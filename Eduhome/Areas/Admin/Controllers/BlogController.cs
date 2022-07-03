using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Business.Services;
using DAL.Models;
using Exceptions.Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Utilities.Helpers;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Eduhome.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        // GET: /<controller>/
        private readonly IBlogService _blogService;
        private readonly IWebHostEnvironment _env;
        private readonly IImageService _imageService;
        public BlogController(IBlogService blogService, IWebHostEnvironment env, IImageService imageService)
        {
            _blogService = blogService;
            _env = env;
            _imageService = imageService;

        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var data = await _blogService.GetAll();
                return View(data);
            }
            catch (EntityIsNullException ex)
            {
                return Json(new
                {
                    status = (int)Enums.Statuses.DataIsNull,
                    message = ex.Message
                });
            }

           
            catch (Exception ex)
            {
                return Json(new
                {
                    status = (int)Enums.Statuses.GeneralError,
                    message = ex.Message
                });
            }

        }
        public async Task<IActionResult> Details(int? id)
        {
            Blog blog;
            try
            {
                blog = await _blogService.Get(id);
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View(blog);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Blog blog)
        {
            if (!ModelState.IsValid)
            {
                return View(blog);
            } 
            string fileName = Guid.NewGuid().ToString() + blog.ImageFile.FileName;

            if (fileName.Length>255)
            {
                fileName = fileName.Substring(fileName.Length - 254);
            }

            string path = Path.Combine(_env.WebRootPath, "assets", "uploads", "images",fileName);

            using(FileStream fs = new FileStream(path, FileMode.Create))
            {
                await blog.ImageFile.CopyToAsync(fs);
            }

            Image image = new();

            image.Name = fileName;

            await _imageService.Create(image);

            blog.ImageId = image.Id;

            await _blogService.Create(blog);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException("Id");
            }
            var data = await _blogService.Get(id);
            if (data is null)
            {
                throw new NullReferenceException("card is null");
            }

            //var categories = await _categoryService.GetAll();
            //ViewData["categoies"] = categories;

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Blog blog)
        {


            if (!ModelState.IsValid)
            {
                return View(blog);
            }

            await _blogService.Update(id, blog);

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _blogService.Delete(id);
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

