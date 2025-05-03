namespace NHÓM_13_LẬP_TRÌNH.NET
{
    partial class frmBaoCaoDoanhThu
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
            this.dataGridViewBCDT = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.mskTo = new System.Windows.Forms.MaskedTextBox();
            this.mskFrom = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBCDT)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLammoi
            // 
            this.btnLammoi.Location = new System.Drawing.Point(341, 403);
            this.btnLammoi.Name = "btnLammoi";
            this.btnLammoi.Size = new System.Drawing.Size(126, 23);
            this.btnLammoi.TabIndex = 36;
            this.btnLammoi.Text = "Làm mới báo cáo";
            this.btnLammoi.UseVisualStyleBackColor = true;
            // 
            // btnInBC
            // 
            this.btnInBC.Location = new System.Drawing.Point(544, 403);
            this.btnInBC.Name = "btnInBC";
            this.btnInBC.Size = new System.Drawing.Size(101, 23);
            this.btnInBC.TabIndex = 35;
            this.btnInBC.Text = "In báo cáo";
            this.btnInBC.UseVisualStyleBackColor = true;
            // 
            // btnHienthiBC
            // 
            this.btnHienthiBC.Location = new System.Drawing.Point(139, 403);
            this.btnHienthiBC.Name = "btnHienthiBC";
            this.btnHienthiBC.Size = new System.Drawing.Size(124, 23);
            this.btnHienthiBC.TabIndex = 34;
            this.btnHienthiBC.Text = "HIển thị báo cáo";
            this.btnHienthiBC.UseVisualStyleBackColor = true;
            // 
            // dataGridViewBCDT
            // 
            this.dataGridViewBCDT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBCDT.Location = new System.Drawing.Point(72, 132);
            this.dataGridViewBCDT.Name = "dataGridViewBCDT";
            this.dataGridViewBCDT.RowHeadersWidth = 51;
            this.dataGridViewBCDT.RowTemplate.Height = 24;
            this.dataGridViewBCDT.Size = new System.Drawing.Size(657, 251);
            this.dataGridViewBCDT.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(396, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 16);
            this.label5.TabIndex = 32;
            this.label5.Text = "Đến";
            // 
            // mskTo
            // 
            this.mskTo.Location = new System.Drawing.Point(462, 74);
            this.mskTo.Mask = "00/00/0000";
            this.mskTo.Name = "mskTo";
            this.mskTo.Size = new System.Drawing.Size(183, 22);
            this.mskTo.TabIndex = 31;
            this.mskTo.ValidatingType = typeof(System.DateTime);
            // 
            // mskFrom
            // 
            this.mskFrom.Location = new System.Drawing.Point(182, 74);
            this.mskFrom.Mask = "00/00/0000";
            this.mskFrom.Name = "mskFrom";
            this.mskFrom.Size = new System.Drawing.Size(183, 22);
            this.mskFrom.TabIndex = 30;
            this.mskFrom.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(120, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 16);
            this.label4.TabIndex = 29;
            this.label4.Text = "Từ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(208, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(334, 36);
            this.label1.TabIndex = 28;
            this.label1.Text = "BÁO CÁO DOANH THU";
            // 
            // frmBaoCaoDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLammoi);
            this.Controls.Add(this.btnInBC);
            this.Controls.Add(this.btnHienthiBC);
            this.Controls.Add(this.dataGridViewBCDT);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.mskTo);
            this.Controls.Add(this.mskFrom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "frmBaoCaoDoanhThu";
            this.Text = "Báo cáo doanh thu";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBCDT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLammoi;
        private System.Windows.Forms.Button btnInBC;
        private System.Windows.Forms.Button btnHienthiBC;
        private System.Windows.Forms.DataGridView dataGridViewBCDT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox mskTo;
        private System.Windows.Forms.MaskedTextBox mskFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
    }
}

