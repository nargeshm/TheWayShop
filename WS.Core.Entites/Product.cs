using System;
using System.Collections.Generic;

namespace WS.Core.Entites
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ToFind { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Media> Medias { get; set; }
        public Status Stock { get; set; }
        public int Likes { get; set; }
        public int Qty { get; set; }
        public int SellerCount { get; set; }
        public DateTime InseretTime { get; set; }
    }
    public enum Status
    {
        In_Stock,
        Out_Of_Stock,
        coming_soon,
        discontinued
    }
}
