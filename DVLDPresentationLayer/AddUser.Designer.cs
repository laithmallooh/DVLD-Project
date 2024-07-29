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
            tabControl1 = new TabControl();
            PersonalInfo = new TabPage();
            NextButton = new Button();
            ctrlPersonCardWithFilter1 = new ctrlPersonCardWithFilter();
            LoginInfo = new TabPage();
            SaveButton = new Button();
            CloseButton = new Button();
            NationalNo = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            checkBox1 = new CheckBox();
            label4 = new Label();
            tabControl1.SuspendLayout();
            PersonalInfo.SuspendLayout();
            LoginInfo.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(PersonalInfo);
            tabControl1.Controls.Add(LoginInfo);
            tabControl1.Location = new Point(34, 92);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1171, 645);
            tabControl1.TabIndex = 0;
            // 
            // PersonalInfo
            // 
            PersonalInfo.Controls.Add(NextButton);
            PersonalInfo.Controls.Add(ctrlPersonCardWithFilter1);
            PersonalInfo.Location = new Point(4, 34);
            PersonalInfo.Name = "PersonalInfo";
            PersonalInfo.Padding = new Padding(3);
            PersonalInfo.Size = new Size(1163, 607);
            PersonalInfo.TabIndex = 0;
            PersonalInfo.Text = "Personal Info";
            PersonalInfo.UseVisualStyleBackColor = true;
            // 
            // NextButton
            // 
            NextButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NextButton.Image = Properties.Resources.next;
            NextButton.ImageAlign = ContentAlignment.MiddleRight;
            NextButton.Location = new Point(956, 538);
            NextButton.Name = "NextButton";
            NextButton.Size = new Size(152, 49);
            NextButton.TabIndex = 1;
            NextButton.Text = "Next";
            NextButton.UseVisualStyleBackColor = true;
            // 
            // ctrlPersonCardWithFilter1
            // 
            ctrlPersonCardWithFilter1.Location = new Point(3, 6);
            ctrlPersonCardWithFilter1.Name = "ctrlPersonCardWithFilter1";
            ctrlPersonCardWithFilter1.Size = new Size(1123, 625);
            ctrlPersonCardWithFilter1.TabIndex = 0;
            // 
            // LoginInfo
            // 
            LoginInfo.Controls.Add(checkBox1);
            LoginInfo.Controls.Add(textBox4);
            LoginInfo.Controls.Add(textBox3);
            LoginInfo.Controls.Add(textBox2);
            LoginInfo.Controls.Add(textBox1);
            LoginInfo.Controls.Add(label3);
            LoginInfo.Controls.Add(label2);
            LoginInfo.Controls.Add(label1);
            LoginInfo.Controls.Add(NationalNo);
            LoginInfo.Location = new Point(4, 34);
            LoginInfo.Name = "LoginInfo";
            LoginInfo.Padding = new Padding(3);
            LoginInfo.Size = new Size(1163, 607);
            LoginInfo.TabIndex = 1;
            LoginInfo.Text = "Login Info";
            LoginInfo.UseVisualStyleBackColor = true;
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
            // textBox1
            // 
            textBox1.Location = new Point(322, 161);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(322, 218);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(150, 31);
            textBox2.TabIndex = 7;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(322, 277);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(150, 31);
            textBox3.TabIndex = 8;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(322, 329);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(150, 31);
            textBox4.TabIndex = 9;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(322, 413);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(104, 29);
            checkBox1.TabIndex = 10;
            checkBox1.Text = "Is Active";
            checkBox1.UseVisualStyleBackColor = true;
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
            // AddUser
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1225, 823);
            Controls.Add(label4);
            Controls.Add(CloseButton);
            Controls.Add(SaveButton);
            Controls.Add(tabControl1);
            Name = "AddUser";
            ShowIcon = false;
            Text = "Add New User";
            tabControl1.ResumeLayout(false);
            PersonalInfo.ResumeLayout(false);
            LoginInfo.ResumeLayout(false);
            LoginInfo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private CheckBox checkBox1;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label4;
    }
}