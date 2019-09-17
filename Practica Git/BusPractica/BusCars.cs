using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brachi.Bussines.BusPractica
{
    public class BusCars
    {
        SqlConnection con;
        public BusCars()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLCarros"].ConnectionString);
        }
        public List<Carro> GetCarros()
        {
            List<Carro> lst = new List<Carro>();
            using (con)
            {
                lst = con.Query<Carro>("spGetCarros").ToList();
            }
            return lst;
        }
    }
}
