using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tek.Cars.BusCars
{
    public class Entidades
    {
    }
    public class Carro
    {
        public Carro()
        {
            marca = new Marca();
            modelo = new Modelo();
        }
        public int id_car { get; set; }
        public string descripcion_car { get; set; }
        public string imagen_car { get; set; }
        public string nombre_marca { get; set; }
        public string nombre_modelo { get; set; }
        public Marca marca { get; set; }
        public Modelo modelo { get; set; }
    }
    public class Marca
    {
        public int id_marca { get; set; }
        public string nombre_marca { get; set; }
    }
    public class Modelo
    {
        public int id_modelo { get; set; }
        public string nombre_modelo { get; set; }
    }
}

