using QuanLySanBong.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanBong.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
            private set { BillDAO.instance = value; }
        }
        private BillDAO()
        {

        }

        public int GetUncheckBillByTableID(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.HoaDon WHERE ID_HoaDon = " + id + " AND TrangThai = 0");

            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                Bill bill = new Bill(row);
                return bill.ID_HoaDon;
            }

            return -1; // Nếu không tìm thấy hóa đơn chưa thanh toán, trả về chuỗi "-1".
        }
        public void CheckOut(int id)
        {
            string query = "UPDATE dbo.HoaDon SET TrangThai = 0 FROM HoaDon hd JOIN ChiTietLichDat_SanBong ctl ON hd.ID_CTLDSB = ctl.ID_CTLDSB WHERE ctl.ID_KVSB " + id;
            DataProvider.Instance.ExecuteNotQuery(query);
        }
        public void InsertBill(int id)
        {
            DataProvider.Instance.ExecuteNotQuery("exec USP_InsertBill @ID_HoaDon", new object[] { id });
        }

        public int GetMaxIDBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(id) FROM dbo.Bill");
            }
            catch
            {
                return 1;
            }
        }
    }
}
