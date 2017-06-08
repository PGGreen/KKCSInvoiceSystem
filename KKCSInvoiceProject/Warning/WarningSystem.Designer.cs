namespace KKCSInvoiceProject
{
    partial class WarningSystem
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
            this.lbl_warning = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_one = new System.Windows.Forms.Button();
            this.btn_two = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_warning
            // 
            this.lbl_warning.AutoSize = true;
            this.lbl_warning.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_warning.ForeColor = System.Drawing.Color.Black;
            this.lbl_warning.Location = new System.Drawing.Point(12, 50);
            this.lbl_warning.Name = "lbl_warning";
            this.lbl_warning.Size = new System.Drawing.Size(235, 29);
            this.lbl_warning.TabIndex = 3;
            this.lbl_warning.Text = "Your Warning Here";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "WARNING!";
            // 
            // btn_one
            // 
            this.btn_one.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_one.Location = new System.Drawing.Point(12, 225);
            this.btn_one.Name = "btn_one";
            this.btn_one.Size = new System.Drawing.Size(85, 41);
            this.btn_one.TabIndex = 5;
            this.btn_one.Text = "OK";
            this.btn_one.UseVisualStyleBackColor = true;
            this.btn_one.Visible = false;
            // 
            // btn_two
            // 
            this.btn_two.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_two.Location = new System.Drawing.Point(317, 225);
            this.btn_two.Name = "btn_two";
            this.btn_two.Size = new System.Drawing.Size(85, 41);
            this.btn_two.TabIndex = 6;
            this.btn_two.Text = "OK";
            this.btn_two.UseVisualStyleBackColor = true;
            this.btn_two.Click += new System.EventHandler(this.btn_two_Click);
            // 
            // WarningSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(414, 278);
            this.Controls.Add(this.btn_two);
            this.Controls.Add(this.btn_one);
            this.Controls.Add(this.lbl_warning);
            this.Controls.Add(this.label1);
            this.Name = "WarningSystem";
            this.Text = "WarningSystem";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_warning;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_one;
        private System.Windows.Forms.Button btn_two;
    }
}