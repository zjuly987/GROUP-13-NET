namespace NHÓM_13_LẬP_TRÌNH.NET
{
    partial class frmBaoCaoHangTon
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
            this.btnLammoi = new System.Windows.Forms.Button();
            this.btnInBC = new System.Windows.Forms.Button();
            this.btnHienthiBC = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.mskTo = new System.Windows.Forms.MaskedTextBox();
            this.mskFrom = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTenquanao = new System.Windows.Forms.TextBox();
            this.cboMaquanao = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLammoi
            // 
            this.btnLammoi.Location = new System.Drawing.Point(341, 411);
            this.btnLammoi.Name = "btnLammoi";
            this.btnLammoi.Size = new System.Drawing.Size(126, 23);
            this.btnLammoi.TabIndex = 27;
            this.btnLammoi.Text = "Làm mới báo cáo";
            this.btnLammoi.UseVisualStyleBackColor = true;
            // 
            // btnInBC
            // 
            this.btnInBC.Location = new System.Drawing.Point(544, 411);
            this.btnInBC.Name = "btnInBC";
            this.btnInBC.Size = new System.Drawing.Size(101, 23);
            this.btnInBC.TabIndex = 26;
            this.btnInBC.Text = "In báo cáo";
            this.btnInBC.UseVisualStyleBackColor = true;
            // 
            // btnHienthiBC
            // 
            this.btnHienthiBC.Location = new System.Drawing.Point(139, 411);
            this.btnHienthiBC.Name = "btnHienthiBC";
            this.btnHienthiBC.Size = new System.Drawing.Size(124, 23);
            this.btnHienthiBC.TabIndex = 25;
            this.btnHienthiBC.Text = "HIển thị báo cáo";
            this.btnHienthiBC.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(72, 140);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(657, 251);
            this.dataGridView1.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(396, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 16);
            this.label5.TabIndex = 23;
            this.label5.Text = "Đến";
            // 
            // mskTo
            // 
            this.mskTo.Location = new System.Drawing.Point(462, 98);
            this.mskTo.Mask = "00/00/0000";
            this.mskTo.Name = "mskTo";
            this.mskTo.Size = new System.Drawing.Size(183, 22);
            this.mskTo.TabIndex = 22;
            this.mskTo.ValidatingType = typeof(System.DateTime);
            // 
            // mskFrom
            // 
            this.mskFrom.Location = new System.Drawing.Point(182, 98);
            this.mskFrom.Mask = "00/00/0000";
            this.mskFrom.Name = "mskFrom";
            this.mskFrom.Size = new System.Drawing.Size(183, 22);
            this.mskFrom.TabIndex = 21;
            this.mskFrom.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(120, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "Từ";
            // 
            // txtTenquanao
            // 
            this.txtTenquanao.Location = new System.Drawing.Point(524, 62);
            this.txtTenquanao.Name = "txtTenquanao";
            this.txtTenquanao.Size = new System.Drawing.Size(121, 22);
            this.txtTenquanao.TabIndex = 19;
            // 
            // cboMaquanao
            // 
            this.cboMaquanao.FormattingEnabled = true;
            this.cboMaquanao.Location = new System.Drawing.Point(221, 62);
            this.cboMaquanao.Name = "cboMaquanao";
            this.cboMaquanao.Size = new System.Drawing.Size(121, 24);
            this.cboMaquanao.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(423, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "Tên quần áo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(120, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Mã quần áo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(229, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 36);
            this.label1.TabIndex = 15;
            this.label1.Text = "BÁO CÁO HÀNG TỒN";
            // 
            // frmBaoCaoHangTon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLammoi);
            this.Controls.Add(this.btnInBC);
            this.Controls.Add(this.btnHienthiBC);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.mskTo);
            this.Controls.Add(this.mskFrom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTenquanao);
            this.Controls.Add(this.cboMaquanao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmBaoCaoHangTon";
            this.Text = "Báo cáo hàng tồn";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLammoi;
        private System.Windows.Forms.Button btnInBC;
        private System.Windows.Forms.Button btnHienthiBC;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox mskTo;
        private System.Windows.Forms.MaskedTextBox mskFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTenquanao;
        private System.Windows.Forms.ComboBox cboMaquanao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}