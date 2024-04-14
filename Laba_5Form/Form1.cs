namespace Laba_5Form
{
    public partial class Form1 : Form
    {
        string xmlFileUri = "";

        public Form1()
        {
            InitializeComponent();
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

            foreach (string id in AppFacade.GetWorkersStrArray())
            {
                listBoxWorkers.Items.Add(id);
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

            string id, name, speciality, grade, salary;

            AppFacade.GetWorkerAttribs(listBoxWorkers.SelectedIndex, out id, out name, out  speciality, out grade, out salary);

            dataGridAttribs.Rows[0].Cells[0].Value = id;
            dataGridAttribs.Rows[1].Cells[0].Value = name;
            dataGridAttribs.Rows[2].Cells[0].Value = speciality;
            dataGridAttribs.Rows[3].Cells[0].Value = grade;
            dataGridAttribs.Rows[4].Cells[0].Value = salary;
            
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

            AppFacade.AddNewWorker(id, name, speciality, grade, salary);
            RefreshListBoxWorkers();
        }

        /// <summary>
        /// ������� ���������� �������� �� ������
        /// </summary>
        private void RemoveWorker()
        {
            AppFacade.RemoveWorker(listBoxWorkers.SelectedIndex);
            RefreshListBoxWorkers();
        }

        /// <summary>
        /// ��������� ������ ������ listBoxMachines
        /// </summary>
        private void RefreshListBoxMachines()
        {
            listBoxMachines.Items.Clear();
            
            foreach (string id in AppFacade.GetMachinesStrArray(listBoxWorkers.SelectedIndex))
                listBoxMachines.Items.Add(id);
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

            string id, name, model;

            AppFacade.GetMachineAttribs(listBoxWorkers.SelectedIndex, listBoxMachines.SelectedIndex, out id, out name, out model);

            dataGridAttribs.Rows[0].Cells[0].Value = id;
            dataGridAttribs.Rows[1].Cells[0].Value = name;
            dataGridAttribs.Rows[2].Cells[0].Value = model;
        }

        /// <summary>
        /// ��������� ����� ������ � ������
        /// </summary>
        private void AddNewMachine()
        {
            string id = dataGridAttribs.Rows[0].Cells[0].Value.ToString();
            string name = dataGridAttribs.Rows[1].Cells[0].Value.ToString();
            string model = dataGridAttribs.Rows[2].Cells[0].Value.ToString();

            AppFacade.AddNewMachine(listBoxWorkers.SelectedIndex, id, name, model);
            RefreshListBoxMachines();  
        }

        /// <summary>
        /// ������� ��������� ������ �� ������
        /// </summary>
        private void RemoveMachine()
        {
            AppFacade.RemoveMachine(listBoxWorkers.SelectedIndex, listBoxMachines.SelectedIndex)
        }

        /// <summary>
        /// ������� ����� ������� �� ��������
        /// </summary>
        private void ShowTotalSalary()
        {
            MessageBox.Show(string.Format("{0} �.", AppFacade.GetTotalSalary()), "����� ������� �� ��������");
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
                MessageBox.Show(string.Format("�������� �� ������������ {0} �������������� ������� ���������: {1} �.", countMachines, AppFacade.GetOverSalary(countMachines)));
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

        private void listBoxMachines_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMachineAttributes();
        }

        private void listBoxWorkers_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowWorkerAttributes();
            RefreshListBoxWorkers();
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

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "���������������� ���";
            RefreshListBoxWorkers();
            textBoxCountMachines.Text = "5";
        }
    }

    /// <summary>
    /// ������������ �������� �����
    /// </summary>
    public class AppFacade
    {
        private static Workshop workshop = new Workshop(); // ��� �� ���������

        /// <summary>
        /// ��������� ������ �� XML-�����
        /// </summary>
        /// <param name="xmlFileUri">���� � XML-�����</param>
        public static void LoadData(string xmlFileUri)
        {
            
        }

        /// <summary>
        /// ��������� ������ � XML-�����
        /// </summary>
        /// <param name="xmlFileUri">���� � XML-�����</param>
        public static void SaveData(string xmlFileUri)
        {

        }

        /// <summary>
        /// ��������� ������������ ������� ��� ��������
        /// </summary>
        /// <param name="workerIndex">������ ��������</param>
        /// <returns></returns>
        private static bool CheckWorkerIndex(int workerIndex)
        {
            bool checkResult = false; // ��������� ��������

            if ((workerIndex >= 0) && (workerIndex < workshop.Workers.Count))
                checkResult = true;

            return checkResult;
        }

        /// <summary>
        /// ��������� ������������ ������� ��� ������
        /// </summary>
        /// <param name="workerIndex">������ ��������</param>
        /// <param name="machineIndex">������ ������</param>
        /// <returns></returns>
        private static bool CheckMachineIndex(int workerIndex, int machineIndex)
        {
            bool checkResult = false;

            if (CheckWorkerIndex(workerIndex) == true)
            {
                if ((machineIndex >= 0) && (machineIndex < workshop.Workers[workerIndex].Machines.Count))
                    checkResult = true;
            }

            return checkResult;
        }

        /// <summary>
        /// ���������� ������ ����� � ������� � �������
        /// </summary>
        /// <returns>������ ����� � ������� � �������</returns>
        public static string[] GetWorkersStrArray()
        {
            List<string> workersStrList = new List<string>();

            foreach (Worker wr in workshop.Workers)
            {
                workersStrList.Add(wr.ToString());
            }

            return workersStrList.ToArray();
        }

        /// <summary>
        /// ���������� ������ ����� � ������� � �������
        /// </summary>
        /// <param name="workerIndex">������ ��������</param>
        /// <returns>������ ����� � ������� � �������</returns>
        public static string[] GetMachinesStrArray(int workerIndex)
        {
            List<string> machinesStrArray = new List<string>();

            if (CheckWorkerIndex(workerIndex) == true)
            {
                foreach (Machine mc in workshop.Workers[workerIndex].Machines)
                    machinesStrArray.Add(mc.ToString());
            }

            return machinesStrArray.ToArray();
        }

        /// <summary>
        /// ���������� �������� ��������� �������� (����� �������� ���������)
        /// </summary>
        /// <param name="workerIndex">������ ��������</param>
        /// <param name="id">��� ��������</param>
        /// <param name="name">���</param>
        /// <param name="speciality">�������������</param>
        /// <param name="grade">������</param>
        /// <param name="salary">��������</param>
        public static void GetWorkerAttribs(int workerIndex, out string id, out string name, out string speciality, out string grade, out string salary)
        {
            id = ""; name = ""; speciality = ""; grade = ""; salary = "";

            if (CheckWorkerIndex(workerIndex) == true)
            {
                id = workshop.Workers[workerIndex].ID;
                name = workshop.Workers[workerIndex].Name;
                speciality = workshop.Workers[workerIndex].Speciality;
                grade = workshop.Workers[workerIndex].Grade.ToString();
                salary = workshop.Workers[workerIndex ].Salary.ToString();  
            }
        }

        /// <summary>
        /// ���������� �������� ��������� ����� (����� �������� ���������)
        /// </summary>
        /// <param name="workerIndex">������ ��������</param>
        /// <param name="machineIndex">������ ������</param>
        /// <param name="id">��� ������</param>
        /// <param name="name">������������</param>
        /// <param name="model">������</param>
        public static void GetMachineAttribs(int workerIndex, int machineIndex, out string id, out string name, out string model)
        {
            id = ""; name = ""; model = "";

            if (CheckMachineIndex(workerIndex, machineIndex) == true)
            {
                id = workshop.Workers[workerIndex].Machines[machineIndex].ID;
                name = workshop.Workers[workerIndex].Machines[machineIndex].Name;
                model = workshop.Workers[workerIndex].Machines[machineIndex].Model;
            }
        }

        /// <summary>
        /// ��������� ������ �������� � ���
        /// </summary>
        /// <param name="id">��� ��������</param>
        /// <param name="name">���</param>
        /// <param name="speciality">�������������</param>
        /// <param name="grade">������</param>
        /// <param name="salary">��������</param>
        public static void AddNewWorker(string id, string name, string speciality, int grade, int salary)
        {
            Worker newWorker = new Worker() { ID = id, Name = name, Speciality = speciality, Grade = grade, Salary = salary };
            workshop.Workers.Add(newWorker);
        }

        /// <summary>
        /// ��������� ����� ������ �������� ����
        /// </summary>
        /// <param name="workerIndex">������ ��������</param>
        /// <param name="id">��� ������</param>
        /// <param name="name">������������</param>
        /// <param name="model">������</param>
        public static void AddNewMachine(int workerIndex, string id, string name, string model)
        {
            if (CheckWorkerIndex(workerIndex) == true)
            {
                Machine newMachine = new Machine() { ID = id, Name = name, Model = model };
                workshop.Workers[workerIndex].Machines.Add(newMachine);
            }
        }

        /// <summary>
        /// ������� ���������� ��������
        /// </summary>
        /// <param name="workerIndex">������ ��������</param>
        public static void RemoveWorker(int workerIndex)
        {
            if (CheckWorkerIndex(workerIndex) == true)
                workshop.Workers.RemoveAt(workerIndex);
        }

        /// <summary>
        /// ������� ��������� ������ � �������� ����
        /// </summary>
        /// <param name="workerIndex">������ ��������</param>
        /// <param name="machineIndex">������ ������</param>
        public static void RemoveMachine(int workerIndex, int machineIndex)
        {
            if (CheckMachineIndex(workerIndex, machineIndex) == true)
                workshop.Workers[workerIndex].Machines.RemoveAt(machineIndex);
        }

        /// <summary>
        /// ���������� ����� ������� �� ��������
        /// </summary>
        /// <returns>����� ������� �� ��������</returns>
        public static int GetTotalSalary()
        {
            return workshop.GetTotalSalary();
        }

        /// <summary>
        /// ���������� ������� �� ���������� �������
        /// </summary>
        /// <param name="count">���������� �������</param>
        /// <returns>������� �� ���������� �������</returns>
        public static int GetOverSalary(int count)
        {
            return workshop.GetOverSalary(count);
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
        public Machine(string id, string name, string model)
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
            ID = id;
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
            Machines.Add(new Machine() { ID = id, Name = name, Model = model });
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
