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
    public class CardController : Controller
    {
        private readonly ICardService _Card;
        private readonly IWebHostEnvironment _env;
        private readonly IImageService _imageService;

        public CardController(ICardService Card, IWebHostEnvironment env, IImageService imageService)
        {
            _Card = Card;
            _env = env;
            _imageService = imageService;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            try
            {
                var data = await _Card.GetAll();
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
            Card card;
            try
            {
                card = await _Card.Get(id);
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

            return View(card);
        }

        public async Task<IActionResult> Create()
        {
            //var categories = await _categoryService.GetAll();
            //ViewData["categoies"] = categories;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Card card)
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

            await _Card.Create(card);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException("Id");
            }
            var data = await _Card.Get(id);
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
        public async Task<IActionResult> Update(int id, Card card)
        {
            //var categories = await _categoryService.GetAll();
            //ViewData["categoies"] = categories;

            if (!ModelState.IsValid)
            {
                return View(card);
            }

            await _Card.Update(id, card);

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _Card.Delete(id);
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

