﻿namespace LegendMotor.WinForm;

partial class LoginForm
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
        txt_username = new TextBox();
        txt_password = new TextBox();
        lbl_username = new Label();
        lbl_password = new Label();
        btn_login = new Button();
        backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
        pictureBox1 = new PictureBox();
        label1 = new Label();
        btn_cancel = new Button();
        checkBox1 = new CheckBox();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // txt_username
        // 
        txt_username.Font = new Font("新細明體", 16F);
        txt_username.Location = new Point(198, 320);
        txt_username.Margin = new Padding(4);
        txt_username.Name = "txt_username";
        txt_username.Size = new Size(339, 33);
        txt_username.TabIndex = 1;
        txt_username.KeyPress += CheckEnterKeyPress;
        // 
        // txt_password
        // 
        txt_password.Font = new Font("新細明體", 16F);
        txt_password.Location = new Point(198, 375);
        txt_password.Margin = new Padding(4);
        txt_password.Name = "txt_password";
        txt_password.Size = new Size(339, 33);
        txt_password.TabIndex = 2;
        txt_password.UseSystemPasswordChar = true;
        txt_password.KeyPress += CheckEnterKeyPress;
        // 
        // lbl_username
        // 
        lbl_username.AutoSize = true;
        lbl_username.Font = new Font("新細明體", 16F);
        lbl_username.Location = new Point(75, 324);
        lbl_username.Margin = new Padding(4, 0, 4, 0);
        lbl_username.Name = "lbl_username";
        lbl_username.Size = new Size(99, 22);
        lbl_username.TabIndex = 3;
        lbl_username.Text = "Username:";
        // 
        // lbl_password
        // 
        lbl_password.AutoSize = true;
        lbl_password.Font = new Font("新細明體", 16F);
        lbl_password.Location = new Point(81, 379);
        lbl_password.Margin = new Padding(4, 0, 4, 0);
        lbl_password.Name = "lbl_password";
        lbl_password.Size = new Size(94, 22);
        lbl_password.TabIndex = 4;
        lbl_password.Text = "Password:";
        // 
        // btn_login
        // 
        btn_login.Font = new Font("新細明體", 16F);
        btn_login.Location = new Point(104, 442);
        btn_login.Margin = new Padding(4);
        btn_login.Name = "btn_login";
        btn_login.Size = new Size(200, 48);
        btn_login.TabIndex = 5;
        btn_login.Text = "Login";
        btn_login.UseVisualStyleBackColor = true;
        btn_login.Click += btn_login_Click;
        // 
        // pictureBox1
        // 
        pictureBox1.Image = Properties.Resources.logo;
        pictureBox1.Location = new Point(14, 3);
        pictureBox1.Margin = new Padding(4);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(705, 298);
        pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
        pictureBox1.TabIndex = 6;
        pictureBox1.TabStop = false;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.BackColor = Color.White;
        label1.Font = new Font("標楷體", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
        label1.Location = new Point(188, 246);
        label1.Margin = new Padding(4, 0, 4, 0);
        label1.Name = "label1";
        label1.Size = new Size(339, 35);
        label1.TabIndex = 7;
        label1.Text = "學海無涯　回頭是岸";
        // 
        // btn_cancel
        // 
        btn_cancel.Font = new Font("新細明體", 16F);
        btn_cancel.Location = new Point(392, 442);
        btn_cancel.Margin = new Padding(4);
        btn_cancel.Name = "btn_cancel";
        btn_cancel.Size = new Size(200, 48);
        btn_cancel.TabIndex = 8;
        btn_cancel.Text = "Cancel";
        btn_cancel.UseVisualStyleBackColor = true;
        btn_cancel.Click += btn_cancel_Click;
        // 
        // checkBox1
        // 
        checkBox1.AutoSize = true;
        checkBox1.Font = new Font("新細明體", 12F);
        checkBox1.Location = new Point(562, 382);
        checkBox1.Name = "checkBox1";
        checkBox1.Size = new Size(124, 20);
        checkBox1.TabIndex = 9;
        checkBox1.Text = "Show password";
        checkBox1.UseVisualStyleBackColor = true;
        checkBox1.CheckedChanged += checkBox1_CheckedChanged;
        // 
        // LoginForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoSize = true;
        ClientSize = new Size(733, 509);
        Controls.Add(checkBox1);
        Controls.Add(btn_cancel);
        Controls.Add(label1);
        Controls.Add(pictureBox1);
        Controls.Add(btn_login);
        Controls.Add(lbl_password);
        Controls.Add(lbl_username);
        Controls.Add(txt_password);
        Controls.Add(txt_username);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Margin = new Padding(4);
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "LoginForm";
        Text = "Login";
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private System.Windows.Forms.TextBox txt_username;
    private System.Windows.Forms.TextBox txt_password;
    private System.Windows.Forms.Label lbl_username;
    private System.Windows.Forms.Label lbl_password;
    private System.Windows.Forms.Button btn_login;
    private System.ComponentModel.BackgroundWorker backgroundWorker1;
    private System.Windows.Forms.PictureBox pictureBox1;
    private Label label1;
    private Button btn_cancel;
    private CheckBox checkBox1;
}

