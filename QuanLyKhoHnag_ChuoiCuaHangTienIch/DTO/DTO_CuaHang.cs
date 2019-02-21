using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHnag_ChuoiCuaHangTienIch.DTO
{
    public class DTO_CuaHang
    {
        private long iD;
        private string diachi;
        private bool status;

        public long ID { get => iD; set => iD = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public bool Status { get => status; set => status = value; }

        public DTO_CuaHang() { }
        public DTO_CuaHang(string diachi, bool sta)
        {
            this.Diachi = diachi;
            this.Status = sta;
        }
        public DTO_CuaHang(DataRow row)
        {
            this.ID = Convert.ToInt32(row["ID"]);
            this.Diachi = row["DiaChi"].ToString();
            this.Status = Convert.ToBoolean(row["Status"]);
        }
    }
}
