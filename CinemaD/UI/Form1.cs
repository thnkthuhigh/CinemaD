using CinemaD.DTO;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using CinemaD.UI;
using CinemaD.BLL;


namespace CinemaD
{
    public partial class Form1 : Form
    {
        private KhachHangBLL khachHangBLL;
        private DatVeBLL datVeBLL;
        private KhuVucBLL khuVucBLL;
        private ChonGheBLL chonGheBLL;

        public Form1()
        {
            InitializeComponent();
            khachHangBLL = new KhachHangBLL();
            datVeBLL = new DatVeBLL();
            khuVucBLL = new KhuVucBLL();
            chonGheBLL = new ChonGheBLL();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            rdoNam.Checked = true; // Default gender
            KhoiTaoGhe(); // Initialize seats
            LoadKhuVuc();
            LoadTicketInformation();
        }

        private void LoadKhuVuc()
        {
            var khuVucs = khuVucBLL.GetAllKhuVuc();
            Console.WriteLine($"Số lượng khu vực: {khuVucs.Count}");

            if (khuVucs.Any())
            {
                cmbKhuVuc.DataSource = khuVucs;
                cmbKhuVuc.DisplayMember = "TenKhuVuc";
                cmbKhuVuc.ValueMember = "MaKhuVuc";
            }
            else
            {
                MessageBox.Show("Không có dữ liệu khu vực.");
            }
        }

        private void KhoiTaoGhe()
        {
            System.Windows.Forms.Button btn;
            int x, soLuongGhe = 15;
            int y = 20, kc = 10;
            int count = 1;

            var allDatVe = datVeBLL.GetAllDatVe();
            Console.WriteLine($"Số lượng đặt vé: {allDatVe.Count}");

            var bookedSeats = allDatVe.SelectMany(dv => dv.ChonGhe).Select(cg => cg.SoGhe).ToList();
            Console.WriteLine($"Số lượng ghế đã đặt: {bookedSeats.Count}");

            pnGhe.Controls.Clear();

            for (int i = 0; i < 3; i++)
            {
                x = 15;
                for (int j = 0; j < soLuongGhe / 3; j++)
                {
                    btn = new System.Windows.Forms.Button();
                    btn.Location = new Point(x + 80 * j, y + 46 * i);
                    btn.Name = "btn" + count;
                    btn.Size = new Size(80, 46);
                    btn.TabIndex = 0;
                    btn.Text = count.ToString();
                    btn.UseVisualStyleBackColor = true;

                    if (bookedSeats.Contains(count))
                    {
                        btn.BackColor = Color.Red; // Mark booked seats
                        btn.Enabled = false; // Disable booking for booked seats
                    }
                    else
                    {
                        btn.BackColor = Color.White; // Mark available seats
                    }

                    btn.Click += Btn_Click;
                    pnGhe.Controls.Add(btn);
                    count++;
                    x += kc;
                }
                y += kc;
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button btn = (System.Windows.Forms.Button)sender;
            if (btn.BackColor == Color.Red)
            {
                MessageBox.Show("Ghế đã được mua");
                return;
            }

            if (btn.BackColor == Color.White)
            {
                btn.BackColor = Color.Pink;
                btn.ForeColor = Color.Red;
            }
            else
            {
                btn.BackColor = Color.White;
                btn.ForeColor = Color.Black;
            }

            RecalculateTotal();
        }

        private void RecalculateTotal()
        {
            decimal total = 0;
            foreach (System.Windows.Forms.Button btnGhe in pnGhe.Controls.OfType<System.Windows.Forms.Button>().Where(x => x.BackColor == Color.Pink))
            {
                int soGhe = int.Parse(btnGhe.Text);
                total += chonGheBLL.TinhGiaTien(soGhe);
            }

            txtTongTien.Text = total.ToString("C");
        }

        private double TinhTien(int soGhe)
        {
            if (soGhe <= 5)
            {
                return 5000;
            }
            else if (soGhe <= 10)
            {
                return 6500;
            }
            return 8000;
        }

        private void btnDatVe_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSDT.Text) || string.IsNullOrWhiteSpace(txtTenKH.Text))
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin");
                    return;
                }

                var customer = khachHangBLL.GetKhachHangBySDT(txtSDT.Text);
                if (customer == null)
                {
                    customer = new KhachHang
                    {
                        TenKH = txtTenKH.Text,
                        SDT = txtSDT.Text,
                        GioiTinh = rdoNam.Checked ? "Nam" : "Nữ",
                        MaKhuVuc = (int)cmbKhuVuc.SelectedValue
                    };
                    khachHangBLL.AddKhachHang(customer);
                }

                decimal tongTien;
                if (!decimal.TryParse(txtTongTien.Text.Replace("₫", "").Trim(), out tongTien))
                {
                    MessageBox.Show("Tổng tiền không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var datVe = new DatVe
                {
                    MaKh = customer.MaKh,
                    NgayMua = DateTime.Now,
                    TongTien = tongTien
                };
                datVeBLL.AddDatVe(datVe);

                var selectedSeats = pnGhe.Controls.OfType<System.Windows.Forms.Button>()
                .Where(x => x.BackColor == Color.Pink)
                .Select(btn => new ChonGhe
                {
                    MaVe = datVe.MaVe,
                    SoGhe = int.Parse(btn.Text),
                    // GiaTien sẽ được tính trong ChonGheBLL
                }).ToList();

                foreach (var seat in selectedSeats)
                {
                    chonGheBLL.AddChonGhe(seat);
                }

                MessageBox.Show("Đặt vé thành công!");
                LoadTicketInformation();
                KhoiTaoGhe();
                RecalculateTotal();

                ShowTicketReport(datVe.MaVe);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}");
            }
        }
        private void ShowTicketReport(int maVe)
        {
            try
            {
                var datVe = datVeBLL.GetDatVeById(maVe);
                if (datVe == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin vé.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var reportData = new TicketReportData
                {
                    TenKhachHang = datVe.KhachHang.TenKH,
                    TongTien = datVe.TongTien,
                    NgayBan = datVe.NgayMua,
                    DanhSachGhe = datVe.ChonGhe.Select(cg => new SeatInfo
                    {
                        SoGhe = cg.SoGhe,
                        GiaTien = cg.GiaTien ?? 0
                    }).ToList()
                };

                using (var reportForm = new ReportForm())
                {
                    reportForm.SetReportData(reportData);
                    reportForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi hiển thị báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTicketInformation()
        {
            ThongTinKH.Rows.Clear();

            var bookings = datVeBLL.GetAllDatVe();

            foreach (var booking in bookings)
            {
                int index = ThongTinKH.Rows.Add();
                ThongTinKH.Rows[index].Cells["MaVe"].Value = booking.MaVe;
                ThongTinKH.Rows[index].Cells["TenKH"].Value = booking.KhachHang?.TenKH ?? "N/A";
                ThongTinKH.Rows[index].Cells["NgayMua"].Value = booking.NgayMua;
                ThongTinKH.Rows[index].Cells["TongTien"].Value = booking.TongTien;
            }
        }



        private void BtnHuy_Click(object sender, EventArgs e)
        {
            foreach (System.Windows.Forms.Button btnGhe in pnGhe.Controls.OfType<System.Windows.Forms.Button>().Where(x => x.BackColor == Color.Pink))
            {
                btnGhe.BackColor = Color.White;
                btnGhe.ForeColor = Color.Black;
            }
            RecalculateTotal();
        }

        private void ThongTinKH_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int maVe = (int)ThongTinKH.Rows[e.RowIndex].Cells["MaVe"].Value;

                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa vé có mã {maVe}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        var datVe = datVeBLL.GetDatVeById(maVe);
                        if (datVe == null)
                        {
                            MessageBox.Show("Không tìm thấy thông tin vé!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        int maKh = (int)datVe.MaKh;

                        // Xóa vé
                        datVeBLL.DeleteDatVe(maVe);

                        // Kiểm tra xem khách hàng còn vé nào không
                        var remainingTickets = datVeBLL.GetDatVeByKhachHangId(maKh);
                        if (remainingTickets.Count == 0)
                        {
                            // Nếu không còn vé, xóa thông tin khách hàng
                            khachHangBLL.DeleteKhachHang(maKh);
                            MessageBox.Show("Xóa vé thành công! Thông tin khách hàng cũng đã được xóa do không còn vé.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Xóa vé thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        LoadTicketInformation();
                        KhoiTaoGhe();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Có lỗi xảy ra khi xóa vé: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }




        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            LoadKhuVuc();
        }
    }
}