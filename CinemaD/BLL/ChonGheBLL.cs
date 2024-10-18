using CinemaD.DAL;
using CinemaD.DTO;
using System.Collections.Generic;

namespace CinemaD.BLL
{
    public class ChonGheBLL
    {
        private ChonGheDAL chonGheDAL;

        public ChonGheBLL()
        {
            chonGheDAL = new ChonGheDAL();
        }

        public void AddChonGhe(ChonGhe chonGhe)
        {
            chonGhe.GiaTien = TinhGiaTien(chonGhe.SoGhe);
            chonGheDAL.AddChonGhe(chonGhe);
        }

        public decimal TinhGiaTien(int soGhe)
        {
            if (soGhe <= 5)
                return 5000;
            else if (soGhe <= 10)
                return 6500;
            else
                return 8000;
        }

        public void DeleteChonGhe(int maVe, int soGhe)
        {
            chonGheDAL.DeleteChonGhe(maVe, soGhe);
        }
    }
}

