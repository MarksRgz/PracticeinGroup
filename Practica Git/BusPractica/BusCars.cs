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
        public int UpdateCarro(Carro car)
        {
            using (con)
            {
                var filas = con.Execute(("spUpdateCarro"), new { id_car = car.id_car, descripcion_car = car.descripcion_car, imagen_car = car.imagen_car }, commandType: CommandType.StoredProcedure);
                return filas;
            }
        }
        public int CreateCarro(Carro car)
        {
            using (con)
            {
                var filas = con.Execute(("spInsertCarro"), new { id_marca_car = car.id_marca_car, id_modelo_car = car.id_modelo_car, descripcion_car = car.descripcion_car, imagen_car = car.imagen_car }, commandType: CommandType.StoredProcedure);
                return filas;
            }
        }
        public int DeleteCarro(int idp)
        {
            using (con)
            {
                var filas = con.Execute(("spDeleteCarro"), new {id_car = idp}, commandType: CommandType.StoredProcedure);
                return filas;
            }
              
        }
    }
}
// id_marca_car = car.marca.id_marca, id_modelo_car = car.modelo.id_modelo, 
