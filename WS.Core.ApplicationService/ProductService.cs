using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WS.Core.Contracts.Repository;
using WS.Core.Contracts.Service;
using WS.Core.Entites;

namespace WS.Core.ApplicationService
{
    public class ProductService : IProdctService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        //1)get the Chippest  product
        public List<Product> GetChippestProduct()
        {
            return productRepository.GetChippestProduct()
                 .Take(6).ToList();
        }
        public List<Product> GetHighPriceProduct()
        {
            return productRepository.GetHighPriceProduct()
                 .Take(6).ToList();
        }
        //2)get the Newest  product
        public List<Product> GetNewestProduct()
        {
            return productRepository.GetNewstProduct();
        }
        //3)get the highest seller product
        public List<Product> GetBestSellerProduct()
        {
            return productRepository.GetBestSellerProduct();
        }
          public List<Product> GetPopularProduct()
        {
            return productRepository.GetPopularProduct();
        }

        public (List<Product>, int) ProductSearch(string q, string category, int pageNumber, int PageSize)
        {
            return productRepository.GetFilterProducts(q, category, pageNumber, PageSize);
        }

        //4)get all  product
        public Product Get(int ProductId)
        {
            return productRepository.Get(ProductId);
        }
    }
}
