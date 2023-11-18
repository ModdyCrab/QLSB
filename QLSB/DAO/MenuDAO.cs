using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QuanLySanBong.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;

        public static MenuDAO Instance
        {
            get { if (instance == null) instance = new MenuDAO(); return MenuDAO.instance; }
            private set { MenuDAO.instance = value; }
        }
        private MenuDAO() { }

        public List<DTO.Menu> GetListMenuByTable(int id)
        {
            List<DTO.Menu> listMenu = new List<DTO.Menu>();
            string query = "SELECT a.ID_HoaDon,e.ID_KVSB,e.Ten,e.GiaTien,c.TenDV,c.GiaTienDV, c.GiaTienDV*b.SoLuong+e.GiaTien AS TongTien FROM dbo.HoaDon AS a,dbo.ChiTietHoaDon AS b,dbo.DV AS c,dbo.ChiTietLichDat_SanBong AS d, dbo.KhuVuc_SanBong AS e WHERE a.ID_HoaDon=b.ID_HoaDon AND b.ID_DV=c.ID_DV AND a.ID_CTLDSB=d.ID_CTLDSB AND d.ID_KVSB=e.ID_KVSB AND a.TrangThai=1 AND e.ID_KVSB=" + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                DTO.Menu menu = new DTO.Menu(item);
                listMenu.Add(menu);
            }
               
            return listMenu;

        }
            
    }
}
