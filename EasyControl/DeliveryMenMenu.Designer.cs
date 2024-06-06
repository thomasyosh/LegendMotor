namespace EasyControl
{
    partial class DeliveryMenMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeliveryMenMenu));
            this.btn_purchasingOrder = new System.Windows.Forms.Button();
            this.btn_incomingOrder = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_purchasingOrder
            // 
            this.btn_purchasingOrder.Font = new System.Drawing.Font("PMingLiU", 14F);
            this.btn_purchasingOrder.Location = new System.Drawing.Point(12, 74);
            this.btn_purchasingOrder.Name = "btn_purchasingOrder";
            this.btn_purchasingOrder.Size = new System.Drawing.Size(269, 40);
            this.btn_purchasingOrder.TabIndex = 19;
            this.btn_purchasingOrder.Text = "View Purchasing Orders";
            this.btn_purchasingOrder.UseVisualStyleBackColor = true;
            this.btn_purchasingOrder.Click += new System.EventHandler(this.btn_purchasingOrder_Click);
            // 
            // btn_incomingOrder
            // 
            this.btn_incomingOrder.Font = new System.Drawing.Font("PMingLiU", 14F);
            this.btn_incomingOrder.Location = new System.Drawing.Point(12, 28);
            this.btn_incomingOrder.Name = "btn_incomingOrder";
            this.btn_incomingOrder.Size = new System.Drawing.Size(269, 40);
            this.btn_incomingOrder.TabIndex = 18;
            this.btn_incomingOrder.Text = "View Incoming Orders";
            this.btn_incomingOrder.UseVisualStyleBackColor = true;
            this.btn_incomingOrder.Click += new System.EventHandler(this.btn_incomingOrder_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(293, 25);
            this.toolStrip1.TabIndex = 17;
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
            // DeliveryMenMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 123);
            this.Controls.Add(this.btn_purchasingOrder);
            this.Controls.Add(this.btn_incomingOrder);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("PMingLiU", 14F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "DeliveryMenMenu";
            this.Text = "Menu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DeliveryMenMenu_FormClosed);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_purchasingOrder;
        private System.Windows.Forms.Button btn_incomingOrder;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}