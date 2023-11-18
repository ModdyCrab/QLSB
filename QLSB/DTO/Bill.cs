using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanBong.DTO
{
    public class Bill
    {
        public Bill(int iD_HoaDon,int iD_CTLDSB,int iD_KH,DateTime? ngayLapBill, DateTime? ngayXuatBill,int giamGia,int trangThai,int iD_NV) { 
        this.ID_HoaDon = iD_HoaDon;
        this.ID_CTLDSB = iD_CTLDSB;
        this.ID_KH = iD_KH;
        this.NgayLapBill = ngayLapBill;
        this.NgayXuatBill = ngayXuatBill;
        this.GiamGia = giamGia;
        this.TrangThai = trangThai;
        this.ID_NV = iD_NV;
        }
        public Bill(DataRow row)
        {
            this.ID_HoaDon= (int)row["ID_HoaDon"];
            this.ID_CTLDSB = (int)row["ID_CTLDSB"];
            this.ID_KH = (int)row["ID_KH"];
            this.NgayLapBill = (DateTime?)row["NgayLapBill"];
            var NgayXuatBillTemp = row["NgayXuatBill"];
            if (NgayXuatBillTemp.ToString() != "")
            
                this.NgayXuatBill = (DateTime?)NgayXuatBillTemp;
            
            this.GiamGia = (int)row["GiamGia"];
            this.TrangThai = (int)row["TrangThai"];
            this.ID_NV = (int)row["ID_NV"];
        }
        private int iD_HoaDon;

        public int ID_HoaDon
        {
            get { return iD_HoaDon; }
            set { iD_HoaDon = value; }
        }

        private int iD_CTLDSB;

        public int ID_CTLDSB
        {
            get { return iD_CTLDSB; }
            set { iD_CTLDSB = value; }
        }

        private int iD_KH;

        public int ID_KH
        {
            get { return iD_KH; }
            set { iD_KH = value; }
        }

        private DateTime? ngayLapBill;

        public DateTime? NgayLapBill
        {
            get { return ngayLapBill; }
            set { ngayLapBill = value; }
        }

        private DateTime? ngayXuatBill;

        public DateTime? NgayXuatBill
        {
            get { return ngayXuatBill; }
            set { ngayXuatBill = value; }
        }

        private int giamGia;

        public int GiamGia
        {
            get { return giamGia; }
            set { giamGia = value; }
        }

        private int trangThai;

        public int TrangThai
        {
            get { return trangThai; }
            set { trangThai = value; }
        }

        private int iD_NV;
        public int ID_NV
        {
            get { return iD_NV; }
            set { iD_NV = value; }
        }
    }
}
