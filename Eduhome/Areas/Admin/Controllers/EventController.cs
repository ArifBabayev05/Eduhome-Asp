using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Services;
using DAL.Models;
using Exceptions.Entity;
using Microsoft.AspNetCore.Mvc;
using Utilities.Helpers;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Eduhome.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EventController : Controller
    {

        private readonly IEventService _eventService;
        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            try
            {
                var data = await _eventService.GetAll();
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
            Event myEvent;
            try
            {
                myEvent = await _eventService.Get(id);
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
            return View();
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Event myEvent)
        {
            if (!ModelState.IsValid)
            {
                return View(myEvent);
            }
            await _eventService.Create(myEvent);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException("Id");
            }
            var data = await _eventService.Get(id);
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
        public async Task<IActionResult> Update(int id, Event myEvent)
        {
            //var categories = await _categoryService.GetAll();
            //ViewData["categoies"] = categories;

            if (!ModelState.IsValid)
            {
                return View(myEvent);
            }

            await _eventService.Update(id, myEvent);

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _eventService.Delete(id);
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

