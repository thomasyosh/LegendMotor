namespace EasyControl
{
    partial class AreaManagerMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AreaManagerMenu));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.btn_viewDealers = new System.Windows.Forms.Button();
            this.btn_searchSpare = new System.Windows.Forms.Button();
            this.btn_SalesOverview = new System.Windows.Forms.Button();
            this.btn_viewOrder = new System.Windows.Forms.Button();
            this.btn_createNewOrder = new System.Windows.Forms.Button();
            this.btn_manageBinLocation = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(289, 25);
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
            // btn_viewDealers
            // 
            this.btn_viewDealers.Font = new System.Drawing.Font("PMingLiU", 14F);
            this.btn_viewDealers.Location = new System.Drawing.Point(12, 78);
            this.btn_viewDealers.Name = "btn_viewDealers";
            this.btn_viewDealers.Size = new System.Drawing.Size(265, 40);
            this.btn_viewDealers.TabIndex = 7;
            this.btn_viewDealers.Text = "View Dealers";
            this.btn_viewDealers.UseVisualStyleBackColor = true;
            // 
            // btn_searchSpare
            // 
            this.btn_searchSpare.Font = new System.Drawing.Font("PMingLiU", 14F);
            this.btn_searchSpare.Location = new System.Drawing.Point(12, 32);
            this.btn_searchSpare.Name = "btn_searchSpare";
            this.btn_searchSpare.Size = new System.Drawing.Size(265, 40);
            this.btn_searchSpare.TabIndex = 8;
            this.btn_searchSpare.Text = "Search Spare";
            this.btn_searchSpare.UseVisualStyleBackColor = true;
            // 
            // btn_SalesOverview
            // 
            this.btn_SalesOverview.Font = new System.Drawing.Font("PMingLiU", 14F);
            this.btn_SalesOverview.Location = new System.Drawing.Point(12, 216);
            this.btn_SalesOverview.Name = "btn_SalesOverview";
            this.btn_SalesOverview.Size = new System.Drawing.Size(265, 40);
            this.btn_SalesOverview.TabIndex = 9;
            this.btn_SalesOverview.Text = "View Sales Overview";
            this.btn_SalesOverview.UseVisualStyleBackColor = true;
            // 
            // btn_viewOrder
            // 
            this.btn_viewOrder.Font = new System.Drawing.Font("PMingLiU", 14F);
            this.btn_viewOrder.Location = new System.Drawing.Point(12, 170);
            this.btn_viewOrder.Name = "btn_viewOrder";
            this.btn_viewOrder.Size = new System.Drawing.Size(265, 40);
            this.btn_viewOrder.TabIndex = 10;
            this.btn_viewOrder.Text = "View Orders";
            this.btn_viewOrder.UseVisualStyleBackColor = true;
            // 
            // btn_createNewOrder
            // 
            this.btn_createNewOrder.Font = new System.Drawing.Font("PMingLiU", 14F);
            this.btn_createNewOrder.Location = new System.Drawing.Point(12, 124);
            this.btn_createNewOrder.Name = "btn_createNewOrder";
            this.btn_createNewOrder.Size = new System.Drawing.Size(265, 40);
            this.btn_createNewOrder.TabIndex = 11;
            this.btn_createNewOrder.Text = "Create New Order";
            this.btn_createNewOrder.UseVisualStyleBackColor = true;
            // 
            // btn_manageBinLocation
            // 
            this.btn_manageBinLocation.Font = new System.Drawing.Font("PMingLiU", 14F);
            this.btn_manageBinLocation.Location = new System.Drawing.Point(12, 262);
            this.btn_manageBinLocation.Name = "btn_manageBinLocation";
            this.btn_manageBinLocation.Size = new System.Drawing.Size(265, 40);
            this.btn_manageBinLocation.TabIndex = 9;
            this.btn_manageBinLocation.Text = "Manage Bin Location";
            this.btn_manageBinLocation.UseVisualStyleBackColor = true;
            this.btn_manageBinLocation.Click += new System.EventHandler(this.button1_Click);
            // 
            // AreaManagerMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 309);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btn_viewDealers);
            this.Controls.Add(this.btn_searchSpare);
            this.Controls.Add(this.btn_manageBinLocation);
            this.Controls.Add(this.btn_SalesOverview);
            this.Controls.Add(this.btn_viewOrder);
            this.Controls.Add(this.btn_createNewOrder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "AreaManagerMenu";
            this.Text = "Menu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AreaManagerMenu_FormClosed);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Button btn_viewDealers;
        private System.Windows.Forms.Button btn_searchSpare;
        private System.Windows.Forms.Button btn_SalesOverview;
        private System.Windows.Forms.Button btn_viewOrder;
        private System.Windows.Forms.Button btn_createNewOrder;
        private System.Windows.Forms.Button btn_manageBinLocation;
    }
}