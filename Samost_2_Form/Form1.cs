using System.Xml;

namespace Samost_2_Form
{
    public partial class Form1 : Form
    {
        XmlDataProvider xdp;

        /// <summary>
        /// Представляет элемент списка ListView (вложенный класс)
        /// </summary>
        class MyListViewItem : ListViewItem
        {
            // Узел XML-документа, связанный с элементом списка
            public XmlNode XmlNode {  get; set; }

            public MyListViewItem(XmlNode xn)
            {
                this.XmlNode = xn;
                this.Text = string.Format("- {0} - {1}", xn.SelectSingleNode("@id").InnerText, xn.SelectSingleNode("name").InnerText);
            }
        }

        // Конструктор класса Form1
        public Form1()
        {
            InitializeComponent();
            xdp = new XmlDataProvider();
        }

        // Обработка события "Загрузка формы Form1"
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Модификация XML-документа";
            this.Font = new Font("Arial", 10, FontStyle.Regular);
            listView1.View = View.List;
            textBoxXml.ScrollBars = ScrollBars.Vertical;
            textBoxXml.Text = xdp.GetXmlCode().ToLower();

            MyListViewItem myLvI;
            // Заполнение списка listView1
            foreach (XmlNode xn in xdp.GetXmlNodes())
            {
                myLvI = new MyListViewItem(xn);
                listView1.Items.Add(myLvI);
            }
        }

        // Обработчик события "Выбор нового элемента списка listView1"
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Коллекция выделенных элементов списка ListView
            ListView.SelectedListViewItemCollection sLviC = listView1.SelectedItems;

            // Выбор первого элемента коллекции sLviC и запись его данных в текстовые поля
            foreach (MyListViewItem myLvi in  sLviC)
            {
                textBoxNumber.Text = myLvi.XmlNode.SelectSingleNode("number").InnerText;
                textBoxName.Text = myLvi.XmlNode.SelectSingleNode("name").InnerText;
                textBoxDate.Text = myLvi.XmlNode.SelectSingleNode("date").InnerText;
                textBoxSum.Text = myLvi.XmlNode.SelectSingleNode("sum").InnerText;
                textBoxProcent.Text = myLvi.XmlNode.SelectSingleNode("procent").InnerText;
                break;
            }
        }

        // Обарботчик события "Нажатие на кнопку buttonAdd"
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            XmlNode xn = xdp.GetXmlNode();

            // Считывание данных из текстовых полейи их запись в XML-узел xn
            xn.SelectSingleNode("number").InnerText = textBoxNumber.Text;
            xn.SelectSingleNode("name").InnerText = textBoxName.Text;
            xn.SelectSingleNode("date").InnerText = textBoxDate.Text;
            xn.SelectSingleNode("sum").InnerText = textBoxSum.Text;
            xn.SelectSingleNode("procent").InnerText = textBoxProcent.Text;

            MyListViewItem myLvi = new MyListViewItem(xn);

            xdp.AddXmlNode(myLvi.XmlNode);
            listView1.Items.Add(myLvi);

            textBoxXml.Text = xdp.GetXmlCode();
        }

        // Обработчиксобытия "Нажатите на кнопку buttonRemove"
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            // Коллекция выделенных элементов списка ListView
            ListView.SelectedListViewItemCollection sLviC = listView1.SelectedItems;

            foreach (MyListViewItem myLvi in sLviC)
            {
                xdp.RemoveXmlNode(myLvi.XmlNode);
                myLvi.Remove();
            }
            textBoxXml.Text = xdp.GetXmlCode();
        }
    }

    /// <summary>
    /// Обеспечивает работы с XML-документом
    /// </summary>
    public class XmlDataProvider
    {
        XmlDocument doc; // XML-документ
        string url;      // Указатель ресурса

        public XmlDataProvider()
        {
            doc = new XmlDocument();
            url = @"C:\Users\mripo\Source\Repos\ExPl0i\ReaderWriterXML_Alekseeva\XML\Debits.xml";
        }

        /// <summary>
        /// Возвращает строку с кодом XML-документа
        /// </summary>
        /// <returns>Код XML-документа</returns>
        public string GetXmlCode()
        {
            doc.LoadXml(url);
            return (doc.InnerXml);
        }

        /// <summary>
        /// Возвращает список узлов debit Xml-документа
        /// </summary>
        /// <returns>Список узлов debit Xml-документа</returns>
        public XmlNodeList GetXmlNodes()
        {
            doc.Load(url);
            XmlNodeList xnl = doc.SelectNodes("debits/debit");
            return xnl;
        }

        /// <summary>
        /// Возвращает произвольный узел debit XML-документа
        /// </summary>
        /// <returns>Произвольный узел debit XML-документа</returns>
        public XmlNode GetXmlNode()
        {
            // Построение дерева для XML-элемента
            XmlElement debitElem = doc.CreateElement("debit");
            debitElem.SetAttribute("id", "X");
            XmlElement numberElem = doc.CreateElement("number");
            numberElem.InnerText = "Номер вклада";
            debitElem.AppendChild(numberElem);
            XmlElement nameElem = doc.CreateElement("name");
            nameElem.InnerText = "ФИО вкладчика";
            debitElem.AppendChild(nameElem);
            XmlElement dateElem = doc.CreateElement("date");
            dateElem.InnerText = "Дата вклада";
            debitElem.AppendChild(dateElem);
            XmlElement sumElem = doc.CreateElement("sum");
            sumElem.InnerText = "Сумма вклада";
            debitElem.AppendChild(sumElem);
            XmlElement procentElem = doc.CreateElement("procent");
            procentElem.InnerText = "Процент по вкладу";
            debitElem.AppendChild(procentElem);
            return (debitElem);
        }

        /// <summary>
        /// Удалаяет заданный узел из XML-документа
        /// </summary>
        /// <param name="xn">Удаляемый XML-узел</param>
        public void RemoveXmlNode(XmlNode xn)
        {
            string id = xn.SelectSingleNode("@id").InnerText;
            XmlNodeList xnl = doc.SelectNodes("debits/dedit");
            foreach (XmlNode x in xnl)
            {
                if (x.SelectSingleNode("@id").InnerText == id)
                {
                    doc.DocumentElement.RemoveChild(x);
                    break;
                }
            }
            doc.Save(url);
        }

        /// <summary>
        /// Добавляет узел в XML-документ
        /// </summary>
        /// <param name="xn">Добавляемый XML-узел</param>
        public void AddXmlNode(XmlNode xn)
        {
            //Выбор корневого элемента XML-документа doc и добавление в него нового узла xn
            doc.DocumentElement.AppendChild(xn);
            doc.Save(url);
        }
    }
}
