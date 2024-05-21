namespace Laba_6
{
    /// <summary>
    /// Представляет банковский вклад
    /// </summary>
    public class Debit
    {
        /// <summary>
        /// Номер счета
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Баланс
        /// </summary>
        public double Balance { get; set; }

        /// <summary>
        /// Тип валюты
        /// </summary>
        public string CurrencyType { get; set; }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Debit()
        {
            Number = "000000000";
            Balance = 0;
            CurrencyType = "Рубли";
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="number">Номер счета</param>
        /// <param name="balance">Баланс</param>
        /// <param name="currencyType">Тип валюты</param>
        public Debit(string number, double balance, string currencyType)
        {
            Number = number;
            Balance = balance;
            CurrencyType = currencyType;
        }
        
        /// <summary>
        /// Метод для пополнения счета
        /// </summary>
        /// <param name="sum">Сумма пополнения</param>
        public void Deposit(double sum)
        {
            if (sum < 0)
            {
                Console.WriteLine("Сумма для пополнения баланса не может быть отрицательной");
            }
            else
            {
                Balance += sum;
                Console.WriteLine("Баланс успешно пополнен!\n Текущий баланс: {0}", Balance);
            }
        }

        /// <summary>
        /// Метод для снятия денег со счета
        /// </summary>
        /// <param name="sum">Сумма снятия</param>
        public void Withdraw(double sum)
        {
            if (Balance >=sum)
            {
                Balance -= sum;
                Console.WriteLine("Деньги успешно сняты!\n Текущий баланс: {0}", Balance);
            }
            else
            {
                Console.WriteLine("Недостаточно средств для снятия!");
            }
        }

        /// <summary>
        /// Метод для изменения типа валюты
        /// </summary>
        /// <param name="currencyType">Новый тип валюты</param>
        public void ChangeCurrencyType(string currencyType)
        {
            if (Balance != 0)
            {
                Console.WriteLine("Для изменения типа валюты необходимо снять все деньги со счета!");
            }
            else
            {
                CurrencyType = currencyType;
                Console.WriteLine("Тип валюты счета успешно изменен! Текущая валюта {0}", CurrencyType);
            }
        }

        /// <summary>
        /// Метод для получения информации о счете
        /// </summary>
        /// <returns>Данные о счете</returns>
        public override string ToString()
        {
            return string.Format("Данные о счете:\n номер счета: {0}\n баланс: {1}\n тип валюты: {2}", Number, Balance, CurrencyType);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер счета:");
            string number = Console.ReadLine();
            Console.WriteLine("Введите тип валюты для счета: ");
            string currencyType = Console.ReadLine();
            
            Debit debit = new Debit(number, 0, currencyType);
            Console.WriteLine();
            GameExample(debit);
        }

        /// <summary>
        /// Метод позволяет взаимодействовать с экземпляром класса Debit
        /// </summary>
        /// <param name="account">Экземпляр класса Debit</param>
        /// <exception cref="amount">Сумма должна иметь тип double</exception>
        public static void GameExample(Debit debit)
        {
            try
            {
                bool game = true;
                while (game)
                {
                    Console.WriteLine("Выберите действие: " +
                        "\n 1 - Пополнить баланс;" +
                        "\n 2 - Снять деньги со счета;" +
                        "\n 3 - Показать информацию о счета." +
                        "\n 4 - Изменить валюту." +
                        "\n 5 - Выйти из программы.");
                    string input = Console.ReadLine();
                    double amount;
                    switch (input)
                    {
                        case "1":
                            Console.WriteLine();
                            Console.WriteLine("Выберите сумму пополнения:");
                            amount = double.Parse(Console.ReadLine());
                            debit.Deposit(amount);
                            Console.WriteLine();
                            break;
                        case "2":
                            Console.WriteLine();
                            Console.WriteLine("Выберите сумму снятия:");
                            amount = double.Parse(Console.ReadLine());
                            debit.Withdraw(amount);
                            Console.WriteLine();
                            break;
                        case "3":
                            Console.WriteLine();
                            Console.WriteLine(debit.ToString());
                            Console.WriteLine();
                            break;
                        case "4":
                            Console.WriteLine();
                            Console.WriteLine("Выберите новую валюту счета:");
                            debit.ChangeCurrencyType(Console.ReadLine());
                            Console.WriteLine();
                            break;
                        case "5":
                            game = false;
                            break;
                        default:
                            Console.WriteLine();
                            Console.WriteLine("Выбрано действие, которого нет в списке!");
                            break;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Сумма пополнения/ снятия должна представлять собой число!");
            }

        }
    }
}
