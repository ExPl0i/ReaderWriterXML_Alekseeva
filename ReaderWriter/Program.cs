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
                writer.WriteStartElement("Name");
                    writer.WriteAttributeString("FirsName", "SecondName", "LastName");
                writer.WriteEndElement();
                writer.WriteStartElement("phoneList");
                    writer.WriteAttributeString("workPhone", "homePhone", "mobilePhone");
                writer.WriteEndElement();
                writer.WriteStartElement("passportInfo");
                    writer.WriteAttributeString("serial", "number", "policeName", "date");
                writer.WriteEndElement();
                writer.WriteStartElement("credit");
                    writer.WriteAttributeString("date", "type", "sum");
                    writer.WriteAttributeString("procent", "term");
                writer.WriteEndElement();
                writer.WriteStartElement("debit");
                    writer.WriteAttributeString("date", "type", "sum");
                    writer.WriteAttributeString("procent", "term");
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