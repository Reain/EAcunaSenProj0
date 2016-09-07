using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVCBartender.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Customer()
        {
            return View();
        }
    }
}