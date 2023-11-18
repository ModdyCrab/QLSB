using QuanLySanBong.DAO;
using QuanLySanBong.DTO;
using QuanLySanBong;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace QuanLySanBong
{
    public partial class Datsan : Form
    {
        bool Thoat = true;

        public Datsan()
        {
            InitializeComponent();
            LoadTable();
            LoadCategory1();
        }


        void LoadFoodListByCategoryID(int id)
        {
        
        }
        private void logo_Click(object sender, EventArgs e)
        {
            Trangchu f = new Trangchu();
            f.Show();
            this.Hide();
        }

        private void btDong_Click(object sender, EventArgs e)
        {
            Trangchu f = new Trangchu();
            f.Show();
            this.Hide();
        }
        private void Datsan_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Thoat)
                Application.Exit();
        }
        void LoadTable()
        {
            List<Table> tableList = TableDAO.Instance.LoadTableList();
            foreach (Table item in tableList)
            {
                Button btn = new Button()
                {
                    Width = TableDAO.TableWidth,
                    Height = TableDAO.TableHeight
                };
                btn.Text = item.Ten+Environment.NewLine+item.TrangThai;
                btn.Click += btn_Click;
                btn.Tag = item;

                switch(item.TrangThai)
                    {
                    case "Trống":
                        btn.BackColor = Color.AliceBlue;
                        break;
                    default: btn.BackColor = Color.AliceBlue; break;
                }
                flpTable.Controls.Add(btn);
            }
        }
        
        void LoadCategory1()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            comboBox1.DataSource = listCategory;
            comboBox1.DisplayMember = "TenLoaiDV";
        }
        void GetDVByCategoryID(int id)
        {
            List<DV> listDV = DVDAO.Instance.GetDVByCategoryID(id);
            comboBox2.DataSource = listDV;
            comboBox2.DisplayMember = "TenDV";
        }


        void ShowBill(int id)
        {
            listView1.Items.Clear();
            List<DTO.Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);
            int TongTien = 0;
            foreach (DTO.Menu item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.ID_HoaDon.ToString());
                lsvItem.SubItems.Add(item.Ten.ToString());
                lsvItem.SubItems.Add(item.GiaTien.ToString());
                lsvItem.SubItems.Add(item.TenDV.ToString());
                lsvItem.SubItems.Add(item.GiaTienDV.ToString());
                lsvItem.SubItems.Add(item.TongTien.ToString());
                TongTien+=item.TongTien;
                listView1.Items.Add(lsvItem);
            }
            CultureInfo culture = new CultureInfo("vi-VN");

            //Thread.CurrentThread.CurrentCulture = culture;

          
            tbTongTien.Text = TongTien.ToString("c", culture);
        }

   
        void btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID_KVSB;
            listView1.Tag = (sender as Button).Tag;
            ShowBill(tableID);

        }



        private void button1_Click(object sender, EventArgs e)
        {
            Thoat = false;
            this.Close();
            FormDangNhap f = new FormDangNhap();
            f.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Thongtintaikhoan f = new Thongtintaikhoan();
            f.Show();
            this.Hide();
        }

        private void flpTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;

            Category selected = cb.SelectedItem as Category;
            id = selected.ID_LDV;

            GetDVByCategoryID(id);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            /*Table table = listView1.Tag as Table;
            int ID_ChiTietHoaDon=
            int ID_HoaDon = BillDAO.Instance.GetUncheckBillByTableID(table.ID_KVSB);
            int ID_DV = (comboBox2.SelectedItem as DV).ID_DV;
            int SoLuong = (int)nmDVCout.Value;

            if (ID_HoaDon == -1)
            {
                BillDAO.Instance.InsertBill(table.ID_KVSB);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), ID_DV, SoLuong);
            }
            else
            {
                BillInfoDAO.Instance.InsertBillInfo(ID_HoaDon, ID_DV, So);
            }

            ShowBill(table.ID);*/
        }
        public int GetMaxIDBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(ID_HoaDon) FROM dbo.HoaDon");
            }
            catch
            {
                return 1;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Table table = listView1.Tag as Table;

            int ID_KVSB = BillDAO.Instance.GetUncheckBillByTableID(table.ID_KVSB);

            if (ID_KVSB != -1)
            {
                if (MessageBox.Show("Bạn có chắc thanh toán hóa đơn cho bàn " + table.Ten, "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(ID_KVSB);
                    ShowBill(table.ID_KVSB);

                    LoadTable();
                }
            }
        }
    }
}
