using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Services;
using Business.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Eduhome.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly ICardService _cardService;
        private readonly IBlogService _blogService;
        public HomeController(ISliderService sliderService, ICardService cardService, IBlogService blogService)
        {
            _sliderService = sliderService;
            _cardService = cardService;
            _blogService = blogService;
        }


        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM();

            homeVM.Sliders = await _sliderService.GetAll();
            homeVM.Cards = await _cardService.GetAll();
            homeVM.Blogs = await _blogService.GetAll();
            return View(homeVM);
        }
    }
}

