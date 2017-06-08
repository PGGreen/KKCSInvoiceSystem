namespace KKCSInvoiceProject
{
    partial class PettyCash
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
            this.txt_returndate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_notes = new System.Windows.Forms.TextBox();
            this.lbl_carreturns = new System.Windows.Forms.Label();
            this.txt_item = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_reciept = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_minusamount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_currentpetty = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_pettycashremaning = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_itemamount = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 458);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 25);
            this.label3.TabIndex = 92;
            this.label3.Text = "Notes:";
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.Location = new System.Drawing.Point(431, 550);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(156, 77);
            this.btn_save.TabIndex = 89;
            this.btn_save.Text = "Unsaved";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // txt_returndate
            // 
            this.txt_returndate.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.5F, System.Drawing.FontStyle.Bold);
            this.txt_returndate.Location = new System.Drawing.Point(136, 64);
            this.txt_returndate.Name = "txt_returndate";
            this.txt_returndate.Size = new System.Drawing.Size(425, 35);
            this.txt_returndate.TabIndex = 88;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.75F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Green;
            this.label6.Location = new System.Drawing.Point(52, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 29);
            this.label6.TabIndex = 87;
            this.label6.Text = "Date:";
            // 
            // txt_notes
            // 
            this.txt_notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txt_notes.Location = new System.Drawing.Point(35, 486);
            this.txt_notes.Multiline = true;
            this.txt_notes.Name = "txt_notes";
            this.txt_notes.Size = new System.Drawing.Size(361, 225);
            this.txt_notes.TabIndex = 86;
            // 
            // lbl_carreturns
            // 
            this.lbl_carreturns.AutoSize = true;
            this.lbl_carreturns.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_carreturns.Location = new System.Drawing.Point(268, 15);
            this.lbl_carreturns.Name = "lbl_carreturns";
            this.lbl_carreturns.Size = new System.Drawing.Size(158, 31);
            this.lbl_carreturns.TabIndex = 83;
            this.lbl_carreturns.Text = "Petty Cash";
            // 
            // txt_item
            // 
            this.txt_item.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_item.Location = new System.Drawing.Point(136, 142);
            this.txt_item.Name = "txt_item";
            this.txt_item.Size = new System.Drawing.Size(271, 31);
            this.txt_item.TabIndex = 98;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(68, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 25);
            this.label4.TabIndex = 99;
            this.label4.Text = "Item:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 400);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 25);
            this.label5.TabIndex = 100;
            this.label5.Text = "Receipt:";
            // 
            // cmb_reciept
            // 
            this.cmb_reciept.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmb_reciept.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_reciept.BackColor = System.Drawing.SystemColors.Window;
            this.cmb_reciept.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmb_reciept.DropDownWidth = 121;
            this.cmb_reciept.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_reciept.FormattingEnabled = true;
            this.cmb_reciept.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.cmb_reciept.Location = new System.Drawing.Point(140, 397);
            this.cmb_reciept.Name = "cmb_reciept";
            this.cmb_reciept.Size = new System.Drawing.Size(68, 33);
            this.cmb_reciept.TabIndex = 101;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(188, 295);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 25);
            this.label2.TabIndex = 102;
            this.label2.Text = "Minus Item Amount:";
            // 
            // txt_minusamount
            // 
            this.txt_minusamount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_minusamount.Location = new System.Drawing.Point(454, 292);
            this.txt_minusamount.Name = "txt_minusamount";
            this.txt_minusamount.Size = new System.Drawing.Size(121, 31);
            this.txt_minusamount.TabIndex = 104;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(410, 295);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 25);
            this.label7.TabIndex = 103;
            this.label7.Text = "$ -";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(192, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 25);
            this.label1.TabIndex = 105;
            this.label1.Text = "Current Petty Cash:";
            // 
            // txt_currentpetty
            // 
            this.txt_currentpetty.BackColor = System.Drawing.SystemColors.Window;
            this.txt_currentpetty.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_currentpetty.Location = new System.Drawing.Point(454, 244);
            this.txt_currentpetty.Name = "txt_currentpetty";
            this.txt_currentpetty.Size = new System.Drawing.Size(121, 31);
            this.txt_currentpetty.TabIndex = 106;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(410, 247);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 25);
            this.label8.TabIndex = 107;
            this.label8.Text = "$";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(159, 342);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(252, 25);
            this.label9.TabIndex = 108;
            this.label9.Text = "Petty Cash Remaining:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(410, 342);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 25);
            this.label10.TabIndex = 109;
            this.label10.Text = "$";
            // 
            // txt_pettycashremaning
            // 
            this.txt_pettycashremaning.BackColor = System.Drawing.Color.Lime;
            this.txt_pettycashremaning.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_pettycashremaning.Location = new System.Drawing.Point(454, 339);
            this.txt_pettycashremaning.Name = "txt_pettycashremaning";
            this.txt_pettycashremaning.Size = new System.Drawing.Size(121, 31);
            this.txt_pettycashremaning.TabIndex = 110;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(68, 188);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(145, 25);
            this.label11.TabIndex = 111;
            this.label11.Text = "Cost of Item:";
            // 
            // txt_itemamount
            // 
            this.txt_itemamount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_itemamount.Location = new System.Drawing.Point(237, 186);
            this.txt_itemamount.Name = "txt_itemamount";
            this.txt_itemamount.Size = new System.Drawing.Size(121, 31);
            this.txt_itemamount.TabIndex = 112;
            this.txt_itemamount.TextChanged += new System.EventHandler(this.txt_itemamount_TextChanged_1);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(208, 189);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(25, 25);
            this.label12.TabIndex = 113;
            this.label12.Text = "$";
            // 
            // PettyCash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(617, 723);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txt_itemamount);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt_pettycashremaning);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_currentpetty);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_minusamount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_reciept);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_item);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.txt_returndate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_notes);
            this.Controls.Add(this.lbl_carreturns);
            this.Name = "PettyCash";
            this.Text = "PettyCash";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.DateTimePicker txt_returndate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_notes;
        private System.Windows.Forms.Label lbl_carreturns;
        private System.Windows.Forms.TextBox txt_item;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_reciept;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_minusamount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_currentpetty;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_pettycashremaning;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_itemamount;
        private System.Windows.Forms.Label label12;
    }
}