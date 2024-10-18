using CinemaD.DAL;
using CinemaD.DTO;
using System.Collections.Generic;

namespace CinemaD.BLL
{
    public class KhachHangBLL
    {
        private KhachHangDAL khachHangDAL = new KhachHangDAL();

        public List<KhachHang> GetAllKhachHang()
        {
            return khachHangDAL.GetAllKhachHang();
        }

        public KhachHang GetKhachHangById(int id)
        {
            return khachHangDAL.GetKhachHangById(id);
        }

        public KhachHang GetKhachHangBySDT(string sdt)
        {
            return khachHangDAL.GetKhachHangBySDT(sdt);
        }

        public void AddKhachHang(KhachHang khachHang)
        {
            khachHangDAL.AddKhachHang(khachHang);
        }


        public void UpdateKhachHang(KhachHang khachHang)
        {
            khachHangDAL.UpdateKhachHang(khachHang);
        }

        public void DeleteKhachHang(int id)
        {
            khachHangDAL.DeleteKhachHang(id);
        }
    }
}