using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKhoHnag_ChuoiCuaHangTienIch.DAO;
namespace QuanLyKhoHnag_ChuoiCuaHangTienIch.Formm
{
    public partial class FPhieuNhap : Form
    {
        public FPhieuNhap()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            lvSanPham.FullRowSelect = true;
            lvSanPham.GridLines = true;
            lvSanPham.View = View.Details;
            lvSanPham.Columns.Add("Tên San Phẩm");
            lvSanPham.Columns.Add("Số Lượng");
        }


        private void FPhieuNhap_Load(object sender, EventArgs e)
        {
            dgvPhieu.DataSource = DAO.Data.Instance.ExecuteQuery("proc_ChiTietPhieuNhap");
            //dgvPhieu.DataSource = DAO.Data.Instance.ExecuteQuery("SELECT DISTINCT dbo.PhieuNhap.ID AS 'Mã Phiếu',  COUNT(*) AS 'Số Sản Phẩm', dbo.PhieuNhap.NgayTao AS 'Ngày Tạo', NhanVien.HoTen AS 'Nhân Viên Lập Phiếu', dbo.NhaCungCap.Ten AS 'Tên Nhà cung Cấp' FROM dbo.ChiTietPhieuNhap INNER JOIN dbo.PhieuNhap ON dbo.ChiTietPhieuNhap.PhieuNhapID = dbo.PhieuNhap.ID INNER JOIN dbo.SanPham ON SanPham.ID = dbo.ChiTietPhieuNhap.SanPhamID INNER JOIN NhanVien ON NhanVien.ID = dbo.ChiTietPhieuNhap.NhanVienID INNER JOIN dbo.NhaCungCap ON NhaCungCap.ID = dbo.ChiTietPhieuNhap.NhaCungCapID GROUP BY  dbo.PhieuNhap.ID, dbo.PhieuNhap.NgayTao, NhanVien.HoTen, dbo.NhaCungCap.Ten");

            dgvChitiet.DataSource = DAO.Data.Instance.ExecuteQuery("proc_ChiTiet_ChiTietPhieuNhap @id ", new object[] { 1});
        }
    }
}
