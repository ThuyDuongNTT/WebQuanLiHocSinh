using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QuanLiDiem.Models
{
    public class Student
    {
        public int MaHS { set; get; }
        [Required(ErrorMessage="Mời nhập học và tên sinh viên")]
        [Display(Name = "Họ và tên")]
        public string TenHS { set; get; }
       // [Required(ErrorMessage = "Mời nhập ngày sinh từ 15 đến 20 tuổi")]

        [Display(Name = "Ngày sinh")]
        public DateTime NgaySinh { set; get; }
        [Required(ErrorMessage = "Mời nhập giới tính")]
        [Display(Name = "Giới tính")]
        public string GioiTinh { set; get; }
        [Required(ErrorMessage = "Mời nhập địa chỉ")]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { set; get; }
        [Required(ErrorMessage = "Mời nhập email")]
        [Display(Name = "Email")]
        public string Email { set; get; }
        [Display(Name = "Mã lớp học")]
       // public int MaLop { set; get; }
        public string MaLop { set; get; }

    }

    class StudentList
    {
        DBConnection db;
        public StudentList()
        {
            db = new DBConnection();
        }
        public List<Student> getStudent(string ID)
        {

            string sql;
            if (string.IsNullOrEmpty(ID))
                sql = "SELECT* FROM HocSinh";
            else
                sql = "SELECT* FROM HocSinh WHERE MaHS =" + ID;

            List<Student> stuList = new List<Student>();
            DataTable dt = new DataTable();
            SqlConnection con = db.GetConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con.Open();
            da.Fill(dt);
            da.Dispose();
            con.Close();
            Student tmpStu;
            for (int i= 0; i<dt.Rows.Count; i++)
            {
                tmpStu = new Student();
                tmpStu.MaHS = Convert.ToInt32(dt.Rows[i]["MaHS"].ToString());
                tmpStu.TenHS = dt.Rows[i]["TenHS"].ToString();
               // tmpStu.NgaySinh = Convert.ToDateTime(dt.Rows[i]["NgaySinh"].ToString());

              //  tmpStu.NgaySinh = Convert.ToDateTime(dt.Rows[i]["NgaySinh"].ToString());
                tmpStu.GioiTinh = dt.Rows[i]["GioiTinh"].ToString();         
                tmpStu.DiaChi = dt.Rows[i]["DiaChi"].ToString();
                tmpStu.Email = dt.Rows[i]["Email"].ToString();
              //  tmpStu.MaLop = Convert.ToInt32(dt.Rows[i]["MaLop"].ToString());
                tmpStu.MaLop = dt.Rows[i]["MaLop"].ToString();

                stuList.Add(tmpStu);

            }
            return stuList;
        }

        
        public void AddStudent(Student stu)
        {
            string sql = "INSERT INTO HocSinh(TenHS,GioiTinh) VALUES (N'" + stu.TenHS + "',N'" + stu.GioiTinh + "')";
            SqlConnection con = db.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
    }
    

}