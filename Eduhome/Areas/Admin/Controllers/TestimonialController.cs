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
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _Testimonial;
        private readonly IWebHostEnvironment _env;
        private readonly IImageService _imageService;
        public TestimonialController(ITestimonialService Testimonial, IWebHostEnvironment env, IImageService imageService)
        {
            _Testimonial = Testimonial;
            _env = env;
            _imageService = imageService;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            try
            {
                var data = await _Testimonial.GetAll();
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
            Testimonial testimonial;
            try
            {
                testimonial = await _Testimonial.Get(id);
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

            return View(testimonial);
        }

        public async Task<IActionResult> Create()
        {


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Testimonial testimonial)
        {
            if (!ModelState.IsValid)
            {
                return View(testimonial);
            }
            string fileName = Guid.NewGuid().ToString() + testimonial.ImageFile.FileName;

            if (fileName.Length > 255)
            {
                fileName = fileName.Substring(fileName.Length - 254);
            }

            string path = Path.Combine(_env.WebRootPath, "assets", "uploads", "images", fileName);

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                await testimonial.ImageFile.CopyToAsync(fs);
            }

            Image image = new();

            image.Name = fileName;

            await _imageService.Create(image);

            testimonial.ImageId = image.Id;

            await _Testimonial.Create(testimonial);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException("Id");
            }
            var data = await _Testimonial.Get(id);
            if (data is null)
            {
                throw new NullReferenceException("card is null");
            }

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Testimonial testimonial)
        {

            if (!ModelState.IsValid)
            {
                return View(testimonial);
            }

            await _Testimonial.Update(id, testimonial);

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _Testimonial.Delete(id);
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

