using QLyKTX.BUS;
using QLyKTX.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLyKTX.GUI
{
    public partial class GiaoDien : Form
    {
        public GiaoDien()
        {
            InitializeComponent();
        }
        NhanVienBUS qlnv = new NhanVienBUS();
        PhongKTXBUS qlp = new PhongKTXBUS();
        SinhVienBUS qlsv = new SinhVienBUS();
        HoaDonTPBUS qltp = new HoaDonTPBUS();
        private void GiaoDien_Load(object sender, EventArgs e)
        {
            loadDataNhanVien();
            loadPhongKTX();
            loadSinhVien();
            loadHoaDonTP();
        }
 //QUẢN LÝ NHÂN VIÊN 
        private void loadDataNhanVien()
        {
            dvgNhanVien.DataSource = qlnv.getNV();

        }
        
        private void dvgNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int dong;
                dong = e.RowIndex;
                this.txtMaNV.Text = dvgNhanVien.Rows[dong].Cells[0].Value.ToString();
                this.txtTenNV.Text = dvgNhanVien.Rows[dong].Cells[1].Value.ToString();
                this.txtGioiTinhNv.Text = dvgNhanVien.Rows[dong].Cells[2].Value.ToString();
                this.dtNsinhNv.Text = dvgNhanVien.Rows[dong].Cells[3].Value.ToString();
                this.mtbNv.Text = dvgNhanVien.Rows[dong].Cells[4].Value.ToString();
                this.txtQueQuanNv.Text = dvgNhanVien.Rows[dong].Cells[5].Value.ToString();
                this.txtChucVuNv.Text = dvgNhanVien.Rows[dong].Cells[6].Value.ToString();
                this.txtTaiKhoanNv.Text = dvgNhanVien.Rows[dong].Cells[7].Value.ToString();
                this.txtMatKhauNv.Text = dvgNhanVien.Rows[dong].Cells[8].Value.ToString();

            }
            catch { }

        }

        private void pNV_Click(object sender, EventArgs e)
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtMatKhauNv.Text = "";
            txtTaiKhoanNv.Text = "";
            txtQueQuanNv.Text = "";
            mtbNv.Text = "";
            txtChucVuNv.Text = "";
            txtGioiTinhNv.Text = "";
            txtTimNv.Text = "";
            dvgNhanVien.DataSource = qlnv.getNV();
        }

        private void btnTImNvMa_Click(object sender, EventArgs e)
        {
            if (txtTimNv.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập từ khoá tìm kiếm ");
            }
            else
            {
                DataTable tb = new DataTable();
                tb = qlnv.TKnV(txtTimNv.Text);
                dvgNhanVien.DataSource = tb;
                if (tb.Rows.Count == 0)
                {
                    lbNV.ForeColor = Color.Red;
                    lbNV.Text = "! Không tìm thấy dữ liệu ";
                }
                else
                {
                    this.lbNV.ResetText();
                }

            }
        }

        private void btnTimNVt_Click(object sender, EventArgs e)
        {
            if (txtTimNv.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập từ khoá tìm kiếm ");
            }
            else
            {
                DataTable tb = new DataTable();
                tb = qlnv.TKnVt(txtTimNv.Text);
                dvgNhanVien.DataSource = tb;
                if (tb.Rows.Count == 0)
                {
                    lbNV.ForeColor = Color.Red;
                    lbNV.Text = "! Không tìm thấy dữ liệu ";
                }
                else
                {
                    this.lbNV.ResetText();
                }
            }
        }

        private void btnTimNVCV_Click(object sender, EventArgs e)
        {
            if (txtTimNv.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập từ khoá tìm kiếm ");
            }
            else
            {
                DataTable tb = new DataTable();
                tb = qlnv.TKnVCV(txtTimNv.Text);
                dvgNhanVien.DataSource = tb;
                if (tb.Rows.Count == 0)
                {
                    lbNV.ForeColor = Color.Red;
                    lbNV.Text = "! Không tìm thấy dữ liệu ";
                }
                else
                {
                    this.lbNV.ResetText();
                }
            }
        }

        private void btnXoaNv_Click(object sender, EventArgs e)
        {
            if (txtMaNV.TextLength == 0)
            {
                MessageBox.Show("Bạn cần nhập mã nhân viên.");
            }

            else
                try
                {
                    DialogResult dlg = MessageBox.Show("Bạn có chắc muốn xóa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlg == DialogResult.Yes)
                    {
                        qlnv.xoaNV(txtMaNV.Text);
                        dvgNhanVien.DataSource = qlnv.getNV();
                        if (true)
                        {
                            txtMaNV.Text = "";
                            txtTenNV.Text = "";
                            txtMatKhauNv.Text = "";
                            txtTaiKhoanNv.Text = "";
                            txtQueQuanNv.Text = "";
                            mtbNv.Text = "";
                            txtChucVuNv.Text = "";
                            txtGioiTinhNv.Text = "";
                            txtMaNV.Focus();

                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Mã không tồn tại.");
                }

        }

        private void btnSuaNv_Click(object sender, EventArgs e)
        {
            NhanVienDTO nv = new NhanVienDTO(txtMaNV.Text, txtTenNV.Text, txtGioiTinhNv.Text, dtNsinhNv.Text,
                    mtbNv.Text, txtQueQuanNv.Text, txtChucVuNv.Text, txtTaiKhoanNv.Text, txtMatKhauNv.Text);

            if (txtMaNV.TextLength == 0 || txtTenNV.Text == "" || txtQueQuanNv.Text == "" || mtbNv.Text == "" || txtTaiKhoanNv.Text == "" || txtMatKhauNv.Text == "")
            {
                MessageBox.Show("Bạn cần nhập đầy đủ.");
            }

            else
                try
                {
                    if (qlnv.suaNV(nv))
                    {

                        MessageBox.Show("Mã không tồn tại.");
                    }
                }
                catch
                {
                   
                    if (qlnv.suaNV(nv))
                    {
                        MessageBox.Show(" Đã sửa thành công");
                        dvgNhanVien.DataSource = qlnv.getNV();
                    }
                }
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            NhanVienDTO nv = new NhanVienDTO(txtMaNV.Text, txtTenNV.Text, txtGioiTinhNv.Text, dtNsinhNv.Text,
                     mtbNv.Text, txtQueQuanNv.Text, txtChucVuNv.Text, txtTaiKhoanNv.Text, txtMatKhauNv.Text);


            if (txtMaNV.TextLength == 0 || txtTenNV.Text == "" || txtQueQuanNv.Text == "" || mtbNv.Text == "" || txtTaiKhoanNv.Text == "" || txtMatKhauNv.Text == "")
            {
                MessageBox.Show("Bạn cần nhập đầy đủ.");
            }
            else 
                if (qlnv.KTmatrungNV(txtMaNV.Text) == 1)
                {
                    MessageBox.Show("Đã tồn tại mã nhân viên! Mời bạn nhập lại!");

                }
                else
                {

                    if (qlnv.themNV(nv))
                    {
                        MessageBox.Show("Thêm thành công");
                        dvgNhanVien.DataSource = qlnv.getNV();

                    }

                }


            }
        
//QUẢN LÝ PHÒNG KTX
        private void loadPhongKTX()
        {
            dgvPhongKTX.DataSource = qlp.getPhongKTX();

        }

        private void dgvPhongKTX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int dongp;
                dongp = e.RowIndex;
                this.txtMaPhong.Text = dgvPhongKTX.Rows[dongp].Cells[0].Value.ToString();
                this.txtLoaiPhong.Text = dgvPhongKTX.Rows[dongp].Cells[1].Value.ToString();
                this.txtGiaPhong.Text = dgvPhongKTX.Rows[dongp].Cells[2].Value.ToString();
                this.txtSucChua.Text = dgvPhongKTX.Rows[dongp].Cells[3].Value.ToString();
                this.txtSLuong.Text = dgvPhongKTX.Rows[dongp].Cells[4].Value.ToString();

            }
            catch { }
        }

        private void pP_Click(object sender, EventArgs e)
        {
            txtMaPhong.Text = "";
            txtLoaiPhong.Text = "";
            txtGiaPhong.Text = "";
            txtSucChua.Text = "";
            txtSLuong.Text = "";
            dgvPhongKTX.DataSource = qlp.getPhongKTX();
            txtTimP.Text = "";
            lbP.Text = "";
        }

        private void btnTimPM_Click(object sender, EventArgs e)
        {
            if (txtTimP.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập từ khoá tìm kiếm ");
            }
            else
            {
                DataTable tb = new DataTable();
                tb = qlp.TKp(txtTimP.Text);
                dgvPhongKTX.DataSource = tb;
                if (tb.Rows.Count == 0)
                {
                    lbP.ForeColor = Color.Red;
                    lbP.Text = "! Không tìm thấy dữ liệu";
                }
                else
                {
                    this.lbP.ResetText();
                }

            }
        }

        private void btnTimPT_Click(object sender, EventArgs e)
        {
            if (txtTimP.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập từ khoá tìm kiếm ");
            }
            else
            {
                DataTable tb = new DataTable();
                tb = qlp.TKpl(txtTimP.Text);
                dgvPhongKTX.DataSource = tb;
                if (tb.Rows.Count == 0)
                {
                    lbP.ForeColor = Color.Red;
                    lbP.Text = "! Không tìm thấy dữ liệu";
                }
                else
                {
                    this.lbP.ResetText();
                }

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            PhongKTXDTO p = new PhongKTXDTO(txtMaPhong.Text, txtLoaiPhong.Text, int.Parse(txtGiaPhong.Text), int.Parse(txtSucChua.Text), int.Parse(txtSLuong.Text));
            if (txtMaPhong.TextLength == 0 || txtLoaiPhong.Text == "" || txtGiaPhong.Text == "" || txtSucChua.Text == "")
            {
                MessageBox.Show("Bạn cần nhập đầy đủ.");
            }
            else
                if (qlp.KTmatrungPhong(txtMaPhong.Text) == 1)
            {
                MessageBox.Show("Đã tồn tại mã phòng! Mời bạn nhập lại!");
            }
            else
            {

                if (qlp.themp(p))
                {
                    MessageBox.Show("Thêm thành công");
                    dgvPhongKTX.DataSource = qlp.getPhongKTX();
                }
            }
        }

        private void btnSuaPhong_Click(object sender, EventArgs e)
        {
            PhongKTXDTO p = new PhongKTXDTO(txtMaPhong.Text, txtLoaiPhong.Text, int.Parse(txtGiaPhong.Text), int.Parse(txtSucChua.Text), int.Parse(txtSLuong.Text));


            if (txtMaPhong.TextLength == 0 || txtLoaiPhong.Text == "" || txtGiaPhong.Text == "" || txtSucChua.Text == "")
            {
                MessageBox.Show("Bạn cần nhập đầy đủ.");
            }
            else
            {
               
                if (qlp.suaPhong(p))
                {

                    MessageBox.Show(" Đã sửa thành công");
                    dgvPhongKTX.DataSource = qlp.getPhongKTX();
                }
            }
        }

        private void btnXoaPhong_Click(object sender, EventArgs e)
        {
            if (txtMaPhong.TextLength == 0)
            {
                MessageBox.Show("Bạn cần nhập mã  phòng");
            }

            else
                try
                {
                    DialogResult dlg = MessageBox.Show("Bạn có chắc muốn xóa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlg == DialogResult.Yes)
                    {
                        qlp.xoaPhong(txtMaPhong.Text);
                        dgvPhongKTX.DataSource = qlp.getPhongKTX();
                        if (true)
                        {
                            txtMaPhong.Text = "";
                            txtLoaiPhong.Text = "";
                            txtGiaPhong.Text = "";
                            txtSucChua.Text = "";
                            txtSLuong.Text = "";
                            txtMaPhong.Focus();

                        }
                    }

                }
                catch
                {
                    MessageBox.Show("Mã không tồn tại.");
                }
        }
//QUẢN LÝ SINH VIÊN
        private void loadSinhVien()
        {
            dvgSinhVien.DataSource = qlsv.getSinhVien();
            cboMaPhongSV.DataSource = qlp.getPhongKTX();
            cboMaPhongSV.DisplayMember = "MaPhong";
            cboMaPhongSV.ValueMember = "MaPhong";
            cboMaPhongSV.SelectedIndex = 0;
            

        }

        private void pSV_Click(object sender, EventArgs e)
        {
            txtMaSV.Text = "";
            txtTenSV.Text = "";
            txtGtinhSV.Text = "";
            dtNsinhNv.Text = "";
            madSV.Text = "";
            txtQueQuanSV.Text = "";
            txtLop.Text = "";
            txtKhoa.Text = "";
            txtNKhoa.Text = "";
            cboMaPhongSV.Text = "";
            txtMaSV.Focus();
            dvgSinhVien.DataSource = qlsv.getSinhVien();
        }

        private void dvgSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int dong;
                dong = e.RowIndex;
                this.txtMaSV.Text = dvgSinhVien.Rows[dong].Cells[0].Value.ToString();
                this.txtTenSV.Text = dvgSinhVien.Rows[dong].Cells[1].Value.ToString();
                this.txtGtinhSV.Text = dvgSinhVien.Rows[dong].Cells[2].Value.ToString();
                this.dtaNSinhSV.Text = dvgSinhVien.Rows[dong].Cells[3].Value.ToString();
                this.madSV.Text = dvgSinhVien.Rows[dong].Cells[4].Value.ToString();
                this.txtQueQuanSV.Text = dvgSinhVien.Rows[dong].Cells[5].Value.ToString();
                this.txtLop.Text = dvgSinhVien.Rows[dong].Cells[6].Value.ToString();
                this.txtKhoa.Text = dvgSinhVien.Rows[dong].Cells[7].Value.ToString();
                this.txtNKhoa.Text = dvgSinhVien.Rows[dong].Cells[8].Value.ToString();
                this.cboMaPhongSV.Text = dvgSinhVien.Rows[dong].Cells[9].Value.ToString();
            }
            catch { }
        }

        private void btnSVm_Click(object sender, EventArgs e)
        {
            if (txtTimSV.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập từ khoá tìm kiếm ");
            }
            else
            {
                DataTable tb = new DataTable();
                tb = qlsv.TKSV(txtTimSV.Text);
                dvgSinhVien.DataSource = tb;
                if (tb.Rows.Count == 0)
                {
                    lbSV.ForeColor = Color.Red;
                    lbSV.Text = "! Không tìm thấy dữ liệu ";
                }
                else
                {
                    this.lbSV.ResetText();
                }
            }
        }

        private void btnSVt_Click(object sender, EventArgs e)
        {
            if (txtTimSV.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập từ khoá tìm kiếm ");
            }
            else
            {
                DataTable tb = new DataTable();
                tb = qlsv.TKSVt(txtTimSV.Text);
                dvgSinhVien.DataSource = tb;
                if (tb.Rows.Count == 0)
                {
                    lbSV.ForeColor = Color.Red;
                    lbSV.Text = "! Không tìm thấy dữ liệu ";
                }
                else
                {
                    this.lbSV.ResetText();
                }
            }
        }

        private void btnSVp_Click(object sender, EventArgs e)
        {
            if (txtTimSV.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập từ khoá tìm kiếm ");
            }
            else
            {
                DataTable tb = new DataTable();
                tb = qlsv.TKSVp(txtTimSV.Text);
                dvgSinhVien.DataSource = tb;
                if (tb.Rows.Count == 0)
                {
                    lbSV.ForeColor = Color.Red;
                    lbSV.Text = "! Không tìm thấy dữ liệu ";
                }
                else
                {
                    this.lbSV.ResetText();
                }
            }
        }

        private void btnXoaSV_Click(object sender, EventArgs e)
        {
            if (txtMaSV.TextLength == 0)
            {
                MessageBox.Show("Bạn cần nhập mã nhân viên.");
            }

            else
                try
                {
                    DialogResult dlg = MessageBox.Show("Bạn có chắc muốn xóa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlg == DialogResult.Yes)
                    {
                        qlsv.xoaSV(txtMaSV.Text);
                        dgvPhongKTX.DataSource = qlp.getPhongKTX();
                        dvgSinhVien.DataSource = qlsv.getSinhVien();
                        if (true)
                        {
                            txtMaSV.Text = "";
                            txtTenSV.Text = "";
                            dtaNSinhSV.Text = "";
                            dtaNSinhSV.Text = "";
                            madSV.Text = "";
                            txtQueQuanSV.Text = "";
                            txtLop.Text = "";
                            txtKhoa.Text = "";
                            txtKhoa.Text = "";
                            cboMaPhongSV.Text = "";
                            txtMaSV.Focus();

                        }
                       
                    }
                }
                catch
                {
                    MessageBox.Show("Mã không tồn tại.");
                }
        }

        private void btnThemSV_Click(object sender, EventArgs e)
        {
          


            if (txtMaSV.TextLength == 0 || txtTenSV.Text == "" || txtGtinhSV.Text == "" || dtaNSinhSV.Text == "" || madSV.Text == ""
                || txtTenSV.Text == "" || txtGtinhSV.Text == "")
            {
                MessageBox.Show("Bạn cần nhập đầy đủ.");
            }
            else
                if (qlsv.KTmatrungSV(txtMaSV.Text) == 1)
            {
                MessageBox.Show("Đã tồn tại mã sinh viên! Mời bạn nhập lại!");
            }
            else
            {
                SinhVienDTO sv = new SinhVienDTO(txtMaSV.Text, txtTenSV.Text, txtGtinhSV.Text, dtNsinhNv.Text, madSV,
      txtQueQuanSV.Text, txtLop.Text, txtKhoa.Text, txtNKhoa.Text, cboMaPhongSV.Text);

                if (qlsv.themSV(sv))
                {
                   
                    MessageBox.Show("Thêm thành công");
                    dvgSinhVien.DataSource = qlsv.getSinhVien();
                }
            }

        }

        private void btnSuaSV_Click(object sender, EventArgs e)
        {
           

        }
        // 
        private void loadHoaDonTP()
            {
            dvgHDTP.DataSource = qltp.getHoaDonTP();

            }

        private void dvgHDTP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int dong;
                dong = e.RowIndex;
                this.txtMaHDtp.Text = dvgHDTP.Rows[dong].Cells[0].Value.ToString();
                this.txtMaNVtp.Text = dvgHDTP.Rows[dong].Cells[1].Value.ToString();
                this.txtMaSVtp.Text = dvgHDTP.Rows[dong].Cells[2].Value.ToString();
                this.txtHDTP.Text = dvgHDTP.Rows[dong].Cells[3].Value.ToString();
                this.txtPhongTP.Text = dvgHDTP.Rows[dong].Cells[4].Value.ToString();
                this.txtThangO.Text = dvgHDTP.Rows[dong].Cells[5].Value.ToString();
                this.txtTP.Text = dvgHDTP.Rows[dong].Cells[6].Value.ToString();
                this.txtNgayDongtp.Text = dvgHDTP.Rows[dong].Cells[7].Value.ToString();
                
              

            }
            catch { }
        }

        private void btnTienPhong_Click(object sender, EventArgs e)
        {
            
            int tienphong, sothango,giaphong;
            sothango = int.Parse(txtThangO.Text);
           // giaphong = int.Parse(txtGiaPhong.Text);
            tienphong = (sothango * 120000) ;
            txtTP.Text = tienphong.ToString();
            //
           
        }

        
    }
}
