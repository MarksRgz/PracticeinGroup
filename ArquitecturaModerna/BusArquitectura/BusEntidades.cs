using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beneficia.BusArquitectura.Buss
{
    public class BusEntidades
    {
    }
    public class Blog
    {
        public int id_blog { get; set; }
        public string nombre_blog { get; set; }
        public string titulo_blog { get; set; }
        public string desc_blog { get; set; }
        public DateTime fecha_blog { get; set; }
        public double vistas_blog { get; set; }
        public int comen_blog { get; set; }
        public string img_blog { get; set; }
    }
    public class Proyecto
    {
        public int id_proyecto { get; set; }
        public string nombre_proyecto { get; set; }
        public string desc_proyecto { get; set; }
        public string img_proyecto { get; set; }
        public DateTime fecha_proyecto { get; set; }
        public double costo_proyecto { get; set; }
    }
    public class Servicio
    {
        public int id_serv { get; set; }
        public string nombre_serv { get; set; }
        public string desc_serv { get; set; }
    }
    public class Slider
    {
        public int id_slider { get; set; }
        public string lugar_slider { get; set; }
        public string desc_slider { get; set; }
        public string img_slider { get; set; }
    }
    public class Testimonio
    {
        public int id_test { get; set; }
        public string nombre_test { get; set; }
        public string opinion_test { get; set; }
        public string img_test { get; set; }
    }
    public class Usuario
    {
        public int id_usua { get; set; }
        public string nombre_usua { get; set; }
        public bool estatus_usua { get; set; }
        public string pass_usua { get; set; }
    }
    public class IndexModelo
    {
        public List<Slider> slider { get; set; }
        public List<Proyecto> proyecto { get; set; }
    }
}

