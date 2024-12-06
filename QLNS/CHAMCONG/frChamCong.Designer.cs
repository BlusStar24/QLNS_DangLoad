namespace QLNS.ChamCongg
{
    partial class frChamCong
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
            this.dgv_chamcong = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_xem = new System.Windows.Forms.Button();
            this.cbx_nam = new System.Windows.Forms.ComboBox();
            this.cbx_thang = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_chamcong)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_chamcong
            // 
            this.dgv_chamcong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_chamcong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_chamcong.Location = new System.Drawing.Point(0, 342);
            this.dgv_chamcong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgv_chamcong.Name = "dgv_chamcong";
            this.dgv_chamcong.RowHeadersWidth = 51;
            this.dgv_chamcong.RowTemplate.Height = 24;
            this.dgv_chamcong.Size = new System.Drawing.Size(2463, 1030);
            this.dgv_chamcong.TabIndex = 6;
            this.dgv_chamcong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_HDNV_CellClick);
            this.dgv_chamcong.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_chamcong_CellContentClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(489, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 23);
            this.label4.TabIndex = 32;
            this.label4.Text = "Chọn Năm:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2463, 342);
            this.panel1.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btn_xem);
            this.groupBox1.Controls.Add(this.cbx_nam);
            this.groupBox1.Controls.Add(this.cbx_thang);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(47, 198);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(1736, 136);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LỌC";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1113, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(338, 55);
            this.button1.TabIndex = 36;
            this.button1.Text = "Thêm Công Cho Nhân Viên";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_xem
            // 
            this.btn_xem.Location = new System.Drawing.Point(915, 52);
            this.btn_xem.Name = "btn_xem";
            this.btn_xem.Size = new System.Drawing.Size(147, 55);
            this.btn_xem.TabIndex = 35;
            this.btn_xem.Text = "Xem";
            this.btn_xem.UseVisualStyleBackColor = true;
            this.btn_xem.Click += new System.EventHandler(this.btn_xem_Click);
            // 
            // cbx_nam
            // 
            this.cbx_nam.FormattingEnabled = true;
            this.cbx_nam.Location = new System.Drawing.Point(620, 64);
            this.cbx_nam.Name = "cbx_nam";
            this.cbx_nam.Size = new System.Drawing.Size(238, 34);
            this.cbx_nam.TabIndex = 34;
            // 
            // cbx_thang
            // 
            this.cbx_thang.FormattingEnabled = true;
            this.cbx_thang.Location = new System.Drawing.Point(160, 64);
            this.cbx_thang.Name = "cbx_thang";
            this.cbx_thang.Size = new System.Drawing.Size(238, 34);
            this.cbx_thang.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 23);
            this.label8.TabIndex = 12;
            this.label8.Text = "Chọn Tháng:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(577, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(643, 49);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ BẢNG CÔNG NHÂN VIÊN";
            // 
            // frChamCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2463, 1372);
            this.Controls.Add(this.dgv_chamcong);
            this.Controls.Add(this.panel1);
            this.Name = "frChamCong";
            this.Text = "frChamCong";
            this.Load += new System.EventHandler(this.frChamCong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_chamcong)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_chamcong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_xem;
        private System.Windows.Forms.ComboBox cbx_nam;
        private System.Windows.Forms.ComboBox cbx_thang;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
    }
}