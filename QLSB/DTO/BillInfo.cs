using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanBong.DTO
{
    public class BillInfo
    {
        public BillInfo(int iD_ChiTietHoaDon, int iD_HoaDon, int iD_DV,int soLuong)
        {
            this.ID_ChiTietHoaDon = iD_ChiTietHoaDon;
            this.ID_HoaDon = iD_HoaDon;
            this.ID_DV = iD_DV;
            this.SoLuong = soLuong;
        }
       public BillInfo(DataRow row)
        {
            this.ID_ChiTietHoaDon = (int)row["ID_ChiTietHoaDon"];
            this.ID_HoaDon = (int)row["ID_HoaDon"];
            this.ID_DV = (int)row["ID_DV"];
            this.SoLuong = (int)row["SoLuong"];
        }
        private int iD_ChiTietHoaDon;

        public int ID_ChiTietHoaDon
        {
            get { return iD_ChiTietHoaDon; }
            set { iD_ChiTietHoaDon = value; }
        }

        private int iD_HoaDon;

        public int ID_HoaDon
        {
            get { return iD_HoaDon; }
            set { iD_HoaDon = value; }
        }

        private int iD_DV;

        public int ID_DV
        {
            get { return iD_DV; }
            set { iD_DV = value; }
        }

        private int soLuong;

        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }
    }
}
