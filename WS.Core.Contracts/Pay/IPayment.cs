using System;
using System.Collections.Generic;
using System.Text;
using WS.Core.Entites;

namespace WS.Core.Contracts.Pay
{
    public interface IPayment
    {
        PaymentResult pay(string price);
        VerifyPayment Verify(string transactonID);
    }
}
