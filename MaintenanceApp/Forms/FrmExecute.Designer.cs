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
            label4 = new Label();
            label3 = new Label();
            numValue3 = new NumericUpDown();
            numValue2 = new NumericUpDown();
            numValue1 = new NumericUpDown();
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
            pnPeko = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numValue3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numValue2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numValue1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChecklist).BeginInit();
            pnPeko.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(pnPeko);
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
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(450, 24);
            label4.Name = "label4";
            label4.Size = new Size(22, 30);
            label4.TabIndex = 12;
            label4.Text = "-";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(267, 24);
            label3.Name = "label3";
            label3.Size = new Size(22, 30);
            label3.TabIndex = 11;
            label3.Text = "-";
            // 
            // numValue3
            // 
            numValue3.DecimalPlaces = 2;
            numValue3.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numValue3.Location = new Point(480, 21);
            numValue3.Maximum = new decimal(new int[] { 1410065407, 2, 0, 0 });
            numValue3.Name = "numValue3";
            numValue3.Size = new Size(145, 37);
            numValue3.TabIndex = 10;
            numValue3.TextAlign = HorizontalAlignment.Center;
            // 
            // numValue2
            // 
            numValue2.DecimalPlaces = 2;
            numValue2.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numValue2.Location = new Point(297, 21);
            numValue2.Maximum = new decimal(new int[] { 1410065407, 2, 0, 0 });
            numValue2.Name = "numValue2";
            numValue2.Size = new Size(145, 37);
            numValue2.TabIndex = 9;
            numValue2.TextAlign = HorizontalAlignment.Center;
            // 
            // numValue1
            // 
            numValue1.DecimalPlaces = 2;
            numValue1.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numValue1.Location = new Point(114, 21);
            numValue1.Maximum = new decimal(new int[] { 1410065407, 2, 0, 0 });
            numValue1.Name = "numValue1";
            numValue1.Size = new Size(145, 37);
            numValue1.TabIndex = 8;
            numValue1.TextAlign = HorizontalAlignment.Center;
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
            btnSave.Location = new Point(1431, 40);
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
            btnRun.Location = new Point(1293, 40);
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
            label2.Location = new Point(820, 56);
            label2.Name = "label2";
            label2.Size = new Size(84, 30);
            label2.TabIndex = 3;
            label2.Text = "User ID";
            // 
            // txtUserID
            // 
            txtUserID.Location = new Point(945, 49);
            txtUserID.Name = "txtUserID";
            txtUserID.Size = new Size(306, 37);
            txtUserID.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(363, 56);
            label1.Name = "label1";
            label1.Size = new Size(122, 30);
            label1.TabIndex = 1;
            label1.Text = "Machine ID";
            // 
            // txtMachineID
            // 
            txtMachineID.Location = new Point(488, 49);
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
            // pnPeko
            // 
            pnPeko.Controls.Add(numValue2);
            pnPeko.Controls.Add(label4);
            pnPeko.Controls.Add(numValue1);
            pnPeko.Controls.Add(label3);
            pnPeko.Controls.Add(numValue3);
            pnPeko.Location = new Point(689, 101);
            pnPeko.Name = "pnPeko";
            pnPeko.Size = new Size(676, 88);
            pnPeko.TabIndex = 13;
            pnPeko.Visible = false;
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
            ((System.ComponentModel.ISupportInitialize)numValue3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numValue2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numValue1).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvChecklist).EndInit();
            pnPeko.ResumeLayout(false);
            pnPeko.PerformLayout();
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
        private TextBox textBox1;
        private DataGridViewTextBoxColumn ItemId;
        private DataGridViewTextBoxColumn PartName;
        private DataGridViewTextBoxColumn ItemName;
        private DataGridViewTextBoxColumn Standard;
        private DataGridViewTextBoxColumn Method;
        private DataGridViewTextBoxColumn ng_solution;
        private DataGridViewCheckBoxColumn OK;
        private DataGridViewCheckBoxColumn Clean;
        private DataGridViewCheckBoxColumn Replace;
        private Label label4;
        private Label label3;
        private NumericUpDown numValue3;
        private NumericUpDown numValue2;
        private NumericUpDown numValue1;
        private Panel pnPeko;
    }
}