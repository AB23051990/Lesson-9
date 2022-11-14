using System;
using MassTransit;
using Restaurant.Messages;

namespace Restaurant.Kitchen
{
    internal class Manager
    {
        

        public Manager(IBus bus)
        {
            
        }

        public bool CheckKitchenReady(Guid orderId, Dish? dish)
        {
            return true;
        }
    }
}