using QuanLiDiem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace QuanLiDiem.Controllers
{
    public class RulesController : Controller
    {
        // GET: Rules
        public ActionResult Index()
        {
            RulesList stuList = new RulesList();
            List<Rules> obj = stuList.getRules(string.Empty);

            return View(obj);

        }
    }
}