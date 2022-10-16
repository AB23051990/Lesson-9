
using System.Collections.Generic;

namespace HW1
{
    public class Restaurant
    {
        private readonly List<Table> _tables = new();
        
        public Restaurant()
        {
            for (ushort i = 1; i <= 10; i++)
            {
                _tables.Add(new Table(i));
            }
        }

        public void BookFreeTable(int countOfPersons)
        {
            Console.WriteLine("Добрый день! Подождите секунду я подберу столик и подтвержу вашу бронь, оставайтесь на линии");
            var table = _tables.FirstOrDefault(t => t.SeatsCount > countOfPersons && t.State == State.Free);
            Thread.Sleep(millisecondsTimeout: 1000 * 5); //у нас нерасторопные менеджеры, 5 секунд они находятся в поисках стола
            Console.WriteLine(table is null
                ? $"K сожалению, сейчас все столики занять!"
                : $"ГOTОBО! Ваш столик номер {table.Id}");
        }
        
        public void BookFreeTableAsync(int countOfPersons)
        {
            Console.WriteLine("Добрый день! Подождите секунду я подберу столик и подтвержу вашу бронь, Вам придет уведомление");
            Task.Run(async () =>
            {
                var table = _tables.FirstOrDefault(t => t.SeatsCount > countOfPersons && t.State == State.Free);
                await Task.Delay(1000 * 5); //у нас нерасторопные менеджеры, 5 секунд они находятся в поисках стола
                table?.SetState(State.Booked);
                Console.WriteLine(table is null
                    ? $"УВЕДОМЛЕН И : К сожалению, сейчас все столики заняты"
                    : $"УВЕДОМЛЕНИЕ: Готово! Ваш столик номер {table.Id}");
            });
        }
        
        public void DelFreeTable(int countOfPersons)
        {
            Console.WriteLine("Добрый день! Подождите секунду я сниму вашу бронь, оставайтесь на линии");
            var table = _tables.FirstOrDefault(t => t.SeatsCount > countOfPersons && t.State == State.Free);// не получается удалить из списка Remove, не знаю что нужно писать
            Thread.Sleep(millisecondsTimeout: 1000 * 5); 
            Console.WriteLine($"ГOTОBО! Ваша бронь снята {table.Id}");
        }
        public void DelFreeTableAsync(int countOfPersons)
        {
            Console.WriteLine("Добрый день! Подождите секунду я сниму вашу бронь, Вам придет уведомление");
            Task.Run(async () =>
            {
                var table = _tables.FirstOrDefault(t => t.SeatsCount > countOfPersons && t.State == State.Free); // не получается удалить из списка Remove, не знаю что нужно писать
                await Task.Delay(1000 * 5); 
                table?.SetState(State.Booked);
                Console.WriteLine($"ГOTОBО! Ваша бронь снята {table.Id}");
            });
        }
    }
}
