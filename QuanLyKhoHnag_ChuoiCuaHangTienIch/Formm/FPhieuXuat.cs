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
    public partial class FPhieuXuat : Form
    {
        public FPhieuXuat()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.View = View.Details;
            listView1.Columns.Add("Sản Phẩm", 200);
            listView1.Columns.Add("Số Lượng", 200);
        }

        private void FPhieuXuat_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Data.Instance.ExecuteQuery("proc_ChiTietPhieuXuat");
        }
    }
}
