using System.Xml.Serialization;

namespace Laba_4
{
    public partial class Form1 : Form
    {
        Workshop workshop; // Цех
        string uri;        // URI XML-документа
        public Form1()
        {
            InitializeComponent();
            workshop = new Workshop();
            uri = @"";

            dataGridAttribs.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            DataGridViewTextBoxColumn colAttrValue = new DataGridViewTextBoxColumn();
            colAttrValue.HeaderText = "Значение";
            colAttrValue.Width = 200;
            dataGridAttribs.Columns.Add(colAttrValue);
        }

        /// <summary>
        /// Обновляет список рабочих listBoxWorkers
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
        /// Отображение атрибутов выбранного рабочего в dataGridAttribs
        /// </summary>
        private void ShowWorkerAttributes()
        {
            dataGridAttribs.Rows.Clear();

            dataGridAttribs.Rows.Add(5);
            dataGridAttribs.Rows[0].HeaderCell.Value = "Код";
            dataGridAttribs.Rows[1].HeaderCell.Value = "ФИО";
            dataGridAttribs.Rows[2].HeaderCell.Value = "Cпециальность";
            dataGridAttribs.Rows[3].HeaderCell.Value = "Разряд";
            dataGridAttribs.Rows[4].HeaderCell.Value = "Общая зарплата, р";

            Worker worker = listBoxMachines.SelectedItem as Worker;
            if (worker != null)
            {
                dataGridAttribs.Rows[0].HeaderCell.Value = worker.ID;
                dataGridAttribs.Rows[1].HeaderCell.Value = worker.Name;
                dataGridAttribs.Rows[2].HeaderCell.Value = worker.Speciality;
                dataGridAttribs.Rows[3].HeaderCell.Value = worker.Grade;
                dataGridAttribs.Rows[4].HeaderCell.Value = worker.Salary;
            }
        }

        /// <summary>
        /// Добавляет нового рабочего в список
        /// </summary>
        private void AddNewWorker()
        {
            string id = dataGridAttribs.Rows[0].HeaderCell.Value.ToString();
            string name = dataGridAttribs.Rows[1].HeaderCell.Value.ToString();
            string speciality = dataGridAttribs.Rows[2].HeaderCell.Value.ToString();
            int grade = 0;
            int.TryParse(dataGridAttribs.Rows[3].HeaderCell.Value.ToString(), out grade);
            int salary = 0;
            int.TryParse(dataGridAttribs.Rows[4].HeaderCell.Value.ToString(), out salary);

            workshop.AddNewWorker(id, name, speciality, grade, salary);
        }

        /// <summary>
        /// Удаляет выбранного рабочего из списка
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
        /// Обновляет список грузов listBoxMachines
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
        /// Отображение атрибутов выбранного станка в dataGridAttribs
        /// </summary>
        private void ShowMachineAttributes()
        {
            dataGridAttribs.Rows.Clear();

            dataGridAttribs.Rows.Add(3);
            dataGridAttribs.Rows[0].HeaderCell.Value = "Код";
            dataGridAttribs.Rows[1].HeaderCell.Value = "Название";
            dataGridAttribs.Rows[2].HeaderCell.Value = "Модель";
            Machine machine = listBoxMachines.SelectedItem as Machine;
            if (machine != null)
            {
                dataGridAttribs.Rows[0].HeaderCell.Value = machine.ID;
                dataGridAttribs.Rows[1].HeaderCell.Value = machine.Name;
                dataGridAttribs.Rows[2].HeaderCell.Value = machine.Model;
            }
        }

        /// <summary>
        /// Добавляет новый станок в список
        /// </summary>
        private void AddNewMachine()
        {
            string id = dataGridAttribs.Rows[0].HeaderCell.Value.ToString();
            string name = dataGridAttribs.Rows[1].HeaderCell.Value.ToString();
            string model = dataGridAttribs.Rows[2].HeaderCell.Value.ToString();
            
            Worker worker = listBoxMachines.SelectedItem as Worker;
            if (worker != null)
            {
                worker.AddNewMachine(id, name, model);
                RefreshListBoxMachines();
            }
        }

        /// <summary>
        /// Удаляет выбранный станок из списка
        /// </summary>
        private void RemoveMachine()
        {
            Worker worker = listBoxMachines.SelectedItem as Worker;
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
        /// Выводит общие расходы на зарплату
        /// </summary>
        private void ShowTotalSalary()
        {
            MessageBox.Show(string.Format("{0} р.", workshop.GetTotalSalary()), "Общие расходы на зарплату");
        }

        /// <summary>
        /// Рассчитывает надбавку за дополнительное число станков
        /// </summary>
        private void OverSalary()
        {
            int countMachines = 0;
            int.TryParse(textBoxCountMachines.Text, out countMachines);
            if (countMachines != 0)
            {
                MessageBox.Show(string.Format("Надбавка за обслуживание {0} дополнительных станков стоставит: {1} р.", countMachines, workshop.GetOverSalary(countMachines)));
            }
        }

        /// <summary>
        /// Сохраняет данные в XML-файле
        /// </summary>
        private void SaveData()
        {

        }

        /// <summary>
        /// Загружает данные из XML-файла
        /// </summary>
        private void LoadData()
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Производственный цех";
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
    /// Представляет станки
    /// </summary>
    public class Machine
    {
        /// <summary>
        /// Идентификационный номер
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Модель
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Machine()
        {
            ID = "AAA-000000";
            Name = "Токарный станок";
            Model = "AA-0000";
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="id">Идентификационный номер</param>
        /// <param name="name">Название</param>
        /// <param name="model">Модель</param>
        public Machine(string id,  string name, string model)
        {
            ID = id;
            Name = name;
            Model = model;
        }

        /// <summary>
        /// Возвращает строку с данными о станке
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}; {1}", ID, Model);
        }
    }

    /// <summary>
    /// Представляет рабочих, обслуживающих станки
    /// </summary>
    public class Worker
    {
        /// <summary>
        /// Код
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// ФИО
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Специальность
        /// </summary>
        public string Speciality { get; set; }

        /// <summary>
        /// Разряд
        /// </summary>
        public int Grade { get; set; }

        /// <summary>
        /// Зарплата
        /// </summary>
        public int Salary { get; set; }

        /// <summary>
        /// Количество обслуживаемых станков
        /// </summary>
        public int CountMachine { get; set; }

        /// <summary>
        /// Список обслуживаемых станков
        /// </summary>
        public List<Machine> Machines { get; set; }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Worker()
        {
            ID = "0000";
            Name = "Иванов Иван Иванович";
            Speciality = "Мханик";
            Grade = 1;
            Salary = 20000;
            CountMachine = 0;
            Machines = new List<Machine>();
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="id">Код</param>
        /// <param name="name">ФИО</param>
        /// <param name="spec">Специальность</param>
        /// <param name="grade">Разряд</param>
        /// <param name="salary">Зарплата</param>
        /// <param name="countMachine">Число обслуживаемых станко</param>
        /// <param name="machines">Список обслуживаемых станков</param>
        public Worker(string id, string name, string spec, int grade, int salary)
        {
            ID= id;
            Name = name;
            Speciality = spec;
            Grade = grade;
            Salary = salary;
        }

        /// <summary>
        /// Возвращает строку с данными о рабочем
        /// </summary>
        /// <returns>Строка с данными о рабочем</returns>
        public override string ToString()
        {
            return string.Format("{0}. {1}", ID, Name);
        }

        /// <summary>
        /// Возвращает надбавку за обслуживание нескольких станков
        /// </summary>
        /// <returns>Надбавка за обслуживание нескольких станков</returns>
        public int GetOverSalary()
        {
            int overSalary = 0;

            foreach (Machine machine in Machines) overSalary += 5000;

            return overSalary;
        }

        /// <summary>
        /// Возвращает общую зарплату
        /// </summary>
        /// <returns>Общая зарплата</returns>
        public int GetTotalSalary()
        {
            int totalSalary = Salary + GetOverSalary();

            return totalSalary;
        }

        /// <summary>
        /// Добавляет новый станок рабочему
        /// </summary>
        /// <param name="id">Код станка</param>
        /// <param name="name">Наименование</param>
        /// <param name="model">Модель</param>
        public void AddNewMachine(string id, string name, string model)
        {
            Machines.Add(new Machine() { ID = id, Name = name, Model = model});
            CountMachine++;
        }

        /// <summary>
        /// Удалить станок с заданным номером
        /// </summary>
        /// <param name="id">Номер станка</param>
        public void RemoveMachine(int index)
        {
            Machines.RemoveAt(index);
            CountMachine--;
        }
    }

    /// <summary>
    /// Предстваляет цеха
    /// </summary>
    public class Workshop
    {
        /// <summary>
        /// Идентификационный номер
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список рабочих
        /// </summary>
        public List<Worker> Workers { get; set; }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Workshop()
        {
            ID = "AAA-00";
            Name = "Слесарный";
            Workers = new List<Worker>();
        }

        /// <summary>
        /// Коструктор с параметрами
        /// </summary>
        /// <param name="id">Индентификационный номер</param>
        /// <param name="name">Название</param>
        /// <param name="workers">Список рабочих</param>
        /// <param name="machines">Список станков</param>
        public Workshop(string id, string name, List<Worker> workers, List<Machine> machines)
        {
            ID = id;
            Name = name;
            Workers = workers;
        }

        /// <summary>
        /// Возвращает строку с данными о цехе
        /// </summary>
        /// <returns>Строка с данынми о цехе</returns>
        public override string ToString()
        {
            return string.Format("{0}. рабочих: {1} чел; станков: {2} шт\n", ID, Workers.Count);
        }

        /// <summary>
        /// Возвращает общие расходы на зарплату
        /// </summary>
        /// <returns>Общие расходы на зарплату</returns>
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
        /// Возвращает надбавку за дополнительные станки
        /// </summary>
        /// <param name="count">Число дополнительных станков</param>
        /// <returns>Надбавка за дополнительные станки</returns>
        public int GetOverSalary(int count)
        {
            return count * 5000;
        }

        /// <summary>
        /// Добавить нового рабочего в цех
        /// </summary>
        /// <param name="id">Код</param>
        /// <param name="name">ФИО</param>
        /// <param name="spec">Специальность</param>
        /// <param name="grade">Разряд</param>
        /// <param name="salary">Зарплата</param>
        /// <param name="countMachine">Количество станков</param>
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
        /// Удалить рабочего с выбранным номером
        /// </summary>
        /// <param name="index">Номер рабочего</param>
        public void RemoveWorker(int index)
        {
            Workers.RemoveAt(index);
        }
    }
}
