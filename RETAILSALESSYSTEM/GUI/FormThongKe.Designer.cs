namespace RETAILSALESSYSTEM.GUI
{
    partial class FormThongKe
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
            this.lblDoanhThu = new System.Windows.Forms.Label();
            this.lstTop5 = new System.Windows.Forms.ListBox();
            this.btnXemBaoCao = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDoanhThu
            // 
            this.lblDoanhThu.AutoSize = true;
            this.lblDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoanhThu.ForeColor = System.Drawing.Color.Red;
            this.lblDoanhThu.Location = new System.Drawing.Point(30, 30);
            this.lblDoanhThu.Name = "lblDoanhThu";
            this.lblDoanhThu.Size = new System.Drawing.Size(325, 29);
            this.lblDoanhThu.TabIndex = 0;
            this.lblDoanhThu.Text = "Doanh thu hôm nay: 0 VNĐ";
            // 
            // lstTop5
            // 
            this.lstTop5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTop5.FormattingEnabled = true;
            this.lstTop5.ItemHeight = 25;
            this.lstTop5.Location = new System.Drawing.Point(35, 120);
            this.lstTop5.Name = "lstTop5";
            this.lstTop5.Size = new System.Drawing.Size(500, 154);
            this.lstTop5.TabIndex = 1;
            // 
            // btnXemBaoCao
            // 
            this.btnXemBaoCao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemBaoCao.Location = new System.Drawing.Point(35, 300);
            this.btnXemBaoCao.Name = "btnXemBaoCao";
            this.btnXemBaoCao.Size = new System.Drawing.Size(500, 50);
            this.btnXemBaoCao.TabIndex = 2;
            this.btnXemBaoCao.Text = "XEM BÁO CÁO";
            this.btnXemBaoCao.UseVisualStyleBackColor = true;
            this.btnXemBaoCao.Click += new System.EventHandler(this.btnXemBaoCao_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Top 5 sản phẩm bán chạy nhất:";
            // 
            // FormThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 380);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnXemBaoCao);
            this.Controls.Add(this.lstTop5);
            this.Controls.Add(this.lblDoanhThu);
            this.Name = "FormThongKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Thống Kê";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDoanhThu;
        private System.Windows.Forms.ListBox lstTop5;
        private System.Windows.Forms.Button btnXemBaoCao;
        private System.Windows.Forms.Label label1;
    }
}