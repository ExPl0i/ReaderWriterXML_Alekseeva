using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace Samost_4._2Lib
{
    /// <summary>
    /// Представляет станки
    /// </summary>
    public class Machine
    {
        /// <summary>
        /// Идентификационный номер
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Модель
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Дата выпуска
        /// </summary>
        public string CreateDate { get; set; }

        /// <summary>
        /// Износ
        /// </summary>
        public int Wear {  get; set; }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Machine()
        {
            ID = "AAA-000000";
            Name = "Токарный станок";
            Model = "AA-0000";
            CreateDate = "01.01.2000";
            Wear = 0;
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="id">Идентификационный номер</param>
        /// <param name="name">Название</param>
        /// <param name="model">Модель</param>
        public Machine(string id, string name, string model, string createDate, int wear)
        {
            ID = id;
            Name = name;
            Model = model;
            CreateDate = createDate;
            Wear = wear;
        }

        /// <summary>
        /// Возвращает строку с данными о станке
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Данные о станке:\n номер: {0}\n наименование: {1}\n модель: {2}\n дата выпуска: {3}\n износ: {4}", ID, Name, Model, CreateDate, Wear);
        }
    }

    /// <summary>
    /// Предстваляет цеха
    /// </summary>
    public class Workshop
    {
        /// <summary>
        /// Идентификационный номер
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список станков
        /// </summary>
        public List<Machine> Machines { get; set; }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Workshop()
        {
            ID = "AAA-00";
            Name = "Слесарный";
            Machines = new List<Machine>();
        }

        /// <summary>
        /// Коструктор с параметрами
        /// </summary>
        /// <param name="id">Индентификационный номер</param>
        /// <param name="name">Название</param>
        /// <param name="workers">Список рабочих</param>
        /// <param name="machines">Список станков</param>
        public Workshop(string id, string name)
        {
            ID = id;
            Name = name;
            Machines = new List<Machine>();
        }

        /// <summary>
        /// Возвращает строку с данными о цехе
        /// </summary>
        /// <returns>Строка с данынми о цехе</returns>
        public override string ToString()
        {
            return string.Format("Данные о цехе:\n номер: {0}\n наименование: {1}\n число станков: {2}", ID, Name, Machines.Count);
        }

        /// <summary>
        /// Добавить нового рабочего в цех
        /// </summary>
        /// <param name="id">Код</param>
        /// <param name="name">ФИО</param>
        /// <param name="spec">Специальность</param>
        /// <param name="grade">Разряд</param>
        /// <param name="salary">Зарплата</param>
        /// <param name="countMachine">Количество станков</param>
        public void AddNewWorker(string id, string name, string model, string createDate, int wear)
        {
            Machine newMachine = new Machine()
            {
                ID = id,
                Name = name,
                Model = model,
                CreateDate = createDate,
                Wear = wear,
            };
            Machines.Add(newMachine);
        }

        /// <summary>
        /// Удалить рабочего с выбранным номером
        /// </summary>
        /// <param name="index">Номер рабочего</param>
        public void RemoveWorker(int index)
        {
            Machines.RemoveAt(index);
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
