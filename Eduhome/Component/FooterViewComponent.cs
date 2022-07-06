using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Eduhome.Component
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly SettingRepository _setting;
        public FooterViewComponent(SettingRepository setting)
        {
            _setting = setting;

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(_setting.GetALl());
        }
    }
}

