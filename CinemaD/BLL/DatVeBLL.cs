using CinemaD.DAL;
using CinemaD.DTO;
using System.Collections.Generic;

namespace CinemaD.BLL
{
    public class DatVeBLL
    {
        private DatVeDAL datVeDAL = new DatVeDAL();
        private ChonGheDAL chonGheDAL = new ChonGheDAL();

        public List<DatVe> GetAllDatVe()
        {
            return datVeDAL.GetAllDatVe();
        }

        public DatVe GetDatVeById(int id)
        {
            return datVeDAL.GetDatVeById(id);
        }

        public void AddDatVe(DatVe datVe)
        {
            datVeDAL.AddDatVe(datVe);
            foreach (var chonGhe in datVe.ChonGhe)
            {
                chonGheDAL.AddChonGhe(chonGhe);
            }
        }

        public void UpdateDatVe(DatVe datVe)
        {
            datVeDAL.UpdateDatVe(datVe);
        }
        public List<DatVe> GetDatVeByKhachHangId(int maKh)
        {
            return datVeDAL.GetDatVeByKhachHangId(maKh);
        }


        public void DeleteDatVe(int id)
        {
            var chonGhes = chonGheDAL.GetChonGheByMaVe(id);
            foreach (var chonGhe in chonGhes)
            {
                chonGheDAL.DeleteChonGhe(chonGhe.MaVe, chonGhe.SoGhe);
            }
            datVeDAL.DeleteDatVe(id);
        }
    }
}