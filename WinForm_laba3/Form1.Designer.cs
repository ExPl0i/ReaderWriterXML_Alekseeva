namespace WinForm_laba3
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
            listBoxDebits = new ListBox();
            buttonAdd = new Button();
            buttonRemove = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBoxNumber = new TextBox();
            label4 = new Label();
            textBoxNameOwner = new TextBox();
            label5 = new Label();
            textBoxDate = new TextBox();
            label6 = new Label();
            textBoxSum = new TextBox();
            label7 = new Label();
            textBoxProcent = new TextBox();
            butonChange = new Button();
            buttonSave = new Button();
            buttonLoad = new Button();
            SuspendLayout();
            // 
            // listBoxDebits
            // 
            listBoxDebits.FormattingEnabled = true;
            listBoxDebits.ItemHeight = 15;
            listBoxDebits.Location = new Point(12, 42);
            listBoxDebits.Name = "listBoxDebits";
            listBoxDebits.Size = new Size(277, 274);
            listBoxDebits.TabIndex = 0;
            listBoxDebits.SelectedIndexChanged += listBoxPersons_SelectedIndexChanged;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(13, 340);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(126, 23);
            buttonAdd.TabIndex = 1;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonRemove
            // 
            buttonRemove.Location = new Point(170, 340);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new Size(119, 23);
            buttonRemove.TabIndex = 2;
            buttonRemove.Text = "Удалить";
            buttonRemove.UseVisualStyleBackColor = true;
            buttonRemove.Click += buttonRemove_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(127, 21);
            label1.TabIndex = 3;
            label1.Text = "Список вкладов:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(347, 9);
            label2.Name = "label2";
            label2.Size = new Size(135, 21);
            label2.TabIndex = 4;
            label2.Text = "Данные о вкладе:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(347, 42);
            label3.Name = "label3";
            label3.Size = new Size(97, 17);
            label3.TabIndex = 5;
            label3.Text = "Номер вклада:";
            // 
            // textBoxNumber
            // 
            textBoxNumber.Location = new Point(347, 62);
            textBoxNumber.Name = "textBoxNumber";
            textBoxNumber.Size = new Size(222, 23);
            textBoxNumber.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(347, 88);
            label4.Name = "label4";
            label4.Size = new Size(105, 17);
            label4.TabIndex = 7;
            label4.Text = "ФИО вкладчика:";
            // 
            // textBoxNameOwner
            // 
            textBoxNameOwner.Location = new Point(347, 108);
            textBoxNameOwner.Name = "textBoxNameOwner";
            textBoxNameOwner.Size = new Size(222, 23);
            textBoxNameOwner.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.Location = new Point(347, 134);
            label5.Name = "label5";
            label5.Size = new Size(84, 17);
            label5.TabIndex = 9;
            label5.Text = "Дата вклада:";
            // 
            // textBoxDate
            // 
            textBoxDate.Location = new Point(347, 154);
            textBoxDate.Name = "textBoxDate";
            textBoxDate.Size = new Size(222, 23);
            textBoxDate.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label6.Location = new Point(347, 180);
            label6.Name = "label6";
            label6.Size = new Size(95, 17);
            label6.TabIndex = 11;
            label6.Text = "Сумма вклада:";
            // 
            // textBoxSum
            // 
            textBoxSum.Location = new Point(347, 200);
            textBoxSum.Name = "textBoxSum";
            textBoxSum.Size = new Size(222, 23);
            textBoxSum.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label7.Location = new Point(347, 226);
            label7.Name = "label7";
            label7.Size = new Size(125, 17);
            label7.TabIndex = 13;
            label7.Text = "Процент по вкладу:";
            // 
            // textBoxProcent
            // 
            textBoxProcent.Location = new Point(347, 246);
            textBoxProcent.Name = "textBoxProcent";
            textBoxProcent.Size = new Size(222, 23);
            textBoxProcent.TabIndex = 14;
            // 
            // butonChange
            // 
            butonChange.Location = new Point(347, 293);
            butonChange.Name = "butonChange";
            butonChange.Size = new Size(108, 23);
            butonChange.TabIndex = 15;
            butonChange.Text = "Изменить";
            butonChange.UseVisualStyleBackColor = true;
            butonChange.Click += butonChange_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(347, 340);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(108, 23);
            buttonSave.TabIndex = 16;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(471, 316);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(98, 23);
            buttonLoad.TabIndex = 17;
            buttonLoad.Text = "Загрузить";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(591, 398);
            Controls.Add(buttonLoad);
            Controls.Add(buttonSave);
            Controls.Add(butonChange);
            Controls.Add(textBoxProcent);
            Controls.Add(label7);
            Controls.Add(textBoxSum);
            Controls.Add(label6);
            Controls.Add(textBoxDate);
            Controls.Add(label5);
            Controls.Add(textBoxNameOwner);
            Controls.Add(label4);
            Controls.Add(textBoxNumber);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonRemove);
            Controls.Add(buttonAdd);
            Controls.Add(listBoxDebits);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxDebits;
        private Button buttonAdd;
        private Button buttonRemove;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBoxNumber;
        private Label label4;
        private TextBox textBoxNameOwner;
        private Label label5;
        private TextBox textBoxDate;
        private Label label6;
        private TextBox textBoxSum;
        private Label label7;
        private TextBox textBoxProcent;
        private Button butonChange;
        private Button buttonSave;
        private Button buttonLoad;
    }
}
