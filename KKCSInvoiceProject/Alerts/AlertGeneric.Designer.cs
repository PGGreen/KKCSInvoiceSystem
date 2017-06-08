namespace KKCSInvoiceProject
{
    partial class AlertGeneric
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
            this.lbl_title = new System.Windows.Forms.Label();
            this.lbl_body = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.Location = new System.Drawing.Point(460, 9);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(88, 39);
            this.lbl_title.TabIndex = 0;
            this.lbl_title.Text = "Title";
            // 
            // lbl_body
            // 
            this.lbl_body.AutoSize = true;
            this.lbl_body.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_body.Location = new System.Drawing.Point(24, 79);
            this.lbl_body.Name = "lbl_body";
            this.lbl_body.Size = new System.Drawing.Size(80, 31);
            this.lbl_body.TabIndex = 1;
            this.lbl_body.Text = "Body";
            // 
            // AlertGeneric
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 846);
            this.Controls.Add(this.lbl_body);
            this.Controls.Add(this.lbl_title);
            this.Name = "AlertGeneric";
            this.Text = "AlertGeneric";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Label lbl_body;
    }
}