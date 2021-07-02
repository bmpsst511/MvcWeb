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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MvcWebContext dbContext;
        private readonly IWebHostEnvironment webHostEnvironment;

        public HomeController(ILogger<HomeController> logger, MvcWebContext context, IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;
            dbContext = context;
            webHostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.banner = dbContext.Banner;
            ViewBag.midpicture_1 = dbContext.Banner.Where(x => x.bannerIndex > 10 && x.bannerIndex < 15).ToList();//banner 順序設定在這個區間是科技講座的圖
            ViewBag.midpicture_2 = dbContext.Banner.Where(x => x.bannerIndex > 15 && x.bannerIndex < 20).ToList();//banner 順序設定在這個區間是商品陳列的圖
            ViewBag.subBoards = dbContext.SubBoard.OrderBy(x => x.Sub_Index).ToList(); //子板照著設定的Index做排列塞入List
            var banners = await dbContext.Banner.ToListAsync();
            return View(banners);
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
