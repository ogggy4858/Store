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
    public partial class FNhaCungCap : Form
    {
        private int ID;
        private Exceptionn ex = new Exceptionn();

        public FNhaCungCap()
        {
            InitializeComponent();
            khoitao();
        }
        private void khoitao()
        {
            listView1.FullRowSelect = true;
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.Columns.Add("ID", 100);
            listView1.Columns.Add("Tên Nhà Cung Cấp", 150);
            listView1.Columns.Add("Địa Chỉ", 200);
            listView1.Columns.Add("SĐT", 100);

        }

        private void btThem_Click(object sender, EventArgs e)
        {
            DAO_NhaCungCap dao = new DAO_NhaCungCap();

            if (ex.KiemTraChuoi(tbTen.Text, 100) && ex.KiemTraChuoi(tbDiaChi.Text, 500))
            {
                if (ex.KiemTraSoLuong(tbSDT.Text, 11))
                {
                    DTO_NhaCungCap dto = new DTO_NhaCungCap(tbTen.Text, tbDiaChi.Text, Convert.ToInt32(tbSDT.Text));
                    dao.Insert(dto);
                    tbTen.Text = "";
                    tbDiaChi.Text = "";
                    tbSDT.Text = "";
                }
                else
                {
                    MessageBox.Show("Nhập Sai SĐT");
                }
            }
            else
            {
                MessageBox.Show("Tên Hoặc Địa Chỉ Quá Dài");
            }

            FNhaCungCap_Load(sender, e);


        }

        private void btSua_Click(object sender, EventArgs e)
        {

            DAO_NhaCungCap dao = new DAO_NhaCungCap();
            if (ex.KiemTraChuoi(tbTen.Text, 100) && ex.KiemTraChuoi(tbDiaChi.Text, 500))
            {
                if (ex.KiemTraSoLuong(tbSDT.Text, 11))
                {
                    DTO_NhaCungCap dto = new DTO_NhaCungCap(tbTen.Text, tbDiaChi.Text, Convert.ToInt32(tbSDT.Text));
                    dto.ID = ID;
                    dao.Update(dto);
                }
                else
                {
                    MessageBox.Show("Nhập Sai SĐT");
                }
            }
            else
            {
                MessageBox.Show("Tên Hoặc Địa Chỉ Quá Dài");
            }
            FNhaCungCap_Load(sender, e);
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            DAO_NhaCungCap dao = new DAO_NhaCungCap();
            DTO_NhaCungCap dto = new DTO_NhaCungCap();
            dto.ID = ID;
            if (ID != 0)
            {
                dao.Delete(dto);
                tbTen.Text = "";
                tbDiaChi.Text = "";
                tbSDT.Text = "";
            }
            else
            {
                MessageBox.Show("Click on Item");
            }
            FNhaCungCap_Load(sender, e);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            FMain f = new FMain();
            f.ShowDialog();
        }

        private void FNhaCungCap_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            List<DTO_NhaCungCap> list = new List<DTO_NhaCungCap>();
            DAO_NhaCungCap dao = new DAO_NhaCungCap();
            list = dao.Load();
            foreach (var item in list)
            {
                ListViewItem it = new ListViewItem(item.ID.ToString());

                it.SubItems.Add(item.Ten);
                it.SubItems.Add(item.Diachi);
                it.SubItems.Add(item.Sdt.ToString());
                listView1.Items.Add(it);
            }
        }

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {


        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            ID = Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text);
            string Name = listView1.SelectedItems[0].SubItems[1].Text;
            string Diachi = listView1.SelectedItems[0].SubItems[2].Text;
            string SDT = listView1.SelectedItems[0].SubItems[3].Text;

            tbTen.Text = Name;
            tbDiaChi.Text = Diachi;
            tbSDT.Text = SDT;
        }

        private void FNhaCungCap_FormClosing(object sender, FormClosingEventArgs e)
        {
            FMain f = new FMain();
            f.Show();
        }
    }
}
