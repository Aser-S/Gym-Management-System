namespace DatabaseProject
{
    partial class OwnerMenu
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
            button2 = new Button();
            button3 = new Button();
            button1 = new Button();
            WelcomeMsg = new Label();
            DGV_Owner = new DataGridView();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            ((System.ComponentModel.ISupportInitialize)DGV_Owner).BeginInit();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 12F);
            button2.Location = new Point(37, 300);
            button2.Name = "button2";
            button2.Size = new Size(467, 54);
            button2.TabIndex = 7;
            button2.Text = "Manage Staff";
            button2.UseVisualStyleBackColor = true;
            button2.Click += staff;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 12F);
            button3.Location = new Point(37, 121);
            button3.Name = "button3";
            button3.Size = new Size(467, 54);
            button3.TabIndex = 8;
            button3.Text = "Show My Info";
            button3.UseVisualStyleBackColor = true;
            button3.Click += ShowInfo;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F);
            button1.Location = new Point(565, 240);
            button1.Name = "button1";
            button1.Size = new Size(467, 54);
            button1.TabIndex = 9;
            button1.Text = "Manage Equipment";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Equipment;
            // 
            // WelcomeMsg
            // 
            WelcomeMsg.AutoSize = true;
            WelcomeMsg.Font = new Font("Segoe UI", 15F);
            WelcomeMsg.Location = new Point(37, 51);
            WelcomeMsg.Name = "WelcomeMsg";
            WelcomeMsg.Size = new Size(215, 41);
            WelcomeMsg.TabIndex = 6;
            WelcomeMsg.Text = "Welcome, Aser";
            // 
            // DGV_Owner
            // 
            DGV_Owner.BackgroundColor = SystemColors.MenuBar;
            DGV_Owner.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Owner.Location = new Point(565, 97);
            DGV_Owner.Name = "DGV_Owner";
            DGV_Owner.RowHeadersWidth = 62;
            DGV_Owner.Size = new Size(467, 107);
            DGV_Owner.TabIndex = 5;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 12F);
            button4.Location = new Point(37, 240);
            button4.Name = "button4";
            button4.Size = new Size(467, 54);
            button4.TabIndex = 9;
            button4.Text = "Manage Members";
            button4.UseVisualStyleBackColor = true;
            button4.Click += Members;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 12F);
            button5.Location = new Point(565, 300);
            button5.Name = "button5";
            button5.Size = new Size(467, 54);
            button5.TabIndex = 9;
            button5.Text = "Manage Suppliers";
            button5.UseVisualStyleBackColor = true;
            button5.Click += Suppliers;
            // 
            // button6
            // 
            button6.Font = new Font("Segoe UI", 12F);
            button6.Location = new Point(37, 521);
            button6.Name = "button6";
            button6.Size = new Size(134, 54);
            button6.TabIndex = 9;
            button6.Text = "Logout";
            button6.UseVisualStyleBackColor = true;
            button6.Click += Logout;
            // 
            // button7
            // 
            button7.Font = new Font("Segoe UI", 12F);
            button7.Location = new Point(37, 360);
            button7.Name = "button7";
            button7.Size = new Size(467, 54);
            button7.TabIndex = 7;
            button7.Text = "Manage Orders";
            button7.UseVisualStyleBackColor = true;
            button7.Click += Orders;
            // 
            // button8
            // 
            button8.Font = new Font("Segoe UI", 12F);
            button8.Location = new Point(1047, 12);
            button8.Name = "button8";
            button8.Size = new Size(81, 54);
            button8.TabIndex = 9;
            button8.Text = "Exit";
            button8.UseVisualStyleBackColor = true;
            button8.Click += ExitApplication;
            // 
            // button9
            // 
            button9.Font = new Font("Segoe UI", 12F);
            button9.Location = new Point(565, 360);
            button9.Name = "button9";
            button9.Size = new Size(467, 54);
            button9.TabIndex = 9;
            button9.Text = "Manage Coaches";
            button9.UseVisualStyleBackColor = true;
            button9.Click += Coach;
            // 
            // button10
            // 
            button10.Font = new Font("Segoe UI", 12F);
            button10.Location = new Point(307, 433);
            button10.Name = "button10";
            button10.Size = new Size(467, 54);
            button10.TabIndex = 7;
            button10.Text = "Manage Memberships";
            button10.UseVisualStyleBackColor = true;
            button10.Click += Membership;
            // 
            // OwnerMenu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1140, 615);
            Controls.Add(button10);
            Controls.Add(button7);
            Controls.Add(button2);
            Controls.Add(button3);
            Controls.Add(button4);
            Controls.Add(button8);
            Controls.Add(button6);
            Controls.Add(button9);
            Controls.Add(button5);
            Controls.Add(button1);
            Controls.Add(WelcomeMsg);
            Controls.Add(DGV_Owner);
            Name = "OwnerMenu";
            Text = "OwnerMenu";
            Load += OwnerMenu_Load;
            ((System.ComponentModel.ISupportInitialize)DGV_Owner).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button2;
        private Button button3;
        private Button button1;
        private Label WelcomeMsg;
        private DataGridView DGV_Owner;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
    }
}