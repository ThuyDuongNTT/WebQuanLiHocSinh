using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QuanLiDiem.Models
{
    public class UserManagement
    {
        [Display(Name = "Mã giảng viên")]
        public int MaGV { set; get; }

        [Required(ErrorMessage = "Mời nhập tên giảng viên")]
        [Display(Name = "Tên giảng viên")]
        public string TenGV { set; get; }

        [Display(Name = "Số điện thoại")]
        public int SDT { set; get; }

        [Display(Name = "Địa chỉ")]
        public string DiaChi { set; get; }

        [Display(Name = "Ngày sinh")]
        public DateTime NgaySinh { set; get; }

        [Display(Name = "Giới tính")]
        public string GioiTinh { set; get; }
        [Display(Name = "Mật khẩu")]
        public string MatKhau { set; get; }

        [Display(Name = "Trạng thái")]
        public bool TrangThai { set; get; }

        [Display(Name = "Mã quyền")]
        public int MaQuyen { set; get; }
        [Display(Name = "Email")]
        public string email { set; get; }

    //    public int TenQuyen { set; get; }
        [Display(Name = "Tên quyền")]
        public string TenQuyen { set; get; }
    }
    class UserManagementList
    {
        DBConnection db;
        public UserManagementList()
        {
            db = new DBConnection();
        }
        public List<UserManagement> getUserManagement(string ID)
        {

            string sql;
            if (string.IsNullOrEmpty(ID))
                sql = "SELECT* FROM GiangVien";
            else
                sql = "SELECT* FROM GiangVien WHERE MaGV =" + ID;

            List<UserManagement> stuList = new List<UserManagement>();
            DataTable dt = new DataTable();
            SqlConnection con = db.GetConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con.Open();
            da.Fill(dt);
            da.Dispose();
            con.Close();
            UserManagement tmpStu;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tmpStu = new UserManagement();
                tmpStu.MaGV = Convert.ToInt32(dt.Rows[i]["MaGV"].ToString());
                tmpStu.TenGV = dt.Rows[i]["TenGV"].ToString();
                tmpStu.SDT = Convert.ToInt32(dt.Rows[i]["SDT"].ToString());
                tmpStu.DiaChi = dt.Rows[i]["DiaChi"].ToString();
                tmpStu.NgaySinh = Convert.ToDateTime(dt.Rows[i]["NgaySinh"].ToString());
                tmpStu.GioiTinh = dt.Rows[i]["GioiTinh"].ToString();
                tmpStu.MatKhau = dt.Rows[i]["MatKhau"].ToString();
                tmpStu.TrangThai = Convert.ToBoolean(dt.Rows[i]["TrangThai"].ToString());
                tmpStu.MaQuyen = Convert.ToInt32(dt.Rows[i]["MaQuyen"].ToString());
                tmpStu.email = dt.Rows[i]["email"].ToString();
                if (tmpStu.MaQuyen == 1)
                    tmpStu.TenQuyen = "Admin";
                if (tmpStu.MaQuyen == 2)
                    tmpStu.TenQuyen = "Giáo vụ";
                if (tmpStu.MaQuyen == 3)
                    tmpStu.TenQuyen = "Giáo viên";
                stuList.Add(tmpStu);
            }
            return stuList;
        }
    }
    }