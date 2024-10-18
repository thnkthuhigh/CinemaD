using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CinemaD.DTO
{
    public partial class CinemaDB : DbContext
    {
        public CinemaDB()
            : base("name=CinemaDB")
        {
        }

        public virtual DbSet<ChonGhe> ChonGhe { get; set; }
        public virtual DbSet<DatVe> DatVe { get; set; }
        public virtual DbSet<KhachHang> KhachHang { get; set; }
        public virtual DbSet<KhuVuc> KhuVuc { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChonGhe>()
                .Property(e => e.GiaTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DatVe>()
                .HasMany(e => e.ChonGhe)
                .WithRequired(e => e.DatVe)
                .WillCascadeOnDelete(false);
        }
    }
}
