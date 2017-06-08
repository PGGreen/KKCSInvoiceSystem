namespace KKCSInvoiceProject
{
    partial class InvoiceManager
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
            this.lbl_template = new System.Windows.Forms.Label();
            this.btn_new = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_template
            // 
            this.lbl_template.AutoSize = true;
            this.lbl_template.BackColor = System.Drawing.Color.MistyRose;
            this.lbl_template.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_template.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_template.Location = new System.Drawing.Point(560, 590);
            this.lbl_template.Name = "lbl_template";
            this.lbl_template.Size = new System.Drawing.Size(91, 22);
            this.lbl_template.TabIndex = 1;
            this.lbl_template.Text = "1BADKAT";
            this.lbl_template.Visible = false;
            this.lbl_template.Click += new System.EventHandler(this.TabLabel_Click);
            // 
            // btn_new
            // 
            this.btn_new.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_new.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_new.Location = new System.Drawing.Point(12, 12);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(84, 22);
            this.btn_new.TabIndex = 3;
            this.btn_new.Text = "NEW";
            this.btn_new.UseVisualStyleBackColor = false;
            this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(102, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 22);
            this.button1.TabIndex = 5;
            this.button1.Text = "LONG TERM";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // InvoiceManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1482, 689);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_new);
            this.Controls.Add(this.lbl_template);
            this.IsMdiContainer = true;
            this.Name = "InvoiceManager";
            this.Text = "InvoiceManager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_template;
        private System.Windows.Forms.Button btn_new;
        private System.Windows.Forms.Button button1;
    }
}