using System;
using System.Collections.Generic;
using System.Text;
using WS.Core.Entites;

namespace WS.Core.Contracts.Service
{
    public interface IOrderService
    {
        void SaveOrder(Order order);

        void SetTransactionId(int orderId, string token);

        void PaymentDone(string token, int tId);
    }
}
