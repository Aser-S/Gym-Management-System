namespace DatabaseProject
{
    partial class ManageEquipment
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
            AddStockTxt = new TextBox();
            label16 = new Label();
            button5 = new Button();
            button3 = new Button();
            DGV_ViewAll = new DataGridView();
            label5 = new Label();
            button1 = new Button();
            label1 = new Label();
            label4 = new Label();
            CostTxt = new TextBox();
            label3 = new Label();
            button2 = new Button();
            DGV_Search = new DataGridView();
            SearchNameTxt = new TextBox();
            button4 = new Button();
            UpdateChoice = new ComboBox();
            UpdateTxt = new TextBox();
            button7 = new Button();
            label2 = new Label();
            IDTxt = new TextBox();
            button6 = new Button();
            ((System.ComponentModel.ISupportInitialize)DGV_ViewAll).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DGV_Search).BeginInit();
            SuspendLayout();
            // 
            // NameTxt
            // 
            NameTxt.Location = new Point(1097, 213);
            NameTxt.Name = "NameTxt";
            NameTxt.Size = new Size(305, 31);
            NameTxt.TabIndex = 83;
            NameTxt.TextChanged += FirstNameTxt_TextChanged;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(1104, 181);
            label15.Name = "label15";
            label15.Size = new Size(59, 25);
            label15.TabIndex = 73;
            label15.Text = "Name";
            // 
            // AddStockTxt
            // 
            AddStockTxt.Location = new Point(1474, 211);
            AddStockTxt.Name = "AddStockTxt";
            AddStockTxt.Size = new Size(323, 31);
            AddStockTxt.TabIndex = 93;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(1481, 179);
            label16.Name = "label16";
            label16.Size = new Size(55, 25);
            label16.TabIndex = 72;
            label16.Text = "Stock";
            // 
            // button5
            // 
            button5.Location = new Point(1358, 366);
            button5.Name = "button5";
            button5.Size = new Size(153, 46);
            button5.TabIndex = 64;
            button5.Text = "Add";
            button5.UseVisualStyleBackColor = true;
            button5.Click += NewEquipment;
            // 
            // button3
            // 
            button3.Location = new Point(419, 468);
            button3.Name = "button3";
            button3.Size = new Size(645, 46);
            button3.TabIndex = 60;
            button3.Text = "Delete";
            button3.UseVisualStyleBackColor = true;
            button3.Click += DeleteEquipment;
            // 
            // DGV_ViewAll
            // 
            DGV_ViewAll.BackgroundColor = SystemColors.MenuBar;
            DGV_ViewAll.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_ViewAll.Location = new Point(32, 183);
            DGV_ViewAll.Name = "DGV_ViewAll";
            DGV_ViewAll.RowHeadersWidth = 62;
            DGV_ViewAll.Size = new Size(360, 535);
            DGV_ViewAll.TabIndex = 65;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(1097, 129);
            label5.Name = "label5";
            label5.Size = new Size(235, 32);
            label5.TabIndex = 55;
            label5.Text = "Add New Equipment";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F);
            button1.Location = new Point(32, 121);
            button1.Name = "button1";
            button1.Size = new Size(360, 56);
            button1.TabIndex = 58;
            button1.Text = "View All";
            button1.UseVisualStyleBackColor = true;
            button1.Click += ViewAll;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(34, 23);
            label1.Name = "label1";
            label1.Size = new Size(463, 54);
            label1.TabIndex = 51;
            label1.Text = "Equipment Management";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1406, 268);
            label4.Name = "label4";
            label4.Size = new Size(48, 25);
            label4.TabIndex = 73;
            label4.Text = "Cost";
            // 
            // CostTxt
            // 
            CostTxt.Location = new Point(1283, 307);
            CostTxt.Name = "CostTxt";
            CostTxt.Size = new Size(305, 31);
            CostTxt.TabIndex = 83;
            CostTxt.TextChanged += FirstNameTxt_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(419, 129);
            label3.Name = "label3";
            label3.Size = new Size(223, 32);
            label3.TabIndex = 54;
            label3.Text = "Search Using Name";
            // 
            // button2
            // 
            button2.Location = new Point(419, 233);
            button2.Name = "button2";
            button2.Size = new Size(645, 34);
            button2.TabIndex = 59;
            button2.Text = "Search";
            button2.UseVisualStyleBackColor = true;
            button2.Click += SearchEquipmentByName;
            // 
            // DGV_Search
            // 
            DGV_Search.BackgroundColor = SystemColors.MenuBar;
            DGV_Search.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Search.Location = new Point(419, 278);
            DGV_Search.Name = "DGV_Search";
            DGV_Search.RowHeadersWidth = 62;
            DGV_Search.Size = new Size(645, 167);
            DGV_Search.TabIndex = 66;
            // 
            // SearchNameTxt
            // 
            SearchNameTxt.Location = new Point(419, 180);
            SearchNameTxt.Multiline = true;
            SearchNameTxt.Name = "SearchNameTxt";
            SearchNameTxt.Size = new Size(645, 46);
            SearchNameTxt.TabIndex = 71;
            // 
            // button4
            // 
            button4.Location = new Point(32, 739);
            button4.Name = "button4";
            button4.Size = new Size(91, 46);
            button4.TabIndex = 64;
            button4.Text = "Back";
            button4.UseVisualStyleBackColor = true;
            button4.Click += BackToOwner;
            // 
            // UpdateChoice
            // 
            UpdateChoice.FormattingEnabled = true;
            UpdateChoice.Items.AddRange(new object[] { "Name", "Stock", "Cost" });
            UpdateChoice.Location = new Point(419, 626);
            UpdateChoice.Name = "UpdateChoice";
            UpdateChoice.Size = new Size(169, 33);
            UpdateChoice.TabIndex = 97;
            // 
            // UpdateTxt
            // 
            UpdateTxt.Location = new Point(617, 585);
            UpdateTxt.Name = "UpdateTxt";
            UpdateTxt.PlaceholderText = "Enter your Change";
            UpdateTxt.Size = new Size(263, 31);
            UpdateTxt.TabIndex = 96;
            // 
            // button7
            // 
            button7.Location = new Point(904, 581);
            button7.Name = "button7";
            button7.Size = new Size(160, 38);
            button7.TabIndex = 95;
            button7.Text = "Update";
            button7.UseVisualStyleBackColor = true;
            button7.Click += ChangeAttribute;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F);
            label2.Location = new Point(419, 539);
            label2.Name = "label2";
            label2.Size = new Size(178, 30);
            label2.TabIndex = 94;
            label2.Text = "Change Attribute";
            // 
            // IDTxt
            // 
            IDTxt.Location = new Point(419, 585);
            IDTxt.Name = "IDTxt";
            IDTxt.PlaceholderText = "Enter EquipmentID";
            IDTxt.Size = new Size(192, 31);
            IDTxt.TabIndex = 96;
            // 
            // button6
            // 
            button6.Location = new Point(1731, 12);
            button6.Name = "button6";
            button6.Size = new Size(91, 46);
            button6.TabIndex = 64;
            button6.Text = "Exit";
            button6.UseVisualStyleBackColor = true;
            button6.Click += ExitApplication;
            // 
            // ManageEquipment
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1834, 797);
            Controls.Add(UpdateChoice);
            Controls.Add(IDTxt);
            Controls.Add(UpdateTxt);
            Controls.Add(button7);
            Controls.Add(label2);
            Controls.Add(CostTxt);
            Controls.Add(label4);
            Controls.Add(NameTxt);
            Controls.Add(label15);
            Controls.Add(AddStockTxt);
            Controls.Add(label16);
            Controls.Add(SearchNameTxt);
            Controls.Add(DGV_Search);
            Controls.Add(button6);
            Controls.Add(button4);
            Controls.Add(button5);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(DGV_ViewAll);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "ManageEquipment";
            Text = "ManageEquipment";
            Load += ManageEquipment_Load;
            ((System.ComponentModel.ISupportInitialize)DGV_ViewAll).EndInit();
            ((System.ComponentModel.ISupportInitialize)DGV_Search).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox NameTxt;
        private Label label15;
        private TextBox AddStockTxt;
        private Label label16;
        private Button button5;
        private Button button3;
        private DataGridView DGV_ViewAll;
        private Label label5;
        private Button button1;
        private Label label1;
        private Label label4;
        private TextBox CostTxt;
        private Label label3;
        private Button button2;
        private DataGridView DGV_Search;
        private TextBox SearchNameTxt;
        private Button button4;
        private ComboBox UpdateChoice;
        private TextBox UpdateTxt;
        private Button button7;
        private Label label2;
        private TextBox IDTxt;
        private Button button6;
    }
}