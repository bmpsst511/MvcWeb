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
    public class SysEmployeeController : Controller
    {
        private readonly MvcWebContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public SysEmployeeController(MvcWebContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;

            //圖片功能
            webHostEnvironment = hostEnvironment;
        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employee.ToListAsync());
        }

        // GET: Employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.employeeId == id);

            var EmployeeViewModel = new employeeViewModel()
            {
                employeeId = employee.employeeId,
                employeeIndex = employee.employeeIndex,
                employeeName = employee.employeeName,
                employeeIntro = employee.employeeIntro,
                employeeDegree = employee.employeeDegree,
                employeeBirth = employee.employeeBirth,
                ExistingImage = employee.employeePicture
            };

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(employeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                /**** 新增圖片 ******/
                string uniqueFileName = ProcessUploadedFile(model);
                Employee employee = new Employee
                {
                    employeeIndex = model.employeeIndex,
                    employeeName = model.employeeName,
                    employeeIntro = model.employeeIntro,
                    employeeDegree = model.employeeDegree,
                    employeeBirth = model.employeeBirth,
                    employeePicture = uniqueFileName
                };
                /**** 新增圖片 ******/

                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FindAsync(id);

            /******** 編輯圖片 **********/
            var EmployeeViewModel = new employeeViewModel()
            {
                employeeId = employee.employeeId,
                employeeIndex = employee.employeeIndex,
                employeeName = employee.employeeName,
                employeeIntro = employee.employeeIntro,
                employeeDegree = employee.employeeDegree,
                employeeBirth = employee.employeeBirth,
                ExistingImage = employee.employeePicture
            };
            /******** 編輯圖片 **********/

            if (employee == null)
            {
                return NotFound();
            }
            ViewBag.employeeInfo = _context.Employee.Where(x => x.employeeId == id).ToList(); // for sysemployee/ edit view
            return View(EmployeeViewModel);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, employeeViewModel model)
        {
            /*if (id != employee.employeeId)
            {
                return NotFound();
            }*/

            if (ModelState.IsValid)
            {
                var employee = await _context.Employee.FindAsync(model.employeeId);
                employee.employeeIndex = model.employeeIndex;
                employee.employeeName = model.employeeName;
                employee.employeeIntro = model.employeeIntro;
                employee.employeeDegree = model.employeeDegree;
                employee.employeeBirth = model.employeeBirth;

                if(model.employeeImage != null)
                {
                    if(model.ExistingImage != null)
                    {
                        string filePath = Path.Combine(webHostEnvironment.WebRootPath, "Uploads", model.ExistingImage);
                        System.IO.File.Delete(filePath);
                    }
                    employee.employeePicture = ProcessUploadedFile(model);
                }
                _context.Update(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.employeeId == id);

            /******** delete圖片 **********/
            var EmployeeViewModel = new employeeViewModel()
            {
                employeeId = employee.employeeId,
                employeeIndex = employee.employeeIndex,
                employeeName = employee.employeeName,
                employeeIntro = employee.employeeIntro,
                employeeDegree = employee.employeeDegree,
                employeeBirth = employee.employeeBirth,
                ExistingImage = employee.employeePicture
            };
            /******** delete圖片 **********/

            if (employee == null)
            {
                return NotFound();
            }

            return View(EmployeeViewModel);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employee.FindAsync(id);

            var CurrentImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images",employee.employeePicture);

            _context.Employee.Remove(employee);
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

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.employeeId == id);
        }

        private string ProcessUploadedFile(employeeViewModel model)
        {
            string uniqueFileName = null;

            if (model.employeeImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Uploads");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.employeeImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.employeeImage.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }

    }
}
