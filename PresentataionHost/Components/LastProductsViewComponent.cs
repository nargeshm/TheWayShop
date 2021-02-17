using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WS.Core.Contracts.Service;

namespace PresentataionHost.Components
{
    public class LastProductsViewComponent : ViewComponent
    {
        private readonly IProdctService productServic;

        public LastProductsViewComponent(IProdctService productServic)
        {
            this.productServic = productServic;
        }
        public IViewComponentResult Invoke()
        {
            var data = productServic.GetNewestProduct().Take(3).ToList();
            return View(data);
        }
    }
}
