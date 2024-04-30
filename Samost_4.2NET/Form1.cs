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
