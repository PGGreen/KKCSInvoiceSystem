namespace KKCSInvoiceProject
{
    partial class EndOfDayManager
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
            this.txt_returns = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_returns
            // 
            this.txt_returns.Location = new System.Drawing.Point(64, 12);
            this.txt_returns.Multiline = true;
            this.txt_returns.Name = "txt_returns";
            this.txt_returns.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_returns.Size = new System.Drawing.Size(816, 556);
            this.txt_returns.TabIndex = 0;
            // 
            // EndOfDayManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 621);
            this.Controls.Add(this.txt_returns);
            this.Name = "EndOfDayManager";
            this.Text = "EndOfDayManager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_returns;
    }
}