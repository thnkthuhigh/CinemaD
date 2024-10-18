using System;
using System.Linq;
using System.Windows.Forms;
using CinemaD.BLL;
using CinemaD.DTO;

namespace CinemaD.UI
{
    public partial class Form2 : Form
    {
        private KhuVucBLL khuVucBLL;

        public Form2()
        {
            InitializeComponent();
            khuVucBLL = new KhuVucBLL();
            LoadDataGridView();
        }

        private void btnThoatKV_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddKV_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddTenKV.Text) || string.IsNullOrWhiteSpace(txtAddMaKV.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khu vực và mã định danh.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtAddMaKV.Text, out int maKhuVuc))
            {
                MessageBox.Show("Mã khu vực phải là một số nguyên hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var khuVuc = new KhuVuc
                {
                    MaKhuVuc = maKhuVuc,
                    TenKhuVuc = txtAddTenKV.Text
                };

                khuVucBLL.AddKhuVuc(khuVuc);

                MessageBox.Show("Thêm khu vực thành công!", "Thông báo", MessageBoxButtons.OK);
                txtAddTenKV.Clear();
                txtAddMaKV.Clear();
                LoadDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDataGridView()
        {
            try
            {
                var khuVucList = khuVucBLL.GetAllKhuVuc();

                datagridKhuVuc.Rows.Clear();

                foreach (var kv in khuVucList)
                {
                    int index = datagridKhuVuc.Rows.Add();
                    datagridKhuVuc.Rows[index].Cells["MaKhuVucGrid"].Value = kv.MaKhuVuc;
                    datagridKhuVuc.Rows[index].Cells["TenKhuVucGrid"].Value = kv.TenKhuVuc;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSuaKV_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddMaKV.Text) || !int.TryParse(txtAddMaKV.Text, out int maKhuVuc))
            {
                MessageBox.Show("Mã khu vực phải là một số nguyên hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAddTenKV.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khu vực mới.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var khuVucToUpdate = khuVucBLL.GetKhuVucById(maKhuVuc);

                if (khuVucToUpdate != null)
                {
                    khuVucToUpdate.TenKhuVuc = txtAddTenKV.Text;
                    khuVucBLL.UpdateKhuVuc(khuVucToUpdate);

                    MessageBox.Show("Cập nhật khu vực thành công!", "Thông báo", MessageBoxButtons.OK);
                    LoadDataGridView();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khu vực với mã này để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaKV_Click_1(object sender, EventArgs e)
        {
            if (!int.TryParse(txtAddMaKV.Text, out int khuVucId))
            {
                MessageBox.Show("Mã khu vực không hợp lệ!");
                return;
            }

            try
            {
                var khuVucToDelete = khuVucBLL.GetKhuVucById(khuVucId);

                if (khuVucToDelete == null)
                {
                    MessageBox.Show("Không tìm thấy khu vực!");
                    return;
                }

                khuVucBLL.DeleteKhuVuc(khuVucId);
                LoadDataGridView();

                MessageBox.Show("Xóa khu vực thành công!", "Thông báo", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoatKV_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void datagridKhuVuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0) // Đảm bảo người dùng không nhấp vào tiêu đề cột
            {
                DataGridViewRow row = datagridKhuVuc.Rows[e.RowIndex];

                // Lấy giá trị từ các ô của hàng được chọn
                string maKhuVuc = row.Cells["MaKhuVucGrid"].Value.ToString();
                string tenKhuVuc = row.Cells["TenKhuVucGrid"].Value.ToString();

                // Điền giá trị vào các TextBox
                txtAddMaKV.Text = maKhuVuc;
                txtAddTenKV.Text = tenKhuVuc;
            }

        }
    }
}
