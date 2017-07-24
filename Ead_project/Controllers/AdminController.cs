using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ead_project.Models;

namespace Ead_project.Controllers
{
    public class AdminController : Controller
    {
        WeddingEntities14 db = new WeddingEntities14();

        public ActionResult Admin_index()
        {
            return View();
        }
        public ActionResult Admin_signup()
        {
            return View();
        }
        public ActionResult onlogin(admin_login s)
        {
            try
            {
                admin_login d = db.admin_login.First(x => x.username == s.username && x.password == s.password);

            }
            catch (Exception e)
            {
                ViewBag.error = "Enter invalid email and password";
                return View("Admin_index");
            }
            return RedirectToAction("admin_show");
        }
        public ActionResult show()
        {
            return View("admin_show");
        }

        /*//////////////////Update/////////////////////////////////////****************/

        public ActionResult update_event()
        {
            return View(db.Themes.ToList());
        }
        public ActionResult onupdate_events(Theme t)
        {
            String name = Request["theme_name"];
            try
            {
                Theme d = db.Themes.First(x => x.theme_name == name);
               
                d.seating_arrangnment = t.seating_arrangnment;
                d.stage_arrangnment = t.stage_arrangnment;
                d.stage_seating = t.stage_seating;
                d.budget = t.budget;
                d.stage_lightening = t.stage_lightening;

                 db.Entry(d).State = EntityState.Modified;
                db.SaveChanges();

            }
            catch (Exception e)
            {
                ViewBag.error = "Enter invalid email and password";
                return View("update_event");
            }
            ViewBag.update = "Rows Updated Successfully";
            return View("update_event");
        }

        /*//////*****************************Show***************************************/

        public ActionResult admin_show()
        {

            return View(db.Themes.ToList());
        }
        
        public ActionResult show_events()
        {
            return View(db.Themes.ToList());
        }
       
        public ActionResult Add_event_detail()
        {
            return View(db.Themes.ToList());
        }
       
        public ActionResult onAdd_events(Theme t)
        {
            db.Themes.Add(t);
            db.SaveChanges();
            return View("Add_event");
        }
        public ActionResult Add_events()
        {
            return View(db.Themes.ToList());
        }

        public ActionResult onAdd_image(Image t)
        {
            db.Images.Add(t);
            db.SaveChanges();
            return View("Add_events");
        }
        public ActionResult Show_user()
        {
            return View(db.Signups.ToList());
        }
        
        public ActionResult delete_event()
        {
            return View(db.Themes.ToList());
        }

         [HttpPost, ActionName("delete_event")]
        
        public ActionResult ondelete_events()
        {
            String name = Request["theme_name"];
            try
            {
                Theme d = db.Themes.First(x => x.theme_name == name);

                db.Themes.Remove(d);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                ViewBag.error = "Enter invalid email and password";
                return View("update_event");
            }
            ViewBag.done = "Row is Deleted Successfully";

            return View("delete_event");
        }
         public ActionResult show_register_theme()
         {
             return View(db.Registerations.ToList());
         }
    
         public ActionResult show_register_user()
         {
             return View(db.Registerations.ToList());
         }
         public ActionResult show_theme()
         {
             return View(db.Registerations.ToList());
         }
        public JsonResult AjaxSample()
         {
             return this.Json("hello",JsonRequestBehavior.AllowGet);
         }
        public ActionResult Search_event()
        {
            return View("Search_event");
        }
        //public ActionResult onSearch_event()
        //{
        //    Theme t;
        //    string search = Request["search"];
        //    try
        //    {
        //        t = db.Themes.First(x => x.theme_name == search);
        //        return View(t);

        //    }
        //    catch (Exception e)
        //    {
        //        // return View("Search_event");
        //    }

        //    return View(t);
        //}
    }
}
