namespace LegendMotor.WinForm
{
    partial class Invoice
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_contact = new System.Windows.Forms.Label();
            this.lbl_dealer = new System.Windows.Forms.Label();
            this.lbl_orderDate = new System.Windows.Forms.Label();
            this.lbl_orderNo = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.orderLineIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.itemName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.unitPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.totalPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_deliveryAddress = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_invoiceAddress = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_totalWeight = new System.Windows.Forms.Label();
            this.lbl_totalPrice = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbl_totalPrice);
            this.panel1.Controls.Add(this.lbl_totalWeight);
            this.panel1.Controls.Add(this.tableLayoutPanel4);
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Controls.Add(this.tableLayoutPanel3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 1281);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.lbl_contact, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.lbl_dealer, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.lbl_orderDate, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.lbl_orderNo, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 372);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1000, 44);
            this.tableLayoutPanel4.TabIndex = 6;
            // 
            // lbl_contact
            // 
            this.lbl_contact.AutoSize = true;
            this.lbl_contact.Location = new System.Drawing.Point(504, 23);
            this.lbl_contact.Name = "lbl_contact";
            this.lbl_contact.Size = new System.Drawing.Size(75, 18);
            this.lbl_contact.TabIndex = 3;
            this.lbl_contact.Text = "Contact: ";
            // 
            // lbl_dealer
            // 
            this.lbl_dealer.AutoSize = true;
            this.lbl_dealer.Location = new System.Drawing.Point(6, 23);
            this.lbl_dealer.Name = "lbl_dealer";
            this.lbl_dealer.Size = new System.Drawing.Size(67, 18);
            this.lbl_dealer.TabIndex = 2;
            this.lbl_dealer.Text = "Dealer: ";
            // 
            // lbl_orderDate
            // 
            this.lbl_orderDate.AutoSize = true;
            this.lbl_orderDate.Location = new System.Drawing.Point(504, 3);
            this.lbl_orderDate.Name = "lbl_orderDate";
            this.lbl_orderDate.Size = new System.Drawing.Size(100, 17);
            this.lbl_orderDate.TabIndex = 0;
            this.lbl_orderDate.Text = "Order Date: ";
            // 
            // lbl_orderNo
            // 
            this.lbl_orderNo.AutoSize = true;
            this.lbl_orderNo.Location = new System.Drawing.Point(6, 3);
            this.lbl_orderNo.Name = "lbl_orderNo";
            this.lbl_orderNo.Size = new System.Drawing.Size(88, 17);
            this.lbl_orderNo.TabIndex = 1;
            this.lbl_orderNo.Text = "Order No: ";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.orderLineIndex,
            this.itemName,
            this.unitPrice,
            this.quantity,
            this.totalPrice});
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(-5, 422);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1000, 766);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // orderLineIndex
            // 
            this.orderLineIndex.Text = "No.";
            this.orderLineIndex.Width = 100;
            // 
            // itemName
            // 
            this.itemName.Tag = "1";
            this.itemName.Text = "Item";
            this.itemName.Width = 396;
            // 
            // unitPrice
            // 
            this.unitPrice.Text = "Unit Price";
            this.unitPrice.Width = 200;
            // 
            // quantity
            // 
            this.quantity.Text = "Quantity";
            this.quantity.Width = 200;
            // 
            // totalPrice
            // 
            this.totalPrice.Text = "Total";
            this.totalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.totalPrice.Width = 100;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.lbl_deliveryAddress, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label8, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lbl_invoiceAddress, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 210);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.68354F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.31645F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1000, 161);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // lbl_deliveryAddress
            // 
            this.lbl_deliveryAddress.Location = new System.Drawing.Point(504, 42);
            this.lbl_deliveryAddress.Name = "lbl_deliveryAddress";
            this.lbl_deliveryAddress.Size = new System.Drawing.Size(491, 117);
            this.lbl_deliveryAddress.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("PMingLiU", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(5, 17);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(185, 21);
            this.label7.TabIndex = 0;
            this.label7.Text = "INVOICE ADDRESS";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("PMingLiU", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(504, 17);
            this.label8.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(202, 21);
            this.label8.TabIndex = 1;
            this.label8.Text = "DELIVERY ADDRESS";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // lbl_invoiceAddress
            // 
            this.lbl_invoiceAddress.Location = new System.Drawing.Point(5, 42);
            this.lbl_invoiceAddress.Name = "lbl_invoiceAddress";
            this.lbl_invoiceAddress.Size = new System.Drawing.Size(491, 117);
            this.lbl_invoiceAddress.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(79, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(345, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "SMLC District, Tienhou, Guangzhou";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.64398F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.35602F));
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(83, 171);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(573, 41);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tel: 133 808 12345";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(276, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "Grams: LegendMC";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(662, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.37736F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.62264F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(337, 212);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "DELIVERY NOTE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("PMingLiU", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(401, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Legend MOTOR Co. Ltd.";
            // 
            // lbl_totalWeight
            // 
            this.lbl_totalWeight.Location = new System.Drawing.Point(646, 1201);
            this.lbl_totalWeight.Name = "lbl_totalWeight";
            this.lbl_totalWeight.Size = new System.Drawing.Size(349, 19);
            this.lbl_totalWeight.TabIndex = 7;
            this.lbl_totalWeight.Text = "label6";
            this.lbl_totalWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_totalPrice
            // 
            this.lbl_totalPrice.Location = new System.Drawing.Point(646, 1236);
            this.lbl_totalPrice.Name = "lbl_totalPrice";
            this.lbl_totalPrice.Size = new System.Drawing.Size(349, 19);
            this.lbl_totalPrice.TabIndex = 8;
            this.lbl_totalPrice.Text = "label6";
            this.lbl_totalPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Invoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 1281);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("PMingLiU", 14F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Invoice";
            this.Text = "Invoice";
            this.Load += new System.EventHandler(this.Invoice_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_deliveryAddress;
        private System.Windows.Forms.Label lbl_invoiceAddress;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader orderLineIndex;
        private System.Windows.Forms.ColumnHeader itemName;
        private System.Windows.Forms.ColumnHeader unitPrice;
        private System.Windows.Forms.ColumnHeader quantity;
        private System.Windows.Forms.ColumnHeader totalPrice;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label lbl_orderNo;
        private System.Windows.Forms.Label lbl_orderDate;
        private System.Windows.Forms.Label lbl_dealer;
        private System.Windows.Forms.Label lbl_contact;
        private System.Windows.Forms.Label lbl_totalPrice;
        private System.Windows.Forms.Label lbl_totalWeight;
    }
}