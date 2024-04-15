namespace Laba_5Form
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
            buttonLoad = new Button();
            buttonSave = new Button();
            label5 = new Label();
            dataGridAttribs = new DataGridView();
            label4 = new Label();
            textBoxCountMachines = new TextBox();
            buttonSalary = new Button();
            buttonTotalSalary = new Button();
            buttonRemoveWorker = new Button();
            buttonAddWorker = new Button();
            buttonRemoveMachine = new Button();
            buttonAddMachine = new Button();
            listBoxWorkers = new ListBox();
            listBoxMachines = new ListBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridAttribs).BeginInit();
            SuspendLayout();
            // 
            // buttonLoad
            // 
            buttonLoad.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonLoad.Location = new Point(432, 553);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(126, 26);
            buttonLoad.TabIndex = 33;
            buttonLoad.Text = "Загрузить данные";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // buttonSave
            // 
            buttonSave.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonSave.Location = new Point(45, 553);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(128, 26);
            buttonSave.TabIndex = 32;
            buttonSave.Text = "Сохранить данные";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.Location = new Point(12, 361);
            label5.Name = "label5";
            label5.Size = new Size(128, 17);
            label5.TabIndex = 31;
            label5.Text = "Атрибуты объектов:";
            // 
            // dataGridAttribs
            // 
            dataGridAttribs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridAttribs.Location = new Point(12, 381);
            dataGridAttribs.Name = "dataGridAttribs";
            dataGridAttribs.Size = new Size(599, 166);
            dataGridAttribs.TabIndex = 30;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(318, 307);
            label4.Name = "label4";
            label4.Size = new Size(98, 17);
            label4.TabIndex = 29;
            label4.Text = "Число станков:";
            // 
            // textBoxCountMachines
            // 
            textBoxCountMachines.Location = new Point(318, 327);
            textBoxCountMachines.Name = "textBoxCountMachines";
            textBoxCountMachines.Size = new Size(142, 23);
            textBoxCountMachines.TabIndex = 28;
            // 
            // buttonSalary
            // 
            buttonSalary.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonSalary.Location = new Point(466, 322);
            buttonSalary.Name = "buttonSalary";
            buttonSalary.Size = new Size(145, 29);
            buttonSalary.TabIndex = 27;
            buttonSalary.Text = "Определить зарплату";
            buttonSalary.UseVisualStyleBackColor = true;
            buttonSalary.Click += buttonSalary_Click;
            // 
            // buttonTotalSalary
            // 
            buttonTotalSalary.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonTotalSalary.Location = new Point(12, 322);
            buttonTotalSalary.Name = "buttonTotalSalary";
            buttonTotalSalary.Size = new Size(293, 29);
            buttonTotalSalary.TabIndex = 26;
            buttonTotalSalary.Text = "Определить суммарные расходы на зарплату";
            buttonTotalSalary.UseVisualStyleBackColor = true;
            buttonTotalSalary.Click += buttonTotalSalary_Click;
            // 
            // buttonRemoveWorker
            // 
            buttonRemoveWorker.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonRemoveWorker.Location = new Point(463, 259);
            buttonRemoveWorker.Name = "buttonRemoveWorker";
            buttonRemoveWorker.Size = new Size(95, 29);
            buttonRemoveWorker.TabIndex = 25;
            buttonRemoveWorker.Text = "Удалить";
            buttonRemoveWorker.UseVisualStyleBackColor = true;
            buttonRemoveWorker.Click += buttonRemoveWorker_Click;
            // 
            // buttonAddWorker
            // 
            buttonAddWorker.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonAddWorker.Location = new Point(351, 259);
            buttonAddWorker.Name = "buttonAddWorker";
            buttonAddWorker.Size = new Size(97, 29);
            buttonAddWorker.TabIndex = 24;
            buttonAddWorker.Text = "Добавить";
            buttonAddWorker.UseVisualStyleBackColor = true;
            buttonAddWorker.Click += buttonAddWorker_Click;
            // 
            // buttonRemoveMachine
            // 
            buttonRemoveMachine.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonRemoveMachine.Location = new Point(169, 259);
            buttonRemoveMachine.Name = "buttonRemoveMachine";
            buttonRemoveMachine.Size = new Size(95, 29);
            buttonRemoveMachine.TabIndex = 23;
            buttonRemoveMachine.Text = "Удалить";
            buttonRemoveMachine.UseVisualStyleBackColor = true;
            buttonRemoveMachine.Click += buttonRemoveMachine_Click;
            // 
            // buttonAddMachine
            // 
            buttonAddMachine.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonAddMachine.Location = new Point(45, 259);
            buttonAddMachine.Name = "buttonAddMachine";
            buttonAddMachine.Size = new Size(98, 29);
            buttonAddMachine.TabIndex = 22;
            buttonAddMachine.Text = "Добавить";
            buttonAddMachine.UseVisualStyleBackColor = true;
            buttonAddMachine.Click += buttonAddMachine_Click;
            // 
            // listBoxWorkers
            // 
            listBoxWorkers.FormattingEnabled = true;
            listBoxWorkers.ItemHeight = 15;
            listBoxWorkers.Location = new Point(318, 54);
            listBoxWorkers.Name = "listBoxWorkers";
            listBoxWorkers.Size = new Size(293, 199);
            listBoxWorkers.TabIndex = 21;
            listBoxWorkers.SelectedIndexChanged += listBoxWorkers_SelectedIndexChanged;
            listBoxWorkers.DoubleClick += listBoxWorkers_SelectedIndexChanged;
            // 
            // listBoxMachines
            // 
            listBoxMachines.FormattingEnabled = true;
            listBoxMachines.ItemHeight = 15;
            listBoxMachines.Location = new Point(12, 54);
            listBoxMachines.Name = "listBoxMachines";
            listBoxMachines.Size = new Size(293, 199);
            listBoxMachines.TabIndex = 20;
            listBoxMachines.SelectedIndexChanged += listBoxMachines_SelectedIndexChanged;
            listBoxMachines.DoubleClick += listBoxMachines_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(318, 34);
            label3.Name = "label3";
            label3.Size = new Size(62, 17);
            label3.TabIndex = 19;
            label3.Text = "Рабочие:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(12, 34);
            label2.Name = "label2";
            label2.Size = new Size(51, 17);
            label2.TabIndex = 18;
            label2.Text = "Станки:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(12, 5);
            label1.Name = "label1";
            label1.Size = new Size(113, 17);
            label1.TabIndex = 17;
            label1.Text = "Списки объектов:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(627, 588);
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

        private Button buttonLoad;
        private Button buttonSave;
        private Label label5;
        private DataGridView dataGridAttribs;
        private Label label4;
        private TextBox textBoxCountMachines;
        private Button buttonSalary;
        private Button buttonTotalSalary;
        private Button buttonRemoveWorker;
        private Button buttonAddWorker;
        private Button buttonRemoveMachine;
        private Button buttonAddMachine;
        private ListBox listBoxWorkers;
        private ListBox listBoxMachines;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}
