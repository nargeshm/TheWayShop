using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WS.Core.Contracts.Service;
using WS.Core.Entites;

namespace PresentataionHost.Components
{
    public class CartNumberViewComponent : ViewComponent
    {
        private readonly IProdctService productServic;
        private readonly Cart cart;
        public CartNumberViewComponent(IProdctService productServic, Cart cart)
        {
            this.cart = cart;
            this.productServic = productServic;
        }
      
        public async Task< IViewComponentResult> InvokeAsync()
        {
           ViewBag.cart =  cart.CartLines.Count();

            return View(cart);
        }
    }

}
