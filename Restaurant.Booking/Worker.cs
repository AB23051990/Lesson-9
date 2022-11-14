using System;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Hosting;
using Restaurant.Messages;

namespace Restaurant.Booking
{
    public class Worker : BackgroundService
    {
        private readonly IBus _bus;
        //private readonly Restaurant _restaurant;

        public Worker(IBus bus, Restaurant restaurant)
        {
            _bus = bus;
            //_restaurant = restaurant;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var s = "Hello world";

            Console.WriteLine(s[^4] + s[3..5] + s[^8..^6]);

            //var a = new HashSet<Guid>();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(10000, stoppingToken);
                Console.WriteLine("Привет! Желаете забронировать столик?");
                var b = Guid.NewGuid();

                var dateTime = DateTime.Now;
                
                await _bus.Publish(new BookingRequest(b, Guid.NewGuid(), null, dateTime),
                    stoppingToken);
                //await Task.Delay(1000000, stoppingToken);
            }
        }
    }
}