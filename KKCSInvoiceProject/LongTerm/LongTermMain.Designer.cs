namespace KKCSInvoiceProject
{
    partial class LongTermMain
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
            this.lbl_longterm = new System.Windows.Forms.Label();
            this.lbl_template = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_longterm
            // 
            this.lbl_longterm.AutoSize = true;
            this.lbl_longterm.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_longterm.Location = new System.Drawing.Point(12, 9);
            this.lbl_longterm.Name = "lbl_longterm";
            this.lbl_longterm.Size = new System.Drawing.Size(124, 25);
            this.lbl_longterm.TabIndex = 1;
            this.lbl_longterm.Text = "Long Term";
            // 
            // lbl_template
            // 
            this.lbl_template.AutoSize = true;
            this.lbl_template.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_template.Location = new System.Drawing.Point(14, 39);
            this.lbl_template.Name = "lbl_template";
            this.lbl_template.Size = new System.Drawing.Size(58, 29);
            this.lbl_template.TabIndex = 5;
            this.lbl_template.Text = "LT1";
            this.lbl_template.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(482, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 29);
            this.label1.TabIndex = 6;
            this.label1.Text = "BLU804/HPE210";
            // 
            // LongTermMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1143, 802);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_template);
            this.Controls.Add(this.lbl_longterm);
            this.Name = "LongTermMain";
            this.Text = "LongTermMain";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_longterm;
        private System.Windows.Forms.Label lbl_template;
        private System.Windows.Forms.Label label1;
    }
}