using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHnag_ChuoiCuaHangTienIch.DTO
{
    public class DTO_NhaCungCap
    {
        private long iD;
        private string ten;
        private string diachi;
        private int sdt;

        public int Sdt { get => sdt; set => sdt = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public string Ten { get => ten; set => ten = value; }
        public long ID { get => iD; set => iD = value; }

        public DTO_NhaCungCap() { }
        public DTO_NhaCungCap(string ten, string diachi, int sdt)
        {
            this.Ten = ten;
            this.Diachi = diachi;
            this.Sdt = sdt;
        }
        public DTO_NhaCungCap(DataRow row)
        {
            this.ID = Convert.ToInt64(row["ID"]);
            this.Ten = row["Ten"].ToString();
            this.Diachi = row["DiaChi"].ToString();
            this.Sdt = Convert.ToInt32(row["SDT"]);

        }
    }
}
