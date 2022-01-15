using Microsoft.Owin;
using Owin;
using QuanLyHocSinh.Models;
using System.Linq;

[assembly: OwinStartupAttribute(typeof(QuanLyHocSinh.Startup))]
namespace QuanLyHocSinh
{
    public partial class Startup
    {

        ApplicationDbContext dc = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //CreateDefaultRolesAndUsers();
        }

        /*
        public void CreateDefaultRolesAndUsers()
        {
            using (DB_QuanLiDiemEntities db = new DB_QuanLiDiemEntities())
            {
                var checkSuperadminRole = db.Quyens.FirstOrDefault(s => s.TenQuyen == "superamin");
                if (checkSuperadminRole == null)
                {
                    var quyen = new Quyen();
                    quyen.TrangThai = true;
                    quyen.TenQuyen = "superamin";
                    db.Quyens.Add(quyen);
                }

                var checkDefaultAdmin = db.GiangViens.FirstOrDefault(s => s.Email == "admin");
                if (checkDefaultAdmin == null)
                {
                    var gv = new GiangVien();
                    gv.Email = "admin";
                    gv.MatKhau = "admin";
                    db.GiangViens.Add(gv);
                }
                db.SaveChanges();
                
            }                   
        }
        */
    }
}
