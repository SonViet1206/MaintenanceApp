namespace MaintenanceApp.Forms
{
    partial class FrmSetup
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSetup));
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            panel2 = new Panel();
            dgvMachineType = new DataGridView();
            panel1 = new Panel();
            btn_tab1_Delete = new Button();
            btn_tab1_Fix = new Button();
            label1 = new Label();
            txt_tab1_MachineType = new TextBox();
            btn_tab1_AddMachineType = new Button();
            dataGridView1 = new DataGridView();
            tabPage2 = new TabPage();
            dgvListPart = new DataGridView();
            panel3 = new Panel();
            btn_tab2_Del = new Button();
            btn_tab2_Fix = new Button();
            cbb_tab2_MachineType = new ComboBox();
            txt_tab2_DisplayOrder = new NumericUpDown();
            txt_tab2_MachinePart = new TextBox();
            label2 = new Label();
            label3 = new Label();
            btn_tab2_AddMachinePart = new Button();
            label4 = new Label();
            tabPage3 = new TabPage();
            dgv_tab3 = new DataGridView();
            pnTab3 = new Panel();
            btn_tab3_Delete = new Button();
            btn_tab3_FullDisplay = new Button();
            btn_tab3_Fix = new Button();
            label7 = new Label();
            txt_tab3_DisplayOrder = new NumericUpDown();
            label6 = new Label();
            btn_tab3_Detail = new Button();
            label5 = new Label();
            label11 = new Label();
            btn_tab3_AddIteamMaintenance = new Button();
            txt_tab3_IteamName = new TextBox();
            txt_tab3_Ng_solution = new TextBox();
            cbb_tab3_MachineType = new ComboBox();
            label10 = new Label();
            cbb_tab3_Part = new ComboBox();
            txt_tab3_method = new TextBox();
            label8 = new Label();
            label9 = new Label();
            txt_tab3_standard = new TextBox();
            tabPage4 = new TabPage();
            btn_tab4_AddMachine = new Button();
            cbb_tab4_MachineType = new ComboBox();
            txt_tab4_MachineID = new TextBox();
            label12 = new Label();
            label13 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMachineType).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListPart).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txt_tab2_DisplayOrder).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_tab3).BeginInit();
            pnTab3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txt_tab3_DisplayOrder).BeginInit();
            tabPage4.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1898, 1024);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(panel2);
            tabPage1.Controls.Add(panel1);
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Location = new Point(4, 39);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1890, 981);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Kiểu máy";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvMachineType);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 191);
            panel2.Name = "panel2";
            panel2.Size = new Size(1884, 787);
            panel2.TabIndex = 5;
            // 
            // dgvMachineType
            // 
            dgvMachineType.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMachineType.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvMachineType.DefaultCellStyle = dataGridViewCellStyle1;
            dgvMachineType.Dock = DockStyle.Fill;
            dgvMachineType.Location = new Point(0, 0);
            dgvMachineType.Name = "dgvMachineType";
            dgvMachineType.RowHeadersWidth = 62;
            dgvMachineType.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMachineType.Size = new Size(1884, 787);
            dgvMachineType.TabIndex = 0;
            dgvMachineType.CellClick += dgvMachineType_CellClick;
            // 
            // panel1
            // 
            panel1.Controls.Add(btn_tab1_Delete);
            panel1.Controls.Add(btn_tab1_Fix);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txt_tab1_MachineType);
            panel1.Controls.Add(btn_tab1_AddMachineType);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1884, 188);
            panel1.TabIndex = 4;
            // 
            // btn_tab1_Delete
            // 
            btn_tab1_Delete.Location = new Point(1105, 122);
            btn_tab1_Delete.Name = "btn_tab1_Delete";
            btn_tab1_Delete.Size = new Size(112, 34);
            btn_tab1_Delete.TabIndex = 8;
            btn_tab1_Delete.Text = "Xoá";
            btn_tab1_Delete.UseVisualStyleBackColor = true;
            btn_tab1_Delete.Click += btn_tab1_Delete_Click;
            // 
            // btn_tab1_Fix
            // 
            btn_tab1_Fix.Location = new Point(971, 122);
            btn_tab1_Fix.Name = "btn_tab1_Fix";
            btn_tab1_Fix.Size = new Size(112, 34);
            btn_tab1_Fix.TabIndex = 6;
            btn_tab1_Fix.Text = "Sửa";
            btn_tab1_Fix.UseVisualStyleBackColor = true;
            btn_tab1_Fix.Click += btn_tab1_Fix_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(720, 45);
            label1.Name = "label1";
            label1.Size = new Size(102, 30);
            label1.TabIndex = 0;
            label1.Text = "Kiểu máy";
            // 
            // txt_tab1_MachineType
            // 
            txt_tab1_MachineType.Location = new Point(828, 42);
            txt_tab1_MachineType.Multiline = true;
            txt_tab1_MachineType.Name = "txt_tab1_MachineType";
            txt_tab1_MachineType.Size = new Size(415, 74);
            txt_tab1_MachineType.TabIndex = 1;
            // 
            // btn_tab1_AddMachineType
            // 
            btn_tab1_AddMachineType.Location = new Point(835, 122);
            btn_tab1_AddMachineType.Name = "btn_tab1_AddMachineType";
            btn_tab1_AddMachineType.Size = new Size(112, 34);
            btn_tab1_AddMachineType.TabIndex = 3;
            btn_tab1_AddMachineType.Text = "Add";
            btn_tab1_AddMachineType.UseVisualStyleBackColor = true;
            btn_tab1_AddMachineType.Click += btnAddMachineType_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(55, 154);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(360, 225);
            dataGridView1.TabIndex = 2;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgvListPart);
            tabPage2.Controls.Add(panel3);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1890, 986);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Bộ phận máy";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvListPart
            // 
            dgvListPart.AllowUserToAddRows = false;
            dgvListPart.AllowUserToDeleteRows = false;
            dgvListPart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListPart.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvListPart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListPart.Dock = DockStyle.Fill;
            dgvListPart.Location = new Point(3, 257);
            dgvListPart.Name = "dgvListPart";
            dgvListPart.RowHeadersWidth = 62;
            dgvListPart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListPart.Size = new Size(1884, 726);
            dgvListPart.TabIndex = 14;
            dgvListPart.CellClick += dgvListPart_CellClick;
            // 
            // panel3
            // 
            panel3.Controls.Add(btn_tab2_Del);
            panel3.Controls.Add(btn_tab2_Fix);
            panel3.Controls.Add(cbb_tab2_MachineType);
            panel3.Controls.Add(txt_tab2_DisplayOrder);
            panel3.Controls.Add(txt_tab2_MachinePart);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(btn_tab2_AddMachinePart);
            panel3.Controls.Add(label4);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(1884, 254);
            panel3.TabIndex = 13;
            // 
            // btn_tab2_Del
            // 
            btn_tab2_Del.Location = new Point(1093, 201);
            btn_tab2_Del.Name = "btn_tab2_Del";
            btn_tab2_Del.Size = new Size(112, 43);
            btn_tab2_Del.TabIndex = 15;
            btn_tab2_Del.Text = "Xoá";
            btn_tab2_Del.UseVisualStyleBackColor = true;
            btn_tab2_Del.Click += btn_tab2_Del_Click;
            // 
            // btn_tab2_Fix
            // 
            btn_tab2_Fix.Location = new Point(948, 201);
            btn_tab2_Fix.Name = "btn_tab2_Fix";
            btn_tab2_Fix.Size = new Size(112, 43);
            btn_tab2_Fix.TabIndex = 14;
            btn_tab2_Fix.Text = "Sửa";
            btn_tab2_Fix.UseVisualStyleBackColor = true;
            btn_tab2_Fix.Click += btn_tab2_Fix_Click;
            // 
            // cbb_tab2_MachineType
            // 
            cbb_tab2_MachineType.DisplayMember = "MachineTypeName";
            cbb_tab2_MachineType.FormattingEnabled = true;
            cbb_tab2_MachineType.Location = new Point(806, 9);
            cbb_tab2_MachineType.Name = "cbb_tab2_MachineType";
            cbb_tab2_MachineType.Size = new Size(390, 38);
            cbb_tab2_MachineType.TabIndex = 11;
            cbb_tab2_MachineType.ValueMember = "Id";
            cbb_tab2_MachineType.SelectedIndexChanged += cbb_tab2_MachineType_SelectedIndexChanged;
            // 
            // txt_tab2_DisplayOrder
            // 
            txt_tab2_DisplayOrder.Location = new Point(806, 158);
            txt_tab2_DisplayOrder.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            txt_tab2_DisplayOrder.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            txt_tab2_DisplayOrder.Name = "txt_tab2_DisplayOrder";
            txt_tab2_DisplayOrder.Size = new Size(390, 37);
            txt_tab2_DisplayOrder.TabIndex = 12;
            txt_tab2_DisplayOrder.TextAlign = HorizontalAlignment.Center;
            txt_tab2_DisplayOrder.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // txt_tab2_MachinePart
            // 
            txt_tab2_MachinePart.Location = new Point(806, 70);
            txt_tab2_MachinePart.Multiline = true;
            txt_tab2_MachinePart.Name = "txt_tab2_MachinePart";
            txt_tab2_MachinePart.Size = new Size(390, 82);
            txt_tab2_MachinePart.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(646, 13);
            label2.Name = "label2";
            label2.Size = new Size(142, 30);
            label2.TabIndex = 4;
            label2.Text = "Kiểu loại máy";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(646, 93);
            label3.Name = "label3";
            label3.Size = new Size(93, 30);
            label3.TabIndex = 7;
            label3.Text = "Bộ phận";
            // 
            // btn_tab2_AddMachinePart
            // 
            btn_tab2_AddMachinePart.Location = new Point(806, 201);
            btn_tab2_AddMachinePart.Name = "btn_tab2_AddMachinePart";
            btn_tab2_AddMachinePart.Size = new Size(120, 43);
            btn_tab2_AddMachinePart.TabIndex = 6;
            btn_tab2_AddMachinePart.Text = "Add";
            btn_tab2_AddMachinePart.UseVisualStyleBackColor = true;
            btn_tab2_AddMachinePart.Click += btnAddMachinePart_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(646, 154);
            label4.Name = "label4";
            label4.Size = new Size(132, 30);
            label4.TabIndex = 9;
            label4.Text = "DisplayOder";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(dgv_tab3);
            tabPage3.Controls.Add(pnTab3);
            tabPage3.Location = new Point(4, 39);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1890, 981);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Bài kiểm tra";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgv_tab3
            // 
            dgv_tab3.AllowUserToAddRows = false;
            dgv_tab3.AllowUserToDeleteRows = false;
            dgv_tab3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgv_tab3.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_tab3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgv_tab3.DefaultCellStyle = dataGridViewCellStyle2;
            dgv_tab3.Dock = DockStyle.Fill;
            dgv_tab3.Location = new Point(640, 3);
            dgv_tab3.Name = "dgv_tab3";
            dgv_tab3.RowHeadersWidth = 62;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgv_tab3.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dgv_tab3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_tab3.Size = new Size(1247, 975);
            dgv_tab3.TabIndex = 31;
            dgv_tab3.KeyPress += dgv_tab3_KeyPress;
            // 
            // pnTab3
            // 
            pnTab3.Controls.Add(btn_tab3_Delete);
            pnTab3.Controls.Add(btn_tab3_FullDisplay);
            pnTab3.Controls.Add(btn_tab3_Fix);
            pnTab3.Controls.Add(label7);
            pnTab3.Controls.Add(txt_tab3_DisplayOrder);
            pnTab3.Controls.Add(label6);
            pnTab3.Controls.Add(btn_tab3_Detail);
            pnTab3.Controls.Add(label5);
            pnTab3.Controls.Add(label11);
            pnTab3.Controls.Add(btn_tab3_AddIteamMaintenance);
            pnTab3.Controls.Add(txt_tab3_IteamName);
            pnTab3.Controls.Add(txt_tab3_Ng_solution);
            pnTab3.Controls.Add(cbb_tab3_MachineType);
            pnTab3.Controls.Add(label10);
            pnTab3.Controls.Add(cbb_tab3_Part);
            pnTab3.Controls.Add(txt_tab3_method);
            pnTab3.Controls.Add(label8);
            pnTab3.Controls.Add(label9);
            pnTab3.Controls.Add(txt_tab3_standard);
            pnTab3.Dock = DockStyle.Left;
            pnTab3.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnTab3.Location = new Point(3, 3);
            pnTab3.Name = "pnTab3";
            pnTab3.Size = new Size(637, 975);
            pnTab3.TabIndex = 30;
            // 
            // btn_tab3_Delete
            // 
            btn_tab3_Delete.Location = new Point(350, 728);
            btn_tab3_Delete.Name = "btn_tab3_Delete";
            btn_tab3_Delete.Size = new Size(120, 43);
            btn_tab3_Delete.TabIndex = 32;
            btn_tab3_Delete.Text = "Xoá";
            btn_tab3_Delete.UseVisualStyleBackColor = true;
            // 
            // btn_tab3_FullDisplay
            // 
            btn_tab3_FullDisplay.Location = new Point(350, 794);
            btn_tab3_FullDisplay.Name = "btn_tab3_FullDisplay";
            btn_tab3_FullDisplay.Size = new Size(120, 43);
            btn_tab3_FullDisplay.TabIndex = 31;
            btn_tab3_FullDisplay.Text = "Hiển thị full";
            btn_tab3_FullDisplay.UseVisualStyleBackColor = true;
            btn_tab3_FullDisplay.Click += btn_tab3_FullDisplay_Click;
            // 
            // btn_tab3_Fix
            // 
            btn_tab3_Fix.Location = new Point(224, 728);
            btn_tab3_Fix.Name = "btn_tab3_Fix";
            btn_tab3_Fix.Size = new Size(120, 43);
            btn_tab3_Fix.TabIndex = 30;
            btn_tab3_Fix.Text = "Sửa";
            btn_tab3_Fix.UseVisualStyleBackColor = true;
            btn_tab3_Fix.Click += btn_tab3_Fix_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(48, 120);
            label7.Name = "label7";
            label7.Size = new Size(103, 21);
            label7.TabIndex = 12;
            label7.Text = "Kiểu loại máy";
            // 
            // txt_tab3_DisplayOrder
            // 
            txt_tab3_DisplayOrder.Font = new Font("Microsoft Sans Serif", 8F);
            txt_tab3_DisplayOrder.Location = new Point(226, 639);
            txt_tab3_DisplayOrder.Name = "txt_tab3_DisplayOrder";
            txt_tab3_DisplayOrder.Size = new Size(180, 26);
            txt_tab3_DisplayOrder.TabIndex = 29;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(48, 173);
            label6.Name = "label6";
            label6.Size = new Size(67, 21);
            label6.TabIndex = 14;
            label6.Text = "Bộ phận";
            // 
            // btn_tab3_Detail
            // 
            btn_tab3_Detail.Location = new Point(226, 794);
            btn_tab3_Detail.Name = "btn_tab3_Detail";
            btn_tab3_Detail.Size = new Size(120, 43);
            btn_tab3_Detail.TabIndex = 28;
            btn_tab3_Detail.Text = "Hiển thị";
            btn_tab3_Detail.UseVisualStyleBackColor = true;
            btn_tab3_Detail.Click += btn_tab3_Detail_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(48, 226);
            label5.Name = "label5";
            label5.Size = new Size(101, 21);
            label5.TabIndex = 16;
            label5.Text = "Mục kiểm tra";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(58, 639);
            label11.Name = "label11";
            label11.Size = new Size(96, 21);
            label11.TabIndex = 26;
            label11.Text = "DisplayOder";
            // 
            // btn_tab3_AddIteamMaintenance
            // 
            btn_tab3_AddIteamMaintenance.Location = new Point(102, 728);
            btn_tab3_AddIteamMaintenance.Name = "btn_tab3_AddIteamMaintenance";
            btn_tab3_AddIteamMaintenance.Size = new Size(120, 43);
            btn_tab3_AddIteamMaintenance.TabIndex = 13;
            btn_tab3_AddIteamMaintenance.Text = "Add";
            btn_tab3_AddIteamMaintenance.UseVisualStyleBackColor = true;
            btn_tab3_AddIteamMaintenance.Click += btn_tab3_AddIteamMaintenance_Click;
            // 
            // txt_tab3_IteamName
            // 
            txt_tab3_IteamName.Font = new Font("Microsoft Sans Serif", 8F);
            txt_tab3_IteamName.Location = new Point(224, 223);
            txt_tab3_IteamName.Multiline = true;
            txt_tab3_IteamName.Name = "txt_tab3_IteamName";
            txt_tab3_IteamName.Size = new Size(390, 37);
            txt_tab3_IteamName.TabIndex = 17;
            // 
            // txt_tab3_Ng_solution
            // 
            txt_tab3_Ng_solution.Font = new Font("Microsoft Sans Serif", 8F);
            txt_tab3_Ng_solution.Location = new Point(226, 480);
            txt_tab3_Ng_solution.Multiline = true;
            txt_tab3_Ng_solution.Name = "txt_tab3_Ng_solution";
            txt_tab3_Ng_solution.Size = new Size(390, 134);
            txt_tab3_Ng_solution.TabIndex = 25;
            // 
            // cbb_tab3_MachineType
            // 
            cbb_tab3_MachineType.DisplayMember = "MachineTypeName";
            cbb_tab3_MachineType.Font = new Font("Microsoft Sans Serif", 8F);
            cbb_tab3_MachineType.FormattingEnabled = true;
            cbb_tab3_MachineType.Location = new Point(224, 116);
            cbb_tab3_MachineType.Name = "cbb_tab3_MachineType";
            cbb_tab3_MachineType.Size = new Size(390, 28);
            cbb_tab3_MachineType.TabIndex = 18;
            cbb_tab3_MachineType.ValueMember = "Id";
            cbb_tab3_MachineType.SelectedIndexChanged += cbb_tab3_MachineType_SelectedIndexChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(50, 483);
            label10.Name = "label10";
            label10.Size = new Size(167, 21);
            label10.TabIndex = 24;
            label10.Text = "Phương pháp xử lý NG";
            // 
            // cbb_tab3_Part
            // 
            cbb_tab3_Part.Font = new Font("Microsoft Sans Serif", 8F);
            cbb_tab3_Part.FormattingEnabled = true;
            cbb_tab3_Part.Location = new Point(224, 170);
            cbb_tab3_Part.Name = "cbb_tab3_Part";
            cbb_tab3_Part.Size = new Size(390, 28);
            cbb_tab3_Part.TabIndex = 19;
            // 
            // txt_tab3_method
            // 
            txt_tab3_method.Font = new Font("Microsoft Sans Serif", 8F);
            txt_tab3_method.Location = new Point(224, 384);
            txt_tab3_method.Multiline = true;
            txt_tab3_method.Name = "txt_tab3_method";
            txt_tab3_method.Size = new Size(390, 90);
            txt_tab3_method.TabIndex = 23;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(48, 269);
            label8.Name = "label8";
            label8.Size = new Size(146, 21);
            label8.TabIndex = 20;
            label8.Text = "Tiêu chuẩn kiểm tra";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(48, 387);
            label9.Name = "label9";
            label9.Size = new Size(165, 21);
            label9.TabIndex = 22;
            label9.Text = "Phương pháp kiểm tra";
            // 
            // txt_tab3_standard
            // 
            txt_tab3_standard.Font = new Font("Microsoft Sans Serif", 8F);
            txt_tab3_standard.Location = new Point(224, 266);
            txt_tab3_standard.Multiline = true;
            txt_tab3_standard.Name = "txt_tab3_standard";
            txt_tab3_standard.Size = new Size(390, 100);
            txt_tab3_standard.TabIndex = 21;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(btn_tab4_AddMachine);
            tabPage4.Controls.Add(cbb_tab4_MachineType);
            tabPage4.Controls.Add(txt_tab4_MachineID);
            tabPage4.Controls.Add(label12);
            tabPage4.Controls.Add(label13);
            tabPage4.Location = new Point(4, 34);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(1890, 986);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Máy";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // btn_tab4_AddMachine
            // 
            btn_tab4_AddMachine.Location = new Point(491, 235);
            btn_tab4_AddMachine.Name = "btn_tab4_AddMachine";
            btn_tab4_AddMachine.Size = new Size(120, 43);
            btn_tab4_AddMachine.TabIndex = 24;
            btn_tab4_AddMachine.Text = "Add";
            btn_tab4_AddMachine.UseVisualStyleBackColor = true;
            btn_tab4_AddMachine.Click += btn_tab4_AddMachine_Click;
            // 
            // cbb_tab4_MachineType
            // 
            cbb_tab4_MachineType.FormattingEnabled = true;
            cbb_tab4_MachineType.Location = new Point(380, 173);
            cbb_tab4_MachineType.Name = "cbb_tab4_MachineType";
            cbb_tab4_MachineType.Size = new Size(390, 38);
            cbb_tab4_MachineType.TabIndex = 23;
            // 
            // txt_tab4_MachineID
            // 
            txt_tab4_MachineID.Location = new Point(380, 120);
            txt_tab4_MachineID.Name = "txt_tab4_MachineID";
            txt_tab4_MachineID.Size = new Size(390, 37);
            txt_tab4_MachineID.TabIndex = 22;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(129, 173);
            label12.Name = "label12";
            label12.Size = new Size(102, 30);
            label12.TabIndex = 21;
            label12.Text = "Kiểu máy";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(129, 120);
            label13.Name = "label13";
            label13.Size = new Size(91, 30);
            label13.TabIndex = 20;
            label13.Text = "Mã máy";
            // 
            // FrmSetup
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1898, 1024);
            Controls.Add(tabControl1);
            Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Margin = new Padding(4);
            Name = "FrmSetup";
            Text = "FrmSetup";
            Shown += FrmSetup_Shown;
            KeyDown += FrmSetup_KeyDown;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMachineType).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvListPart).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txt_tab2_DisplayOrder).EndInit();
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_tab3).EndInit();
            pnTab3.ResumeLayout(false);
            pnTab3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txt_tab3_DisplayOrder).EndInit();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private DataGridView dataGridView1;
        private TextBox txt_tab1_MachineType;
        private Label label1;
        private Button btn_tab1_AddMachineType;
        private ComboBox cbb_tab2_MachineType;
        private Label label4;
        private TextBox txt_tab2_MachinePart;
        private Label label3;
        private Button btn_tab2_AddMachinePart;
        private Label label2;
        private ComboBox cbb_tab3_Part;
        private ComboBox cbb_tab3_MachineType;
        private TextBox txt_tab3_IteamName;
        private Label label5;
        private Label label6;
        private Button btn_tab3_AddIteamMaintenance;
        private Label label7;
        private Label label11;
        private TextBox txt_tab3_Ng_solution;
        private Label label10;
        private TextBox txt_tab3_method;
        private Label label9;
        private TextBox txt_tab3_standard;
        private Label label8;
        private Button btn_tab4_AddMachine;
        private ComboBox cbb_tab4_MachineType;
        private TextBox txt_tab4_MachineID;
        private Label label12;
        private Label label13;
        private Panel panel2;
        private DataGridView dgvMachineType;
        private Panel panel1;
        private NumericUpDown txt_tab2_DisplayOrder;
        private Panel panel3;
        private DataGridView dgvListPart;
        private Button btn_tab3_Detail;
        private Button btn_tab1_Delete;
        private Button btn_tab1_Fix;
        private Button btn_tab2_Del;
        private Button btn_tab2_Fix;
        private NumericUpDown txt_tab3_DisplayOrder;
        private Panel pnTab3;
        private DataGridView dgv_tab3;
        private Button btn_tab3_Fix;
        private Button btn_tab3_FullDisplay;
        private Button btn_tab3_Delete;
    }
}