using QuanLyKhoHnag_ChuoiCuaHangTienIch.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhoHnag_ChuoiCuaHangTienIch.Linq;

namespace QuanLyKhoHnag_ChuoiCuaHangTienIch.DAO
{
    class DAO_SanPham
    {
        QuanLyKhoHangDataContext db = new Linq.QuanLyKhoHangDataContext();
        public bool Check(string TenSanPham)
        {
            var res = db.SanPhams.Where(x => x.TenSanPham == TenSanPham).SingleOrDefault();
            if (res != null)
                return true;
            else
                return false;
        }
        public bool CheckWithID(long ID)
        {
            var res = db.SanPhams.Where(x => x.ID == ID).SingleOrDefault();
            if (res != null)
                return true;
            else
                return false;
        }
        public DataTable Insert(DTO_SanPham sp)
        {
            DataTable table = new DataTable();
            if (Check(sp.Tensanpham))
            {
               
            }
            else
            {

                table = Data.Instance.ExecuteQuery("proc_Insert_SanPham @ten , @soluong , @dovi , @ngaythem , @ngaysx , @han , @hinhanh , @gia , @id ", 
                    new object[] {sp.Tensanpham, sp.Soluong, sp.Donvi, sp.Ngaythem, sp.Ngaysanxuat, sp.Hansudung, sp.Hinhanh, sp.Gia,sp.DanhmucID });
            }
            return table;
        }
        public DataTable Update(DTO_SanPham sp)
        {
            DataTable table = new DataTable();
            if(CheckWithID(sp.ID))
            {
                table = Data.Instance.ExecuteQuery("proc_Update_SanPham  @id , @ten , @soluong , @dovi , @ngaythem , @ngaysx , @han , @hinhanh , @gia , @id2 ",
                    new object[] { sp.ID, sp.Tensanpham, sp.Soluong, sp.Donvi, sp.Ngaythem, sp.Ngaysanxuat, sp.Hansudung, sp.Hinhanh, sp.Gia,sp.DanhmucID });
            }
            else { }
            return table;
        }
        public DataTable Delete(DTO_SanPham sp)
        {
            DataTable table = new DataTable();
            if (CheckWithID(sp.ID))
            {
                table = Data.Instance.ExecuteQuery("proc_Delete_SanPham @id ",new object[] { sp.ID });
            }
            else { }
            return table;
        }
        public List<DTO_SanPham> List()
        {
            List<DTO_SanPham> list = new List<DTO_SanPham>();
            DataTable table = Data.Instance.ExecuteQuery("select * from SanPham"); 
            foreach(DataRow row in table.Rows)
            {
                DTO_SanPham sp = new DTO_SanPham(row);
                list.Add(sp);
            }
            return list;
        }
        public DataTable Combobox()
        {
            DataTable table = new DataTable();
            table = Data.Instance.ExecuteQuery("select * from DanhMucSanPham");
            return table;
        }
        public object GetImageName(long id)
        {
            object ob = Data.Instance.ExecuteScalar("select HinhAnh from SanPham where ID = @id ", new object[] {id });
            return ob;
        }
    }
}
