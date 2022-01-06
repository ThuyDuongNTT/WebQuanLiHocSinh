using QuanLiDiem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace QuanLiDiem.Controllers
{
    public class ClassController : Controller
    {
        // GET: Class
        public ActionResult Index()
        {
            ClassList stuList = new ClassList();
            List<Class> obj = stuList.getClass(string.Empty);

            return View(obj);
      
        }
    }
}