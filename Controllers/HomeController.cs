using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wk6_Capstone.Models;

namespace wk6_Capstone.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            wk6_CapstoneEntities ORM = new wk6_CapstoneEntities();
            ViewBag.Tasks = ORM.Tasks.Where(x => x.completion.Equals(false));
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

        public ActionResult NewTaskSetup()
        {
            return View();
        }

        public ActionResult CreateTask(Task task)
        {
            wk6_CapstoneEntities ORM = new wk6_CapstoneEntities();
            ORM.Tasks.Add(task);
            ORM.SaveChanges();
            //ViewBag.Tasks = ORM.Tasks.Where(x => x.completion.Equals(false));

            return RedirectToAction("Index");
        }

        public ActionResult DeleteTask(int taskid)
        {
            wk6_CapstoneEntities ORM = new wk6_CapstoneEntities();

            if (ORM.Tasks.Find(taskid) != null)
            {
                ORM.Tasks.Remove(ORM.Tasks.Find(taskid));
                ORM.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult CompleteTask(int taskid)
        {
            wk6_CapstoneEntities ORM = new wk6_CapstoneEntities();

            if (ORM.Tasks.Find(taskid) != null)
            {
                Task OldRecord = ORM.Tasks.Find(taskid);

                // to do: check for null

                OldRecord.completion = true;
               
                ORM.Entry(OldRecord).State = System.Data.Entity.EntityState.Modified;
                ORM.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}