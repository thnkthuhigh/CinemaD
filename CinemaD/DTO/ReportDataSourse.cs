using System.Collections.Generic;
using System;

public class TicketReportData
{
    public string TenKhachHang { get; set; }
    public decimal TongTien { get; set; }
    public DateTime NgayBan { get; set; }
    public List<SeatInfo> DanhSachGhe { get; set; }
}

public class SeatInfo
{
    public int SoGhe { get; set; }
    public decimal GiaTien { get; set; }
}