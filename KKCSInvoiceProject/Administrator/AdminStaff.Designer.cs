namespace KKCSInvoiceProject
{
    partial class AdminStaff
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
            this.txt_staff = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_saved = new System.Windows.Forms.Label();
            this.btn_update = new System.Windows.Forms.Button();
            this.lbl_changesmade = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_staff
            // 
            this.txt_staff.Location = new System.Drawing.Point(17, 51);
            this.txt_staff.Multiline = true;
            this.txt_staff.Name = "txt_staff";
            this.txt_staff.Size = new System.Drawing.Size(277, 227);
            this.txt_staff.TabIndex = 0;
            this.txt_staff.TextChanged += new System.EventHandler(this.txt_staff_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(486, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please only add 1 New Staff Member per line";
            // 
            // lbl_saved
            // 
            this.lbl_saved.AutoSize = true;
            this.lbl_saved.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lbl_saved.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_saved.ForeColor = System.Drawing.Color.Green;
            this.lbl_saved.Location = new System.Drawing.Point(237, 291);
            this.lbl_saved.Name = "lbl_saved";
            this.lbl_saved.Size = new System.Drawing.Size(131, 37);
            this.lbl_saved.TabIndex = 160;
            this.lbl_saved.Text = "SAVED";
            this.lbl_saved.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_saved.Visible = false;
            // 
            // btn_update
            // 
            this.btn_update.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_update.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_update.ForeColor = System.Drawing.Color.White;
            this.btn_update.Location = new System.Drawing.Point(25, 339);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(139, 63);
            this.btn_update.TabIndex = 159;
            this.btn_update.Text = "UPDATE CHANGES";
            this.btn_update.UseVisualStyleBackColor = false;
            this.btn_update.Visible = false;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // lbl_changesmade
            // 
            this.lbl_changesmade.AutoSize = true;
            this.lbl_changesmade.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_changesmade.ForeColor = System.Drawing.Color.Red;
            this.lbl_changesmade.Location = new System.Drawing.Point(180, 339);
            this.lbl_changesmade.Name = "lbl_changesmade";
            this.lbl_changesmade.Size = new System.Drawing.Size(245, 74);
            this.lbl_changesmade.TabIndex = 158;
            this.lbl_changesmade.Text = "WARNING!\r\nChanges Made";
            this.lbl_changesmade.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_changesmade.Visible = false;
            // 
            // AdminStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 434);
            this.Controls.Add(this.lbl_saved);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.lbl_changesmade);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_staff);
            this.Name = "AdminStaff";
            this.Text = "AdminStaff";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_staff;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_saved;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Label lbl_changesmade;
    }
}