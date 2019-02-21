using QuanLyKhoHnag_ChuoiCuaHangTienIch.DTO;
using QuanLyKhoHnag_ChuoiCuaHangTienIch.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHnag_ChuoiCuaHangTienIch.DAO
{
    class DAO_DangNhap
    {
        public int DangNhap(DTO_NhanVien nhanvien)
        {
            QuanLyKhoHangDataContext db = new QuanLyKhoHangDataContext();
            var nv = db.NhanViens.SingleOrDefault(x => x.TenTaiKhoan == nhanvien.Tentaikhoan);
            if (nv != null)
            {
                if (nv.MatKhau == nhanvien.Matkhau)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return 0;
            }
        }
    }
}
