using CinemaD.DTO;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CinemaD.DAL
{
    public class KhuVucDAL
    {
        public List<KhuVuc> GetAllKhuVuc()
        {
            using (var context = new CinemaDB())
            {
                return context.KhuVuc.ToList();
            }
        }

        public KhuVuc GetKhuVucById(int id)
        {
            using (var context = new CinemaDB())
            {
                return context.KhuVuc.Find(id);
            }
        }

        public void AddKhuVuc(KhuVuc khuVuc)
        {
            using (var context = new CinemaDB())
            {
                context.KhuVuc.Add(khuVuc);
                context.SaveChanges();
            }
        }

        public void UpdateKhuVuc(KhuVuc khuVuc)
        {
            using (var context = new CinemaDB())
            {
                context.Entry(khuVuc).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteKhuVuc(int id)
        {
            using (var context = new CinemaDB())
            {
                var khuVuc = context.KhuVuc.Find(id);
                if (khuVuc != null)
                {
                    context.KhuVuc.Remove(khuVuc);
                    context.SaveChanges();
                }
            }
        }
    }
}