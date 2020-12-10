using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PROBANET.Models;

using Microsoft.EntityFrameworkCore;


namespace PROBANET.Controllers
{
     
    public class DeveloperController: Controller
    {
        private pmdbContext context= new pmdbContext();
        public IActionResult index(int id,string message="")
        {
           try{
                ViewBag.mes= message;
                var user = context.Users.Where(m => m.Id == id).First();
                ViewBag.me=user;

                var taskJoins= from t in context.Tasks
                                        join p in context.Projects on t.ProId equals p.Id into pt
                                        from taskp in pt
                                        where t.Assigned==id
                                        select new TaskJoin {
                                            Id = t.Id,
                                            Status = t.Status,
                                            Progress = t.Progress,
                                            Deadline =t.Deadline,
                                            Description = t.Description,
                                            Assigned = -1,
                                            ProId=taskp.Id,
                                            ProName=  taskp.Name,
                                            AssignedName=""
                                        };
                
                List<TaskJoin> task= taskJoins.ToList();
                ViewBag.all= task;
            }
            catch(Exception)
            {
                return RedirectToAction("Index","Home");
            }
            return View();
        }
        
        [HttpPost]
        public IActionResult AddTask(PROBANET.Models.Task t)
        {
            try
            {
                var check = context.Tasks.Count(m => m.Id== t.Id);
                if (check>0)
                    return this.StatusCode(210);
                context.Tasks.Add(t);    
                var up = context.SaveChanges();
                if (up==0)
                    return this.StatusCode(220);
            }
            catch (Exception)
            {
               return this.StatusCode(220);
            }

            return this.StatusCode(200);
        }

        [HttpPost]
        public IActionResult DeleteTask(int id)
        {
            try{
                var check= context.Tasks.Count(m => m.Id == id);
                if (check==0)  return this.StatusCode(210);
                var u=context.Tasks.Where(m=>m.Id==id).First();
                context.Tasks.Remove(u);
                check= context.SaveChanges();
                if (check==0)
                    return this.StatusCode(220);
            }
            catch (Exception)
            {
               return this.StatusCode(220);
            }

           return this.StatusCode(200);
        }

        [HttpPost]
        public IActionResult UpdateTask (PROBANET.Models.Task t, int indexId)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index","Developer",new {@id = indexId, @message="Check input data"});
            }

            var u = context.Tasks.Count(m => m.Id == t.Id); // Check if task is in database 
            if (u==0)
                return RedirectToAction("Index","Developer",new {@id = indexId, @message="Task is not in database"});
            
            try{
                context.Tasks.Update(t);
                context.SaveChanges();
            }
            catch(Exception)
            {
                 return RedirectToAction("Index","Developer",new {@id = indexId, @message="Database error"});
            }

             return RedirectToAction("Index","Developer",new {@id = indexId, @message="Sucessfull update"});
        }
    }

}