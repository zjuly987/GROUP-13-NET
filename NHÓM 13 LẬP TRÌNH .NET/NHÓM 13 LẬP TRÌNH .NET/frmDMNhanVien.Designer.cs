namespace NHÓM_13_LẬP_TRÌNH.NET
{
    partial class frmNhanVien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboMaCV = new System.Windows.Forms.ComboBox();
            this.lblCongviec = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnBoqua = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dataGridViewNV = new System.Windows.Forms.DataGridView();
            this.mskNgaysinh = new System.Windows.Forms.MaskedTextBox();
            this.mskDienthoai = new System.Windows.Forms.MaskedTextBox();
            this.txtDiachi = new System.Windows.Forms.TextBox();
            this.txtTennhanvien = new System.Windows.Forms.TextBox();
            this.txtManhanvien = new System.Windows.Forms.TextBox();
            this.chkGioitinh = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNgaysinh = new System.Windows.Forms.Label();
            this.lblDienthoai = new System.Windows.Forms.Label();
            this.lblGioitinh = new System.Windows.Forms.Label();
            this.lblDiachi = new System.Windows.Forms.Label();
            this.lblTennhanvien = new System.Windows.Forms.Label();
            this.lblManhanvien = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNV)).BeginInit();
            this.SuspendLayout();
            // 
            // cboMaCV
            // 
            this.cboMaCV.FormattingEnabled = true;
            this.cboMaCV.Location = new System.Drawing.Point(161, 176);
            this.cboMaCV.Name = "cboMaCV";
            this.cboMaCV.Size = new System.Drawing.Size(121, 24);
            this.cboMaCV.TabIndex = 43;
            // 
            // lblCongviec
            // 
            this.lblCongviec.AutoSize = true;
            this.lblCongviec.Location = new System.Drawing.Point(45, 179);
            this.lblCongviec.Name = "lblCongviec";
            this.lblCongviec.Size = new System.Drawing.Size(67, 16);
            this.lblCongviec.TabIndex = 42;
            this.lblCongviec.Text = "Công việc";
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(628, 415);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 23);
            this.btnDong.TabIndex = 41;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            // 
            // btnBoqua
            // 
            this.btnBoqua.Location = new System.Drawing.Point(526, 415);
            this.btnBoqua.Name = "btnBoqua";
            this.btnBoqua.Size = new System.Drawing.Size(75, 23);
            this.btnBoqua.TabIndex = 40;
            this.btnBoqua.Text = "Bỏ qua";
            this.btnBoqua.UseVisualStyleBackColor = true;
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(407, 415);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 39;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(294, 415);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 38;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(192, 415);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 37;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(87, 415);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 36;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            // 
            // dataGridViewNV
            // 
            this.dataGridViewNV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNV.Location = new System.Drawing.Point(31, 218);
            this.dataGridViewNV.Name = "dataGridViewNV";
            this.dataGridViewNV.RowHeadersWidth = 51;
            this.dataGridViewNV.RowTemplate.Height = 24;
            this.dataGridViewNV.Size = new System.Drawing.Size(732, 181);
            this.dataGridViewNV.TabIndex = 35;
            // 
            // mskNgaysinh
            // 
            this.mskNgaysinh.Location = new System.Drawing.Point(535, 103);
            this.mskNgaysinh.Mask = "00/00/0000";
            this.mskNgaysinh.Name = "mskNgaysinh";
            this.mskNgaysinh.Size = new System.Drawing.Size(198, 22);
            this.mskNgaysinh.TabIndex = 34;
            this.mskNgaysinh.ValidatingType = typeof(System.DateTime);
            // 
            // mskDienthoai
            // 
            this.mskDienthoai.Location = new System.Drawing.Point(535, 67);
            this.mskDienthoai.Mask = "(999) 000-0000";
            this.mskDienthoai.Name = "mskDienthoai";
            this.mskDienthoai.Size = new System.Drawing.Size(198, 22);
            this.mskDienthoai.TabIndex = 33;
            // 
            // txtDiachi
            // 
            this.txtDiachi.Location = new System.Drawing.Point(535, 145);
            this.txtDiachi.Name = "txtDiachi";
            this.txtDiachi.Size = new System.Drawing.Size(198, 22);
            this.txtDiachi.TabIndex = 32;
            // 
            // txtTennhanvien
            // 
            this.txtTennhanvien.Location = new System.Drawing.Point(164, 103);
            this.txtTennhanvien.Name = "txtTennhanvien";
            this.txtTennhanvien.Size = new System.Drawing.Size(210, 22);
            this.txtTennhanvien.TabIndex = 31;
            // 
            // txtManhanvien
            // 
            this.txtManhanvien.Location = new System.Drawing.Point(164, 64);
            this.txtManhanvien.Name = "txtManhanvien";
            this.txtManhanvien.Size = new System.Drawing.Size(210, 22);
            this.txtManhanvien.TabIndex = 30;
            // 
            // chkGioitinh
            // 
            this.chkGioitinh.AutoSize = true;
            this.chkGioitinh.Location = new System.Drawing.Point(164, 144);
            this.chkGioitinh.Name = "chkGioitinh";
            this.chkGioitinh.Size = new System.Drawing.Size(58, 20);
            this.chkGioitinh.TabIndex = 29;
            this.chkGioitinh.Text = "Nam";
            this.chkGioitinh.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(216, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(349, 36);
            this.label1.TabIndex = 28;
            this.label1.Text = "DANH MỤC NHÂN VIÊN";
            // 
            // lblNgaysinh
            // 
            this.lblNgaysinh.AutoSize = true;
            this.lblNgaysinh.Location = new System.Drawing.Point(438, 106);
            this.lblNgaysinh.Name = "lblNgaysinh";
            this.lblNgaysinh.Size = new System.Drawing.Size(67, 16);
            this.lblNgaysinh.TabIndex = 27;
            this.lblNgaysinh.Text = "Ngày sinh";
            // 
            // lblDienthoai
            // 
            this.lblDienthoai.AutoSize = true;
            this.lblDienthoai.Location = new System.Drawing.Point(438, 67);
            this.lblDienthoai.Name = "lblDienthoai";
            this.lblDienthoai.Size = new System.Drawing.Size(66, 16);
            this.lblDienthoai.TabIndex = 26;
            this.lblDienthoai.Text = "Điện thoại";
            // 
            // lblGioitinh
            // 
            this.lblGioitinh.AutoSize = true;
            this.lblGioitinh.Location = new System.Drawing.Point(48, 144);
            this.lblGioitinh.Name = "lblGioitinh";
            this.lblGioitinh.Size = new System.Drawing.Size(54, 16);
            this.lblGioitinh.TabIndex = 25;
            this.lblGioitinh.Text = "Giới tính";
            // 
            // lblDiachi
            // 
            this.lblDiachi.AutoSize = true;
            this.lblDiachi.Location = new System.Drawing.Point(438, 145);
            this.lblDiachi.Name = "lblDiachi";
            this.lblDiachi.Size = new System.Drawing.Size(47, 16);
            this.lblDiachi.TabIndex = 24;
            this.lblDiachi.Text = "Địa chỉ";
            // 
            // lblTennhanvien
            // 
            this.lblTennhanvien.AutoSize = true;
            this.lblTennhanvien.Location = new System.Drawing.Point(48, 109);
            this.lblTennhanvien.Name = "lblTennhanvien";
            this.lblTennhanvien.Size = new System.Drawing.Size(91, 16);
            this.lblTennhanvien.TabIndex = 23;
            this.lblTennhanvien.Text = "Tên nhân viên";
            // 
            // lblManhanvien
            // 
            this.lblManhanvien.AutoSize = true;
            this.lblManhanvien.Location = new System.Drawing.Point(48, 70);
            this.lblManhanvien.Name = "lblManhanvien";
            this.lblManhanvien.Size = new System.Drawing.Size(86, 16);
            this.lblManhanvien.TabIndex = 22;
            this.lblManhanvien.Text = "Mã nhân viên";
            // 
            // frmNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cboMaCV);
            this.Controls.Add(this.lblCongviec);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnBoqua);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dataGridViewNV);
            this.Controls.Add(this.mskNgaysinh);
            this.Controls.Add(this.mskDienthoai);
            this.Controls.Add(this.txtDiachi);
            this.Controls.Add(this.txtTennhanvien);
            this.Controls.Add(this.txtManhanvien);
            this.Controls.Add(this.chkGioitinh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNgaysinh);
            this.Controls.Add(this.lblDienthoai);
            this.Controls.Add(this.lblGioitinh);
            this.Controls.Add(this.lblDiachi);
            this.Controls.Add(this.lblTennhanvien);
            this.Controls.Add(this.lblManhanvien);
            this.Name = "frmNhanVien";
            this.Text = "Danh mục nhân viên";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboMaCV;
        private System.Windows.Forms.Label lblCongviec;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnBoqua;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dataGridViewNV;
        private System.Windows.Forms.MaskedTextBox mskNgaysinh;
        private System.Windows.Forms.MaskedTextBox mskDienthoai;
        private System.Windows.Forms.TextBox txtDiachi;
        private System.Windows.Forms.TextBox txtTennhanvien;
        private System.Windows.Forms.TextBox txtManhanvien;
        private System.Windows.Forms.CheckBox chkGioitinh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNgaysinh;
        private System.Windows.Forms.Label lblDienthoai;
        private System.Windows.Forms.Label lblGioitinh;
        private System.Windows.Forms.Label lblDiachi;
        private System.Windows.Forms.Label lblTennhanvien;
        private System.Windows.Forms.Label lblManhanvien;
    }
}