namespace MaintenanceApp.Forms
{
    partial class FrmHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHistory));
            panel1 = new Panel();
            label5 = new Label();
            cbbResult = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            dtpTo = new DateTimePicker();
            dtpFrom = new DateTimePicker();
            btnPrint = new Button();
            btnFind = new Button();
            label2 = new Label();
            txtUserID = new TextBox();
            label1 = new Label();
            txtMachineID = new TextBox();
            dgvHistory = new DataGridView();
            MachineCode = new DataGridViewTextBoxColumn();
            userID = new DataGridViewTextBoxColumn();
            TypeMachineName = new DataGridViewTextBoxColumn();
            PartName = new DataGridViewTextBoxColumn();
            ItemName = new DataGridViewTextBoxColumn();
            Standard = new DataGridViewTextBoxColumn();
            Method = new DataGridViewTextBoxColumn();
            ng_solution = new DataGridViewTextBoxColumn();
            OK = new DataGridViewCheckBoxColumn();
            Clean = new DataGridViewCheckBoxColumn();
            Replace = new DataGridViewCheckBoxColumn();
            Time = new DataGridViewTextBoxColumn();
            btnKhongkhi = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnKhongkhi);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(cbbResult);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(dtpTo);
            panel1.Controls.Add(dtpFrom);
            panel1.Controls.Add(btnPrint);
            panel1.Controls.Add(btnFind);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtUserID);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtMachineID);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1898, 167);
            panel1.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(720, 29);
            label5.Name = "label5";
            label5.Size = new Size(72, 25);
            label5.TabIndex = 12;
            label5.Text = "Kết quả";
            // 
            // cbbResult
            // 
            cbbResult.FormattingEnabled = true;
            cbbResult.Items.AddRange(new object[] { "", "OK", "Clean/Adjust", "Replace" });
            cbbResult.Location = new Point(807, 25);
            cbbResult.Name = "cbbResult";
            cbbResult.Size = new Size(145, 33);
            cbbResult.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1229, 29);
            label4.Name = "label4";
            label4.Size = new Size(80, 25);
            label4.TabIndex = 10;
            label4.Text = "Tới ngày";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(967, 29);
            label3.Name = "label3";
            label3.Size = new Size(76, 25);
            label3.TabIndex = 9;
            label3.Text = "Từ ngày";
            // 
            // dtpTo
            // 
            dtpTo.Format = DateTimePickerFormat.Short;
            dtpTo.Location = new Point(1324, 26);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(152, 31);
            dtpTo.TabIndex = 8;
            // 
            // dtpFrom
            // 
            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Location = new Point(1058, 26);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(156, 31);
            dtpFrom.TabIndex = 7;
            dtpFrom.Value = new DateTime(2026, 3, 20, 0, 0, 0, 0);
            dtpFrom.ValueChanged += dtpFrom_ValueChanged;
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(1667, 14);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(131, 55);
            btnPrint.TabIndex = 6;
            btnPrint.Text = "Print";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += btnPrint_Click;
            // 
            // btnFind
            // 
            btnFind.Location = new Point(1507, 14);
            btnFind.Name = "btnFind";
            btnFind.Size = new Size(131, 55);
            btnFind.TabIndex = 4;
            btnFind.Text = "Tìm kiếm";
            btnFind.UseVisualStyleBackColor = true;
            btnFind.Click += btnFind_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(468, 29);
            label2.Name = "label2";
            label2.Size = new Size(66, 25);
            label2.TabIndex = 3;
            label2.Text = "Mã NV";
            // 
            // txtUserID
            // 
            txtUserID.Location = new Point(549, 26);
            txtUserID.Name = "txtUserID";
            txtUserID.Size = new Size(156, 31);
            txtUserID.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(181, 29);
            label1.Name = "label1";
            label1.Size = new Size(101, 25);
            label1.TabIndex = 1;
            label1.Text = "Machine ID";
            // 
            // txtMachineID
            // 
            txtMachineID.Location = new Point(297, 26);
            txtMachineID.Name = "txtMachineID";
            txtMachineID.Size = new Size(156, 31);
            txtMachineID.TabIndex = 0;
            // 
            // dgvHistory
            // 
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.AllowUserToDeleteRows = false;
            dgvHistory.AllowUserToResizeColumns = false;
            dgvHistory.AllowUserToResizeRows = false;
            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistory.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistory.Columns.AddRange(new DataGridViewColumn[] { MachineCode, userID, TypeMachineName, PartName, ItemName, Standard, Method, ng_solution, OK, Clean, Replace, Time });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvHistory.DefaultCellStyle = dataGridViewCellStyle1;
            dgvHistory.Dock = DockStyle.Fill;
            dgvHistory.Location = new Point(0, 167);
            dgvHistory.Name = "dgvHistory";
            dgvHistory.ReadOnly = true;
            dgvHistory.RowHeadersVisible = false;
            dgvHistory.RowHeadersWidth = 62;
            dgvHistory.Size = new Size(1898, 857);
            dgvHistory.TabIndex = 2;
            // 
            // MachineCode
            // 
            MachineCode.HeaderText = "Tên máy";
            MachineCode.MinimumWidth = 8;
            MachineCode.Name = "MachineCode";
            MachineCode.ReadOnly = true;
            // 
            // userID
            // 
            userID.HeaderText = "Mã NV";
            userID.MinimumWidth = 8;
            userID.Name = "userID";
            userID.ReadOnly = true;
            // 
            // TypeMachineName
            // 
            TypeMachineName.HeaderText = "Loại máy";
            TypeMachineName.MinimumWidth = 8;
            TypeMachineName.Name = "TypeMachineName";
            TypeMachineName.ReadOnly = true;
            // 
            // PartName
            // 
            PartName.FillWeight = 113.930321F;
            PartName.HeaderText = "Bộ phận";
            PartName.MinimumWidth = 8;
            PartName.Name = "PartName";
            PartName.ReadOnly = true;
            // 
            // ItemName
            // 
            ItemName.FillWeight = 113.930321F;
            ItemName.HeaderText = "Nội dung kiểm tra";
            ItemName.MinimumWidth = 8;
            ItemName.Name = "ItemName";
            ItemName.ReadOnly = true;
            // 
            // Standard
            // 
            Standard.FillWeight = 113.930321F;
            Standard.HeaderText = "Tiêu chuẩn";
            Standard.MinimumWidth = 8;
            Standard.Name = "Standard";
            Standard.ReadOnly = true;
            // 
            // Method
            // 
            Method.FillWeight = 113.930321F;
            Method.HeaderText = "Phương pháp";
            Method.MinimumWidth = 8;
            Method.Name = "Method";
            Method.ReadOnly = true;
            // 
            // ng_solution
            // 
            ng_solution.HeaderText = "Phương pháp xử lý NG";
            ng_solution.MinimumWidth = 8;
            ng_solution.Name = "ng_solution";
            ng_solution.ReadOnly = true;
            // 
            // OK
            // 
            OK.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            OK.FillWeight = 79.54545F;
            OK.HeaderText = "OK";
            OK.MinimumWidth = 8;
            OK.Name = "OK";
            OK.ReadOnly = true;
            OK.Width = 42;
            // 
            // Clean
            // 
            Clean.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Clean.FillWeight = 84.268F;
            Clean.HeaderText = "Vệ sinh";
            Clean.MinimumWidth = 8;
            Clean.Name = "Clean";
            Clean.ReadOnly = true;
            Clean.Width = 68;
            // 
            // Replace
            // 
            Replace.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Replace.FillWeight = 80.46514F;
            Replace.HeaderText = "Thay thế";
            Replace.MinimumWidth = 8;
            Replace.Name = "Replace";
            Replace.ReadOnly = true;
            Replace.Width = 77;
            // 
            // Time
            // 
            Time.HeaderText = "Thời gian";
            Time.MinimumWidth = 8;
            Time.Name = "Time";
            Time.ReadOnly = true;
            // 
            // btnKhongkhi
            // 
            btnKhongkhi.BackColor = SystemColors.ActiveCaption;
            btnKhongkhi.Location = new Point(3, 106);
            btnKhongkhi.Name = "btnKhongkhi";
            btnKhongkhi.Size = new Size(139, 58);
            btnKhongkhi.TabIndex = 13;
            btnKhongkhi.Text = "Không khí";
            btnKhongkhi.UseVisualStyleBackColor = false;
            btnKhongkhi.Click += btnKhongkhi_Click;
            // 
            // FrmHistory
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1898, 1024);
            Controls.Add(dgvHistory);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmHistory";
            Text = "Lịch sử";
            Load += FrmTable_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnPrint;
        private Button btnFind;
        private Label label2;
        private TextBox txtUserID;
        private Label label1;
        private TextBox txtMachineID;
        private DataGridView dgvHistory;
        private Label label4;
        private Label label3;
        private DateTimePicker dtpTo;
        private DateTimePicker dtpFrom;
        private ComboBox cbbResult;
        private Label label5;
        private DataGridViewTextBoxColumn ItemId;
        private DataGridViewTextBoxColumn MachineCode;
        private DataGridViewTextBoxColumn userID;
        private DataGridViewTextBoxColumn TypeMachineName;
        private DataGridViewTextBoxColumn PartName;
        private DataGridViewTextBoxColumn ItemName;
        private DataGridViewTextBoxColumn Standard;
        private DataGridViewTextBoxColumn Method;
        private DataGridViewTextBoxColumn ng_solution;
        private DataGridViewCheckBoxColumn OK;
        private DataGridViewCheckBoxColumn Clean;
        private DataGridViewCheckBoxColumn Replace;
        private DataGridViewTextBoxColumn Time;
        private Button btnKhongkhi;
    }
}