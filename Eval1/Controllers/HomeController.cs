using System.Diagnostics;
using Eval1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eval1.Controllers
{
    public class HomeController : Controller
    {
        Evaluation1Context eval1 = new Evaluation1Context(); 

        public IActionResult Index()
        {
            return View(eval1.Trainees.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]

        public IActionResult Create(string str)
        {
            Trainee Trainee = new Trainee();
            {
                Trainee.TraineeName = Request.Form["TraineeName"];
                Trainee.Location = Request.Form["Location"];
                Trainee.Points = Convert.ToInt32(Request.Form["Points"]);
                Trainee.Description = Request.Form["Description"];
            }
            ;
            eval1.Trainees.Add(Trainee);
            eval1.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
