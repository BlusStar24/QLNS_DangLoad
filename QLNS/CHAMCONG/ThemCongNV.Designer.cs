namespace QLNS.ChamCongg
{
    partial class ThemCongNV
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_luu = new System.Windows.Forms.Button();
            this.masktxt_gtl = new System.Windows.Forms.MaskedTextBox();
            this.masktxt_gvl = new System.Windows.Forms.MaskedTextBox();
            this.dtP_ncc = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbx_manv = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(167, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(479, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "THÊM CÔNG CHO NHÂN VIÊN";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbx_manv);
            this.groupBox1.Controls.Add(this.btn_luu);
            this.groupBox1.Controls.Add(this.masktxt_gtl);
            this.groupBox1.Controls.Add(this.masktxt_gvl);
            this.groupBox1.Controls.Add(this.dtP_ncc);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(75, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(653, 328);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thêm Công";
            // 
            // btn_luu
            // 
            this.btn_luu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_luu.Location = new System.Drawing.Point(168, 255);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Size = new System.Drawing.Size(266, 45);
            this.btn_luu.TabIndex = 8;
            this.btn_luu.Text = "Lưu";
            this.btn_luu.UseVisualStyleBackColor = true;
            this.btn_luu.Click += new System.EventHandler(this.btn_luu_Click);
            // 
            // masktxt_gtl
            // 
            this.masktxt_gtl.Location = new System.Drawing.Point(203, 208);
            this.masktxt_gtl.Mask = "00:00";
            this.masktxt_gtl.Name = "masktxt_gtl";
            this.masktxt_gtl.Size = new System.Drawing.Size(200, 26);
            this.masktxt_gtl.TabIndex = 7;
            this.masktxt_gtl.ValidatingType = typeof(System.DateTime);
            // 
            // masktxt_gvl
            // 
            this.masktxt_gvl.Location = new System.Drawing.Point(203, 157);
            this.masktxt_gvl.Mask = "00:00";
            this.masktxt_gvl.Name = "masktxt_gvl";
            this.masktxt_gvl.Size = new System.Drawing.Size(200, 26);
            this.masktxt_gvl.TabIndex = 6;
            this.masktxt_gvl.ValidatingType = typeof(System.DateTime);
            // 
            // dtP_ncc
            // 
            this.dtP_ncc.Location = new System.Drawing.Point(203, 99);
            this.dtP_ncc.Name = "dtP_ncc";
            this.dtP_ncc.Size = new System.Drawing.Size(200, 26);
            this.dtP_ncc.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Giờ Tan Làm:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Giờ Vào Làm:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Ngày Chấm Công:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã Nhân Viên:";
            // 
            // cbx_manv
            // 
            this.cbx_manv.FormattingEnabled = true;
            this.cbx_manv.Location = new System.Drawing.Point(203, 41);
            this.cbx_manv.Name = "cbx_manv";
            this.cbx_manv.Size = new System.Drawing.Size(200, 28);
            this.cbx_manv.TabIndex = 9;
            // 
            // ThemCongNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "ThemCongNV";
            this.Text = "ThemCongNV";
            this.Load += new System.EventHandler(this.ThemCongNV_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox masktxt_gvl;
        private System.Windows.Forms.DateTimePicker dtP_ncc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox masktxt_gtl;
        private System.Windows.Forms.Button btn_luu;
        private System.Windows.Forms.ComboBox cbx_manv;
    }
}