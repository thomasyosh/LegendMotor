namespace LegendMotor.WinForm;

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
        this.txt_username = new System.Windows.Forms.TextBox();
        this.txt_password = new System.Windows.Forms.TextBox();
        this.lbl_username = new System.Windows.Forms.Label();
        this.lbl_password = new System.Windows.Forms.Label();
        this.btn_login = new System.Windows.Forms.Button();
        this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
        this.pictureBox1 = new System.Windows.Forms.PictureBox();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
        this.SuspendLayout();
        // 
        // txt_username
        // 
        this.txt_username.Font = new System.Drawing.Font("PMingLiU", 16F);
        this.txt_username.Location = new System.Drawing.Point(214, 264);
        this.txt_username.Name = "txt_username";
        this.txt_username.Size = new System.Drawing.Size(291, 33);
        this.txt_username.TabIndex = 1;
        this.txt_username.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnterKeyPress);
        // 
        // txt_password
        // 
        this.txt_password.Font = new System.Drawing.Font("PMingLiU", 16F);
        this.txt_password.Location = new System.Drawing.Point(214, 316);
        this.txt_password.Name = "txt_password";
        this.txt_password.Size = new System.Drawing.Size(291, 33);
        this.txt_password.TabIndex = 2;
        this.txt_password.UseSystemPasswordChar = true;
        this.txt_password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnterKeyPress);
        // 
        // lbl_username
        // 
        this.lbl_username.AutoSize = true;
        this.lbl_username.Font = new System.Drawing.Font("PMingLiU", 16F);
        this.lbl_username.Location = new System.Drawing.Point(109, 267);
        this.lbl_username.Name = "lbl_username";
        this.lbl_username.Size = new System.Drawing.Size(99, 22);
        this.lbl_username.TabIndex = 3;
        this.lbl_username.Text = "Username:";
        // 
        // lbl_password
        // 
        this.lbl_password.AutoSize = true;
        this.lbl_password.Font = new System.Drawing.Font("PMingLiU", 16F);
        this.lbl_password.Location = new System.Drawing.Point(114, 319);
        this.lbl_password.Name = "lbl_password";
        this.lbl_password.Size = new System.Drawing.Size(94, 22);
        this.lbl_password.TabIndex = 4;
        this.lbl_password.Text = "Password:";
        // 
        // btn_login
        // 
        this.btn_login.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.btn_login.Font = new System.Drawing.Font("PMingLiU", 16F);
        this.btn_login.Location = new System.Drawing.Point(0, 369);
        this.btn_login.Name = "btn_login";
        this.btn_login.Size = new System.Drawing.Size(628, 38);
        this.btn_login.TabIndex = 5;
        this.btn_login.Text = "Login";
        this.btn_login.UseVisualStyleBackColor = true;
        this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
        // 
        // pictureBox1
        // 
        this.pictureBox1.Image = global::LegendMotor.WinForm.Properties.Resources.logo;
        this.pictureBox1.Location = new System.Drawing.Point(12, 12);
        this.pictureBox1.Name = "pictureBox1";
        this.pictureBox1.Size = new System.Drawing.Size(604, 246);
        this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
        this.pictureBox1.TabIndex = 6;
        this.pictureBox1.TabStop = false;
        // 
        // LoginForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.AutoSize = true;
        this.ClientSize = new System.Drawing.Size(628, 407);
        this.Controls.Add(this.pictureBox1);
        this.Controls.Add(this.btn_login);
        this.Controls.Add(this.lbl_password);
        this.Controls.Add(this.lbl_username);
        this.Controls.Add(this.txt_password);
        this.Controls.Add(this.txt_username);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "LoginForm";
        this.Text = "Login";
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.TextBox txt_username;
    private System.Windows.Forms.TextBox txt_password;
    private System.Windows.Forms.Label lbl_username;
    private System.Windows.Forms.Label lbl_password;
    private System.Windows.Forms.Button btn_login;
    private System.ComponentModel.BackgroundWorker backgroundWorker1;
    private System.Windows.Forms.PictureBox pictureBox1;
}

