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
            cbb_tab2_MachineType = new ComboBox();
            txt_tab2_DisplayOrder = new NumericUpDown();
            txt_tab2_MachinePart = new TextBox();
            label2 = new Label();
            label3 = new Label();
            btn_tab2_AddMachinePart = new Button();
            label4 = new Label();
            tabPage3 = new TabPage();
            btn_tab3_Detail = new Button();
            txt_tab3_DisplayOrder = new TextBox();
            label11 = new Label();
            txt_tab3_Ng_solution = new TextBox();
            label10 = new Label();
            txt_tab3_method = new TextBox();
            label9 = new Label();
            txt_tab3_standard = new TextBox();
            label8 = new Label();
            cbb_tab3_Part = new ComboBox();
            cbb_tab3_MachineType = new ComboBox();
            txt_tab3_IteamName = new TextBox();
            label5 = new Label();
            label6 = new Label();
            btn_tab3_AddIteamMaintenance = new Button();
            label7 = new Label();
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
            tabControl1.Size = new Size(960, 711);
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
            tabPage1.Size = new Size(952, 668);
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
            panel2.Size = new Size(946, 474);
            panel2.TabIndex = 5;
            // 
            // dgvMachineType
            // 
            dgvMachineType.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMachineType.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMachineType.Dock = DockStyle.Fill;
            dgvMachineType.Location = new Point(0, 0);
            dgvMachineType.Name = "dgvMachineType";
            dgvMachineType.RowHeadersWidth = 62;
            dgvMachineType.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMachineType.Size = new Size(946, 474);
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
            panel1.Size = new Size(946, 188);
            panel1.TabIndex = 4;
            // 
            // btn_tab1_Delete
            // 
            btn_tab1_Delete.Location = new Point(552, 121);
            btn_tab1_Delete.Name = "btn_tab1_Delete";
            btn_tab1_Delete.Size = new Size(112, 34);
            btn_tab1_Delete.TabIndex = 8;
            btn_tab1_Delete.Text = "Xoá";
            btn_tab1_Delete.UseVisualStyleBackColor = true;
            btn_tab1_Delete.Click += btn_tab1_Delete_Click;
            // 
            // btn_tab1_Fix
            // 
            btn_tab1_Fix.Location = new Point(418, 121);
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
            label1.Location = new Point(200, 58);
            label1.Name = "label1";
            label1.Size = new Size(102, 30);
            label1.TabIndex = 0;
            label1.Text = "Kiểu máy";
            // 
            // txt_tab1_MachineType
            // 
            txt_tab1_MachineType.Location = new Point(308, 55);
            txt_tab1_MachineType.Name = "txt_tab1_MachineType";
            txt_tab1_MachineType.Size = new Size(415, 37);
            txt_tab1_MachineType.TabIndex = 1;
            // 
            // btn_tab1_AddMachineType
            // 
            btn_tab1_AddMachineType.Location = new Point(282, 121);
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
            tabPage2.Size = new Size(952, 673);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Bộ phận máy";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvListPart
            // 
            dgvListPart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListPart.Dock = DockStyle.Fill;
            dgvListPart.Location = new Point(3, 257);
            dgvListPart.Name = "dgvListPart";
            dgvListPart.RowHeadersWidth = 62;
            dgvListPart.Size = new Size(946, 413);
            dgvListPart.TabIndex = 14;
            // 
            // panel3
            // 
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
            panel3.Size = new Size(946, 254);
            panel3.TabIndex = 13;
            // 
            // cbb_tab2_MachineType
            // 
            cbb_tab2_MachineType.DisplayMember = "MachineTypeName";
            cbb_tab2_MachineType.FormattingEnabled = true;
            cbb_tab2_MachineType.Location = new Point(309, 32);
            cbb_tab2_MachineType.Name = "cbb_tab2_MachineType";
            cbb_tab2_MachineType.Size = new Size(390, 38);
            cbb_tab2_MachineType.TabIndex = 11;
            // 
            // txt_tab2_DisplayOrder
            // 
            txt_tab2_DisplayOrder.Location = new Point(309, 146);
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
            txt_tab2_MachinePart.Location = new Point(309, 86);
            txt_tab2_MachinePart.Name = "txt_tab2_MachinePart";
            txt_tab2_MachinePart.Size = new Size(390, 37);
            txt_tab2_MachinePart.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(149, 36);
            label2.Name = "label2";
            label2.Size = new Size(142, 30);
            label2.TabIndex = 4;
            label2.Text = "Kiểu loại máy";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(149, 89);
            label3.Name = "label3";
            label3.Size = new Size(93, 30);
            label3.TabIndex = 7;
            label3.Text = "Bộ phận";
            // 
            // btn_tab2_AddMachinePart
            // 
            btn_tab2_AddMachinePart.Location = new Point(432, 189);
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
            label4.Location = new Point(149, 142);
            label4.Name = "label4";
            label4.Size = new Size(132, 30);
            label4.TabIndex = 9;
            label4.Text = "DisplayOder";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(btn_tab3_Detail);
            tabPage3.Controls.Add(txt_tab3_DisplayOrder);
            tabPage3.Controls.Add(label11);
            tabPage3.Controls.Add(txt_tab3_Ng_solution);
            tabPage3.Controls.Add(label10);
            tabPage3.Controls.Add(txt_tab3_method);
            tabPage3.Controls.Add(label9);
            tabPage3.Controls.Add(txt_tab3_standard);
            tabPage3.Controls.Add(label8);
            tabPage3.Controls.Add(cbb_tab3_Part);
            tabPage3.Controls.Add(cbb_tab3_MachineType);
            tabPage3.Controls.Add(txt_tab3_IteamName);
            tabPage3.Controls.Add(label5);
            tabPage3.Controls.Add(label6);
            tabPage3.Controls.Add(btn_tab3_AddIteamMaintenance);
            tabPage3.Controls.Add(label7);
            tabPage3.Location = new Point(4, 34);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(952, 673);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Bài kiểm tra";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // btn_tab3_Detail
            // 
            btn_tab3_Detail.Location = new Point(667, 401);
            btn_tab3_Detail.Name = "btn_tab3_Detail";
            btn_tab3_Detail.Size = new Size(120, 43);
            btn_tab3_Detail.TabIndex = 28;
            btn_tab3_Detail.Text = "Chi tiết";
            btn_tab3_Detail.UseVisualStyleBackColor = true;
            btn_tab3_Detail.Click += btn_tab3_Detail_Click;
            // 
            // txt_tab3_DisplayOrder
            // 
            txt_tab3_DisplayOrder.Location = new Point(419, 340);
            txt_tab3_DisplayOrder.Name = "txt_tab3_DisplayOrder";
            txt_tab3_DisplayOrder.Size = new Size(390, 37);
            txt_tab3_DisplayOrder.TabIndex = 27;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(168, 343);
            label11.Name = "label11";
            label11.Size = new Size(132, 30);
            label11.TabIndex = 26;
            label11.Text = "DisplayOder";
            // 
            // txt_tab3_Ng_solution
            // 
            txt_tab3_Ng_solution.Location = new Point(419, 288);
            txt_tab3_Ng_solution.Name = "txt_tab3_Ng_solution";
            txt_tab3_Ng_solution.Size = new Size(390, 37);
            txt_tab3_Ng_solution.TabIndex = 25;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(168, 291);
            label10.Name = "label10";
            label10.Size = new Size(231, 30);
            label10.TabIndex = 24;
            label10.Text = "Phương pháp xử lý NG";
            // 
            // txt_tab3_method
            // 
            txt_tab3_method.Location = new Point(419, 229);
            txt_tab3_method.Name = "txt_tab3_method";
            txt_tab3_method.Size = new Size(390, 37);
            txt_tab3_method.TabIndex = 23;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(168, 232);
            label9.Name = "label9";
            label9.Size = new Size(228, 30);
            label9.TabIndex = 22;
            label9.Text = "Phương pháp kiểm tra";
            // 
            // txt_tab3_standard
            // 
            txt_tab3_standard.Location = new Point(419, 174);
            txt_tab3_standard.Name = "txt_tab3_standard";
            txt_tab3_standard.Size = new Size(390, 37);
            txt_tab3_standard.TabIndex = 21;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(168, 177);
            label8.Name = "label8";
            label8.Size = new Size(202, 30);
            label8.TabIndex = 20;
            label8.Text = "Tiêu chuẩn kiểm tra";
            // 
            // cbb_tab3_Part
            // 
            cbb_tab3_Part.FormattingEnabled = true;
            cbb_tab3_Part.Location = new Point(419, 78);
            cbb_tab3_Part.Name = "cbb_tab3_Part";
            cbb_tab3_Part.Size = new Size(390, 38);
            cbb_tab3_Part.TabIndex = 19;
            // 
            // cbb_tab3_MachineType
            // 
            cbb_tab3_MachineType.DisplayMember = "MachineTypeName";
            cbb_tab3_MachineType.FormattingEnabled = true;
            cbb_tab3_MachineType.Location = new Point(419, 24);
            cbb_tab3_MachineType.Name = "cbb_tab3_MachineType";
            cbb_tab3_MachineType.Size = new Size(390, 38);
            cbb_tab3_MachineType.TabIndex = 18;
            cbb_tab3_MachineType.ValueMember = "Id";
            cbb_tab3_MachineType.SelectedIndexChanged += cbb_tab3_MachineType_SelectedIndexChanged;
            // 
            // txt_tab3_IteamName
            // 
            txt_tab3_IteamName.Location = new Point(419, 131);
            txt_tab3_IteamName.Name = "txt_tab3_IteamName";
            txt_tab3_IteamName.Size = new Size(390, 37);
            txt_tab3_IteamName.TabIndex = 17;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(168, 134);
            label5.Name = "label5";
            label5.Size = new Size(140, 30);
            label5.TabIndex = 16;
            label5.Text = "Mục kiểm tra";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(168, 81);
            label6.Name = "label6";
            label6.Size = new Size(93, 30);
            label6.TabIndex = 14;
            label6.Text = "Bộ phận";
            // 
            // btn_tab3_AddIteamMaintenance
            // 
            btn_tab3_AddIteamMaintenance.Location = new Point(419, 401);
            btn_tab3_AddIteamMaintenance.Name = "btn_tab3_AddIteamMaintenance";
            btn_tab3_AddIteamMaintenance.Size = new Size(120, 43);
            btn_tab3_AddIteamMaintenance.TabIndex = 13;
            btn_tab3_AddIteamMaintenance.Text = "Thêm";
            btn_tab3_AddIteamMaintenance.UseVisualStyleBackColor = true;
            btn_tab3_AddIteamMaintenance.Click += btn_tab3_AddIteamMaintenance_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(168, 28);
            label7.Name = "label7";
            label7.Size = new Size(142, 30);
            label7.TabIndex = 12;
            label7.Text = "Kiểu loại máy";
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
            tabPage4.Size = new Size(952, 673);
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
            ClientSize = new Size(960, 711);
            Controls.Add(tabControl1);
            Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "FrmSetup";
            Text = "FrmSetup";
            Shown += FrmSetup_Shown;
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
            tabPage3.PerformLayout();
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
        private TextBox txt_tab3_DisplayOrder;
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
    }
}