namespace LegendMotor.WinForm;

partial class UpdateStaffForm
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
        radioButton2 = new RadioButton();
        radioButton1 = new RadioButton();
        label9 = new Label();
        button1 = new Button();
        textBox5 = new TextBox();
        label8 = new Label();
        comboBox3 = new ComboBox();
        label7 = new Label();
        button2 = new Button();
        comboBox2 = new ComboBox();
        comboBox1 = new ComboBox();
        label6 = new Label();
        label5 = new Label();
        textBox4 = new TextBox();
        label4 = new Label();
        textBox3 = new TextBox();
        label3 = new Label();
        textBox2 = new TextBox();
        label2 = new Label();
        label1 = new Label();
        comboBox4 = new ComboBox();
        label10 = new Label();
        comboBox5 = new ComboBox();
        SuspendLayout();
        // 
        // radioButton2
        // 
        radioButton2.AutoSize = true;
        radioButton2.Location = new Point(207, 140);
        radioButton2.Name = "radioButton2";
        radioButton2.Size = new Size(80, 23);
        radioButton2.TabIndex = 42;
        radioButton2.TabStop = true;
        radioButton2.Text = "Female";
        radioButton2.UseVisualStyleBackColor = true;
        radioButton2.CheckedChanged += radioButton2_CheckedChanged;
        // 
        // radioButton1
        // 
        radioButton1.AutoSize = true;
        radioButton1.Location = new Point(127, 140);
        radioButton1.Name = "radioButton1";
        radioButton1.Size = new Size(64, 23);
        radioButton1.TabIndex = 41;
        radioButton1.TabStop = true;
        radioButton1.Text = "Male";
        radioButton1.UseVisualStyleBackColor = true;
        radioButton1.CheckedChanged += radioButton1_CheckedChanged;
        // 
        // label9
        // 
        label9.AutoSize = true;
        label9.Location = new Point(12, 140);
        label9.Name = "label9";
        label9.Size = new Size(72, 19);
        label9.TabIndex = 40;
        label9.Text = "Gender: ";
        // 
        // button1
        // 
        button1.Font = new Font("新細明體", 14F);
        button1.Location = new Point(15, 465);
        button1.Name = "button1";
        button1.Size = new Size(263, 43);
        button1.TabIndex = 39;
        button1.Text = "Reset password";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // textBox5
        // 
        textBox5.Enabled = false;
        textBox5.Location = new Point(127, 94);
        textBox5.Name = "textBox5";
        textBox5.Size = new Size(312, 30);
        textBox5.TabIndex = 38;
        // 
        // label8
        // 
        label8.AutoSize = true;
        label8.Location = new Point(12, 97);
        label8.Name = "label8";
        label8.Size = new Size(83, 19);
        label8.TabIndex = 37;
        label8.Text = "Password:";
        // 
        // comboBox3
        // 
        comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox3.FormattingEnabled = true;
        comboBox3.Location = new Point(127, 414);
        comboBox3.Name = "comboBox3";
        comboBox3.Size = new Size(263, 27);
        comboBox3.TabIndex = 36;
        comboBox3.Visible = false;
        comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
        // 
        // label7
        // 
        label7.AutoSize = true;
        label7.Location = new Point(12, 417);
        label7.Name = "label7";
        label7.Size = new Size(109, 19);
        label7.TabIndex = 35;
        label7.Text = "Bin Location:";
        label7.Visible = false;
        label7.Click += label7_Click;
        // 
        // button2
        // 
        button2.Location = new Point(312, 465);
        button2.Name = "button2";
        button2.Size = new Size(263, 43);
        button2.TabIndex = 34;
        button2.Text = "Update";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // comboBox2
        // 
        comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox2.FormattingEnabled = true;
        comboBox2.Location = new Point(127, 313);
        comboBox2.Name = "comboBox2";
        comboBox2.Size = new Size(263, 27);
        comboBox2.TabIndex = 33;
        comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
        // 
        // comboBox1
        // 
        comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox1.FormattingEnabled = true;
        comboBox1.Location = new Point(127, 262);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new Size(263, 27);
        comboBox1.TabIndex = 32;
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Location = new Point(12, 316);
        label6.Name = "label6";
        label6.Size = new Size(54, 19);
        label6.TabIndex = 31;
        label6.Text = "Area: ";
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(12, 265);
        label5.Name = "label5";
        label5.Size = new Size(78, 19);
        label5.TabIndex = 30;
        label5.Text = "Position: ";
        // 
        // textBox4
        // 
        textBox4.Location = new Point(127, 52);
        textBox4.Name = "textBox4";
        textBox4.Size = new Size(448, 30);
        textBox4.TabIndex = 29;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(14, 13);
        label4.Name = "label4";
        label4.Size = new Size(62, 19);
        label4.TabIndex = 28;
        label4.Text = "Email: ";
        // 
        // textBox3
        // 
        textBox3.Location = new Point(127, 169);
        textBox3.Name = "textBox3";
        textBox3.Size = new Size(448, 30);
        textBox3.TabIndex = 27;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(12, 176);
        label3.Name = "label3";
        label3.Size = new Size(73, 19);
        label3.TabIndex = 26;
        label3.Text = "Address:";
        // 
        // textBox2
        // 
        textBox2.Location = new Point(127, 216);
        textBox2.Name = "textBox2";
        textBox2.Size = new Size(448, 30);
        textBox2.TabIndex = 25;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(12, 219);
        label2.Name = "label2";
        label2.Size = new Size(64, 19);
        label2.TabIndex = 24;
        label2.Text = "Phone: ";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(12, 55);
        label1.Name = "label1";
        label1.Size = new Size(62, 19);
        label1.TabIndex = 22;
        label1.Text = "Name: ";
        // 
        // comboBox4
        // 
        comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox4.FormattingEnabled = true;
        comboBox4.Location = new Point(127, 10);
        comboBox4.Name = "comboBox4";
        comboBox4.Size = new Size(448, 27);
        comboBox4.TabIndex = 43;
        comboBox4.SelectedValueChanged += comboBox4_SelectedValueChanged;
        // 
        // label10
        // 
        label10.AutoSize = true;
        label10.Font = new Font("新細明體", 14F, FontStyle.Bold);
        label10.Location = new Point(14, 366);
        label10.Name = "label10";
        label10.Size = new Size(109, 19);
        label10.TabIndex = 44;
        label10.Text = "Active user:";
        // 
        // comboBox5
        // 
        comboBox5.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox5.FormattingEnabled = true;
        comboBox5.Location = new Point(127, 363);
        comboBox5.Name = "comboBox5";
        comboBox5.Size = new Size(263, 27);
        comboBox5.TabIndex = 45;
        comboBox5.SelectedIndexChanged += comboBox5_SelectedIndexChanged;
        // 
        // UpdateStaffForm
        // 
        AutoScaleDimensions = new SizeF(10F, 19F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(587, 528);
        Controls.Add(comboBox5);
        Controls.Add(label10);
        Controls.Add(comboBox4);
        Controls.Add(radioButton2);
        Controls.Add(radioButton1);
        Controls.Add(label9);
        Controls.Add(button1);
        Controls.Add(textBox5);
        Controls.Add(label8);
        Controls.Add(comboBox3);
        Controls.Add(label7);
        Controls.Add(button2);
        Controls.Add(comboBox2);
        Controls.Add(comboBox1);
        Controls.Add(label6);
        Controls.Add(label5);
        Controls.Add(textBox4);
        Controls.Add(label4);
        Controls.Add(textBox3);
        Controls.Add(label3);
        Controls.Add(textBox2);
        Controls.Add(label2);
        Controls.Add(label1);
        Font = new Font("新細明體", 14F);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Margin = new Padding(5);
        Name = "UpdateStaffForm";
        Text = "Update Staff";
        Load += UpdateStaffForm_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.RadioButton radioButton2;
    private System.Windows.Forms.RadioButton radioButton1;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.TextBox textBox5;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.ComboBox comboBox3;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.ComboBox comboBox2;
    private System.Windows.Forms.ComboBox comboBox1;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox textBox4;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox textBox3;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox comboBox4;
    private Label label10;
    private ComboBox comboBox5;
}