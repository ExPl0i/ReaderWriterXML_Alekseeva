namespace Laba_4
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
            label2 = new Label();
            label3 = new Label();
            listBoxMachines = new ListBox();
            listBoxWorkers = new ListBox();
            buttonAddMachine = new Button();
            buttonRemoveMachine = new Button();
            buttonAddWorker = new Button();
            buttonRemoveWorker = new Button();
            buttonTotalSalary = new Button();
            buttonSalary = new Button();
            textBoxCountMachines = new TextBox();
            label4 = new Label();
            dataGridAttribs = new DataGridView();
            label5 = new Label();
            buttonSave = new Button();
            buttonLoad = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridAttribs).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(113, 17);
            label1.TabIndex = 0;
            label1.Text = "Списки объектов:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(12, 38);
            label2.Name = "label2";
            label2.Size = new Size(51, 17);
            label2.TabIndex = 1;
            label2.Text = "Станки:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(318, 38);
            label3.Name = "label3";
            label3.Size = new Size(62, 17);
            label3.TabIndex = 2;
            label3.Text = "Рабочие:";
            label3.Click += label3_Click;
            // 
            // listBoxMachines
            // 
            listBoxMachines.FormattingEnabled = true;
            listBoxMachines.ItemHeight = 15;
            listBoxMachines.Location = new Point(12, 58);
            listBoxMachines.Name = "listBoxMachines";
            listBoxMachines.Size = new Size(293, 199);
            listBoxMachines.TabIndex = 3;
            listBoxMachines.SelectedIndexChanged += listBoxMachines_SelectedIndexChanged;
            // 
            // listBoxWorkers
            // 
            listBoxWorkers.FormattingEnabled = true;
            listBoxWorkers.ItemHeight = 15;
            listBoxWorkers.Location = new Point(318, 58);
            listBoxWorkers.Name = "listBoxWorkers";
            listBoxWorkers.Size = new Size(293, 199);
            listBoxWorkers.TabIndex = 4;
            listBoxWorkers.SelectedIndexChanged += listBoxWorkers_SelectedIndexChanged;
            // 
            // buttonAddMachine
            // 
            buttonAddMachine.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonAddMachine.Location = new Point(45, 263);
            buttonAddMachine.Name = "buttonAddMachine";
            buttonAddMachine.Size = new Size(98, 29);
            buttonAddMachine.TabIndex = 5;
            buttonAddMachine.Text = "Добавить";
            buttonAddMachine.UseVisualStyleBackColor = true;
            buttonAddMachine.Click += buttonAddMachine_Click;
            // 
            // buttonRemoveMachine
            // 
            buttonRemoveMachine.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonRemoveMachine.Location = new Point(169, 263);
            buttonRemoveMachine.Name = "buttonRemoveMachine";
            buttonRemoveMachine.Size = new Size(95, 29);
            buttonRemoveMachine.TabIndex = 6;
            buttonRemoveMachine.Text = "Удалить";
            buttonRemoveMachine.UseVisualStyleBackColor = true;
            buttonRemoveMachine.Click += buttonRemoveMachine_Click;
            // 
            // buttonAddWorker
            // 
            buttonAddWorker.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonAddWorker.Location = new Point(351, 263);
            buttonAddWorker.Name = "buttonAddWorker";
            buttonAddWorker.Size = new Size(97, 29);
            buttonAddWorker.TabIndex = 7;
            buttonAddWorker.Text = "Добавить";
            buttonAddWorker.UseVisualStyleBackColor = true;
            buttonAddWorker.Click += buttonAddWorker_Click;
            // 
            // buttonRemoveWorker
            // 
            buttonRemoveWorker.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonRemoveWorker.Location = new Point(463, 263);
            buttonRemoveWorker.Name = "buttonRemoveWorker";
            buttonRemoveWorker.Size = new Size(95, 29);
            buttonRemoveWorker.TabIndex = 8;
            buttonRemoveWorker.Text = "Удалить";
            buttonRemoveWorker.UseVisualStyleBackColor = true;
            buttonRemoveWorker.Click += buttonRemoveWorker_Click;
            // 
            // buttonTotalSalary
            // 
            buttonTotalSalary.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonTotalSalary.Location = new Point(12, 326);
            buttonTotalSalary.Name = "buttonTotalSalary";
            buttonTotalSalary.Size = new Size(293, 29);
            buttonTotalSalary.TabIndex = 9;
            buttonTotalSalary.Text = "Определить суммарные расходы на зарплату";
            buttonTotalSalary.UseVisualStyleBackColor = true;
            buttonTotalSalary.Click += buttonTotalSalary_Click;
            // 
            // buttonSalary
            // 
            buttonSalary.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonSalary.Location = new Point(466, 326);
            buttonSalary.Name = "buttonSalary";
            buttonSalary.Size = new Size(145, 29);
            buttonSalary.TabIndex = 10;
            buttonSalary.Text = "Определить зарплату";
            buttonSalary.UseVisualStyleBackColor = true;
            buttonSalary.Click += buttonSalary_Click;
            // 
            // textBoxCountMachines
            // 
            textBoxCountMachines.Location = new Point(318, 331);
            textBoxCountMachines.Name = "textBoxCountMachines";
            textBoxCountMachines.Size = new Size(142, 23);
            textBoxCountMachines.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(318, 311);
            label4.Name = "label4";
            label4.Size = new Size(98, 17);
            label4.TabIndex = 12;
            label4.Text = "Число станков:";
            // 
            // dataGridAttribs
            // 
            dataGridAttribs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridAttribs.Location = new Point(12, 385);
            dataGridAttribs.Name = "dataGridAttribs";
            dataGridAttribs.Size = new Size(599, 166);
            dataGridAttribs.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.Location = new Point(12, 365);
            label5.Name = "label5";
            label5.Size = new Size(128, 17);
            label5.TabIndex = 14;
            label5.Text = "Атрибуты объектов:";
            // 
            // buttonSave
            // 
            buttonSave.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonSave.Location = new Point(45, 557);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(128, 26);
            buttonSave.TabIndex = 15;
            buttonSave.Text = "Сохранить данные";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonLoad
            // 
            buttonLoad.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonLoad.Location = new Point(432, 557);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(126, 26);
            buttonLoad.TabIndex = 16;
            buttonLoad.Text = "Загрузить данные";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(623, 601);
            Controls.Add(buttonLoad);
            Controls.Add(buttonSave);
            Controls.Add(label5);
            Controls.Add(dataGridAttribs);
            Controls.Add(label4);
            Controls.Add(textBoxCountMachines);
            Controls.Add(buttonSalary);
            Controls.Add(buttonTotalSalary);
            Controls.Add(buttonRemoveWorker);
            Controls.Add(buttonAddWorker);
            Controls.Add(buttonRemoveMachine);
            Controls.Add(buttonAddMachine);
            Controls.Add(listBoxWorkers);
            Controls.Add(listBoxMachines);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridAttribs).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private ListBox listBoxMachines;
        private ListBox listBoxWorkers;
        private Button buttonAddMachine;
        private Button buttonRemoveMachine;
        private Button buttonAddWorker;
        private Button buttonRemoveWorker;
        private Button buttonTotalSalary;
        private Button buttonSalary;
        private TextBox textBoxCountMachines;
        private Label label4;
        private DataGridView dataGridAttribs;
        private Label label5;
        private Button buttonSave;
        private Button buttonLoad;
    }
}
