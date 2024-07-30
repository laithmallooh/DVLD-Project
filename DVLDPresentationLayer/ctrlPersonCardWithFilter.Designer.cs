namespace DVLDPresentationLayer
{
    partial class ctrlPersonCardWithFilter
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
            FindBy = new ComboBox();
            label10 = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            textBox1 = new TextBox();
            Filter = new GroupBox();
            PersonInformation = new GroupBox();
            ctrlPersonCard1 = new ctrlPersonCard();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            PersonInformation.SuspendLayout();
            SuspendLayout();
            // 
            // FindBy
            // 
            FindBy.DropDownStyle = ComboBoxStyle.DropDownList;
            FindBy.FormattingEnabled = true;
            FindBy.Items.AddRange(new object[] { "1", "2", "3" });
            FindBy.Location = new Point(183, 77);
            FindBy.Name = "FindBy";
            FindBy.Size = new Size(256, 33);
            FindBy.TabIndex = 0;
            FindBy.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(53, 77);
            label10.Name = "label10";
            label10.Size = new Size(99, 28);
            label10.TabIndex = 38;
            label10.Text = "Find By : ";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = Properties.Resources.icons8_search_user_48;
            pictureBox1.Location = new Point(744, 69);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(50, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 39;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Image = Properties.Resources.icons8_add_user_48;
            pictureBox2.Location = new Point(806, 69);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(50, 50);
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.TabIndex = 40;
            pictureBox2.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(455, 79);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(256, 31);
            textBox1.TabIndex = 41;
            // 
            // Filter
            // 
            Filter.Location = new Point(37, 34);
            Filter.Name = "Filter";
            Filter.Size = new Size(1095, 103);
            Filter.TabIndex = 43;
            Filter.TabStop = false;
            Filter.Text = "Filter";
            // 
            // PersonInformation
            // 
            PersonInformation.Controls.Add(ctrlPersonCard1);
            PersonInformation.Location = new Point(37, 175);
            PersonInformation.Name = "PersonInformation";
            PersonInformation.Size = new Size(1095, 375);
            PersonInformation.TabIndex = 44;
            PersonInformation.TabStop = false;
            PersonInformation.Text = "Person Information";
            // 
            // ctrlPersonCard1
            // 
            ctrlPersonCard1.Location = new Point(0, 30);
            ctrlPersonCard1.Name = "ctrlPersonCard1";
            ctrlPersonCard1.Size = new Size(1074, 311);
            ctrlPersonCard1.TabIndex = 0;
            // 
            // ctrlPersonCardWithFilter
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(textBox1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(label10);
            Controls.Add(FindBy);
            Controls.Add(Filter);
            Controls.Add(PersonInformation);
            Name = "ctrlPersonCardWithFilter";
            Size = new Size(1174, 602);
            Load += ctrlPersonCardWithFilter_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            PersonInformation.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox FindBy;
        private Label label10;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private TextBox textBox1;
        private GroupBox Filter;
        private GroupBox PersonInformation;
        private ctrlPersonCard ctrlPersonCard1;
    }
}
