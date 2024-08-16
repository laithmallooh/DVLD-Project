namespace DVLDPresentationLayer
{
    partial class frmShowDetails
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
            PersonalInformation = new GroupBox();
            personCard = new ctrlPersonCard();
            UserInformation = new GroupBox();
            userCard = new ctrlUserCard();
            PersonalInformation.SuspendLayout();
            UserInformation.SuspendLayout();
            SuspendLayout();
            // 
            // PersonalInformation
            // 
            PersonalInformation.Controls.Add(personCard);
            PersonalInformation.Location = new Point(21, 27);
            PersonalInformation.Name = "PersonalInformation";
            PersonalInformation.Size = new Size(1356, 362);
            PersonalInformation.TabIndex = 0;
            PersonalInformation.TabStop = false;
            PersonalInformation.Text = "Personal Information";
            // 
            // personCard
            // 
            personCard.Location = new Point(10, 30);
            personCard.Name = "personCard";
            personCard.Size = new Size(1346, 316);
            personCard.TabIndex = 0;
            // 
            // UserInformation
            // 
            UserInformation.Controls.Add(userCard);
            UserInformation.Location = new Point(21, 440);
            UserInformation.Name = "UserInformation";
            UserInformation.Size = new Size(1356, 149);
            UserInformation.TabIndex = 1;
            UserInformation.TabStop = false;
            UserInformation.Text = "User Information";
            // 
            // userCard
            // 
            userCard.Location = new Point(70, 30);
            userCard.Name = "userCard";
            userCard.Size = new Size(1182, 104);
            userCard.TabIndex = 1;
            // 
            // ShowDetails
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1401, 631);
            Controls.Add(UserInformation);
            Controls.Add(PersonalInformation);
            Name = "ShowDetails";
            Text = "Show Details";
            PersonalInformation.ResumeLayout(false);
            UserInformation.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox PersonalInformation;
        private ctrlPersonCard personCard;
        private GroupBox UserInformation;
        private ctrlUserCard userCard;


    }
}