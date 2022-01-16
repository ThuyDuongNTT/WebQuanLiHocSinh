using QuanLiDiem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace QuanLiDiem.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            ReportsList stuList = new ReportsList();
            List<Reports> obj = stuList.getReports(string.Empty);

            return View(obj);

        }
    }
}