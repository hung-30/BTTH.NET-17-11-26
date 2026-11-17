using System;
using System.Windows.Forms;
using RETAILSALESSYSTEM.BUS;
using RETAILSALESSYSTEM.DTO;

namespace RETAILSALESSYSTEM.GUI
{
    public partial class FormSanPham : Form
    {
        private SanPhamBUS sanPhamBUS = new SanPhamBUS();

        public FormSanPham()
        {
            InitializeComponent();

            // Đăng ký các sự kiện khi mở form và bấm nút
            this.Load += FormSanPham_Load;
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnTimKiem.Click += BtnTimKiem_Click;
            dgvSanPham.CellClick += DgvSanPham_CellClick;
        }

        // 1. Tải danh sách sản phẩm khi vừa mở màn hình
        private void FormSanPham_Load(object sender, EventArgs e)
        {
            LoadDanhSach();
        }

        private void LoadDanhSach()
        {
            dgvSanPham.DataSource = sanPhamBUS.LayDanhSach();
        }

        // 2. Click vào dòng nào trên lưới thì đổ dữ liệu lên TextBox
        private void DgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];
                txtMaSP.Text = row.Cells["MaSP"].Value.ToString();
                txtTenSP.Text = row.Cells["TenSP"].Value.ToString();
                txtGiaBan.Text = row.Cells["GiaBan"].Value.ToString();
                txtSoLuongTon.Text = row.Cells["SoLuongTon"].Value.ToString();
            }
        }

        // 3. Xử lý nút Thêm
        private void BtnThem_Click(object sender, EventArgs e)
        {
            try
            {
                SanPhamDTO sp = new SanPhamDTO();
                sp.MaSP = txtMaSP.Text.Trim();
                sp.TenSP = txtTenSP.Text.Trim();
                sp.GiaBan = Convert.ToDecimal(txtGiaBan.Text);
                sp.SoLuongTon = Convert.ToInt32(txtSoLuongTon.Text);

                if (sanPhamBUS.Them(sp))
                {
                    MessageBox.Show("Thêm sản phẩm thành công vào Database!");
                    LoadDanhSach(); // Gọi lại hàm này để lưới cập nhật dữ liệu mới nhất
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Báo lỗi");
            }
        }

        // 4. Xử lý nút Sửa
        private void BtnSua_Click(object sender, EventArgs e)
        {
            try
            {
                SanPhamDTO sp = new SanPhamDTO();
                sp.MaSP = txtMaSP.Text.Trim(); // Sửa theo mã SP (Mã không đổi)
                sp.TenSP = txtTenSP.Text.Trim();
                sp.GiaBan = Convert.ToDecimal(txtGiaBan.Text);
                sp.SoLuongTon = Convert.ToInt32(txtSoLuongTon.Text);

                if (sanPhamBUS.Sua(sp))
                {
                    MessageBox.Show("Cập nhật thông tin thành công!");
                    LoadDanhSach();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Báo lỗi");
            }
        }

        // 5. Xử lý nút Xóa
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            string maSP = txtMaSP.Text.Trim();
            if (string.IsNullOrEmpty(maSP))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!");
                return;
            }

            DialogResult dialog = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này khỏi CSDL không?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    if (sanPhamBUS.Xoa(maSP))
                    {
                        MessageBox.Show("Đã xóa thành công!");
                        LoadDanhSach();

                        // Làm rỗng các ô nhập liệu
                        txtMaSP.Clear();
                        txtTenSP.Clear();
                        txtGiaBan.Clear();
                        txtSoLuongTon.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa. Lỗi: " + ex.Message);
                }
            }
        }

        // 6. Xử lý nút Tìm kiếm (Dùng từ khóa %)
        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            dgvSanPham.DataSource = sanPhamBUS.TimKiem(tuKhoa);
        }
    }
}