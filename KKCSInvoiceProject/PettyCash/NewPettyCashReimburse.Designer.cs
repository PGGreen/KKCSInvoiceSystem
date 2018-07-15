namespace KKCSInvoiceProject
{
    partial class PettyCashReimburse
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
            this.label3 = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.txt_notes = new System.Windows.Forms.TextBox();
            this.lbl_amounttoadd = new System.Windows.Forms.Label();
            this.txt_returndate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_carreturns = new System.Windows.Forms.Label();
            this.txt_currentpetty = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_worker = new System.Windows.Forms.ComboBox();
            this.txt_pccurrent = new System.Windows.Forms.TextBox();
            this.txt_totalnew = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 287);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 25);
            this.label3.TabIndex = 108;
            this.label3.Text = "Notes:";
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.Red;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.btn_save.Location = new System.Drawing.Point(426, 424);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(184, 77);
            this.btn_save.TabIndex = 105;
            this.btn_save.Text = "Unsaved";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click_1);
            // 
            // txt_notes
            // 
            this.txt_notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txt_notes.Location = new System.Drawing.Point(24, 333);
            this.txt_notes.Multiline = true;
            this.txt_notes.Name = "txt_notes";
            this.txt_notes.Size = new System.Drawing.Size(361, 225);
            this.txt_notes.TabIndex = 104;
            // 
            // lbl_amounttoadd
            // 
            this.lbl_amounttoadd.AutoSize = true;
            this.lbl_amounttoadd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_amounttoadd.Location = new System.Drawing.Point(36, 186);
            this.lbl_amounttoadd.Name = "lbl_amounttoadd";
            this.lbl_amounttoadd.Size = new System.Drawing.Size(464, 25);
            this.lbl_amounttoadd.TabIndex = 121;
            this.lbl_amounttoadd.Text = "Amount You Need to add to Petty Cash: $+";
            // 
            // txt_returndate
            // 
            this.txt_returndate.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.5F, System.Drawing.FontStyle.Bold);
            this.txt_returndate.Location = new System.Drawing.Point(165, 62);
            this.txt_returndate.Name = "txt_returndate";
            this.txt_returndate.Size = new System.Drawing.Size(425, 35);
            this.txt_returndate.TabIndex = 118;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.75F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Green;
            this.label6.Location = new System.Drawing.Point(81, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 29);
            this.label6.TabIndex = 117;
            this.label6.Text = "Date:";
            // 
            // lbl_carreturns
            // 
            this.lbl_carreturns.AutoSize = true;
            this.lbl_carreturns.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_carreturns.Location = new System.Drawing.Point(198, 9);
            this.lbl_carreturns.Name = "lbl_carreturns";
            this.lbl_carreturns.Size = new System.Drawing.Size(306, 31);
            this.lbl_carreturns.TabIndex = 116;
            this.lbl_carreturns.Text = "Petty Cash Reimburse";
            // 
            // txt_currentpetty
            // 
            this.txt_currentpetty.BackColor = System.Drawing.Color.Yellow;
            this.txt_currentpetty.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_currentpetty.Location = new System.Drawing.Point(497, 179);
            this.txt_currentpetty.Name = "txt_currentpetty";
            this.txt_currentpetty.ReadOnly = true;
            this.txt_currentpetty.Size = new System.Drawing.Size(121, 38);
            this.txt_currentpetty.TabIndex = 124;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(48, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(239, 25);
            this.label4.TabIndex = 125;
            this.label4.Text = "Current Petty Cash: $";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(90, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 25);
            this.label1.TabIndex = 126;
            this.label1.Text = "New Amount in Petty Cash: $";
            // 
            // cmb_worker
            // 
            this.cmb_worker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.cmb_worker.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_worker.FormattingEnabled = true;
            this.cmb_worker.Location = new System.Drawing.Point(426, 381);
            this.cmb_worker.Name = "cmb_worker";
            this.cmb_worker.Size = new System.Drawing.Size(184, 37);
            this.cmb_worker.TabIndex = 187;
            // 
            // txt_pccurrent
            // 
            this.txt_pccurrent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txt_pccurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_pccurrent.Location = new System.Drawing.Point(290, 126);
            this.txt_pccurrent.Name = "txt_pccurrent";
            this.txt_pccurrent.Size = new System.Drawing.Size(121, 31);
            this.txt_pccurrent.TabIndex = 193;
            this.txt_pccurrent.Text = "200.00";
            // 
            // txt_totalnew
            // 
            this.txt_totalnew.BackColor = System.Drawing.Color.Lime;
            this.txt_totalnew.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_totalnew.Location = new System.Drawing.Point(410, 234);
            this.txt_totalnew.Name = "txt_totalnew";
            this.txt_totalnew.ReadOnly = true;
            this.txt_totalnew.Size = new System.Drawing.Size(121, 38);
            this.txt_totalnew.TabIndex = 196;
            // 
            // PettyCashReimburse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(656, 573);
            this.Controls.Add(this.txt_totalnew);
            this.Controls.Add(this.txt_pccurrent);
            this.Controls.Add(this.cmb_worker);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_currentpetty);
            this.Controls.Add(this.lbl_amounttoadd);
            this.Controls.Add(this.txt_returndate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbl_carreturns);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.txt_notes);
            this.Name = "PettyCashReimburse";
            this.Text = "PettyCashReimburse";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.TextBox txt_notes;
        private System.Windows.Forms.Label lbl_amounttoadd;
        private System.Windows.Forms.DateTimePicker txt_returndate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_carreturns;
        private System.Windows.Forms.TextBox txt_currentpetty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_worker;
        private System.Windows.Forms.TextBox txt_pccurrent;
        private System.Windows.Forms.TextBox txt_totalnew;
    }
}