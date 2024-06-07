namespace LegendMotor.WinForm;

partial class StoremenMenu
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
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StoremenMenu));
        this.toolStrip1 = new System.Windows.Forms.ToolStrip();
        this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
        //this.spareBindingSource = new System.Windows.Forms.BindingSource(this.components);
        //this.easycontrolDataSet2 = new EasyControl.easycontrolDataSet();
        //this.easycontrolDataSet = new EasyControl.easycontrolDataSet();
        //this.staffBindingSource = new System.Windows.Forms.BindingSource(this.components);
        //this.easycontrolDataSet1 = new EasyControl.easycontrolDataSet();
        //this.binLocationSpareBindingSource = new System.Windows.Forms.BindingSource(this.components);
        //this.imcomingOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
        //this.fKSpareBinLocationSpareBindingSource = new System.Windows.Forms.BindingSource(this.components);
        //this.spareSparePriceBindingSource = new System.Windows.Forms.BindingSource(this.components);
        //this.spareSupplierBindingSource = new System.Windows.Forms.BindingSource(this.components);
        this.btn_stock = new System.Windows.Forms.Button();
        this.btn_incomingOrder = new System.Windows.Forms.Button();
        this.btn_purchasingOrder = new System.Windows.Forms.Button();
        this.toolStrip1.SuspendLayout();
        /*((System.ComponentModel.ISupportInitialize)(this.spareBindingSource)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.easycontrolDataSet2)).BeginInit();
       ((System.ComponentModel.ISupportInitialize)(this.easycontrolDataSet)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.staffBindingSource)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.easycontrolDataSet1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.binLocationSpareBindingSource)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.imcomingOrderBindingSource)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.fKSpareBinLocationSpareBindingSource)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.spareSparePriceBindingSource)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.spareSupplierBindingSource)).BeginInit();*/
        this.SuspendLayout();
        // 
        // toolStrip1
        // 
        this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        this.toolStripButton1});
        this.toolStrip1.Location = new System.Drawing.Point(0, 0);
        this.toolStrip1.Name = "toolStrip1";
        this.toolStrip1.Size = new System.Drawing.Size(293, 25);
        this.toolStrip1.TabIndex = 13;
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
        // spareBindingSource
        // 
        //this.spareBindingSource.DataMember = "Spare";
        //this.spareBindingSource.DataSource = this.easycontrolDataSet2;
        // 
        // easycontrolDataSet2
        // 
        //this.easycontrolDataSet2.DataSetName = "easycontrolDataSet";
        //this.easycontrolDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
        // 
        // easycontrolDataSet
        // 
        //this.easycontrolDataSet.DataSetName = "easycontrolDataSet";
       // this.easycontrolDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
        // 
        // staffBindingSource
        // 
        //this.staffBindingSource.DataMember = "Staff";
        //this.staffBindingSource.DataSource = this.easycontrolDataSet;
        // 
        // easycontrolDataSet1
        // 
       // this.easycontrolDataSet1.DataSetName = "easycontrolDataSet";
       // this.easycontrolDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
        // 
        // binLocationSpareBindingSource
        // 
        //this.binLocationSpareBindingSource.DataMember = "BinLocation_Spare";
        //this.binLocationSpareBindingSource.DataSource = this.easycontrolDataSet2;
        // 
        // imcomingOrderBindingSource
        // 
        //this.imcomingOrderBindingSource.DataMember = "ImcomingOrder";
       // this.imcomingOrderBindingSource.DataSource = this.easycontrolDataSet2;
        // 
        // fKSpareBinLocationSpareBindingSource
        // 
        //this.fKSpareBinLocationSpareBindingSource.DataMember = "FK_Spare_BinLocation_Spare";
        //this.fKSpareBinLocationSpareBindingSource.DataSource = this.spareBindingSource;
        // 
        // spareSparePriceBindingSource
        // 
       // this.spareSparePriceBindingSource.DataMember = "Spare_SparePrice";
       // this.spareSparePriceBindingSource.DataSource = this.spareBindingSource;
        // 
        // spareSupplierBindingSource
        // 
        //this.spareSupplierBindingSource.DataMember = "Spare_Supplier";
        //this.spareSupplierBindingSource.DataSource = this.spareBindingSource;
        // 
        // btn_stock
        // 
        this.btn_stock.Font = new System.Drawing.Font("PMingLiU", 14F);
        this.btn_stock.Location = new System.Drawing.Point(12, 28);
        this.btn_stock.Name = "btn_stock";
        this.btn_stock.Size = new System.Drawing.Size(269, 40);
        this.btn_stock.TabIndex = 14;
        this.btn_stock.Text = "View Stocks";
        this.btn_stock.UseVisualStyleBackColor = true;
        this.btn_stock.Click += new System.EventHandler(this.btn_stock_Click);
        // 
        // btn_incomingOrder
        // 
        this.btn_incomingOrder.Font = new System.Drawing.Font("PMingLiU", 14F);
        this.btn_incomingOrder.Location = new System.Drawing.Point(12, 74);
        this.btn_incomingOrder.Name = "btn_incomingOrder";
        this.btn_incomingOrder.Size = new System.Drawing.Size(269, 40);
        this.btn_incomingOrder.TabIndex = 15;
        this.btn_incomingOrder.Text = "View Incoming Orders";
        this.btn_incomingOrder.UseVisualStyleBackColor = true;
        this.btn_incomingOrder.Click += new System.EventHandler(this.btn_incomingOrder_Click);
        // 
        // btn_purchasingOrder
        // 
        this.btn_purchasingOrder.Font = new System.Drawing.Font("PMingLiU", 14F);
        this.btn_purchasingOrder.Location = new System.Drawing.Point(12, 120);
        this.btn_purchasingOrder.Name = "btn_purchasingOrder";
        this.btn_purchasingOrder.Size = new System.Drawing.Size(269, 40);
        this.btn_purchasingOrder.TabIndex = 16;
        this.btn_purchasingOrder.Text = "View Purchasing Orders";
        this.btn_purchasingOrder.UseVisualStyleBackColor = true;
        this.btn_purchasingOrder.Click += new System.EventHandler(this.btn_purchasingOrder_Click);
        // 
        // StoremenMenu
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(293, 171);
        this.Controls.Add(this.btn_purchasingOrder);
        this.Controls.Add(this.btn_incomingOrder);
        this.Controls.Add(this.btn_stock);
        this.Controls.Add(this.toolStrip1);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Name = "StoremenMenu";
        this.Text = "Menu";
        this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StoremenMenu_FormClosed);
        this.toolStrip1.ResumeLayout(false);
        this.toolStrip1.PerformLayout();
        /*((System.ComponentModel.ISupportInitialize)(this.spareBindingSource)).EndInit();
        //((System.ComponentModel.ISupportInitialize)(this.easycontrolDataSet2)).EndInit();
       // ((System.ComponentModel.ISupportInitialize)(this.easycontrolDataSet)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.staffBindingSource)).EndInit();
       // ((System.ComponentModel.ISupportInitialize)(this.easycontrolDataSet1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.binLocationSpareBindingSource)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.imcomingOrderBindingSource)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.fKSpareBinLocationSpareBindingSource)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.spareSparePriceBindingSource)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.spareSupplierBindingSource)).EndInit();*/
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripButton toolStripButton1;
    //private easycontrolDataSet easycontrolDataSet;
    private System.Windows.Forms.BindingSource staffBindingSource;
    //private easycontrolDataSet easycontrolDataSet1;
    //private easycontrolDataSet easycontrolDataSet2;
    private System.Windows.Forms.BindingSource binLocationSpareBindingSource;
    private System.Windows.Forms.BindingSource spareBindingSource;
    private System.Windows.Forms.BindingSource fKSpareBinLocationSpareBindingSource;
    private System.Windows.Forms.BindingSource spareSparePriceBindingSource;
    private System.Windows.Forms.BindingSource spareSupplierBindingSource;
    private System.Windows.Forms.BindingSource imcomingOrderBindingSource;
    private System.Windows.Forms.Button btn_stock;
    private System.Windows.Forms.Button btn_incomingOrder;
    private System.Windows.Forms.Button btn_purchasingOrder;
}