using Samost_4._1Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Samost_4._1NET
{
    public partial class Form1 : Form
    {
        List<Debit> debits;
        string xmlFileUri;

        public Form1()
        {
            InitializeComponent();
            debits = new List<Debit>();
            xmlFileUri = @"C:\Users\mripo\Source\Repos\ExPl0i\ReaderWriterXML_Alekseeva\XML\Samost_4.1.xml";
        }

        /// <summary>
        /// Выполняет привязку списка debits к элементу dataGridDebits
        /// </summary>
        private void BindDebits()
        {
            debitBindingSource.DataSource = debits;
            dataGridDebits.DataSource = debitBindingSource;
        }

        /// <summary>
        /// Сохраняет данные в XML
        /// </summary>
        private void SaveData()
        {
            XmlDataProvider<Debit>.SaveObject(xmlFileUri, debits);
            MessageBox.Show("Данные сохранены");
        }

        /// <summary>
        /// Загружает данные из XML
        /// </summary>
        private void LoadData()
        {
            debits = XmlDataProvider<Debit>.LoadObject(xmlFileUri);
            BindDebits();
            MessageBox.Show("Данные загружены");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Привязка данных";
            BindDebits();
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
}
