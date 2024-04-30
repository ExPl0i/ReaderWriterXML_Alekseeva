using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Xml;

namespace Samost_4Form.NET
{

    public partial class Form1 : Form
    {
        List<Debit> debits;
        string xmlFileUri;

        public Form1()
        {
            InitializeComponent();
            debits = new List<Debit>();
            xmlFileUri = @"C:\Users\mripo\Source\Repos\ExPl0i\ReaderWriterXML_Alekseeva\XML\Samost_4.xml";

        }


        private void BindDebits()
        {
            
        }
    }

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
    /// Представляет объект для доступа к XML-данным (обобщенный класс)
    /// </summary>
    /// <typeparam name="T"></typeparam>
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
            // Объект с настройками для XmlWriter
            XmlWriterSettings xmlWrS = new XmlWriterSettings();
            xmlWrS.Indent = true;// Задаем отступ для XML-элементов
            // Объект для записи XML-файлов
            XmlWriter xmlWrt = XmlWriter.Create(uri, xmlWrS);
            // Сериализуем объект в XML
            xmlSzr.Serialize(xmlWrt, obj);
            xmlWrt.Close();// Закрываем поток данных для xmlWrt
        }

        /// <summary>
        /// Загружает объект из XML-файла
        /// </summary>
        /// <param name="uri">URI XML-файла</param>
        /// <returns>Объект</returns>
        public static T LoadObject(string uri)
        {
            // Объект с настройками для XmlReader
            XmlReaderSettings xmlRdS = new XmlReaderSettings();
            // Объект для чтения XML-файлов
            XmlReader xmlRdr = XmlReader.Create(uri, xmlRdS);
            // Десериализуем обект
            T obj = xmlSzr.Deserialize(xmlRdr) as T;
            // Закрываем поток данных для xmlRdr
            xmlRdr.Close();
            return obj;
        }
    }
}
