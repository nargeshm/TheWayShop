using Microsoft.AspNetCore.Mvc;
using PresentataionHost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WS.Core.Contracts.Pay;
using WS.Core.Contracts.Service;
using WS.Core.Entites;

namespace PresentataionHost.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IPayment payment;

        public PaymentController(IOrderService orderService, IPayment payment)
        {
            this.payment = payment;
            this.orderService = orderService;
        }
        public IActionResult Pay(int orderId, int totalPrice)
        {
            var result = payment.pay(totalPrice.ToString());
            if (result.Status == 1)
            {
                orderService.SetTransactionId(orderId, result.Token);
                return Redirect("https://pay.ir/pg/" + result.Token);
            }
            return View();
        }

        public IActionResult Verify(PaymentResponseViewModel model)
        {
        
            if (model.status == 1)
            {
                VerifyPayment verifyResult = payment.Verify(model.token.ToString());
                if (verifyResult.Status == 1)
                {
                    orderService.PaymentDone(model.token, verifyResult.transId);
                    ViewBag.result = "پرداخت با موفقیت انجام شد ";
                    ViewBag.transId = verifyResult.transId;
                    //return View(model);
                }
                else if (verifyResult.Status == -5)
                {
                    ViewBag.result = "تراکنش با خطا مواجه شده است ";
                    ViewBag.transId = verifyResult.transId;
                }
                else
                {
                    
                    ViewBag.result = "پرداخت نا موفق بود  ";
                    ViewBag.transId= verifyResult.transId;
                }

            }
           
            return View(model);
        }
    }
}
