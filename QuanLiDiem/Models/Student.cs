using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QuanLiDiem.Models
{
    public class StudentID
    {
        public string ID;
    }
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
        public int MaLop { set; get; }

    }

    class StudentList
    {
        public string temp_id { set; get; }

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
                tmpStu.NgaySinh = Convert.ToDateTime(dt.Rows[i]["NgaySinh"].ToString());
                tmpStu.GioiTinh = dt.Rows[i]["GioiTinh"].ToString();         
                tmpStu.DiaChi = dt.Rows[i]["DiaChi"].ToString();
                tmpStu.Email = dt.Rows[i]["Email"].ToString();
                string temp = dt.Rows[i]["MaLop"].ToString();
                if (string.IsNullOrEmpty(temp))
                {
                    tmpStu.MaLop = 0;

                }
                else
                {
                    tmpStu.MaLop = Convert.ToInt32(temp);
                }
                stuList.Add(tmpStu);
            }
            return stuList;
        }
        
        public void AddStudent(Student stu)
        {
            string format = "yyyy-MM-dd HH:mm:ss";
            DateTime tempDate = Convert.ToDateTime(stu.NgaySinh.ToString("yyyy-MM-dd"));
            string sql = "INSERT INTO HocSinh(TenHS, NgaySinh, GioiTinh, DiaChi, Email,MaLop) VALUES (N'" + stu.TenHS + "','"+ stu.NgaySinh.ToString(format)+ "',N'" + stu.GioiTinh + "',N'" + stu.DiaChi + "',N'" + stu.Email + "',NULL)";
            SqlConnection con = db.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public void UpdateStudent(Student stu)
        {
            string sql = "UPDATE HocSinh SET TenHS = N'" + stu.TenHS + "',NgaySinh =  N'" + stu.NgaySinh + "',GioiTinh =  N'" + stu.GioiTinh + "', DiaChi = N'" + stu.DiaChi + "',Email =  N'" + stu.Email + "' WHERE MaHS = " + stu.MaHS;
            SqlConnection con = db.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public void DeleteStudent(Student stu)
        {
            string sql = "DELETE FROM HocSinh WHERE MaHS = " + stu.MaHS;
            SqlConnection con = db.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
    }    

}