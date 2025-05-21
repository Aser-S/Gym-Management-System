namespace DatabaseProject
{
    partial class Login
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
            EmailLogin = new TextBox();
            PasswordLogin = new TextBox();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            label3 = new Label();
            button2 = new Button();
            SuspendLayout();
            // 
            // EmailLogin
            // 
            EmailLogin.Font = new Font("Segoe UI", 15F);
            EmailLogin.Location = new Point(744, 360);
            EmailLogin.Multiline = true;
            EmailLogin.Name = "EmailLogin";
            EmailLogin.Size = new Size(534, 56);
            EmailLogin.TabIndex = 0;
            // 
            // PasswordLogin
            // 
            PasswordLogin.Font = new Font("Segoe UI", 15F);
            PasswordLogin.Location = new Point(744, 517);
            PasswordLogin.Name = "PasswordLogin";
            PasswordLogin.Size = new Size(534, 47);
            PasswordLogin.TabIndex = 0;
            PasswordLogin.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(744, 290);
            label1.Name = "label1";
            label1.Size = new Size(117, 54);
            label1.TabIndex = 1;
            label1.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20F);
            label2.Location = new Point(744, 446);
            label2.Name = "label2";
            label2.Size = new Size(188, 54);
            label2.TabIndex = 1;
            label2.Text = "Password";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 15F);
            button1.Location = new Point(845, 613);
            button1.Name = "button1";
            button1.Size = new Size(116, 61);
            button1.TabIndex = 2;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Login_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 30F);
            label3.Location = new Point(777, 190);
            label3.Name = "label3";
            label3.Size = new Size(438, 81);
            label3.TabIndex = 1;
            label3.Text = "Welcome back!";
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 15F);
            button2.Location = new Point(1000, 613);
            button2.Name = "button2";
            button2.Size = new Size(140, 61);
            button2.TabIndex = 2;
            button2.Text = "Register";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Register;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1827, 777);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(PasswordLogin);
            Controls.Add(EmailLogin);
            Name = "Login";
            Text = "Login";
            Load += Login_Load;
            Click += Login_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox EmailLogin;
        private TextBox PasswordLogin;
        private Label label1;
        private Label label2;
        private Button button1;
        private Label label3;
        private Button button2;
    }
}
