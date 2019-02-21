using QuanLyKhoHnag_ChuoiCuaHangTienIch.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHnag_ChuoiCuaHangTienIch.DAO
{
    public class DAO_NhanVien
    {
        public List<DTO_NhanVien> List()
        {
            List<DTO_NhanVien> list = new List<DTO_NhanVien>();
            DataTable table = new DataTable();
            table = Data.Instance.ExecuteQuery("select * from NhanVien");
            foreach (DataRow row in table.Rows)
            {
               
                DTO_NhanVien li = new DTO_NhanVien(row);

                list.Add(li);
            }
            return list;
        }
        public object TenQuyen(long id)
        {
            var res = new object();
               res = Data.Instance.ExecuteScalar("select ChucVu from PhanQuyen where ID = @id ", new object[] { id });
            return res;
        }
        public object IDPhanQuyen(string ChucVu)
        {
            var res = new object();
            res = Data.Instance.ExecuteScalar("select ID from PhanQuyen where ChucVu = @chucvu ", new object[] { ChucVu });
            return res;
        }
    }

}
