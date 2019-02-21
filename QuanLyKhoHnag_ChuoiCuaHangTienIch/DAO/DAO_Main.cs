using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhoHnag_ChuoiCuaHangTienIch.DTO;
using QuanLyKhoHnag_ChuoiCuaHangTienIch.Linq;
namespace QuanLyKhoHnag_ChuoiCuaHangTienIch.DAO
{
    public class DAO_Main
    {
         

        public List<DTO_SanPham> ListSP()
        {
            DataTable table = new DataTable();
            List<DTO_SanPham> list = new List<DTO_SanPham>();
            table = Data.Instance.ExecuteQuery("select * from SanPham");
            foreach(DataRow item in table.Rows)
            {
                DTO_SanPham sp = new DTO_SanPham(item);
                list.Add(sp);
            }
            return list;
        }
        public List<DTO_SanPham> ListSP_DanhMuc(long id)
        {
            DataTable table = new DataTable();
            List<DTO_SanPham> list = new List<DTO_SanPham>();
            table = Data.Instance.ExecuteQuery("proc_ListSP_DanhMuc @id ",new object[] { id });
            foreach (DataRow item in table.Rows)
            {
                DTO_SanPham sp = new DTO_SanPham(item);
                list.Add(sp);
            }
            return list;
        }
        public List<DTO_SanPham> ListSP_DanhMuc_SanPham(long id)
        {
            DataTable table = new DataTable();
            List<DTO_SanPham> list = new List<DTO_SanPham>();
            table = Data.Instance.ExecuteQuery("proc_ListSP_DanhMuc_SanPham @id ", new object[] { id });
            foreach (DataRow item in table.Rows)
            {
                DTO_SanPham sp = new DTO_SanPham(item);
                list.Add(sp);
            }
            return list;
        }
        public List<string> ListTenDanhMuc()
        {
            QuanLyKhoHangDataContext db = new QuanLyKhoHangDataContext();
            List<string> listt = new List<string>();
            var list = db.DanhMucSanPhams.Where(x => x.ID != 0).ToList();
            return listt;
        }
        public int SoLuong(long id)
        {
            var res = Data.Instance.ExecuteScalar("select SoLuong from SanPham where id = @id ", new object[] { id });
            return Convert.ToInt32(res);
        }
   
    }
}
