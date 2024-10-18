using CinemaD.DTO;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CinemaD.DAL
{
    public class ChonGheDAL
    {


        public List<ChonGhe> GetChonGheByMaVe(int maVe)
        {
            using (var context = new CinemaDB())
            {
                return context.ChonGhe.Where(cg => cg.MaVe == maVe).ToList();
            }
        }

        public void AddChonGhe(ChonGhe chonGhe)
        {
            using (var context = new CinemaDB())
            {
                context.ChonGhe.Add(chonGhe);
                context.SaveChanges();
            }
        }

        public void DeleteChonGhe(int maVe, int soGhe)
        {
            using (var context = new CinemaDB())
            {
                var chonGhe = context.ChonGhe.FirstOrDefault(cg => cg.MaVe == maVe && cg.SoGhe == soGhe);
                if (chonGhe != null)
                {
                    context.ChonGhe.Remove(chonGhe);
                    context.SaveChanges();
                }
            }
        }
    }
}