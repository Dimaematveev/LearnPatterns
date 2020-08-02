namespace DataBase.BL
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ModelDevice")]
    public partial class ModelDevice
    {
        public int ID { get; set; }

        public int TypeDeviceID { get; set; }

        [StringLength(10)]
        public string Name { get; set; }

        public virtual TypeDevice TypeDevice { get; set; }
    }
}
