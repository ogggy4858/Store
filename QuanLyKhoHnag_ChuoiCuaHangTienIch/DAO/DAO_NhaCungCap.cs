using QuanLyKhoHnag_ChuoiCuaHangTienIch.DTO;
using QuanLyKhoHnag_ChuoiCuaHangTienIch.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHnag_ChuoiCuaHangTienIch.DAO
{
    public class DAO_NhaCungCap
    {
        private Linq.QuanLyKhoHangDataContext db = new Linq.QuanLyKhoHangDataContext();
        private bool Check(string ten, string diachi)
        {

            var res = db.NhaCungCaps.Where(x => x.Ten == ten && x.DiaChi == diachi).SingleOrDefault();
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
            var res = db.NhaCungCaps.Where(x => x.ID == ID).SingleOrDefault();
            if (res != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable Insert(DTO_NhaCungCap ncc)
        {
            DataTable table = new DataTable();
            if (Check(ncc.Ten, ncc.Diachi))
            { }
            else
            {
                table = Data.Instance.ExecuteQuery("proc_Insert_NCC @ten , @diachi , @SDT ", new object[] { ncc.Ten, ncc.Diachi, ncc.Sdt });
            }
            return table;
        }
        public DataTable Update(DTO_NhaCungCap ncc)
        {
            DataTable table = new DataTable();
            if (CheckWithID(ncc.ID))
            {
                if (Check(ncc.Ten, ncc.Diachi))
                    ;
                else
                    table = Data.Instance.ExecuteQuery("proc_Update_NCC @ten , @diachi , @SDT , @id ", new object[] { ncc.Ten, ncc.Diachi, ncc.Sdt, ncc.ID });
            }
            else
            {

            }
            return table;
        }
        public DataTable Delete(DTO_NhaCungCap ncc)
        {
            DataTable table = new DataTable();
            if (CheckWithID(ncc.ID))
            {
                table = Data.Instance.ExecuteQuery("proc_Delete_NCC @id ", new object[] { ncc.ID });

            }
            else
            {
            }
            return table;
        }
        public List<DTO_NhaCungCap> Load()
        {
            DataTable table = new DataTable();
            table = Data.Instance.ExecuteQuery("select * from NhaCungCap");
            List<DTO_NhaCungCap> list = new List<DTO_NhaCungCap>();
            foreach (DataRow item in table.Rows)
            {
                DTO_NhaCungCap dto = new DTO_NhaCungCap(item);
                list.Add(dto);

            }
            return list;
        }

    }
}
