namespace APBDProject.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("project.Vehicle")]
    public partial class Vehicle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vehicle()
        {
            Rent = new HashSet<Rent>();
        }

        [Key]
        public int Vid { get; set; }

        [Required]
        [StringLength(17)]
        public string VIN { get; set; }

        public int Type_Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Brand { get; set; }

        [Required]
        [StringLength(20)]
        public string Model { get; set; }

        [Required]
        [StringLength(20)]
        public string Color { get; set; }

        public int MakeYear { get; set; }

        public int FeulType_Id { get; set; }

        public int PriceByDay { get; set; }

        public int Mileage { get; set; }

        [Required]
        [StringLength(3)]
        public string IfRent { get; set; }

        public virtual FeulType FeulType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rent> Rent { get; set; }

        public virtual Type Type { get; set; }

        public override string ToString()
        {
            return Type.Name + " " + Brand + " " + Model + " " + Color + " " + PriceByDay;
        }


    }
}
