namespace DatabaseProject
{
    partial class ManageOrders
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
            ReceiverIDTxt = new TextBox();
            label11 = new Label();
            label13 = new Label();
            NameTxt = new TextBox();
            label15 = new Label();
            AmountTxt = new TextBox();
            label16 = new Label();
            DGV_Sort = new DataGridView();
            button5 = new Button();
            button2 = new Button();
            DGV_ViewAll = new DataGridView();
            label5 = new Label();
            label3 = new Label();
            button1 = new Button();
            label1 = new Label();
            SortByTxt = new ComboBox();
            SupplierName = new TextBox();
            button3 = new Button();
            button4 = new Button();
            UpdateChoice = new ComboBox();
            UpdateTxt = new TextBox();
            button6 = new Button();
            button7 = new Button();
            label4 = new Label();
            IDTxt = new TextBox();
            ((System.ComponentModel.ISupportInitialize)DGV_Sort).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DGV_ViewAll).BeginInit();
            SuspendLayout();
            // 
            // ReceiverIDTxt
            // 
            ReceiverIDTxt.Location = new Point(1102, 287);
            ReceiverIDTxt.Name = "ReceiverIDTxt";
            ReceiverIDTxt.Size = new Size(305, 31);
            ReceiverIDTxt.TabIndex = 48;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(1109, 255);
            label11.Name = "label11";
            label11.Size = new Size(158, 25);
            label11.TabIndex = 44;
            label11.Text = "Staff ID of receiver";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(1486, 253);
            label13.Name = "label13";
            label13.Size = new Size(82, 25);
            label13.TabIndex = 40;
            label13.Text = "Supplier ";
            // 
            // NameTxt
            // 
            NameTxt.Location = new Point(1102, 207);
            NameTxt.Name = "NameTxt";
            NameTxt.Size = new Size(305, 31);
            NameTxt.TabIndex = 45;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(1109, 175);
            label15.Name = "label15";
            label15.Size = new Size(150, 25);
            label15.TabIndex = 38;
            label15.Text = "Equipment Name";
            // 
            // AmountTxt
            // 
            AmountTxt.Location = new Point(1479, 205);
            AmountTxt.Name = "AmountTxt";
            AmountTxt.Size = new Size(323, 31);
            AmountTxt.TabIndex = 50;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(1486, 173);
            label16.Name = "label16";
            label16.Size = new Size(77, 25);
            label16.TabIndex = 37;
            label16.Text = "Amount";
            // 
            // DGV_Sort
            // 
            DGV_Sort.BackgroundColor = SystemColors.MenuBar;
            DGV_Sort.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Sort.Location = new Point(424, 272);
            DGV_Sort.Name = "DGV_Sort";
            DGV_Sort.RowHeadersWidth = 62;
            DGV_Sort.Size = new Size(645, 272);
            DGV_Sort.TabIndex = 33;
            // 
            // button5
            // 
            button5.Location = new Point(1367, 349);
            button5.Name = "button5";
            button5.Size = new Size(153, 46);
            button5.TabIndex = 31;
            button5.Text = "Make Order";
            button5.UseVisualStyleBackColor = true;
            button5.Click += MakeOrder;
            // 
            // button2
            // 
            button2.Location = new Point(424, 227);
            button2.Name = "button2";
            button2.Size = new Size(645, 34);
            button2.TabIndex = 28;
            button2.Text = "Search";
            button2.UseVisualStyleBackColor = true;
            button2.Click += SortEquipmentOrders;
            // 
            // DGV_ViewAll
            // 
            DGV_ViewAll.BackgroundColor = SystemColors.MenuBar;
            DGV_ViewAll.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_ViewAll.Location = new Point(37, 177);
            DGV_ViewAll.Name = "DGV_ViewAll";
            DGV_ViewAll.RowHeadersWidth = 62;
            DGV_ViewAll.Size = new Size(360, 367);
            DGV_ViewAll.TabIndex = 32;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(1102, 123);
            label5.Name = "label5";
            label5.Size = new Size(196, 32);
            label5.TabIndex = 25;
            label5.Text = "Make New Order";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(424, 123);
            label3.Name = "label3";
            label3.Size = new Size(90, 32);
            label3.TabIndex = 24;
            label3.Text = "Sort By";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F);
            button1.Location = new Point(37, 115);
            button1.Name = "button1";
            button1.Size = new Size(360, 56);
            button1.TabIndex = 27;
            button1.Text = "View All";
            button1.UseVisualStyleBackColor = true;
            button1.Click += ViewAll;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(16, 17);
            label1.Name = "label1";
            label1.Size = new Size(373, 54);
            label1.TabIndex = 22;
            label1.Text = "Order Management";
            label1.Click += label1_Click;
            // 
            // SortByTxt
            // 
            SortByTxt.FormattingEnabled = true;
            SortByTxt.Items.AddRange(new object[] { "Date", "Cost", "Equipment", "Supplier" });
            SortByTxt.Location = new Point(424, 177);
            SortByTxt.Name = "SortByTxt";
            SortByTxt.Size = new Size(645, 33);
            SortByTxt.TabIndex = 53;
            // 
            // SupplierName
            // 
            SupplierName.Location = new Point(1479, 287);
            SupplierName.Name = "SupplierName";
            SupplierName.Size = new Size(323, 31);
            SupplierName.TabIndex = 48;
            // 
            // button3
            // 
            button3.Location = new Point(1746, 12);
            button3.Name = "button3";
            button3.Size = new Size(79, 46);
            button3.TabIndex = 31;
            button3.Text = "Exit";
            button3.UseVisualStyleBackColor = true;
            button3.Click += ExitApplication;
            // 
            // button4
            // 
            button4.Location = new Point(12, 560);
            button4.Name = "button4";
            button4.Size = new Size(106, 37);
            button4.TabIndex = 31;
            button4.Text = "Back";
            button4.UseVisualStyleBackColor = true;
            button4.Click += BackToOwner;
            // 
            // UpdateChoice
            // 
            UpdateChoice.FormattingEnabled = true;
            UpdateChoice.Items.AddRange(new object[] { "TotalCost", "Amount", "StaffID", "SupplierID", "EquipmentID" });
            UpdateChoice.Location = new Point(1109, 543);
            UpdateChoice.Name = "UpdateChoice";
            UpdateChoice.Size = new Size(169, 33);
            UpdateChoice.TabIndex = 58;
            // 
            // UpdateTxt
            // 
            UpdateTxt.Location = new Point(1305, 543);
            UpdateTxt.Name = "UpdateTxt";
            UpdateTxt.PlaceholderText = "Enter your Change";
            UpdateTxt.Size = new Size(263, 31);
            UpdateTxt.TabIndex = 57;
            // 
            // button6
            // 
            button6.Location = new Point(1592, 538);
            button6.Name = "button6";
            button6.Size = new Size(210, 46);
            button6.TabIndex = 55;
            button6.Text = "Update";
            button6.UseVisualStyleBackColor = true;
            button6.Click += ChangeAttribute;
            // 
            // button7
            // 
            button7.Location = new Point(1109, 442);
            button7.Name = "button7";
            button7.Size = new Size(693, 46);
            button7.TabIndex = 56;
            button7.Text = "Delete";
            button7.UseVisualStyleBackColor = true;
            button7.Click += DeleteOrder;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F);
            label4.Location = new Point(1109, 501);
            label4.Name = "label4";
            label4.Size = new Size(178, 30);
            label4.TabIndex = 54;
            label4.Text = "Change Attribute";
            // 
            // IDTxt
            // 
            IDTxt.Location = new Point(1109, 405);
            IDTxt.Name = "IDTxt";
            IDTxt.PlaceholderText = "Enter Order ID";
            IDTxt.Size = new Size(693, 31);
            IDTxt.TabIndex = 48;
            // 
            // ManageOrders
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1837, 727);
            Controls.Add(UpdateChoice);
            Controls.Add(UpdateTxt);
            Controls.Add(button6);
            Controls.Add(button7);
            Controls.Add(label4);
            Controls.Add(SortByTxt);
            Controls.Add(SupplierName);
            Controls.Add(IDTxt);
            Controls.Add(ReceiverIDTxt);
            Controls.Add(label11);
            Controls.Add(label13);
            Controls.Add(NameTxt);
            Controls.Add(label15);
            Controls.Add(AmountTxt);
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
            Controls.Add(label1);
            Name = "ManageOrders";
            Text = "ManageOrders";
            Load += ManageOrders_Load;
            ((System.ComponentModel.ISupportInitialize)DGV_Sort).EndInit();
            ((System.ComponentModel.ISupportInitialize)DGV_ViewAll).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox ReceiverIDTxt;
        private Label label11;
        private Label label13;
        private TextBox NameTxt;
        private Label label15;
        private TextBox AmountTxt;
        private Label label16;
        private DataGridView DGV_Sort;
        private Button button5;
        private Button button2;
        private DataGridView DGV_ViewAll;
        private Label label5;
        private Label label3;
        private Button button1;
        private Label label1;
        private ComboBox SortByTxt;
        private TextBox SupplierName;
        private Button button3;
        private Button button4;
        private ComboBox UpdateChoice;
        private TextBox UpdateTxt;
        private Button button6;
        private Button button7;
        private Label label4;
        private TextBox IDTxt;
    }
}