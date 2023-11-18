using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLySanBong.DAO;
using QuanLySanBong.DTO;

namespace QuanLySanBong
{
    public partial class FormDangNhap : Form
    {
            
        public FormDangNhap()
        {
            InitializeComponent();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btdangnhap_Click_1(object sender, EventArgs e)
        {
            string userName = tbtaikhoan.Text;
            string passWord = tbmatkhau.Text;
            if(Login(userName, passWord))
            {

                Trangchu f = new Trangchu();
                f.Show();
                this.Hide();
            }
        else
        {
                MessageBox.Show("sai ten tai khoan hoac mat khau!");
        } }
        bool Login(string userName, string passWord)
        {
        return AccountDao.Instance.Login(userName, passWord);
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
