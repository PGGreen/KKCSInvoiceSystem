namespace KKCSInvoiceProject
{
    partial class Testing
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
            this.lbl_testing = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_testing
            // 
            this.lbl_testing.AutoSize = true;
            this.lbl_testing.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_testing.Location = new System.Drawing.Point(23, 20);
            this.lbl_testing.Name = "lbl_testing";
            this.lbl_testing.Size = new System.Drawing.Size(203, 25);
            this.lbl_testing.TabIndex = 0;
            this.lbl_testing.Text = "Testing Placeholder";
            // 
            // Testing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(991, 440);
            this.Controls.Add(this.lbl_testing);
            this.Name = "Testing";
            this.Text = "Testing";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_testing;
    }
}