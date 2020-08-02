namespace DataBase.BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Model")]
    public partial class Model
    {
        public int ID { get; set; }

        public int TypeID { get; set; }

        [StringLength(10)]
        public string Name { get; set; }

        public virtual Type Type { get; set; }
    }
}
