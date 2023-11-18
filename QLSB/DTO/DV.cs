using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanBong.DTO
{
    public class DV
    {

        public DV(int iD_DV, int iD_LDV, string tenDV, int giaTienDV)
        {
            this.ID_DV = iD_DV;
            this.ID_LDV = iD_LDV;
            this.TenDV = tenDV;
            this.GiaTienDV = giaTienDV;
        }

        public DV(DataRow row)
        {
            this.ID_DV = (int)row["ID_DV"];
            this.ID_LDV = (int)row["ID_LDV"];
            this.TenDV = row["TenDV"].ToString();
            this.GiaTienDV = (int)row["GiaTienDV"];
        }

        private int giaTienDV;

        public int GiaTienDV
        {
            get { return giaTienDV; }
            set { giaTienDV = value; }
        }

        private int iD_DV;

        public int ID_DV
        {
            get { return iD_DV; }
            set { iD_DV = value; }
        }

        private string tenDV;

        public string TenDV
        {
            get { return tenDV; }
            set { tenDV = value; }
        }

        private int iD_LDV;

        public int ID_LDV
        {
            get { return iD_LDV; }
            set { iD_LDV = value; }
        }

    }
}
