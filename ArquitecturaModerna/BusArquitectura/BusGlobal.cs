using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beneficia.BusArquitectura.Buss
{
    public class BusGlobal
    {
        SqlConnection con;

        public BusGlobal()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLArquitecturas"].ConnectionString);
        }
        public List<Slider> GetSliders()
        {
            try
            {
                List<Slider> lst = new List<Slider>();
                using (con)
                {
                    lst = con.Query<Slider>("spGetSliders").ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error spGetSliders: " + ex.Message);
            }
        }
        public IndexModelo GetModeloIndex()
        {
            IndexModelo modelo = new IndexModelo();
            try
            {
                using (var multi = con.QueryMultiple("spGetSlidersProye", null))
                {
                    modelo.slider = multi.Read<Slider>().ToList();
                    modelo.proyecto = multi.Read<Proyecto>().ToList();
                }
                return modelo;
            }
            catch (Exception ex)
            {
                con.Close();
                throw new ApplicationException("Error spGetSlidersProye: " + ex.Message);
            }
        }
        public List<Proyecto> GetProyectos()
        {
            try
            {
                List<Proyecto> lst = new List<Proyecto>();
                using (con)
                {
                    lst = con.Query<Proyecto>("spGetProyectos").ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error spGetProyectos: " + ex.Message);
            }
        }
        public List<Servicio> GetServicios()
        {
            try
            {
                List<Servicio> lst = new List<Servicio>();
                using (con)
                {
                    lst = con.Query<Servicio>("spGetServicios").ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error spGetServicios: " + ex.Message);
            }
        }
        public List<Blog> GetBlogs()
        {
            try
            {
                List<Blog> lst = new List<Blog>();
                using (con)
                {
                    lst = con.Query<Blog>("spGetBlogs").ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error spGetBlogs: " + ex.Message);
            }
        }
        public List<Testimonio> GetTestimonios()
        {
            try
            {
                List<Testimonio> lst = new List<Testimonio>();
                using (con)
                {
                    lst = con.Query<Testimonio>("spGetTestimonios").ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error spGetTestimonios: " + ex.Message);
            }
        }
        public List<Usuario> GetUsuarios()
        {
            try
            {
                List<Usuario> lst = new List<Usuario>();
                using (con)
                {
                    lst = con.Query<Usuario>("spGetUsuarios").ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error spGetUsuarios: " + ex.Message);
            }
        }
    }
}

