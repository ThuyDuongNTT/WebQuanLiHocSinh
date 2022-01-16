using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QuanLiDiem.Models
{
    public class Reports
    {
        [Display(Name = "Mã báo cáo")]

        public int MaBC { set; get; }

        [Display(Name = "Loại báo cáo")]
        public int LoaiBC { set; get; }

        [Display(Name = "Tên loại báo cáo")]
        public string TenLoaiBC { set; get; }

        [Display(Name = "Mã môn học")]

        public int MaMH { set; get; }
        [Display(Name = "Mã lớp")]

        public int MaLop { set; get; }
        [Display(Name = "Sỉ số")]

        public int SoLuongDat { set; get; }
        [Display(Name = "Học kỳ")]

        public int HocKy { set; get; }
    
    }
    class ReportsList
    {
        DBConnection db;
        public ReportsList()
        {
            db = new DBConnection();
        }
        public List<Reports> getReports(string ID)
        {

            string sql;
            if (string.IsNullOrEmpty(ID))
                sql = "SELECT* FROM BaoCaoTK";
            else
                sql = "SELECT* FROM BaoCaoTK WHERE MaBC =" + ID;

            List<Reports> stuList = new List<Reports>();
            DataTable dt = new DataTable();
            SqlConnection con = db.GetConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con.Open();
            da.Fill(dt);
            da.Dispose();
            con.Close();
            Reports tmpStu;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tmpStu = new Reports();
                tmpStu.MaBC = Convert.ToInt32(dt.Rows[i]["MaBC"].ToString());
                tmpStu.LoaiBC = Convert.ToInt32(dt.Rows[i]["LoaiBC"].ToString());
                tmpStu.MaMH = Convert.ToInt32(dt.Rows[i]["MaMH"].ToString());
                tmpStu.MaLop = Convert.ToInt32(dt.Rows[i]["MaLop"].ToString());
                tmpStu.SoLuongDat = Convert.ToInt32(dt.Rows[i]["SoLuongDat"].ToString());
                tmpStu.HocKy = Convert.ToInt32(dt.Rows[i]["HocKy"].ToString());
                if (tmpStu.LoaiBC == 1)
                    tmpStu.TenLoaiBC = "Báo cáo tổng kết môn";
                if (tmpStu.LoaiBC == 2)
                    tmpStu.TenLoaiBC = "Báo cáo tổng kết học kỳ";



                stuList.Add(tmpStu);
            }
            return stuList;
        }
    }
 }