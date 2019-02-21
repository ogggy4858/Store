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
    public partial class FReportNhanVien : Form
    {
        public FReportNhanVien()
        {
            InitializeComponent();
        }

        private void FReportNhanVien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetSet.proc_Report_NhanVien' table. You can move, or remove it, as needed.
            this.proc_Report_NhanVienTableAdapter.Fill(this.dataSetSet.proc_Report_NhanVien);

            this.reportViewer1.RefreshReport();
        }
    }
}
