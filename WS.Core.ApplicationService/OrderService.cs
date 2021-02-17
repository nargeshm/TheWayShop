using System;
using WS.Core.Contracts.Repository;
using WS.Core.Contracts.Service;
using WS.Core.Entites;

namespace WS.Core.ApplicationService
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }



        public void PaymentDone(string token, int tId)
        {
            orderRepository.PaymentDone(token, tId);
        }

        public void SaveOrder(Order order)
        {
            orderRepository.Save(order);
        }

        public void SetTransactionId(int orderId, string token)
        {
            orderRepository.SetOrderToken(orderId, token);
        }
    }
}
