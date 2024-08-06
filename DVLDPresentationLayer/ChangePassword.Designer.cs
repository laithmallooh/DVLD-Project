namespace DVLDPresentationLayer
{
    partial class ChangePassword
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
            PersonInformation = new GroupBox();
            ctrlPersonCard = new ctrlPersonCard();
            LoginInformation = new GroupBox();
            ctrlUserCard = new ctrlUserCard();
            CurrentPasswordLabel = new Label();
            NewPasswordLabel = new Label();
            ConfirmPasswordLabel = new Label();
            CurrentPasswordInput = new TextBox();
            NewPasswordInput = new TextBox();
            ConfirmPasswordInput = new TextBox();
            CloseButton = new Button();
            SaveButton = new Button();
            PersonInformation.SuspendLayout();
            LoginInformation.SuspendLayout();
            SuspendLayout();
            // 
            // PersonInformation
            // 
            PersonInformation.Controls.Add(ctrlPersonCard);
            PersonInformation.Location = new Point(23, 22);
            PersonInformation.Name = "PersonInformation";
            PersonInformation.Size = new Size(1397, 388);
            PersonInformation.TabIndex = 0;
            PersonInformation.TabStop = false;
            PersonInformation.Text = "Person Information";
            // 
            // ctrlPersonCard
            // 
            ctrlPersonCard.Location = new Point(21, 44);
            ctrlPersonCard.Name = "ctrlPersonCard";
            ctrlPersonCard.Size = new Size(1358, 323);
            ctrlPersonCard.TabIndex = 0;
            ctrlPersonCard.Load += ctrlPersonCard_Load;
            // 
            // LoginInformation
            // 
            LoginInformation.Controls.Add(ctrlUserCard);
            LoginInformation.Location = new Point(33, 454);
            LoginInformation.Name = "LoginInformation";
            LoginInformation.Size = new Size(1387, 150);
            LoginInformation.TabIndex = 1;
            LoginInformation.TabStop = false;
            LoginInformation.Text = "Login Information";
            // 
            // ctrlUserCard
            // 
            ctrlUserCard.Location = new Point(220, 30);
            ctrlUserCard.Name = "ctrlUserCard";
            ctrlUserCard.Size = new Size(877, 99);
            ctrlUserCard.TabIndex = 0;
            // 
            // CurrentPasswordLabel
            // 
            CurrentPasswordLabel.AutoSize = true;
            CurrentPasswordLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CurrentPasswordLabel.Location = new Point(148, 720);
            CurrentPasswordLabel.Name = "CurrentPasswordLabel";
            CurrentPasswordLabel.Size = new Size(216, 32);
            CurrentPasswordLabel.TabIndex = 2;
            CurrentPasswordLabel.Text = "Current Password";
            // 
            // NewPasswordLabel
            // 
            NewPasswordLabel.AutoSize = true;
            NewPasswordLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NewPasswordLabel.Location = new Point(148, 775);
            NewPasswordLabel.Name = "NewPasswordLabel";
            NewPasswordLabel.Size = new Size(180, 32);
            NewPasswordLabel.TabIndex = 3;
            NewPasswordLabel.Text = "New Password";
            // 
            // ConfirmPasswordLabel
            // 
            ConfirmPasswordLabel.AutoSize = true;
            ConfirmPasswordLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ConfirmPasswordLabel.Location = new Point(148, 832);
            ConfirmPasswordLabel.Name = "ConfirmPasswordLabel";
            ConfirmPasswordLabel.Size = new Size(222, 32);
            ConfirmPasswordLabel.TabIndex = 4;
            ConfirmPasswordLabel.Text = "Confirm Password";
            // 
            // CurrentPasswordInput
            // 
            CurrentPasswordInput.Location = new Point(414, 723);
            CurrentPasswordInput.Name = "CurrentPasswordInput";
            CurrentPasswordInput.Size = new Size(253, 31);
            CurrentPasswordInput.TabIndex = 5;
            // 
            // NewPasswordInput
            // 
            NewPasswordInput.Location = new Point(414, 778);
            NewPasswordInput.Name = "NewPasswordInput";
            NewPasswordInput.Size = new Size(253, 31);
            NewPasswordInput.TabIndex = 6;
            // 
            // ConfirmPasswordInput
            // 
            ConfirmPasswordInput.Location = new Point(414, 835);
            ConfirmPasswordInput.Name = "ConfirmPasswordInput";
            ConfirmPasswordInput.Size = new Size(253, 31);
            ConfirmPasswordInput.TabIndex = 7;
            // 
            // CloseButton
            // 
            CloseButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CloseButton.Image = Properties.Resources.icons8_close_40;
            CloseButton.ImageAlign = ContentAlignment.MiddleRight;
            CloseButton.Location = new Point(810, 1001);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(152, 49);
            CloseButton.TabIndex = 9;
            CloseButton.Text = "Close";
            CloseButton.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            SaveButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SaveButton.Image = Properties.Resources.diskette;
            SaveButton.ImageAlign = ContentAlignment.MiddleRight;
            SaveButton.Location = new Point(978, 1001);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(152, 49);
            SaveButton.TabIndex = 8;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;

            // Initialize and add ctrlUserCard
            ctrlUserCard = new ctrlUserCard();
            ctrlUserCard.Location = new Point(220, 30);
            ctrlUserCard.Name = "ctrlUserCard";
            ctrlUserCard.Size = new Size(877, 99);
            LoginInformation.Controls.Add(ctrlUserCard);

            // 
            // ChangePassword
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1442, 1074);
            Controls.Add(CloseButton);
            Controls.Add(SaveButton);
            Controls.Add(ConfirmPasswordInput);
            Controls.Add(NewPasswordInput);
            Controls.Add(CurrentPasswordInput);
            Controls.Add(ConfirmPasswordLabel);
            Controls.Add(NewPasswordLabel);
            Controls.Add(CurrentPasswordLabel);
            Controls.Add(LoginInformation);
            Controls.Add(PersonInformation);
            Name = "ChangePassword";
            ShowIcon = false;
            Text = "Change Password";
            PersonInformation.ResumeLayout(false);
            LoginInformation.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox PersonInformation;
        private ctrlPersonCard ctrlPersonCard;
        private GroupBox LoginInformation;
        private ctrlUserCard ctrlUserCard;
        private Label CurrentPasswordLabel;
        private Label NewPasswordLabel;
        private Label ConfirmPasswordLabel;
        private TextBox CurrentPasswordInput;
        private TextBox NewPasswordInput;
        private TextBox ConfirmPasswordInput;
        private Button CloseButton;
        private Button SaveButton;
    }
}