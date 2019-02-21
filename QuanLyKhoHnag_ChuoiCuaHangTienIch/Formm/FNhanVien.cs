using QuanLyKhoHnag_ChuoiCuaHangTienIch.DAO;
using QuanLyKhoHnag_ChuoiCuaHangTienIch.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhoHnag_ChuoiCuaHangTienIch.Formm
{
    public partial class FNhanVien : Form
    {
        public FNhanVien()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.View = View.Details;
            listView1.Columns.Add("ID");
            listView1.Columns.Add("Họ Tên");
            listView1.Columns.Add("Địa Chỉ");
            listView1.Columns.Add("SĐT");
            listView1.Columns.Add("Ngày Bắt Đầu Làm");
            listView1.Columns.Add("Ngày Kết Thúc");
            listView1.Columns.Add("Chức Vụ");

        }

        private void FNhanVien_Load(object sender, EventArgs e)
        {
            DAO_NhanVien dao = new DAO_NhanVien();
            List<DTO_NhanVien> list = new List<DTO_NhanVien>();
            list = dao.List();
            foreach(var item in list)
            {
                string NgayKetThuc = "";
                ListViewItem it = new ListViewItem(item.ID.ToString());
                it.SubItems.Add(item.Hoten);
                it.SubItems.Add(item.Diachi);
                it.SubItems.Add(item.SDT.ToString());
                it.SubItems.Add(item.Ngaybatdaulam.ToString());
                if(item.Ngayketthuc.ToString() == "1/1/0001 12:00:00 AM")
                {
                    it.SubItems.Add(NgayKetThuc);
                }
                else
                {
                    it.SubItems.Add(item.Ngayketthuc.ToString());
                }
                string TenQuyen = dao.TenQuyen(item.PhanQuyenID).ToString();
                it.SubItems.Add(TenQuyen);
                listView1.Items.Add(it);
            }

        }

        private void btThem_Click(object sender, EventArgs e)
        {

        }

        private void btSua_Click(object sender, EventArgs e)
        {

        }

        private void btXoa_Click(object sender, EventArgs e)
        {

        }

        private void btThoat_Click(object sender, EventArgs e)
        {

        }

        private void btHinhAnh_Click(object sender, EventArgs e)
        {

        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            DAO_NhanVien dao = new DAO_NhanVien();
            tbHoTen.Text = listView1.SelectedItems[0].SubItems[1].Text;
            tbDiaChi.Text = listView1.SelectedItems[0].SubItems[2].Text;
            tbSDT.Text = listView1.SelectedItems[0].SubItems[3].Text;
            dtpNgayBatDau.Text = listView1.SelectedItems[0].SubItems[4].Text;
            dtpNgayKetThuc.Text = listView1.SelectedItems[0].SubItems[5].Text;
            long ID = Convert.ToInt32(dao.IDPhanQuyen(listView1.SelectedItems[0].SubItems[6].Text));
            cbbPhanQuyen.Text = ID.ToString();

        }
    }
}
