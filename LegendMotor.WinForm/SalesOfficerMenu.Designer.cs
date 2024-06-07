namespace LegendMotor.WinForm;

partial class SalesOfficerMenu
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesOfficerMenu));
        this.btn_searchSpare = new System.Windows.Forms.Button();
        this.btn_viewDealers = new System.Windows.Forms.Button();
        this.toolStrip1 = new System.Windows.Forms.ToolStrip();
        this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
        this.btn_createNewOrder = new System.Windows.Forms.Button();
        this.btn_viewOrder = new System.Windows.Forms.Button();
        this.toolStrip1.SuspendLayout();
        this.SuspendLayout();
        // 
        // btn_searchSpare
        // 
        this.btn_searchSpare.Font = new System.Drawing.Font("PMingLiU", 14F);
        this.btn_searchSpare.Location = new System.Drawing.Point(12, 28);
        this.btn_searchSpare.Name = "btn_searchSpare";
        this.btn_searchSpare.Size = new System.Drawing.Size(269, 40);
        this.btn_searchSpare.TabIndex = 0;
        this.btn_searchSpare.Text = "Search Spare";
        this.btn_searchSpare.UseVisualStyleBackColor = true;
        this.btn_searchSpare.Click += new System.EventHandler(this.btn_searchSpare_Click);
        // 
        // btn_viewDealers
        // 
        this.btn_viewDealers.Font = new System.Drawing.Font("PMingLiU", 14F);
        this.btn_viewDealers.Location = new System.Drawing.Point(12, 74);
        this.btn_viewDealers.Name = "btn_viewDealers";
        this.btn_viewDealers.Size = new System.Drawing.Size(269, 40);
        this.btn_viewDealers.TabIndex = 0;
        this.btn_viewDealers.Text = "View Dealers";
        this.btn_viewDealers.UseVisualStyleBackColor = true;
        this.btn_viewDealers.Click += new System.EventHandler(this.btn_viewDealers_Click);
        // 
        // toolStrip1
        // 
        this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        this.toolStripButton1});
        this.toolStrip1.Location = new System.Drawing.Point(0, 0);
        this.toolStrip1.Name = "toolStrip1";
        this.toolStrip1.Size = new System.Drawing.Size(293, 25);
        this.toolStrip1.TabIndex = 1;
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
        // btn_createNewOrder
        // 
        this.btn_createNewOrder.Font = new System.Drawing.Font("PMingLiU", 14F);
        this.btn_createNewOrder.Location = new System.Drawing.Point(12, 120);
        this.btn_createNewOrder.Name = "btn_createNewOrder";
        this.btn_createNewOrder.Size = new System.Drawing.Size(269, 40);
        this.btn_createNewOrder.TabIndex = 0;
        this.btn_createNewOrder.Text = "Create New Order";
        this.btn_createNewOrder.UseVisualStyleBackColor = true;
        // 
        // btn_viewOrder
        // 
        this.btn_viewOrder.Font = new System.Drawing.Font("PMingLiU", 14F);
        this.btn_viewOrder.Location = new System.Drawing.Point(12, 166);
        this.btn_viewOrder.Name = "btn_viewOrder";
        this.btn_viewOrder.Size = new System.Drawing.Size(269, 40);
        this.btn_viewOrder.TabIndex = 0;
        this.btn_viewOrder.Text = "View Orders";
        this.btn_viewOrder.UseVisualStyleBackColor = true;
        this.btn_viewOrder.Click += new System.EventHandler(this.btn_viewOrder_Click);
        // 
        // SalesOfficerMenu
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(293, 213);
        this.Controls.Add(this.toolStrip1);
        this.Controls.Add(this.btn_viewOrder);
        this.Controls.Add(this.btn_createNewOrder);
        this.Controls.Add(this.btn_viewDealers);
        this.Controls.Add(this.btn_searchSpare);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Name = "SalesOfficerMenu";
        this.Text = "Menu";
        this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SalesOfficerMenu_FormClosed);
        this.toolStrip1.ResumeLayout(false);
        this.toolStrip1.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btn_searchSpare;
    private System.Windows.Forms.Button btn_viewDealers;
    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripButton toolStripButton1;
    private System.Windows.Forms.Button btn_createNewOrder;
    private System.Windows.Forms.Button btn_viewOrder;
}