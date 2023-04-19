using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CONECT
    {
        public static SqlConnection chuoiKetNoi()
        {
            string strCon = "Data Source=DESKTOP-LNJ99RH\\SQLEXPRESS;Initial Catalog=QLTDNS;Integrated Security=True";
            SqlConnection sqlCON = new SqlConnection(strCon);
            sqlCON.Open();
            return sqlCON;
        }
    }
}
