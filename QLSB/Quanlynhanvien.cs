﻿using QuanLySanBong.DAO;
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
    public partial class Quanlynhanvien : Form
    {
        bool Thoat = true;
        public Quanlynhanvien()
        {
            InitializeComponent();
           
        }
      
        private void button9_Click(object sender, EventArgs e)
        {
            Trangchu f = new Trangchu();
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

        private void button7_Click(object sender, EventArgs e)
        {
            Thongtintaikhoan f = new Thongtintaikhoan();
            f.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thoat = false;
            this.Close();
            FormDangNhap f = new FormDangNhap();
            f.ShowDialog();
        }

        private void logo_Click(object sender, EventArgs e)
        {
            Trangchu f = new Trangchu();
            f.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Quanlykh f = new Quanlykh();
            f.Show();
            this.Hide();
        }

       
    }
}
