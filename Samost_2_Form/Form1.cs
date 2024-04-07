using System.Xml;

namespace Samost_2_Form
{
    public partial class Form1 : Form
    {
        XmlDataProvider xdp;

        /// <summary>
        /// ������������ ������� ������ ListView (��������� �����)
        /// </summary>
        class MyListViewItem : ListViewItem
        {
            // ���� XML-���������, ��������� � ��������� ������
            public XmlNode XmlNode {  get; set; }

            public MyListViewItem(XmlNode xn)
            {
                this.XmlNode = xn;
                this.Text = string.Format("- {0} - {1}", xn.SelectSingleNode("@id").InnerText, xn.SelectSingleNode("name").InnerText);
            }
        }

        // ����������� ������ Form1
        public Form1()
        {
            InitializeComponent();
            xdp = new XmlDataProvider();
        }

        // ��������� ������� "�������� ����� Form1"
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "����������� XML-���������";
            this.Font = new Font("Arial", 10, FontStyle.Regular);
            listView1.View = View.List;
            textBoxXml.ScrollBars = ScrollBars.Vertical;
            textBoxXml.Text = xdp.GetXmlCode().ToLower();

            MyListViewItem myLvI;
            // ���������� ������ listView1
            foreach (XmlNode xn in xdp.GetXmlNodes())
            {
                myLvI = new MyListViewItem(xn);
                listView1.Items.Add(myLvI);
            }
        }

        // ���������� ������� "����� ������ �������� ������ listView1"
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ��������� ���������� ��������� ������ ListView
            ListView.SelectedListViewItemCollection sLviC = listView1.SelectedItems;

            // ����� ������� �������� ��������� sLviC � ������ ��� ������ � ��������� ����
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

        // ���������� ������� "������� �� ������ buttonAdd"
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            XmlNode xn = xdp.GetXmlNode();

            // ���������� ������ �� ��������� ������ �� ������ � XML-���� xn
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

        // ����������������� "�������� �� ������ buttonRemove"
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            // ��������� ���������� ��������� ������ ListView
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
    /// ������������ ������ � XML-����������
    /// </summary>
    public class XmlDataProvider
    {
        XmlDocument doc; // XML-��������
        string url;      // ��������� �������

        public XmlDataProvider()
        {
            doc = new XmlDocument();
            url = @"C:\Users\mripo\Source\Repos\ExPl0i\ReaderWriterXML_Alekseeva\XML\Debits.xml";
        }

        /// <summary>
        /// ���������� ������ � ����� XML-���������
        /// </summary>
        /// <returns>��� XML-���������</returns>
        public string GetXmlCode()
        {
            doc.LoadXml(url);
            return (doc.InnerXml);
        }

        /// <summary>
        /// ���������� ������ ����� debit Xml-���������
        /// </summary>
        /// <returns>������ ����� debit Xml-���������</returns>
        public XmlNodeList GetXmlNodes()
        {
            doc.Load(url);
            XmlNodeList xnl = doc.SelectNodes("debits/debit");
            return xnl;
        }

        /// <summary>
        /// ���������� ������������ ���� debit XML-���������
        /// </summary>
        /// <returns>������������ ���� debit XML-���������</returns>
        public XmlNode GetXmlNode()
        {
            // ���������� ������ ��� XML-��������
            XmlElement debitElem = doc.CreateElement("debit");
            debitElem.SetAttribute("id", "X");
            XmlElement numberElem = doc.CreateElement("number");
            numberElem.InnerText = "����� ������";
            debitElem.AppendChild(numberElem);
            XmlElement nameElem = doc.CreateElement("name");
            nameElem.InnerText = "��� ���������";
            debitElem.AppendChild(nameElem);
            XmlElement dateElem = doc.CreateElement("date");
            dateElem.InnerText = "���� ������";
            debitElem.AppendChild(dateElem);
            XmlElement sumElem = doc.CreateElement("sum");
            sumElem.InnerText = "����� ������";
            debitElem.AppendChild(sumElem);
            XmlElement procentElem = doc.CreateElement("procent");
            procentElem.InnerText = "������� �� ������";
            debitElem.AppendChild(procentElem);
            return (debitElem);
        }

        /// <summary>
        /// �������� �������� ���� �� XML-���������
        /// </summary>
        /// <param name="xn">��������� XML-����</param>
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
        /// ��������� ���� � XML-��������
        /// </summary>
        /// <param name="xn">����������� XML-����</param>
        public void AddXmlNode(XmlNode xn)
        {
            //����� ��������� �������� XML-��������� doc � ���������� � ���� ������ ���� xn
            doc.DocumentElement.AppendChild(xn);
            doc.Save(url);
        }
    }
}
