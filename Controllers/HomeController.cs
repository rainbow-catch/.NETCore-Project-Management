using DataRoom.Models;
using DataRoom.ViewModels;
using FileUploadDownload.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace DataRoom.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IHostEnvironment _hostingEnvironment;

        public HomeController(IEmployeeRepository employeeRepository,
                              IHostEnvironment hostingEnvironment)
        {
            _employeeRepository = employeeRepository;
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// List files currently on the upload folder of the server
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            // Get files from the server
            var model = new FilesViewModel();

            foreach (var item in Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "upload")))
            {
                model.Files.Add(
                    new FileDetails { Name = System.IO.Path.GetFileName(item), Path = item });
            }
            
            return View(model);
        }

        [HttpGet]
        public IActionResult UploadFiles()
        {
            // Gets files from the server
            // https://www.techieclues.com/articles/how-to-upload-and-download-files-in-asp-net-core
            var model = new FilesViewModel();

            foreach (var item in Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "upload")))
            {
                model.Files.Add(
                    new FileDetails { Name = System.IO.Path.GetFileName(item), Path = item });
            }
            
            return View(model);
        }

        [HttpPost]
        public IActionResult UploadFiles(IFormFile[] files)
        {
            // Iterate each files
            foreach (var file in files)
            {
                // Gets the file name from the browser
                var fileName = System.IO.Path.GetFileName(file.FileName);

                // Gets file path to be uploaded
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "upload", fileName);

                // Checks If file with same name exists and delete it
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                // Creates a new local file and copy contents of uploaded file
                using (var localFile = System.IO.File.OpenWrite(filePath))
                
                using (var uploadedFile = file.OpenReadStream())
                {
                    uploadedFile.CopyTo(localFile);
                }
            }
            
            ViewBag.Message = "Files are successfully uploaded";

            // Gets files from the server
            var model = new FilesViewModel();
            
            foreach (var item in Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "upload")))
            {
                model.Files.Add(
                    new FileDetails { Name = System.IO.Path.GetFileName(item), Path = item });
            }
            
            return View(model);
        }

        // Downloads file from the server
        public async Task<IActionResult> Download(string filename)
        {
            if (filename == null)
                return Content("filename is not availble");

            var path = Path.Combine(Directory.GetCurrentDirectory(), "upload", filename);

            var memory = new MemoryStream();

            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            
            memory.Position = 0;
            
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }

        // Gets content type
        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            
            return types[ext];
        }

        // Gets mime types
        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
                    {
                        {".txt", "text/plain"},
                        {".pdf", "application/pdf"},
                        {".doc", "application/vnd.ms-word"},
                        {".docx", "application/vnd.ms-word"},
                        {".xls", "application/vnd.ms-excel"},
                        {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                        {".png", "image/png"},
                        {".jpg", "image/jpeg"},
                        {".jpeg", "image/jpeg"},
                        {".gif", "image/gif"},
                        {".csv", "text/csv"}
                    };
        }

        public ViewResult GetAllEmployees()
        {
            // retrieve all the employees
            var model = _employeeRepository.GetAllEmployees();
            
            // Pass the list of employees to the view
            return View(model);
        }

        public ViewResult Detail(int id)
        {
            EmployeeDetailViewModel detailViewModel = new EmployeeDetailViewModel()
            {
                Employee = _employeeRepository.GetEmployee(id),
                PageTitle = "Employee Details"
            };
            
            return View(detailViewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;

                // If the Photo property on the incoming model object is not null, then the user
                // has selected an image to upload.
                if (model.Photo != null)
                {
                    // The image must be uploaded to the images folder in wwwroot
                    // To get the path of the wwwroot folder we are using the inject
                    // HostingEnvironment service provided by ASP.NET Core
                    string uploadsFolder = Path.Combine(_hostingEnvironment.ContentRootPath, "images");
                    
                    // To make sure the file name is unique we are appending a new
                    // GUID value and and an underscore to the file name
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    
                    // Use CopyTo() method provided by IFormFile interface to
                    // copy the file to wwwroot/images folder
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Employee newEmployee = new Employee
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = (Departments) model.Department,
                    
                    // Store the file name in PhotoPath property of the employee object
                    // which gets saved to the Employees database table
                    PhotoPath = uniqueFileName
                };

                _employeeRepository.Add(newEmployee);
                return RedirectToAction("GetEmployee", new { id = newEmployee.Id });
            }

            return View();
        }
    }
}
