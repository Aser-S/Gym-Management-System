namespace DatabaseProject
{
    partial class ManageSuppliers
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
            NameTxt = new TextBox();
            label15 = new Label();
            PhoneTxt = new TextBox();
            label16 = new Label();
            button5 = new Button();
            DGV_All = new DataGridView();
            label5 = new Label();
            button1 = new Button();
            label1 = new Label();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            UpdateChoice = new ComboBox();
            IDTxt = new TextBox();
            button4 = new Button();
            label4 = new Label();
            button3 = new Button();
            UpdateTxt = new TextBox();
            ((System.ComponentModel.ISupportInitialize)DGV_All).BeginInit();
            SuspendLayout();
            // 
            // NameTxt
            // 
            NameTxt.Location = new Point(1017, 284);
            NameTxt.Name = "NameTxt";
            NameTxt.Size = new Size(305, 31);
            NameTxt.TabIndex = 83;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 15F);
            label15.Location = new Point(1016, 223);
            label15.Name = "label15";
            label15.Size = new Size(214, 41);
            label15.TabIndex = 73;
            label15.Text = "Supplier Name";
            // 
            // PhoneTxt
            // 
            PhoneTxt.Location = new Point(1394, 284);
            PhoneTxt.Name = "PhoneTxt";
            PhoneTxt.Size = new Size(323, 31);
            PhoneTxt.TabIndex = 93;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 15F);
            label16.Location = new Point(1393, 223);
            label16.Name = "label16";
            label16.Size = new Size(220, 41);
            label16.TabIndex = 72;
            label16.Text = "Phone Number";
            // 
            // button5
            // 
            button5.Location = new Point(1281, 349);
            button5.Name = "button5";
            button5.Size = new Size(153, 46);
            button5.TabIndex = 64;
            button5.Text = "Add";
            button5.UseVisualStyleBackColor = true;
            button5.Click += AddNewMember;
            // 
            // DGV_All
            // 
            DGV_All.BackgroundColor = SystemColors.MenuBar;
            DGV_All.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_All.Location = new Point(30, 189);
            DGV_All.Name = "DGV_All";
            DGV_All.RowHeadersWidth = 62;
            DGV_All.Size = new Size(787, 535);
            DGV_All.TabIndex = 65;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 20F);
            label5.Location = new Point(1001, 140);
            label5.Name = "label5";
            label5.Size = new Size(346, 54);
            label5.TabIndex = 55;
            label5.Text = "Add New Supplier";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F);
            button1.Location = new Point(30, 127);
            button1.Name = "button1";
            button1.Size = new Size(787, 56);
            button1.TabIndex = 58;
            button1.Text = "View All";
            button1.UseVisualStyleBackColor = true;
            button1.Click += ViewAll;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(32, 29);
            label1.Name = "label1";
            label1.Size = new Size(417, 54);
            label1.TabIndex = 51;
            label1.Text = "Supplier Management";
            // 
            // button6
            // 
            button6.Font = new Font("Segoe UI", 12F);
            button6.Location = new Point(-1213, 469);
            button6.Name = "button6";
            button6.Size = new Size(360, 56);
            button6.TabIndex = 58;
            button6.Text = "Logout";
            button6.UseVisualStyleBackColor = true;
            button6.Click += Logout;
            // 
            // button7
            // 
            button7.Location = new Point(19, 747);
            button7.Name = "button7";
            button7.Size = new Size(138, 46);
            button7.TabIndex = 60;
            button7.Text = "Back";
            button7.UseVisualStyleBackColor = true;
            button7.Click += BackToOwner;
            // 
            // button8
            // 
            button8.Location = new Point(1733, 12);
            button8.Name = "button8";
            button8.Size = new Size(79, 46);
            button8.TabIndex = 60;
            button8.Text = "Exit";
            button8.UseVisualStyleBackColor = true;
            button8.Click += ExitApplication;
            // 
            // UpdateChoice
            // 
            UpdateChoice.FormattingEnabled = true;
            UpdateChoice.Items.AddRange(new object[] { "Name", "Phone" });
            UpdateChoice.Location = new Point(1026, 625);
            UpdateChoice.Name = "UpdateChoice";
            UpdateChoice.Size = new Size(169, 33);
            UpdateChoice.TabIndex = 97;
            // 
            // IDTxt
            // 
            IDTxt.Location = new Point(1026, 466);
            IDTxt.Name = "IDTxt";
            IDTxt.PlaceholderText = "Enter SupplierID";
            IDTxt.Size = new Size(645, 31);
            IDTxt.TabIndex = 96;
            IDTxt.TextChanged += UpdateTxt_TextChanged;
            // 
            // button4
            // 
            button4.Location = new Point(1509, 620);
            button4.Name = "button4";
            button4.Size = new Size(162, 46);
            button4.TabIndex = 95;
            button4.Text = "Update";
            button4.UseVisualStyleBackColor = true;
            button4.Click += ChangeAttribute;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F);
            label4.Location = new Point(1026, 583);
            label4.Name = "label4";
            label4.Size = new Size(178, 30);
            label4.TabIndex = 94;
            label4.Text = "Change Attribute";
            // 
            // button3
            // 
            button3.Location = new Point(1026, 524);
            button3.Name = "button3";
            button3.Size = new Size(645, 46);
            button3.TabIndex = 98;
            button3.Text = "Delete";
            button3.UseVisualStyleBackColor = true;
            button3.Click += DeleteSupplier;
            // 
            // UpdateTxt
            // 
            UpdateTxt.Location = new Point(1211, 625);
            UpdateTxt.Name = "UpdateTxt";
            UpdateTxt.PlaceholderText = "Enter your Change";
            UpdateTxt.Size = new Size(263, 31);
            UpdateTxt.TabIndex = 96;
            UpdateTxt.TextChanged += UpdateTxt_TextChanged;
            // 
            // ManageSuppliers
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1824, 801);
            Controls.Add(button3);
            Controls.Add(UpdateChoice);
            Controls.Add(UpdateTxt);
            Controls.Add(IDTxt);
            Controls.Add(button4);
            Controls.Add(label4);
            Controls.Add(NameTxt);
            Controls.Add(label15);
            Controls.Add(PhoneTxt);
            Controls.Add(label16);
            Controls.Add(button5);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(DGV_All);
            Controls.Add(label5);
            Controls.Add(button6);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "ManageSuppliers";
            Text = "ManageSuppliers";
            Load += ManageSuppliers_Load;
            ((System.ComponentModel.ISupportInitialize)DGV_All).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox NameTxt;
        private Label label15;
        private TextBox PhoneTxt;
        private Label label16;
        private Button button5;
        private DataGridView DGV_All;
        private Label label5;
        private Button button1;
        private Label label1;
        private Button button6;
        private Button button7;
        private Button button8;
        private ComboBox UpdateChoice;
        private TextBox IDTxt;
        private Button button4;
        private Label label4;
        private Button button3;
        private TextBox UpdateTxt;
    }
}