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
        SqlConnection con, conu;
        public BusCars()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLCarros"].ConnectionString);
            conu = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLProductos"].ConnectionString);
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
        public Carro CreateCarro(Carro car)
        {
            using (con)
            {
                Carro filas = con.Query<Carro>(("spInsertCarro"), new { id_marca_car = car.id_marca_car, id_modelo_car = car.id_modelo_car, descripcion_car = car.descripcion_car, imagen_car = car.imagen_car }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return filas;
            }
        }
        public int DeleteCarro(int idp)
        {
            using (con)
            {
                var filas = con.Execute(("spDeleteCarro"), new { id_car = idp }, commandType: CommandType.StoredProcedure);
                return filas;
            }

        }
        public Usuario GetUsuario(string nombre, string password)
        {
            Usuario lst = new Usuario();
            using (conu)
            {
                lst = conu.Query<Usuario>("spGetUsuario", new { nombre = nombre, password = password }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return lst;
        }
        public List<Producto> GetProductos()
        {
            List<Producto> lst = new List<Producto>();
            using (conu)
            {
                lst = conu.Query<Producto>("spGetProductos").ToList();
            }
            return lst;
        }
        public List<MarcaProd> GetMarcasProd()
        {
            List<MarcaProd> lst = new List<MarcaProd>();
            using (conu)
            {
                lst = conu.Query<MarcaProd>("spGetMarcasProd").ToList();
            }
            return lst;
        }
        public List<GrupoProd> GetGrupos()
        {
            List<GrupoProd> lst = new List<GrupoProd>();
            using (conu)
            {
                lst = conu.Query<GrupoProd>("spGetGruposProd").ToList();
            }
            return lst;
        }
    }
}

