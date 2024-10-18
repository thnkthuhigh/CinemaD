using System.Collections.Generic;

public class KhachHangDTO
{
    public int MaKh { get; set; }
    public string TenKH { get; set; }
    public string GioiTinh { get; set; }
    public string SDT { get; set; }
    public int? MaKhuVuc { get; set; }
    public List<DatVeDTO> DatVe { get; set; }
}