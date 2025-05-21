namespace DatabaseProject
{
    partial class OwnerMore
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
            button1 = new Button();
            DGV_More = new DataGridView();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            ((System.ComponentModel.ISupportInitialize)DGV_More).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 735);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 0;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Back;
            // 
            // DGV_More
            // 
            DGV_More.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_More.Location = new Point(926, 12);
            DGV_More.Name = "DGV_More";
            DGV_More.RowHeadersWidth = 62;
            DGV_More.Size = new Size(883, 757);
            DGV_More.TabIndex = 2;
            // 
            // button2
            // 
            button2.Location = new Point(503, 332);
            button2.Name = "button2";
            button2.Size = new Size(198, 81);
            button2.TabIndex = 0;
            button2.Text = "Back";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(130, 332);
            button3.Name = "button3";
            button3.Size = new Size(198, 81);
            button3.TabIndex = 0;
            button3.Text = "Back";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(503, 171);
            button4.Name = "button4";
            button4.Size = new Size(198, 81);
            button4.TabIndex = 0;
            button4.Text = "Back";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(130, 171);
            button5.Name = "button5";
            button5.Size = new Size(198, 81);
            button5.TabIndex = 0;
            button5.Text = "Back";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(503, 503);
            button6.Name = "button6";
            button6.Size = new Size(198, 81);
            button6.TabIndex = 0;
            button6.Text = "Back";
            button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Location = new Point(130, 503);
            button7.Name = "button7";
            button7.Size = new Size(198, 81);
            button7.TabIndex = 0;
            button7.Text = "Back";
            button7.UseVisualStyleBackColor = true;
            // 
            // OwnerMore
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1821, 781);
            Controls.Add(DGV_More);
            Controls.Add(button5);
            Controls.Add(button7);
            Controls.Add(button3);
            Controls.Add(button4);
            Controls.Add(button6);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "OwnerMore";
            Text = "OwnerMore";
            ((System.ComponentModel.ISupportInitialize)DGV_More).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private DataGridView DGV_More;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
    }
}