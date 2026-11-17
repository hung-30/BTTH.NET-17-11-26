namespace RETAILSALESSYSTEM.GUI
{
    partial class FormBanHang
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            txtMaSP = new TextBox();
            nudSoLuong = new NumericUpDown();
            btnThem = new Button();
            dgvGioHang = new DataGridView();
            MaSP = new DataGridViewTextBoxColumn();
            SoLuong = new DataGridViewTextBoxColumn();
            DonGia = new DataGridViewTextBoxColumn();
            ThanhTien = new DataGridViewTextBoxColumn();
            txtMaKH = new TextBox();
            lblTongTien = new Label();
            btnThanhToan = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)nudSoLuong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvGioHang).BeginInit();
            SuspendLayout();
            // 
            // txtMaSP
            // 
            txtMaSP.Location = new Point(100, 25);
            txtMaSP.Margin = new Padding(3, 4, 3, 4);
            txtMaSP.Name = "txtMaSP";
            txtMaSP.Size = new Size(150, 27);
            txtMaSP.TabIndex = 0;
            // 
            // nudSoLuong
            // 
            nudSoLuong.Location = new Point(340, 25);
            nudSoLuong.Margin = new Padding(3, 4, 3, 4);
            nudSoLuong.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudSoLuong.Name = "nudSoLuong";
            nudSoLuong.Size = new Size(80, 27);
            nudSoLuong.TabIndex = 1;
            nudSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnThem
            // 
            btnThem.Location = new Point(440, 19);
            btnThem.Margin = new Padding(3, 4, 3, 4);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(100, 38);
            btnThem.TabIndex = 2;
            btnThem.Text = "Thêm vào giỏ";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // dgvGioHang
            // 
            dgvGioHang.AllowUserToAddRows = false;
            dgvGioHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGioHang.Columns.AddRange(new DataGridViewColumn[] { MaSP, SoLuong, DonGia, ThanhTien });
            dgvGioHang.Location = new Point(20, 88);
            dgvGioHang.Margin = new Padding(3, 4, 3, 4);
            dgvGioHang.Name = "dgvGioHang";
            dgvGioHang.RowHeadersWidth = 51;
            dgvGioHang.RowTemplate.Height = 24;
            dgvGioHang.Size = new Size(750, 312);
            dgvGioHang.TabIndex = 3;
            // 
            // MaSP
            // 
            MaSP.HeaderText = "Mã Sản Phẩm";
            MaSP.MinimumWidth = 6;
            MaSP.Name = "MaSP";
            MaSP.ReadOnly = true;
            MaSP.Width = 150;
            // 
            // SoLuong
            // 
            SoLuong.HeaderText = "Số Lượng";
            SoLuong.MinimumWidth = 6;
            SoLuong.Name = "SoLuong";
            SoLuong.ReadOnly = true;
            SoLuong.Width = 125;
            // 
            // DonGia
            // 
            DonGia.HeaderText = "Đơn Giá";
            DonGia.MinimumWidth = 6;
            DonGia.Name = "DonGia";
            DonGia.ReadOnly = true;
            DonGia.Width = 150;
            // 
            // ThanhTien
            // 
            ThanhTien.HeaderText = "Thành Tiền";
            ThanhTien.MinimumWidth = 6;
            ThanhTien.Name = "ThanhTien";
            ThanhTien.ReadOnly = true;
            ThanhTien.Width = 150;
            // 
            // txtMaKH
            // 
            txtMaKH.Location = new Point(143, 436);
            txtMaKH.Margin = new Padding(3, 4, 3, 4);
            txtMaKH.Name = "txtMaKH";
            txtMaKH.Size = new Size(150, 27);
            txtMaKH.TabIndex = 4;
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTongTien.ForeColor = Color.Red;
            lblTongTien.Location = new Point(450, 431);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(99, 31);
            lblTongTien.TabIndex = 5;
            lblTongTien.Text = "0 VNĐ";
            // 
            // btnThanhToan
            // 
            btnThanhToan.BackColor = Color.LightGreen;
            btnThanhToan.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThanhToan.Location = new Point(20, 500);
            btnThanhToan.Margin = new Padding(3, 4, 3, 4);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new Size(750, 62);
            btnThanhToan.TabIndex = 6;
            btnThanhToan.Text = "THANH TOÁN";
            btnThanhToan.UseVisualStyleBackColor = false;
            btnThanhToan.Click += btnThanhToan_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 29);
            label1.Name = "label1";
            label1.Size = new Size(53, 20);
            label1.TabIndex = 7;
            label1.Text = "Mã SP:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(270, 29);
            label2.Name = "label2";
            label2.Size = new Size(72, 20);
            label2.TabIndex = 8;
            label2.Text = "Số lượng:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 441);
            label3.Name = "label3";
            label3.Size = new Size(117, 20);
            label3.TabIndex = 9;
            label3.Text = "Mã Khách Hàng:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(330, 438);
            label4.Name = "label4";
            label4.Size = new Size(100, 25);
            label4.TabIndex = 10;
            label4.Text = "Tổng tiền:";
            // 
            // FormBanHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnThanhToan);
            Controls.Add(lblTongTien);
            Controls.Add(txtMaKH);
            Controls.Add(dgvGioHang);
            Controls.Add(btnThem);
            Controls.Add(nudSoLuong);
            Controls.Add(txtMaSP);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormBanHang";
            Text = "Màn Hình Bán Hàng - Lập Hóa Đơn";
            ((System.ComponentModel.ISupportInitialize)nudSoLuong).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvGioHang).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvGioHang;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThanhTien;
    }
}