using QuanLyKhoHnag_ChuoiCuaHangTienIch.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHnag_ChuoiCuaHangTienIch.DAO
{
    public class DAO_DanhMucSanPham
    {
        private Linq.QuanLyKhoHangDataContext db = new Linq.QuanLyKhoHangDataContext();
        private bool Check(string ten)
        { 
            var res = db.DanhMucSanPhams.Where(x => x.TenDanhMuc == ten).SingleOrDefault();
            if (res != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CheckWithID(long ID)
        {
            var res = db.DanhMucSanPhams.Where(x => x.ID == ID).SingleOrDefault();
            if (res != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable Insert(DTO_DanhMucSanPham ncc)
        {
            DataTable table = new DataTable();
            if (Check(ncc.Tendanhmuc))
            { }
            else
            {
                table = Data.Instance.ExecuteQuery("proc_Insert_DanhMucSanPham @ten ", new object[] { ncc.Tendanhmuc });
            }
            return table;
        }
        public DataTable Update(DTO_DanhMucSanPham ncc)
        {
            DataTable table = new DataTable();
            if (CheckWithID(ncc.ID))
            {
                if (Check(ncc.Tendanhmuc))
                { }
                else
                    table = Data.Instance.ExecuteQuery("proc_Update_DanhMucSanPham @id , @ten ", new object[] { ncc.ID ,ncc.Tendanhmuc });
            }
            else
            {

            }
            return table;
        }
        public DataTable Delete(DTO_DanhMucSanPham ncc)
        {
            DataTable table = new DataTable();
            if (CheckWithID(ncc.ID))
            {
                table = Data.Instance.ExecuteQuery("proc_Delete_DanhMucSanPham @id ", new object[] { ncc.ID });

            }
            else
            {
            }
            return table;
        }
        public List<DTO_DanhMucSanPham> Load()
        {
            DataTable table = new DataTable();
            table = Data.Instance.ExecuteQuery("select * from DanhMucSanPham");
            List<DTO_DanhMucSanPham> list = new List<DTO_DanhMucSanPham>();
            foreach (DataRow item in table.Rows)
            {
                DTO_DanhMucSanPham dto = new DTO_DanhMucSanPham(item);
                list.Add(dto);
            }
            return list;
        }
    }
}
