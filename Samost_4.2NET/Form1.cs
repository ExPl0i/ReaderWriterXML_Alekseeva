using Samost_4._2Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Samost_4._2NET
{
    public partial class Form1 : Form
    {
        List<Workshop> workshops; // Список цехов
        BindingSource worksopsBindSrc; // Объект для привязки данных о цехах
        BindingSource machinesBindSrc; // Объект для привязки данных о станках
        string xmlUri;

        public Form1()
        {
            InitializeComponent();
            workshops = new List<Workshop>();
            worksopsBindSrc = new BindingSource();
            machinesBindSrc = new BindingSource();
            xmlUri = @"C:\Users\mripo\Source\Repos\ExPl0i\ReaderWriterXML_Alekseeva\XML\Samost_4.xml";
        }

        /// <summary>
        /// Возвращает индекс цеха в списке worksops по выделенной ячейке
        /// dataGridWorkshops (при отсутствии объекта возвращает -1)
        /// </summary>
        /// <returns>Индекс цеха</returns>
        private int GetWorkshopIndex()
        {
            // Индекс, выводимый при отсутствии выбранного элемента
            const int incorIndex = -1;
            // Проверяем число выделенных ячеек в dataGridWorkshops
            if (dataGridWorkshops.SelectedCells.Count > 0)
            {
                int workshopIndex = dataGridWorkshops.SelectedCells[0].RowIndex;
                if (workshopIndex < workshops.Count)
                {
                    return workshopIndex;
                }
                else return incorIndex;
            }
            else return incorIndex;
        }

        /// <summary>
        /// Возвращает индекс станка в списке machines по выделенной
        /// ячейке dataGridMachines (при отсутствии объекта возвращает -1)
        /// </summary>
        /// <param name="workshopIndex"></param>
        /// <returns></returns>
        private int GetMachineIndex(int workshopIndex)
        {
            const int incorIndex = -1;
            if (workshopIndex < 0) { return incorIndex; }
            if (dataGridMachines.SelectedCells.Count > 0)
            {
                int machineIndex = dataGridMachines.SelectedCells[0].RowIndex;
                if (machineIndex < workshops[workshopIndex].Machines.Count)
                {
                    return machineIndex;
                }
                else return incorIndex;
            }
            else return incorIndex;
        }

        /// <summary>
        /// Выводит данные о цехе на элементы управления
        /// </summary>
        private void ShowWorkshopData()
        {
            int workshopIndex = GetWorkshopIndex();
            if (workshopIndex >= 0)
            {
                // Выводим данные о цехе в элемент labelWorkshopData
                labelWorkshopData.Text = workshops[workshopIndex].ToString();
            }
        }

        /// <summary>
        /// Выводит данные о станке на элементы управления
        /// </summary>
        private void ShowMachineData()
        {
            int workshopIndex = GetWorkshopIndex();
            int machineIndex = GetMachineIndex(workshopIndex);
            if ((workshopIndex >= 0) && (machineIndex >=0))
            {
                Machine machine = workshops[workshopIndex].Machines[machineIndex];
                labelMachineData.Text = machine.ToString();
            }
        }

        /// <summary>
        /// Выполняет привязку данных о кафедрах к элементам управления
        /// </summary>
        private void BindWorkshops()
        {
            worksopsBindSrc.DataSource = workshops;
            dataGridWorkshops.DataSource = worksopsBindSrc;
            comboBoxWorkshops.DataSource = worksopsBindSrc;
            comboBoxWorkshops.DisplayMember = "Name";
        }

        /// <summary>
        /// Выполняет привзяку данных о преподавателях к элементам управления
        /// </summary>
        private void BindMachines()
        {
            int workshopIndex = GetWorkshopIndex();
            if ((workshopIndex >= 0) && (workshopIndex < workshops.Count))
            {
                machinesBindSrc.DataSource = workshops[workshopIndex].Machines;
                dataGridMachines.DataSource = machinesBindSrc;
            }
        }

        /// <summary>
        /// Добавляет нужные столбцы в элемент dataGridWorkshops
        /// </summary>
        public void AddColsToDataGridWorkshops()
        {
            // Отключаем автоматическое создание столбцов
            dataGridWorkshops.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn idCol = new DataGridViewTextBoxColumn();
            idCol.DataPropertyName = "ID";
            idCol.HeaderText = "Номер";
            idCol.Width = 75;
            dataGridWorkshops.Columns.Add(idCol);

            DataGridViewTextBoxColumn nameCol = new DataGridViewTextBoxColumn();
            nameCol.DataPropertyName = "Name";
            nameCol.HeaderText = "Название";
            nameCol.Width = 200;
            dataGridWorkshops.Columns.Add(nameCol);
        }

        /// <summary>
        /// Добавляет нужные столбцы в элемент dataGridMachines
        /// </summary>
        private void AddColsToDataGridMachines()
        {
            dataGridMachines.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn idCol = new DataGridViewTextBoxColumn();
            idCol.DataPropertyName = "ID";
            idCol.HeaderText = "Номер";
            idCol.Width = 75;
            dataGridMachines.Columns.Add(idCol);

            DataGridViewTextBoxColumn nameCol = new DataGridViewTextBoxColumn();
            nameCol.DataPropertyName = "Name";
            nameCol.HeaderText = "Наименование";
            nameCol.Width = 200;
            dataGridMachines.Columns.Add(nameCol);

            DataGridViewTextBoxColumn modelCol = new DataGridViewTextBoxColumn();
            modelCol.DataPropertyName = "Model";
            modelCol.HeaderText = "Модель";
            modelCol.Width = 150;
            dataGridMachines.Columns.Add(modelCol);

            DataGridViewTextBoxColumn createDateCol = new DataGridViewTextBoxColumn();
            createDateCol.DataPropertyName = "CreateDate";
            createDateCol.HeaderText = "Дата выпуска";
            createDateCol.Width = 85;
            dataGridMachines.Columns.Add(createDateCol);

            DataGridViewTextBoxColumn wearCol = new DataGridViewTextBoxColumn();
            wearCol.DataPropertyName = "Wear";
            wearCol.HeaderText = "Износ";
            wearCol.Width = 75;
            dataGridMachines.Columns.Add(wearCol);
        }

        /// <summary>
        /// Сохраняет данные в XML
        /// </summary>
        private void SaveData()
        {
            XmlDataProvider<Workshop>.SaveObject(xmlUri, workshops);
            toolStripStatusLabel1.Text = "Данные успешно сохранены в " + xmlUri;
        }

        /// <summary>
        /// Сохраняет данные в выбранный файл
        /// </summary>
        private void SaveDataAs()
        {
            if ((saveFileDialog1.ShowDialog() == DialogResult.OK) && saveFileDialog1.FileName != null)
            {
                xmlUri = saveFileDialog1.FileName;
                SaveData();
            }
        }

        /// <summary>
        /// Загружает данные из XML-файла
        /// </summary>
        private void LoadData()
        {
            workshops = XmlDataProvider<List<Workshop>>.LoadObject(xmlUri);
            toolStripStatusLabel1.Text = "Данные загружены из " + xmlUri;
        }

        /// <summary>
        /// Загружает данные из выбранного XML-файла
        /// </summary>
        private void LoadDataFrom()
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != null)
            {
                LoadData();
            }
        }

        private void dataGridWorkshops_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowWorkshopData();
            BindMachines();
            BindWorkshops();
        }

        private void dataGridMachines_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BindMachines();
            BindWorkshops();
            ShowMachineData();  
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadDataFrom();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDataAs();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AddColsToDataGridWorkshops();
            AddColsToDataGridMachines();
        }

        private void comboBoxWorkshops_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindWorkshops();
        }
    }
}
