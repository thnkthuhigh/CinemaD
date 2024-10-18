using CinemaD.DTO;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CinemaD.DAL
{
    public class KhachHangDAL
    {
        public List<KhachHang> GetAllKhachHang()
        {
            using (var context = new CinemaDB())
            {
                return context.KhachHang.ToList();
            }
        }

        public KhachHang GetKhachHangById(int id)
        {
            using (var context = new CinemaDB())
            {
                return context.KhachHang.Find(id);
            }
        }

        public KhachHang GetKhachHangBySDT(string sdt)
        {
            using (var context = new CinemaDB())
            {
                return context.KhachHang.FirstOrDefault(kh => kh.SDT == sdt);
            }
        }

        public void AddKhachHang(KhachHang khachHang)
        {
            using (var context = new CinemaDB())
            {
                context.KhachHang.Add(khachHang);
                context.SaveChanges();
            }
        }

        public void UpdateKhachHang(KhachHang khachHang)
        {
            using (var context = new CinemaDB())
            {
                context.Entry(khachHang).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteKhachHang(int id)
        {
            using (var context = new CinemaDB())
            {
                var khachHang = context.KhachHang.Find(id);
                if (khachHang != null)
                {
                    context.KhachHang.Remove(khachHang);
                    context.SaveChanges();
                }
            }
        }
    }
}