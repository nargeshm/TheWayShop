using System;
using System.Collections.Generic;
using System.Text;
using WS.Core.Entites;

namespace WS.Core.Contracts.Repository
{
    public interface IProductRepository
    {
        Product Get(int ProductId);

        (List<Product>, int Count) GetFilterProducts(string search, string category, int pageNumber, int PageSize);

        List<Product> GetChippestProduct();
        List<Product> GetHighPriceProduct();
        List<Product> GetNewstProduct();
        List<Product> GetBestSellerProduct();
        List<Product> GetPopularProduct();

    }
}
