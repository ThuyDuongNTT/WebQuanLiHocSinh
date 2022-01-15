using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyHocSinh.Models;
using QuanLyHocSinh.Data;

namespace QuanLyHocSinh.Controllers
{
    public class GiangVienController : Controller
    {
        private DB_QuanLiDiemEntities db = new DB_QuanLiDiemEntities();

        // GET: GiangVien
        public ActionResult Index()
        {
            if (Session["MaGV"] != null)
            {
                var loggedinMaGV = Convert.ToInt32(Session["MaGV"].ToString());
                // List giang vien tru admin va nguoi dung hien tai
                var giangViens = db.GiangViens
                                    .Where(gv => gv.Email != "admin" || gv.MaGV != loggedinMaGV);
                return View(giangViens.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }            
        }

        // GET: GiangVien/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiangVien giangVien = db.GiangViens.Find(id);
            if (giangVien == null)
            {
                return HttpNotFound();
            }
            return View(giangVien);
        }

        // GET: GiangVien/Create
        public ActionResult Create()
        {
            ViewBag.MaQuyen = new SelectList(db.Quyens, "MaQuyen", "TenQuyen");
            return View();
        }

        // POST: GiangVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaGV,TenGV,SDT,DiaChi,NgaySinh,GioiTinh,MatKhau,TrangThai,MaQuyen,Email")] GiangVien giangVien)
        {
            if (ModelState.IsValid)
            {
                var check = db.GiangViens.FirstOrDefault(s => s.Email == giangVien.Email);
                if (check == null)
                {
                    //giangVien.MatKhau = giangVien.MatKhau;
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.GiangViens.Add(giangVien);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    ViewBag.error = "Email đã tồn tại";
                    return View();
                }
            }

            ViewBag.MaQuyen = new SelectList(db.Quyens, "MaQuyen", "TenQuyen", giangVien.MaQuyen);
            return View(giangVien);
        }

        // GET: GiangVien/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiangVien giangVien = db.GiangViens.Find(id);
            if (giangVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaQuyen = new SelectList(db.Quyens, "MaQuyen", "TenQuyen", giangVien.MaQuyen);
            return View(giangVien);
        }

        // POST: GiangVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaGV,TenGV,SDT,DiaChi,NgaySinh,GioiTinh,MatKhau,TrangThai,MaQuyen,Email")] GiangVien giangVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(giangVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaQuyen = new SelectList(db.Quyens, "MaQuyen", "TenQuyen", giangVien.MaQuyen);
            return View(giangVien);
        }

        // GET: GiangVien/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiangVien giangVien = db.GiangViens.Find(id);
            if (giangVien == null)
            {
                return HttpNotFound();
            }
            return View(giangVien);
        }

        // POST: GiangVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GiangVien giangVien = db.GiangViens.Find(id);
            db.GiangViens.Remove(giangVien);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
