using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PresentataionHost.Infrastructures.Extensions;
using System;
using WS.Core.Entites;
using Newtonsoft.Json;


namespace PresentataionHost.Models
{
    public class SessionCart : Cart
    {

        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
            .HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("Cart")
            ?? new SessionCart();
            cart.Session = session;
            return cart;
        }

        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddItem(Product product, int quantity,string size)
        {
            base.AddItem(product, quantity,size);
            Session.SetJson("Cart", this);
        }
        public override void RemoveLine(int productId)
        {
            base.RemoveLine(productId);
            Session.SetJson("Cart", this);
        }
        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}
