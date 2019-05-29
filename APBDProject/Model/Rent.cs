namespace APBDProject.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("project.Rent")]
    public partial class Rent
    {
        [Key]
        public int Rid { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfRental { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfReturn { get; set; }

        public int Client_Id { get; set; }

        public int User_Id { get; set; }

        public int Vehicle_Id { get; set; }

        public virtual Client Client { get; set; }

        public virtual User User { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}
