using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Business.Services;
using DAL.Models;
using Exceptions.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Utilities.Helpers;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Eduhome.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "Admin,SuperAdmin")]
    public class SliderController : Controller
    {
        private readonly ISliderService _slider;
        private readonly IWebHostEnvironment _env;
        private readonly IImageService _imageService;
        public SliderController(ISliderService slider, IWebHostEnvironment env,IImageService imageService)
        {
            _slider = slider;
            _env = env;
            _imageService = imageService;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            try
            {
                var data = await _slider.GetAll();
                return View(data);
            }
            catch(EntityIsNullException ex)
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
             Slider slider ;
            try
            {
                slider = await _slider.Get(id);
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

            return View(slider);
        }

        public async Task<IActionResult> Create()
        {
            

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider card)
        {
            if (!ModelState.IsValid)
            {
                return View(card);
            }
            string fileName = Guid.NewGuid().ToString() + card.ImageFile.FileName;

            if (fileName.Length > 255)
            {
                fileName = fileName.Substring(fileName.Length - 254);
            }

            string path = Path.Combine(_env.WebRootPath, "assets", "uploads", "images", fileName);

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                await card.ImageFile.CopyToAsync(fs);
            }

            Image image = new();

            image.Name = fileName;

            await _imageService.Create(image);

            card.ImageId = image.Id;

            await _slider.Create(card);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException("Id");
            }
            var data = await _slider.Get(id);
            if (data is null)
            {
                throw new NullReferenceException("card is null");
            }

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Slider slider)
        {
          
            if (!ModelState.IsValid)
            {
                return View(slider);
            }

            await _slider.Update(id, slider);

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _slider.Delete(id);
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

