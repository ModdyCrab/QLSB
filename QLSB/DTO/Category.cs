using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanBong.DTO
{
    public class Category
    {
        public Category(int iD_LDV, string tenLoaiDV)
        {
            this.ID_LDV = iD_LDV;
            this.TenLoaiDV = tenLoaiDV;
        }

        public Category(DataRow row)
        {
            this.ID_LDV = (int)row["ID_LDV"];
            this.TenLoaiDV = row["TenLoaiDV"].ToString();
        }

        private string tenLoaiDV;

        public string TenLoaiDV
        {
            get { return tenLoaiDV; }
            set { tenLoaiDV = value; }
        }

        private int iD_LDV;

        public int ID_LDV
        {
            get { return iD_LDV; }
            set { iD_LDV = value; }
        }
    }
    
}

