using System.Xml;

namespace Samost_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Создание и чтение XML-документа с использованием модели DOM";
            // URI, задающий путь к XML-документу
            string uri = @"C:\Users\mripo\Source\Repos\ExPl0i\ReaderWriterXML_Alekseeva\XML\Debit.xml";
            XmlCreate(uri);
            XmlLoad(uri);
            Console.Read();
        }


        static void XmlCreate(string url)
        {
            XmlDocument xmlDoc = new XmlDocument();
            // Добавление объявления XML в XML-документ
            xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes"));
            // Добавление комментария в XML-документ
            xmlDoc.AppendChild(xmlDoc.CreateComment("Данные о банковских вкладах"));
            XmlElement rootElem = xmlDoc.CreateElement("debit");
            // Добавление корневого элемента в XML-документа
            xmlDoc.AppendChild(rootElem);
            // Задание пространства имен по умолчанию в корневом элементе
            rootElem.SetAttribute("xmlns", "http://www.debit.com/uslugi");

            XmlElement clientElem = xmlDoc.CreateElement("Client");
            rootElem.AppendChild(clientElem);
            clientElem.SetAttribute("ID", "1"); // Задание атрибута и его значения

            XmlElement numberElem = xmlDoc.CreateElement("number");
            // Задание текстового содержимого элемента-контейнера
            numberElem.InnerText = "40300767400000002167";
            clientElem.AppendChild(numberElem);
            XmlElement clietntNameElem = xmlDoc.CreateElement("clientName");
            clietntNameElem.InnerText = "Белкин Михаил Игоревич";
            clientElem.AppendChild(clietntNameElem);
            XmlElement dateElem = xmlDoc.CreateElement("date");
            dateElem.InnerText = "01.04.2024";
            clientElem.AppendChild(dateElem);
            XmlElement sumElem = xmlDoc.CreateElement("sum");
            sumElem.InnerText = "1000000";
            clientElem.AppendChild(sumElem);
            XmlElement procentElem = xmlDoc.CreateElement("procent");
            procentElem.InnerText = "7.5";
            clientElem.AppendChild(procentElem);

            // Сохранение документа в XML-файле
            xmlDoc.Save(url);
            Console.WriteLine("XML-документ создан по адресу: " + url);
            Console.Read();
        }

        
        static void XmlLoad(string url)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(url);
            Console.WriteLine("Код XML-документа:\n" + xmlDoc.InnerXml);
            Console.Read();
        }
    }
}
