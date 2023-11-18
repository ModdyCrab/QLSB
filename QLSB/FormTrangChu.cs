using QuanLySanBong.DAO;
using QuanLySanBong.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySanBong
{
    public partial class Trangchu : Form
    {
        private Account loginAccount;

      
        bool Thoat = true;
      

        public Trangchu()
        {
            InitializeComponent();
         
        }

      

        void ChangeAccount(int userType)
        {
            button5.Enabled= userType ==1;
            

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Thoat=false;
            this.Close();
            FormDangNhap f = new FormDangNhap();
            f.ShowDialog();
        }

        private void Trangchu_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(Thoat)
            Application.Exit();
        }

        private void logo_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Quanlykh f = new Quanlykh();
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {


            Datsan f = new Datsan();
                    f.Show();
                    this.Hide();
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Thanhtoan f = new Thanhtoan();
            f.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Quanlynhanvien f = new Quanlynhanvien();
            f.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Thongtintaikhoan f = new Thongtintaikhoan();
            f.Show();
            this.Hide();
        }
    }
}
