using System.Collections.Generic;
using System;

public class DatVeDTO
{
    public int MaVe { get; set; }
    public int? MaKh { get; set; }
    public DateTime NgayMua { get; set; }
    public decimal TongTien { get; set; }
    public List<ChonGheDTO> ChonGhe { get; set; }
}