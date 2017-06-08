namespace KKCSInvoiceProject
{
    partial class DrivingBack
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
            this.lbl_drivingback = new System.Windows.Forms.Label();
            this.btn_printdrivingback = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_drivingback
            // 
            this.lbl_drivingback.AutoSize = true;
            this.lbl_drivingback.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_drivingback.Location = new System.Drawing.Point(12, 18);
            this.lbl_drivingback.Name = "lbl_drivingback";
            this.lbl_drivingback.Size = new System.Drawing.Size(127, 20);
            this.lbl_drivingback.TabIndex = 0;
            this.lbl_drivingback.Text = "lbl_drivingback";
            // 
            // btn_printdrivingback
            // 
            this.btn_printdrivingback.BackColor = System.Drawing.Color.Black;
            this.btn_printdrivingback.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_printdrivingback.ForeColor = System.Drawing.Color.White;
            this.btn_printdrivingback.Location = new System.Drawing.Point(1040, 136);
            this.btn_printdrivingback.Name = "btn_printdrivingback";
            this.btn_printdrivingback.Size = new System.Drawing.Size(219, 101);
            this.btn_printdrivingback.TabIndex = 1;
            this.btn_printdrivingback.Text = "Print Out Driving Back Info Sheet For Customer";
            this.btn_printdrivingback.UseVisualStyleBackColor = false;
            this.btn_printdrivingback.Click += new System.EventHandler(this.btn_printdrivingback_Click);
            // 
            // DrivingBack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1271, 743);
            this.Controls.Add(this.btn_printdrivingback);
            this.Controls.Add(this.lbl_drivingback);
            this.Name = "DrivingBack";
            this.Text = "DrivingBack";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_drivingback;
        private System.Windows.Forms.Button btn_printdrivingback;
    }
}