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

            foreach (string id in AppFacade.GetWorkersStrArray())
            {
                listBoxWorkers.Items.Add(id);
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

            string id, name, speciality, grade, salary;

            AppFacade.GetWorkerAttribs(listBoxWorkers.SelectedIndex, out id, out name, out  speciality, out grade, out salary);

            dataGridAttribs.Rows[0].Cells[0].Value = id;
            dataGridAttribs.Rows[1].Cells[0].Value = name;
            dataGridAttribs.Rows[2].Cells[0].Value = speciality;
            dataGridAttribs.Rows[3].Cells[0].Value = grade;
            dataGridAttribs.Rows[4].Cells[0].Value = salary;
            
        }

        /// <summary>
        /// Добавляет нового рабочего в список
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
        /// Удаляет выбранного рабочего из списка
        /// </summary>
        private void RemoveWorker()
        {
            AppFacade.RemoveWorker(listBoxWorkers.SelectedIndex);
            RefreshListBoxWorkers();
        }

        /// <summary>
        /// Обновляет список грузов listBoxMachines
        /// </summary>
        private void RefreshListBoxMachines()
        {
            listBoxMachines.Items.Clear();
            
            foreach (string id in AppFacade.GetMachinesStrArray(listBoxWorkers.SelectedIndex))
                listBoxMachines.Items.Add(id);
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

            string id, name, model;

            AppFacade.GetMachineAttribs(listBoxWorkers.SelectedIndex, listBoxMachines.SelectedIndex, out id, out name, out model);

            dataGridAttribs.Rows[0].Cells[0].Value = id;
            dataGridAttribs.Rows[1].Cells[0].Value = name;
            dataGridAttribs.Rows[2].Cells[0].Value = model;
        }

        /// <summary>
        /// Добавляет новый станок в список
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
        /// Удаляет выбранный станок из списка
        /// </summary>
        private void RemoveMachine()
        {
            AppFacade.RemoveMachine(listBoxWorkers.SelectedIndex, listBoxMachines.SelectedIndex)
        }

        /// <summary>
        /// Выводит общие расходы на зарплату
        /// </summary>
        private void ShowTotalSalary()
        {
            MessageBox.Show(string.Format("{0} р.", AppFacade.GetTotalSalary()), "Общие расходы на зарплату");
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
                MessageBox.Show(string.Format("Надбавка за обслуживание {0} дополнительных станков стоставит: {1} р.", countMachines, AppFacade.GetOverSalary(countMachines)));
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
            this.Text = "Производственный цех";
            RefreshListBoxWorkers();
            textBoxCountMachines.Text = "5";
        }
    }

    /// <summary>
    /// Представляет фасадный объет
    /// </summary>
    public class AppFacade
    {
        private static Workshop workshop = new Workshop(); // Цех по умолчанию

        /// <summary>
        /// Загрузить даныне из XML-файла
        /// </summary>
        /// <param name="xmlFileUri">Путь к XML-файлу</param>
        public static void LoadData(string xmlFileUri)
        {
            
        }

        /// <summary>
        /// Сохранить данные в XML-файле
        /// </summary>
        /// <param name="xmlFileUri">Путь к XML-файлу</param>
        public static void SaveData(string xmlFileUri)
        {

        }

        /// <summary>
        /// Проверяет правильность индекса для рабочего
        /// </summary>
        /// <param name="workerIndex">Индекс рабочего</param>
        /// <returns></returns>
        private static bool CheckWorkerIndex(int workerIndex)
        {
            bool checkResult = false; // Результат проверки

            if ((workerIndex >= 0) && (workerIndex < workshop.Workers.Count))
                checkResult = true;

            return checkResult;
        }

        /// <summary>
        /// Проверяет правильность индекса для станка
        /// </summary>
        /// <param name="workerIndex">Индекс рабочего</param>
        /// <param name="machineIndex">Индекс станка</param>
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
        /// Возвращает массив строк с данными о рабочих
        /// </summary>
        /// <returns>Массив строк с данными о рабочих</returns>
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
        /// Возвращает массив строк с данными о станках
        /// </summary>
        /// <param name="workerIndex">Индекс рабочего</param>
        /// <returns>Массив строк с данными о станках</returns>
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
        /// Возвращает значения атрибутов рабочего (через выходные параметры)
        /// </summary>
        /// <param name="workerIndex">Индекс рабочего</param>
        /// <param name="id">Код рабочего</param>
        /// <param name="name">ФИО</param>
        /// <param name="speciality">Специальность</param>
        /// <param name="grade">Разряд</param>
        /// <param name="salary">Зарплата</param>
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
        /// Возвращает значения атрибутов груза (через выходные параметры)
        /// </summary>
        /// <param name="workerIndex">Индекс рабочего</param>
        /// <param name="machineIndex">Индекс станка</param>
        /// <param name="id">Код станка</param>
        /// <param name="name">Наименование</param>
        /// <param name="model">Модель</param>
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
        /// Добавляет нового рабочего в цех
        /// </summary>
        /// <param name="id">Код рабочего</param>
        /// <param name="name">ФИО</param>
        /// <param name="speciality">Специальность</param>
        /// <param name="grade">Разряд</param>
        /// <param name="salary">Зарплата</param>
        public static void AddNewWorker(string id, string name, string speciality, int grade, int salary)
        {
            Worker newWorker = new Worker() { ID = id, Name = name, Speciality = speciality, Grade = grade, Salary = salary };
            workshop.Workers.Add(newWorker);
        }

        /// <summary>
        /// Добавляет новый станок рабочему цеха
        /// </summary>
        /// <param name="workerIndex">Индекс рабочего</param>
        /// <param name="id">Код станка</param>
        /// <param name="name">Наименование</param>
        /// <param name="model">Модель</param>
        public static void AddNewMachine(int workerIndex, string id, string name, string model)
        {
            if (CheckWorkerIndex(workerIndex) == true)
            {
                Machine newMachine = new Machine() { ID = id, Name = name, Model = model };
                workshop.Workers[workerIndex].Machines.Add(newMachine);
            }
        }

        /// <summary>
        /// Удаляет выбранного рабочего
        /// </summary>
        /// <param name="workerIndex">Индекс рабочего</param>
        public static void RemoveWorker(int workerIndex)
        {
            if (CheckWorkerIndex(workerIndex) == true)
                workshop.Workers.RemoveAt(workerIndex);
        }

        /// <summary>
        /// Удаляет выбранный станок у рабочего цеха
        /// </summary>
        /// <param name="workerIndex">Индекс рабочего</param>
        /// <param name="machineIndex">Индекс станка</param>
        public static void RemoveMachine(int workerIndex, int machineIndex)
        {
            if (CheckMachineIndex(workerIndex, machineIndex) == true)
                workshop.Workers[workerIndex].Machines.RemoveAt(machineIndex);
        }

        /// <summary>
        /// Возвращает общие расходы на зарплату
        /// </summary>
        /// <returns>Общие расходы на зарплату</returns>
        public static int GetTotalSalary()
        {
            return workshop.GetTotalSalary();
        }

        /// <summary>
        /// Возвращате доплату за количество станков
        /// </summary>
        /// <param name="count">Количество станков</param>
        /// <returns>Доплата за количество станков</returns>
        public static int GetOverSalary(int count)
        {
            return workshop.GetOverSalary(count);
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
        public Machine(string id, string name, string model)
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
            ID = id;
            Name = name;
            Speciality = spec;
            Grade = grade;
            Salary = salary;
            Machines = new List<Machine>();
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
            Machines.Add(new Machine() { ID = id, Name = name, Model = model });
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
        public Workshop(string id, string name)
        {
            ID = id;
            Name = name;
            Workers = new List<Worker>();
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
