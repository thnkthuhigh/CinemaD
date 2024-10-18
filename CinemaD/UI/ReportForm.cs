using CinemaD.DTO;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CinemaD.UI
{
    public partial class ReportForm : Form
    {
        private TicketReportData _reportData;

        public ReportForm()
        {
            InitializeComponent();
        }

        public void SetReportData(TicketReportData reportData)
        {
            _reportData = reportData;
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            if (_reportData == null)
            {
                MessageBox.Show("Không có dữ liệu báo cáo.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Sử dụng đường dẫn chính xác đến file RDLC
            reportViewer1.LocalReport.ReportPath = "D:\\CODE\\CinemaD\\CinemaD\\UI\\CinemaReport.rdlc";

            // Tạo các tham số báo cáo
            var parameters = new ReportParameter[]
            {
            new ReportParameter("TenKhachHang", _reportData.TenKhachHang),
            new ReportParameter("TongTien", _reportData.TongTien.ToString("C")),
            new ReportParameter("NgayBan", _reportData.NgayBan.ToString("dd/MM/yyyy HH:mm:ss"))
            };

            // Đặt các tham số cho báo cáo
            reportViewer1.LocalReport.SetParameters(parameters);

            // Thêm nguồn dữ liệu cho bảng ghế
            var seatData = new ReportDataSource("SeatData", _reportData.DanhSachGhe);
            reportViewer1.LocalReport.DataSources.Add(seatData);

            reportViewer1.RefreshReport();
        }
    }
}