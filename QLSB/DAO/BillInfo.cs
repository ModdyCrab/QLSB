using QuanLySanBong.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanBong.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;
        public static BillInfoDAO Instance {

            get { if (instance == null) instance = new BillInfoDAO(); return BillInfoDAO.instance; }
            private set { BillInfoDAO.instance = value; }
        }
        public BillInfoDAO() { }

        public List<BillInfo> GetListBillInfo(int id) {
        List<BillInfo> listBillInfo = new List<BillInfo>();
            DataTable data = DataProvider.Instance.ExecuteQuery("Select *from dbo.ChiTietHoaDon where ID_ChiTietHoaDon = " + id);
            foreach (DataRow item in data.Rows) {
                BillInfo info = new BillInfo(item);
                listBillInfo.Add(info);
            }
            return listBillInfo;
        }
        /*public void InsertBillInfo(int ID_ChiTienHoaDon, int ID_HoaDon, int ID_DV,int SoLuong)
        {
            DataProvider.Instance.ExecuteNotQuery"USP_InsertBillInfo @ID_ChiTietHoaDon, @ID_HoaDon,@ID_DV,@SoLuong", new object[] { ID_ChiTienHoaDon,  ID_HoaDon,  ID_DV,  SoLuong);
        }*/


    }
} 
    

