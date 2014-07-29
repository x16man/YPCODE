///Created by Wang Junhui.
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ZedGraph
{
    public class FloatingData : List<FloatingDataItem>
    {
        public FloatingData()
        {
        }

        public FloatingDataItem this[String key]
        {
            get
            {
                int index = IndexOf(key);
                if (index >= 0)
                    return (this[index]);
                else
                    return null;
            }
            set
            {
                int idx = this.IndexOf(key);
                if (idx >= 0)
                    this[idx] = value;
            }
        }

        public int IndexOf(string key)
        {
            int index = 0;
            foreach (FloatingDataItem p in this)
            {
                if (String.Compare(p.Key, key, true) == 0)
                    return index;
                index++;
            }

            return -1;
        }

        public Boolean Exists(String key)
        {
            return this.Exists(o => o.Key == key);
        }

        /// <summary>
        /// 如果这个元素已存在，则更新它，否则添加一个元素。
        /// </summary>
        /// <param name="item"></param>
        public void Add2(FloatingDataItem item)
        {
            if (this.Exists(item.Key))
            {
                this[item.Key] = item;
            }
            else
            {
                this.Add(item);
            }
        }
    }

    public class FloatingDataItem
    {
        private double _value = 0.0d;
        private double _x;
        private String _valueString;
        private String _label;
        private String _unit;
        private FontSpec _valueFontSpec = new FontSpec("宋体", 12, Color.Red, false, false, false) { StringAlignment = StringAlignment.Far };
        private FontSpec _unitFontSpec = new FontSpec("宋体", 12, Color.Blue, false, false, false) { StringAlignment = StringAlignment.Far };        
        private IPointList _points;
        private String _valueType = "V";
        private bool _isInstant = true;

        public FloatingDataItem() 
        {
            _valueFontSpec.Border.IsVisible = false;
            _valueFontSpec.Fill.IsVisible = false;
            //_valueFontSpec.Border.Color = Color.Red;
            //_valueFontSpec.Fill.Color = Color.Transparent;

            _unitFontSpec.Border.IsVisible = false;
            _unitFontSpec.Fill.IsVisible = false;
            //_unitFontSpec.Border.Color = Color.Red;
            //_unitFontSpec.Fill.Color = Color.Transparent;
        }

        public String Key { get; set; }

        public Object Tag { get; set; }

        /// <summary>
        /// 表示值的字符串。
        /// </summary>
        public String ValueString
        {
            get
            {
                if (_valueString == null)
                    return _value.ToString();
                return _valueString;
            }
            set { _valueString = value; }
        }

        public double Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public double X
        {
            get { return _x; }
            set
            {
                if (_x != value)
                {
                    _x = value;
                    if (_valueType == "CT" || _valueType == "T")
                    { 
                        int year, month, day, hour, minute, second, millisecond;
                        XDate.XLDateToCalendarDate(_x, out year, out month, out day, out hour, out minute, out second, out millisecond);
                        DateTime dateTime = new DateTime(year, month, day, hour, minute, second, millisecond);
                        _valueString = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
                        return;
                    }
                    if (_points == null) return;
                    if (_points is StockPointList)
                    {
                        var pts = _points as StockPointList;
                        var pt = pts.Find(o => o.X == _x);
                        if (pt != null)
                        {
                            switch (_valueType.ToUpper())
                            {
                                case "V":
                                    _value = pt.Vol;
                                    break;
                                case "O":
                                    _value = pt.Open;
                                    break;
                                case "C":
                                    _value = pt.Close;
                                    break;
                                case "H":
                                    _value = pt.High;
                                    break;
                                case "L":
                                    _value = pt.LowValue;
                                    break;
                                default:
                                    _value = pt.Vol;
                                    break;
                            }
                        }
                    }
                    else if (_points is PointPairList)
                    {
                        var pts = _points as PointPairList;
                        var pt = pts.Find(o => o.X == _x);
                        if (pt != null)
                            _value = pt.Y;
                    }
                }
            }
        }

        public String Label
        {
            get { return (_label == null ? (this.Key ?? "") : _label); }
            set { _label = value; }
        }

        public FontSpec ValueFontSpec
        {
            get { return _valueFontSpec; }
            set { _valueFontSpec = value; }
        }

        public SizeF ValueSizeF { get; set; }

        public String Unit
        {
            get { return _unit ?? ""; }
            set { _unit = value; }
        }

        public FontSpec UnitFontSpec
        {
            get { return _unitFontSpec; }
            set { _unitFontSpec = value; }
        }

        public SizeF UnitSizeF { get; set; }
        
        public IPointList Points
        {
            get { return _points; }
            set { _points = value; }
        }

        /// <summary>
        /// 对于 K 线值标签。O:Open,C:Close,H:High,L:Low,V:Value.
        /// </summary>
        public String ValueType 
        {
            get { return _valueType; }
            set { _valueType = value.ToUpper(); }
        }

        /// <summary>
        /// 是否是跟随光标即时刷新的。默认为 true.
        /// </summary>
        public bool IsInstant
        {
            get { return _isInstant; }
            set { _isInstant = value; }
        }
    }
}
