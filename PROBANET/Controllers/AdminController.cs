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
    public class AdminController: Controller
    {
        
        private pmdbContext context= new pmdbContext();
        public IActionResult index(int id,string message="")
        {
           ViewBag.mes= message;
            try{
                var user = context.Users.Where(m => m.Id == id).First();
                ViewBag.me=user;
                var users= context.Users.ToList();
                ViewBag.all= users;
                }
            catch(Exception)
            {
                return RedirectToAction("Index","Home");
            }
            
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            try
            {
                var u = context.Users.Count(m => m.Username == user.Username);
                if (u>0)
                    return this.StatusCode(210);
            }
            catch (Exception)
            {
               return this.StatusCode(210);
            }
            try{
            context.Users.Add(user);    
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
       
       public IActionResult DeleteUser(User u)
       {

           var check= context.Users.Count(m => m.Id == u.Id);
           if (check==0)  return this.StatusCode(210);
           context.Users.Remove(u);
           check= context.SaveChanges();
           if (check==0)
                return this.StatusCode(220);

           return this.StatusCode(200);
       }

       public IActionResult UpdateUser(User user, int indexId)
       {
           Console.WriteLine(indexId);
            var u = context.Users.Count(m => m.Id == user.Id);
            if (u==0)
                return RedirectToAction("Index","Admin",new {@id = indexId, @message="User is not in database"});
            try{
                
                var oldUser=context.Users.Where(u=>u.Id==user.Id).Select( u => u.Role).First();
                {
                    if (oldUser=="Developer" && user.Role!="Developer")
                    {
                        foreach ( var ta in context.Tasks.ToList())
                        {
                            if (ta.Assigned==user.Id)
                                {ta.Assigned=null;
                                context.Tasks.Update(ta);}
                        }
                    }
                    if (oldUser=="Project Manager" &&user.Role!="Project Manager")
                    {
                        foreach ( var ta in context.Projects.ToList())
                        {
                            if (ta.ManId==user.Id)
                                {ta.ManId=null;
                                context.Projects.Update(ta);}
                        }
                    }
                }
                context.Users.Update(user);
                context.SaveChanges();
            }
            catch(Exception)
            {
                 return RedirectToAction("Index","Admin",new {@id = indexId, @message="Check input data"});
            }

             return RedirectToAction("Index","Admin",new {@id = indexId, @message="Sucessfull update"});
       }
    
        public IActionResult Project(int id,string message="")
        {
            ViewBag.mes= message;
            try{
                var user = context.Users.Where(m => m.Id == id).First();
                ViewBag.me=user;
                var pro = from pr in context.Projects 
                            select new ProjectPlus
                            {
                                Id = pr.Id,
                                Name = pr.Name,
                                Code = pr.Code,
                                ManId = pr.ManId,
                                Progress = (from t in context.Tasks where t.ProId==pr.Id select (int?)t.Progress).Average(),
                                Overdue = (from t in context.Tasks where t.ProId==pr.Id && t.Deadline< DateTime.Today.AddDays(3) select t.Progress).Count()

                            }
                            ;
                ViewBag.all= pro.ToList();
                
            }
            catch(Exception)
            {
                return RedirectToAction("Index","Home");
            }
            var managers= context.Users.Where(m => m.Role=="Project Manager").ToList();
            ViewBag.man = managers;
            return View();
        }

        public IActionResult AddProject(Project pro)
        {
            try
            {
                var check = context.Projects.Count(m => m.Id== pro.Id);
                if (check>0)
                    return this.StatusCode(210);
                    
                context.Projects.Add(pro);    
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
        public IActionResult DeleteProject(int id)
        {
            var check= context.Projects.Count(m => m.Id == id);
            if (check==0)  return this.StatusCode(210);
            var u=context.Projects.Where(m=>m.Id==id).First();
            var task= context.Tasks.Where(m => m.ProId== u.Id).ToList();
            foreach (var t in task)
            {
               context.Tasks.Remove(t);
            }
           context.Projects.Remove(u);
           check= context.SaveChanges();
           if (check==0)
                return this.StatusCode(220);

           return this.StatusCode(200);
        }

        public IActionResult UpdateProject(Project project, int indexId){
            var u = context.Projects.Count(m => m.Id == project.Id);
            if (u==0)
                return RedirectToAction("Project","Admin",new {@id = indexId, @message="Task is not in database"});
            try{
                context.Projects.Update(project);
                context.SaveChanges();
            }
            catch(Exception)
            {
                 return RedirectToAction("Project","Admin",new {@id = indexId, @message="Database error"});
            }

             return RedirectToAction("Project","Admin",new {@id = indexId, @message="Sucessfull update"});
        }
        public IActionResult Task(int id,string message="")
        {
            ViewBag.mes= message;
            try{
                var user = context.Users.Where(m => m.Id == id).First();
                ViewBag.me=user;
            }
            catch(Exception)
            {
                return RedirectToAction("Index","Home");
            }
            var taskJoins= from t in context.Tasks
                                        join p in context.Projects on t.ProId equals p.Id into pt
                                        from taskp in pt
                                        join u in context.Users on t.Assigned equals u.Id into tu
                                        from tasku in tu.DefaultIfEmpty()
                                        select new TaskJoin {
                                             Id = t.Id,
                                            Status = t.Status,
                                            Progress = t.Progress,
                                            Deadline =t.Deadline,
                                            Description = t.Description,
                                            Assigned = tasku.Id !=null? tasku.Id:-1,
                                            ProId=taskp.Id,
                                            ProName=  taskp.Name,
                                            AssignedName=tasku.Username != null ? tasku.Username : ""
                                        };
                
            List<TaskJoin> task= taskJoins.ToList();
            ViewBag.all= task;
            var proj= context.Projects.ToList();
            ViewBag.pro=proj;
          
           try
            {   var dev= context.Users.FromSqlRaw(
                "SELECT * FROM user u WHERE u.role = 3 and( u.id not IN (SELECT t.assigned FROM task t GROUP BY t.assigned HAVING COUNT(t.id)>2) or (SELECT t.assigned FROM task t GROUP BY t.assigned HAVING COUNT(t.id)>2 limit 1) IS NULL)"
            ).ToList();
            ViewBag.dev= dev;
            }
            catch(Exception)
            {

            }
            return View();
        }
        public IActionResult AddTask(PROBANET.Models.Task t)
        {
            try
            {
                var check = context.Tasks.Count(m => m.Id== t.Id);
                if (check>0)
                    return this.StatusCode(210);
            }
            catch (Exception)
            {
               return this.StatusCode(220);
            }

            try{
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

        public IActionResult DeleteTask(int id)
        {
           var check= context.Tasks.Count(m => m.Id == id);
           if (check==0)  return this.StatusCode(210);
           var u=context.Tasks.Where(m=>m.Id==id).First();
           context.Tasks.Remove(u);
           check= context.SaveChanges();
           if (check==0)
                return this.StatusCode(220);

           return this.StatusCode(200);
        }

        public IActionResult UpdateTask (PROBANET.Models.Task t, int indexId)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Task","Admin",new {@id = indexId, @message="Check input data"});
            }
            var u = context.Tasks.Count(m => m.Id == t.Id);
            if (u==0)
                return RedirectToAction("Task","Admin",new {@id = indexId, @message="Task is not in database"});
            try{
                context.Tasks.Update(t);
                context.SaveChanges();
            }
            catch(Exception)
            {
               
                 return RedirectToAction("Task","Admin",new {@id = indexId, @message="Database error"});
            }

             return RedirectToAction("Task","Admin",new {@id = indexId, @message="Sucessfull update"});
        }
    }
}