using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QuanLiDiem.Models
{
    public class Subjects
    {

        public int MaMH { set; get; }
        [Required(ErrorMessage = "Mời nhập tên môn học")]
        [Display(Name = "Tên môn học")]
        public string TenMH { set; get; }
        [Display(Name = "Khối")]
        public string Khoi { set; get; }
    }
    class SubjectsList
    {
        DBConnection db;
        public SubjectsList()
        {
            db = new DBConnection();
        }
        public List<Subjects> getSubjects(string ID)
        {

            string sql;
            if (string.IsNullOrEmpty(ID))
                sql = "SELECT* FROM MonHoc";
            else
                sql = "SELECT* FROM MonHoc WHERE MonHoc =" + ID;

            List<Subjects> stuList = new List<Subjects>();
            DataTable dt = new DataTable();
            SqlConnection con = db.GetConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con.Open();
            da.Fill(dt);
            da.Dispose();
            con.Close();
            Subjects tmpStu;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tmpStu = new Subjects();
                tmpStu.MaMH = Convert.ToInt32(dt.Rows[i]["MaMH"].ToString());
                tmpStu.TenMH = dt.Rows[i]["TenMH"].ToString();
                tmpStu.Khoi = dt.Rows[i]["Khoi"].ToString();

                stuList.Add(tmpStu);
            }
            return stuList;
        }


    }
}