using QuanLyHocSinh.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyHocSinh.Controllers
{
    public class LoginController : Controller
    {

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(GiangVien loginGv)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine(loginGv);
                using(DB_QuanLiDiemEntities db = new DB_QuanLiDiemEntities())
                {
                    var giangvien = db.GiangViens.Where(gv => gv.Email.Equals(loginGv.Email) && gv.MatKhau.Equals(loginGv.MatKhau)).FirstOrDefault();
                    if (giangvien != null)
                    {
                        Session["MaGv"] = giangvien.MaGV.ToString();
                        Session["TenGV"] = giangvien.TenGV.ToString();
                        Console.WriteLine(giangvien);
                        Console.WriteLine(giangvien.Quyen.TenQuyen);
                        Session["Quyen"] = giangvien.Quyen.TenQuyen.ToString();
                        
                        return RedirectToAction("Index", "Lop");
                    }
                    else
                    {
                        ModelState.AddModelError("", "The Username or Password Incorrect");
                    }
                }
            }

            return View(loginGv);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}