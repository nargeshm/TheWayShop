using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WS.Core.Contracts.Service;
using WS.Core.Entites;

namespace PresentataionHost.Components
{
    public class CartSideBarViewComponent : ViewComponent
    {
        private readonly IProdctService productServic;
        private readonly Cart cart;
        public CartSideBarViewComponent(IProdctService productServic, Cart cart)
        {
            this.cart = cart;
            this.productServic = productServic;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var data = productServic.GetNewestProduct().Take(3).ToList();
           // ViewBag.cart = cart;
            return View(cart);
        }
       
    }

}
