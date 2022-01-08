using QuanLiDiem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLiDiem.Controllers
{
    public class SubjectsController : Controller
    {
        // GET: Subjects
        public ActionResult Index()
        {
            SubjectsList stuList = new SubjectsList();
            List<Subjects> obj = stuList.getSubjects(string.Empty);

            return View(obj);
        }


        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Create(Subjects stu)
        {
            if (ModelState.IsValid)
            {
                SubjectsList stuList = new SubjectsList();
                stuList.AddSubjects(stu);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(string id = "")
        {
            SubjectsList stuList = new SubjectsList(); ;
            List<Subjects> obj = stuList.getSubjects(id);
            return View(obj.FirstOrDefault());

        }
        [HttpPost]
        public ActionResult Edit(Subjects stu)
        {
            SubjectsList stuList = new SubjectsList();
            stuList.UpdateSubjects(stu);
            return RedirectToAction("Index");
        }

        public ActionResult Details(string id = "")
        {
            SubjectsList stuList = new SubjectsList();
            List<Subjects> obj = stuList.getSubjects(id);
            return View(obj.FirstOrDefault());
        }

        public ActionResult Delete(string id = "")
        {
            SubjectsList stuList = new SubjectsList();
            List<Subjects> obj = stuList.getSubjects(id);
            return View(obj.FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(Subjects stu)
        {
            SubjectsList stuList = new SubjectsList();
            stuList.DeleteSubjects(stu);
            return RedirectToAction("Index");
        }
    }
}