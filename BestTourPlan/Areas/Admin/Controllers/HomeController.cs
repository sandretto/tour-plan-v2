using BestTourPlan.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestTourPlan.Areas.Admin.Controllers
{
    [Area("Admin")]
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
