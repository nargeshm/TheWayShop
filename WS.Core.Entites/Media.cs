namespace WS.Core.Entites
{
    public class Media
    {
        public int MediaId { get; set; }
        public string Path { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
