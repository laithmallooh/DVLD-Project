namespace DVLDPresentationLayer
{
    partial class ManageUsers
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
            label4 = new Label();
            label3 = new Label();
            CloseButton = new Button();
            usersDataGridView = new DataGridView();
            addUser = new Button();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            colorDialog1 = new ColorDialog();
            label2 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)usersDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlText;
            label4.Location = new Point(-149, 777);
            label4.Name = "label4";
            label4.Size = new Size(40, 28);
            label4.TabIndex = 15;
            label4.Text = "No";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlText;
            label3.Location = new Point(-277, 777);
            label3.Name = "label3";
            label3.Size = new Size(122, 28);
            label3.TabIndex = 14;
            label3.Text = "# Records : ";
            // 
            // CloseButton
            // 
            CloseButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CloseButton.Image = Properties.Resources.icons8_close_40;
            CloseButton.ImageAlign = ContentAlignment.MiddleLeft;
            CloseButton.Location = new Point(1170, 1078);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(180, 52);
            CloseButton.TabIndex = 13;
            CloseButton.Text = "Close";
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CloseButton_Click;
            // 
            // usersDataGridView
            // 
            usersDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            usersDataGridView.Location = new Point(12, 350);
            usersDataGridView.Name = "usersDataGridView";
            usersDataGridView.RowHeadersWidth = 62;
            usersDataGridView.Size = new Size(1338, 692);
            usersDataGridView.TabIndex = 12;
            // 
            // addUser
            // 
            addUser.Image = Properties.Resources.icons8_add_user_48;
            addUser.Location = new Point(1294, 265);
            addUser.Name = "addUser";
            addUser.Size = new Size(56, 65);
            addUser.TabIndex = 11;
            addUser.UseVisualStyleBackColor = true;
            addUser.Click += addPerson_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.HotTrack;
            label1.Location = new Point(575, 274);
            label1.Name = "label1";
            label1.Size = new Size(189, 38);
            label1.TabIndex = 10;
            label1.Text = "Manage User";
            label1.Click += label1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.icons8_users_96;
            pictureBox1.Location = new Point(551, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(239, 237);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(140, 1105);
            label2.Name = "label2";
            label2.Size = new Size(40, 28);
            label2.TabIndex = 17;
            label2.Text = "No";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ControlText;
            label5.Location = new Point(12, 1105);
            label5.Name = "label5";
            label5.Size = new Size(122, 28);
            label5.TabIndex = 16;
            label5.Text = "# Records : ";
            // 
            // ManageUsers
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1375, 1142);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(CloseButton);
            Controls.Add(usersDataGridView);
            Controls.Add(addUser);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "ManageUsers";
            Text = "Manage Users";
            ((System.ComponentModel.ISupportInitialize)usersDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private Label label3;
        private Button CloseButton;
        private DataGridView usersDataGridView;
        private Button addUser;
        private Label label1;
        private PictureBox pictureBox1;
        private ColorDialog colorDialog1;
        private Label label2;
        private Label label5;
    }
}