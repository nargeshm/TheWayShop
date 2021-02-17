
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PresentataionHost.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
            return View();
        }
        [HttpPost]
        public IActionResult Index(string q)
        {
            List<Product> result = new List<Product>();
            ViewBag.q = q;
            if (q=="")
            {
                
            }
            else if (q=="")
            {

            }
            else
            {
                    
            }

            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        //go to list of product
        public IActionResult Shop()
        {
            
            return View(ProductService.GetNewestProduct().Take(9).ToList());
        }
        //see this page:  
    // https://www.aspsnippets.com/Articles/MVC-Partial-View-String-Render-Return-Partial-View-as-String-from-Controller-in-ASPNet-MVC.aspx
         
        //for filter product in shop page:
        [HttpPost]
        public ContentResult Shop(string q)
        {
            List<Product> result = new List<Product>();
            if (q == "BestSelling")
            {
                result = ProductService.GetBestSellerProduct().ToList();
            }
            else if (q == "Popularity")
            {
                result = ProductService.GetPopularProduct().ToList();
            }
            else if (q == "Low")
            {
                result = ProductService.GetChippestProduct().ToList();
            }
            else if (q == "High")
            {
                result = ProductService.GetHighPriceProduct().ToList();
            }

            else
            {
                result = ProductService.GetNewestProduct().ToList();
            }
            string format = "";
            foreach (var item in result)
            {
                string images = $"/images/{ item.Medias[0].Path as string}";
                string src = $"/Home/Detail/?id={item.ProductID}";

                format += $" <div class={"col - sm - 6 col - md - 6 col - lg - 4 col - xl - 4"}>" +
                      $"< div class={"products-single fix"}>" +
                      $"<div class={"box-img-hover"}>" +
                      $"<div class={"type-lb"}>< p class={"sale"}>Sale</p></div>" +
                      $"< img src = { images} class={"img-fluid"} alt={"Image"}>" +
                      $"<div class={"mask-icon"}>" +
                      $"<ul><li><a href = {src} data-toggle={"tooltip"} " +
                      $"data-placement={"right"} title={"View"}>" +
                      $"<i class={"fas fa-eye"}></i></a></li>" +
                      $"< li >< a href = {"#"} data-toggle={ "tooltip"} data-placement={"right"} title={"Compare"}>" +
                      $"<i class={"fas fa-sync-alt"}></i></a></li><li>" +
                      $"<a href = {"#"} data-toggle={"tooltip"} data-placement={"right"} title={"Add to Wishlist"}><i class={"far fa-heart"}>" +
                      $"</i></a></li></ul><a class={"cart"} href={"#"}>Add to Cart</a></div></div>" +
                      $"<div class={"why-text"}><h4>{item.Description}</h4><h5> ${item.Price}</h5></div></div></div>";


            }
            //ViewBag.data = $"@(Component.Invoke({"LastProducts"}))";
            return Content(format);
        }
 //see this!!!https://www.c-sharpcorner.com/article/different-ways-of-render-partial-view-in-mvc/
        
            //show detail of Product:
            public IActionResult Detail(int id)
             {
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
