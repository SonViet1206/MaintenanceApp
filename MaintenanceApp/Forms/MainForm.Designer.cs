namespace MaintenanceApp.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            btnRun = new Button();
            btnSetup = new Button();
            btnHistory = new Button();
            SuspendLayout();
            // 
            // btnRun
            // 
            btnRun.Font = new Font("Segoe UI", 20F);
            btnRun.Location = new Point(41, 82);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(226, 194);
            btnRun.TabIndex = 0;
            btnRun.Text = "Run";
            btnRun.UseVisualStyleBackColor = true;
            btnRun.Click += btnRun_Click;
            // 
            // btnSetup
            // 
            btnSetup.Font = new Font("Segoe UI", 20F);
            btnSetup.Location = new Point(312, 82);
            btnSetup.Name = "btnSetup";
            btnSetup.Size = new Size(226, 194);
            btnSetup.TabIndex = 1;
            btnSetup.Text = "SETUP";
            btnSetup.UseVisualStyleBackColor = true;
            btnSetup.Click += btnSetup_Click;
            // 
            // btnHistory
            // 
            btnHistory.Font = new Font("Segoe UI", 20F);
            btnHistory.Location = new Point(598, 82);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(226, 194);
            btnHistory.TabIndex = 2;
            btnHistory.Text = "HISTORY";
            btnHistory.UseVisualStyleBackColor = true;
            btnHistory.Click += btnHistory_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(868, 388);
            Controls.Add(btnHistory);
            Controls.Add(btnSetup);
            Controls.Add(btnRun);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Phần mềm bảo dưỡng máy ";
            ResumeLayout(false);
        }

        #endregion

        private Button btnRun;
        private Button btnSetup;
        private Button btnHistory;
    }
}