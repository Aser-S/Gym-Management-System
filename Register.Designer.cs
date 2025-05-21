namespace DatabaseProject
{
    partial class Register
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
            SSNTxt = new TextBox();
            label2 = new Label();
            label3 = new Label();
            PhoneTxt = new TextBox();
            label4 = new Label();
            label5 = new Label();
            FirstNameTxt = new TextBox();
            label6 = new Label();
            label7 = new Label();
            EmailTxt = new TextBox();
            LastNameTxt = new TextBox();
            label8 = new Label();
            PasswordTxt = new TextBox();
            Gender = new ComboBox();
            birthDateInput = new DateTimePicker();
            button1 = new Button();
            label9 = new Label();
            label10 = new Label();
            hi = new Label();
            label12 = new Label();
            memHeight = new TextBox();
            memWeight = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(428, 108);
            label1.Name = "label1";
            label1.Size = new Size(45, 25);
            label1.TabIndex = 0;
            label1.Text = "SSN";
            // 
            // SSNTxt
            // 
            SSNTxt.Location = new Point(421, 140);
            SSNTxt.Name = "SSNTxt";
            SSNTxt.Size = new Size(323, 31);
            SSNTxt.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(428, 188);
            label2.Name = "label2";
            label2.Size = new Size(69, 25);
            label2.TabIndex = 0;
            label2.Text = "Gender";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(428, 363);
            label3.Name = "label3";
            label3.Size = new Size(62, 25);
            label3.TabIndex = 0;
            label3.Text = "Phone";
            // 
            // PhoneTxt
            // 
            PhoneTxt.Location = new Point(421, 395);
            PhoneTxt.Name = "PhoneTxt";
            PhoneTxt.Size = new Size(323, 31);
            PhoneTxt.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(428, 443);
            label4.Name = "label4";
            label4.Size = new Size(83, 25);
            label4.TabIndex = 0;
            label4.Text = "Birthdate";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(51, 110);
            label5.Name = "label5";
            label5.Size = new Size(97, 25);
            label5.TabIndex = 0;
            label5.Text = "First Name";
            // 
            // FirstNameTxt
            // 
            FirstNameTxt.Location = new Point(44, 142);
            FirstNameTxt.Name = "FirstNameTxt";
            FirstNameTxt.Size = new Size(305, 31);
            FirstNameTxt.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(51, 365);
            label6.Name = "label6";
            label6.Size = new Size(54, 25);
            label6.TabIndex = 0;
            label6.Text = "Email";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(51, 190);
            label7.Name = "label7";
            label7.Size = new Size(95, 25);
            label7.TabIndex = 0;
            label7.Text = "Last Name";
            // 
            // EmailTxt
            // 
            EmailTxt.Location = new Point(44, 397);
            EmailTxt.Name = "EmailTxt";
            EmailTxt.Size = new Size(305, 31);
            EmailTxt.TabIndex = 1;
            // 
            // LastNameTxt
            // 
            LastNameTxt.Location = new Point(44, 222);
            LastNameTxt.Name = "LastNameTxt";
            LastNameTxt.Size = new Size(305, 31);
            LastNameTxt.TabIndex = 1;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(51, 445);
            label8.Name = "label8";
            label8.Size = new Size(87, 25);
            label8.TabIndex = 0;
            label8.Text = "Password";
            // 
            // PasswordTxt
            // 
            PasswordTxt.Location = new Point(44, 477);
            PasswordTxt.Name = "PasswordTxt";
            PasswordTxt.Size = new Size(305, 31);
            PasswordTxt.TabIndex = 1;
            PasswordTxt.WordWrap = false;
            // 
            // Gender
            // 
            Gender.FormattingEnabled = true;
            Gender.Items.AddRange(new object[] { "M", "F" });
            Gender.Location = new Point(421, 220);
            Gender.Name = "Gender";
            Gender.Size = new Size(323, 33);
            Gender.TabIndex = 2;
            // 
            // birthDateInput
            // 
            birthDateInput.Location = new Point(421, 475);
            birthDateInput.Name = "birthDateInput";
            birthDateInput.Size = new Size(323, 31);
            birthDateInput.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(329, 550);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 4;
            button1.Text = "Register";
            button1.UseVisualStyleBackColor = true;
            button1.Click += RegisterNewMember;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 20F);
            label9.Location = new Point(294, 35);
            label9.Name = "label9";
            label9.Size = new Size(196, 54);
            label9.TabIndex = 5;
            label9.Text = "Welcome!";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = Color.DeepSkyBlue;
            label10.Location = new Point(461, 553);
            label10.Name = "label10";
            label10.Size = new Size(213, 25);
            label10.TabIndex = 6;
            label10.Text = "Already have an account?";
            label10.Click += AlreadyHaveAnAccount;
            // 
            // hi
            // 
            hi.AutoSize = true;
            hi.Location = new Point(428, 276);
            hi.Name = "hi";
            hi.Size = new Size(65, 25);
            hi.TabIndex = 0;
            hi.Text = "Height";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(51, 278);
            label12.Name = "label12";
            label12.Size = new Size(68, 25);
            label12.TabIndex = 0;
            label12.Text = "Weight\r\n";
            // 
            // memHeight
            // 
            memHeight.Location = new Point(421, 308);
            memHeight.Name = "memHeight";
            memHeight.Size = new Size(323, 31);
            memHeight.TabIndex = 1;
            // 
            // memWeight
            // 
            memWeight.Location = new Point(44, 310);
            memWeight.Name = "memWeight";
            memWeight.Size = new Size(305, 31);
            memWeight.TabIndex = 1;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 646);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(button1);
            Controls.Add(birthDateInput);
            Controls.Add(Gender);
            Controls.Add(PasswordTxt);
            Controls.Add(label8);
            Controls.Add(LastNameTxt);
            Controls.Add(label4);
            Controls.Add(memWeight);
            Controls.Add(EmailTxt);
            Controls.Add(label7);
            Controls.Add(memHeight);
            Controls.Add(label12);
            Controls.Add(PhoneTxt);
            Controls.Add(label6);
            Controls.Add(label2);
            Controls.Add(hi);
            Controls.Add(FirstNameTxt);
            Controls.Add(label3);
            Controls.Add(label5);
            Controls.Add(SSNTxt);
            Controls.Add(label1);
            Name = "Register";
            Text = "Register";
            Load += Register_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox SSNTxt;
        private Label label2;
        private Label label3;
        private TextBox PhoneTxt;
        private Label label4;
        private Label label5;
        private TextBox FirstNameTxt;
        private Label label6;
        private Label label7;
        private TextBox EmailTxt;
        private TextBox LastNameTxt;
        private Label label8;
        private TextBox PasswordTxt;
        private ComboBox Gender;
        private DateTimePicker birthDateInput;
        private Button button1;
        private Label label9;
        private Label label10;
        private Label hi;
        private Label label12;
        private TextBox memHeight;
        private TextBox memWeight;
    }
}