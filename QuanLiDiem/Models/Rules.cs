using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QuanLiDiem.Models
{
    public class Rules
    {
        [Display(Name = "Mã quyền")]

        public int MaQuyen { set; get; }
        [Display(Name = "Tên quyền")]
        public string TenQuyen { set; get; }
        [Display(Name = "Trạng thái")]

        public bool TrangThai { set; get; }
        [Display(Name = "Trang học sinh")]

        public string HocSinh { set; get; }
        [Display(Name = "Trang lớp học")]

        public string LopHoc { set; get; }
        [Display(Name = "Trang môn học")]

        public string MonHoc { set; get; }
        [Display(Name = "Trang bảng điểm")]

        public string BangDiem { set; get; }
        [Display(Name = "Trang báo cáo")]

        public string BaoCao { set; get; }
        [Display(Name = "Trang người dùng")]

        public string NguoiDung { set; get; }


    }
    class RulesList
    {
        DBConnection db;
        public RulesList()
        {
            db = new DBConnection();
        }
        public List<Rules> getRules(string ID)
        {

            string sql;
            if (string.IsNullOrEmpty(ID))
                sql = "SELECT* FROM Quyen";
            else
                sql = "SELECT* FROM Quyen WHERE MaQuyen =" + ID;

            List<Rules> stuList = new List<Rules>();
            DataTable dt = new DataTable();
            SqlConnection con = db.GetConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con.Open();
            da.Fill(dt);
            da.Dispose();
            con.Close();
            Rules tmpStu;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tmpStu = new Rules();
                tmpStu.MaQuyen = Convert.ToInt32(dt.Rows[i]["MaQuyen"].ToString());
                tmpStu.TenQuyen = dt.Rows[i]["TenQuyen"].ToString();
                tmpStu.TrangThai = Convert.ToBoolean(dt.Rows[i]["TrangThai"].ToString());
                tmpStu.HocSinh = dt.Rows[i]["HocSinh"].ToString();
                tmpStu.LopHoc = dt.Rows[i]["LopHoc"].ToString();
                tmpStu.MonHoc = dt.Rows[i]["MonHoc"].ToString();
                tmpStu.BangDiem = dt.Rows[i]["BangDiem"].ToString();
                tmpStu.BaoCao = dt.Rows[i]["BaoCao"].ToString();
                tmpStu.NguoiDung = dt.Rows[i]["NguoiDung"].ToString();



                stuList.Add(tmpStu);
            }
            return stuList;
        }
    }
    }