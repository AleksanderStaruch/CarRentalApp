namespace APBDProject.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("project.FeulType")]
    public partial class FeulType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FeulType()
        {
            Vehicle = new HashSet<Vehicle>();
        }

        [Key]
        public int Fid { get; set; }

        [Required]
        [StringLength(20)]
        public string Feul { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}
