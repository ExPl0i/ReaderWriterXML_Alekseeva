namespace Laba_5
{
    /// <summary>
    /// Представляет плоский конденсатор (Адаптируемый класс)
    /// </summary>
    class f_capasitor
    {
        protected double s;     // Площадь обкладки кнденсатора
        protected double d;     // Расстояние между обкладками
        protected double eps;   // Диэлектрическая проницаемость среды между обкладками

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="s">Площадь обкладки кнденсатора</param>
        /// <param name="d">Расстояние между обкладками</param>
        /// <param name="eps">Диэлектрическая проницаемость среды между обкладками</param>
        public f_capasitor(double s, double d, double eps)
        {
            this.s = s;
            this.d = d;
            this.eps = eps;
        }

        /// <summary>
        /// Конструктор по умолчанию (на основе парам. конструктора)
        /// </summary>
        public f_capasitor()
            : this(2.0, 0.9, 1.0) { }

        /// <summary>
        /// Возвращает и устанавливает текущую площадь обкладки
        /// </summary>
        public double CurrentS
        {
            get
            { return s; }
            set 
            { s = value; }
        }

        /// <summary>
        /// Определяет емкость конденсатора
        /// </summary>
        /// <returns>Емкость конденсатора</returns>
        public double Capacity()
        {
            return (eps * (0.00000000000885) * s) / (d);
        }

        /// <summary>
        /// Возвращает значение заряда на обкладках конденсатора при известном напряжении u
        /// </summary>
        /// <param name="u">Напряжение конденсатора</param>
        /// <returns>Значение заряда на обкладках конденсатора</returns>
        public double GetCharge(int u)
        {
            return Capacity() / u;
        }

        /// <summary>
        /// Возвращает данные о конденсаторе
        /// </summary>
        /// <returns>Данные о конденсаторе</returns>
        public override string ToString()
        {
            return string.Format("Данные о плоском конденсаторе:\n площадь обкладки: {0}\n расстояние между обкладками: {1}\n диэлектрическая проницаемость среды между обкладками: {2}\n емкость: {3}", s, d, eps, Capacity());
        }
    }

    /// <summary>
    /// Целевой интерфейс
    /// </summary>
    public interface ITarget
    {
        /// <summary>
        /// Возвращает текущую площадь обкладки конеденсатора
        /// </summary>
        double CurrentS { get; }

        /// <summary>
        /// Изменяет площадь обкладок конденсатора на величину dS
        /// </summary>
        /// <param name="dS">Изменение площади обкладок конденсатора</param>
        void ModifS(double dS);

        /// <summary>
        /// Определяет электрическую энергию конденсатора при известном напряжении u между обкладками
        /// </summary>
        /// <param name="u">Напряжение между обкладками</param>
        /// <returns>Электрическую энергию конденсатора</returns>
        double CalculateW(int u);

        /// <summary>
        /// Возвращает строку с данными об объекте
        /// </summary>
        /// <returns>Данные об объекте</returns>
        string GetData();
    }


    public class CapacitorObjAdapter : ITarget
    {
        f_capasitor capasitor;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public CapacitorObjAdapter()
        {
            capasitor = new f_capasitor();
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="s">Площадь обкладки кнденсатора</param>
        /// <param name="d">Расстояние между обкладками</param>
        /// <param name="eps">Диэлектрическая проницаемость среды между обкладками</param>
        public CapacitorObjAdapter(double  s, double d, double eps)
        {
            capasitor = new f_capasitor(s, d, eps);
        }

        /// <summary>
        /// Возвращает текущую площадь обкладки кнденсатора
        /// </summary>
        public double CurrentS
        {
            get
            { return capasitor.CurrentS; }
        }

        /// <summary>
        /// Изменить площадь обкладки кнденсатора на величину dS
        /// </summary>
        /// <param name="dS"></param>
        public void ModifS(double dS)
        {
            capasitor.CurrentS += dS;
        }

        /// <summary>
        /// Определяет электрическую энергию конденсатора при известном напряжении u между обкладками
        /// </summary>
        /// <param name="u">Напряжение между обкладками</param>
        /// <returns>Электрическую энергию конденсатора</returns>
        public double CalculateW(int u)
        {
            return (capasitor.GetCharge(u) * u)/2;
        }

        /// <summary>
        /// Возвращает строку с данными об объекте
        /// </summary>
        /// <returns>Данные об объекте</returns>
        public string GetData()
        {
            return capasitor.ToString();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Работа с шаблоном проектирования Адаптер";

            const string OA = "* Адаптер объектов *\n";

            ITarget objAdapter = GetObjectAdapter();

            Console.WriteLine(OA + objAdapter.GetData());
            Console.WriteLine();

            Console.WriteLine("Введите значение напряжения на конденсаторе:");
            int u = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine(OA + "Электрическая энергия конденсатора при напряжении {0}: {1}\n", u, objAdapter.CalculateW(u));

            Console.WriteLine("Введите значение на которое измениться площадь обкладки конденсатора");
            double dS = double.Parse(Console.ReadLine());
            objAdapter.ModifS(dS);

            Console.WriteLine(OA + "Текущая площадь обкладки кнденсатора: {0}", objAdapter.CurrentS);

            Console.WriteLine(OA + objAdapter.GetData());
            Console.WriteLine(OA + "Электрическая энергия конденсатора при напряжении {0}: {1}\n", u, objAdapter.CalculateW(u));

            Console.Read();

        }

        /// <summary>
        /// Возвращает ссылку на адаптер объектов
        /// </summary>
        /// <returns>Адаптер объектов</returns>
        static ITarget GetObjectAdapter()
        {
            ITarget objAdapter = new CapacitorObjAdapter();

            return objAdapter;
        }
    }
}
