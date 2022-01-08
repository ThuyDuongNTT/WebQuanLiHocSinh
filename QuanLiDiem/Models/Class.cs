using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QuanLiDiem.Models
{
    public class Class
    {
        public int MaLop { set; get; }
        [Required(ErrorMessage = "Mời nhập tên lớp")]
        [Display(Name = "Tên lớp")]
        public string TenLop { set; get; }
        [Display(Name = "Sỉ Số")]
        public string SiSo { set; get; }
        [Display(Name = "Giáo viên chủ nhiệm")]
        public string MaGVCN { set; get; }
    }
    class ClassList
    {
        DBConnection db;
        public ClassList()
        {
            db = new DBConnection();
        }
        public List<Class> getClass(string ID)
        {

            string sql;
            if (string.IsNullOrEmpty(ID))
                sql = "SELECT* FROM Lop";
            else
                sql = "SELECT* FROM Lop WHERE MaLop =" + ID;

            List<Class> stuList = new List<Class>();
            DataTable dt = new DataTable();
            SqlConnection con = db.GetConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con.Open();
            da.Fill(dt);
            da.Dispose();
            con.Close();
            Class tmpStu;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tmpStu = new Class();
                tmpStu.MaLop = Convert.ToInt32(dt.Rows[i]["MaLop"].ToString());
                tmpStu.TenLop = dt.Rows[i]["TenLop"].ToString();
                tmpStu.SiSo = dt.Rows[i]["SiSo"].ToString();                
                tmpStu.MaGVCN = dt.Rows[i]["MaGVCN"].ToString();

                stuList.Add(tmpStu);
            }
            return stuList;
        }

        public void AddClass(Class stu)
        {
            string sql = "INSERT INTO Lop(TenLop,SiSo, MaGVCN) VALUES (N'" + stu.MaLop + "',N'" + stu.SiSo + "',N'" + stu.MaGVCN + "')";
            SqlConnection con = db.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public void UpdateClass(Class stu)
        {
            int temp1 = Convert.ToInt32(stu.SiSo);
            int temp2 = Convert.ToInt32(stu.MaGVCN);

            string sql = "UPDATE Lop SET TenLop = N'" + stu.TenLop + "',SiSo = " + temp1 + ",MaGVCN =  " + temp2 + " WHERE MaLop = " + stu.MaLop;
            SqlConnection con = db.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public void DeleteClass(Class stu)
        {
            string sql = "DELETE Lop WHERE MaLop = " + stu.MaLop;
            SqlConnection con = db.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

    }
}