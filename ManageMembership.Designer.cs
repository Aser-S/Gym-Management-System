using MaterialSkin.Controls;

namespace DatabaseProject
{
    public partial class ManageMembership : MaterialForm
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>



        private TextBox DurationMonthTxt;
        private Label label11;
        private Label label13;
        private ComboBox TypeNameComboBox; // Changed from TextBox to ComboBox
        private Label label15;
        private TextBox MemberIDTxt;
        private Label label16;
        private DataGridView DGV_Sort;
        private Button button5;
        private Button button2;
        private DataGridView DGV_ViewAll;
        private Label label5;
        private Label label3;
        private Button button1;
        private ComboBox SortByTxt;
        private DateTimePicker dateTimePicker1;



        private void InitializeComponent()
        {
            DurationMonthTxt = new TextBox();
            label11 = new Label();
            label13 = new Label();
            TypeNameComboBox = new ComboBox();
            label15 = new Label();
            MemberIDTxt = new TextBox();
            label16 = new Label();
            DGV_Sort = new DataGridView();
            button5 = new Button();
            button2 = new Button();
            DGV_ViewAll = new DataGridView();
            label5 = new Label();
            label3 = new Label();
            button1 = new Button();
            SortByTxt = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            SearchBtn = new Button();
            label2 = new Label();
            MemberShipIDtxt = new TextBox();
            label4 = new Label();
            UpdateAttribute = new ComboBox();
            label6 = new Label();
            UpdateValtxt = new TextBox();
            label7 = new Label();
            UpdateBtn = new Button();
            SearchEmail = new TextBox();
            label8 = new Label();
            DeleteBtn = new Button();
            button3 = new Button();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)DGV_Sort).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DGV_ViewAll).BeginInit();
            SuspendLayout();
            // 
            // DurationMonthTxt
            // 
            DurationMonthTxt.Location = new Point(301, 655);
            DurationMonthTxt.Margin = new Padding(2);
            DurationMonthTxt.Name = "DurationMonthTxt";
            DurationMonthTxt.Size = new Size(196, 31);
            DurationMonthTxt.TabIndex = 48;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(306, 629);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(166, 25);
            label11.TabIndex = 44;
            label11.Text = "Duration in months";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(207, 695);
            label13.Margin = new Padding(2, 0, 2, 0);
            label13.Name = "label13";
            label13.Size = new Size(90, 25);
            label13.TabIndex = 40;
            label13.Text = "Start Date";
            // 
            // TypeNameComboBox
            // 
            TypeNameComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            TypeNameComboBox.FormattingEnabled = true;
            TypeNameComboBox.Location = new Point(34, 652);
            TypeNameComboBox.Margin = new Padding(2);
            TypeNameComboBox.Name = "TypeNameComboBox";
            TypeNameComboBox.Size = new Size(245, 33);
            TypeNameComboBox.TabIndex = 45;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(39, 626);
            label15.Margin = new Padding(2, 0, 2, 0);
            label15.Name = "label15";
            label15.Size = new Size(101, 25);
            label15.TabIndex = 38;
            label15.Text = "Type Name";
            // 
            // MemberIDTxt
            // 
            MemberIDTxt.Location = new Point(34, 725);
            MemberIDTxt.Margin = new Padding(2);
            MemberIDTxt.Name = "MemberIDTxt";
            MemberIDTxt.Size = new Size(102, 31);
            MemberIDTxt.TabIndex = 50;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(40, 699);
            label16.Margin = new Padding(2, 0, 2, 0);
            label16.Name = "label16";
            label16.Size = new Size(102, 25);
            label16.TabIndex = 37;
            label16.Text = "Member ID";
            // 
            // DGV_Sort
            // 
            DGV_Sort.BackgroundColor = SystemColors.MenuBar;
            DGV_Sort.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Sort.Location = new Point(901, 233);
            DGV_Sort.Margin = new Padding(2, 0, 0, 0);
            DGV_Sort.Name = "DGV_Sort";
            DGV_Sort.RowHeadersWidth = 62;
            DGV_Sort.Size = new Size(516, 218);
            DGV_Sort.TabIndex = 33;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.Location = new Point(361, 579);
            button5.Margin = new Padding(2);
            button5.Name = "button5";
            button5.Size = new Size(138, 34);
            button5.TabIndex = 31;
            button5.Text = "Add ";
            button5.UseVisualStyleBackColor = true;
            button5.Click += AddMembership;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button2.Location = new Point(901, 182);
            button2.Margin = new Padding(2);
            button2.Name = "button2";
            button2.Size = new Size(190, 49);
            button2.TabIndex = 28;
            button2.Text = "Sort";
            button2.UseVisualStyleBackColor = true;
            button2.Click += SortEquipmentOrders;
            // 
            // DGV_ViewAll
            // 
            DGV_ViewAll.BackgroundColor = SystemColors.MenuBar;
            DGV_ViewAll.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_ViewAll.Location = new Point(32, 157);
            DGV_ViewAll.Margin = new Padding(2);
            DGV_ViewAll.Name = "DGV_ViewAll";
            DGV_ViewAll.RowHeadersWidth = 62;
            DGV_ViewAll.Size = new Size(794, 294);
            DGV_ViewAll.TabIndex = 32;
            DGV_ViewAll.CellContentClick += DGV_ViewAll_CellContentClick;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(32, 573);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(313, 38);
            label5.TabIndex = 25;
            label5.Text = "Make New Membership";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(901, 101);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(90, 32);
            label3.TabIndex = 24;
            label3.Text = "Sort By";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button1.Location = new Point(32, 455);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(288, 45);
            button1.TabIndex = 27;
            button1.Text = "View All";
            button1.UseVisualStyleBackColor = true;
            button1.Click += ViewAll;
            // 
            // SortByTxt
            // 
            SortByTxt.DropDownStyle = ComboBoxStyle.DropDownList;
            SortByTxt.FormattingEnabled = true;
            SortByTxt.Items.AddRange(new object[] { "StartDate", "ExpiryDate", "Duration", "Member", "Type" });
            SortByTxt.Location = new Point(901, 142);
            SortByTxt.Margin = new Padding(2);
            SortByTxt.Name = "SortByTxt";
            SortByTxt.Size = new Size(190, 33);
            SortByTxt.TabIndex = 53;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.AccessibleName = "StartDate";
            dateTimePicker1.Location = new Point(201, 723);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(296, 31);
            dateTimePicker1.TabIndex = 54;
            // 
            // SearchBtn
            // 
            SearchBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            SearchBtn.Location = new Point(538, 455);
            SearchBtn.Margin = new Padding(2);
            SearchBtn.Name = "SearchBtn";
            SearchBtn.Size = new Size(288, 45);
            SearchBtn.TabIndex = 55;
            SearchBtn.Text = "Search";
            SearchBtn.UseVisualStyleBackColor = true;
            SearchBtn.Click += SearchBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(889, 569);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(270, 38);
            label2.TabIndex = 56;
            label2.Text = "Update Membership";
            // 
            // MemberShipIDtxt
            // 
            MemberShipIDtxt.Location = new Point(1141, 652);
            MemberShipIDtxt.Margin = new Padding(2);
            MemberShipIDtxt.Name = "MemberShipIDtxt";
            MemberShipIDtxt.Size = new Size(102, 31);
            MemberShipIDtxt.TabIndex = 58;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1141, 623);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(135, 25);
            label4.TabIndex = 57;
            label4.Text = "Membership ID";
            // 
            // UpdateAttribute
            // 
            UpdateAttribute.DropDownStyle = ComboBoxStyle.DropDownList;
            UpdateAttribute.FormattingEnabled = true;
            UpdateAttribute.Items.AddRange(new object[] { "MemberID", "Duration", "Type" });
            UpdateAttribute.Location = new Point(901, 654);
            UpdateAttribute.Margin = new Padding(2);
            UpdateAttribute.Name = "UpdateAttribute";
            UpdateAttribute.Size = new Size(190, 33);
            UpdateAttribute.TabIndex = 59;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(898, 627);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(82, 25);
            label6.TabIndex = 60;
            label6.Text = "Atttibute";
            // 
            // UpdateValtxt
            // 
            UpdateValtxt.Location = new Point(901, 729);
            UpdateValtxt.Margin = new Padding(2);
            UpdateValtxt.Name = "UpdateValtxt";
            UpdateValtxt.Size = new Size(152, 31);
            UpdateValtxt.TabIndex = 62;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(906, 701);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(89, 25);
            label7.TabIndex = 61;
            label7.Text = "NewValue";
            // 
            // UpdateBtn
            // 
            UpdateBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UpdateBtn.Location = new Point(1163, 571);
            UpdateBtn.Margin = new Padding(2);
            UpdateBtn.Name = "UpdateBtn";
            UpdateBtn.Size = new Size(138, 34);
            UpdateBtn.TabIndex = 63;
            UpdateBtn.Text = "Update";
            UpdateBtn.UseVisualStyleBackColor = true;
            UpdateBtn.Click += UpdateBtn_Click;
            // 
            // SearchEmail
            // 
            SearchEmail.Location = new Point(140, 104);
            SearchEmail.Margin = new Padding(2);
            SearchEmail.Name = "SearchEmail";
            SearchEmail.Size = new Size(492, 31);
            SearchEmail.TabIndex = 65;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(73, 100);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(71, 32);
            label8.TabIndex = 64;
            label8.Text = "Email";
            // 
            // DeleteBtn
            // 
            DeleteBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DeleteBtn.Location = new Point(363, 458);
            DeleteBtn.Margin = new Padding(2);
            DeleteBtn.Name = "DeleteBtn";
            DeleteBtn.Size = new Size(136, 50);
            DeleteBtn.TabIndex = 66;
            DeleteBtn.Text = "Delete";
            DeleteBtn.UseVisualStyleBackColor = true;
            DeleteBtn.Click += DeleteBtn_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(1563, 84);
            button3.Margin = new Padding(2);
            button3.Name = "button3";
            button3.Size = new Size(99, 34);
            button3.TabIndex = 31;
            button3.Text = "Exit";
            button3.UseVisualStyleBackColor = true;
            button3.Click += ExitApplication;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.Location = new Point(30, 889);
            button4.Margin = new Padding(2);
            button4.Name = "button4";
            button4.Size = new Size(138, 34);
            button4.TabIndex = 31;
            button4.Text = "Back";
            button4.UseVisualStyleBackColor = true;
            button4.Click += BackToOwner;
            // 
            // ManageMembership
            // 
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1706, 1106);
            Controls.Add(DeleteBtn);
            Controls.Add(SearchEmail);
            Controls.Add(label8);
            Controls.Add(UpdateBtn);
            Controls.Add(UpdateValtxt);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(UpdateAttribute);
            Controls.Add(MemberShipIDtxt);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(SearchBtn);
            Controls.Add(dateTimePicker1);
            Controls.Add(SortByTxt);
            Controls.Add(DurationMonthTxt);
            Controls.Add(label11);
            Controls.Add(label13);
            Controls.Add(TypeNameComboBox);
            Controls.Add(label15);
            Controls.Add(MemberIDTxt);
            Controls.Add(label16);
            Controls.Add(DGV_Sort);
            Controls.Add(button3);
            Controls.Add(button4);
            Controls.Add(button5);
            Controls.Add(button2);
            Controls.Add(DGV_ViewAll);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(button1);
            Cursor = Cursors.Hand;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2);
            Name = "ManageMembership";
            RightToLeftLayout = true;
            Text = "Manage Membership";
            Load += ManageMembership_Load;
            ((System.ComponentModel.ISupportInitialize)DGV_Sort).EndInit();
            ((System.ComponentModel.ISupportInitialize)DGV_ViewAll).EndInit();
            ResumeLayout(false);
            PerformLayout();



        }
        private Button SearchBtn;
        private Label label2;
        private TextBox MemberShipIDtxt;
        private Label label4;
        private ComboBox UpdateAttribute;
        private Label label6;
        private TextBox UpdateValtxt;
        private Label label7;
        private Button UpdateBtn;
        private TextBox SearchEmail;
        private Label label8;
        private Button DeleteBtn;
        private Button button3;
        private Button button4;
    }
}