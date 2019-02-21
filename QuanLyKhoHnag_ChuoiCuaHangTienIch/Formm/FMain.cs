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
using QuanLyKhoHnag_ChuoiCuaHangTienIch.Linq;
namespace QuanLyKhoHnag_ChuoiCuaHangTienIch.Formm
{
    public partial class FMain : Form
    {
        private long idDanhmuc = 0;
        private long idSanPham = 0;
        private QuanLyKhoHangDataContext db;

        public FMain()
        {
            InitializeComponent();
            Init();
        }
        #region Button click And Menu Click

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FNhanVien f = new FNhanVien();
            this.Hide();
            f.Show();
        }

        private void nhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FReportNhanVien nv = new FReportNhanVien();
            this.Hide();
            nv.Show();
        }

        private void nhậpHàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FNhaCungCap ncc = new FNhaCungCap();
            this.Hide();
            ncc.ShowDialog();

        }

        private void cửaHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FCuaHang f = new FCuaHang();
            this.Hide();
            f.ShowDialog();
        }

        private void btThemSanPham_Click(object sender, EventArgs e)
        {
            FSanPham f = new FSanPham();
            this.Hide();
            f.Show();
        }

        private void btThemDanhMuc_Click(object sender, EventArgs e)
        {
            FDanhMucSanPham f = new FDanhMucSanPham();
            this.Hide();
            f.Show();
        }

        private void FMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
            Application.Exit();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FSanPham f = new FSanPham();
            this.Hide();
            f.Show();
        }

        private void danhMụcSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FDanhMucSanPham f = new FDanhMucSanPham();
            this.Hide();
            f.Show();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region FormLoad and Init

        private void FMain_Load(object sender, EventArgs e)
        {
            DAO_SanPham sp = new DAO_SanPham();
            DAO_Main main = new DAO_Main();
            List<DTO_SanPham> list = new List<DTO_SanPham>();

            if (cbbDanhMuc.Text == "" && cbbSanPham.Text == "")
            {
                lv.Items.Clear();
                list = main.ListSP();
                foreach (var item in list)
                {
                    ListViewItem it = new ListViewItem(item.ID.ToString());
                    it.SubItems.Add(item.Tensanpham);
                    it.SubItems.Add(item.Soluong.ToString());
                    it.SubItems.Add(item.Donvi.ToString());
                    it.SubItems.Add(item.Ngaythem.ToString());
                    it.SubItems.Add(item.Ngaysanxuat.ToString());
                    it.SubItems.Add(item.Hansudung.ToString());
                    object table = Data.Instance.ExecuteScalar("select TenDanhMuc from DanhMucSanPham where ID = @id ", new object[] { item.DanhmucID });
                    string danhmuc = table.ToString();
                    it.SubItems.Add(danhmuc);
                    lv.Items.Add(it);
                }
            }
            else if (cbbDanhMuc.Text != "" && cbbSanPham.Text == "")
            {
                lv.Items.Clear();
                list = main.ListSP_DanhMuc(idDanhmuc);
                foreach (var item in list)
                {
                    ListViewItem it = new ListViewItem(item.ID.ToString());
                    it.SubItems.Add(item.Tensanpham);
                    it.SubItems.Add(item.Soluong.ToString());
                    it.SubItems.Add(item.Donvi.ToString());
                    it.SubItems.Add(item.Ngaythem.ToString());
                    it.SubItems.Add(item.Ngaysanxuat.ToString());
                    it.SubItems.Add(item.Hansudung.ToString());
                    object table = Data.Instance.ExecuteScalar("select TenDanhMuc from DanhMucSanPham where ID = @id ", new object[] { item.DanhmucID });
                    string danhmuc = table.ToString();
                    it.SubItems.Add(danhmuc);
                    lv.Items.Add(it);
                }

            }
            else if (cbbDanhMuc.Text != "" && cbbSanPham.Text != "")
            {
                lv.Items.Clear();
                list = main.ListSP_DanhMuc_SanPham(idSanPham);
                foreach (var item in list)
                {
                    ListViewItem it = new ListViewItem(item.ID.ToString());
                    it.SubItems.Add(item.Tensanpham);
                    it.SubItems.Add(item.Soluong.ToString());
                    it.SubItems.Add(item.Donvi.ToString());
                    it.SubItems.Add(item.Ngaythem.ToString());
                    it.SubItems.Add(item.Ngaysanxuat.ToString());
                    it.SubItems.Add(item.Hansudung.ToString());
                    object table = Data.Instance.ExecuteScalar("select TenDanhMuc from DanhMucSanPham where ID = @id ", new object[] { item.DanhmucID });
                    string danhmuc = table.ToString();
                    it.SubItems.Add(danhmuc);
                    lv.Items.Add(it);
                }

            }


        }

        private void Init()
        {
            DAO_SanPham sp = new DAO_SanPham();
            DAO_Main main = new DAO_Main();
            lv.FullRowSelect = true;
            lv.View = View.Details;
            lv.GridLines = true;
            lv.Columns.Add("ID");
            lv.Columns.Add("Tên Sản Phẩm", 120);
            lv.Columns.Add("Số Lượng", 100);
            lv.Columns.Add("Đơn Vị", 90);
            lv.Columns.Add("Ngày Thêm", 120);
            lv.Columns.Add("NSX", 120);
            lv.Columns.Add("HSD", 120);
            lv.Columns.Add("Danh Mục", 125);
            cbbDanhMuc.Text = "";
            cbbSanPham.Text = "";
        }

        #endregion

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }



        private void btThemVaoPhieuXuat_Click(object sender, EventArgs e)
        {

        }

        private void btChiTiet_Click(object sender, EventArgs e)
        {

        }


        private void btTimKiem_Click(object sender, EventArgs e)
        {

        }

        private void lv_MouseClick(object sender, MouseEventArgs e)
        {
            db = new QuanLyKhoHangDataContext();
            string href = "H:\\project\\c#\\Wfrom\\QuanLyKhoHnag_ChuoiCuaHangTienIch\\QuanLyKhoHnag_ChuoiCuaHangTienIch\\Image\\";
            var id = Convert.ToInt32(lv.SelectedItems[0].SubItems[0].Text);
     
            var hr = db.SanPhams.SingleOrDefault(x => x.ID == id);
            pictureBox1.Image = Image.FromFile(href + hr.HinhAnh);
        }

        #region Combobox Event

        private void cbbDanhMuc_MouseClick(object sender, MouseEventArgs e)
        {
            if (cbbDanhMuc.Text == "")
            {
                DAO_SanPham sp = new DAO_SanPham();
                cbbDanhMuc.DataSource = sp.Combobox();
                cbbDanhMuc.DisplayMember = "TenDanhMuc";
                cbbDanhMuc.ValueMember = "ID";
            }
            else
            { }
        }

        private void cbbDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbDanhMuc.SelectedValue.ToString() == "System.Data.DataRowView")
            { }
            else
            {
                var id = cbbDanhMuc.SelectedValue.ToString();
                idDanhmuc = Convert.ToInt32(id);
                FMain_Load(sender, e);
            }
            DAO_Main main = new DAO_Main();
            cbbSanPham.DataSource = main.ListSP_DanhMuc(idDanhmuc);
            if (main.ListSP_DanhMuc(idDanhmuc).Count() == 0)
            {
                cbbSanPham.Text = "";
                lbSoLuong.Text = "0";
                lv.Items.Clear();
            }
            else
            {
                
                cbbSanPham.DisplayMember = "TenSanPham";
                cbbSanPham.ValueMember = "ID";
                var id = cbbSanPham.SelectedValue.ToString();
                idSanPham = Convert.ToInt32(id);
                int soluong = main.SoLuong(idSanPham);
                lbSoLuong.Text = soluong.ToString();

                db = new QuanLyKhoHangDataContext();
                string href = "H:\\project\\c#\\Wfrom\\QuanLyKhoHnag_ChuoiCuaHangTienIch\\QuanLyKhoHnag_ChuoiCuaHangTienIch\\Image\\";
                var sanpham = db.SanPhams.SingleOrDefault(x => x.ID == idSanPham);
                pictureBox1.Image = Image.FromFile(href + sanpham.HinhAnh);
            }
        }

        private void cbbSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbSanPham.SelectedValue.ToString() == "System.Data.DataRowView")
            { }
            else if (cbbSanPham.SelectedValue.ToString() == "QuanLyKhoHnag_ChuoiCuaHangTienIch.DTO.DTO_SanPham")
            { }
            else
            {
                var id = cbbSanPham.SelectedValue.ToString();
                idSanPham = Convert.ToInt32(id);
                DAO_Main main = new DAO_Main();
                int soluong = main.SoLuong(idSanPham);
                lbSoLuong.Text = soluong.ToString();
                FMain_Load(sender, e);

                db = new QuanLyKhoHangDataContext();
                string href = "H:\\project\\c#\\Wfrom\\QuanLyKhoHnag_ChuoiCuaHangTienIch\\QuanLyKhoHnag_ChuoiCuaHangTienIch\\Image\\";
                var sanpham = db.SanPhams.SingleOrDefault(x => x.ID == idSanPham);
                pictureBox1.Image = Image.FromFile(href + sanpham.HinhAnh);
            }
        }

        private void cbbDanhMuc_MouseCaptureChanged(object sender, EventArgs e)
        {

        }

        private void cbbDanhMuc_Enter(object sender, EventArgs e)
        {

        }

        private void cbbDanhMuc_KeyPress(object sender, KeyPressEventArgs e)
        {
           

        }

        private void cbbSanPham_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void cbbDanhMuc_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void cbbSanPham_KeyDown(object sender, KeyEventArgs e)
        {
         
        }

        private void cbbDanhMuc_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void cbbSanPham_KeyUp(object sender, KeyEventArgs e)
        {
          
        }


        #endregion

    

        private void sảnPhẩmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //FReport_SanPham sp = new FReport_SanPham();
            //sp.Show();
        }

        private void xuấtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FPhieuNhap f = new FPhieuNhap();
            this.Hide();
            f.Show();
        }

        private void hàngTồnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FPhieuXuat f = new FPhieuXuat();
            this.Hide();
            f.Show();
        }
    }
}
