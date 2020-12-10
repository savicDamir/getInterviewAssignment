using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PROBANET.Models;

namespace PROBANET.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private pmdbContext context= new pmdbContext();
        public HomeController(){
            
        }
      

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User login)
        {   
            var user = context
                .Users
                .Where(u => u.Username == login.Username && u.Password == login.Password).ToList();
                if (user.Count==0)
                    return this.StatusCode(210,"");
                else
                switch(user.First().Role)
                {
                    case "Administrator":
                        return this.StatusCode(220, user.First().Id);
                    case "Project Manager":
                        return this.StatusCode(230, user.First().Id);
                    case "Developer":
                        return this.StatusCode(240, user.First().Id);
                   
                }
            return NotFound();
        }
        
    }
}
