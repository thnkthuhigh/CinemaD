namespace CinemaD.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DatVe")]
    public partial class DatVe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DatVe()
        {
            ChonGhe = new HashSet<ChonGhe>();
        }

        [Key]
        public int MaVe { get; set; }

        public int? MaKh { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayMua { get; set; }

        public decimal TongTien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChonGhe> ChonGhe { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
