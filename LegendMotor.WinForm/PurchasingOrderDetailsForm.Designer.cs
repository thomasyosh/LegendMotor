namespace LegendMotor.WinForm
{
    partial class PurchasingOrderDetailsForm
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
            this.lbl_spares = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lbl_orderDate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_orderId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_spares
            // 
            this.lbl_spares.AutoSize = true;
            this.lbl_spares.Location = new System.Drawing.Point(12, 97);
            this.lbl_spares.Name = "lbl_spares";
            this.lbl_spares.Size = new System.Drawing.Size(62, 19);
            this.lbl_spares.TabIndex = 18;
            this.lbl_spares.Text = "Spares:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 119);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1105, 454);
            this.dataGridView1.TabIndex = 28;
            // 
            // lbl_orderDate
            // 
            this.lbl_orderDate.AutoSize = true;
            this.lbl_orderDate.Location = new System.Drawing.Point(12, 39);
            this.lbl_orderDate.Name = "lbl_orderDate";
            this.lbl_orderDate.Size = new System.Drawing.Size(91, 19);
            this.lbl_orderDate.TabIndex = 36;
            this.lbl_orderDate.Text = "Order date:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 19);
            this.label6.TabIndex = 40;
            this.label6.Text = "Last Update:";
            // 
            // lbl_orderId
            // 
            this.lbl_orderId.AutoSize = true;
            this.lbl_orderId.Location = new System.Drawing.Point(12, 9);
            this.lbl_orderId.Name = "lbl_orderId";
            this.lbl_orderId.Size = new System.Drawing.Size(80, 19);
            this.lbl_orderId.TabIndex = 41;
            this.lbl_orderId.Text = "Order ID:";
            // 
            // PurchasingOrderDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 582);
            this.Controls.Add(this.lbl_orderId);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbl_orderDate);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lbl_spares);
            this.Font = new System.Drawing.Font("PMingLiU", 14F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "PurchasingOrderDetails";
            this.Text = "Order Details";
            this.Load += new System.EventHandler(this.PurchasingOrderDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_spares;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lbl_orderDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_orderId;
    }
}