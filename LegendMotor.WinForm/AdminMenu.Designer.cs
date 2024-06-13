namespace LegendMotor.WinForm;

partial class AdminMenu
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminMenu));
        toolStrip1 = new ToolStrip();
        toolStripButton1 = new ToolStripButton();
        btn_addStaff = new Button();
        button1 = new Button();
        accountInfo = new Button();
        toolStrip1.SuspendLayout();
        SuspendLayout();
        // 
        // toolStrip1
        // 
        toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1 });
        toolStrip1.Location = new Point(0, 0);
        toolStrip1.Name = "toolStrip1";
        toolStrip1.Size = new Size(293, 25);
        toolStrip1.TabIndex = 7;
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
        // btn_addStaff
        // 
        btn_addStaff.Font = new Font("新細明體", 14F);
        btn_addStaff.Location = new Point(12, 28);
        btn_addStaff.Name = "btn_addStaff";
        btn_addStaff.Size = new Size(269, 40);
        btn_addStaff.TabIndex = 8;
        btn_addStaff.Text = "Add Staff";
        btn_addStaff.UseVisualStyleBackColor = true;
        btn_addStaff.Click += btn_searchSpare_Click;
        // 
        // button1
        // 
        button1.Font = new Font("新細明體", 14F);
        button1.Location = new Point(12, 74);
        button1.Name = "button1";
        button1.Size = new Size(269, 40);
        button1.TabIndex = 9;
        button1.Text = "Update Staff";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // accountInfo
        // 
        accountInfo.Font = new Font("新細明體", 14F);
        accountInfo.Location = new Point(12, 120);
        accountInfo.Name = "accountInfo";
        accountInfo.Size = new Size(269, 40);
        accountInfo.TabIndex = 10;
        accountInfo.Text = "Account Info";
        accountInfo.UseVisualStyleBackColor = true;
        accountInfo.Click += accountInfo_Click;
        // 
        // AdminMenu
        // 
        AutoScaleDimensions = new SizeF(10F, 19F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(293, 188);
        Controls.Add(accountInfo);
        Controls.Add(button1);
        Controls.Add(btn_addStaff);
        Controls.Add(toolStrip1);
        Font = new Font("新細明體", 14F);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Margin = new Padding(5);
        Name = "AdminMenu";
        Text = "AdminForm";
        FormClosed += AdminMenu_FormClosed_1;
        toolStrip1.ResumeLayout(false);
        toolStrip1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripButton toolStripButton1;
    private System.Windows.Forms.Button btn_addStaff;
    private System.Windows.Forms.Button button1;
    private Button accountInfo;
}