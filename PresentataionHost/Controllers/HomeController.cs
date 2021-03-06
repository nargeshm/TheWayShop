
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PresentataionHost.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WS.Core.Contracts.Service;
using WS.Core.Entites;
using WS.Infrastruture.Sql;

namespace PresentataionHost.Controllers
{
    public class HomeController : Controller
    {

        private readonly IProdctService ProductService;
        private readonly DemoContext ctx;

        public HomeController(IProdctService ProductService, DemoContext ctx)
        {
            this.ProductService = ProductService;
            this.ctx = ctx;
        }
        public IActionResult Index()
        {
            ViewBag.best = ProductService.GetBestSellerProduct().Take(4).ToList();
            ViewBag.top = ProductService.GetPopularProduct().Take(4).ToList();
            return View(ProductService.GetNewestProduct().Take(4).ToList());
        }
       

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Shop()
        {

            return View(ProductService.GetNewestProduct().Take(9).ToList());
        }
        //see this page:  
        // https://www.aspsnippets.com/Articles/MVC-Partial-View-String-Render-Return-Partial-View-as-String-from-Controller-in-ASPNet-MVC.aspx

        //for filter product in shop page:
        [HttpPost]
        public IActionResult Shop(string q)
        {
            List<Product> result = new List<Product>();
            if (q == "BestSelling")
            {
                result = ProductService.GetBestSellerProduct().Take(9).ToList();
            }
            else if (q == "Popularity")
            {
                result = ProductService.GetPopularProduct().Take(9).ToList();
            }
            else if (q == "Low")
            {
                result = ProductService.GetChippestProduct().Take(9).ToList();
            }
            else if (q == "High")
            {
                result = ProductService.GetHighPriceProduct().Take(9).ToList();
            }

            else
            {
                result = ProductService.GetNewestProduct().Take(9).ToList();
            }

            ////ViewBag.data = $"@(Component.Invoke({"LastProducts"}))";
            return View(result);
        }
        //see this!!!https://www.c-sharpcorner.com/article/different-ways-of-render-partial-view-in-mvc/

        //show detail of Product:
        public IActionResult Detail(int id)
        {
            ViewBag.top = ProductService.GetPopularProduct().Take(12).ToList();
            return View(ProductService.Get(id));

        }


        /* return  Product by category */
        public IActionResult Product(string Category)
        {
            ViewBag.name = Category;
            var CategoryN = ctx.Categories.Single(a => a.CategoryName == Category);
            var ProductContext = ctx.Entry(CategoryN).Collection(b => b.Products)
                .Query().Include(b => b.Medias);
            return View(ProductContext.ToList());
        }

        //for search news:
        public IActionResult Search()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult Search(string q, int page = 1)
        //{

        //    string format = "";


        //    var data = ProductService.ProductSearch(q, page, 4);
        //    foreach (var item in data)
        //    {
        //        string images = $"/images/{ item.Medias[0].Path as string}";
        //        string src = $"/Home/Detail/?little={item.LitleTitle}";

        //        format += $"<hr /><ul class={"row - popular"}> <section class={"popular - text"}><p><a href={src}>{item.NewsTitle}</a></p><li><img src={images}  style = {"border:1px;height:100px;width:120px"} /><p style = {"height:50px;width:830px"}><a href={src}>{item.NewsReleasetime} ... {item.NewsSummary}</a></p></li></section></ul><hr />";


        //    }
        //    return Content(format);
        //}
        //public IActionResult Search(int page = 1, string category = "All", string q = "")
        //{
        //    var data = ProductService.ProductSearch(q, category, page, 4);
        //    PagedList<Product> pageList = new PagedList<Product>(data.Item1, page, 4, data.Item2);
        //    ViewBag.category = category;
        //    ViewBag.q = q;

        //    return View(pageList);
        //}
        //public IActionResult SearchByTitle(string q, int page = 1)
        //{
        //    var data = newsService.NewsSearch(q, page, 4);

        //    return View(data);
        //}




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
