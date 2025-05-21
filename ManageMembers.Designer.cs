namespace DatabaseProject
{
    partial class ManageMembers
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
            label1 = new Label();
            button1 = new Button();
            DGV_ViewAllMem = new DataGridView();
            button2 = new Button();
            DGV_memSearch = new DataGridView();
            button3 = new Button();
            label3 = new Label();
            memNameSearch = new TextBox();
            label4 = new Label();
            button4 = new Button();
            UpdateTxt = new TextBox();
            birthDateInput = new DateTimePicker();
            Gender = new ComboBox();
            PasswordTxt = new TextBox();
            label8 = new Label();
            LastNameTxt = new TextBox();
            label10 = new Label();
            EmailTxt = new TextBox();
            label11 = new Label();
            PhoneTxt = new TextBox();
            label12 = new Label();
            label13 = new Label();
            FirstNameTxt = new TextBox();
            label14 = new Label();
            label15 = new Label();
            SSNTxt = new TextBox();
            label16 = new Label();
            label5 = new Label();
            button5 = new Button();
            label6 = new Label();
            label7 = new Label();
            HeightTxt = new TextBox();
            WeightTxt = new TextBox();
            button6 = new Button();
            button7 = new Button();
            UpdateChoice = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)DGV_ViewAllMem).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DGV_memSearch).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(77, 60);
            label1.Name = "label1";
            label1.Size = new Size(420, 54);
            label1.TabIndex = 0;
            label1.Text = "Member Management";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F);
            button1.Location = new Point(75, 158);
            button1.Name = "button1";
            button1.Size = new Size(360, 56);
            button1.TabIndex = 1;
            button1.Text = "View All";
            button1.UseVisualStyleBackColor = true;
            button1.Click += ViewAll;
            // 
            // DGV_ViewAllMem
            // 
            DGV_ViewAllMem.BackgroundColor = SystemColors.MenuBar;
            DGV_ViewAllMem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_ViewAllMem.Location = new Point(75, 220);
            DGV_ViewAllMem.Name = "DGV_ViewAllMem";
            DGV_ViewAllMem.RowHeadersWidth = 62;
            DGV_ViewAllMem.Size = new Size(360, 367);
            DGV_ViewAllMem.TabIndex = 2;
            // 
            // button2
            // 
            button2.Location = new Point(462, 270);
            button2.Name = "button2";
            button2.Size = new Size(645, 34);
            button2.TabIndex = 1;
            button2.Text = "Search";
            button2.UseVisualStyleBackColor = true;
            button2.Click += SearchByMail;
            // 
            // DGV_memSearch
            // 
            DGV_memSearch.BackgroundColor = SystemColors.MenuBar;
            DGV_memSearch.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_memSearch.GridColor = SystemColors.ActiveBorder;
            DGV_memSearch.Location = new Point(462, 315);
            DGV_memSearch.Name = "DGV_memSearch";
            DGV_memSearch.RowHeadersWidth = 62;
            DGV_memSearch.Size = new Size(645, 167);
            DGV_memSearch.TabIndex = 2;
            // 
            // button3
            // 
            button3.Location = new Point(462, 497);
            button3.Name = "button3";
            button3.Size = new Size(645, 46);
            button3.TabIndex = 1;
            button3.Text = "Delete";
            button3.UseVisualStyleBackColor = true;
            button3.Click += DeleteMember;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(462, 166);
            label3.Name = "label3";
            label3.Size = new Size(268, 32);
            label3.TabIndex = 0;
            label3.Text = "Search Using Full Name";
            // 
            // memNameSearch
            // 
            memNameSearch.Location = new Point(462, 217);
            memNameSearch.Multiline = true;
            memNameSearch.Name = "memNameSearch";
            memNameSearch.Size = new Size(645, 46);
            memNameSearch.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F);
            label4.Location = new Point(462, 557);
            label4.Name = "label4";
            label4.Size = new Size(178, 30);
            label4.TabIndex = 0;
            label4.Text = "Change Attribute";
            // 
            // button4
            // 
            button4.Location = new Point(945, 594);
            button4.Name = "button4";
            button4.Size = new Size(162, 46);
            button4.TabIndex = 1;
            button4.Text = "Update";
            button4.UseVisualStyleBackColor = true;
            button4.Click += ChangeAttribute;
            // 
            // UpdateTxt
            // 
            UpdateTxt.Location = new Point(658, 599);
            UpdateTxt.Name = "UpdateTxt";
            UpdateTxt.PlaceholderText = "Enter your Change";
            UpdateTxt.Size = new Size(263, 31);
            UpdateTxt.TabIndex = 3;
            // 
            // birthDateInput
            // 
            birthDateInput.Location = new Point(1518, 550);
            birthDateInput.Name = "birthDateInput";
            birthDateInput.Size = new Size(323, 31);
            birthDateInput.TabIndex = 21;
            // 
            // Gender
            // 
            Gender.FormattingEnabled = true;
            Gender.Items.AddRange(new object[] { "Male", "Female" });
            Gender.Location = new Point(1517, 328);
            Gender.Name = "Gender";
            Gender.Size = new Size(323, 33);
            Gender.TabIndex = 20;
            // 
            // PasswordTxt
            // 
            PasswordTxt.Location = new Point(1141, 552);
            PasswordTxt.Name = "PasswordTxt";
            PasswordTxt.Size = new Size(305, 31);
            PasswordTxt.TabIndex = 18;
            PasswordTxt.WordWrap = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(1148, 520);
            label8.Name = "label8";
            label8.Size = new Size(87, 25);
            label8.TabIndex = 10;
            label8.Text = "Password";
            // 
            // LastNameTxt
            // 
            LastNameTxt.Location = new Point(1140, 330);
            LastNameTxt.Name = "LastNameTxt";
            LastNameTxt.Size = new Size(305, 31);
            LastNameTxt.TabIndex = 17;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(1525, 518);
            label10.Name = "label10";
            label10.Size = new Size(83, 25);
            label10.TabIndex = 12;
            label10.Text = "Birthdate";
            // 
            // EmailTxt
            // 
            EmailTxt.Location = new Point(1140, 477);
            EmailTxt.Name = "EmailTxt";
            EmailTxt.Size = new Size(305, 31);
            EmailTxt.TabIndex = 16;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(1147, 298);
            label11.Name = "label11";
            label11.Size = new Size(95, 25);
            label11.TabIndex = 13;
            label11.Text = "Last Name";
            // 
            // PhoneTxt
            // 
            PhoneTxt.Location = new Point(1517, 475);
            PhoneTxt.Name = "PhoneTxt";
            PhoneTxt.Size = new Size(323, 31);
            PhoneTxt.TabIndex = 15;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(1147, 445);
            label12.Name = "label12";
            label12.Size = new Size(54, 25);
            label12.TabIndex = 11;
            label12.Text = "Email";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(1524, 296);
            label13.Name = "label13";
            label13.Size = new Size(69, 25);
            label13.TabIndex = 9;
            label13.Text = "Gender";
            // 
            // FirstNameTxt
            // 
            FirstNameTxt.Location = new Point(1140, 250);
            FirstNameTxt.Name = "FirstNameTxt";
            FirstNameTxt.Size = new Size(305, 31);
            FirstNameTxt.TabIndex = 14;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(1524, 443);
            label14.Name = "label14";
            label14.Size = new Size(62, 25);
            label14.TabIndex = 8;
            label14.Text = "Phone";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(1147, 218);
            label15.Name = "label15";
            label15.Size = new Size(97, 25);
            label15.TabIndex = 7;
            label15.Text = "First Name";
            // 
            // SSNTxt
            // 
            SSNTxt.Location = new Point(1517, 248);
            SSNTxt.Name = "SSNTxt";
            SSNTxt.Size = new Size(323, 31);
            SSNTxt.TabIndex = 19;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(1524, 216);
            label16.Name = "label16";
            label16.Size = new Size(45, 25);
            label16.TabIndex = 6;
            label16.Text = "SSN";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(1140, 166);
            label5.Name = "label5";
            label5.Size = new Size(210, 32);
            label5.TabIndex = 0;
            label5.Text = "Add New Member";
            // 
            // button5
            // 
            button5.Location = new Point(1404, 618);
            button5.Name = "button5";
            button5.Size = new Size(153, 46);
            button5.TabIndex = 1;
            button5.Text = "Add";
            button5.UseVisualStyleBackColor = true;
            button5.Click += AddNewMember;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1524, 375);
            label6.Name = "label6";
            label6.Size = new Size(65, 25);
            label6.TabIndex = 8;
            label6.Text = "Height";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1147, 377);
            label7.Name = "label7";
            label7.Size = new Size(68, 25);
            label7.TabIndex = 11;
            label7.Text = "Weight";
            // 
            // HeightTxt
            // 
            HeightTxt.Location = new Point(1517, 407);
            HeightTxt.Name = "HeightTxt";
            HeightTxt.Size = new Size(323, 31);
            HeightTxt.TabIndex = 15;
            // 
            // WeightTxt
            // 
            WeightTxt.Location = new Point(1140, 409);
            WeightTxt.Name = "WeightTxt";
            WeightTxt.Size = new Size(305, 31);
            WeightTxt.TabIndex = 16;
            // 
            // button6
            // 
            button6.Location = new Point(75, 618);
            button6.Name = "button6";
            button6.Size = new Size(153, 46);
            button6.TabIndex = 1;
            button6.Text = "Back";
            button6.UseVisualStyleBackColor = true;
            button6.Click += BackToOwner;
            // 
            // button7
            // 
            button7.Location = new Point(1756, 12);
            button7.Name = "button7";
            button7.Size = new Size(96, 46);
            button7.TabIndex = 1;
            button7.Text = "Exit";
            button7.UseVisualStyleBackColor = true;
            button7.Click += ExitApplication;
            // 
            // UpdateChoice
            // 
            UpdateChoice.FormattingEnabled = true;
            UpdateChoice.Items.AddRange(new object[] { "First Name", "Last Name", "Weight", "Height", "Locker Number", "Coach ID" });
            UpdateChoice.Location = new Point(462, 599);
            UpdateChoice.Name = "UpdateChoice";
            UpdateChoice.Size = new Size(169, 33);
            UpdateChoice.TabIndex = 22;
            // 
            // ManageMembers
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1864, 918);
            Controls.Add(UpdateChoice);
            Controls.Add(birthDateInput);
            Controls.Add(Gender);
            Controls.Add(PasswordTxt);
            Controls.Add(label8);
            Controls.Add(LastNameTxt);
            Controls.Add(label10);
            Controls.Add(WeightTxt);
            Controls.Add(EmailTxt);
            Controls.Add(HeightTxt);
            Controls.Add(label11);
            Controls.Add(label7);
            Controls.Add(PhoneTxt);
            Controls.Add(label12);
            Controls.Add(label13);
            Controls.Add(label6);
            Controls.Add(FirstNameTxt);
            Controls.Add(label14);
            Controls.Add(label15);
            Controls.Add(SSNTxt);
            Controls.Add(label16);
            Controls.Add(memNameSearch);
            Controls.Add(UpdateTxt);
            Controls.Add(DGV_memSearch);
            Controls.Add(button6);
            Controls.Add(button7);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(DGV_ViewAllMem);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "ManageMembers";
            Text = "ManageMembers";
            Load += ManageMembers_Load;
            ((System.ComponentModel.ISupportInitialize)DGV_ViewAllMem).EndInit();
            ((System.ComponentModel.ISupportInitialize)DGV_memSearch).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private DataGridView DGV_ViewAllMem;
        private Button button2;
        private DataGridView DGV_memSearch;
        private Button button3;
        private Label label3;
        private TextBox memNameSearch;
        private Label label4;
        private Button button4;
        private TextBox UpdateTxt;
        private DateTimePicker birthDateInput;
        private ComboBox Gender;
        private TextBox PasswordTxt;
        private Label label8;
        private TextBox LastNameTxt;
        private Label label10;
        private TextBox EmailTxt;
        private Label label11;
        private TextBox PhoneTxt;
        private Label label12;
        private Label label13;
        private TextBox FirstNameTxt;
        private Label label14;
        private Label label15;
        private TextBox SSNTxt;
        private Label label16;
        private Label label5;
        private Button button5;
        private Label label6;
        private Label label7;
        private TextBox HeightTxt;
        private TextBox WeightTxt;
        private Button button6;
        private Button button7;
        private ComboBox UpdateChoice;
    }
}