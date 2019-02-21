using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHnag_ChuoiCuaHangTienIch.DTO
{
    public class DTO_DanhMucSanPham
    {
        private long iD;
        private string tendanhmuc;

        public long ID { get => iD; set => iD = value; }
        public string Tendanhmuc { get => tendanhmuc; set => tendanhmuc = value; }

        public DTO_DanhMucSanPham( string tendanhmuc)
        {
     
            Tendanhmuc = tendanhmuc;
        }
        public DTO_DanhMucSanPham() { }
        public DTO_DanhMucSanPham(DataRow row)
        {
            ID = Convert.ToInt32(row["ID"]);
            Tendanhmuc = row["TenDanhMuc"].ToString();
        }
    }
}
