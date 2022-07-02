﻿using System;
using System.Collections.Generic;
using DAL.Models;

namespace Business.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public List<Card> Cards { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Event> Events { get; set; }
    }
}


