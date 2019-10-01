using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
        public int UpdateSlider(Slider slide)
        {
            try
            {
                using (con)
                {
                    var filas = con.Execute(("spUpdateSlider"), new { id_slider = slide.id_slider, lugar_slider = slide.lugar_slider, desc_slider = slide.desc_slider, img_slider = slide.img_slider }, commandType: CommandType.StoredProcedure);
                    return filas;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error spUpdateSlider: " + ex.Message);
            }
        }
        public Slider CreateSlider(Slider slide)
        {
            try
            {
                using (con)
                {
                    Slider slid = con.Query<Slider>(("spCreateSlider"), new { lugar_slider = slide.lugar_slider, desc_slider = slide.desc_slider, img_slider = slide.img_slider }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    return slid;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error spCreateSlider: " + ex.Message);
            }
        }
        public int DeleteSlider(int idp)
        {
            try
            {
                using (con)
                {
                    var filas = con.Execute(("spDeleteSlider"), new { id_slider = idp }, commandType: CommandType.StoredProcedure);
                    return filas;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error spDeleteSlider:" + ex.Message);
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
        public int UpdateProyecto(Proyecto proye)
        {
            try
            {
                using (con)
                {
                    var filas = con.Execute(("spUpdateProyecto"), new { id_proyecto = proye.id_proyecto, nombre_proyecto = proye.nombre_proyecto, desc_proyecto = proye.desc_proyecto, img_proyecto = proye.img_proyecto, fecha_proyecto = proye.fecha_proyecto, costo_proyecto = proye.costo_proyecto }, commandType: CommandType.StoredProcedure);
                    return filas;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error spUpdateProyecto" + ex.Message);
            }
        }
        public Proyecto CreateProyecto(Proyecto proye)
        {
            try
            {
                using (con)
                {
                    Proyecto proyecto = con.Query<Proyecto>(("spCreateProyecto"), new { nombre_proyecto = proye.nombre_proyecto, desc_proyecto = proye.desc_proyecto, img_proyecto = proye.img_proyecto, fecha_proyecto = proye.fecha_proyecto, costo_proyecto = proye.costo_proyecto }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    return proyecto;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error spCreateProyecto" + ex.Message);
            }
        }
        public int DeleteProyecto(int idp)
        {
            try
            {
                using (con)
                {
                    var filas = con.Execute(("spDeleteProyecto"), new { id_proyecto = idp }, commandType: CommandType.StoredProcedure);
                    return filas;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error spDeleteProyecto" + ex.Message);
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
        public int UpdateServicio(Servicio serv)
        {
            try
            {
                using (con)
                {
                    var filas = con.Execute(("spUpdateServicio"), new { id_serv = serv.id_serv, nombre_serv = serv.nombre_serv, desc_serv = serv.desc_serv }, commandType: CommandType.StoredProcedure);
                    return filas;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error spUpdateServicio" + ex.Message);
            }
        }
        public Servicio CreateServicio(Servicio servi)
        {
            try
            {
                using (con)
                {
                    Servicio serv = con.Query<Servicio>(("spCreateServicio"), new { nombre_serv = servi.nombre_serv, desc_serv = servi.desc_serv }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    return serv;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error spCreateServicio" + ex.Message);
            }
        }
        public int DeleteServicio(int idp)
        {
            try
            {
                var filas = con.Execute(("spDeleteServicio"), new { id_serv = idp }, commandType: CommandType.StoredProcedure);
                return filas;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error spDeleteServicio" + ex.Message);
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
        public int UpdateBlog(Blog blog)
        {
            try
            {
                using (con)
                {
                    int filas = con.Execute(("spUpdateBlog"), new
                    {
                        id_blog = blog.id_blog,
                        nombre_blog = blog.nombre_blog,
                        titulo_blog = blog.titulo_blog,
                        desc_blog = blog.desc_blog,
                        fecha_blog = blog.fecha_blog,
                        vistas_blog = blog.vistas_blog,
                        comen_blog = blog.comen_blog,
                        img_blog = blog.img_blog
                    }, commandType: CommandType.StoredProcedure);
                    return filas;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error spUpdateBlog" + ex.Message);
            }
        }
        public Blog CreateBlog(Blog blog)
        {
            try
            {
                using (con)
                {
                    Blog blo = con.Query<Blog>(("spCreateBlog"), new
                    {
                        nombre_blog = blog.nombre_blog,
                        titulo_blog = blog.titulo_blog,
                        desc_blog = blog.desc_blog,
                        fecha_blog = blog.fecha_blog,
                        vistas_blog = blog.vistas_blog,
                        comen_blog = blog.comen_blog,
                        img_blog = blog.img_blog
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    return blo;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error spCreateBlog" + ex.Message);
            }
        }
        public int DeleteBlog(int idp)
        {
            try
            {
                using (con)
                {
                    int filas = con.Execute(("spDeleteBlog"), new { id_blog = idp }, commandType: CommandType.StoredProcedure);
                    return filas;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error spDeleteBlog" + ex.Message);
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
        public int UpdateTestimonio(Testimonio test)
        {
            try
            {
                using (con)
                {
                    int filas = con.Execute(("spUpdateTestimonio"), new { id_test = test.id_test, nombre_test = test.nombre_test, opinion_test = test.opinion_test, img_test = test.img_test }, commandType: CommandType.StoredProcedure);
                    return filas;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("spUpdateTestimonio" + ex.Message);
            }
        }
        public Testimonio CreateTestimonio(Testimonio test)
        {
            try
            {
                using (con)
                {
                    Testimonio testi = con.Query<Testimonio>(("spCreateTestimonio"), new { nombre_test = test.nombre_test, opinion_test = test.opinion_test, img_test = test.img_test }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    return testi;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("spCreateTestimonio" + ex.Message);
            }
        }
        public int DeleteTestimonio(int idp)
        {
            try
            {
                using (con)
                {
                    int filas = con.Execute(("spDeleteTestimonio"), new {id_test = idp }, commandType:CommandType.StoredProcedure);
                    return filas;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error spDeleteTestimonio" + ex.Message);
            }
        }
        public Usuario GetUsuario(string nombre, string password)
        {
            try
            {
                Usuario usua = new Usuario();
                using (con)
                {
                    usua = con.Query<Usuario>("spGetUsuario", new { nombre = nombre, password = password }, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
                }
                return usua;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error spGetUsuario: " + ex.Message);
            }
        }

    }
}






