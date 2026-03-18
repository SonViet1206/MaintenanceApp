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
            dgvList = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvList).BeginInit();
            SuspendLayout();
            // 
            // dgvList
            // 
            dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvList.Dock = DockStyle.Fill;
            dgvList.Location = new Point(0, 0);
            dgvList.Name = "dgvList";
            dgvList.RowHeadersWidth = 62;
            dgvList.Size = new Size(800, 450);
            dgvList.TabIndex = 0;
            // 
            // FrmTable
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvList);
            Name = "FrmTable";
            Text = "FrmTable";
            Load += FrmTable_Load;
            ((System.ComponentModel.ISupportInitialize)dgvList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvList;
    }
}