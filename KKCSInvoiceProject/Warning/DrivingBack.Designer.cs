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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DrivingBack));
            this.lbl_drivingback = new System.Windows.Forms.Label();
            this.btn_printdrivingback = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_drivingback
            // 
            this.lbl_drivingback.AutoSize = true;
            this.lbl_drivingback.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_drivingback.Location = new System.Drawing.Point(12, 9);
            this.lbl_drivingback.Name = "lbl_drivingback";
            this.lbl_drivingback.Size = new System.Drawing.Size(699, 420);
            this.lbl_drivingback.TabIndex = 0;
            this.lbl_drivingback.Text = resources.GetString("lbl_drivingback.Text");
            // 
            // btn_printdrivingback
            // 
            this.btn_printdrivingback.BackColor = System.Drawing.Color.Black;
            this.btn_printdrivingback.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_printdrivingback.ForeColor = System.Drawing.Color.White;
            this.btn_printdrivingback.Location = new System.Drawing.Point(752, 74);
            this.btn_printdrivingback.Name = "btn_printdrivingback";
            this.btn_printdrivingback.Size = new System.Drawing.Size(242, 121);
            this.btn_printdrivingback.TabIndex = 1;
            this.btn_printdrivingback.Text = "Print Copy For Customer";
            this.btn_printdrivingback.UseVisualStyleBackColor = false;
            this.btn_printdrivingback.Click += new System.EventHandler(this.btn_printdrivingback_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(748, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 40);
            this.label1.TabIndex = 40;
            this.label1.Text = "If the customer would like a copy\r\nof this procedure, click on this button:";
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.Red;
            this.btn_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_close.Location = new System.Drawing.Point(752, 215);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(131, 66);
            this.btn_close.TabIndex = 41;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // DrivingBack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(1075, 482);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_printdrivingback);
            this.Controls.Add(this.lbl_drivingback);
            this.Name = "DrivingBack";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DrivingBack";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_drivingback;
        private System.Windows.Forms.Button btn_printdrivingback;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_close;
    }
}