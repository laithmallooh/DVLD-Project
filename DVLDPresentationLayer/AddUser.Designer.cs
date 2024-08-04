namespace DVLDPresentationLayer
{
    partial class AddUser
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
            panel1 = new Panel();
            ctrlPersonCardWithFilter1 = new ctrlPersonCardWithFilter();
            tabControl1 = new TabControl();
            PersonalInfo = new TabPage();
            NextButton = new Button();
            LoginInfo = new TabPage();
            UserIDLabel = new Label();
            IsActiveCheckBox = new CheckBox();
            ConfirmPasswordInput = new TextBox();
            PasswordInput = new TextBox();
            UserNameInput = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            NationalNo = new Label();
            SaveButton = new Button();
            CloseButton = new Button();
            label4 = new Label();
            dataGridView1 = new DataGridView();
            tabControl1.SuspendLayout();
            PersonalInfo.SuspendLayout();
            LoginInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Location = new Point(55, 205);
            panel1.Name = "panel1";
            panel1.Size = new Size(1325, 339);
            panel1.TabIndex = 0;
            // 
            // ctrlPersonCardWithFilter1
            // 
            ctrlPersonCardWithFilter1.Location = new Point(3, 3);
            ctrlPersonCardWithFilter1.Name = "ctrlPersonCardWithFilter1";
            ctrlPersonCardWithFilter1.SelectedPersonId = null;
            ctrlPersonCardWithFilter1.Size = new Size(1512, 559);
            ctrlPersonCardWithFilter1.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(PersonalInfo);
            tabControl1.Controls.Add(LoginInfo);
            tabControl1.Location = new Point(34, 92);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1519, 655);
            tabControl1.TabIndex = 0;
            // 
            // PersonalInfo
            // 
            PersonalInfo.Controls.Add(panel1);
            PersonalInfo.Controls.Add(NextButton);
            PersonalInfo.Controls.Add(ctrlPersonCardWithFilter1);
            PersonalInfo.Location = new Point(4, 34);
            PersonalInfo.Name = "PersonalInfo";
            PersonalInfo.Padding = new Padding(3);
            PersonalInfo.Size = new Size(1511, 617);
            PersonalInfo.TabIndex = 0;
            PersonalInfo.Text = "Personal Info";
            PersonalInfo.UseVisualStyleBackColor = true;
            // 
            // NextButton
            // 
            NextButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NextButton.Image = Properties.Resources.next;
            NextButton.ImageAlign = ContentAlignment.MiddleRight;
            NextButton.Location = new Point(956, 561);
            NextButton.Name = "NextButton";
            NextButton.Size = new Size(152, 49);
            NextButton.TabIndex = 1;
            NextButton.Text = "Next";
            NextButton.UseVisualStyleBackColor = true;
            NextButton.Click += NextButton_Click;
            // 
            // LoginInfo
            // 
            LoginInfo.Controls.Add(UserIDLabel);
            LoginInfo.Controls.Add(IsActiveCheckBox);
            LoginInfo.Controls.Add(ConfirmPasswordInput);
            LoginInfo.Controls.Add(PasswordInput);
            LoginInfo.Controls.Add(UserNameInput);
            LoginInfo.Controls.Add(label3);
            LoginInfo.Controls.Add(label2);
            LoginInfo.Controls.Add(label1);
            LoginInfo.Controls.Add(NationalNo);
            LoginInfo.Location = new Point(4, 34);
            LoginInfo.Name = "LoginInfo";
            LoginInfo.Padding = new Padding(3);
            LoginInfo.Size = new Size(1511, 617);
            LoginInfo.TabIndex = 1;
            LoginInfo.Text = "Login Info";
            LoginInfo.UseVisualStyleBackColor = true;
            // 
            // UserIDLabel
            // 
            UserIDLabel.AutoSize = true;
            UserIDLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UserIDLabel.Location = new Point(322, 164);
            UserIDLabel.Name = "UserIDLabel";
            UserIDLabel.Size = new Size(51, 28);
            UserIDLabel.TabIndex = 11;
            UserIDLabel.Text = "N\\A";
            // 
            // IsActiveCheckBox
            // 
            IsActiveCheckBox.AutoSize = true;
            IsActiveCheckBox.Location = new Point(322, 413);
            IsActiveCheckBox.Name = "IsActiveCheckBox";
            IsActiveCheckBox.Size = new Size(104, 29);
            IsActiveCheckBox.TabIndex = 10;
            IsActiveCheckBox.Text = "Is Active";
            IsActiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // ConfirmPasswordInput
            // 
            ConfirmPasswordInput.Location = new Point(322, 329);
            ConfirmPasswordInput.Name = "ConfirmPasswordInput";
            ConfirmPasswordInput.Size = new Size(150, 31);
            ConfirmPasswordInput.TabIndex = 9;
            // 
            // PasswordInput
            // 
            PasswordInput.Location = new Point(322, 277);
            PasswordInput.Name = "PasswordInput";
            PasswordInput.Size = new Size(150, 31);
            PasswordInput.TabIndex = 8;
            // 
            // UserNameInput
            // 
            UserNameInput.Location = new Point(322, 218);
            UserNameInput.Name = "UserNameInput";
            UserNameInput.Size = new Size(150, 31);
            UserNameInput.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(90, 332);
            label3.Name = "label3";
            label3.Size = new Size(194, 28);
            label3.TabIndex = 5;
            label3.Text = "Confirm Password :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(90, 277);
            label2.Name = "label2";
            label2.Size = new Size(112, 28);
            label2.TabIndex = 4;
            label2.Text = "Password :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(90, 221);
            label1.Name = "label1";
            label1.Size = new Size(127, 28);
            label1.TabIndex = 3;
            label1.Text = "User Name :";
            // 
            // NationalNo
            // 
            NationalNo.AutoSize = true;
            NationalNo.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NationalNo.Location = new Point(90, 164);
            NationalNo.Name = "NationalNo";
            NationalNo.Size = new Size(92, 28);
            NationalNo.TabIndex = 2;
            NationalNo.Text = "User ID :";
            // 
            // SaveButton
            // 
            SaveButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SaveButton.Image = Properties.Resources.diskette;
            SaveButton.ImageAlign = ContentAlignment.MiddleRight;
            SaveButton.Location = new Point(994, 753);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(152, 49);
            SaveButton.TabIndex = 2;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            // 
            // CloseButton
            // 
            CloseButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CloseButton.Image = Properties.Resources.icons8_close_40;
            CloseButton.ImageAlign = ContentAlignment.MiddleRight;
            CloseButton.Location = new Point(826, 753);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(152, 49);
            CloseButton.TabIndex = 3;
            CloseButton.Text = "Close";
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CloseButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(485, 35);
            label4.Name = "label4";
            label4.Size = new Size(294, 54);
            label4.TabIndex = 4;
            label4.Text = "Add New User";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(776, 426);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // AddUser
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1565, 823);
            Controls.Add(label4);
            Controls.Add(CloseButton);
            Controls.Add(SaveButton);
            Controls.Add(tabControl1);
            Controls.Add(dataGridView1);
            Name = "AddUser";
            ShowIcon = false;
            Text = "Add New User";
            tabControl1.ResumeLayout(false);
            PersonalInfo.ResumeLayout(false);
            LoginInfo.ResumeLayout(false);
            LoginInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();



            // In the constructor or InitializeComponent method
            btnCheckState = new Button();
            btnCheckState.Text = "Check State";
            btnCheckState.Location = new Point(/* set appropriate location */);
            btnCheckState.Click += BtnCheckState_Click;
            this.Controls.Add(btnCheckState);


        }

        #endregion

        private TabControl tabControl1;
        private TabPage PersonalInfo;
        private TabPage LoginInfo;
        private Button NextButton;
        private ctrlPersonCardWithFilter ctrlPersonCardWithFilter1;
        private Button SaveButton;
        private Button CloseButton;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label NationalNo;
        private CheckBox IsActiveCheckBox;
        private TextBox ConfirmPasswordInput;
        private TextBox PasswordInput;
        private TextBox UserNameInput;
        private Label label4;
        private Label UserIDLabel;
        private Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Button btnCheckState;



    }
}