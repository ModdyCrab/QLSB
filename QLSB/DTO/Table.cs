using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanBong.DTO
{
    public class Table
    {
        public Table(int iD_KVSB, string ten, int giatien,string trangthai) 
        {
        this.ID_KVSB = iD_KVSB;
            this.Ten = ten;
            this.GiaTien = giaTien;
            this.TrangThai = trangThai;
        }
        public Table(DataRow row) 
        {
            this.ID_KVSB = (int)row["ID_KVSB"];
            this.Ten = row["Ten"].ToString();
            this.GiaTien = (int)row["GiaTien"];
            this.TrangThai= row["TrangThai"].ToString();
        }
        private int giaTien;
        private string ten;
        private int iD_KVSB;
        private string trangThai;

        public int ID_KVSB { get{return iD_KVSB; }
            set { iD_KVSB = value; } }
        public string Ten 
        {get { return ten; }
            set { ten = value; }
        }
        public int GiaTien
        { get{ return giaTien; }
            set { giaTien = value; }
        }

        public string TrangThai
        {
            get { return trangThai; }
            set { trangThai = value; }
        }
    }
}
