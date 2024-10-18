using System.Collections.Generic;

public class KhuVucDTO
{
    public int MaKhuVuc { get; set; }
    public string TenKhuVuc { get; set; }
    public List<KhachHangDTO> KhachHang { get; set; }
}