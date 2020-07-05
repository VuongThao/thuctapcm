using System;
using System.Data;
using System.Windows.Forms;

namespace Shop_Project_WinForm
{
    public partial class UserNhaCungCap : UserControl
    {
        int i;
        public UserNhaCungCap()
        {
            InitializeComponent();
            loadDl();
            txmncc.Enabled = false;
            txsdt.Enabled = false;
            txdiachi.Enabled = false;
            txtenncc.Enabled = false;
            txgmail.Enabled = false;
            txmncc.Enabled = true;
            txsdt.Enabled = true;
            txdiachi.Enabled = true;
            txtenncc.Enabled = true;
            txgmail.Enabled = true;
            
        }
        public void loadDl()
        {
            string query = "select *from NhaCungCap";
            DataTable data = KetNoi.Instance.excuteQuery(query);
            dgt1.DataSource = data;
        }
        public bool kiemtra(string MaNV)
        {
            string query = "select *from NhaCungCap where MaNCC='" + txmncc.Text + "'";
            DataTable data = KetNoi.Instance.excuteQuery(query);
            int dem = 0;
            foreach (DataRow item in data.Rows)
            {
                dem++;
            }
            if (dem > 0)
                return true;
            return false;
        }
        void setnull()
        {
            txmncc.Text = "";
            txtenncc.Text = "";
            txdiachi.Text = "";
            txsdt.Text = "";
            txgmail.Text = "";
           

        }
        private void gunaButton10_Click(object sender, EventArgs e)
        {
            //int i = 1;
          
            txmncc.Enabled = true;
            txsdt.Enabled = true;
            txdiachi.Enabled = true;
            txtenncc.Enabled = true;
            txgmail.Enabled = true;
            setnull();



        }




        private void dgt1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int row = e.RowIndex;
            if (row< 0)
            {
                return;
            }
            else
            {
                txmncc.Text = dgt1.Rows[row].Cells[0].Value.ToString();
                txtenncc.Text = dgt1.Rows[row].Cells[1].Value.ToString();
                txdiachi.Text = dgt1.Rows[row].Cells[2].Value.ToString();
                txsdt.Text = dgt1.Rows[row].Cells[3].Value.ToString();
                txgmail.Text = dgt1.Rows[row].Cells[4].Value.ToString();






            }
    }

        private void gunaButton9_Click(object sender, EventArgs e)
        {
            txmncc.Enabled = false;
        }

        private void gunaButton11_Click(object sender, EventArgs e)
        {
            if (txmncc.Text == "" || txtenncc.Text == "")
            {
                MessageBox.Show(" vui lòng chọn dòng cần xóa");
            }
            try
            {
                string query = "delete NhaCungCap where MaNCC='" + txmncc.Text + "' ";
                DataTable data = KetNoi.Instance.excuteQuery(query);
                MessageBox.Show("Xóa Thành Công");
                loadDl();

            }
            catch
            {
                MessageBox.Show(" Xóa thất bại");
            }
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            if (txmncc.Enabled)
            {
                if (txmncc.Text == "" || txtenncc.Text == "" || txsdt.Text == "" || txdiachi.Text == "")
                {
                    MessageBox.Show("vui long nhap du thong tin");
                }
                else
                {
                    if (kiemtra(txmncc.Text) == true)
                    {
                        MessageBox.Show("ma da ton tai");
                        return;
                    }
                    try
                    {
                        string query = "insert into NhaCungCap values (N'" + txmncc.Text + "',N'" + txtenncc.Text + "',N'" + txdiachi.Text + "','" + txsdt.Text + "','" + txgmail.Text + "')";
                        DataTable data = KetNoi.Instance.excuteQuery(query);
                        MessageBox.Show("them thanh cong");
                        loadDl();
                    }
                    catch
                    {
                        MessageBox.Show("them that bai");
                    }
                }
            }
            else
            {
                if (txtenncc.Text == "" || txsdt.Text == "" || txdiachi.Text == "")
                {
                    MessageBox.Show("vui long nhap du thong tin");
                }
                else
                {

                    try
                    {
                        string query = "update NhaCungCap set TenNhaCC= N'" + txtenncc.Text + "',ĐiaChiNCC=N'" + txdiachi.Text + "',SDTNCC='" + txsdt.Text + "',GmailNCC='" + txgmail.Text + "' where MaNCC='" + txmncc.Text + "'";
                        DataTable data = KetNoi.Instance.excuteQuery(query);
                        MessageBox.Show("Sửa thành công");
                        loadDl();
                    }
                    catch
                    {
                        MessageBox.Show("Sửa thất bại");
                    }
                }
            }
            }

        private void txsdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void guna2VSeparator1_Click(object sender, EventArgs e)
        {

        }
    }
    }

