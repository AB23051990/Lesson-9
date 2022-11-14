using MassTransit;
using Microsoft.Extensions.Logging;
using Restaurant.Messages;
using Restaurant.Messages.InMemoryDb;

namespace Restaurant.Booking.Consumers
{
    public class RestaurantBookingRequestConsumer : IConsumer<IBookingRequest>
    {
        private readonly ILogger _logger;
        private readonly Restaurant _restaurant;
        private readonly IInMemoryRepository<IBookingRequest> _repository;
        public RestaurantBookingRequestConsumer(Restaurant restaurant, IInMemoryRepository<IBookingRequest> repository, ILogger<RestaurantBookingRequestConsumer> logger)
        {
            _restaurant = restaurant;
            _repository = repository;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<IBookingRequest> context)
        {
            _logger.Log(LogLevel.Information, $"[OrderId: {context.Message.OrderId}]");
            var savedMessage = _repository.Get()
            .FirstOrDefault(m => m.OrderId == context.Message.OrderId);
            if (savedMessage is null)
            {
                _logger.Log(LogLevel.Debug, "First time message");
                _repository.AddOrUpdate(context.Message);
                var result = await _restaurant.BookFreeTableAsync(1);
                await context.Publish<ITableBooked>(new TableBooked(context.Message.OrderId, result ?? false));
                return;
            }

            _logger.Log(LogLevel.Debug, "Second time message");

            /*
            var model = _repository.Get().FirstOrDefault(i => i.OrderId == context.Message.OrderId);
            
            if (model is not null && model.CheckMessageId(context.MessageId.ToString()))
            {
                Console.WriteLine(context.MessageId.ToString());
                Console.WriteLine("Second time");
                return;
            }
            var requestModel = new BookingRequestModel(context.Message.OrderId, context.Message.ClientId,
            context.Message.PreOrder, context.Message.CreationDate, context.MessageId.ToString());

            Console.WriteLine(context.MessageId.ToString());
            Console.WriteLine("First time");
            var resultModel = model?.Update(requestModel, context.MessageId.ToString()) ?? requestModel;
            
            _repository.AddOrUpdate(resultModel);
            var result = await _restaurant.BookFreeTableAsync(1);
            await context.Publish<ITableBooked>(new TableBooked(context.Message.OrderId, result ?? false));
            */

        }
    }
}