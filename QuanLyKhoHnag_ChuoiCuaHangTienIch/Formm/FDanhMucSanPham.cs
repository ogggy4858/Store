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
namespace QuanLyKhoHnag_ChuoiCuaHangTienIch.Formm
{
    public partial class FDanhMucSanPham : Form
    {
        private Exceptionn ex = new Exceptionn();
        long id = 0;

        public FDanhMucSanPham()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.View = View.Details;
            listView1.Columns.Add("ID", 200);
            listView1.Columns.Add("Tên Danh Mục", 350);
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            DTO_DanhMucSanPham sp = new DTO_DanhMucSanPham(tbTen.Text);
            DAO_DanhMucSanPham dao = new DAO_DanhMucSanPham();
            if (ex.KiemTraChuoi(sp.Tendanhmuc, 100))
            {
                dao.Insert(sp);
            }
            else
            {
                MessageBox.Show("Name very long");
            }
            FDanhMucSanPham_Load(sender, e);
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            DTO_DanhMucSanPham sp = new DTO_DanhMucSanPham(tbTen.Text);
            sp.ID = id;
            DAO_DanhMucSanPham dao = new DAO_DanhMucSanPham();
            if (id != 0)
            {
                if (ex.KiemTraChuoi(sp.Tendanhmuc, 100))
                {
                    dao.Update(sp);
                }
                else
                {
                    MessageBox.Show("Name very long");
                }
            }
            else
            {

            }
            FDanhMucSanPham_Load(sender, e);
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            DTO_DanhMucSanPham sp = new DTO_DanhMucSanPham();
            sp.ID = id;
            DAO_DanhMucSanPham dao = new DAO_DanhMucSanPham();
            if (id != 0)
            {
                dao.Delete(sp);
            }
            else
            {

            }
            FDanhMucSanPham_Load(sender, e);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FDanhMucSanPham_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            DAO_DanhMucSanPham dao = new DAO_DanhMucSanPham();
            List<DTO_DanhMucSanPham> list = new List<DTO_DanhMucSanPham>();
            list = dao.Load();
            foreach(var item in list)
            {
                ListViewItem it = new ListViewItem(item.ID.ToString());
                it.SubItems.Add(item.Tendanhmuc);
                listView1.Items.Add(it);
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            tbTen.Text = listView1.SelectedItems[0].SubItems[1].Text;
            id = Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text);
        }

        private void FDanhMucSanPham_FormClosing(object sender, FormClosingEventArgs e)
        {
            FMain f = new FMain();
            f.Show();
        }
    }
}
