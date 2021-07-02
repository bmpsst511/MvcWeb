using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace MvcWeb.Controllers
{
    public class ShopController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MvcWebContext dbContext;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ShopController(ILogger<HomeController> logger, MvcWebContext context, IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;
            dbContext = context;
            webHostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.subBoards = dbContext.SubBoard.OrderBy(x => x.Sub_Index).ToList(); //子板照著設定的Index做排列塞入List
            var products = await dbContext.Product.ToListAsync();
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
