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
        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Create(Class stu)
        {
            if (ModelState.IsValid)
            {
                ClassList stuList = new ClassList();
                stuList.AddClass(stu);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(string id = "")
        {
            ClassList stuList = new ClassList(); ;
            List<Class> obj = stuList.getClass(id);
            return View(obj.FirstOrDefault());

        }
        [HttpPost]
        public ActionResult Edit(Class stu)
        {
            ClassList stuList = new ClassList();
            stuList.UpdateClass(stu);
            return RedirectToAction("Index");
        }

        public ActionResult Details(string id = "")
        {
            ClassList stuList = new ClassList();
            List<Class> obj = stuList.getClass(id);
            return View(obj.FirstOrDefault());
        }

        public ActionResult Delete(string id = "")
        {
            ClassList stuList = new ClassList();
            List<Class> obj = stuList.getClass(id);
            return View(obj.FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(Class stu)
        {
            ClassList stuList = new ClassList();
            stuList.DeleteClass(stu);
            return RedirectToAction("Index");
        }
    }
}