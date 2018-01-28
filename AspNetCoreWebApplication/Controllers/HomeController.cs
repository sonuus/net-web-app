using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace AspNetCoreWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            for (int j = 0; j < 100; j++)
            {
                sb.Append(j);
                sb.Append(",");
            }
            
            ViewData["Message"] = sb.ToString();;
            return View();
        }

        public IActionResult Error()
        {
            ViewData["Message"] = "We've encountered an error :(";
            return View();
        }
    }
}
