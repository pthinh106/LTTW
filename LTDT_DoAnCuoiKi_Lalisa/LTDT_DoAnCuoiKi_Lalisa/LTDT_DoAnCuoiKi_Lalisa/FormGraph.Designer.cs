
namespace LTDT_DoAnCuoiKi_Lalisa
{
    partial class FormGraph
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDuyet = new FontAwesome.Sharp.IconButton();
            this.btnLamMoi = new FontAwesome.Sharp.IconButton();
            this.panelClickSukien = new System.Windows.Forms.Panel();
            this.txtTrongSo = new System.Windows.Forms.TextBox();
            this.labTrongSo = new System.Windows.Forms.Label();
            this.btnXacNhan = new FontAwesome.Sharp.IconButton();
            this.btnXoaDinh = new FontAwesome.Sharp.IconButton();
            this.btnXoaCanh = new FontAwesome.Sharp.IconButton();
            this.btnThemCanh = new FontAwesome.Sharp.IconButton();
            this.btnThemDinh = new FontAwesome.Sharp.IconButton();
            this.pnlCachDuyet = new System.Windows.Forms.Panel();
            this.cbxCachDuyet = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlFS = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDinhBatDau = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDinhKetThuc = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxChucNang = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxLoaiDoThi = new System.Windows.Forms.ComboBox();
            this.pnlVeDoThi = new System.Windows.Forms.Panel();
            this.txtKetqua = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.txtMatran = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelClickSukien.SuspendLayout();
            this.pnlCachDuyet.SuspendLayout();
            this.pnlFS.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panelClickSukien);
            this.panel1.Controls.Add(this.pnlCachDuyet);
            this.panel1.Controls.Add(this.pnlFS);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(757, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(325, 588);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDuyet);
            this.panel2.Controls.Add(this.btnLamMoi);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 426);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(325, 120);
            this.panel2.TabIndex = 15;
            // 
            // btnDuyet
            // 
            this.btnDuyet.BackColor = System.Drawing.Color.Teal;
            this.btnDuyet.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.btnDuyet.IconColor = System.Drawing.Color.GreenYellow;
            this.btnDuyet.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDuyet.IconSize = 25;
            this.btnDuyet.Location = new System.Drawing.Point(45, 61);
            this.btnDuyet.Name = "btnDuyet";
            this.btnDuyet.Padding = new System.Windows.Forms.Padding(46, 0, 23, 0);
            this.btnDuyet.Size = new System.Drawing.Size(241, 49);
            this.btnDuyet.TabIndex = 0;
            this.btnDuyet.Text = "Duyệt";
            this.btnDuyet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDuyet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDuyet.UseVisualStyleBackColor = false;
            this.btnDuyet.Click += new System.EventHandler(this.btnDuyet_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.Teal;
            this.btnLamMoi.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.btnLamMoi.IconColor = System.Drawing.Color.Aquamarine;
            this.btnLamMoi.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLamMoi.IconSize = 25;
            this.btnLamMoi.Location = new System.Drawing.Point(45, 6);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Padding = new System.Windows.Forms.Padding(23, 0, 23, 0);
            this.btnLamMoi.Size = new System.Drawing.Size(241, 49);
            this.btnLamMoi.TabIndex = 1;
            this.btnLamMoi.Text = "Xóa Và Tạo Mới";
            this.btnLamMoi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLamMoi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // panelClickSukien
            // 
            this.panelClickSukien.Controls.Add(this.txtTrongSo);
            this.panelClickSukien.Controls.Add(this.labTrongSo);
            this.panelClickSukien.Controls.Add(this.btnXacNhan);
            this.panelClickSukien.Controls.Add(this.btnXoaDinh);
            this.panelClickSukien.Controls.Add(this.btnXoaCanh);
            this.panelClickSukien.Controls.Add(this.btnThemCanh);
            this.panelClickSukien.Controls.Add(this.btnThemDinh);
            this.panelClickSukien.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelClickSukien.Location = new System.Drawing.Point(0, 207);
            this.panelClickSukien.Name = "panelClickSukien";
            this.panelClickSukien.Size = new System.Drawing.Size(325, 219);
            this.panelClickSukien.TabIndex = 13;
            // 
            // txtTrongSo
            // 
            this.txtTrongSo.Location = new System.Drawing.Point(85, 35);
            this.txtTrongSo.Name = "txtTrongSo";
            this.txtTrongSo.Size = new System.Drawing.Size(149, 25);
            this.txtTrongSo.TabIndex = 14;
            // 
            // labTrongSo
            // 
            this.labTrongSo.AutoSize = true;
            this.labTrongSo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTrongSo.Location = new System.Drawing.Point(5, 8);
            this.labTrongSo.Name = "labTrongSo";
            this.labTrongSo.Size = new System.Drawing.Size(65, 19);
            this.labTrongSo.TabIndex = 15;
            this.labTrongSo.Text = "Trọng Số";
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhan.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnXacNhan.IconChar = FontAwesome.Sharp.IconChar.CheckCircle;
            this.btnXacNhan.IconColor = System.Drawing.Color.DarkSlateGray;
            this.btnXacNhan.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnXacNhan.IconSize = 28;
            this.btnXacNhan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXacNhan.Location = new System.Drawing.Point(86, 164);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Padding = new System.Windows.Forms.Padding(14, 0, 26, 2);
            this.btnXacNhan.Size = new System.Drawing.Size(148, 42);
            this.btnXacNhan.TabIndex = 4;
            this.btnXacNhan.Text = "Xác Nhận";
            this.btnXacNhan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXacNhan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // btnXoaDinh
            // 
            this.btnXoaDinh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaDinh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnXoaDinh.IconChar = FontAwesome.Sharp.IconChar.MinusCircle;
            this.btnXoaDinh.IconColor = System.Drawing.Color.DarkSlateGray;
            this.btnXoaDinh.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnXoaDinh.IconSize = 28;
            this.btnXoaDinh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaDinh.Location = new System.Drawing.Point(167, 67);
            this.btnXoaDinh.Name = "btnXoaDinh";
            this.btnXoaDinh.Padding = new System.Windows.Forms.Padding(9, 0, 9, 2);
            this.btnXoaDinh.Size = new System.Drawing.Size(147, 42);
            this.btnXoaDinh.TabIndex = 3;
            this.btnXoaDinh.Text = "Xóa Đỉnh";
            this.btnXoaDinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaDinh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoaDinh.UseVisualStyleBackColor = true;
            this.btnXoaDinh.Click += new System.EventHandler(this.btnXoaDinh_Click);
            // 
            // btnXoaCanh
            // 
            this.btnXoaCanh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaCanh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnXoaCanh.IconChar = FontAwesome.Sharp.IconChar.MinusCircle;
            this.btnXoaCanh.IconColor = System.Drawing.Color.DarkSlateGray;
            this.btnXoaCanh.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnXoaCanh.IconSize = 28;
            this.btnXoaCanh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaCanh.Location = new System.Drawing.Point(167, 116);
            this.btnXoaCanh.Name = "btnXoaCanh";
            this.btnXoaCanh.Padding = new System.Windows.Forms.Padding(9, 0, 9, 2);
            this.btnXoaCanh.Size = new System.Drawing.Size(149, 42);
            this.btnXoaCanh.TabIndex = 2;
            this.btnXoaCanh.Text = "Xóa Cạnh";
            this.btnXoaCanh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaCanh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoaCanh.UseVisualStyleBackColor = true;
            this.btnXoaCanh.Click += new System.EventHandler(this.btnXoaCanh_Click);
            // 
            // btnThemCanh
            // 
            this.btnThemCanh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemCanh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnThemCanh.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.btnThemCanh.IconColor = System.Drawing.Color.DarkSlateGray;
            this.btnThemCanh.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnThemCanh.IconSize = 28;
            this.btnThemCanh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemCanh.Location = new System.Drawing.Point(8, 116);
            this.btnThemCanh.Name = "btnThemCanh";
            this.btnThemCanh.Padding = new System.Windows.Forms.Padding(9, 0, 9, 2);
            this.btnThemCanh.Size = new System.Drawing.Size(149, 42);
            this.btnThemCanh.TabIndex = 1;
            this.btnThemCanh.Text = "Thêm Cạnh";
            this.btnThemCanh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemCanh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThemCanh.UseVisualStyleBackColor = true;
            this.btnThemCanh.Click += new System.EventHandler(this.btnThemCanh_Click);
            // 
            // btnThemDinh
            // 
            this.btnThemDinh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemDinh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnThemDinh.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.btnThemDinh.IconColor = System.Drawing.Color.DarkSlateGray;
            this.btnThemDinh.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnThemDinh.IconSize = 28;
            this.btnThemDinh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemDinh.Location = new System.Drawing.Point(8, 67);
            this.btnThemDinh.Name = "btnThemDinh";
            this.btnThemDinh.Padding = new System.Windows.Forms.Padding(9, 0, 9, 2);
            this.btnThemDinh.Size = new System.Drawing.Size(149, 42);
            this.btnThemDinh.TabIndex = 0;
            this.btnThemDinh.Text = "Thêm Đỉnh";
            this.btnThemDinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemDinh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThemDinh.UseVisualStyleBackColor = true;
            this.btnThemDinh.Click += new System.EventHandler(this.btnThemDinh_Click);
            // 
            // pnlCachDuyet
            // 
            this.pnlCachDuyet.Controls.Add(this.cbxCachDuyet);
            this.pnlCachDuyet.Controls.Add(this.label6);
            this.pnlCachDuyet.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCachDuyet.Location = new System.Drawing.Point(0, 163);
            this.pnlCachDuyet.Name = "pnlCachDuyet";
            this.pnlCachDuyet.Size = new System.Drawing.Size(325, 44);
            this.pnlCachDuyet.TabIndex = 14;
            this.pnlCachDuyet.Visible = false;
            // 
            // cbxCachDuyet
            // 
            this.cbxCachDuyet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCachDuyet.FormattingEnabled = true;
            this.cbxCachDuyet.Items.AddRange(new object[] {
            "Duyệt Từng Bước",
            "Duyệt Toàn Bộ"});
            this.cbxCachDuyet.Location = new System.Drawing.Point(112, 7);
            this.cbxCachDuyet.Name = "cbxCachDuyet";
            this.cbxCachDuyet.Size = new System.Drawing.Size(164, 25);
            this.cbxCachDuyet.TabIndex = 14;
            this.cbxCachDuyet.TextChanged += new System.EventHandler(this.cbxCachDuyet_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Cách Duyệt";
            // 
            // pnlFS
            // 
            this.pnlFS.Controls.Add(this.label2);
            this.pnlFS.Controls.Add(this.txtDinhBatDau);
            this.pnlFS.Controls.Add(this.label3);
            this.pnlFS.Controls.Add(this.txtDinhKetThuc);
            this.pnlFS.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFS.Location = new System.Drawing.Point(0, 85);
            this.pnlFS.Name = "pnlFS";
            this.pnlFS.Size = new System.Drawing.Size(325, 78);
            this.pnlFS.TabIndex = 13;
            this.pnlFS.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Đỉnh Bắt Đầu";
            // 
            // txtDinhBatDau
            // 
            this.txtDinhBatDau.Location = new System.Drawing.Point(112, 6);
            this.txtDinhBatDau.Name = "txtDinhBatDau";
            this.txtDinhBatDau.Size = new System.Drawing.Size(164, 25);
            this.txtDinhBatDau.TabIndex = 10;
            this.txtDinhBatDau.TextChanged += new System.EventHandler(this.txtDinhBatDau_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Đỉnh Kết Thúc";
            // 
            // txtDinhKetThuc
            // 
            this.txtDinhKetThuc.Location = new System.Drawing.Point(112, 42);
            this.txtDinhKetThuc.Name = "txtDinhKetThuc";
            this.txtDinhKetThuc.Size = new System.Drawing.Size(164, 25);
            this.txtDinhKetThuc.TabIndex = 11;
            this.txtDinhKetThuc.TextChanged += new System.EventHandler(this.txtDinhKetThuc_TextChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.cbxChucNang);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.cbxLoaiDoThi);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(325, 85);
            this.panel3.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Chức Năng";
            // 
            // cbxChucNang
            // 
            this.cbxChucNang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxChucNang.FormattingEnabled = true;
            this.cbxChucNang.Items.AddRange(new object[] {
            "Disjktra",
            "Kruskal",
            "Prim",
            "Duyệt BFS",
            "Duyệt DFS",
            "Xét Liên Thông"});
            this.cbxChucNang.Location = new System.Drawing.Point(112, 52);
            this.cbxChucNang.Name = "cbxChucNang";
            this.cbxChucNang.Size = new System.Drawing.Size(164, 25);
            this.cbxChucNang.TabIndex = 12;
            this.cbxChucNang.SelectedValueChanged += new System.EventHandler(this.comboBox2_SelectedValueChanged);
            this.cbxChucNang.TextChanged += new System.EventHandler(this.cbxCachDuyet_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Loại Đồ Thị";
            // 
            // cbxLoaiDoThi
            // 
            this.cbxLoaiDoThi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLoaiDoThi.FormattingEnabled = true;
            this.cbxLoaiDoThi.Items.AddRange(new object[] {
            "Đồ Thị Vô Hướng",
            "Đồ Thị Có Hướng"});
            this.cbxLoaiDoThi.Location = new System.Drawing.Point(112, 15);
            this.cbxLoaiDoThi.Name = "cbxLoaiDoThi";
            this.cbxLoaiDoThi.Size = new System.Drawing.Size(164, 25);
            this.cbxLoaiDoThi.TabIndex = 8;
            this.cbxLoaiDoThi.TextChanged += new System.EventHandler(this.cbxLoaiDoThi_TextChanged);
            // 
            // pnlVeDoThi
            // 
            this.pnlVeDoThi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlVeDoThi.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pnlVeDoThi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlVeDoThi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlVeDoThi.Location = new System.Drawing.Point(14, 14);
            this.pnlVeDoThi.Name = "pnlVeDoThi";
            this.pnlVeDoThi.Size = new System.Drawing.Size(728, 368);
            this.pnlVeDoThi.TabIndex = 1;
            this.pnlVeDoThi.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlVeDoThi_MouseClick);
            // 
            // txtKetqua
            // 
            this.txtKetqua.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKetqua.BackColor = System.Drawing.SystemColors.Control;
            this.txtKetqua.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKetqua.Location = new System.Drawing.Point(13, 23);
            this.txtKetqua.Multiline = true;
            this.txtKetqua.Name = "txtKetqua";
            this.txtKetqua.ReadOnly = true;
            this.txtKetqua.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtKetqua.Size = new System.Drawing.Size(457, 154);
            this.txtKetqua.TabIndex = 2;
            this.txtKetqua.Text = "Kết Quả Duyệt";
            // 
            // txtMatran
            // 
            this.txtMatran.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMatran.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatran.Location = new System.Drawing.Point(489, 23);
            this.txtMatran.Multiline = true;
            this.txtMatran.Name = "txtMatran";
            this.txtMatran.ReadOnly = true;
            this.txtMatran.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMatran.Size = new System.Drawing.Size(238, 154);
            this.txtMatran.TabIndex = 3;
            this.txtMatran.Text = "Ma Trận Tạo Thành";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtMatran);
            this.groupBox1.Controls.Add(this.txtKetqua);
            this.groupBox1.Location = new System.Drawing.Point(14, 389);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(735, 186);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Báo";
            // 
            // FormGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1082, 588);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnlVeDoThi);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormGraph";
            this.Text = "FormGraph";
            this.Load += new System.EventHandler(this.FormGraph_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelClickSukien.ResumeLayout(false);
            this.panelClickSukien.PerformLayout();
            this.pnlCachDuyet.ResumeLayout(false);
            this.pnlCachDuyet.PerformLayout();
            this.pnlFS.ResumeLayout(false);
            this.pnlFS.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlVeDoThi;
        private System.Windows.Forms.TextBox txtKetqua;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDinhKetThuc;
        private System.Windows.Forms.TextBox txtDinhBatDau;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxLoaiDoThi;
        private System.Windows.Forms.Panel panelClickSukien;
        private FontAwesome.Sharp.IconButton btnThemDinh;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxCachDuyet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxChucNang;
        private FontAwesome.Sharp.IconButton btnXoaDinh;
        private FontAwesome.Sharp.IconButton btnXoaCanh;
        private FontAwesome.Sharp.IconButton btnThemCanh;
        private FontAwesome.Sharp.IconButton btnDuyet;
        private System.Windows.Forms.Panel pnlFS;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private FontAwesome.Sharp.IconButton btnXacNhan;
        private FontAwesome.Sharp.IconButton btnLamMoi;
        private System.Windows.Forms.TextBox txtMatran;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labTrongSo;
        private System.Windows.Forms.TextBox txtTrongSo;
        private System.Windows.Forms.Panel pnlCachDuyet;
        private System.Windows.Forms.Panel panel2;
    }
}