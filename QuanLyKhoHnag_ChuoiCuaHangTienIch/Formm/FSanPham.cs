using QuanLyKhoHnag_ChuoiCuaHangTienIch.DAO;
using QuanLyKhoHnag_ChuoiCuaHangTienIch.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhoHnag_ChuoiCuaHangTienIch.Formm
{
    public partial class FSanPham : Form
    {
        private string HinhAnh = "";
        private long id = 0;

        public FSanPham()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            DAO_SanPham sp = new DAO_SanPham();
            listView1.FullRowSelect = true;
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.Columns.Add("ID");
            listView1.Columns.Add("Tên Sản Phẩm", 120);
            listView1.Columns.Add("Đơn Giá", 80);
            listView1.Columns.Add("Số Lượng");
            listView1.Columns.Add("Đơn Vị");
            listView1.Columns.Add("Ngày Thêm", 90);
            listView1.Columns.Add("NSX", 90);
            listView1.Columns.Add("HSD", 90);
            listView1.Columns.Add("Danh Mục", 120);
            cbbDanhMuc.DataSource = sp.Combobox();
            cbbDanhMuc.DisplayMember = "TenDanhMuc";
            cbbDanhMuc.ValueMember = "ID";
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            DAO_SanPham dao = new DAO_SanPham();
            if (HinhAnh == "")
            {
                MessageBox.Show("Please Select Image");
            }
            else
            {
                Exceptionn ex = new Exceptionn();

                if (ex.KiemTraChuoi(new string[] { tbTen.Text, tbDonVi.Text }, new int[] { 100, 100 })
                    && ex.KiemTraSoLuong(tbSoLuong.Text, 999999999) && ex.KiemTraSoLuong(tbDonGia.Text, 10 ^ 37))
                {
                    DTO_SanPham dto = new DTO_SanPham(tbTen.Text, Convert.ToInt32(tbSoLuong.Text), tbDonVi.Text,
                        Convert.ToDateTime(dtpNgayThem.Text), Convert.ToDateTime(dtpNgaySanXuat.Text),
                        Convert.ToDateTime(dtpHanSuDung.Text), HinhAnh, Convert.ToDouble(tbDonGia.Text),Convert.ToInt32(cbbDanhMuc.SelectedValue));
                    dao.Insert(dto);
                }
            }
            FSanPham_Load(sender, e);
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            DAO_SanPham dao = new DAO_SanPham();
            if (HinhAnh == "")
            {
                MessageBox.Show("Please Select Image");
            }
            else
            {
                Exceptionn ex = new Exceptionn();
                if (ex.KiemTraChuoi(new string[] { tbTen.Text, tbDonVi.Text }, new int[] { 100, 100 })
                   && ex.KiemTraSoLuong(tbSoLuong.Text, 999999999) && ex.KiemTraSoLuong(tbDonGia.Text, 10 ^ 37))
                {
                    DTO_SanPham dto = new DTO_SanPham(tbTen.Text, Convert.ToInt32(tbSoLuong.Text), tbDonVi.Text,
                    Convert.ToDateTime(dtpNgayThem.Text), Convert.ToDateTime(dtpNgaySanXuat.Text),
                    Convert.ToDateTime(dtpHanSuDung.Text),HinhAnh, Convert.ToDouble(tbDonGia.Text) ,Convert.ToInt32(cbbDanhMuc.SelectedValue));
                    dto.ID = id;
                    dao.Update(dto);
                }
            }
            FSanPham_Load(sender, e);
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            DAO_SanPham dao = new DAO_SanPham();
            DTO_SanPham sp = new DTO_SanPham();
            sp.ID = id;
            if (sp.ID != 0)
            {
                dao.Delete(sp);
                tbTen.Text = "";
                tbSoLuong.Text = "";
                tbDonVi.Text = "";
                dtpHanSuDung.Text = DateTime.Now.ToString();
                dtpNgaySanXuat.Text = DateTime.Now.ToString();
                dtpNgayThem.Text = DateTime.Now.ToString();
                HinhAnh = "";
                tbDonGia.Text = "";
                cbbDanhMuc.Text = "";
                pictureBox1.Image = null;
                FSanPham_Load(sender, e);

            }
            else
            {

            }
    
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            //FMain f = new FMain();
            //f.Show();
            this.Close();
        }

        private void FSanPham_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            DAO_SanPham sp = new DAO_SanPham();
            List<DTO_SanPham> list = new List<DTO_SanPham>();
            list = sp.List();
            foreach(var item in list)
            {
                ListViewItem it = new ListViewItem(item.ID.ToString());
                it.SubItems.Add(item.Tensanpham);
                it.SubItems.Add(item.Gia.ToString());
                it.SubItems.Add(item.Soluong.ToString());
                it.SubItems.Add(item.Donvi.ToString());
                it.SubItems.Add(item.Ngaythem.ToString());
                it.SubItems.Add(item.Ngaysanxuat.ToString());
                it.SubItems.Add(item.Hansudung.ToString());
                object table = Data.Instance.ExecuteScalar("select TenDanhMuc from DanhMucSanPham where ID = @id ", new object[] { item.DanhmucID });
                string danhmuc = table.ToString();
                it.SubItems.Add(danhmuc);
                listView1.Items.Add(it);
            }

        }

        private void btHinhAnh_Click(object sender, EventArgs e)
        {

            OpenFileDialog open = new OpenFileDialog();
            //For any other formats
            open.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";

            if (open.ShowDialog() == DialogResult.OK)
            {
                if (open.CheckPathExists)
                {
                    string Name = System.IO.Path.GetFileName(open.FileName);
                    string NewName = "H:\\project\\c#\\Wfrom\\QuanLyKhoHnag_ChuoiCuaHangTienIch\\QuanLyKhoHnag_ChuoiCuaHangTienIch\\Image\\" + Name;
                    if (System.IO.File.Exists(NewName))
                    {
                        
                    }
                    else
                    {
                        System.IO.File.Copy(open.FileName, NewName);
                    }
                    HinhAnh = Name;
                    pictureBox1.Image = Image.FromFile(NewName) ;
                }
                else
                {

                }
            }
           // @"H:\project\c#\Wform\QuanLyKhoHnag_ChuoiCuaHangTienIch\Image\
        }

        private void FSanPham_FormClosing(object sender, FormClosingEventArgs e)
        {
            FMain f = new FMain();
            f.Show();
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
         
            DAO_SanPham sp = new DAO_SanPham();
                
            var ten = listView1.SelectedItems[0].SubItems[1].Text;
            var  sl = listView1.SelectedItems[0].SubItems[3].Text;
            var  dv = listView1.SelectedItems[0].SubItems[4].Text;
            var  nt = listView1.SelectedItems[0].SubItems[5].Text;
            var nsx = listView1.SelectedItems[0].SubItems[6].Text;
            var hsd = listView1.SelectedItems[0].SubItems[7].Text;
            var cbb = listView1.SelectedItems[0].SubItems[8].Text;
            var dg = listView1.SelectedItems[0].SubItems[2].Text;
            tbTen.Text = ten;
            tbSoLuong.Text = sl;
            tbDonVi.Text = dv;
            dtpNgayThem.Text = nt;
            dtpNgaySanXuat.Text = nsx;
            dtpHanSuDung.Text = hsd;
            cbbDanhMuc.Text = cbb;
            tbDonGia.Text = dg;
            id = Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text);
            QuanLyKhoHnag_ChuoiCuaHangTienIch.Linq.QuanLyKhoHangDataContext db = new Linq.QuanLyKhoHangDataContext();
            var res = db.SanPhams.SingleOrDefault(x => x.ID == id);
            HinhAnh = res.HinhAnh;
            string imageName = sp.GetImageName(Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text)).ToString();
            pictureBox1.Image = Image.FromFile("H:\\project\\c#\\Wfrom\\QuanLyKhoHnag_ChuoiCuaHangTienIch\\QuanLyKhoHnag_ChuoiCuaHangTienIch\\Image\\" + imageName);
            //string SDT = listView1.SelectedItems[0].SubItems[3].Text;
        }
    }
}
