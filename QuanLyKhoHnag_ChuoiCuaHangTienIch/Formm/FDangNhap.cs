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
using QuanLyKhoHnag_ChuoiCuaHangTienIch.DTO;
using QuanLyKhoHnag_ChuoiCuaHangTienIch.Formm;
namespace QuanLyKhoHnag_ChuoiCuaHangTienIch.Formm
{
    public partial class FDangNhap : Form
    {
        public FDangNhap()
        {
            InitializeComponent();
        }

        private void btDangNhap_Click(object sender, EventArgs e)
        {
            DAO_DangNhap dao = new DAO_DangNhap();
            DTO_NhanVien dto = new DTO_NhanVien();
            dto.Tentaikhoan = tbTenDangNhap.Text;
            dto.Matkhau = tbMatKhau.Text;
            var res = dao.DangNhap(dto);
            if(res == 1)
            {
                FMain f = new FMain();
                f.Show();
                this.Hide();
            }
            else if(res == -1)
            {
                MessageBox.Show("Sai Mat Khau");
            }
            else if(res == 0)
            {
                MessageBox.Show("Khong tim thay ten tai khoan");
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
