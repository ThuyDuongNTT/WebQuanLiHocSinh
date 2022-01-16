using QuanLiDiem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace QuanLiDiem.Controllers
{
    public class UserManagementController : Controller
    {
        // GET: UserManagement
        public ActionResult Index()
        {

            UserManagementList stuList = new UserManagementList();
            List<UserManagement> obj = stuList.getUserManagement(string.Empty);

            return View(obj);

            
        }
    }
}