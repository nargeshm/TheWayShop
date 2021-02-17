using System.Collections.Generic;
using System.Linq;

namespace WS.Core.Entites
{
    public class Cart
    {
        private List<CartLine> lines = new List<CartLine>();

        public virtual void AddItem(Product product, int quantity,string size)
        {
            CartLine cartLine = GetCartLine(product.ProductID);
            if (cartLine != null)
            {
                //update
            }
            else
            {
                lines.Add(new CartLine() { Quantity = quantity, Product = product, Size=size });
            }

        }

        public virtual void RemoveLine(int productId)
        {
            lines.RemoveAll(a => a.Product.ProductID == productId);
        }

        public virtual int GetTotalPrice()
        {
            return lines.Sum(e => e.Product.Price * e.Quantity);
        }

        public virtual void Clear()
        {
            lines.Clear();
        }

        public IEnumerable<CartLine> CartLines { get => lines; }

        private CartLine GetCartLine(int productId)
        {
            return lines.FirstOrDefault(p => p.Product.ProductID == productId);
        }

    }

}
