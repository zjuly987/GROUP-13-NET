namespace NHÓM_13_LẬP_TRÌNH.NET
{
    partial class frmTimKiem
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
            this.lblThongtin = new System.Windows.Forms.Label();
            this.cboMaquanao = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblThongtin
            // 
            this.lblThongtin.AutoSize = true;
            this.lblThongtin.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongtin.Location = new System.Drawing.Point(239, 125);
            this.lblThongtin.Name = "lblThongtin";
            this.lblThongtin.Size = new System.Drawing.Size(174, 16);
            this.lblThongtin.TabIndex = 10;
            this.lblThongtin.Text = "(thông tin sẽ xuất hiện ở đây)";
            // 
            // cboMaquanao
            // 
            this.cboMaquanao.FormattingEnabled = true;
            this.cboMaquanao.Location = new System.Drawing.Point(242, 77);
            this.cboMaquanao.Name = "cboMaquanao";
            this.cboMaquanao.Size = new System.Drawing.Size(154, 24);
            this.cboMaquanao.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(83, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Thông tin sản phẩm:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tìm theo mã";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(236, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 36);
            this.label1.TabIndex = 6;
            this.label1.Text = "TÌM KIẾM QUẦN ÁO";
            // 
            // frmTimKiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblThongtin);
            this.Controls.Add(this.cboMaquanao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmTimKiem";
            this.Text = "Tìm kiếm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblThongtin;
        private System.Windows.Forms.ComboBox cboMaquanao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}