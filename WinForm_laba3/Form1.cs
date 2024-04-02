

using ClassLib_laba3;

namespace WinForm_laba3
{

    public partial class Form1 : Form
    {
        List<ClassLib_laba3.Debit> debits; //Список вкладов
        string xmlUri; // Путь к XML-документу
        public Form1()
        {
            InitializeComponent();
            debits = new List<ClassLib_laba3.Debit>()
            {
                new ClassLib_laba3.Debit(),
                new ClassLib_laba3.Debit()
                {
                    Number = "40761306700000009222",
                    NameOwner = "Горбункова Ульяна Игоревна",
                    Date = "01.03.2023",
                    Sum = 200000,
                    Procent = 7
                }
            };
            xmlUri = @"DebitData1.xml";
        }

        /// <summary>
        /// Обновляет элементы списка listBoxDebits
        /// </summary>
        private void RefreshListBoxDebits()
        {
           listBoxDebits.Items.Clear();
            int i = 0;

            foreach (ClassLib_laba3.Debit debit in debits)
            {
                listBoxDebits.Items.Add(string.Format("{0}. {1} {2}", ++i, debit.Number, debit.NameOwner));
            }
        }

        /// <summary>
        /// Выводит даныне о банковском вкладе в элементы управления
        /// </summary>
        private void ShowDebitData()
        {
            int index = listBoxDebits.SelectedIndex;
            if (index >= 0 && index < debits.Count)
            {
                textBoxNumber.Text = debits[index].Number;
                textBoxNameOwner.Text = debits[index].NameOwner;
                textBoxDate.Text = debits[index].Date;
                textBoxSum.Text = debits[index].Sum.ToString();
                textBoxProcent.Text = debits[index].Procent.ToString();
            }
        }

        /// <summary>
        /// Созадает и добавляет в список новый вклад с введенными данными
        /// </summary>
        private void AddNewDebit()
        {
            ClassLib_laba3.Debit newDebit = new ClassLib_laba3.Debit()
            {
                Number = textBoxNumber.Text,
                NameOwner = textBoxNameOwner.Text, 
                Date = textBoxDate.Text,
                Sum = double.Parse(textBoxSum.Text),
                Procent = double.Parse(textBoxProcent.Text)
            };
            debits.Add(newDebit);
            RefreshListBoxDebits();
        }

        /// <summary>
        /// Удаляет выбранный вклад из списка
        /// </summary>
        private void RemoveDebit()
        {
            int index = listBoxDebits.SelectedIndex;
            if (index >= 0 && index < debits.Count)
            {
                debits.RemoveAt(index);
            }
            RefreshListBoxDebits();
        }

        /// <summary>
        /// Изменяет данные о выбранном вкладе
        /// </summary>
        private void ChangeDebitData()
        {
            int index = listBoxDebits.SelectedIndex;
            if (index >= 0 && index < debits.Count)
            {
                debits[index].Number = textBoxNumber.Text;
                debits[index].NameOwner = textBoxNameOwner.Text;
                debits[index].Date = textBoxDate.Text;
                debits[index].Sum = double.Parse(textBoxSum.Text);
                debits[index].Procent = double.Parse(textBoxProcent.Text);
            }
            RefreshListBoxDebits();
        }

        /// <summary>
        /// Сохраняет данные в XML-документе
        /// </summary>
        private void SaveData()
        {
            XmlDataProvider<List<ClassLib_laba3.Debit>>.SaveObject(xmlUri, debits);
            MessageBox.Show("Данные успешно созранены!");
        }


        private void LoadData()
        {
            debits = XmlDataProvider<List<ClassLib_laba3.Debit>>.LoadObject(xmlUri);
            RefreshListBoxDebits();
            MessageBox.Show("Данные успешно загруженны!");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Сохранение и загрузка данных";
            RefreshListBoxDebits();
        }

        private void listBoxPersons_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowDebitData();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddNewDebit();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            RemoveDebit();
        }

        private void butonChange_Click(object sender, EventArgs e)
        {
            ChangeDebitData();
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
