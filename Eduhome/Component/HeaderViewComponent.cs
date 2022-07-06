using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Eduhome.Component
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly SettingRepository _setting;
        public HeaderViewComponent(SettingRepository setting)
        {
            _setting = setting;

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<string> datas = new List<string>();
            datas.Add(_setting.Get("headerLogo"));

            return View(datas);
        }   
    }
          
}

    
         
    



