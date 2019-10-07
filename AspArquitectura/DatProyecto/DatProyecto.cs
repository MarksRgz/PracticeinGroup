using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digipro.AspArquitectura.Data
{
    public class DatProyecto
    {
        private SqlConnection con;
        public DatProyecto()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL"].ConnectionString);
        }
        public DataTable GetProyectos()
        {
            SqlCommand com = new SqlCommand("spGetProyectosasp", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable GetProyectosCombo()
        {
            SqlCommand com = new SqlCommand("spGetProyectosCombo", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public int CreateProyecto(string nombre_proyecto, string desc_proyecto, string img_proyecto, DateTime fecha_proyecto, decimal costo_proyecto)
        {
            SqlCommand com = new SqlCommand("spCreateProyectoasp", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter { ParameterName = "@nombre_proyecto", Value = nombre_proyecto, SqlDbType = SqlDbType.VarChar });
            com.Parameters.Add(new SqlParameter { ParameterName = "@desc_proyecto", Value = desc_proyecto, SqlDbType = SqlDbType.VarChar });
            com.Parameters.Add(new SqlParameter { ParameterName = "@img_proyecto", Value = img_proyecto, SqlDbType = SqlDbType.VarChar });
            com.Parameters.Add(new SqlParameter { ParameterName = "@fecha_proyecto ", Value = fecha_proyecto, SqlDbType = SqlDbType.DateTime });
            com.Parameters.Add(new SqlParameter { ParameterName = "@costo_proyecto ", Value = costo_proyecto, SqlDbType = SqlDbType.Decimal });
            try
            {
                con.Open();
                int filas = com.ExecuteNonQuery();
                con.Close();
                return filas;

            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al insertar proyecto: {ex.Message}");
            }
        }

        public int UpdateProyecto(int id_proyecto, string nombre_proyecto, string desc_proyecto, string img_proyecto, DateTime fecha_proyecto, decimal costo_proyecto)
        {
            SqlCommand com = new SqlCommand("spUpdateProyectoasp", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter { ParameterName = "@id_proyecto", Value = id_proyecto, SqlDbType = SqlDbType.VarChar });
            com.Parameters.Add(new SqlParameter { ParameterName = "@nombre_proyecto", Value = nombre_proyecto, SqlDbType = SqlDbType.VarChar });
            com.Parameters.Add(new SqlParameter { ParameterName = "@desc_proyecto", Value = desc_proyecto, SqlDbType = SqlDbType.VarChar });
            com.Parameters.Add(new SqlParameter { ParameterName = "@img_proyecto", Value = img_proyecto, SqlDbType = SqlDbType.VarChar });
            com.Parameters.Add(new SqlParameter { ParameterName = "@fecha_proyecto ", Value = fecha_proyecto, SqlDbType = SqlDbType.DateTime });
            com.Parameters.Add(new SqlParameter { ParameterName = "@costo_proyecto ", Value = costo_proyecto, SqlDbType = SqlDbType.Decimal });
            try
            {
                con.Open();
                int filas = com.ExecuteNonQuery();
                con.Close();
                return filas;

            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al actualizar proyecto: {ex.Message}");
            }
        }

        public int DeleteLibro(int id_proyecto)
        {
            SqlCommand com = new SqlCommand("spDeleteProyectoasp", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter { ParameterName = "@id_proyecto", Value = id_proyecto, SqlDbType = SqlDbType.Int });
            try
            {
                con.Open();
                int filas = com.ExecuteNonQuery();
                con.Close();
                return filas;
            }
            catch (Exception ex)
            {
                con.Close();
                throw new ApplicationException("Error al eliminar proyecto");
            }
            throw new NotImplementedException();
        }
    }
}




