using CinemaD.DTO;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CinemaD.DAL
{
    public class DatVeDAL
    {
        public List<DatVe> GetAllDatVe()
        {
            using (var context = new CinemaDB())
            {
                return context.DatVe.Include(dv => dv.KhachHang).Include(dv => dv.ChonGhe).ToList();
            }
        }

        public DatVe GetDatVeById(int id)
        {
            using (var context = new CinemaDB())
            {
                return context.DatVe.Include(dv => dv.KhachHang).Include(dv => dv.ChonGhe).FirstOrDefault(dv => dv.MaVe == id);
            }
        }

        public List<DatVe> GetDatVeByKhachHangId(int maKh)
        {
            using (var context = new CinemaDB())
            {
                return context.DatVe.Where(dv => dv.MaKh == maKh).ToList();
            }
        }
        public void AddDatVe(DatVe datVe)
        {
            using (var context = new CinemaDB())
            {
                context.DatVe.Add(datVe);
                context.SaveChanges();
            }
        }

        public void UpdateDatVe(DatVe datVe)
        {
            using (var context = new CinemaDB())
            {
                context.Entry(datVe).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteDatVe(int id)
        {
            using (var context = new CinemaDB())
            {
                var datVe = context.DatVe.Find(id);
                if (datVe != null)
                {
                    context.DatVe.Remove(datVe);
                    context.SaveChanges();
                }
            }
        }
    }
}