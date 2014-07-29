
namespace Shmzh.Monitor.Entity
{
    public class ObjTypeInfo
    {
        #region Property
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public string Remark { get; set; }
        #endregion

        public ObjTypeInfo()
        {}

        public override string ToString()
        {
            return string.Format(System.Globalization.CultureInfo.InvariantCulture,
                                 @"{4}:
- Id: {0}
- Name: {1}
- ParentId: {2}
- Remark:{3}
",
                                 this.Id,
                                 this.Name,
                                 this.ParentId,
                                 this.Remark,
                                 this.GetType());
        }
    }
}
