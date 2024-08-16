namespace DVLDPresentationLayer
{
    partial class AddPerson
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
            components = new System.ComponentModel.Container();
            PersonID = new Label();
            PersonIDLabel = new Label();
            TitleLabel = new Label();
            NameLabel = new Label();
            NationalNo = new Label();
            Gender = new Label();
            Email = new Label();
            Address = new Label();
            CountryBox = new Label();
            Phone = new Label();
            DateOfBirthLabel = new Label();
            FirstNameBox = new TextBox();
            SecondNameBox = new TextBox();
            LastNameBox = new TextBox();
            ThirdNameBox = new TextBox();
            NationalNoBox = new TextBox();
            EmailBox = new TextBox();
            AddressBox = new TextBox();
            PhoneBox = new TextBox();
            pictureBox1 = new PictureBox();
            groupBox1 = new GroupBox();
            Male = new RadioButton();
            Female = new RadioButton();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            setImage = new LinkLabel();
            DateOfBirthPicker = new DateTimePicker();
            CloseButton = new Button();
            SaveButton = new Button();
            comboBox1 = new ComboBox();
            label6 = new Label();
            label7 = new Label();
            errorProvider1 = new ErrorProvider(components);
            setImageLabel = new LinkLabel();
            removeImageLabel = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // PersonID
            // 
            PersonID.AutoSize = true;
            PersonID.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PersonID.Location = new Point(74, 130);
            PersonID.Name = "PersonID";
            PersonID.Size = new Size(102, 28);
            PersonID.TabIndex = 0;
            PersonID.Text = "Person ID";
            // 
            // PersonIDLabel
            // 
            PersonIDLabel.AutoSize = true;
            PersonIDLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PersonIDLabel.Location = new Point(249, 130);
            PersonIDLabel.Name = "PersonIDLabel";
            PersonIDLabel.Size = new Size(51, 28);
            PersonIDLabel.TabIndex = 1;
            PersonIDLabel.Text = "N/A";
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TitleLabel.Location = new Point(565, 46);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(234, 38);
            TitleLabel.TabIndex = 2;
            TitleLabel.Text = "Add New Person";
            TitleLabel.Click += label1_Click;
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NameLabel.Location = new Point(74, 239);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(73, 28);
            NameLabel.TabIndex = 3;
            NameLabel.Text = "Name:";
            // 
            // NationalNo
            // 
            NationalNo.AutoSize = true;
            NationalNo.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NationalNo.Location = new Point(74, 305);
            NationalNo.Name = "NationalNo";
            NationalNo.Size = new Size(133, 28);
            NationalNo.TabIndex = 4;
            NationalNo.Text = "National No:";
            // 
            // Gender
            // 
            Gender.AutoSize = true;
            Gender.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Gender.Location = new Point(74, 372);
            Gender.Name = "Gender";
            Gender.Size = new Size(97, 28);
            Gender.TabIndex = 5;
            Gender.Text = "Gender : ";
            // 
            // Email
            // 
            Email.AutoSize = true;
            Email.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Email.Location = new Point(74, 451);
            Email.Name = "Email";
            Email.Size = new Size(81, 28);
            Email.TabIndex = 6;
            Email.Text = "Email : ";
            // 
            // Address
            // 
            Address.AutoSize = true;
            Address.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Address.Location = new Point(74, 515);
            Address.Name = "Address";
            Address.Size = new Size(104, 28);
            Address.TabIndex = 7;
            Address.Text = "Address : ";
            // 
            // CountryBox
            // 
            CountryBox.AutoSize = true;
            CountryBox.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CountryBox.Location = new Point(589, 454);
            CountryBox.Name = "CountryBox";
            CountryBox.Size = new Size(105, 28);
            CountryBox.TabIndex = 10;
            CountryBox.Text = "Country : ";
            // 
            // Phone
            // 
            Phone.AutoSize = true;
            Phone.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Phone.Location = new Point(589, 375);
            Phone.Name = "Phone";
            Phone.Size = new Size(88, 28);
            Phone.TabIndex = 9;
            Phone.Text = "Phone : ";
            // 
            // DateOfBirthLabel
            // 
            DateOfBirthLabel.AutoSize = true;
            DateOfBirthLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DateOfBirthLabel.Location = new Point(589, 308);
            DateOfBirthLabel.Name = "DateOfBirthLabel";
            DateOfBirthLabel.Size = new Size(151, 28);
            DateOfBirthLabel.TabIndex = 8;
            DateOfBirthLabel.Text = "Date Of Birth :";
            DateOfBirthLabel.Click += label4_Click;
            // 
            // FirstNameBox
            // 
            FirstNameBox.Location = new Point(227, 236);
            FirstNameBox.Name = "FirstNameBox";
            FirstNameBox.Size = new Size(149, 31);
            FirstNameBox.TabIndex = 11;
            FirstNameBox.TextChanged += FirstNameBox_TextChanged_1;
            // 
            // SecondNameBox
            // 
            SecondNameBox.Location = new Point(408, 236);
            SecondNameBox.Name = "SecondNameBox";
            SecondNameBox.Size = new Size(149, 31);
            SecondNameBox.TabIndex = 12;
            // 
            // LastNameBox
            // 
            LastNameBox.Location = new Point(770, 236);
            LastNameBox.Name = "LastNameBox";
            LastNameBox.Size = new Size(149, 31);
            LastNameBox.TabIndex = 14;
            // 
            // ThirdNameBox
            // 
            ThirdNameBox.Location = new Point(589, 236);
            ThirdNameBox.Name = "ThirdNameBox";
            ThirdNameBox.Size = new Size(149, 31);
            ThirdNameBox.TabIndex = 13;
            // 
            // NationalNoBox
            // 
            NationalNoBox.Location = new Point(227, 302);
            NationalNoBox.Name = "NationalNoBox";
            NationalNoBox.Size = new Size(149, 31);
            NationalNoBox.TabIndex = 15;
            NationalNoBox.TextChanged += NationalNoBox_TextChanged;
            // 
            // EmailBox
            // 
            EmailBox.Location = new Point(227, 448);
            EmailBox.Name = "EmailBox";
            EmailBox.Size = new Size(330, 31);
            EmailBox.TabIndex = 17;
            // 
            // AddressBox
            // 
            AddressBox.Location = new Point(227, 515);
            AddressBox.Name = "AddressBox";
            AddressBox.Size = new Size(698, 31);
            AddressBox.TabIndex = 18;
            // 
            // PhoneBox
            // 
            PhoneBox.Location = new Point(770, 369);
            PhoneBox.Name = "PhoneBox";
            PhoneBox.Size = new Size(149, 31);
            PhoneBox.TabIndex = 19;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(1046, 196);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(215, 225);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(Male);
            groupBox1.Controls.Add(Female);
            groupBox1.Location = new Point(249, 357);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 64);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Enter += groupBox1_Enter_1;
            // 
            // Male
            // 
            Male.AutoSize = true;
            Male.Location = new Point(20, 19);
            Male.Name = "Male";
            Male.Size = new Size(75, 29);
            Male.TabIndex = 0;
            Male.TabStop = true;
            Male.Text = "Male";
            Male.UseVisualStyleBackColor = true;
            Male.CheckedChanged += Male_CheckedChanged;
            // 
            // Female
            // 
            Female.AutoSize = true;
            Female.Location = new Point(101, 19);
            Female.Name = "Female";
            Female.Size = new Size(93, 29);
            Female.TabIndex = 1;
            Female.TabStop = true;
            Female.Text = "Female";
            Female.UseVisualStyleBackColor = true;
            Female.CheckedChanged += Female_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(269, 196);
            label2.Name = "label2";
            label2.Size = new Size(53, 28);
            label2.TabIndex = 22;
            label2.Text = "First";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(814, 196);
            label3.Name = "label3";
            label3.Size = new Size(50, 28);
            label3.TabIndex = 23;
            label3.Text = "Last";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(74, 239);
            label4.Name = "label4";
            label4.Size = new Size(70, 28);
            label4.TabIndex = 24;
            label4.Text = "First : ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(74, 239);
            label5.Name = "label5";
            label5.Size = new Size(85, 28);
            label5.TabIndex = 25;
            label5.Text = "Name : ";
            label5.Click += label5_Click;
            // 
            // setImage
            // 
            setImage.AutoSize = true;
            setImage.Location = new Point(1109, 451);
            setImage.Name = "setImage";
            setImage.Size = new Size(92, 25);
            setImage.TabIndex = 26;
            setImage.TabStop = true;
            setImage.Text = "Set Image";
            setImage.LinkClicked += setImage_LinkClicked;



            // 
            // DateOfBirthPicker
            // 
            DateOfBirthPicker.Format = DateTimePickerFormat.Short;
            DateOfBirthPicker.Location = new Point(770, 305);
            DateOfBirthPicker.Name = "DateOfBirthPicker";
            DateOfBirthPicker.Size = new Size(149, 31);
            DateOfBirthPicker.TabIndex = 27;
            DateOfBirthPicker.ValueChanged += dateTimePicker1_ValueChanged_1;
            // 
            // CloseButton
            // 
            CloseButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CloseButton.Location = new Point(654, 600);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(156, 45);
            CloseButton.TabIndex = 28;
            CloseButton.Text = "Close";
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CloseButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SaveButton.Location = new Point(826, 600);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(156, 45);
            SaveButton.TabIndex = 29;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(770, 451);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 33);
            comboBox1.TabIndex = 30;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged_1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(434, 196);
            label6.Name = "label6";
            label6.Size = new Size(80, 28);
            label6.TabIndex = 31;
            label6.Text = "Second";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(632, 196);
            label7.Name = "label7";
            label7.Size = new Size(62, 28);
            label7.TabIndex = 32;
            label7.Text = "Third";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // setImageLabel
            // 
            setImageLabel.AutoSize = true;
            setImageLabel.Location = new Point(636, 329);
            setImageLabel.Name = "setImageLabel";
            setImageLabel.Size = new Size(0, 25);
            setImageLabel.TabIndex = 33;
            // 
            // removeImageLabel
            // 
            removeImageLabel.AutoSize = true;
            removeImageLabel.Location = new Point(1125, 489);
            removeImageLabel.Name = "removeImageLabel";
            removeImageLabel.Size = new Size(76, 25);
            removeImageLabel.TabIndex = 34;
            removeImageLabel.TabStop = true;
            removeImageLabel.Text = "Remove";
            removeImageLabel.Visible = false;
            removeImageLabel.LinkClicked += removeImageLabel_LinkClicked;
            // 
            // AddPerson
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1362, 682);
            Controls.Add(removeImageLabel);
            Controls.Add(setImageLabel);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(comboBox1);
            Controls.Add(SaveButton);
            Controls.Add(CloseButton);
            Controls.Add(DateOfBirthPicker);
            Controls.Add(setImage);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(groupBox1);
            Controls.Add(pictureBox1);
            Controls.Add(PhoneBox);
            Controls.Add(AddressBox);
            Controls.Add(EmailBox);
            Controls.Add(NationalNoBox);
            Controls.Add(LastNameBox);
            Controls.Add(ThirdNameBox);
            Controls.Add(SecondNameBox);
            Controls.Add(FirstNameBox);
            Controls.Add(CountryBox);
            Controls.Add(Phone);
            Controls.Add(DateOfBirthLabel);
            Controls.Add(Address);
            Controls.Add(Email);
            Controls.Add(Gender);
            Controls.Add(NationalNo);
            Controls.Add(NameLabel);
            Controls.Add(TitleLabel);
            Controls.Add(PersonIDLabel);
            Controls.Add(PersonID);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddPerson";
            Text = "Add / Edit Person info ";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label PersonID;
        private Label PersonIDLabel;
        private Label TitleLabel;
        private Label NameLabel; // Renamed from 'Name' to 'NameLabel'
        private Label NationalNo;
        private Label Gender;
        private Label Email;
        private Label Address;
        private Label CountryBox;
        private Label Phone;
        private Label DateOfBirthLabel;
        private TextBox FirstNameBox;
        private TextBox SecondNameBox;
        private TextBox LastNameBox;
        private TextBox ThirdNameBox;
        private TextBox NationalNoBox;
        private TextBox EmailBox;
        private TextBox AddressBox;
        private TextBox PhoneBox;
        private PictureBox pictureBox1;
        private GroupBox groupBox1;
        private RadioButton Female;
        private RadioButton Male;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private LinkLabel setImage;
        private DateTimePicker DateOfBirthPicker;
        private Button CloseButton;
        private Button SaveButton;
        private ComboBox comboBox1;
        private Label label6;
        private Label label7;
        private ErrorProvider errorProvider1;
        private LinkLabel setImageLabel;
        private LinkLabel removeImageLabel;
    }
}
