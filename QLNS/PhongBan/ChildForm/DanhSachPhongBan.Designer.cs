namespace QLNS.PhongBan.ChildForm
{
    partial class DanhSachPhongBan
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
            this.tv_PhongBan = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label_TenPB = new System.Windows.Forms.Label();
            this.txt_TenPB = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNgayVaoLam = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCCCD = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.cBCCNN = new System.Windows.Forms.ComboBox();
            this.cBHocVan = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.mTBNgaySinh = new System.Windows.Forms.MaskedTextBox();
            this.cBGioiTinh = new System.Windows.Forms.ComboBox();
            this.cBLoaiNV = new System.Windows.Forms.ComboBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_ChonPB = new System.Windows.Forms.Label();
            this.cb_PhongBan = new System.Windows.Forms.ComboBox();
            this.btnNo2 = new System.Windows.Forms.Button();
            this.btnOk2 = new System.Windows.Forms.Button();
            this.btn_XoaPB = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btn_ThemPB = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tv_PhongBan
            // 
            this.tv_PhongBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tv_PhongBan.Dock = System.Windows.Forms.DockStyle.Left;
            this.tv_PhongBan.Location = new System.Drawing.Point(0, 0);
            this.tv_PhongBan.Name = "tv_PhongBan";
            this.tv_PhongBan.Size = new System.Drawing.Size(557, 811);
            this.tv_PhongBan.TabIndex = 3;
            this.tv_PhongBan.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_PhongBan_AfterSelect);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(557, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1108, 811);
            this.panel2.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox2.Controls.Add(this.btnNo2);
            this.groupBox2.Controls.Add(this.btnOk2);
            this.groupBox2.Controls.Add(this.cb_PhongBan);
            this.groupBox2.Controls.Add(this.label_ChonPB);
            this.groupBox2.Controls.Add(this.btn_XoaPB);
            this.groupBox2.Controls.Add(this.btnNo);
            this.groupBox2.Controls.Add(this.btnOk);
            this.groupBox2.Controls.Add(this.btn_ThemPB);
            this.groupBox2.Controls.Add(this.label_TenPB);
            this.groupBox2.Controls.Add(this.txt_TenPB);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Blue;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1108, 281);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thao tác phòng ban";
            // 
            // label_TenPB
            // 
            this.label_TenPB.AutoSize = true;
            this.label_TenPB.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TenPB.ForeColor = System.Drawing.Color.Blue;
            this.label_TenPB.Location = new System.Drawing.Point(45, 82);
            this.label_TenPB.Name = "label_TenPB";
            this.label_TenPB.Size = new System.Drawing.Size(210, 26);
            this.label_TenPB.TabIndex = 38;
            this.label_TenPB.Text = "Nhập tên phòng ban:";
            // 
            // txt_TenPB
            // 
            this.txt_TenPB.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TenPB.Location = new System.Drawing.Point(49, 111);
            this.txt_TenPB.Name = "txt_TenPB";
            this.txt_TenPB.Size = new System.Drawing.Size(201, 30);
            this.txt_TenPB.TabIndex = 38;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.txtNgayVaoLam);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtCCCD);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.txtSDT);
            this.groupBox1.Controls.Add(this.cBCCNN);
            this.groupBox1.Controls.Add(this.cBHocVan);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.mTBNgaySinh);
            this.groupBox1.Controls.Add(this.cBGioiTinh);
            this.groupBox1.Controls.Add(this.cBLoaiNV);
            this.groupBox1.Controls.Add(this.txtDiaChi);
            this.groupBox1.Controls.Add(this.txtHoTen);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtMaNV);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(0, 281);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1108, 530);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin nhân viên";
            // 
            // txtNgayVaoLam
            // 
            this.txtNgayVaoLam.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgayVaoLam.Location = new System.Drawing.Point(313, 458);
            this.txtNgayVaoLam.Name = "txtNgayVaoLam";
            this.txtNgayVaoLam.Size = new System.Drawing.Size(201, 30);
            this.txtNgayVaoLam.TabIndex = 37;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(67, 463);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(109, 20);
            this.label14.TabIndex = 36;
            this.label14.Text = "Ngày vào làm:";
            // 
            // txtCCCD
            // 
            this.txtCCCD.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCCCD.Location = new System.Drawing.Point(313, 166);
            this.txtCCCD.Name = "txtCCCD";
            this.txtCCCD.Size = new System.Drawing.Size(201, 30);
            this.txtCCCD.TabIndex = 35;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(67, 171);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 20);
            this.label13.TabIndex = 34;
            this.label13.Text = "CCCD:";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(313, 238);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(201, 30);
            this.txtEmail.TabIndex = 33;
            // 
            // txtSDT
            // 
            this.txtSDT.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDT.Location = new System.Drawing.Point(313, 202);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(201, 30);
            this.txtSDT.TabIndex = 32;
            // 
            // cBCCNN
            // 
            this.cBCCNN.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBCCNN.FormattingEnabled = true;
            this.cBCCNN.Location = new System.Drawing.Point(313, 384);
            this.cBCCNN.Name = "cBCCNN";
            this.cBCCNN.Size = new System.Drawing.Size(201, 31);
            this.cBCCNN.TabIndex = 31;
            // 
            // cBHocVan
            // 
            this.cBHocVan.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBHocVan.FormattingEnabled = true;
            this.cBHocVan.Location = new System.Drawing.Point(313, 347);
            this.cBHocVan.Name = "cBHocVan";
            this.cBHocVan.Size = new System.Drawing.Size(201, 31);
            this.cBHocVan.TabIndex = 30;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(67, 389);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(159, 20);
            this.label11.TabIndex = 29;
            this.label11.Text = "Chứng chỉ ngoại ngữ:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(67, 352);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 20);
            this.label7.TabIndex = 28;
            this.label7.Text = "Trình độ học vấn:";
            // 
            // mTBNgaySinh
            // 
            this.mTBNgaySinh.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mTBNgaySinh.Location = new System.Drawing.Point(313, 130);
            this.mTBNgaySinh.Mask = "00/00/0000";
            this.mTBNgaySinh.Name = "mTBNgaySinh";
            this.mTBNgaySinh.Size = new System.Drawing.Size(201, 30);
            this.mTBNgaySinh.TabIndex = 27;
            this.mTBNgaySinh.ValidatingType = typeof(System.DateTime);
            // 
            // cBGioiTinh
            // 
            this.cBGioiTinh.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBGioiTinh.FormattingEnabled = true;
            this.cBGioiTinh.Location = new System.Drawing.Point(313, 274);
            this.cBGioiTinh.Name = "cBGioiTinh";
            this.cBGioiTinh.Size = new System.Drawing.Size(201, 31);
            this.cBGioiTinh.TabIndex = 24;
            // 
            // cBLoaiNV
            // 
            this.cBLoaiNV.DisplayMember = "TenCV";
            this.cBLoaiNV.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBLoaiNV.FormattingEnabled = true;
            this.cBLoaiNV.Location = new System.Drawing.Point(313, 421);
            this.cBLoaiNV.Name = "cBLoaiNV";
            this.cBLoaiNV.Size = new System.Drawing.Size(201, 31);
            this.cBLoaiNV.TabIndex = 23;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiaChi.Location = new System.Drawing.Point(313, 311);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(201, 30);
            this.txtDiaChi.TabIndex = 18;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTen.Location = new System.Drawing.Point(313, 94);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(201, 30);
            this.txtHoTen.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(67, 243);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 20);
            this.label10.TabIndex = 14;
            this.label10.Text = "Email:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(67, 207);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 20);
            this.label9.TabIndex = 13;
            this.label9.Text = "Số điện thoại:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(67, 426);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 20);
            this.label8.TabIndex = 12;
            this.label8.Text = "Loại nhân viên:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(67, 316);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Địa chỉ:";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNV.Location = new System.Drawing.Point(313, 58);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(201, 30);
            this.txtMaNV.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(67, 279);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Giới tính:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(67, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ngày sinh:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(67, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Họ tên:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(67, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã nhân viên:";
            // 
            // label_ChonPB
            // 
            this.label_ChonPB.AutoSize = true;
            this.label_ChonPB.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ChonPB.ForeColor = System.Drawing.Color.Blue;
            this.label_ChonPB.Location = new System.Drawing.Point(228, 82);
            this.label_ChonPB.Name = "label_ChonPB";
            this.label_ChonPB.Size = new System.Drawing.Size(171, 26);
            this.label_ChonPB.TabIndex = 60;
            this.label_ChonPB.Text = "Chọn phòng ban:";
            // 
            // cb_PhongBan
            // 
            this.cb_PhongBan.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_PhongBan.FormattingEnabled = true;
            this.cb_PhongBan.Location = new System.Drawing.Point(233, 109);
            this.cb_PhongBan.Name = "cb_PhongBan";
            this.cb_PhongBan.Size = new System.Drawing.Size(201, 33);
            this.cb_PhongBan.TabIndex = 61;
            // 
            // btnNo2
            // 
            this.btnNo2.ForeColor = System.Drawing.Color.Red;
            this.btnNo2.Image = global::QLNS.Properties.Resources.multiply;
            this.btnNo2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNo2.Location = new System.Drawing.Point(325, 148);
            this.btnNo2.Name = "btnNo2";
            this.btnNo2.Size = new System.Drawing.Size(86, 34);
            this.btnNo2.TabIndex = 63;
            this.btnNo2.Text = "No";
            this.btnNo2.UseVisualStyleBackColor = true;
            this.btnNo2.Click += new System.EventHandler(this.btnNo2_Click);
            // 
            // btnOk2
            // 
            this.btnOk2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnOk2.Image = global::QLNS.Properties.Resources.check__1_;
            this.btnOk2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk2.Location = new System.Drawing.Point(233, 147);
            this.btnOk2.Name = "btnOk2";
            this.btnOk2.Size = new System.Drawing.Size(86, 34);
            this.btnOk2.TabIndex = 62;
            this.btnOk2.Text = "Ok";
            this.btnOk2.UseVisualStyleBackColor = true;
            this.btnOk2.Click += new System.EventHandler(this.btnOk2_Click);
            // 
            // btn_XoaPB
            // 
            this.btn_XoaPB.BackColor = System.Drawing.Color.White;
            this.btn_XoaPB.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_XoaPB.ForeColor = System.Drawing.Color.Red;
            this.btn_XoaPB.Image = global::QLNS.Properties.Resources.business;
            this.btn_XoaPB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_XoaPB.Location = new System.Drawing.Point(228, 33);
            this.btn_XoaPB.Name = "btn_XoaPB";
            this.btn_XoaPB.Size = new System.Drawing.Size(167, 41);
            this.btn_XoaPB.TabIndex = 59;
            this.btn_XoaPB.Text = "   Xóa phòng ban";
            this.btn_XoaPB.UseVisualStyleBackColor = false;
            this.btn_XoaPB.Click += new System.EventHandler(this.btn_XoaPB_Click);
            // 
            // btnNo
            // 
            this.btnNo.ForeColor = System.Drawing.Color.Red;
            this.btnNo.Image = global::QLNS.Properties.Resources.multiply;
            this.btnNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNo.Location = new System.Drawing.Point(141, 144);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(86, 34);
            this.btnNo.TabIndex = 58;
            this.btnNo.Text = "No";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnOk
            // 
            this.btnOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnOk.Image = global::QLNS.Properties.Resources.check__1_;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(49, 144);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(86, 34);
            this.btnOk.TabIndex = 57;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btn_ThemPB
            // 
            this.btn_ThemPB.BackColor = System.Drawing.Color.White;
            this.btn_ThemPB.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ThemPB.ForeColor = System.Drawing.Color.Green;
            this.btn_ThemPB.Image = global::QLNS.Properties.Resources.deparment;
            this.btn_ThemPB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ThemPB.Location = new System.Drawing.Point(38, 33);
            this.btn_ThemPB.Name = "btn_ThemPB";
            this.btn_ThemPB.Size = new System.Drawing.Size(167, 41);
            this.btn_ThemPB.TabIndex = 40;
            this.btn_ThemPB.Text = "Thêm phòng ban";
            this.btn_ThemPB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_ThemPB.UseVisualStyleBackColor = false;
            this.btn_ThemPB.Click += new System.EventHandler(this.btn_ThemPB_Click);
            // 
            // DanhSachPhongBan
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1665, 811);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tv_PhongBan);
            this.Name = "DanhSachPhongBan";
            this.Text = "Dach sách phòng ban";
            this.Load += new System.EventHandler(this.DanhSachPhongBan_Load);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TreeView tv_PhongBan;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNgayVaoLam;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtCCCD;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.ComboBox cBCCNN;
        private System.Windows.Forms.ComboBox cBHocVan;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox mTBNgaySinh;
        private System.Windows.Forms.ComboBox cBGioiTinh;
        private System.Windows.Forms.ComboBox cBLoaiNV;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label_TenPB;
        private System.Windows.Forms.TextBox txt_TenPB;
        private System.Windows.Forms.Button btn_ThemPB;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Button btnNo2;
        private System.Windows.Forms.Button btnOk2;
        private System.Windows.Forms.ComboBox cb_PhongBan;
        private System.Windows.Forms.Label label_ChonPB;
        private System.Windows.Forms.Button btn_XoaPB;
    }
}
