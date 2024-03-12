using System.Xml;
using System.Xml.Schema;

namespace XSDcheck
{
    public partial class Form1 : Form
    {
        bool xmlIsValid = true; // ������� ������������ XML-���������
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        public Form1()
        {
            InitializeComponent();
        }

        private void ReaderValidationEventHandler(object sender, ValidationEventArgs e)
        {
            // ��������� ������� ����������� ������
            if (e.Severity == XmlSeverityType.Warning)
            {
                listBox1.Items.Add("��������������: " + e.Message);
                xmlIsValid = false;
            }

            else if (e.Severity == XmlSeverityType.Error)
            {
                listBox1.Items.Add("������: " + e.Message);
                xmlIsValid = false;
            }
        }

        // ������������ ������� "�������� ����� Form1"
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "�������� ���������� XML � ������� XML-����";
            textBox1.Text = "http://www.nerazvod.hz/bank";
            textBox2.Text = @"XML\Nerazvod.xml";
            textBox3.Text = @"XML\NerazvodSchem.xsd";
        }

        // ����������� ������� "������� �� ������� ���������"
        private void button3_Click(object sender, EventArgs e)
        {
            // ������� ������ � ����������� ��� ������ XML-���������
            XmlReaderSettings rdSets = new XmlReaderSettings();
            // ������ ��� XML-����� (����� �� ����� XSD)
            rdSets.ValidationType = ValidationType.Schema;
            // ��������� XML-����� � ������ ������� ������������� ����
            rdSets.Schemas.Add(textBox1.Text, textBox3.Text);
            // ��������� ������� "������ ��� �������� XML-�����" � ��������� ��� ���������� ReaderValidationEventHandler
            rdSets.ValidationEventHandler += new ValidationEventHandler(ReaderValidationEventHandler);

            // ������� ������ ��� ������ XML-���������
            XmlReader reader = XmlReader.Create(textBox2.Text, rdSets);
            // ������ ��� ���� XML-��������� � ���������� ��������
            while (reader.Read())
            {
                if (xmlIsValid == true)
                {
                    listBox1.Items.Add("������ �� ����������! XML-�������� ������������� �����");
                }
            }
        }

        // ������������ ������� "������� ������ ����� ��� XML-���������"
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "XML=����� (*.xml)|*.xml";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = openFileDialog1.FileName;
            }
        }

        // ������������ ������� "������� ������� ����� ��� XSD-�����"
        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "XSD-����� (*.xsd)|*.xsd";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = openFileDialog1.FileName;
            }
        }
    }
}
