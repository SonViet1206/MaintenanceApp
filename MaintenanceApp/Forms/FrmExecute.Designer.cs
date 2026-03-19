namespace MaintenanceApp.Forms
{
    partial class FrmExecute
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmExecute));
            panel1 = new Panel();
            textBox1 = new TextBox();
            btnSave = new Button();
            btnAllOK = new Button();
            btnRun = new Button();
            label2 = new Label();
            txtUserID = new TextBox();
            label1 = new Label();
            txtMachineID = new TextBox();
            panel2 = new Panel();
            dgvChecklist = new DataGridView();
            ItemId = new DataGridViewTextBoxColumn();
            PartName = new DataGridViewTextBoxColumn();
            ItemName = new DataGridViewTextBoxColumn();
            Standard = new DataGridViewTextBoxColumn();
            Method = new DataGridViewTextBoxColumn();
            ng_solution = new DataGridViewTextBoxColumn();
            OK = new DataGridViewCheckBoxColumn();
            Clean = new DataGridViewCheckBoxColumn();
            Replace = new DataGridViewCheckBoxColumn();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChecklist).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(btnAllOK);
            panel1.Controls.Add(btnRun);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtUserID);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtMachineID);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1898, 204);
            panel1.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.ForeColor = SystemColors.InactiveBorder;
            textBox1.Location = new Point(1884, 121);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(11, 37);
            textBox1.TabIndex = 7;
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(996, 143);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(131, 55);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnAllOK
            // 
            btnAllOK.BackColor = Color.LawnGreen;
            btnAllOK.Location = new Point(1813, 164);
            btnAllOK.Name = "btnAllOK";
            btnAllOK.Size = new Size(85, 34);
            btnAllOK.TabIndex = 5;
            btnAllOK.Text = "All OK";
            btnAllOK.UseVisualStyleBackColor = false;
            btnAllOK.Visible = false;
            btnAllOK.Click += btnAllOK_Click;
            // 
            // btnRun
            // 
            btnRun.Location = new Point(821, 143);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(131, 55);
            btnRun.TabIndex = 4;
            btnRun.Text = "Run";
            btnRun.UseVisualStyleBackColor = true;
            btnRun.Click += btnRun_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(696, 107);
            label2.Name = "label2";
            label2.Size = new Size(84, 30);
            label2.TabIndex = 3;
            label2.Text = "User ID";
            // 
            // txtUserID
            // 
            txtUserID.Location = new Point(821, 100);
            txtUserID.Name = "txtUserID";
            txtUserID.Size = new Size(306, 37);
            txtUserID.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(696, 52);
            label1.Name = "label1";
            label1.Size = new Size(122, 30);
            label1.TabIndex = 1;
            label1.Text = "Machine ID";
            // 
            // txtMachineID
            // 
            txtMachineID.Location = new Point(821, 45);
            txtMachineID.Name = "txtMachineID";
            txtMachineID.Size = new Size(306, 37);
            txtMachineID.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvChecklist);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 204);
            panel2.Name = "panel2";
            panel2.Size = new Size(1898, 820);
            panel2.TabIndex = 1;
            // 
            // dgvChecklist
            // 
            dgvChecklist.AllowUserToAddRows = false;
            dgvChecklist.AllowUserToDeleteRows = false;
            dgvChecklist.AllowUserToResizeColumns = false;
            dgvChecklist.AllowUserToResizeRows = false;
            dgvChecklist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChecklist.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvChecklist.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChecklist.Columns.AddRange(new DataGridViewColumn[] { ItemId, PartName, ItemName, Standard, Method, ng_solution, OK, Clean, Replace });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 11F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvChecklist.DefaultCellStyle = dataGridViewCellStyle1;
            dgvChecklist.Dock = DockStyle.Fill;
            dgvChecklist.Location = new Point(0, 0);
            dgvChecklist.Name = "dgvChecklist";
            dgvChecklist.RowHeadersVisible = false;
            dgvChecklist.RowHeadersWidth = 62;
            dgvChecklist.Size = new Size(1898, 820);
            dgvChecklist.TabIndex = 0;
            dgvChecklist.CellContentClick += dgvChecklist_CellContentClick;
            // 
            // ItemId
            // 
            ItemId.HeaderText = "IteamID";
            ItemId.MinimumWidth = 8;
            ItemId.Name = "ItemId";
            ItemId.Visible = false;
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
            OK.Width = 49;
            // 
            // Clean
            // 
            Clean.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Clean.FillWeight = 84.268F;
            Clean.HeaderText = "Vệ sinh";
            Clean.MinimumWidth = 8;
            Clean.Name = "Clean";
            Clean.Width = 89;
            // 
            // Replace
            // 
            Replace.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Replace.FillWeight = 80.46514F;
            Replace.HeaderText = "Thay thế";
            Replace.MinimumWidth = 8;
            Replace.Name = "Replace";
            Replace.Width = 102;
            // 
            // FrmExecute
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1898, 1024);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 11F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "FrmExecute";
            Text = "Phần mềm bảo dưỡng máy";
            KeyDown += FrmExecute_KeyDown;
            KeyPress += FrmExecute_KeyPress;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvChecklist).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnRun;
        private Label label2;
        private TextBox txtUserID;
        private Label label1;
        private TextBox txtMachineID;
        private Panel panel2;
        private DataGridView dgvChecklist;
        private Button btnAllOK;
        private Button btnSave;
        private DataGridViewTextBoxColumn ItemId;
        private DataGridViewTextBoxColumn PartName;
        private DataGridViewTextBoxColumn ItemName;
        private DataGridViewTextBoxColumn Standard;
        private DataGridViewTextBoxColumn Method;
        private DataGridViewTextBoxColumn ng_solution;
        private DataGridViewCheckBoxColumn OK;
        private DataGridViewCheckBoxColumn Clean;
        private DataGridViewCheckBoxColumn Replace;
        private TextBox textBox1;
    }
}