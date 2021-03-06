﻿using BestTourPlan.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BestTourPlan.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataHelper dataHelper;

        public HomeController(DataHelper dataHelper)
        {
            this.dataHelper = dataHelper;
        }

        public IActionResult Index()
        {
            return View(dataHelper.Hotels.GetHotels());
        }
    }
}
