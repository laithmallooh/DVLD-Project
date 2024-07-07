namespace DVLDPresentationLayer
{
    partial class LoginScreen
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
            CloseButton = new Button();
            LoginButton = new Button();
            TitleLabel = new Label();
            LoginPicture = new PictureBox();
            UsernameLabel = new Label();
            PasswordLabel = new Label();
            UsernameTextBox = new TextBox();
            PasswordTextBox = new TextBox();
            RemembermeCheckBox = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)LoginPicture).BeginInit();
            SuspendLayout();
            // 
            // CloseButton
            // 
            CloseButton.Image = Properties.Resources.close;
            CloseButton.Location = new Point(1182, 12);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(94, 71);
            CloseButton.TabIndex = 0;
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CloseButton_Click;
            // 
            // LoginButton
            // 
            LoginButton.Image = Properties.Resources.login_;
            LoginButton.ImageAlign = ContentAlignment.MiddleLeft;
            LoginButton.Location = new Point(1084, 472);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(120, 45);
            LoginButton.TabIndex = 1;
            LoginButton.Text = "Login";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += LoginButton_Click;
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TitleLabel.Location = new Point(877, 148);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(311, 38);
            TitleLabel.TabIndex = 2;
            TitleLabel.Text = "Login To Your Account";
            TitleLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // LoginPicture
            // 
            LoginPicture.BackgroundImageLayout = ImageLayout.Center;
            LoginPicture.Image = Properties.Resources._6310507;
            LoginPicture.Location = new Point(-96, -30);
            LoginPicture.Name = "LoginPicture";
            LoginPicture.Size = new Size(850, 847);
            LoginPicture.SizeMode = PictureBoxSizeMode.Zoom;
            LoginPicture.TabIndex = 3;
            LoginPicture.TabStop = false;
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UsernameLabel.Location = new Point(790, 277);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(121, 32);
            UsernameLabel.TabIndex = 4;
            UsernameLabel.Text = "Username";
            UsernameLabel.TextAlign = ContentAlignment.TopCenter;
            UsernameLabel.Click += label1_Click;
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PasswordLabel.Location = new Point(790, 337);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(111, 32);
            PasswordLabel.TabIndex = 5;
            PasswordLabel.Text = "Password";
            PasswordLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // UsernameTextBox
            // 
            UsernameTextBox.Location = new Point(955, 280);
            UsernameTextBox.Name = "UsernameTextBox";
            UsernameTextBox.Size = new Size(249, 31);
            UsernameTextBox.TabIndex = 6;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(955, 337);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(249, 31);
            PasswordTextBox.TabIndex = 7;
            // 
            // RemembermeCheckBox
            // 
            RemembermeCheckBox.AutoSize = true;
            RemembermeCheckBox.Location = new Point(955, 405);
            RemembermeCheckBox.Name = "RemembermeCheckBox";
            RemembermeCheckBox.Size = new Size(154, 29);
            RemembermeCheckBox.TabIndex = 8;
            RemembermeCheckBox.Text = "Remember Me";
            RemembermeCheckBox.UseVisualStyleBackColor = true;
            // 
            // LoginScreen
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1288, 796);
            ControlBox = false;
            Controls.Add(RemembermeCheckBox);
            Controls.Add(PasswordTextBox);
            Controls.Add(UsernameTextBox);
            Controls.Add(PasswordLabel);
            Controls.Add(UsernameLabel);
            Controls.Add(LoginPicture);
            Controls.Add(TitleLabel);
            Controls.Add(LoginButton);
            Controls.Add(CloseButton);
            Name = "LoginScreen";
            ((System.ComponentModel.ISupportInitialize)LoginPicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button CloseButton;
        private Button LoginButton;
        private Label TitleLabel;
        private PictureBox LoginPicture;
        private Label UsernameLabel;
        private Label PasswordLabel;
        private TextBox UsernameTextBox;
        private TextBox PasswordTextBox;
        private CheckBox RemembermeCheckBox;
    }
}