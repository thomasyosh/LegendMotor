namespace LegendMotor.WinForm
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
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            btn_viewDealers = new Button();
            btn_searchSpare = new Button();
            btn_SalesOverview = new Button();
            btn_viewOrder = new Button();
            btn_manageBinLocation = new Button();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(337, 25);
            toolStrip1.TabIndex = 12;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(52, 22);
            toolStripButton1.Text = "Logout";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // btn_viewDealers
            // 
            btn_viewDealers.Font = new Font("新細明體", 14F);
            btn_viewDealers.Location = new Point(14, 98);
            btn_viewDealers.Margin = new Padding(4);
            btn_viewDealers.Name = "btn_viewDealers";
            btn_viewDealers.Size = new Size(309, 50);
            btn_viewDealers.TabIndex = 7;
            btn_viewDealers.Text = "View Dealers";
            btn_viewDealers.UseVisualStyleBackColor = true;
            btn_viewDealers.Click += btn_viewDealers_Click;
            // 
            // btn_searchSpare
            // 
            btn_searchSpare.Font = new Font("新細明體", 14F);
            btn_searchSpare.Location = new Point(14, 40);
            btn_searchSpare.Margin = new Padding(4);
            btn_searchSpare.Name = "btn_searchSpare";
            btn_searchSpare.Size = new Size(309, 50);
            btn_searchSpare.TabIndex = 8;
            btn_searchSpare.Text = "Search Spare";
            btn_searchSpare.UseVisualStyleBackColor = true;
            btn_searchSpare.Click += btn_searchSpare_Click;
            // 
            // btn_SalesOverview
            // 
            btn_SalesOverview.Font = new Font("新細明體", 14F);
            btn_SalesOverview.Location = new Point(14, 213);
            btn_SalesOverview.Margin = new Padding(4);
            btn_SalesOverview.Name = "btn_SalesOverview";
            btn_SalesOverview.Size = new Size(309, 50);
            btn_SalesOverview.TabIndex = 9;
            btn_SalesOverview.Text = "View Sales Overview";
            btn_SalesOverview.UseVisualStyleBackColor = true;
            btn_SalesOverview.Click += btn_SalesOverview_Click;
            // 
            // btn_viewOrder
            // 
            btn_viewOrder.Font = new Font("新細明體", 14F);
            btn_viewOrder.Location = new Point(14, 155);
            btn_viewOrder.Margin = new Padding(4);
            btn_viewOrder.Name = "btn_viewOrder";
            btn_viewOrder.Size = new Size(309, 50);
            btn_viewOrder.TabIndex = 10;
            btn_viewOrder.Text = "View Orders";
            btn_viewOrder.UseVisualStyleBackColor = true;
            btn_viewOrder.Click += btn_viewOrder_Click;
            // 
            // btn_manageBinLocation
            // 
            btn_manageBinLocation.Font = new Font("新細明體", 14F);
            btn_manageBinLocation.Location = new Point(14, 271);
            btn_manageBinLocation.Margin = new Padding(4);
            btn_manageBinLocation.Name = "btn_manageBinLocation";
            btn_manageBinLocation.Size = new Size(309, 50);
            btn_manageBinLocation.TabIndex = 9;
            btn_manageBinLocation.Text = "Manage Bin Location";
            btn_manageBinLocation.UseVisualStyleBackColor = true;
            btn_manageBinLocation.Click += button1_Click;
            // 
            // AreaManagerMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(337, 335);
            Controls.Add(toolStrip1);
            Controls.Add(btn_viewDealers);
            Controls.Add(btn_searchSpare);
            Controls.Add(btn_manageBinLocation);
            Controls.Add(btn_SalesOverview);
            Controls.Add(btn_viewOrder);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(4);
            Name = "AreaManagerMenu";
            Text = "Menu";
            FormClosed += AreaManagerMenu_FormClosed;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Button btn_viewDealers;
        private System.Windows.Forms.Button btn_searchSpare;
        private System.Windows.Forms.Button btn_SalesOverview;
        private System.Windows.Forms.Button btn_viewOrder;
        private System.Windows.Forms.Button btn_manageBinLocation;
    }
}