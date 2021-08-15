using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcWeb.Models;

// 圖片上傳功能
using MvcWeb.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace MvcWeb.Controllers
{
    public class SysBannerController : Controller
    {
        private readonly MvcWebContext _context;
        //圖片功能
        private readonly IWebHostEnvironment webHostEnvironment;
        public SysBannerController(MvcWebContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;

            //圖片功能
            webHostEnvironment = hostEnvironment;
        }

        // GET: Banner
        public async Task<IActionResult> Index()
        {
            return View(await _context.Banner.ToListAsync());
        }

        // GET: Banner/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banner = await _context.Banner
                .FirstOrDefaultAsync(m => m.Id == id);
            var BannerViewModel = new bannerViewModel()
            {
                Id = banner.Id,
                bannerIndex = banner.bannerIndex,
                bannerState = banner.bannerState,
                bannerContentUp = banner.bannerContentUp,
                bannerContentDown = banner.bannerContentDown,
                ExistingImage = banner.ProfilePicture
            };

            if (banner == null)
            {
                return NotFound();
            }

            return View(banner);
        }

        // GET: Banner/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Banner/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(bannerViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);
                Banner banner = new Banner
                {
                    bannerIndex = model.bannerIndex,
                    bannerState = model.bannerState,
                    bannerContentUp = model.bannerContentUp,
                    bannerContentDown = model.bannerContentDown,
                    ProfilePicture = uniqueFileName
                };

                _context.Add(banner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Banner/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banner = await _context.Banner.FindAsync(id);

            var BannerViewModel = new bannerViewModel()
            {
                Id = banner.Id,
                bannerIndex = banner.bannerIndex,
                bannerState = banner.bannerState,
                bannerContentUp = banner.bannerContentUp,
                bannerContentDown = banner.bannerContentDown,
                ExistingImage = banner.ProfilePicture
            };

            if (banner == null)
            {
                return NotFound();
            }
            ViewBag.bannerInfo = _context.Banner.Where(x => x.Id == id).ToList(); // for sysemployee/ edit view
            return View(BannerViewModel);
        }

        // POST: Banner/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, bannerViewModel model)
        {
            /*if (id != model.Id)
            {
                return NotFound();
            }*/

            if (ModelState.IsValid)
            {
                var banner = await _context.Banner.FindAsync(model.Id);
                banner.bannerIndex = model.bannerIndex;
                banner.bannerState = model.bannerState;
                banner.bannerContentUp = model.bannerContentUp;
                banner.bannerContentDown = model.bannerContentDown;

                if (model.ProfileImage != null)
                {
                    if (model.ExistingImage != null)
                    {
                        string filePath = Path.Combine(webHostEnvironment.WebRootPath, "Uploads", model.ExistingImage);
                        System.IO.File.Delete(filePath);
                    }

                    banner.ProfilePicture = ProcessUploadedFile(model);
                }
                _context.Update(banner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Banner/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banner = await _context.Banner
                .FirstOrDefaultAsync(m => m.Id == id);

            var BannerViewModel = new bannerViewModel()
            {
                Id = banner.Id,
                bannerIndex = banner.bannerIndex,
                bannerState = banner.bannerState,
                bannerContentUp = banner.bannerContentUp,
                bannerContentDown = banner.bannerContentDown,
                ExistingImage = banner.ProfilePicture
            };

            if (banner == null)
            {
                return NotFound();
            }

            return View(BannerViewModel);
        }

        // POST: Banner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var banner = await _context.Banner.FindAsync(id);

            var CurrentImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", banner.ProfilePicture);

            _context.Banner.Remove(banner);

            if (await _context.SaveChangesAsync() > 0)
            {
                if (System.IO.File.Exists(CurrentImage))
                {
                    System.IO.File.Delete(CurrentImage);
                }
            }

            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BannerExists(int id)
        {
            return _context.Banner.Any(e => e.Id == id);
        }

        private string ProcessUploadedFile(bannerViewModel model)
        {
            string uniqueFileName = null;

            if (model.ProfileImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Uploads");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfileImage.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}
