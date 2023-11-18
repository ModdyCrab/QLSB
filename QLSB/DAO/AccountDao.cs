using QuanLySanBong.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanBong.DAO
{
    public class AccountDao
    {
        private static AccountDao instance;
        public static AccountDao Instance
        {
            get { if (instance == null) instance = new AccountDao(); return instance; }
            private set { instance = value; }
        }
        private AccountDao() { }
        public bool Login(string userName, string passWord)
        {
            string query = "USP_Login2 @UserName , @PassWord";
         DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[]{userName, passWord});
            return result.Rows.Count > 0;
        }
        public Account GetAccountByUserName(string userName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from Account where UserName = '" + userName + "'");

            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }

            return null;
        }
    }
    }

