using System.Text;
using System.Xml;



namespace ReaderWriter
{
    internal class Program
    {
        static void ShowXmlNodeData(XmlReader reader)
        {
            switch (reader.NodeType)
            {
                case XmlNodeType.Element:
                    Console.WriteLine("Элемент <{0}>", reader.Name);
                    if (reader.HasAttributes == true)
                    {
                        Console.WriteLine("Атрибуты элемента <{0}>:", reader.Name);
                        while (reader.MoveToNextAttribute())
                        {
                            Console.WriteLine("- {0} = {1}", reader.Name, reader.Value);
                        }
                    }
                    break;
                case XmlNodeType.Text:
                    Console.WriteLine("Текст: " + reader.Value); break;

                case XmlNodeType.Comment:
                    Console.WriteLine("Комментарий: " + reader.Value); break;

                case XmlNodeType.CDATA:
                    Console.WriteLine("Секция CDATA: " + reader.Value); break;
            }
        }

        static void ReadXml(string uri)
        {
            XmlReaderSettings rdSets = new XmlReaderSettings();
            rdSets.IgnoreWhitespace = true;
            rdSets.IgnoreComments = false;

            XmlReader reader = XmlReader.Create(uri, rdSets);

            Console.WriteLine("XML-данные, считанные из файла: " + uri);
            try
            {
                while (reader.Read()) ShowXmlNodeData(reader);
            }
            catch (XmlException exc)
            {
                Console.WriteLine("Ошибка в документе! " + exc.Message);
            }
        }

        static void WriteXml(string uri)
        {
            XmlWriterSettings wrSets = new XmlWriterSettings();
            wrSets.Indent = true;
            wrSets.Encoding = Encoding.UTF8;
            
            XmlWriter writer = XmlWriter.Create(uri, wrSets);

            writer.WriteStartDocument();
            writer.WriteComment("Содержит данные о клиентах банка, их кридитах и вкладах");
            writer.WriteStartElement("Client");
                writer.WriteAttributeString("ID", "3");
                writer.WriteStartElement("Name");
                    writer.WriteStartElement("FirstName");
                        writer.WriteString("Михаил");
                    writer.WriteEndElement();
                    writer.WriteStartElement("SecondName");
                        writer.WriteString("Игоревич");
                    writer.WriteEndElement();
                    writer.WriteStartElement("LastName");
                        writer.WriteString("Белкин");
                    writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteStartElement("phoneList");
                    writer.WriteStartElement("workPhone");
                        writer.WriteString("22-15-00");
                    writer.WriteEndElement();
                    writer.WriteStartElement("homePhone");
                        writer.WriteString("none");
                    writer.WriteEndElement();
                    writer.WriteStartElement("mobilePhone");
                        writer.WriteString("8-800-555-35-35");
                    writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteStartElement("passportInfo");
                    writer.WriteStartElement("serial");
                        writer.WriteString("77 23");
                    writer.WriteEndElement();
                    writer.WriteStartElement("number");
                        writer.WriteString("069690");
                    writer.WriteEndElement();
                    writer.WriteStartElement("policeName");
                        writer.WriteString("УПРАВЛЕНИЕ ФЕДЕРАЛЬНОЙ МИГРАЦИОННОЙ СЛУЖБЫ РОССИИ ПО ГОР. МОСКВЕ");
                    writer.WriteEndElement();
                    writer.WriteStartElement("policeID");
                        writer.WriteString("770-001");
                    writer.WriteEndElement();
                    writer.WriteStartElement("date");
                        writer.WriteString("24.12.2023");
                    writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteStartElement("debit");
                    writer.WriteAttributeString("ID", "2");
                    writer.WriteStartElement("number");
                        writer.WriteString("50803979800000009254");
                    writer.WriteEndElement();
                    writer.WriteStartElement("date");
                        writer.WriteString("26.12.2023");
                    writer.WriteEndElement();
                    writer.WriteStartElement("type");
                        writer.WriteString("Валютный");
                    writer.WriteEndElement();
                    writer.WriteStartElement("sum");
                        writer.WriteString("50000");
                    writer.WriteEndElement();
                    writer.WriteStartElement("procent");
                        writer.WriteString("4.2");
                    writer.WriteEndElement();
                    writer.WriteStartElement("term");
                        writer.WriteString("26.12.2025");
                    writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteStartElement("debit");
                    writer.WriteAttributeString("ID", "3");
                    writer.WriteStartElement("number");
                        writer.WriteString("50559147400000009412");
                    writer.WriteEndElement();
                    writer.WriteStartElement("date");
                        writer.WriteString("27.12.2023");
                    writer.WriteEndElement();
                    writer.WriteStartElement("type");
                        writer.WriteString("Валютный");
                    writer.WriteEndElement();
                    writer.WriteStartElement("sum");
                        writer.WriteString("150000");
                    writer.WriteEndElement();
                    writer.WriteStartElement("procent");
                        writer.WriteString("5.2");
                    writer.WriteEndElement();
                    writer.WriteStartElement("term");
                        writer.WriteString("27.12.2025");
                    writer.WriteEndElement();
            writer.WriteEndElement();
             writer.WriteStartElement("Client");
                writer.WriteAttributeString("ID", "4");
                writer.WriteStartElement("Name");
                    writer.WriteStartElement("FirstName");
                        writer.WriteString("Полина");
                    writer.WriteEndElement();
                    writer.WriteStartElement("SecondName");
                        writer.WriteString("Юрьевна");
                    writer.WriteEndElement();
                    writer.WriteStartElement("LastName");
                        writer.WriteString("Фомина");
                    writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteStartElement("phoneList");
                    writer.WriteStartElement("workPhone");
                        writer.WriteString("33-15-51");
                    writer.WriteEndElement();
                    writer.WriteStartElement("homePhone");
                        writer.WriteString("none");
                    writer.WriteEndElement();
                    writer.WriteStartElement("mobilePhone");
                        writer.WriteString("8-982-105-62-85");
                    writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteStartElement("passportInfo");
                    writer.WriteStartElement("serial");
                        writer.WriteString("77 23");
                    writer.WriteEndElement();
                    writer.WriteStartElement("number");
                        writer.WriteString("190091");
                    writer.WriteEndElement();
                    writer.WriteStartElement("policeName");
                        writer.WriteString("УПРАВЛЕНИЕ ФЕДЕРАЛЬНОЙ МИГРАЦИОННОЙ СЛУЖБЫ РОССИИ ПО ГОР. МОСКВЕ");
                    writer.WriteEndElement();
                    writer.WriteStartElement("policeID");
                        writer.WriteString("770-001");
                    writer.WriteEndElement();
                    writer.WriteStartElement("date");
                        writer.WriteString("05.01.2024");
                    writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteStartElement("debit");
                    writer.WriteAttributeString("ID", "4");
                    writer.WriteStartElement("number");
                        writer.WriteString("50465851600000001984");
                    writer.WriteEndElement();
                    writer.WriteStartElement("date");
                        writer.WriteString("06.01.2024");
                    writer.WriteEndElement();
                    writer.WriteStartElement("type");
                        writer.WriteString("Валютный");
                    writer.WriteEndElement();
                    writer.WriteStartElement("sum");
                        writer.WriteString("5000");
                    writer.WriteEndElement();
                    writer.WriteStartElement("procent");
                        writer.WriteString("4.2");
                    writer.WriteEndElement();
                    writer.WriteStartElement("term");
                        writer.WriteString("06.01.2025");
                    writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteStartElement("debit");
                    writer.WriteAttributeString("ID", "5");
                    writer.WriteStartElement("number");
                        writer.WriteString("40294110600000001373");
                    writer.WriteEndElement();
                    writer.WriteStartElement("date");
                        writer.WriteString("07.01.2024");
                    writer.WriteEndElement();
                    writer.WriteStartElement("type");
                        writer.WriteString("Валютный");
                    writer.WriteEndElement();
                    writer.WriteStartElement("sum");
                        writer.WriteString("150000");
                    writer.WriteEndElement();
                    writer.WriteStartElement("procent");
                        writer.WriteString("5.2");
                    writer.WriteEndElement();
                    writer.WriteStartElement("term");
                        writer.WriteString("07.01.2026");
                    writer.WriteEndElement();
            writer.WriteEndElement();
            writer.Close();

            Console.WriteLine("\nXML-даннные записаны в файл: " + uri);
        }
        static void Main(string[] args)
        {
            Console.Title = "Чтение и запист XML с помощьб XnlReader и XmlWriter";

            string uri = @"C:\Users\mripo\source\repos\ReaderWriter\Nerazvod.xml";
            ReadXml(uri);

            string newUri = @"C:\Users\mripo\source\repos\ReaderWriter\Bank.xml";
            WriteXml(newUri);
            ReadXml(newUri);
            Console.ReadLine();
        }
    }
}