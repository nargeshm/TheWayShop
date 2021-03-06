using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WS.Core.Contracts.Service;
using WS.Core.Entites;

namespace PresentataionHost.Controllers
{
    public class CartController : Controller
    {
        private readonly IProdctService prodctService;
        private readonly Cart cart;

        public CartController(IProdctService prodctService, Cart cart)
        {
            this.prodctService = prodctService;
            this.cart = cart;
        }
        public IActionResult Index()
        {
            return View(cart);
        }

        public IActionResult AddToCart(int productId, int qunaity=1,string size="xl")
        {
            string referer = Request.Headers["Referer"].ToString();
            Product product = prodctService.Get(productId);
            if (product != null)
            {
                cart.AddItem(product, qunaity,size);
            }
            return Redirect(referer);
        }
        [HttpPost]
        public IActionResult RemoveLine(int ProductId)
        {
           
            string referer = Request.Headers["Referer"].ToString();
            Product product = prodctService.Get(ProductId);
            if (product != null)
            {
                cart.RemoveLine(ProductId);
            }
            return Redirect(referer);
        }

    }
}
