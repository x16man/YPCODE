using System;
using System.Collections.Generic;
using System.Text;

namespace Shmzh.Monitor.Entity
{
    public class MonitorObjInfo
    {
        #region property
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public int SerialNo { get; set; }
        public string AttrField01 { get; set; }
        public string AttrField02 { get; set; }
        public string AttrField03 { get; set; }
        public string AttrField04 { get; set; }
        public string AttrField05 { get; set; }
        public string AttrField06 { get; set; }
        public string AttrField07 { get; set; }
        public string AttrField08 { get; set; }
        public string AttrField09 { get; set; }
        public string AttrField10 { get; set; }
        public string AttrField11 { get; set; }
        public string AttrField12 { get; set; }
        public string AttrField13 { get; set; }
        public string AttrField14 { get; set; }
        public string AttrField15 { get; set; }
        public string AttrField16 { get; set; }
        public string AttrField17 { get; set; }
        public string AttrField18 { get; set; }
        public string AttrField19 { get; set; }
        public string AttrField20 { get; set; }
        
        #endregion

        public MonitorObjInfo()
        {
        }
        public override string ToString()
        {
            return string.Format(System.Globalization.CultureInfo.InvariantCulture,
                                 @"{25}:
- Id: {0}
- Code: {1}
- Name: {2}
- TypeId: {3}
- SerialNo:{4}
- AttrField01:{5}
- AttrField02:{6}
- AttrField03:{7}
- AttrField04:{8}
- AttrField05:{9}
- AttrField06:{10}
- AttrField07:{11}
- AttrField08:{12}
- AttrField09:{13}
- AttrField10:{14}
- AttrField11:{15}
- AttrField12:{16}
- AttrField13:{17}
- AttrField14:{18}
- AttrField15:{19}
- AttrField16:{20}
- AttrField17:{21}
- AttrField18:{22}
- AttrField19:{23}
- AttrField20:{24}
",
                                 this.Id,
                                 this.Code,
                                 this.Name,
                                 this.TypeId,
                                 this.SerialNo,
                                 this.AttrField01,
                                 this.AttrField02,
                                 this.AttrField03,
                                 this.AttrField04,
                                 this.AttrField05,
                                 this.AttrField06,
                                 this.AttrField07,
                                 this.AttrField08,
                                 this.AttrField09,
                                 this.AttrField10,
                                 this.AttrField11,
                                 this.AttrField12,
                                 this.AttrField13,
                                 this.AttrField14,
                                 this.AttrField15,
                                 this.AttrField16,
                                 this.AttrField17,
                                 this.AttrField18,
                                 this.AttrField19,
                                 this.AttrField20,
                                 this.GetType());
        }
    }
}
