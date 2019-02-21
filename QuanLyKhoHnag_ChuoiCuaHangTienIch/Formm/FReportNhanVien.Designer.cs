namespace QuanLyKhoHnag_ChuoiCuaHangTienIch.Formm
{
    partial class FReportNhanVien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSetSet = new QuanLyKhoHnag_ChuoiCuaHangTienIch.Linq.DataSetSet();
            this.procReportNhanVienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.proc_Report_NhanVienTableAdapter = new QuanLyKhoHnag_ChuoiCuaHangTienIch.Linq.DataSetSetTableAdapters.proc_Report_NhanVienTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.procReportNhanVienBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.procReportNhanVienBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyKhoHnag_ChuoiCuaHangTienIch.Report.NhanVien.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1264, 576);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataSetSet
            // 
            this.dataSetSet.DataSetName = "DataSetSet";
            this.dataSetSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // procReportNhanVienBindingSource
            // 
            this.procReportNhanVienBindingSource.DataMember = "proc_Report_NhanVien";
            this.procReportNhanVienBindingSource.DataSource = this.dataSetSet;
            // 
            // proc_Report_NhanVienTableAdapter
            // 
            this.proc_Report_NhanVienTableAdapter.ClearBeforeFill = true;
            // 
            // FReportNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 576);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FReportNhanVien";
            this.Text = "Report Nhân Viên";
            this.Load += new System.EventHandler(this.FReportNhanVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSetSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.procReportNhanVienBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Linq.DataSetSet dataSetSet;
        private System.Windows.Forms.BindingSource procReportNhanVienBindingSource;
        private Linq.DataSetSetTableAdapters.proc_Report_NhanVienTableAdapter proc_Report_NhanVienTableAdapter;
    }
}