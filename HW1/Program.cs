using System.Diagnostics;

namespace HW1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var rest = new Restaurant();
            while (true)
            {
                Console.WriteLine("Привет! Желаете забронировать столик ? \n1 - мы уведомим Вас по  смс(асинхронно)" +
                    "\n2 - подождите на линии, мы Вас оповестим (синхроннно)"); //приглашаем ко вводу
                if (!int.TryParse(Console.ReadLine(), out var choice) && choice is not (1 or 2))
                {
                    Console.WriteLine("Введите, пожалуйста 1 или 2"); //всегда нужно защититься от невалидного ввода
                }
                var stopWatch = new Stopwatch();
                stopWatch.Start();  //замерим потраченное нами время на бронирование, ведь наше время - самое дорогое что у нас есть
                if (choice == 1)
                {
                    rest.BookFreeTableAsync(1); //забранируем с ответом по смс
                }
                else
                {
                    rest.BookFreeTable(1); //забранируем по звонку
                }
                Console.WriteLine("Спасибо за Ваше	обращение!");   //клиентд всегда нужно порадовать благодарностью
                stopWatch.Stop();
                var ts = stopWatch.Elapsed;
                Console.WriteLine($"{ts.Seconds}:{ts.Milliseconds}"); //выведем	потраченное нами	время


                //Снятие брони
                Console.WriteLine("Желаете снять бронь со столика ?" +
                "\n1 - мы уведомим Вас по  смс(асинхронно)"+ "\n2 - подождите на линии, мы Вас оповестим (синхроннно)");
                if (!int.TryParse(Console.ReadLine(), out var choiceDel) && choiceDel is not (1 or 2))
                {
                    Console.WriteLine("Введите, пожалуйста 1 или 2"); 
                }
                stopWatch.Start();  //замерим потраченное нами время на бронирование, ведь наше время - самое дорогое что у нас есть
                if (choice == 1)
                {
                    rest.DelFreeTableAsync(1); //забранируем с ответом по смс
                }
                else
                {
                    rest.DelFreeTable(1); //забранируем по звонку
                }
                Console.WriteLine("Спасибо за Ваше	обращение!");   //клиентд всегда нужно порадовать благодарностью
                stopWatch.Stop();
                var tsDel = stopWatch.Elapsed;
                Console.WriteLine($"{tsDel.Seconds}:{tsDel.Milliseconds}");

            }

        }
    }
}