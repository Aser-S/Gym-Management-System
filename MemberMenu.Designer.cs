namespace DatabaseProject
{
    partial class MemberMenu
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
            DGV_Member = new DataGridView();
            WelcomeMsg = new Label();
            button1 = new Button();
            txtTiming = new TextBox();
            button2 = new Button();
            button3 = new Button();
            txtCoachID = new TextBox();
            label2 = new Label();
            button4 = new Button();
            txtLockerNumber = new TextBox();
            label3 = new Label();
            button5 = new Button();
            DGV_Guests = new DataGridView();
            button6 = new Button();
            GuestRelationTxt = new TextBox();
            GuestNameTxt = new TextBox();
            label5 = new Label();
            TypeTxt = new ComboBox();
            label1 = new Label();
            DGV_Types = new DataGridView();
            label4 = new Label();
            label6 = new Label();
            DurationNum = new NumericUpDown();
            AddShipBtn = new Button();
            label7 = new Label();
            label8 = new Label();
            button7 = new Button();
            ((System.ComponentModel.ISupportInitialize)DGV_Member).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DGV_Guests).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DGV_Types).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DurationNum).BeginInit();
            SuspendLayout();
            // 
            // DGV_Member
            // 
            DGV_Member.BackgroundColor = SystemColors.MenuBar;
            DGV_Member.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Member.Location = new Point(42, 239);
            DGV_Member.Name = "DGV_Member";
            DGV_Member.RowHeadersWidth = 62;
            DGV_Member.Size = new Size(467, 151);
            DGV_Member.TabIndex = 0;
            // 
            // WelcomeMsg
            // 
            WelcomeMsg.AutoSize = true;
            WelcomeMsg.Font = new Font("Segoe UI", 15F);
            WelcomeMsg.Location = new Point(42, 48);
            WelcomeMsg.Name = "WelcomeMsg";
            WelcomeMsg.Size = new Size(215, 41);
            WelcomeMsg.TabIndex = 1;
            WelcomeMsg.Text = "Welcome, Aser";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F);
            button1.Location = new Point(42, 408);
            button1.Name = "button1";
            button1.Size = new Size(467, 73);
            button1.TabIndex = 2;
            button1.Text = "Show Guest Log";
            button1.UseVisualStyleBackColor = true;
            button1.Click += ShowGuestLog;
            // 
            // txtTiming
            // 
            txtTiming.Location = new Point(557, 398);
            txtTiming.Multiline = true;
            txtTiming.Name = "txtTiming";
            txtTiming.PlaceholderText = "Enter Slot";
            txtTiming.Size = new Size(467, 38);
            txtTiming.TabIndex = 3;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 12F);
            button2.Location = new Point(557, 446);
            button2.Name = "button2";
            button2.Size = new Size(467, 54);
            button2.TabIndex = 2;
            button2.Text = "Book";
            button2.UseVisualStyleBackColor = true;
            button2.Click += BookCoach;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 12F);
            button3.Location = new Point(42, 140);
            button3.Name = "button3";
            button3.Size = new Size(467, 79);
            button3.TabIndex = 2;
            button3.Text = "Show My Info";
            button3.UseVisualStyleBackColor = true;
            button3.Click += ShowInfo;
            // 
            // txtCoachID
            // 
            txtCoachID.Location = new Point(557, 346);
            txtCoachID.Multiline = true;
            txtCoachID.Name = "txtCoachID";
            txtCoachID.PasswordChar = '*';
            txtCoachID.PlaceholderText = "Enter ID";
            txtCoachID.Size = new Size(467, 38);
            txtCoachID.TabIndex = 3;
            txtCoachID.Tag = "";
            txtCoachID.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(557, 302);
            label2.Name = "label2";
            label2.Size = new Size(141, 32);
            label2.TabIndex = 4;
            label2.Text = "Book Coach";
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 12F);
            button4.Location = new Point(557, 237);
            button4.Name = "button4";
            button4.Size = new Size(467, 54);
            button4.TabIndex = 2;
            button4.Text = "Set";
            button4.UseVisualStyleBackColor = true;
            button4.Click += SetLockerNumber;
            // 
            // txtLockerNumber
            // 
            txtLockerNumber.Location = new Point(557, 189);
            txtLockerNumber.Multiline = true;
            txtLockerNumber.Name = "txtLockerNumber";
            txtLockerNumber.PlaceholderText = "Enter Number";
            txtLockerNumber.Size = new Size(467, 38);
            txtLockerNumber.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(557, 141);
            label3.Name = "label3";
            label3.Size = new Size(219, 32);
            label3.TabIndex = 4;
            label3.Text = "Set Locker Number";
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 12F);
            button5.Location = new Point(42, 812);
            button5.Name = "button5";
            button5.Size = new Size(102, 54);
            button5.TabIndex = 2;
            button5.Text = "Logout";
            button5.UseVisualStyleBackColor = true;
            button5.Click += Logout;
            // 
            // DGV_Guests
            // 
            DGV_Guests.BackgroundColor = SystemColors.MenuBar;
            DGV_Guests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Guests.Location = new Point(42, 507);
            DGV_Guests.Name = "DGV_Guests";
            DGV_Guests.RowHeadersWidth = 62;
            DGV_Guests.Size = new Size(467, 218);
            DGV_Guests.TabIndex = 0;
            // 
            // button6
            // 
            button6.Font = new Font("Segoe UI", 12F);
            button6.Location = new Point(557, 671);
            button6.Name = "button6";
            button6.Size = new Size(467, 54);
            button6.TabIndex = 2;
            button6.Text = "Enter";
            button6.UseVisualStyleBackColor = true;
            button6.Click += AddGuest;
            // 
            // GuestRelationTxt
            // 
            GuestRelationTxt.Location = new Point(557, 623);
            GuestRelationTxt.Multiline = true;
            GuestRelationTxt.Name = "GuestRelationTxt";
            GuestRelationTxt.PlaceholderText = "Enter Their Relation";
            GuestRelationTxt.Size = new Size(467, 38);
            GuestRelationTxt.TabIndex = 3;
            // 
            // GuestNameTxt
            // 
            GuestNameTxt.Location = new Point(557, 567);
            GuestNameTxt.Multiline = true;
            GuestNameTxt.Name = "GuestNameTxt";
            GuestNameTxt.PlaceholderText = "Enter Their Full Name";
            GuestNameTxt.Size = new Size(467, 38);
            GuestNameTxt.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(557, 518);
            label5.Name = "label5";
            label5.Size = new Size(269, 32);
            label5.TabIndex = 4;
            label5.Text = "Enter Guest's Full Name";
            // 
            // TypeTxt
            // 
            TypeTxt.FormattingEnabled = true;
            TypeTxt.Items.AddRange(new object[] { "Silver", "Gold", "Platinum" });
            TypeTxt.Location = new Point(1477, 247);
            TypeTxt.Name = "TypeTxt";
            TypeTxt.Size = new Size(323, 33);
            TypeTxt.TabIndex = 29;
            TypeTxt.Text = "Type";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(1477, 190);
            label1.Name = "label1";
            label1.Size = new Size(288, 32);
            label1.TabIndex = 21;
            label1.Text = "Subscribe to Membership";
            // 
            // DGV_Types
            // 
            DGV_Types.BackgroundColor = SystemColors.MenuBar;
            DGV_Types.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Types.Location = new Point(1056, 189);
            DGV_Types.Name = "DGV_Types";
            DGV_Types.RowHeadersWidth = 62;
            DGV_Types.Size = new Size(393, 237);
            DGV_Types.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(1056, 139);
            label4.Name = "label4";
            label4.Size = new Size(217, 32);
            label4.TabIndex = 4;
            label4.Text = "Membership Types";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F);
            label6.ForeColor = SystemColors.ControlDarkDark;
            label6.Location = new Point(1279, 146);
            label6.Name = "label6";
            label6.Size = new Size(478, 25);
            label6.TabIndex = 4;
            label6.Text = "Address pricings with staff members to complete payment";
            // 
            // DurationNum
            // 
            DurationNum.Location = new Point(1488, 340);
            DurationNum.Name = "DurationNum";
            DurationNum.Size = new Size(63, 31);
            DurationNum.TabIndex = 30;
            DurationNum.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // AddShipBtn
            // 
            AddShipBtn.Font = new Font("Segoe UI", 12F);
            AddShipBtn.Location = new Point(1564, 330);
            AddShipBtn.Name = "AddShipBtn";
            AddShipBtn.Size = new Size(236, 62);
            AddShipBtn.TabIndex = 2;
            AddShipBtn.Text = "Subscribe";
            AddShipBtn.UseVisualStyleBackColor = true;
            AddShipBtn.Click += AddMembership;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1477, 295);
            label7.Name = "label7";
            label7.Size = new Size(157, 25);
            label7.TabIndex = 32;
            label7.Text = "Duration (months)";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = SystemColors.ControlDarkDark;
            label8.Location = new Point(1488, 401);
            label8.Name = "label8";
            label8.Size = new Size(299, 25);
            label8.TabIndex = 32;
            label8.Text = "Go to reception to confirm payment";
            // 
            // button7
            // 
            button7.Font = new Font("Segoe UI", 12F);
            button7.Location = new Point(1779, 12);
            button7.Name = "button7";
            button7.Size = new Size(102, 54);
            button7.TabIndex = 2;
            button7.Text = "Exit";
            button7.UseVisualStyleBackColor = true;
            button7.Click += ExitApplication;
            // 
            // MemberMenu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1893, 900);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(DurationNum);
            Controls.Add(TypeTxt);
            Controls.Add(label1);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(GuestNameTxt);
            Controls.Add(txtCoachID);
            Controls.Add(txtLockerNumber);
            Controls.Add(GuestRelationTxt);
            Controls.Add(txtTiming);
            Controls.Add(button7);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button6);
            Controls.Add(AddShipBtn);
            Controls.Add(button2);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(WelcomeMsg);
            Controls.Add(DGV_Guests);
            Controls.Add(DGV_Types);
            Controls.Add(DGV_Member);
            Name = "MemberMenu";
            Text = "MemberMenu";
            Load += MemberMenu_Load;
            ((System.ComponentModel.ISupportInitialize)DGV_Member).EndInit();
            ((System.ComponentModel.ISupportInitialize)DGV_Guests).EndInit();
            ((System.ComponentModel.ISupportInitialize)DGV_Types).EndInit();
            ((System.ComponentModel.ISupportInitialize)DurationNum).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DGV_Member;
        private Label WelcomeMsg;
        private Button button1;
        private TextBox txtTiming;
        private Button button2;
        private Button button3;
        private TextBox txtCoachID;
        private Label label2;
        private Button button4;
        private TextBox txtLockerNumber;
        private Label label3;
        private Button button5;
        private DataGridView DGV_Guests;
        private Button button6;
        private TextBox GuestRelationTxt;
        private TextBox GuestNameTxt;
        private Label label5;
        private ComboBox TypeTxt;
        private Label label11;
        private Label label13;
        private TextBox SSNTxt;
        private Label label1;
        private DataGridView DGV_Types;
        private Label label4;
        private Label label6;
        private NumericUpDown DurationNum;
        private Button AddShipBtn;
        private Label label7;
        private Label label8;
        private Button button7;
    }
}