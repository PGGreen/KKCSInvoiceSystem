namespace KKCSInvoiceProject
{
    partial class Administrator
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
            this.btn_alerts = new System.Windows.Forms.Button();
            this.btn_flighttimes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_alerts
            // 
            this.btn_alerts.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_alerts.Location = new System.Drawing.Point(12, 12);
            this.btn_alerts.Name = "btn_alerts";
            this.btn_alerts.Size = new System.Drawing.Size(165, 55);
            this.btn_alerts.TabIndex = 0;
            this.btn_alerts.Text = "Alert Settings";
            this.btn_alerts.UseVisualStyleBackColor = true;
            this.btn_alerts.Click += new System.EventHandler(this.btn_alerts_Click);
            // 
            // btn_flighttimes
            // 
            this.btn_flighttimes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_flighttimes.Location = new System.Drawing.Point(12, 86);
            this.btn_flighttimes.Name = "btn_flighttimes";
            this.btn_flighttimes.Size = new System.Drawing.Size(165, 55);
            this.btn_flighttimes.TabIndex = 1;
            this.btn_flighttimes.Text = "Flight Times";
            this.btn_flighttimes.UseVisualStyleBackColor = true;
            this.btn_flighttimes.Click += new System.EventHandler(this.btn_flighttimes_Click);
            // 
            // Administrator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 768);
            this.Controls.Add(this.btn_flighttimes);
            this.Controls.Add(this.btn_alerts);
            this.Name = "Administrator";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_alerts;
        private System.Windows.Forms.Button btn_flighttimes;
    }
}