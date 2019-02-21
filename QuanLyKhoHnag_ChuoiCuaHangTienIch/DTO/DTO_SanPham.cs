using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHnag_ChuoiCuaHangTienIch.DTO
{
    public class DTO_SanPham
    {
        private long iD;
        private string tensanpham;
        private int soluong;
        private string donvi;
        private DateTime ngaythem;
        private DateTime ngaysanxuat;
        private DateTime hansudung;
        private string hinhanh;
        private long danhmucID;
        private double gia;

        public long ID { get => iD; set => iD = value; }
        public string Tensanpham { get => tensanpham; set => tensanpham = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public string Donvi { get => donvi; set => donvi = value; }
        public DateTime Ngaythem { get => ngaythem; set => ngaythem = value; }
        public DateTime Ngaysanxuat { get => ngaysanxuat; set => ngaysanxuat = value; }
        public DateTime Hansudung { get => hansudung; set => hansudung = value; }
        public string Hinhanh { get => hinhanh; set => hinhanh = value; }
        public long DanhmucID { get => danhmucID; set => danhmucID = value; }
        public double Gia { get => gia; set => gia = value; }

        public DTO_SanPham(string tensanpham, int soluong, string donvi, DateTime ngaythem, DateTime ngaysanxuat, DateTime hansudung, string hinhanh, double gia,long danhmucID)
        {
  
            Tensanpham = tensanpham;
            Soluong = soluong;
            Donvi = donvi;
            Ngaythem = ngaythem;
            Ngaysanxuat = ngaysanxuat;
            Hansudung = hansudung;
            Hinhanh = hinhanh;
            DanhmucID = danhmucID;
            Gia = gia;
        }

        public DTO_SanPham()
        { }
        public DTO_SanPham(DataRow row)
        {
            ID = Convert.ToInt32(row["iD"]);
            Tensanpham = row["tensanpham"].ToString();
            Soluong = Convert.ToInt32(row["soluong"]);
            Donvi = row["donvi"].ToString();
            Ngaythem = Convert.ToDateTime(row["ngaythem"]);
            Ngaysanxuat = Convert.ToDateTime(row["ngaysanxuat"]);
            Hansudung = Convert.ToDateTime(row["hansudung"]);
            Hinhanh = row["hinhanh"].ToString();
            DanhmucID = Convert.ToInt32(row["DanhMucSanPhamID"]);
            Gia = Convert.ToDouble(row["Gia"]);
        }
    }
}
