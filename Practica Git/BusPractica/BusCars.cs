using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
        public List<Marca> GetMarcas()
        {
            List<Marca> lst = new List<Marca>();
            using (con)
            {
                lst = con.Query<Marca>("spGetMarcas").ToList();
            }
            return lst;
        }
        public int Update(Carro car)
        {
            using (con)
            {
                Carro carro = new Carro();
                carro = con.QueryFirst(("spUpdateCarro"), new { id_car = car.id_car, descripcion_car = car.descripcion_car, imagen_car = car.imagen_car });
                return carro.id_car;
            }
        }
        public int UpdateCarro(Carro car)
        {
            using (con)
            {
                var filas = con.Execute(("spUpdateCarro"), new { id_car = car.id_car, descripcion_car = car.descripcion_car, imagen_car = car.imagen_car }, commandType: CommandType.StoredProcedure);
                return filas;

            }
        }
    }
}
