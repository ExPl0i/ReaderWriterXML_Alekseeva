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

        private void dataGridWorkshops_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridMachines_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
