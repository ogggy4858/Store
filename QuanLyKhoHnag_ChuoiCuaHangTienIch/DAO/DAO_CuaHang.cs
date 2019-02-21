using QuanLyKhoHnag_ChuoiCuaHangTienIch.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHnag_ChuoiCuaHangTienIch.DAO
{
    class DAO_CuaHang
    {
        private Linq.QuanLyKhoHangDataContext db = new Linq.QuanLyKhoHangDataContext();
        private Data data = new Data();
        private Exceptionn ex = new Exceptionn();
        public bool Check(string DiaChi)
        {
            var res = db.CuaHangs.Where(x => x.DiaChi == DiaChi).SingleOrDefault();
            if (res != null)
                return true;
            else
                return false;

        }
        public bool CheckWithID(long id)
        {
            var res = db.CuaHangs.Where(x => x.ID == id).SingleOrDefault();
            if (res != null)
                return true;
            else
                return false;
        }
        public DataTable Insert(DTO_CuaHang dto)
        {
            DataTable table = new DataTable();
            if (Check(dto.Diachi))
            {

            }
            else
            {
                table = data.ExecuteQuery("proc_Insert_CuaHang @diachi , @Status ", new object[] { dto.Diachi, dto.Status });
            }
            return table;
        }
        public DataTable Update(DTO_CuaHang dto)
        {
            DataTable table = new DataTable();
            if (CheckWithID(dto.ID))
            {
                table = data.ExecuteQuery("proc_Update_CuaHang @diachi , @status , @id ", new object[] { dto.Diachi, dto.Status, dto.ID });
            }
            else
            {

            }
            return table;
        }
        public DataTable Delete(DTO_CuaHang dto)
        {
            DataTable table = new DataTable();
            if (CheckWithID(dto.ID))
            {
                table = data.ExecuteQuery("proc_Delete_CuaHang @id ", new object[] { dto.ID });
            }
            else
            {

            }
            return table;
        }
        public List<DTO_CuaHang> List()
        {
            List<DTO_CuaHang> list = new List<DTO_CuaHang>();

            DataTable table = new DataTable();
            table = data.ExecuteQuery("select * from CuaHang");
            foreach (DataRow row in table.Rows)
            {
                DTO_CuaHang dto = new DTO_CuaHang(row);
                list.Add(dto);
            }
            return list;
        }
    }
}
