namespace KKCSInvoiceProject
{
    partial class ShowNotesAlerts
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
            this.lbl_notes = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_alerts = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lbl_sep = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightCyan;
            this.panel1.Controls.Add(this.lbl_notes);
            this.panel1.Location = new System.Drawing.Point(54, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(462, 607);
            this.panel1.TabIndex = 0;
            // 
            // lbl_notes
            // 
            this.lbl_notes.AutoSize = true;
            this.lbl_notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_notes.Location = new System.Drawing.Point(19, 15);
            this.lbl_notes.MaximumSize = new System.Drawing.Size(400, 0);
            this.lbl_notes.Name = "lbl_notes";
            this.lbl_notes.Size = new System.Drawing.Size(399, 20);
            this.lbl_notes.TabIndex = 0;
            this.lbl_notes.Text = "000000000000000000000000000000000000000";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.lbl_alerts);
            this.panel2.Location = new System.Drawing.Point(594, 83);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(462, 607);
            this.panel2.TabIndex = 1;
            // 
            // lbl_alerts
            // 
            this.lbl_alerts.AutoSize = true;
            this.lbl_alerts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_alerts.Location = new System.Drawing.Point(16, 15);
            this.lbl_alerts.MaximumSize = new System.Drawing.Size(400, 0);
            this.lbl_alerts.Name = "lbl_alerts";
            this.lbl_alerts.Size = new System.Drawing.Size(399, 20);
            this.lbl_alerts.TabIndex = 1;
            this.lbl_alerts.Text = "000000000000000000000000000000000000000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(220, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Notes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(777, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "Alerts";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(493, 705);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 42);
            this.button1.TabIndex = 4;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_sep
            // 
            this.lbl_sep.AutoSize = true;
            this.lbl_sep.Location = new System.Drawing.Point(432, 13);
            this.lbl_sep.Name = "lbl_sep";
            this.lbl_sep.Size = new System.Drawing.Size(35, 13);
            this.lbl_sep.TabIndex = 5;
            this.lbl_sep.Text = "label3";
            // 
            // ShowNotesAlerts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 759);
            this.Controls.Add(this.lbl_sep);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ShowNotesAlerts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShowNotesAlerts";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_notes;
        private System.Windows.Forms.Label lbl_alerts;
        private System.Windows.Forms.Label lbl_sep;
    }
}