using System;
using System.Collections.Generic;
using System.Text;
using WS.Core.Entites;

namespace WS.Core.Contracts.Service
{
    public interface IProdctService
    {
        Product Get(int ProductId);
        (List<Product>, int) ProductSearch(string q, string category, int pageNumber, int PageSize);

        List<Product> GetChippestProduct();
        List<Product> GetHighPriceProduct();
        List<Product> GetNewestProduct();
        List<Product> GetBestSellerProduct();
        List<Product> GetPopularProduct();


    }
}
