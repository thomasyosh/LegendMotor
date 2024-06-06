namespace EasyControl
{
    partial class CheckoutForm
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
            this.lbl_dealer = new System.Windows.Forms.Label();
            this.lbl_dealer_value = new System.Windows.Forms.Label();
            this.lbl_spares = new System.Windows.Forms.Label();
            this.lbl_invoiceName = new System.Windows.Forms.Label();
            this.lbl_invoiceAddress = new System.Windows.Forms.Label();
            this.lbl_deliveryAddress = new System.Windows.Forms.Label();
            this.txt_invoiceName = new System.Windows.Forms.TextBox();
            this.txt_delivery = new System.Windows.Forms.TextBox();
            this.txt_invoiceAddress = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_dealer
            // 
            this.lbl_dealer.AutoSize = true;
            this.lbl_dealer.Location = new System.Drawing.Point(12, 9);
            this.lbl_dealer.Name = "lbl_dealer";
            this.lbl_dealer.Size = new System.Drawing.Size(67, 19);
            this.lbl_dealer.TabIndex = 0;
            this.lbl_dealer.Text = "Dealer: ";
            // 
            // lbl_dealer_value
            // 
            this.lbl_dealer_value.Location = new System.Drawing.Point(85, 9);
            this.lbl_dealer_value.Name = "lbl_dealer_value";
            this.lbl_dealer_value.Size = new System.Drawing.Size(879, 38);
            this.lbl_dealer_value.TabIndex = 1;
            this.lbl_dealer_value.Text = "Name";
            // 
            // lbl_spares
            // 
            this.lbl_spares.AutoSize = true;
            this.lbl_spares.Location = new System.Drawing.Point(15, 388);
            this.lbl_spares.Name = "lbl_spares";
            this.lbl_spares.Size = new System.Drawing.Size(62, 19);
            this.lbl_spares.TabIndex = 2;
            this.lbl_spares.Text = "Spares:";
            // 
            // lbl_invoiceName
            // 
            this.lbl_invoiceName.AutoSize = true;
            this.lbl_invoiceName.Location = new System.Drawing.Point(12, 64);
            this.lbl_invoiceName.Name = "lbl_invoiceName";
            this.lbl_invoiceName.Size = new System.Drawing.Size(116, 19);
            this.lbl_invoiceName.TabIndex = 4;
            this.lbl_invoiceName.Text = "Invoice Name:";
            // 
            // lbl_invoiceAddress
            // 
            this.lbl_invoiceAddress.AutoSize = true;
            this.lbl_invoiceAddress.Location = new System.Drawing.Point(12, 100);
            this.lbl_invoiceAddress.Name = "lbl_invoiceAddress";
            this.lbl_invoiceAddress.Size = new System.Drawing.Size(137, 19);
            this.lbl_invoiceAddress.TabIndex = 5;
            this.lbl_invoiceAddress.Text = "Invoice Address: ";
            // 
            // lbl_deliveryAddress
            // 
            this.lbl_deliveryAddress.AutoSize = true;
            this.lbl_deliveryAddress.Location = new System.Drawing.Point(12, 136);
            this.lbl_deliveryAddress.Name = "lbl_deliveryAddress";
            this.lbl_deliveryAddress.Size = new System.Drawing.Size(146, 19);
            this.lbl_deliveryAddress.TabIndex = 6;
            this.lbl_deliveryAddress.Text = "Delivery Address: ";
            // 
            // txt_invoiceName
            // 
            this.txt_invoiceName.Location = new System.Drawing.Point(164, 61);
            this.txt_invoiceName.Name = "txt_invoiceName";
            this.txt_invoiceName.Size = new System.Drawing.Size(766, 30);
            this.txt_invoiceName.TabIndex = 7;
            // 
            // txt_delivery
            // 
            this.txt_delivery.Location = new System.Drawing.Point(164, 133);
            this.txt_delivery.Name = "txt_delivery";
            this.txt_delivery.Size = new System.Drawing.Size(766, 30);
            this.txt_delivery.TabIndex = 8;
            // 
            // txt_invoiceAddress
            // 
            this.txt_invoiceAddress.Location = new System.Drawing.Point(164, 97);
            this.txt_invoiceAddress.Name = "txt_invoiceAddress";
            this.txt_invoiceAddress.Size = new System.Drawing.Size(766, 30);
            this.txt_invoiceAddress.TabIndex = 9;
            this.txt_invoiceAddress.TextChanged += new System.EventHandler(this.txt_invoiceAddress_TextChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(164, 169);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(222, 23);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Same with invoice address";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(15, 266);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(949, 108);
            this.richTextBox1.TabIndex = 11;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 19);
            this.label1.TabIndex = 12;
            this.label1.Text = "Remark:";
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(868, 632);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(8);
            this.button1.Size = new System.Drawing.Size(96, 45);
            this.button1.TabIndex = 13;
            this.button1.Text = "Confirm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 420);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(949, 197);
            this.dataGridView1.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 19);
            this.label2.TabIndex = 15;
            this.label2.Text = "Contact type:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Email",
            "Phone",
            "Telex",
            "Fax"});
            this.comboBox1.Location = new System.Drawing.Point(164, 200);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(153, 27);
            this.comboBox1.TabIndex = 16;
            // 
            // CheckoutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(976, 684);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.txt_invoiceAddress);
            this.Controls.Add(this.txt_delivery);
            this.Controls.Add(this.txt_invoiceName);
            this.Controls.Add(this.lbl_deliveryAddress);
            this.Controls.Add(this.lbl_invoiceAddress);
            this.Controls.Add(this.lbl_invoiceName);
            this.Controls.Add(this.lbl_spares);
            this.Controls.Add(this.lbl_dealer_value);
            this.Controls.Add(this.lbl_dealer);
            this.Font = new System.Drawing.Font("PMingLiU", 14F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "CheckoutForm";
            this.Text = "Checkout";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CheckoutForm_FormClosing);
            this.Load += new System.EventHandler(this.CheckoutForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_dealer;
        private System.Windows.Forms.Label lbl_dealer_value;
        private System.Windows.Forms.Label lbl_spares;
        private System.Windows.Forms.Label lbl_invoiceName;
        private System.Windows.Forms.Label lbl_invoiceAddress;
        private System.Windows.Forms.Label lbl_deliveryAddress;
        private System.Windows.Forms.TextBox txt_invoiceName;
        private System.Windows.Forms.TextBox txt_delivery;
        private System.Windows.Forms.TextBox txt_invoiceAddress;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}