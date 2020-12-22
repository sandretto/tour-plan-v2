using BestTourPlan.Domain;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BestTourPlan.Controllers
{
    public class HotelController : Controller
    {
        private readonly DataHelper dataHelper;

        public HotelController(DataHelper dataHelper)
        {
            this.dataHelper = dataHelper;
        }

        public IActionResult Index(Guid id)
        {
            return View(dataHelper.Hotels.GetHotelById(id));
        }
    }
}
