using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Reflection;
using System.IO;
using Ciloci.Flee;
using Shmzh.Monitor.Data;


namespace Shmzh.Monitor.Gadget
{
    public class Utils
    {
        private static readonly String RootPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        
        public static String GetImagePath(String strFileName)
        {
            return Path.Combine(RootPath, @"Images\" + strFileName);
        }

        /// <summary>
        /// 计算表达式的值。
        /// </summary>
        /// <param name="strExp">表达式。</param>
        /// <param name="value">值。</param>
        /// <returns></returns>
        public static String CalcExpString(String strExp, Double value)
        {
            strExp = strExp.Replace("'", "\"").Replace("\\", "\\\\");
            var myContext = new ExpressionContext();
            if (value.Equals(Double.MinValue)) value /= 10;//因Double.MinValue时，计算表达式有错，故除以10；
            var variables = myContext.Variables;
            variables.Add("value", value);
            var myExpression = myContext.CompileGeneric<string>(strExp);
            var retValue = myExpression.Evaluate();
            return retValue;
        }

        /// <summary>
        /// 计算表达式的值。
        /// </summary>
        /// <param name="strExp">表达式。</param>
        /// <param name="value">值。</param>
        /// <param name="monitorObj">MonitorObj.如果没有属性值，请传入null或""。</param>
        /// <returns></returns>
        public static String CalcExpString(String strExp, Double value, String monitorObj)
        {
            strExp = ReplaceAttrToValue(strExp, monitorObj);
            return CalcExpString(strExp, value);
        }

        /// <summary>
        /// 计算表达式的值。
        /// </summary>
        /// <param name="strExp">表达式。</param>
        /// <param name="value">值。</param>
        /// <returns></returns>
        public static Int32 CalcExpInt(String strExp, Double value)
        {
            var myContext = new ExpressionContext();
            if (value.Equals(Double.MinValue)) value /= 10;//因Double.MinValue时，计算表达式有错，故除以10；
            var variables = myContext.Variables;
            variables.Add("value", value);
            var myExpression = myContext.CompileGeneric<int>(strExp);
            var retValue = myExpression.Evaluate();
            return retValue;
        }

        /// <summary>
        /// 计算表达式的值。
        /// </summary>
        /// <param name="strExp">表达式。</param>
        /// <param name="value">值。</param>
        /// <param name="monitorObj">MonitorObj.如果没有属性值，请传入null或""。</param>
        /// <returns></returns>
        public static Int32 CalcExpInt(String strExp, Double value, String monitorObj)
        {
            strExp = ReplaceAttrToValue(strExp, monitorObj);
            return CalcExpInt(strExp, value);
        }

        /// <summary>
        /// 是否是表达式。
        /// </summary>
        /// <param name="strExp">要判断的字符串。</param>
        /// <returns></returns>
        public static Boolean IsExp(String strExp)
        {
            return (strExp.IndexOf("value") != -1);
        }

        /// <summary>
        /// 替换表达式中的属性定义为属性值。
        /// </summary>
        /// <param name="strExp"></param>
        /// <param name="monitorObj"></param>
        /// <returns></returns>
        private static String ReplaceAttrToValue(String strExp, String monitorObj)
        {
            if (!String.IsNullOrEmpty(monitorObj))
            {
                var attrRegex = new Regex(@"\[[0-9|A-Z|a-z|-]*\]");
                var mc = attrRegex.Matches(strExp);
                var attrs = new Dictionary<string, string>();
                foreach (Match match in mc)
                {
                    if (!attrs.ContainsKey(match.ToString()))
                    {
                        var attrValue = GetAttrValue(monitorObj, match.ToString());
                        attrs.Add(match.ToString(), attrValue);
                    }
                }
                foreach (var attr in attrs)
                {
                    strExp = strExp.Replace(attr.Key, attr.Value);
                }
            }
            return strExp;
        }

        /// <summary>
        /// 获取单个属性的值。
        /// </summary>
        /// <param name="monitorObj">MonitorObj</param>
        /// <param name="attribute">attribute</param>
        /// <returns></returns>
        public static String GetAttrValue(String monitorObj, String attribute)
        {
            attribute = attribute.Replace("[", String.Empty).Replace("]", String.Empty);

            var obj = GlobleVariables.MonitorObjList.Find(item => item.Code == monitorObj);
            if(obj != null)
            {
                switch(attribute.ToUpper())
                {
                    case "ATTRFIELD01":
                        return obj.AttrField01;                        
                    case "ATTRFIELD02":
                        return obj.AttrField02;
                    case "ATTRFIELD03":
                        return obj.AttrField03;
                    case "ATTRFIELD04":
                        return obj.AttrField04;
                    case "ATTRFIELD05":
                        return obj.AttrField05;
                    case "ATTRFIELD06":
                        return obj.AttrField06;
                    case "ATTRFIELD07":
                        return obj.AttrField07;
                    case "ATTRFIELD08":
                        return obj.AttrField08;
                    case "ATTRFIELD09":
                        return obj.AttrField09;
                    case "ATTRFIELD10":
                        return obj.AttrField10;
                    case "ATTRFIELD11":
                        return obj.AttrField11;
                    case "ATTRFIELD12":
                        return obj.AttrField12;
                    case "ATTRFIELD13":
                        return obj.AttrField13;
                    case "ATTRFIELD14":
                        return obj.AttrField14;
                    case "ATTRFIELD15":
                        return obj.AttrField15;
                    case "ATTRFIELD16":
                        return obj.AttrField16;
                    case "ATTRFIELD17":
                        return obj.AttrField17;
                    case "ATTRFIELD18":
                        return obj.AttrField18;
                    case "ATTRFIELD19":
                        return obj.AttrField19;
                    case "ATTRFIELD20":
                        return obj.AttrField20;
                    default:
                        return "0.0";
                }    
            }
            return "0.0";

            //var result = DataProvider.MonitorObjProvider.GetAttributeValue(monitorObj, attribute);
            //return String.IsNullOrEmpty(result) ? "0.0" : result;
        }

        /// <summary>
        /// 验证是否是单个属性。
        /// </summary>
        /// <param name="strAttr">属性字符串，或者常数值。</param>
        /// <returns></returns>
        public static Boolean IsAttribute(String strAttr)
        {
            return (strAttr.StartsWith("[") && strAttr.EndsWith("]") && !strAttr.Substring(1).Contains("["));
        }

        public static String GetDecimalDigits(Double number, Int32 decimalDigits)
        {
            if (decimalDigits >= 0)
            {
                return number.ToString("F" + decimalDigits);
            }
            else
            {
                var temp = Convert.ToInt32(Math.Pow(10D, Math.Abs(decimalDigits)));
                return (Convert.ToInt32(number / temp) * temp).ToString("F0");
            }
        }

        /// <summary>
        /// 是否是调试模式。
        /// </summary>
        public static Boolean IsDebug { get; set; }

    }
}
