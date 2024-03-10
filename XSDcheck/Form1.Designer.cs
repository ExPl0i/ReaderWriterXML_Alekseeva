namespace XSDcheck
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
            label1 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            listBox1 = new ListBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(114, 21);
            label1.TabIndex = 0;
            label1.Text = "Выбор файлов";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 65);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(326, 23);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 133);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(231, 23);
            textBox2.TabIndex = 2;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(12, 208);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(231, 23);
            textBox3.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(12, 45);
            label2.Name = "label2";
            label2.Size = new Size(129, 17);
            label2.TabIndex = 4;
            label2.Text = "Пространство имен:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(12, 113);
            label3.Name = "label3";
            label3.Size = new Size(94, 17);
            label3.TabIndex = 5;
            label3.Text = "XML-документ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(12, 188);
            label4.Name = "label4";
            label4.Size = new Size(74, 17);
            label4.TabIndex = 6;
            label4.Text = "XML-схема";
            // 
            // button1
            // 
            button1.Location = new Point(249, 133);
            button1.Name = "button1";
            button1.Size = new Size(89, 23);
            button1.TabIndex = 7;
            button1.Text = "Обзор...";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(249, 208);
            button2.Name = "button2";
            button2.Size = new Size(89, 23);
            button2.TabIndex = 8;
            button2.Text = "Обзор...";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(141, 291);
            button3.Name = "button3";
            button3.Size = new Size(102, 23);
            button3.TabIndex = 9;
            button3.Text = "Проверить";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(393, 36);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(395, 289);
            listBox1.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.Location = new Point(393, 9);
            label5.Name = "label5";
            label5.Size = new Size(164, 21);
            label5.TabIndex = 11;
            label5.Text = "Результаты проверки";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 362);
            Controls.Add(label5);
            Controls.Add(listBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button1;
        private Button button2;
        private Button button3;
        private ListBox listBox1;
        private Label label5;
    }
}
