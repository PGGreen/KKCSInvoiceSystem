namespace KKCSInvoiceProject
{
    partial class Banking
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
            this.cmb_from = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_returndate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_notes = new System.Windows.Forms.TextBox();
            this.txt_amount = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lbl_carreturns = new System.Windows.Forms.Label();
            this.lbl_inplasticbox = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmb_from
            // 
            this.cmb_from.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmb_from.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_from.BackColor = System.Drawing.SystemColors.Window;
            this.cmb_from.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmb_from.DropDownWidth = 121;
            this.cmb_from.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_from.FormattingEnabled = true;
            this.cmb_from.Items.AddRange(new object[] {
            "Plastic Box"});
            this.cmb_from.Location = new System.Drawing.Point(457, 185);
            this.cmb_from.Name = "cmb_from";
            this.cmb_from.Size = new System.Drawing.Size(152, 33);
            this.cmb_from.TabIndex = 95;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 254);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 25);
            this.label3.TabIndex = 92;
            this.label3.Text = "Notes:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 25);
            this.label1.TabIndex = 91;
            this.label1.Text = "Amount Banking: $";
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
            this.txt_notes.Location = new System.Drawing.Point(36, 282);
            this.txt_notes.Multiline = true;
            this.txt_notes.Name = "txt_notes";
            this.txt_notes.Size = new System.Drawing.Size(361, 225);
            this.txt_notes.TabIndex = 86;
            // 
            // txt_amount
            // 
            this.txt_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_amount.Location = new System.Drawing.Point(246, 186);
            this.txt_amount.Name = "txt_amount";
            this.txt_amount.Size = new System.Drawing.Size(121, 31);
            this.txt_amount.TabIndex = 85;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(135, 189);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 25);
            this.label11.TabIndex = 84;
            this.label11.Text = "$ -";
            // 
            // lbl_carreturns
            // 
            this.lbl_carreturns.AutoSize = true;
            this.lbl_carreturns.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_carreturns.Location = new System.Drawing.Point(289, 14);
            this.lbl_carreturns.Name = "lbl_carreturns";
            this.lbl_carreturns.Size = new System.Drawing.Size(119, 31);
            this.lbl_carreturns.TabIndex = 83;
            this.lbl_carreturns.Text = "Banking";
            // 
            // lbl_inplasticbox
            // 
            this.lbl_inplasticbox.AutoSize = true;
            this.lbl_inplasticbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_inplasticbox.Location = new System.Drawing.Point(34, 126);
            this.lbl_inplasticbox.Name = "lbl_inplasticbox";
            this.lbl_inplasticbox.Size = new System.Drawing.Size(249, 25);
            this.lbl_inplasticbox.TabIndex = 96;
            this.lbl_inplasticbox.Text = "Amount In Plastic Box:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(383, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 25);
            this.label4.TabIndex = 97;
            this.label4.Text = "From";
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.OrangeRed;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.ForeColor = System.Drawing.Color.Black;
            this.btn_save.Location = new System.Drawing.Point(457, 362);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(209, 80);
            this.btn_save.TabIndex = 98;
            this.btn_save.Text = "UNSAVED";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.button1_Click);
            // 
            // Banking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(743, 538);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_inplasticbox);
            this.Controls.Add(this.cmb_from);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_returndate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_notes);
            this.Controls.Add(this.txt_amount);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lbl_carreturns);
            this.Name = "Banking";
            this.Text = "Banking";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmb_from;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txt_returndate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_notes;
        private System.Windows.Forms.TextBox txt_amount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbl_carreturns;
        private System.Windows.Forms.Label lbl_inplasticbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_save;
    }
}