namespace WS.Core.Entites
{
    public class CartLine
    {
        public int CartLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public string Size { get; set; }
    }
}
