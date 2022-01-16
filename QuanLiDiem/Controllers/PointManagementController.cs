using QuanLiDiem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace QuanLiDiem.Controllers
{
    public class PointManagementController : Controller
    {
        // GET: PointManagement
        public ActionResult Index()
        {
            PointManagementList stuList = new PointManagementList();
            List<PointManagement> obj = stuList.getPointManagement(string.Empty);

            return View(obj);

        }
        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Create(PointManagement stu)
        {
            if (ModelState.IsValid)
            {
                PointManagementList stuList = new PointManagementList();
                stuList.AddPointManagement(stu);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(string id = "")
        {
            PointManagementList stuList = new PointManagementList(); ;
            List<PointManagement> obj = stuList.getPointManagement(id);
            return View(obj.FirstOrDefault());

        }
        [HttpPost]
        public ActionResult Edit(PointManagement stu)
        {
            PointManagementList stuList = new PointManagementList();
            stuList.UpdatePointManagement(stu);
            return RedirectToAction("Index");
        }

        public ActionResult Details(string id = "")
        {
            PointManagementList stuList = new PointManagementList();
            List<PointManagement> obj = stuList.getPointManagement(id);
            return View(obj.FirstOrDefault());
        }

        public ActionResult Delete(string id = "")
        {
            PointManagementList stuList = new PointManagementList();
            List<PointManagement> obj = stuList.getPointManagement(id);
            return View(obj.FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(PointManagement stu)
        {
            PointManagementList stuList = new PointManagementList();
            stuList.DeletePointManagement(stu);
            return RedirectToAction("Index");
        }
    }
}
