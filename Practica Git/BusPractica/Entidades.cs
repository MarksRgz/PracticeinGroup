﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brachi.Bussines.BusPractica
{
    public class Entidades
    {
    }
    public class Carro
    {
        public Carro()
        {
        }
        public int id_car { get; set; }
        public int id_marca_car { get; set; }
        public int id_modelo_car { get; set; }
        public string descripcion_car { get; set; }
        public string imagen_car { get; set; }
        public string nombre_marca { get; set; }
        public string nombre_modelo { get; set; }



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
    public class Usuario
    {
        public int id_usua { get; set; }
        public string nombre_usua { get; set; }
        public string pass_usua { get; set; }
        public bool estatus_usua { get; set; }
    }
    public class Producto
    {
        public int id_prod { get; set; }
        public int id_marca_prod { get; set; }
        public int id_grup_prod { get; set; }
        public string nombre_prod { get; set; }
    }
    public class MarcaProd
    {
        public int id_marca { get; set; }
        public int id_grup_marca { get; set; }
        public string nombre_marca { get; set; }
    }
    public class GrupoProd
    {
        public int id_grup { get; set; }
        public string nombre_grup { get; set; }
    }
}
