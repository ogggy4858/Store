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
    public partial class FCuaHang : Form
    {
        private DAO_CuaHang dao = new DAO_CuaHang();
        private Exceptionn ex = new Exceptionn();
        private long ID;

        public FCuaHang()
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
            listView1.Columns.Add("Địa Chỉ", 200);
            listView1.Columns.Add("Trạng Thái", 200);
            comboBox1.Items.Add("Đang Hoạt Động");
            comboBox1.Items.Add("Đã Dừng Hoạt Động");
        }
        private void btThem_Click(object sender, EventArgs e)
        {

            if (comboBox1.Text != null)
            {
                DTO_CuaHang dto;
                if (comboBox1.Text == "Đang Hoạt Động")
                {
                    dto = new DTO_CuaHang(tbTen.Text, true);
                }
                else
                {
                    dto = new DTO_CuaHang(tbTen.Text, false);
                }
                if (ex.KiemTraChuoi(dto.Diachi, 500))
                {
                    dao.Insert(dto);
                }
            }
            FCuaHang_Load(sender, e);
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != null)
            {
                DTO_CuaHang dto = new DTO_CuaHang();
                dto.ID = ID;
                if (comboBox1.Text == "Đang Hoạt Động")
                {
                    dto.Diachi = tbTen.Text;
                    dto.Status = true;
                }
                else
                {
                    dto.Diachi = tbTen.Text;
                    dto.Status = false;
                }
                if (ex.KiemTraChuoi(dto.Diachi, 500))
                {
                    if (ID != 0)
                    {
                        dao.Update(dto);
                    }
                    else
                    {

                    }
                }
            }
            FCuaHang_Load(sender, e);
        }

        private void btXoa_Click(object sender, EventArgs e)
        {

            DTO_CuaHang dto = new DTO_CuaHang();
            dto.ID = ID;
            if (ID != 0)
            {
                dao.Delete(dto);
            }
            else
            {

            }


            FCuaHang_Load(sender, e);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FCuaHang_MouseClick(object sender, MouseEventArgs e)
        {



        }

        private void FCuaHang_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            List<DTO_CuaHang> list = new List<DTO_CuaHang>();
            list = dao.List();
            foreach (var item in list)
            {
                ListViewItem it = new ListViewItem(item.ID.ToString());
                it.SubItems.Add(item.Diachi);
                it.SubItems.Add(item.Status ? "Đang Họat Động" : "Đã Dừng Hoạt Động");
                listView1.Items.Add(it);
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {

            ID = Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text);
            string Name = listView1.SelectedItems[0].SubItems[1].Text;
            tbTen.Text = Name;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[2].Text;
        }

        private void FCuaHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            FMain f = new FMain();
            f.Show();
            e.Cancel = false;
        }
    }
}
