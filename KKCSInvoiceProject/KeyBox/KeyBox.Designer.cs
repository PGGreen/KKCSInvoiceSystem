namespace KKCSInvoiceProject
{
    partial class KeyBox
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
            this.btn_mainmenu = new System.Windows.Forms.Button();
            this.btn_invoice = new System.Windows.Forms.Button();
            this.btn_returns = new System.Windows.Forms.Button();
            this.cmb_regos = new System.Windows.Forms.ComboBox();
            this.btn_clear = new System.Windows.Forms.Button();
            this.label71 = new System.Windows.Forms.Label();
            this.lbl_datein = new System.Windows.Forms.Label();
            this.txt_nocars = new System.Windows.Forms.Label();
            this.btn_one = new System.Windows.Forms.Button();
            this.label72 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_mainmenu
            // 
            this.btn_mainmenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_mainmenu.Location = new System.Drawing.Point(1362, 9);
            this.btn_mainmenu.Name = "btn_mainmenu";
            this.btn_mainmenu.Size = new System.Drawing.Size(83, 25);
            this.btn_mainmenu.TabIndex = 219;
            this.btn_mainmenu.Text = "Main Menu";
            this.btn_mainmenu.UseVisualStyleBackColor = true;
            this.btn_mainmenu.Click += new System.EventHandler(this.btn_mainmenu_Click);
            // 
            // btn_invoice
            // 
            this.btn_invoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_invoice.Location = new System.Drawing.Point(1362, 38);
            this.btn_invoice.Name = "btn_invoice";
            this.btn_invoice.Size = new System.Drawing.Size(83, 26);
            this.btn_invoice.TabIndex = 220;
            this.btn_invoice.Text = "Invoice";
            this.btn_invoice.UseVisualStyleBackColor = true;
            this.btn_invoice.Click += new System.EventHandler(this.btn_invoice_Click);
            // 
            // btn_returns
            // 
            this.btn_returns.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_returns.Location = new System.Drawing.Point(1362, 69);
            this.btn_returns.Name = "btn_returns";
            this.btn_returns.Size = new System.Drawing.Size(83, 26);
            this.btn_returns.TabIndex = 221;
            this.btn_returns.Text = "Returns";
            this.btn_returns.UseVisualStyleBackColor = true;
            this.btn_returns.Click += new System.EventHandler(this.btn_returns_Click);
            // 
            // cmb_regos
            // 
            this.cmb_regos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmb_regos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_regos.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_regos.FormattingEnabled = true;
            this.cmb_regos.Location = new System.Drawing.Point(956, 71);
            this.cmb_regos.Name = "cmb_regos";
            this.cmb_regos.Size = new System.Drawing.Size(211, 39);
            this.cmb_regos.TabIndex = 225;
            this.cmb_regos.SelectedIndexChanged += new System.EventHandler(this.cmb_regos_SelectedIndexChanged);
            // 
            // btn_clear
            // 
            this.btn_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btn_clear.Location = new System.Drawing.Point(1198, 75);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(82, 30);
            this.btn_clear.TabIndex = 226;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label71.Location = new System.Drawing.Point(952, 44);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(114, 20);
            this.label71.TabIndex = 227;
            this.label71.Text = "Search Rego";
            // 
            // lbl_datein
            // 
            this.lbl_datein.AutoSize = true;
            this.lbl_datein.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_datein.Location = new System.Drawing.Point(42, 220);
            this.lbl_datein.Name = "lbl_datein";
            this.lbl_datein.Size = new System.Drawing.Size(90, 16);
            this.lbl_datein.TabIndex = 228;
            this.lbl_datein.Text = "SUN, 5 JUN";
            this.lbl_datein.Visible = false;
            // 
            // txt_nocars
            // 
            this.txt_nocars.AutoSize = true;
            this.txt_nocars.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nocars.ForeColor = System.Drawing.Color.Red;
            this.txt_nocars.Location = new System.Drawing.Point(544, 44);
            this.txt_nocars.Name = "txt_nocars";
            this.txt_nocars.Size = new System.Drawing.Size(356, 73);
            this.txt_nocars.TabIndex = 230;
            this.txt_nocars.Text = "35/70 Cars";
            // 
            // btn_one
            // 
            this.btn_one.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_one.Location = new System.Drawing.Point(21, 166);
            this.btn_one.Name = "btn_one";
            this.btn_one.Size = new System.Drawing.Size(141, 51);
            this.btn_one.TabIndex = 231;
            this.btn_one.Text = "10. NANAGG";
            this.btn_one.UseVisualStyleBackColor = true;
            this.btn_one.Visible = false;
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label72.Location = new System.Drawing.Point(661, 9);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(108, 29);
            this.label72.TabIndex = 232;
            this.label72.Text = "Key Box";
            // 
            // KeyBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1545, 735);
            this.Controls.Add(this.label72);
            this.Controls.Add(this.btn_one);
            this.Controls.Add(this.txt_nocars);
            this.Controls.Add(this.lbl_datein);
            this.Controls.Add(this.label71);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.cmb_regos);
            this.Controls.Add(this.btn_returns);
            this.Controls.Add(this.btn_invoice);
            this.Controls.Add(this.btn_mainmenu);
            this.Name = "KeyBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_mainmenu;
        private System.Windows.Forms.Button btn_invoice;
        private System.Windows.Forms.Button btn_returns;
        private System.Windows.Forms.ComboBox cmb_regos;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.Label lbl_datein;
        private System.Windows.Forms.Label txt_nocars;
        private System.Windows.Forms.Button btn_one;
        private System.Windows.Forms.Label label72;
    }
}