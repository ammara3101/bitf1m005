using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ead_project.Models;

namespace Ead_project.Controllers
{
    public class HomeController : Controller
    {
        IDataSource user;
        WeddingEntities14 db = new WeddingEntities14();

        public HomeController(IDataSource user1)
        {
            user = user1;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult about()
        {
            return View();
        }
        public ActionResult contact(Contact c)
        {
            if(ModelState.IsValid)
            {
                user.save(c);
                return View("contact");
            }
            return View();
        }
        
        /***********************************Login*************************************/
        public ActionResult services()
        {
            return View();
        }
        public ActionResult onservices(Signup s)
        {
            db.Signups.Add(s);
            db.SaveChanges();
            return RedirectToAction("Events");
        }
        public ActionResult User_Login()
        {
            return View("Events");
        }
        public ActionResult onlogin(Signup s)
        {
            try
            {

                Signup d= db.Signups.First(x => x.email == s.email && x.password == s.password );

            }catch(Exception e) 
            {
                ViewBag.error = "Enter valid email and password";
                return View("services");
             }
            return RedirectToAction("Events");
        }

        public ActionResult update_event()
        {
            return View();
        }
        public ActionResult gallery()
        {
            return View();
        }
        /**********************************Events Handle**********************/

        public ActionResult events()

        {

            return View();
        }
        public ActionResult mehndi()
        {
            return View(db.Images.ToList());
        }
        public ActionResult mehndi_theme(int t_id)
        {
            Theme t = db.Themes.Find(t_id);
            return View(t);
        }
        
        public ActionResult mehndi_theme2(int t_id)
        {
            Image h = db.Images.Find(t_id);
            return View(h);
        }
       
        public ActionResult Registeration()
        {
            return View();
        }
        public ActionResult onregister(Registeration r)
        {

            user.register_client(r);
           // ViewBag.ok = "Your Have Registered, Thanks";
            return View("Registeration");
        }
        public ActionResult images_set()
        {        
            return View(db.Images.ToList());
        }
        public ActionResult register()
        {
            return View(db.check_info.ToList());
        }

    }
}

































































//public ActionResult onmehndi()
//{

//    //string id = Request["btn"];
//    //if(id != null)
//    //try
//    //{
//    //    Theme d = db.Themes.First(x => x.theme_name == id);

//    //}
//    //catch (Exception e)
//    //{
//    //    ViewBag.error = "Enter valid email and password";
//    //    return View("services");
//    //}

//    return View("mehndi_theme");
//}