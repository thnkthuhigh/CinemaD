namespace CinemaD.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChonGhe")]
    public partial class ChonGhe
    {
        public int MaVe { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SoGhe { get; set; }

        public decimal? GiaTien { get; set; }

        public virtual DatVe DatVe { get; set; }
    }
}
