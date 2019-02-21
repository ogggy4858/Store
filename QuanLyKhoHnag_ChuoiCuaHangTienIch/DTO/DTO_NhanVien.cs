using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHnag_ChuoiCuaHangTienIch.DTO
{
    public class DTO_NhanVien
    {
        private long iD;
        private string hoten;
        private string diachi;
        private string tentaikhoan;
        private string matkhau;
        private int sDT;
        private DateTime ngaybatdaulam;
        private DateTime ngayketthuc;
        private int songaycong;
        private int phanQuyenID;

        public DTO_NhanVien(string ht, string dc, int sdt, DateTime nbd, DateTime nkt, int pq)
        {
            this.Hoten = ht;
            this.Diachi = dc;
            this.SDT = sDT;
            this.Ngaybatdaulam = nbd;
            this.Ngayketthuc = nkt;
            this.PhanQuyenID = pq;
    
        }

        public DTO_NhanVien()
        {

        }

        public DTO_NhanVien(DataRow row)
        {
            this.ID = Convert.ToInt32(row["ID"]);
            this.Hoten = row["HoTen"].ToString();
            this.Diachi = row["DiaChi"].ToString();
            this.SDT = Convert.ToInt32(row["SDT"]);
            this.Ngaybatdaulam = Convert.ToDateTime(row["NgayBatDauLam"]);
            if (DBNull.Value == row["NgayKetThuc"])
            {

            }
            else
            {
                this.Ngayketthuc = Convert.ToDateTime(row["NgayKetThuc"]);
            }
            this.PhanQuyenID = Convert.ToInt32(row["PHanQuyenID"]);
        }

        public string Hoten { get => hoten; set => hoten = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public int SDT { get => sDT; set => sDT = value; }
        public DateTime Ngaybatdaulam { get => ngaybatdaulam; set => ngaybatdaulam = value; }
        public DateTime Ngayketthuc { get => ngayketthuc; set => ngayketthuc = value; }
        public int Songaycong { get => songaycong; set => songaycong = value; }
        public int PhanQuyenID { get => phanQuyenID; set => phanQuyenID = value; }
        public string Tentaikhoan { get => tentaikhoan; set => tentaikhoan = value; }
        public string Matkhau { get => matkhau; set => matkhau = value; }
        public long ID { get => iD; set => iD = value; }
    }
}
