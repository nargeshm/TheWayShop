using System;
using System.Collections.Generic;
using System.Text;
using WS.Core.Entites;

namespace WS.Core.Contracts.Repository
{
    public interface IOrderRepository
    {
        void Save(Order order);
        void SetOrderToken(int orderId, string token);
        void PaymentDone(string token, int tId);
    }
}
