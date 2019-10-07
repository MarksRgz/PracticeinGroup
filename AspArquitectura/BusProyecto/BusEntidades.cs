using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digipro.AspArquitectura.Bussiness
{
    public class BusEntidades
    {
    }
    public class Proyecto
    {
        public int id_proyecto { get; set; }
        public string nombre_proyecto { get; set; }
        public string desc_proyecto { get; set; }
        public string img_proyecto { get; set; }
        public DateTime fecha_proyecto { get; set; }
        public decimal costo_proyecto { get; set; }
    }
}
