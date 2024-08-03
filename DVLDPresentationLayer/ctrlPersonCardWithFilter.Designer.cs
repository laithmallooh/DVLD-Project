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
        private System.Windows.Forms.Panel panel1; // Ensure this is declared

        private void InitializeComponent()
        {
            FindByComboBox = new ComboBox();
            label10 = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            textInput = new TextBox();
            Filter = new GroupBox();
            PersonInformation = new GroupBox();
            panel1 = new Panel();
            ctrlPersonCard1 = new ctrlPersonCard();
            dgvPersons = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            PersonInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPersons).BeginInit();
            SuspendLayout();
            // 
            // FindByComboBox
            // 
            FindByComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            FindByComboBox.FormattingEnabled = true;
            FindByComboBox.Location = new Point(183, 77);
            FindByComboBox.Name = "FindByComboBox";
            FindByComboBox.Size = new Size(256, 33);
            FindByComboBox.TabIndex = 0;
            FindByComboBox.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
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
            pictureBox1.Click += pictureBox1_Click;
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
            // textInput
            // 
            textInput.Location = new Point(455, 79);
            textInput.Name = "textInput";
            textInput.Size = new Size(256, 31);
            textInput.TabIndex = 41;
            textInput.TextChanged += textInput_TextChanged;
            // 
            // Filter
            // 
            Filter.Location = new Point(37, 34);
            Filter.Name = "Filter";
            Filter.Size = new Size(1356, 103);
            Filter.TabIndex = 43;
            Filter.TabStop = false;
            Filter.Text = "Filter";
            Filter.Enter += Filter_Enter;
            // 
            // PersonInformation
            // 
            PersonInformation.Controls.Add(panel1);
            PersonInformation.Controls.Add(ctrlPersonCard1);
            PersonInformation.Location = new Point(37, 175);
            PersonInformation.Name = "PersonInformation";
            PersonInformation.Size = new Size(1356, 375);
            PersonInformation.TabIndex = 44;
            PersonInformation.TabStop = false;
            PersonInformation.Text = "Person Information";
            // 
            // panel1
            // 
            panel1.Location = new Point(16, 23);
            panel1.Name = "panel1";
            panel1.Size = new Size(1334, 346);
            panel1.TabIndex = 45;
            // 
            // ctrlPersonCard1
            // 
            ctrlPersonCard1.Location = new Point(0, 30);
            ctrlPersonCard1.Name = "ctrlPersonCard1";
            ctrlPersonCard1.Size = new Size(1074, 311);
            ctrlPersonCard1.TabIndex = 0;
            // 
            // dgvPersons
            // 
            dgvPersons.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPersons.Location = new Point(12, 12);
            dgvPersons.Name = "dgvPersons";
            dgvPersons.RowHeadersWidth = 62;
            dgvPersons.Size = new Size(240, 150);
            dgvPersons.TabIndex = 0;
            dgvPersons.CellContentClick += dgvPersons_CellContentClick;
            // 
            // ctrlPersonCardWithFilter
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(textInput);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(label10);
            Controls.Add(FindByComboBox);
            Controls.Add(Filter);
            Controls.Add(PersonInformation);
            Controls.Add(dgvPersons);
            Name = "ctrlPersonCardWithFilter";
            Size = new Size(1435, 602);
            Load += ctrlPersonCardWithFilter_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            PersonInformation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPersons).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private ComboBox FindByComboBox;
        private Label label10;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private TextBox textInput;
        private GroupBox Filter;
        private GroupBox PersonInformation;
        private ctrlPersonCard ctrlPersonCard1;
        private Panel panelPersonDetails;
        private DataGridView dgvPersons;
    }
}
