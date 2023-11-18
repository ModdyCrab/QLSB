using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanBong.DTO
{
     public class Menu
    {

        public Menu(int iD_HoaDon, int tongTien , string tenDV, int giaTienDV, string ten, int giaTien)
        {   
            
            this.ID_HoaDon=iD_HoaDon;
            this.GiaTien = tongTien;
            this.TenDV = tenDV;
            this.GiaTienDV = giaTienDV;
            this.Ten = ten;
            this.GiaTien = giaTien;

        }
        
        public Menu(DataRow row)   
        {
                this.ID_HoaDon = Convert.ToInt32(row["ID_HoaDon"]);
                this.TongTien = Convert.ToInt32(row["TongTien"]);
                this.Ten = row["Ten"].ToString();
                this.GiaTien = Convert.ToInt32(row["GiaTien"]);
                this.TenDV = row["TenDV"].ToString();
                this.GiaTienDV = Convert.ToInt32(row["GiaTienDV"]);
                

        }

        private int iD_HoaDon;
        public int ID_HoaDon
        {
            get { return iD_HoaDon; }
            set { iD_HoaDon = value; }
        }
        private int tongTien;
        public int TongTien
        {
            get { return tongTien; }
            set {tongTien = value; }
        }
        private string ten;
        public string Ten
        {
            get { return ten; }
            set { ten = value; }
        }


        private int giaTien;
        public int GiaTien
        {
            get { return giaTien; }
            set { giaTien = value; }
        }

        private string tenDV;
        public string TenDV
        {
            get { return tenDV; }
            set { tenDV = value; }
        }

        private int giaTienDV;

        public int GiaTienDV
        {
            get { return giaTienDV; }
            set { giaTienDV = value; }
        }
    }
}
