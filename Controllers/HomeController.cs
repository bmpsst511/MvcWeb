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

namespace LMcomposite.Controllers
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
            ViewBag.banner1 = dbContext.Banner.Where(x => x.bannerIndex == 1).ToList();
            ViewBag.banner2 = dbContext.Banner.Where(x => x.bannerIndex == 2).ToList();
            ViewBag.banner3 = dbContext.Banner.Where(x => x.bannerIndex == 3).ToList();
            ViewBag.banner4 = dbContext.Banner.Where(x => x.bannerIndex == 4).ToList();
            ViewBag.banner5 = dbContext.Banner.Where(x => x.bannerIndex == 5).ToList();
            ViewBag.subBoards = dbContext.SubBoard;

            var banners = await dbContext.Banner.ToListAsync();
            return View(banners);
        }

        /*public IActionResult Index()
        {
            var banners = await dbContext.Banners.ToListAsync();
            return View();
        }*/

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
