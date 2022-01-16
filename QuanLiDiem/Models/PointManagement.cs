using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QuanLiDiem.Models
{
    public class PointManagement
    {
        public int MaHS { set; get; }
        public int MaMon { set; get; }
        public int HocKy { set; get; }
        public string NienKhoa { set; get; }

        public float Diem15p { set; get; }

        public float Diem1Tiet { set; get; }
        public float DiemCuoiKy { set; get; }

    }
    class PointManagementList
    {
        DBConnection db;
        public PointManagementList()
        {
            db = new DBConnection();
        }
        public List<PointManagement> getPointManagement(string ID)
        {

            string sql;
            if (string.IsNullOrEmpty(ID))
                sql = "SELECT* FROM Diem";
            else
                sql = "SELECT* FROM Diem WHERE MaMon =" + ID;

            List<PointManagement> stuList = new List<PointManagement>();
            DataTable dt = new DataTable();
            SqlConnection con = db.GetConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con.Open();
            da.Fill(dt);
            da.Dispose();
            con.Close();
            PointManagement tmpStu;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tmpStu = new PointManagement();
                tmpStu.MaHS = Convert.ToInt32(dt.Rows[i]["MaHS"].ToString());
                tmpStu.MaMon = Convert.ToInt32(dt.Rows[i]["MaMon"].ToString());
                tmpStu.HocKy = Convert.ToInt32(dt.Rows[i]["HocKy"].ToString());
                tmpStu.NienKhoa = dt.Rows[i]["NienKhoa"].ToString();
                tmpStu.Diem15p = Convert.ToInt32(dt.Rows[i]["Diem15p"].ToString());
                tmpStu.Diem1Tiet = Convert.ToInt32(dt.Rows[i]["Diem15p"].ToString());
                tmpStu.DiemCuoiKy = Convert.ToInt32(dt.Rows[i]["Diem15p"].ToString());


                stuList.Add(tmpStu);
            }
            return stuList;
        }

        public void AddPointManagement(PointManagement stu)
        {
            string sql = "INSERT INTO Diem(MaHS,MaMon,HocKy,NienKhoa,Diem15p,Diem1Tiet,DiemCuoiKy) VALUES (N'" + stu.MaHS + "',N'" + stu.MaMon + "',N'" + stu.HocKy + "',N'" + stu.NienKhoa + "',N'" + stu.Diem15p + "',N'" + stu.Diem1Tiet + "',N'" + stu.DiemCuoiKy + "')";
            SqlConnection con = db.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public void UpdatePointManagement(PointManagement stu)
        {
            int hocky = Convert.ToInt32(stu.HocKy);
            int Diem15p = Convert.ToInt32(stu.Diem15p);
            int Diem1Tiet = Convert.ToInt32(stu.Diem1Tiet);
            int DiemCuoiKy = Convert.ToInt32(stu.DiemCuoiKy);

            string sql = "UPDATE Diem SET Diem15p = "  +Diem15p+ ",Diem1Tiet = " + Diem1Tiet + ",DiemCuoiKy =  " + DiemCuoiKy + " WHERE MaHS = " + stu.MaHS +"and MaMon = "+stu.MaMon;
            SqlConnection con = db.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public void DeletePointManagement(PointManagement stu)
        {
            string sql = "DELETE Diem WHERE MaHS = " + stu.MaHS +"and MaMon ="+stu.MaMon;
            SqlConnection con = db.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

    }
}