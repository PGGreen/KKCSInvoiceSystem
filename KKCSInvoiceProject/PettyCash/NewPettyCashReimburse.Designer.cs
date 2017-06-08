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
            this.txt_pettyadding = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_returndate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_carreturns = new System.Windows.Forms.Label();
            this.txt_currentpetty = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_newpettycash = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 300);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 25);
            this.label3.TabIndex = 108;
            this.label3.Text = "Notes:";
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.Red;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.btn_save.Location = new System.Drawing.Point(436, 410);
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
            this.txt_notes.Location = new System.Drawing.Point(27, 328);
            this.txt_notes.Multiline = true;
            this.txt_notes.Name = "txt_notes";
            this.txt_notes.Size = new System.Drawing.Size(361, 225);
            this.txt_notes.TabIndex = 104;
            // 
            // txt_pettyadding
            // 
            this.txt_pettyadding.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_pettyadding.Location = new System.Drawing.Point(488, 185);
            this.txt_pettyadding.Name = "txt_pettyadding";
            this.txt_pettyadding.Size = new System.Drawing.Size(121, 31);
            this.txt_pettyadding.TabIndex = 123;
            this.txt_pettyadding.Text = "200.00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(462, 25);
            this.label2.TabIndex = 121;
            this.label2.Text = "Amount You Are Reimbursing to the Box: $";
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
            this.txt_currentpetty.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_currentpetty.Location = new System.Drawing.Point(488, 122);
            this.txt_currentpetty.Name = "txt_currentpetty";
            this.txt_currentpetty.ReadOnly = true;
            this.txt_currentpetty.Size = new System.Drawing.Size(121, 31);
            this.txt_currentpetty.TabIndex = 124;
            this.txt_currentpetty.Text = "5.20";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(48, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(438, 25);
            this.label4.TabIndex = 125;
            this.label4.Text = "Current Amount in the Petty Cash Box: $";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(121, 249);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(365, 25);
            this.label1.TabIndex = 126;
            this.label1.Text = "New Amount in Petty Cash Box: $";
            // 
            // txt_newpettycash
            // 
            this.txt_newpettycash.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_newpettycash.Location = new System.Drawing.Point(488, 246);
            this.txt_newpettycash.Name = "txt_newpettycash";
            this.txt_newpettycash.Size = new System.Drawing.Size(121, 31);
            this.txt_newpettycash.TabIndex = 127;
            // 
            // PettyCashReimburse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(664, 565);
            this.Controls.Add(this.txt_newpettycash);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_currentpetty);
            this.Controls.Add(this.txt_pettyadding);
            this.Controls.Add(this.label2);
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
        private System.Windows.Forms.TextBox txt_pettyadding;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker txt_returndate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_carreturns;
        private System.Windows.Forms.TextBox txt_currentpetty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_newpettycash;
    }
}