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
    public class SysProductController : Controller
    {
        private readonly MvcWebContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public SysProductController(MvcWebContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;

            //圖片功能
            webHostEnvironment = hostEnvironment;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            return View(await _context.Product.ToListAsync());
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.productId == id);

            var ProductViewModel = new productViewModel()
            {
                productId = product.productId,
                productIndex = product.productIndex,
                productNumber = product.productNumber,
                productPrice = product.productPrice,
                productName = product.productName,
                productDescription = product.productDescription,
                productUnit = product.productUnit,
                productPosition = product.productPosition,
                productPs = product.productPs,
                ExistingImage = product.productPicture
            };
            
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(productViewModel model)
        {
            if (ModelState.IsValid)
            {
                /**** 新增圖片 ******/
                string uniqueFileName = ProcessUploadedFile(model);
                Product product = new Product
                {
                    productIndex = model.productIndex,
                    productNumber = model.productNumber,
                    productPrice = model.productPrice,
                    productName = model.productName,
                    productDescription = model.productDescription,
                    productUnit = model.productUnit,
                    productPosition = model.productPosition,
                    productPs = model.productPs,
                    productPicture = uniqueFileName
                };
                /**** 新增圖片 ******/

                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //return View(product);
            return View(model);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);

            /******** 編輯圖片 **********/
            var ProductViewModel = new productViewModel()
            {
                productId = product.productId,
                productIndex = product.productIndex,
                productNumber = product.productNumber,
                productPrice = product.productPrice,
                productName = product.productName,
                productDescription = product.productDescription,
                productUnit = product.productUnit,
                productPosition = product.productPosition,
                productPs = product.productPs,
                ExistingImage = product.productPicture
            }; 
            /******** 編輯圖片 **********/

            if (product == null)
            {
                return NotFound();
            }
            //return View(product);
            return View(ProductViewModel);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, productViewModel model)
        {
            /*if (id != product.productId)
            {
                return NotFound();
            }*/

            if (ModelState.IsValid)
            {
                var product = await _context.Product.FindAsync(model.productId);
                product.productIndex = model.productIndex;
                product.productNumber = model.productNumber;
                product.productPrice = model.productPrice;
                product.productName = model.productName;
                product.productDescription = model.productDescription;
                product.productUnit = model.productUnit;
                product.productPosition = model.productPosition;
                product.productPs = model.productPs;

                if(model.productImage != null)
                {
                    if(model.ExistingImage != null)
                    {
                        string filePath = Path.Combine(webHostEnvironment.WebRootPath, "Uploads", model.ExistingImage);
                        System.IO.File.Delete(filePath);
                    }
                    product.productPicture = ProcessUploadedFile(model);
                }
                _context.Update(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.productId == id);

            /******** 刪除圖片 **********/
            var ProductViewModel = new productViewModel()
            {
                productId = product.productId,
                productIndex = product.productIndex,
                productNumber = product.productNumber,
                productPrice = product.productPrice,
                productName = product.productName,
                productDescription = product.productDescription,
                productUnit = product.productUnit,
                productPosition = product.productPosition,
                productPs = product.productPs,
                ExistingImage = product.productPicture
            }; 
            /******** 刪除圖片 **********/

            if (product == null)
            {
                return NotFound();
            }

            return View(ProductViewModel);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);

            var CurrentImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images",product.productPicture);

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            if (await _context.SaveChangesAsync() > 0)
            {
                if (System.IO.File.Exists(CurrentImage))
                {
                    System.IO.File.Delete(CurrentImage);
                }
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.productId == id);
        }

        private string ProcessUploadedFile(productViewModel model)
        {
            string uniqueFileName = null;

            if (model.productImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Uploads");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.productImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.productImage.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}
