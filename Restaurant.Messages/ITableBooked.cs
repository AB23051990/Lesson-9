using System;

namespace Restaurant.Messages
{
    public interface ITableBooked
    {
        public Guid OrderId { get; }   
        public bool Success { get; }
        public DateTime CreationDate { get; }
    }

    public class TableBooked : ITableBooked
    {
        public TableBooked(Guid orderId, bool success, Dish? preOrder = null)
        {
            OrderId = orderId;            
            Success = success;            
        }

        public Guid OrderId { get; }       
        public bool Success { get; }
        public DateTime CreationDate { get; }
    }
}