//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Practica_Git.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Carro
    {
        public int id_car { get; set; }
        public int id_marca_car { get; set; }
        public int id_modelo_car { get; set; }
        public string descripcion_car { get; set; }
        public string imagen_car { get; set; }
    
        public virtual Marca Marca { get; set; }
        public virtual Modelo Modelo { get; set; }
    }
}