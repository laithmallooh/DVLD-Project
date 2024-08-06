namespace DVLDPresentationLayer
{
    partial class ctrlUserCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            IsActiveOutput = new Label();
            UserNameOutPut = new Label();
            UserIDOutput = new Label();
            IsActiveLabel = new Label();
            UserNameLabel = new Label();
            UserIDLabel = new Label();
            SuspendLayout();
            // 
            // IsActiveOutput
            // 
            IsActiveOutput.AutoSize = true;
            IsActiveOutput.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            IsActiveOutput.Location = new Point(810, 45);
            IsActiveOutput.Name = "IsActiveOutput";
            IsActiveOutput.Size = new Size(51, 28);
            IsActiveOutput.TabIndex = 11;
            IsActiveOutput.Text = "N/A";
            // 
            // UserNameOutPut
            // 
            UserNameOutPut.AutoSize = true;
            UserNameOutPut.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UserNameOutPut.Location = new Point(534, 45);
            UserNameOutPut.Name = "UserNameOutPut";
            UserNameOutPut.Size = new Size(51, 28);
            UserNameOutPut.TabIndex = 10;
            UserNameOutPut.Text = "N/A";
            // 
            // UserIDOutput
            // 
            UserIDOutput.AutoSize = true;
            UserIDOutput.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UserIDOutput.Location = new Point(220, 45);
            UserIDOutput.Name = "UserIDOutput";
            UserIDOutput.Size = new Size(51, 28);
            UserIDOutput.TabIndex = 9;
            UserIDOutput.Text = "N/A";
            // 
            // IsActiveLabel
            // 
            IsActiveLabel.AutoSize = true;
            IsActiveLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            IsActiveLabel.Location = new Point(700, 45);
            IsActiveLabel.Name = "IsActiveLabel";
            IsActiveLabel.Size = new Size(104, 28);
            IsActiveLabel.TabIndex = 8;
            IsActiveLabel.Text = "Is Active :";
            // 
            // UserNameLabel
            // 
            UserNameLabel.AutoSize = true;
            UserNameLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UserNameLabel.Location = new Point(401, 45);
            UserNameLabel.Name = "UserNameLabel";
            UserNameLabel.Size = new Size(127, 28);
            UserNameLabel.TabIndex = 7;
            UserNameLabel.Text = "User Name :";
            // 
            // UserIDLabel
            // 
            UserIDLabel.AutoSize = true;
            UserIDLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UserIDLabel.Location = new Point(122, 45);
            UserIDLabel.Name = "UserIDLabel";
            UserIDLabel.Size = new Size(92, 28);
            UserIDLabel.TabIndex = 6;
            UserIDLabel.Text = "User ID :";
            // 
            // ctrlUserCard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(IsActiveOutput);
            Controls.Add(UserNameOutPut);
            Controls.Add(UserIDOutput);
            Controls.Add(IsActiveLabel);
            Controls.Add(UserNameLabel);
            Controls.Add(UserIDLabel);
            Name = "ctrlUserCard";
            Size = new Size(983, 118);
            Load += ctrlUserCard_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label IsActiveOutput;
        private Label UserNameOutPut;
        private Label UserIDOutput;
        private Label IsActiveLabel;
        private Label UserNameLabel;
        private Label UserIDLabel;
    }
}
