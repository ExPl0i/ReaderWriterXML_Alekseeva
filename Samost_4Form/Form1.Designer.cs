namespace Samost_4Form
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
            dataGridDebits = new DataGridView();
            buttonSave = new Button();
            buttonLoad = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridDebits).BeginInit();
            SuspendLayout();
            // 
            // dataGridDebits
            // 
            dataGridDebits.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridDebits.Location = new Point(12, 12);
            dataGridDebits.Name = "dataGridDebits";
            dataGridDebits.Size = new Size(652, 348);
            dataGridDebits.TabIndex = 0;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(132, 390);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(159, 23);
            buttonSave.TabIndex = 1;
            buttonSave.Text = "Сохранить данные в XML";
            buttonSave.UseVisualStyleBackColor = true;
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(379, 390);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(159, 23);
            buttonLoad.TabIndex = 2;
            buttonLoad.Text = "Загрузить данные из XML";
            buttonLoad.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(676, 450);
            Controls.Add(buttonLoad);
            Controls.Add(buttonSave);
            Controls.Add(dataGridDebits);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridDebits).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridDebits;
        private Button buttonSave;
        private Button buttonLoad;
    }
}
