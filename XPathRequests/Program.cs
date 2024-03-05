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
        /// <param name="fname">Имя</param>
        /// <param name="sname"><Отчество/param>
        /// <param name="lname">Фамилия</param>
        static void Query3(XPathNavigator xpNav, string fname, string sname, string lname)
        {
            string title = string.Format("3. Все вклады, сделанные клиентом {0} {1} {2} :", fname, sname, lname);
            string exprs = string.Format("count(t:bank/t:Client[t:Name/t:FirstName = '{0}' and t:Name/t:SecondName = '{1}' and t:Name/t:LastName = '{2}']/t:debit)", fname, sname, lname);
            XPathProcess(xpNav, exprs, title);
        }

        /// <summary>
        /// Выводит данные о кредитах, у которых процентная ставка меньше заданной
        /// </summary>
        /// <param name="xpNav">Объект XPathNavigator</param>
        /// <param name="procent">Процентная ставка</param>
        static void Query4(XPathNavigator xpNav, double procent)
        {
            string title = string.Format("4. Число кредитов по которым процентная ставка меньше {0}:", procent);
            string exprs = string.Format("count(t:bank/t:Client/t:credit[t:procent<{0}])", procent);
            XPathProcess(xpNav, exprs, title);
        }

        /// <summary>
        /// Выводит данные о кредитах, взятых в заданную дату, у которых сумма больше заданной
        /// </summary>
        /// <param name="xpNav">Объект XPathNavigator</param>
        /// <param name="data">Дата кредита</param>
        /// <param name="sum">Сумма кредита</param>
        static void Query5(XPathNavigator xpNav, string data, int sum)
        {
            string title = string.Format("5. Кредиты, взятые {0} на сумму более {1}:", data, sum);
            string exprs = string.Format("count(t:bank/t:Client/t:credit[t:date = '{0}' and t:sum>{1}])", data, sum);
            XPathProcess(xpNav, exprs, title);
        }

        /// <summary>
        /// Выводит данные о среднем размере вклада
        /// </summary>
        /// <param name="xpNav">Объект XPathNavigator</param>
        static void Query6(XPathNavigator xpNav)
        {
            string title = string.Format("6. Средний размер вклада:");
            string exprs = string.Format("sum(t:bank/t:Client/t:debit/t:sum) div count(t:bank/t:Client/t:debit)");
            XPathProcess(xpNav, exprs, title);
        }

        /// <summary>
        /// Выводит данные о клиентах, взявших более одного кредита
        /// </summary>
        /// <param name="xpNav">Объект XPathNavigator</param>
        static void Query7(XPathNavigator xpNav)
        {
            string title = string.Format("7. Клиенты, взявшие более одного кредита:");
            string exprs = string.Format("t:bank/t:Client[count(t:credit) > 1]/t:Name");
            XPathProcess(xpNav, exprs, title);
        }

        /// <summary>
        /// Выводит данные о числе вкладов, размер которых находится между заданными величинами
        /// </summary>
        /// <param name="xpNav">Объект XPathNavigator</param>
        /// <param name="sum1">Первая величина</param>
        /// <param name="sum2">Вторая величина</param>
        static void Query8(XPathNavigator xpNav, int sum1, int sum2)
        {
            string title = string.Format("8. Число вкладов, размер которых составляет от {0} до {1}:", sum1, sum2);
            string exprs = string.Format("count(t:bank/t:Client/t:debit[t:sum > {0} and t:sum < {1}])", sum1, sum2);
            XPathProcess(xpNav, exprs, title);
        }

        /// <summary>
        /// Выводит ФИО клиента, которому принадлежит вклад, с указанным кодом
        /// </summary>
        /// <param name="xpNav">Объект XPathNavigator</param>
        /// <param name="code">Код вклада</param>
        static void Query9(XPathNavigator xpNav, string code)
        {
            string title = string.Format("9. ФИО клиента, которому принадлежит вклад с кодом {0}:", code);
            string exprs = string.Format("t:bank/t:Client[t:debit[@id = '{0}']]/t:Name", code);
            XPathProcess(xpNav, exprs, title);
        }

        /// <summary>
        /// Выводит данные о числе кредитов, предшествующих кредиту с заданным кодом
        /// </summary>
        /// <param name="xpNav">Объект XPathNavigator</param>
        /// <param name="code">Код кредита</param>
        static void Query10(XPathNavigator xpNav, int code)
        {
            string title = string.Format("10. Число кредитов, предшествующих в документе кредиту с кодом {0}:", code);
            string exprs = string.Format("count(t:bank/t:Client/t:credit[@id < {0}])", code);
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
            Query4(xpNav, 10.0);
            Console.WriteLine();
            Query5(xpNav, "01.02.2024", 1000000);
            Console.WriteLine();
            Query6(xpNav);
            Console.WriteLine();
            Query7(xpNav);
            Console.WriteLine();
            Query8(xpNav, 100000, 10000000);
            Console.WriteLine();
            Query9(xpNav, "1");
            Console.WriteLine();
            Query10(xpNav, 3);
            Console.WriteLine();

            Console.Read();
        }
    }
}