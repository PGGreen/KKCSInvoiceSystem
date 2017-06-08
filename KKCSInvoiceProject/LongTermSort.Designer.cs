namespace KKCSInvoiceProject
{
    partial class LongTermSort
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
            this.pnl_template = new System.Windows.Forms.Panel();
            this.lbl_dateout = new System.Windows.Forms.Label();
            this.lbl_datein = new System.Windows.Forms.Label();
            this.lbl_numberplate = new System.Windows.Forms.Label();
            this.txt_DateIn = new System.Windows.Forms.TextBox();
            this.lbl_keynumber = new System.Windows.Forms.Label();
            this.pnl_template.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_template
            // 
            this.pnl_template.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pnl_template.Controls.Add(this.lbl_keynumber);
            this.pnl_template.Controls.Add(this.lbl_dateout);
            this.pnl_template.Controls.Add(this.lbl_datein);
            this.pnl_template.Controls.Add(this.lbl_numberplate);
            this.pnl_template.Location = new System.Drawing.Point(12, 24);
            this.pnl_template.Name = "pnl_template";
            this.pnl_template.Size = new System.Drawing.Size(1140, 45);
            this.pnl_template.TabIndex = 1;
            this.pnl_template.Visible = false;
            // 
            // lbl_dateout
            // 
            this.lbl_dateout.AutoSize = true;
            this.lbl_dateout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dateout.Location = new System.Drawing.Point(740, 12);
            this.lbl_dateout.Name = "lbl_dateout";
            this.lbl_dateout.Size = new System.Drawing.Size(219, 20);
            this.lbl_dateout.TabIndex = 3;
            this.lbl_dateout.Text = "000000000000000000000";
            // 
            // lbl_datein
            // 
            this.lbl_datein.AutoSize = true;
            this.lbl_datein.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_datein.Location = new System.Drawing.Point(486, 12);
            this.lbl_datein.Name = "lbl_datein";
            this.lbl_datein.Size = new System.Drawing.Size(219, 20);
            this.lbl_datein.TabIndex = 2;
            this.lbl_datein.Text = "000000000000000000000";
            // 
            // lbl_numberplate
            // 
            this.lbl_numberplate.AutoSize = true;
            this.lbl_numberplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_numberplate.Location = new System.Drawing.Point(245, 12);
            this.lbl_numberplate.Name = "lbl_numberplate";
            this.lbl_numberplate.Size = new System.Drawing.Size(219, 20);
            this.lbl_numberplate.TabIndex = 1;
            this.lbl_numberplate.Text = "000000000000000000000";
            // 
            // txt_DateIn
            // 
            this.txt_DateIn.Location = new System.Drawing.Point(1180, 489);
            this.txt_DateIn.Multiline = true;
            this.txt_DateIn.Name = "txt_DateIn";
            this.txt_DateIn.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_DateIn.Size = new System.Drawing.Size(67, 44);
            this.txt_DateIn.TabIndex = 2;
            // 
            // lbl_keynumber
            // 
            this.lbl_keynumber.AutoSize = true;
            this.lbl_keynumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_keynumber.Location = new System.Drawing.Point(20, 12);
            this.lbl_keynumber.Name = "lbl_keynumber";
            this.lbl_keynumber.Size = new System.Drawing.Size(219, 20);
            this.lbl_keynumber.TabIndex = 4;
            this.lbl_keynumber.Text = "000000000000000000000";
            // 
            // LongTermSort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1315, 602);
            this.Controls.Add(this.txt_DateIn);
            this.Controls.Add(this.pnl_template);
            this.Name = "LongTermSort";
            this.Text = "LongTermSort";
            this.pnl_template.ResumeLayout(false);
            this.pnl_template.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnl_template;
        private System.Windows.Forms.Label lbl_dateout;
        private System.Windows.Forms.Label lbl_datein;
        private System.Windows.Forms.Label lbl_numberplate;
        private System.Windows.Forms.TextBox txt_DateIn;
        private System.Windows.Forms.Label lbl_keynumber;
    }
}