using System.Xml.Serialization;
using System.Xml;

namespace ClassLib_laba3
{
    // Предсставляет банковский вклад
    [Serializable]
    public class Debit
    {
        /// <summary>
        /// Номер счета
        /// </summary>
        [XmlAnyAttribute]
        public string Number { get; set; }

        /// <summary>
        /// Имя вкладчика
        /// </summary>
        public string NameOwner { get; set; }

        /// <summary>
        /// Дата вклада
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Сумма вклада
        /// </summary>
        public double Sum { get; set; }

        /// <summary>
        /// Процент по вкладу
        /// </summary>
        public double Procent { get; set; }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Debit()
        {
            Number = "40203960500000004623";
            NameOwner = "Белкин Михаил Игоревич";
            Date = "02.02.2024";
            Sum = 1000000;
            Procent = 7.6;
        }

        /// <summary>
        /// Возвращает строку с данынми о банковском вкладе
        /// </summary>
        /// <returns>Данные о банковском вкладе</returns>
        public override string ToString()
        {
            return (string.Format("Данные о банковском вкладе:\n" +
                                  "* Номер вклада: {0}\n" +
                                  "* ФИО вкладчика: {1}\n" +
                                  "* Дата вклада: {2}\n" +
                                  "* Сумма вклада: {3}\n" +
                                  "* Процент по вкладу: {4}\n", Number, NameOwner, Date, Sum, Procent));
        }
    }

    /// <summary>
    /// Представляет объект для доступа к XML-данным
    /// об экземплярах класса Debit
    /// </summary>
    public static class DebitXmlDataProvider
    {
        // Объект для XML-сериализации и десериализации
        static XmlSerializer xmlSzr = new XmlSerializer(typeof(Debit));

        /// <summary>
        /// Сохраняет объект класса Person в XML-файл
        /// </summary>
        /// <param name="uri">URI XML-файла</param>
        /// <param name="debit">Объект класса Debit</param>
        public static void SaveDebitObject(string uri, Debit debit)
        {
            // Объект с настройками для XmlWriter
            XmlWriterSettings xmlWrS = new XmlWriterSettings();
            xmlWrS.Indent = true; // Задаем отступ для XML-элементов
            // Объект для записи XML-файлов
            XmlWriter xmlWrt = XmlWriter.Create(uri, xmlWrS);
            // Сериализуем объект debit в XML
            xmlSzr.Serialize(xmlWrt, debit);
            xmlWrt.Close(); // Закрываем поток данных для xmlWrt
        }

        /// <summary>
        /// Загружает объект класса Debit из XML-файла
        /// </summary>
        /// <param name="uri"></param>
        /// <returns>URI XML-файла</returns>
        public static Debit LoadDebitObject(string uri)
        {
            // Объект с настройками для XmlReader
            XmlReaderSettings xmlRdS = new XmlReaderSettings();
            // Объект для чтения XML-файлов
            XmlReader xmlRdr = XmlReader.Create(uri, xmlRdS);
            // Десериализуем объект типа Debit
            Debit debit = xmlSzr.Deserialize(xmlRdr) as Debit;
            // Закрываем поток данных для xmlRdr
            xmlRdr.Close();
            return debit;
        }

        /// <summary>
        /// Возвращает код XML-файла в виде строки
        /// </summary>
        /// <param name="xmlFileName">Имя XML-файла</param>
        /// <returns>Строка с кодом XML-файла</returns>
        public static string GetXmlCode(string xmlFileName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFileName);
            return xmlDoc.InnerXml;
        }
    }


    public static class XmlDataProvider<T>
        where T : class, new()
    {
        // Объект для XML-сериализации и десериализации
        static XmlSerializer xmlSzr = new XmlSerializer(typeof(T));

        /// <summary>
        /// Сохраняет объект в XML-файл
        /// </summary>
        /// <param name="uri">URI XML-файл</param>
        /// <param name="obj">Объект</param>
        public static void SaveObject(string uri, T obj)
        {
            XmlWriterSettings xmlWrS = new XmlWriterSettings();
            xmlWrS.Indent = true;
            XmlWriter xmlWrt = XmlWriter.Create(uri, xmlWrS);
            xmlSzr.Serialize(xmlWrt, obj);
            xmlWrt.Close();
        }

        /// <summary>
        /// Загружает объект из XML-файла
        /// </summary>
        /// <param name="uri">URI XML-файла</param>
        /// <returns>Объект</returns>
        public static T LoadObject(string uri)
        {
            XmlReaderSettings xmlRdS = new XmlReaderSettings();
            XmlReader xmlRdr = XmlReader.Create(uri, xmlRdS);
            T obj = xmlSzr.Deserialize(xmlRdr) as T;
            xmlRdr.Close();
            return obj;
        }
    }


    public static class DebitBinDataProvider
    {
        // Объект для сериализации/десериализации в двоичном формате
        //static BinaryFormatter binFormat = new BinaryFormatter();
    }


    public static class DebitSoapDataProvideer
    {
        //static SoapFormatter 
    }
}
