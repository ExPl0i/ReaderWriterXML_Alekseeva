namespace Samost_2_Form
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listView1 = new ListView();
            label1 = new Label();
            textBoxXml = new TextBox();
            label2 = new Label();
            buttonAdd = new Button();
            buttonRemove = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            textBoxNumber = new TextBox();
            textBoxName = new TextBox();
            textBoxDate = new TextBox();
            textBoxSum = new TextBox();
            textBoxProcent = new TextBox();
            label9 = new Label();
            textBoxID = new TextBox();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Location = new Point(12, 28);
            listView1.Name = "listView1";
            listView1.Size = new Size(281, 189);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(12, 8);
            label1.Name = "label1";
            label1.Size = new Size(70, 17);
            label1.TabIndex = 1;
            label1.Text = "Элементы:";
            // 
            // textBoxXml
            // 
            textBoxXml.Location = new Point(321, 28);
            textBoxXml.Multiline = true;
            textBoxXml.Name = "textBoxXml";
            textBoxXml.Size = new Size(311, 494);
            textBoxXml.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(321, 8);
            label2.Name = "label2";
            label2.Size = new Size(94, 17);
            label2.TabIndex = 3;
            label2.Text = "XML-документ";
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(44, 223);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(98, 23);
            buttonAdd.TabIndex = 4;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonRemove
            // 
            buttonRemove.Location = new Point(162, 223);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new Size(98, 23);
            buttonRemove.TabIndex = 5;
            buttonRemove.Text = "Удалить";
            buttonRemove.UseVisualStyleBackColor = true;
            buttonRemove.Click += buttonRemove_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(12, 260);
            label3.Name = "label3";
            label3.Size = new Size(57, 17);
            label3.TabIndex = 6;
            label3.Text = "Данные:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F);
            label4.Location = new Point(12, 321);
            label4.Name = "label4";
            label4.Size = new Size(88, 17);
            label4.TabIndex = 7;
            label4.Text = "Номер счета:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F);
            label5.Location = new Point(12, 357);
            label5.Name = "label5";
            label5.Size = new Size(105, 17);
            label5.TabIndex = 8;
            label5.Text = "ФИО вкладчика:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F);
            label6.Location = new Point(12, 391);
            label6.Name = "label6";
            label6.Size = new Size(84, 17);
            label6.TabIndex = 9;
            label6.Text = "Дата вклада:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F);
            label7.Location = new Point(12, 427);
            label7.Name = "label7";
            label7.Size = new Size(50, 17);
            label7.TabIndex = 10;
            label7.Text = "Сумма:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9.75F);
            label8.Location = new Point(12, 463);
            label8.Name = "label8";
            label8.Size = new Size(62, 17);
            label8.TabIndex = 11;
            label8.Text = "Процент:";
            // 
            // textBoxNumber
            // 
            textBoxNumber.Location = new Point(123, 320);
            textBoxNumber.Name = "textBoxNumber";
            textBoxNumber.Size = new Size(170, 23);
            textBoxNumber.TabIndex = 12;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(123, 356);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(170, 23);
            textBoxName.TabIndex = 13;
            // 
            // textBoxDate
            // 
            textBoxDate.Location = new Point(123, 390);
            textBoxDate.Name = "textBoxDate";
            textBoxDate.Size = new Size(170, 23);
            textBoxDate.TabIndex = 14;
            // 
            // textBoxSum
            // 
            textBoxSum.Location = new Point(123, 427);
            textBoxSum.Name = "textBoxSum";
            textBoxSum.Size = new Size(170, 23);
            textBoxSum.TabIndex = 15;
            // 
            // textBoxProcent
            // 
            textBoxProcent.Location = new Point(123, 463);
            textBoxProcent.Name = "textBoxProcent";
            textBoxProcent.Size = new Size(170, 23);
            textBoxProcent.TabIndex = 16;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label9.Location = new Point(12, 292);
            label9.Name = "label9";
            label9.Size = new Size(22, 17);
            label9.TabIndex = 17;
            label9.Text = "id:";
            // 
            // textBoxID
            // 
            textBoxID.Location = new Point(123, 291);
            textBoxID.Name = "textBoxID";
            textBoxID.Size = new Size(170, 23);
            textBoxID.TabIndex = 18;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(644, 534);
            Controls.Add(textBoxID);
            Controls.Add(label9);
            Controls.Add(textBoxProcent);
            Controls.Add(textBoxSum);
            Controls.Add(textBoxDate);
            Controls.Add(textBoxName);
            Controls.Add(textBoxNumber);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(buttonRemove);
            Controls.Add(buttonAdd);
            Controls.Add(label2);
            Controls.Add(textBoxXml);
            Controls.Add(label1);
            Controls.Add(listView1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private Label label1;
        private TextBox textBoxXml;
        private Label label2;
        private Button buttonAdd;
        private Button buttonRemove;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox textBoxNumber;
        private TextBox textBoxName;
        private TextBox textBoxDate;
        private TextBox textBoxSum;
        private TextBox textBoxProcent;
        private Label label9;
        private TextBox textBoxID;
    }
}
