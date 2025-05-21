namespace DatabaseProject
{
    partial class ManageCoach
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitle = new Label();
            DGV_ViewAllCoach = new DataGridView();
            btnViewAll = new Button();
            FirstNameTxt = new TextBox();
            LastNameTxt = new TextBox();
            EmailTxt = new TextBox();
            SSNTxt = new TextBox();
            GenderComboBox = new ComboBox();
            RatingTxt = new TextBox();
            SupervisorIDTxt = new TextBox();
            PasswordTxt = new TextBox();
            btnAddCoach = new Button();
            btnDeleteCoach = new Button();
            CoachIDTxt = new TextBox();
            btnSearchCoach = new Button();
            DGV_coachSearch = new DataGridView();
            DGV_SlotTimings = new DataGridView();
            DGV_Certifications = new DataGridView();
            DGV_AllSlotTimings = new DataGridView();
            DGV_AllCertifications = new DataGridView();
            btnLogout = new Button();
            btnExit = new Button();
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            UpdateChoice = new ComboBox();
            UpdateTxt = new TextBox();
            button6 = new Button();
            label4 = new Label();
            IDTxt = new TextBox();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)DGV_ViewAllCoach).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DGV_coachSearch).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DGV_SlotTimings).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DGV_Certifications).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DGV_AllSlotTimings).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DGV_AllCertifications).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(20, 17);
            lblTitle.Margin = new Padding(5, 0, 5, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(281, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Manage Coaches";
            lblTitle.Click += lblTitle_Click;
            // 
            // DGV_ViewAllCoach
            // 
            DGV_ViewAllCoach.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_ViewAllCoach.Location = new Point(26, 144);
            DGV_ViewAllCoach.Margin = new Padding(5, 6, 5, 6);
            DGV_ViewAllCoach.Name = "DGV_ViewAllCoach";
            DGV_ViewAllCoach.RowHeadersWidth = 62;
            DGV_ViewAllCoach.Size = new Size(496, 288);
            DGV_ViewAllCoach.TabIndex = 1;
            // 
            // btnViewAll
            // 
            btnViewAll.Location = new Point(36, 74);
            btnViewAll.Margin = new Padding(5, 6, 5, 6);
            btnViewAll.Name = "btnViewAll";
            btnViewAll.Size = new Size(486, 58);
            btnViewAll.TabIndex = 2;
            btnViewAll.Text = "View All Coaches";
            btnViewAll.UseVisualStyleBackColor = true;
            btnViewAll.Click += ViewAll;
            // 
            // FirstNameTxt
            // 
            FirstNameTxt.Location = new Point(1155, 127);
            FirstNameTxt.Margin = new Padding(5, 6, 5, 6);
            FirstNameTxt.Name = "FirstNameTxt";
            FirstNameTxt.PlaceholderText = "First Name";
            FirstNameTxt.Size = new Size(164, 31);
            FirstNameTxt.TabIndex = 3;
            // 
            // LastNameTxt
            // 
            LastNameTxt.Location = new Point(1343, 127);
            LastNameTxt.Margin = new Padding(5, 6, 5, 6);
            LastNameTxt.Name = "LastNameTxt";
            LastNameTxt.PlaceholderText = "Last Name";
            LastNameTxt.Size = new Size(164, 31);
            LastNameTxt.TabIndex = 4;
            // 
            // EmailTxt
            // 
            EmailTxt.Location = new Point(1532, 127);
            EmailTxt.Margin = new Padding(5, 6, 5, 6);
            EmailTxt.Name = "EmailTxt";
            EmailTxt.PlaceholderText = "Email";
            EmailTxt.Size = new Size(197, 31);
            EmailTxt.TabIndex = 5;
            // 
            // SSNTxt
            // 
            SSNTxt.Location = new Point(1155, 184);
            SSNTxt.Margin = new Padding(5, 6, 5, 6);
            SSNTxt.Name = "SSNTxt";
            SSNTxt.PlaceholderText = "SSN";
            SSNTxt.Size = new Size(164, 31);
            SSNTxt.TabIndex = 6;
            // 
            // GenderComboBox
            // 
            GenderComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            GenderComboBox.FormattingEnabled = true;
            GenderComboBox.Location = new Point(1155, 240);
            GenderComboBox.Margin = new Padding(5, 6, 5, 6);
            GenderComboBox.Name = "GenderComboBox";
            GenderComboBox.Size = new Size(164, 33);
            GenderComboBox.TabIndex = 7;
            GenderComboBox.SelectedIndexChanged += GenderComboBox_SelectedIndexChanged;
            // 
            // RatingTxt
            // 
            RatingTxt.Location = new Point(1343, 242);
            RatingTxt.Margin = new Padding(5, 6, 5, 6);
            RatingTxt.Name = "RatingTxt";
            RatingTxt.PlaceholderText = "Rating";
            RatingTxt.Size = new Size(164, 31);
            RatingTxt.TabIndex = 8;
            // 
            // SupervisorIDTxt
            // 
            SupervisorIDTxt.Location = new Point(1343, 184);
            SupervisorIDTxt.Margin = new Padding(5, 6, 5, 6);
            SupervisorIDTxt.Name = "SupervisorIDTxt";
            SupervisorIDTxt.PlaceholderText = "Supervisor ID";
            SupervisorIDTxt.Size = new Size(164, 31);
            SupervisorIDTxt.TabIndex = 9;
            // 
            // PasswordTxt
            // 
            PasswordTxt.Location = new Point(1532, 184);
            PasswordTxt.Margin = new Padding(5, 6, 5, 6);
            PasswordTxt.Name = "PasswordTxt";
            PasswordTxt.PlaceholderText = "Password";
            PasswordTxt.Size = new Size(197, 31);
            PasswordTxt.TabIndex = 10;
            // 
            // btnAddCoach
            // 
            btnAddCoach.Location = new Point(1532, 242);
            btnAddCoach.Margin = new Padding(5, 6, 5, 6);
            btnAddCoach.Name = "btnAddCoach";
            btnAddCoach.Size = new Size(197, 31);
            btnAddCoach.TabIndex = 11;
            btnAddCoach.Text = "Add Coach";
            btnAddCoach.UseVisualStyleBackColor = true;
            btnAddCoach.Click += AddNewCoach;
            // 
            // btnDeleteCoach
            // 
            btnDeleteCoach.Location = new Point(949, 458);
            btnDeleteCoach.Margin = new Padding(5, 6, 5, 6);
            btnDeleteCoach.Name = "btnDeleteCoach";
            btnDeleteCoach.Size = new Size(125, 44);
            btnDeleteCoach.TabIndex = 13;
            btnDeleteCoach.Text = "Delete Coach";
            btnDeleteCoach.UseVisualStyleBackColor = true;
            btnDeleteCoach.Click += DeleteCoach;
            // 
            // CoachIDTxt
            // 
            CoachIDTxt.Location = new Point(26, 456);
            CoachIDTxt.Margin = new Padding(5, 6, 5, 6);
            CoachIDTxt.Multiline = true;
            CoachIDTxt.Name = "CoachIDTxt";
            CoachIDTxt.PlaceholderText = "Coach ID";
            CoachIDTxt.Size = new Size(496, 43);
            CoachIDTxt.TabIndex = 14;
            // 
            // btnSearchCoach
            // 
            btnSearchCoach.Location = new Point(566, 74);
            btnSearchCoach.Margin = new Padding(5, 6, 5, 6);
            btnSearchCoach.Name = "btnSearchCoach";
            btnSearchCoach.Size = new Size(500, 58);
            btnSearchCoach.TabIndex = 15;
            btnSearchCoach.Text = "View Properties";
            btnSearchCoach.UseVisualStyleBackColor = true;
            btnSearchCoach.Click += SearchByCoachID;
            // 
            // DGV_coachSearch
            // 
            DGV_coachSearch.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_coachSearch.Location = new Point(566, 144);
            DGV_coachSearch.Margin = new Padding(5, 6, 5, 6);
            DGV_coachSearch.Name = "DGV_coachSearch";
            DGV_coachSearch.RowHeadersWidth = 62;
            DGV_coachSearch.Size = new Size(508, 283);
            DGV_coachSearch.TabIndex = 16;
            DGV_coachSearch.CellClick += DGV_coachSearch_CellClick;
            // 
            // DGV_SlotTimings
            // 
            DGV_SlotTimings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_SlotTimings.Location = new Point(15, 588);
            DGV_SlotTimings.Margin = new Padding(5, 6, 5, 6);
            DGV_SlotTimings.Name = "DGV_SlotTimings";
            DGV_SlotTimings.RowHeadersWidth = 62;
            DGV_SlotTimings.Size = new Size(500, 352);
            DGV_SlotTimings.TabIndex = 17;
            DGV_SlotTimings.CellContentClick += DGV_SlotTimings_CellContentClick;
            // 
            // DGV_Certifications
            // 
            DGV_Certifications.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Certifications.Location = new Point(574, 577);
            DGV_Certifications.Margin = new Padding(5, 6, 5, 6);
            DGV_Certifications.Name = "DGV_Certifications";
            DGV_Certifications.RowHeadersWidth = 62;
            DGV_Certifications.Size = new Size(500, 352);
            DGV_Certifications.TabIndex = 18;
            // 
            // DGV_AllSlotTimings
            // 
            DGV_AllSlotTimings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_AllSlotTimings.Location = new Point(20, 1077);
            DGV_AllSlotTimings.Margin = new Padding(5, 6, 5, 6);
            DGV_AllSlotTimings.Name = "DGV_AllSlotTimings";
            DGV_AllSlotTimings.RowHeadersWidth = 62;
            DGV_AllSlotTimings.Size = new Size(500, 192);
            DGV_AllSlotTimings.TabIndex = 21;
            // 
            // DGV_AllCertifications
            // 
            DGV_AllCertifications.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_AllCertifications.Location = new Point(550, 1077);
            DGV_AllCertifications.Margin = new Padding(5, 6, 5, 6);
            DGV_AllCertifications.Name = "DGV_AllCertifications";
            DGV_AllCertifications.RowHeadersWidth = 62;
            DGV_AllCertifications.Size = new Size(500, 192);
            DGV_AllCertifications.TabIndex = 22;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(20, 1308);
            btnLogout.Margin = new Padding(5, 6, 5, 6);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(125, 44);
            btnLogout.TabIndex = 23;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += Logout;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(155, 1308);
            btnExit.Margin = new Padding(5, 6, 5, 6);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(125, 44);
            btnExit.TabIndex = 24;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += ExitApplication;
            // 
            // button1
            // 
            button1.Location = new Point(20, 973);
            button1.Name = "button1";
            button1.Size = new Size(127, 46);
            button1.TabIndex = 25;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = true;
            button1.Click += BackToOwner;
            // 
            // button2
            // 
            button2.Location = new Point(1683, 12);
            button2.Name = "button2";
            button2.Size = new Size(112, 46);
            button2.TabIndex = 26;
            button2.Text = "EXIT";
            button2.UseVisualStyleBackColor = true;
            button2.Click += ExitApplication;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(1140, 77);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(140, 29);
            label1.TabIndex = 0;
            label1.Text = "Add Coach";
            label1.Click += lblTitle_Click;
            // 
            // UpdateChoice
            // 
            UpdateChoice.FormattingEnabled = true;
            UpdateChoice.Items.AddRange(new object[] { "FirstName", "LastName", "Email", "SSN", "Gender", "Rating", "SupervisorID", "Password" });
            UpdateChoice.Location = new Point(1156, 514);
            UpdateChoice.Name = "UpdateChoice";
            UpdateChoice.Size = new Size(171, 33);
            UpdateChoice.TabIndex = 62;
            // 
            // UpdateTxt
            // 
            UpdateTxt.Location = new Point(1343, 514);
            UpdateTxt.Name = "UpdateTxt";
            UpdateTxt.PlaceholderText = "Enter your Change";
            UpdateTxt.Size = new Size(164, 31);
            UpdateTxt.TabIndex = 61;
            // 
            // button6
            // 
            button6.Location = new Point(1532, 506);
            button6.Name = "button6";
            button6.Size = new Size(197, 46);
            button6.TabIndex = 60;
            button6.Text = "Update";
            button6.UseVisualStyleBackColor = true;
            button6.Click += ChangeAttribute;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F);
            label4.Location = new Point(1156, 472);
            label4.Name = "label4";
            label4.Size = new Size(178, 30);
            label4.TabIndex = 59;
            label4.Text = "Change Attribute";
            // 
            // IDTxt
            // 
            IDTxt.Location = new Point(1156, 567);
            IDTxt.Margin = new Padding(5, 6, 5, 6);
            IDTxt.Name = "IDTxt";
            IDTxt.PlaceholderText = "Coach ID";
            IDTxt.Size = new Size(171, 31);
            IDTxt.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(595, 542);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(145, 29);
            label2.TabIndex = 0;
            label2.Text = "Certificates";
            label2.Click += lblTitle_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(26, 553);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(150, 29);
            label3.TabIndex = 0;
            label3.Text = "Slot timings";
            label3.Click += lblTitle_Click;
            // 
            // ManageCoach
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1807, 1050);
            Controls.Add(UpdateChoice);
            Controls.Add(UpdateTxt);
            Controls.Add(button6);
            Controls.Add(label4);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(btnExit);
            Controls.Add(btnLogout);
            Controls.Add(DGV_AllCertifications);
            Controls.Add(DGV_AllSlotTimings);
            Controls.Add(DGV_Certifications);
            Controls.Add(DGV_SlotTimings);
            Controls.Add(DGV_coachSearch);
            Controls.Add(btnSearchCoach);
            Controls.Add(IDTxt);
            Controls.Add(CoachIDTxt);
            Controls.Add(btnDeleteCoach);
            Controls.Add(btnAddCoach);
            Controls.Add(PasswordTxt);
            Controls.Add(SupervisorIDTxt);
            Controls.Add(RatingTxt);
            Controls.Add(GenderComboBox);
            Controls.Add(SSNTxt);
            Controls.Add(EmailTxt);
            Controls.Add(LastNameTxt);
            Controls.Add(FirstNameTxt);
            Controls.Add(btnViewAll);
            Controls.Add(DGV_ViewAllCoach);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblTitle);
            Margin = new Padding(5, 6, 5, 6);
            Name = "ManageCoach";
            Text = "Manage Coaches";
            Load += ManageCoach_Load;
            ((System.ComponentModel.ISupportInitialize)DGV_ViewAllCoach).EndInit();
            ((System.ComponentModel.ISupportInitialize)DGV_coachSearch).EndInit();
            ((System.ComponentModel.ISupportInitialize)DGV_SlotTimings).EndInit();
            ((System.ComponentModel.ISupportInitialize)DGV_Certifications).EndInit();
            ((System.ComponentModel.ISupportInitialize)DGV_AllSlotTimings).EndInit();
            ((System.ComponentModel.ISupportInitialize)DGV_AllCertifications).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView DGV_ViewAllCoach;
        private System.Windows.Forms.Button btnViewAll;
        private System.Windows.Forms.TextBox FirstNameTxt;
        private System.Windows.Forms.TextBox LastNameTxt;
        private System.Windows.Forms.TextBox EmailTxt;
        private System.Windows.Forms.TextBox SSNTxt;
        private System.Windows.Forms.ComboBox GenderComboBox;
        private System.Windows.Forms.TextBox RatingTxt;
        private System.Windows.Forms.TextBox SupervisorIDTxt;
        private System.Windows.Forms.TextBox PasswordTxt;
        private System.Windows.Forms.Button btnAddCoach;
        private System.Windows.Forms.Button btnDeleteCoach;
        private System.Windows.Forms.TextBox CoachIDTxt;
        private System.Windows.Forms.Button btnSearchCoach;
        private System.Windows.Forms.DataGridView DGV_coachSearch;
        private System.Windows.Forms.DataGridView DGV_SlotTimings;
        private System.Windows.Forms.DataGridView DGV_Certifications;
        private System.Windows.Forms.DataGridView DGV_AllSlotTimings;
        private System.Windows.Forms.DataGridView DGV_AllCertifications;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnExit;
        private Button button1;
        private Button button2;
        private Label label1;
        private ComboBox UpdateChoice;
        private TextBox UpdateTxt;
        private Button button6;
        private Label label4;
        private TextBox IDTxt;
        private Label label2;
        private Label label3;
    }
}