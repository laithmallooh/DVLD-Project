namespace DVLDPresentationLayer
{
    partial class ManagePeople
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
            pictureBox1 = new PictureBox();
            label1 = new Label();
            addPerson = new Button();
            dataGridView1 = new DataGridView();
            CloseButton = new Button();
            label3 = new Label();
            label4 = new Label();
            colorDialog1 = new ColorDialog();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.icons8_users_96;
            pictureBox1.Location = new Point(757, 35);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(239, 237);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.HotTrack;
            label1.Location = new Point(766, 292);
            label1.Name = "label1";
            label1.Size = new Size(219, 38);
            label1.TabIndex = 1;
            label1.Text = "Manage People";
            // 
            // addPerson
            // 
            addPerson.Image = Properties.Resources.icons8_add_user_48;
            addPerson.Location = new Point(1690, 282);
            addPerson.Name = "addPerson";
            addPerson.Size = new Size(56, 65);
            addPerson.TabIndex = 4;
            addPerson.UseVisualStyleBackColor = true;
            addPerson.Click += addPerson_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(32, 366);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1714, 433);
            dataGridView1.TabIndex = 5;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // CloseButton
            // 
            CloseButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CloseButton.Image = Properties.Resources.icons8_close_40;
            CloseButton.ImageAlign = ContentAlignment.MiddleLeft;
            CloseButton.Location = new Point(1255, 843);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(180, 52);
            CloseButton.TabIndex = 6;
            CloseButton.Text = "Close";
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlText;
            label3.Location = new Point(32, 867);
            label3.Name = "label3";
            label3.Size = new Size(122, 28);
            label3.TabIndex = 7;
            label3.Text = "# Records : ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlText;
            label4.Location = new Point(160, 867);
            label4.Name = "label4";
            label4.Size = new Size(40, 28);
            label4.TabIndex = 8;
            label4.Text = "No";
            label4.Click += label4_Click;
            // 
            // ManagePeople
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1954, 920);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(CloseButton);
            Controls.Add(dataGridView1);
            Controls.Add(addPerson);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "ManagePeople";
            ShowIcon = false;
            Text = "Manage People";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Button addPerson;
        private DataGridView dataGridView1;
        private Button CloseButton;
        private Label label3;
        private Label label4;
        private ColorDialog colorDialog1;
    }
}