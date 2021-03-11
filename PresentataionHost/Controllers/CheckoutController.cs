using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WS.Core.Contracts.Service;
using WS.Core.Entites;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace PresentataionHost.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly Cart cart;
        private readonly IOrderService orderService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        // omitted for clarity
      
        public CheckoutController(Cart cart, IOrderService orderService, IHttpContextAccessor httpContextAccessor)
        {
            this.cart = cart;
            this.orderService = orderService;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.id= _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            }
            ViewBag.cart = cart;
            return View(new Order());
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Index(Order order)
        {
            var totalPice = cart.GetTotalPrice();
            if (cart.CartLines.Count() == 0)
            {
                ModelState.AddModelError("", "there is no more order!");
            }

            if (ModelState.IsValid)
            {
                order.Lines = cart.CartLines.ToList();
                orderService.SaveOrder(order);
                cart.Clear();
                return RedirectToAction("Pay", "Payment", new { orderId = order.OrderID, totalPrice = totalPice });
            }
            return View(order);
        }
    }
}
