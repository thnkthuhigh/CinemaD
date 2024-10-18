using CinemaD.DAL;
using CinemaD.DTO;
using System.Collections.Generic;

public class KhuVucBLL
{
    private KhuVucDAL khuVucDAL;

    public KhuVucBLL()
    {
        khuVucDAL = new KhuVucDAL();
    }

    public List<KhuVuc> GetAllKhuVuc()
    {
        return khuVucDAL.GetAllKhuVuc();
    }

    public KhuVuc GetKhuVucById(int id)
    {
        return khuVucDAL.GetKhuVucById(id);
    }

    public void AddKhuVuc(KhuVuc khuVuc)
    {
        khuVucDAL.AddKhuVuc(khuVuc);
    }

    public void UpdateKhuVuc(KhuVuc khuVuc)
    {
        khuVucDAL.UpdateKhuVuc(khuVuc);
    }

    public void DeleteKhuVuc(int id)
    {
        khuVucDAL.DeleteKhuVuc(id);
    }
}