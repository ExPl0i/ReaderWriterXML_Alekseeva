using System.Xml;
using System.Xml.XPath;

namespace XpathRequests3
{
    internal class Program
    {
        /// <summary>
        /// Обрабатывает выражение XPath с выводом результатов на консоль
        /// </summary>
        /// <param name="xpnav">Экземпляр XPathNavigator</param>
        /// <param name="exprs">XPath-выражение</param>
        /// <param name="title">Заголовок</param>
        static void XPathProcess(XPathNavigator xpnav, string exprs, string title)
        {
            double result = 0.0;
            // Создаем объект для управления пространствами имен XML
            XmlNamespaceManager nsMgr = new XmlNamespaceManager(xpnav.NameTable);
            // Добавляем пространство имен по умолчанию с фиктивным префиксом "t"
            nsMgr.AddNamespace("t", "http://www.nerazvod.hz/bank");
            nsMgr.AddNamespace("db", "http://www.nerazvod.hz/bank/debit");


            // Признак того, является ли результат XPath-выражения числом
            bool isNumber = double.TryParse(xpnav.Evaluate(exprs, nsMgr).ToString(),
                out result);
            if (isNumber == false)
            {
                Console.WriteLine(title);
                // Создание итератора для перебора узлов
                XPathNodeIterator xpnIter = xpnav.Select(exprs, nsMgr);
                // Объект XPathNavigator для работы с текущим узлом
                XPathNavigator navCurNode = xpnIter.Current;
                while (xpnIter.MoveNext())
                {
                    Console.WriteLine("- {0}", navCurNode.Value);
                }
            }
            else Console.WriteLine(title + " {0}", result);
        }

        /// <summary>
        /// Выводит данные всех кредитов, предоставленных банком
        /// </summary>
        /// <param name="xpNav">Объект XPathNavigator</param>
        static void Query1(XPathNavigator xpNav)
        {
            string title = "1. Все кредиты, предоставленные банком:";
            string exprs = "t:bank/t:Client/t:credit";
            XPathProcess(xpNav, exprs, title);
        }

        /// <summary>
        /// Выводит число всех клиентов банка
        /// </summary>
        /// <param name="xpNav">Объект XPathNavigator</param>
        static void Query2(XPathNavigator xpNav)
        {
            string title = "2. Число всех клиентов банка:";
            string exprs = "count(t:bank/t:Client)";
            XPathProcess(xpNav, exprs, title);
        }

        /// <summary>
        /// Выводит данные о всех вкладах, сделанных клиентом
        /// </summary>
        /// <param name="xpNav">Объект XPathNavigator</param>
        static void Query3(XPathNavigator xpNav, string fname, string sname, string lname)
        {
            string title = string.Format("3. Все вклады, сделанные клиентом {0} {1} {2} :", fname, sname, lname);
            string exprs = string.Format("count(t:bank/t:Client[t:Name/FirstName = {0} and t:Name/SeconName = {1} and t:Name/LastName = {2}]/t:debit)", fname, sname, lname);
            XPathProcess(xpNav, exprs, title);
        }

        static void Main(string[] args)
        {
            Console.Title = "XPath-запросы к XML-документу";
            // URI, задающий путь к XML-документу
            string uri = @"C:\Users\mripo\Source\Repos\ExPl0i\ReaderWriterXML_Alekseeva\Nerazvod.xml";
            // Объект XPathDocument для чтения XML-документа
            XPathDocument xpDoc = new XPathDocument(uri);
            // Объект XPathNavigator для обработки XPath-выражений
            XPathNavigator xpNav = xpDoc.CreateNavigator();
            // Выполнение запросов к XML-документу
            Query1(xpNav);
            Console.WriteLine();
            Query2(xpNav);
            Console.WriteLine();
            Query3(xpNav, "Иван", "Петрович", "Сидтиков");
            Console.WriteLine();

            Console.Read();
        }
    }
}