using System.Xml.Serialization;

namespace Laba_4
{
    public partial class Form1 : Form
    {
        Workshop workshop; // ���
        string uri;        // URI XML-���������
        public Form1()
        {
            InitializeComponent();
            workshop = new Workshop();
            uri = @"";

            dataGridAttribs.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            DataGridViewTextBoxColumn colAttrValue = new DataGridViewTextBoxColumn();
            colAttrValue.HeaderText = "��������";
            colAttrValue.Width = 200;
            dataGridAttribs.Columns.Add(colAttrValue);
        }

        /// <summary>
        /// ��������� ������ ������� listBoxWorkers
        /// </summary>
        private void RefreshListBoxWorkers()
        {
            listBoxWorkers.Items.Clear();
            listBoxWorkers.DisplayMember = "ID";
            foreach (Worker worker in workshop.Workers)
            {
                listBoxWorkers.Items.Add(worker);
            }
        }

        /// <summary>
        /// ����������� ��������� ���������� �������� � dataGridAttribs
        /// </summary>
        private void ShowWorkerAttributes()
        {
            dataGridAttribs.Rows.Clear();

            dataGridAttribs.Rows.Add(5);
            dataGridAttribs.Rows[0].HeaderCell.Value = "���";
            dataGridAttribs.Rows[1].HeaderCell.Value = "���";
            dataGridAttribs.Rows[2].HeaderCell.Value = "C������������";
            dataGridAttribs.Rows[3].HeaderCell.Value = "������";
            dataGridAttribs.Rows[4].HeaderCell.Value = "����� ��������, �";

            Worker worker = listBoxWorkers.SelectedItem as Worker;
            if (worker != null)
            {
                dataGridAttribs.Rows[0].Cells[0].Value = worker.ID;
                dataGridAttribs.Rows[1].Cells[0].Value = worker.Name;
                dataGridAttribs.Rows[2].Cells[0].Value = worker.Speciality;
                dataGridAttribs.Rows[3].Cells[0].Value = worker.Grade;
                dataGridAttribs.Rows[4].Cells[0].Value = worker.Salary;
            }
        }

        /// <summary>
        /// ��������� ������ �������� � ������
        /// </summary>
        private void AddNewWorker()
        {
            string id = dataGridAttribs.Rows[0].Cells[0].Value.ToString();
            string name = dataGridAttribs.Rows[1].Cells[0].Value.ToString();
            string speciality = dataGridAttribs.Rows[2].Cells[0].Value.ToString();
            int grade = 0;
            int.TryParse(dataGridAttribs.Rows[3].Cells[0].Value.ToString(), out grade);
            int salary = 0;
            int.TryParse(dataGridAttribs.Rows[4].Cells[0].Value.ToString(), out salary);

            workshop.AddNewWorker(id, name, speciality, grade, salary);
            RefreshListBoxWorkers();   
        }

        /// <summary>
        /// ������� ���������� �������� �� ������
        /// </summary>
        private void RemoveWorker()
        {
            int index = listBoxWorkers.SelectedIndex;
            if (index >=0 && index < workshop.Workers.Count)
            {
                workshop.RemoveWorker(index);
                RefreshListBoxWorkers();
            }
        }

        /// <summary>
        /// ��������� ������ ������ listBoxMachines
        /// </summary>
        private void RefreshListBoxMachines()
        {
            listBoxMachines.Items.Clear();
            listBoxMachines.DisplayMember = "ID";
            Worker worker = listBoxWorkers.SelectedItem as Worker;
            if (worker != null)
            {
                foreach (Machine machine in worker.Machines)
                {
                    listBoxMachines.Items.Add(machine);
                }
            }
        }

        /// <summary>
        /// ����������� ��������� ���������� ������ � dataGridAttribs
        /// </summary>
        private void ShowMachineAttributes()
        {
            dataGridAttribs.Rows.Clear();

            dataGridAttribs.Rows.Add(3);
            dataGridAttribs.Rows[0].HeaderCell.Value = "���";
            dataGridAttribs.Rows[1].HeaderCell.Value = "��������";
            dataGridAttribs.Rows[2].HeaderCell.Value = "������";
            Machine machine = listBoxMachines.SelectedItem as Machine;
            if (machine != null)
            {
                dataGridAttribs.Rows[0].Cells[0].Value = machine.ID;
                dataGridAttribs.Rows[1].Cells[0].Value = machine.Name;
                dataGridAttribs.Rows[2].Cells[0].Value = machine.Model;
            }
        }

        /// <summary>
        /// ��������� ����� ������ � ������
        /// </summary>
        private void AddNewMachine()
        {
            string id = dataGridAttribs.Rows[0].Cells[0].Value.ToString();
            string name = dataGridAttribs.Rows[1].Cells[0].Value.ToString();
            string model = dataGridAttribs.Rows[2].Cells[0].Value.ToString();
            
            Worker worker = listBoxWorkers.SelectedItem as Worker;
            if (worker != null)
            {
                worker.AddNewMachine(id, name, model);
                RefreshListBoxMachines();
            }
        }

        /// <summary>
        /// ������� ��������� ������ �� ������
        /// </summary>
        private void RemoveMachine()
        {
            Worker worker = listBoxWorkers.SelectedItem as Worker;
            if (worker != null)
            {
                int index = listBoxMachines.SelectedIndex;
                if (index >= 0 && index < worker.Machines.Count)
                {
                    worker.Machines.RemoveAt(index);
                    RefreshListBoxMachines();
                }
            }
        }

        /// <summary>
        /// ������� ����� ������� �� ��������
        /// </summary>
        private void ShowTotalSalary()
        {
            MessageBox.Show(string.Format("{0} �.", workshop.GetTotalSalary()), "����� ������� �� ��������");
        }

        /// <summary>
        /// ������������ �������� �� �������������� ����� �������
        /// </summary>
        private void OverSalary()
        {
            int countMachines = 0;
            int.TryParse(textBoxCountMachines.Text, out countMachines);
            if (countMachines != 0)
            {
                MessageBox.Show(string.Format("�������� �� ������������ {0} �������������� ������� ���������: {1} �.", countMachines, workshop.GetOverSalary(countMachines)));
            }
        }

        /// <summary>
        /// ��������� ������ � XML-�����
        /// </summary>
        private void SaveData()
        {

        }

        /// <summary>
        /// ��������� ������ �� XML-�����
        /// </summary>
        private void LoadData()
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "���������������� ���";
            RefreshListBoxWorkers();
            textBoxCountMachines.Text = "5";
        }

        private void listBoxMachines_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMachineAttributes();
        }

        private void listBoxWorkers_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowWorkerAttributes();
            RefreshListBoxMachines();
        }

        private void buttonAddMachine_Click(object sender, EventArgs e)
        {
            AddNewMachine();
        }

        private void buttonRemoveMachine_Click(object sender, EventArgs e)
        {
            RemoveMachine();
        }

        private void buttonAddWorker_Click(object sender, EventArgs e)
        {
            AddNewWorker();
        }

        private void buttonRemoveWorker_Click(object sender, EventArgs e)
        {
            RemoveWorker();
        }

        private void buttonTotalSalary_Click(object sender, EventArgs e)
        {
            ShowTotalSalary();
        }

        private void buttonSalary_Click(object sender, EventArgs e)
        {
            OverSalary();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }

    /// <summary>
    /// ������������ ������
    /// </summary>
    public class Machine
    {
        /// <summary>
        /// ����������������� �����
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// ����������� �� ���������
        /// </summary>
        public Machine()
        {
            ID = "AAA-000000";
            Name = "�������� ������";
            Model = "AA-0000";
        }

        /// <summary>
        /// ����������� � �����������
        /// </summary>
        /// <param name="id">����������������� �����</param>
        /// <param name="name">��������</param>
        /// <param name="model">������</param>
        public Machine(string id,  string name, string model)
        {
            ID = id;
            Name = name;
            Model = model;
        }

        /// <summary>
        /// ���������� ������ � ������� � ������
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}; {1}", ID, Model);
        }
    }

    /// <summary>
    /// ������������ �������, ������������� ������
    /// </summary>
    public class Worker
    {
        /// <summary>
        /// ���
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// ���
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// �������������
        /// </summary>
        public string Speciality { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        public int Grade { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public int Salary { get; set; }

        /// <summary>
        /// ���������� ������������� �������
        /// </summary>
        public int CountMachine { get; set; }

        /// <summary>
        /// ������ ������������� �������
        /// </summary>
        public List<Machine> Machines { get; set; }

        /// <summary>
        /// ����������� �� ���������
        /// </summary>
        public Worker()
        {
            ID = "0000";
            Name = "������ ���� ��������";
            Speciality = "������";
            Grade = 1;
            Salary = 20000;
            CountMachine = 0;
            Machines = new List<Machine>();
        }

        /// <summary>
        /// ����������� � �����������
        /// </summary>
        /// <param name="id">���</param>
        /// <param name="name">���</param>
        /// <param name="spec">�������������</param>
        /// <param name="grade">������</param>
        /// <param name="salary">��������</param>
        /// <param name="countMachine">����� ������������� ������</param>
        /// <param name="machines">������ ������������� �������</param>
        public Worker(string id, string name, string spec, int grade, int salary)
        {
            ID= id;
            Name = name;
            Speciality = spec;
            Grade = grade;
            Salary = salary;
            Machines = new List<Machine>();
        }

        /// <summary>
        /// ���������� ������ � ������� � �������
        /// </summary>
        /// <returns>������ � ������� � �������</returns>
        public override string ToString()
        {
            return string.Format("{0}. {1}", ID, Name);
        }

        /// <summary>
        /// ���������� �������� �� ������������ ���������� �������
        /// </summary>
        /// <returns>�������� �� ������������ ���������� �������</returns>
        public int GetOverSalary()
        {
            int overSalary = 0;

            foreach (Machine machine in Machines) overSalary += 5000;

            return overSalary;
        }

        /// <summary>
        /// ���������� ����� ��������
        /// </summary>
        /// <returns>����� ��������</returns>
        public int GetTotalSalary()
        {
            int totalSalary = Salary + GetOverSalary();

            return totalSalary;
        }

        /// <summary>
        /// ��������� ����� ������ ��������
        /// </summary>
        /// <param name="id">��� ������</param>
        /// <param name="name">������������</param>
        /// <param name="model">������</param>
        public void AddNewMachine(string id, string name, string model)
        {
            Machines.Add(new Machine() { ID = id, Name = name, Model = model});
            CountMachine++;
        }

        /// <summary>
        /// ������� ������ � �������� �������
        /// </summary>
        /// <param name="id">����� ������</param>
        public void RemoveMachine(int index)
        {
            Machines.RemoveAt(index);
            CountMachine--;
        }
    }

    /// <summary>
    /// ������������ ����
    /// </summary>
    public class Workshop
    {
        /// <summary>
        /// ����������������� �����
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ������ �������
        /// </summary>
        public List<Worker> Workers { get; set; }

        /// <summary>
        /// ����������� �� ���������
        /// </summary>
        public Workshop()
        {
            ID = "AAA-00";
            Name = "���������";
            Workers = new List<Worker>();
        }

        /// <summary>
        /// ���������� � �����������
        /// </summary>
        /// <param name="id">������������������ �����</param>
        /// <param name="name">��������</param>
        /// <param name="workers">������ �������</param>
        /// <param name="machines">������ �������</param>
        public Workshop(string id, string name)
        {
            ID = id;
            Name = name;
            Workers = new List<Worker>();
        }

        /// <summary>
        /// ���������� ������ � ������� � ����
        /// </summary>
        /// <returns>������ � ������� � ����</returns>
        public override string ToString()
        {
            return string.Format("{0}. �������: {1} ���; �������: {2} ��\n", ID, Workers.Count);
        }

        /// <summary>
        /// ���������� ����� ������� �� ��������
        /// </summary>
        /// <returns>����� ������� �� ��������</returns>
        public int GetTotalSalary()
        {
            int totalSalary = 0;

            foreach (Worker worker in Workers)
            {
                totalSalary += worker.GetTotalSalary();
            }

            return totalSalary;
        }

        /// <summary>
        /// ���������� �������� �� �������������� ������
        /// </summary>
        /// <param name="count">����� �������������� �������</param>
        /// <returns>�������� �� �������������� ������</returns>
        public int GetOverSalary(int count)
        {
            return count * 5000;
        }

        /// <summary>
        /// �������� ������ �������� � ���
        /// </summary>
        /// <param name="id">���</param>
        /// <param name="name">���</param>
        /// <param name="spec">�������������</param>
        /// <param name="grade">������</param>
        /// <param name="salary">��������</param>
        /// <param name="countMachine">���������� �������</param>
        public void AddNewWorker(string id, string name, string spec, int grade, int salary)
        {
            Worker newWorker = new Worker()
            {
                ID = id,
                Name = name,
                Speciality = spec,
                Grade = grade,
                Salary = salary,
            };
            Workers.Add(newWorker);
        }

        /// <summary>
        /// ������� �������� � ��������� �������
        /// </summary>
        /// <param name="index">����� ��������</param>
        public void RemoveWorker(int index)
        {
            Workers.RemoveAt(index);
        }
    }
}
