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
    }
}