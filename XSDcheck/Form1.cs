using System.Xml;
using System.Xml.Schema;

namespace XSDcheck
{
    public partial class Form1 : Form
    {
        bool xmlIsValid = true; // Признак правильности XML-документа
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        public Form1()
        {
            InitializeComponent();
        }

        private void ReaderValidationEventHandler(object sender, ValidationEventArgs e)
        {
            // Проверяем уровень серьезности ошибки
            if (e.Severity == XmlSeverityType.Warning)
            {
                listBox1.Items.Add("Предупреждение: " + e.Message);
                xmlIsValid = false;
            }

            else if (e.Severity == XmlSeverityType.Error)
            {
                listBox1.Items.Add("Ошибка: " + e.Message);
                xmlIsValid = false;
            }
        }

        // Обрабатывает событие "Загрузка формы Form1"
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Проверка документов XML с помощью XML-схем";
            textBox1.Text = "http://www.nerazvod.hz/bank";
            textBox2.Text = @"XML\Nerazvod.xml";
            textBox3.Text = @"XML\NerazvodSchem.xsd";
        }

        // Обрабытвает событие "Нажатие на кнопуку Проверить"
        private void button3_Click(object sender, EventArgs e)
        {
            // Создаем объект с параметрами для чтения XML-документа
            XmlReaderSettings rdSets = new XmlReaderSettings();
            // Задаем тип XML-схемы (схема на языке XSD)
            rdSets.ValidationType = ValidationType.Schema;
            // Добавляем XML-схему с нужным целевым пространством имен
            rdSets.Schemas.Add(textBox1.Text, textBox3.Text);
            // Добавляем событие "Ошибка при проверке XML-схемы" и указываем его обработчик ReaderValidationEventHandler
            rdSets.ValidationEventHandler += new ValidationEventHandler(ReaderValidationEventHandler);

            // Создаем объект для чтения XML-документа
            XmlReader reader = XmlReader.Create(textBox2.Text, rdSets);
            // Читаем все узлы XML-документа с выполнение проверки
            while (reader.Read())
            {
                if (xmlIsValid == true)
                {
                    listBox1.Items.Add("Ошибок не обнаружено! XML-документ соответствует схеме");
                }
            }
        }

        // Обрабатывает событие "Нажатие кнопки Обзор для XML-документа"
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "XML=файлы (*.xml)|*.xml";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = openFileDialog1.FileName;
            }
        }

        // Обрабатывает событие "Нажатие кнопкио Обзор для XSD-схемы"
        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "XSD-файлы (*.xsd)|*.xsd";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = openFileDialog1.FileName;
            }
        }
    }
}
