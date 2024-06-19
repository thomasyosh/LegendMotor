namespace LegendMotor.WinForm
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
            lbl_dealer = new Label();
            lbl_dealer_value = new Label();
            lbl_spares = new Label();
            lbl_invoiceName = new Label();
            lbl_invoiceAddress = new Label();
            lbl_deliveryAddress = new Label();
            txt_invoiceName = new TextBox();
            txt_delivery = new TextBox();
            txt_invoiceAddress = new TextBox();
            checkBox1 = new CheckBox();
            richTextBox1 = new RichTextBox();
            label1 = new Label();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            label2 = new Label();
            comboBox1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // lbl_dealer
            // 
            lbl_dealer.AutoSize = true;
            lbl_dealer.Location = new Point(12, 9);
            lbl_dealer.Name = "lbl_dealer";
            lbl_dealer.Size = new Size(67, 19);
            lbl_dealer.TabIndex = 0;
            lbl_dealer.Text = "Dealer: ";
            // 
            // lbl_dealer_value
            // 
            lbl_dealer_value.Location = new Point(85, 9);
            lbl_dealer_value.Name = "lbl_dealer_value";
            lbl_dealer_value.Size = new Size(879, 38);
            lbl_dealer_value.TabIndex = 1;
            lbl_dealer_value.Text = "Name";
            // 
            // lbl_spares
            // 
            lbl_spares.AutoSize = true;
            lbl_spares.Location = new Point(15, 388);
            lbl_spares.Name = "lbl_spares";
            lbl_spares.Size = new Size(62, 19);
            lbl_spares.TabIndex = 2;
            lbl_spares.Text = "Spares:";
            // 
            // lbl_invoiceName
            // 
            lbl_invoiceName.AutoSize = true;
            lbl_invoiceName.Location = new Point(12, 64);
            lbl_invoiceName.Name = "lbl_invoiceName";
            lbl_invoiceName.Size = new Size(116, 19);
            lbl_invoiceName.TabIndex = 4;
            lbl_invoiceName.Text = "Invoice Name:";
            // 
            // lbl_invoiceAddress
            // 
            lbl_invoiceAddress.AutoSize = true;
            lbl_invoiceAddress.Location = new Point(12, 100);
            lbl_invoiceAddress.Name = "lbl_invoiceAddress";
            lbl_invoiceAddress.Size = new Size(137, 19);
            lbl_invoiceAddress.TabIndex = 5;
            lbl_invoiceAddress.Text = "Invoice Address: ";
            // 
            // lbl_deliveryAddress
            // 
            lbl_deliveryAddress.AutoSize = true;
            lbl_deliveryAddress.Location = new Point(12, 136);
            lbl_deliveryAddress.Name = "lbl_deliveryAddress";
            lbl_deliveryAddress.Size = new Size(146, 19);
            lbl_deliveryAddress.TabIndex = 6;
            lbl_deliveryAddress.Text = "Delivery Address: ";
            // 
            // txt_invoiceName
            // 
            txt_invoiceName.Location = new Point(164, 61);
            txt_invoiceName.Name = "txt_invoiceName";
            txt_invoiceName.Size = new Size(766, 30);
            txt_invoiceName.TabIndex = 7;
            // 
            // txt_delivery
            // 
            txt_delivery.Location = new Point(164, 133);
            txt_delivery.Name = "txt_delivery";
            txt_delivery.Size = new Size(766, 30);
            txt_delivery.TabIndex = 8;
            // 
            // txt_invoiceAddress
            // 
            txt_invoiceAddress.Location = new Point(164, 97);
            txt_invoiceAddress.Name = "txt_invoiceAddress";
            txt_invoiceAddress.Size = new Size(766, 30);
            txt_invoiceAddress.TabIndex = 9;
            txt_invoiceAddress.TextChanged += txt_invoiceAddress_TextChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(164, 169);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(205, 23);
            checkBox1.TabIndex = 10;
            checkBox1.Text = "Same as invoice address";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(15, 266);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(949, 108);
            richTextBox1.TabIndex = 11;
            richTextBox1.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 244);
            label1.Name = "label1";
            label1.Size = new Size(71, 19);
            label1.TabIndex = 12;
            label1.Text = "Remark:";
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.Location = new Point(868, 632);
            button1.Name = "button1";
            button1.Padding = new Padding(8);
            button1.Size = new Size(96, 45);
            button1.TabIndex = 13;
            button1.Text = "Confirm";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(15, 420);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 24;
            dataGridView1.Size = new Size(949, 197);
            dataGridView1.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 203);
            label2.Name = "label2";
            label2.Size = new Size(106, 19);
            label2.TabIndex = 15;
            label2.Text = "Contact type:";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Email", "Phone", "Telex", "Fax" });
            comboBox1.Location = new Point(164, 200);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(153, 27);
            comboBox1.TabIndex = 16;
            // 
            // CheckoutForm
            // 
            AutoScaleDimensions = new SizeF(10F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(976, 684);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(richTextBox1);
            Controls.Add(checkBox1);
            Controls.Add(txt_invoiceAddress);
            Controls.Add(txt_delivery);
            Controls.Add(txt_invoiceName);
            Controls.Add(lbl_deliveryAddress);
            Controls.Add(lbl_invoiceAddress);
            Controls.Add(lbl_invoiceName);
            Controls.Add(lbl_spares);
            Controls.Add(lbl_dealer_value);
            Controls.Add(lbl_dealer);
            Font = new Font("新細明體", 14F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(5);
            Name = "CheckoutForm";
            Text = "Checkout";
            FormClosing += CheckoutForm_FormClosing;
            Load += CheckoutForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
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