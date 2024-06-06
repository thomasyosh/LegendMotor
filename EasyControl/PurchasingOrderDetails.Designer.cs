namespace EasyControl
{
    partial class PurchasingOrderDetails
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lbl_spares = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btn_update = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_orderDate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(952, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bin Location:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(952, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Address:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(952, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Supplier:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Related Order:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(134, 111);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(201, 19);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Click here to view details!";
            // 
            // lbl_spares
            // 
            this.lbl_spares.AutoSize = true;
            this.lbl_spares.Location = new System.Drawing.Point(12, 174);
            this.lbl_spares.Name = "lbl_spares";
            this.lbl_spares.Size = new System.Drawing.Size(62, 19);
            this.lbl_spares.TabIndex = 18;
            this.lbl_spares.Text = "Spares:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 196);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(952, 277);
            this.dataGridView1.TabIndex = 28;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ItemHeight = 19;
            this.comboBox1.Location = new System.Drawing.Point(746, 515);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 27);
            this.comboBox1.TabIndex = 39;
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(873, 508);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(91, 39);
            this.btn_update.TabIndex = 38;
            this.btn_update.Text = "Update";
            this.btn_update.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(677, 518);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 19);
            this.label5.TabIndex = 37;
            this.label5.Text = "Status: ";
            // 
            // lbl_orderDate
            // 
            this.lbl_orderDate.AutoSize = true;
            this.lbl_orderDate.Location = new System.Drawing.Point(12, 143);
            this.lbl_orderDate.Name = "lbl_orderDate";
            this.lbl_orderDate.Size = new System.Drawing.Size(91, 19);
            this.lbl_orderDate.TabIndex = 36;
            this.lbl_orderDate.Text = "Order date:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(862, 486);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 19);
            this.label6.TabIndex = 40;
            this.label6.Text = "Last Update:";
            // 
            // PurchasingOrderDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 559);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl_orderDate);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lbl_spares);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("PMingLiU", 14F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "PurchasingOrderDetails";
            this.Text = "Order Details";
            this.Load += new System.EventHandler(this.PurchasingOrderDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label lbl_spares;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_orderDate;
        private System.Windows.Forms.Label label6;
    }
}