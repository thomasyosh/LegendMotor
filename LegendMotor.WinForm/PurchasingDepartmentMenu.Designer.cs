namespace EasyControl.Model
{
    partial class PurchasingDepartmentMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PurchasingDepartmentMenu));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.btn_supplier = new System.Windows.Forms.Button();
            this.btn_spare = new System.Windows.Forms.Button();
            this.btn_order = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(293, 25);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(49, 22);
            this.toolStripButton1.Text = "Logout";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btn_supplier
            // 
            this.btn_supplier.Font = new System.Drawing.Font("PMingLiU", 14F);
            this.btn_supplier.Location = new System.Drawing.Point(12, 76);
            this.btn_supplier.Name = "btn_supplier";
            this.btn_supplier.Size = new System.Drawing.Size(269, 40);
            this.btn_supplier.TabIndex = 7;
            this.btn_supplier.Text = "Suppliers";
            this.btn_supplier.UseVisualStyleBackColor = true;
            this.btn_supplier.Click += new System.EventHandler(this.btn_supplier_Click);
            // 
            // btn_spare
            // 
            this.btn_spare.Font = new System.Drawing.Font("PMingLiU", 14F);
            this.btn_spare.Location = new System.Drawing.Point(12, 30);
            this.btn_spare.Name = "btn_spare";
            this.btn_spare.Size = new System.Drawing.Size(269, 40);
            this.btn_spare.TabIndex = 8;
            this.btn_spare.Text = "Spares";
            this.btn_spare.UseVisualStyleBackColor = true;
            this.btn_spare.Click += new System.EventHandler(this.btn_spare_Click);
            // 
            // btn_order
            // 
            this.btn_order.Font = new System.Drawing.Font("PMingLiU", 14F);
            this.btn_order.Location = new System.Drawing.Point(12, 122);
            this.btn_order.Name = "btn_order";
            this.btn_order.Size = new System.Drawing.Size(269, 40);
            this.btn_order.TabIndex = 11;
            this.btn_order.Text = "Orders";
            this.btn_order.UseVisualStyleBackColor = true;
            this.btn_order.Click += new System.EventHandler(this.btn_order_Click);
            // 
            // PurchasingDepartmentMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 171);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btn_supplier);
            this.Controls.Add(this.btn_spare);
            this.Controls.Add(this.btn_order);
            this.Font = new System.Drawing.Font("PMingLiU", 14F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "PurchasingDepartmentMenu";
            this.Text = "PurchasingDepartmentMenu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PurchasingDepartment_FormClosed);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Button btn_supplier;
        private System.Windows.Forms.Button btn_spare;
        private System.Windows.Forms.Button btn_order;
    }
}