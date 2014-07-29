using System;
using System.Collections.Generic;
using System.Text;

namespace Shmzh.Monitor.Entity
{
    public class ObjTypeAttrInfo
    {
        #region propetry
        public int Id { get; set; }
        public string Name { get; set; }
        public short SerialNo { get; set; }
        public int TypeId { get; set; }
        public string FieldName { get; set; }
        public string DataType { get; set; }
        #endregion
        public ObjTypeAttrInfo()
        {
        }

        public override string ToString()
        {
            return string.Format(System.Globalization.CultureInfo.InvariantCulture,
                                 @"{6}:
- Id: {0}
- Name: {1}
- SerialNo: {2}
- TypeId:{3}
- FieldName:{4}
- DataType: {5}",
                                 this.Id,
                                 this.Name,
                                 this.SerialNo,
                                 this.TypeId,
                                 this.FieldName,
                                 this.DataType,
                                 this.GetType());
        }
    }
}
