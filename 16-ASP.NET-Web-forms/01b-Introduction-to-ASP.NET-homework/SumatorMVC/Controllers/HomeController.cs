using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SumatorMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AddTwoNumbers(double? firstNumber, double? secondNumber)
        {
            if (firstNumber == null)
            {
                firstNumber = 0;
            }

            if (secondNumber == null)
            {
                secondNumber = 0;
            }

            ViewBag.Result = firstNumber + secondNumber;
            return View("Index");
        }
    }
}