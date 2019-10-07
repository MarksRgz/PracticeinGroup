using Digipro.AspArquitectura.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digipro.AspArquitectura.Bussiness
{
    public class BusGlobal
    {
        public List<Proyecto> GetProyectos()
        {
            List<Proyecto> lst = new List<Proyecto>();
            DataTable dt = new DatProyecto().GetProyectos();
            foreach (DataRow row in dt.Rows)
            {
                Proyecto proye = new Proyecto();
                proye.id_proyecto = Convert.ToInt32(row["ID"]);
                proye.nombre_proyecto = row["Nombre"].ToString();
                proye.desc_proyecto = row["Descripcion"].ToString();
                proye.img_proyecto = row["Imagen"].ToString();
                proye.fecha_proyecto = Convert.ToDateTime(row["Fecha"]);
                proye.costo_proyecto = Convert.ToInt32(row["Costo"]);
                lst.Add(proye);
            }
            return lst;
        }
        public Proyecto GetProyecto(int idProyecto)
        {
            List<Proyecto> lst = GetProyectos();
            Proyecto proye = lst.FirstOrDefault(l => l.id_proyecto == idProyecto);
            return proye;
        }
        public List<Proyecto> GetProyectosCombo()
        {
            List<Proyecto> lst = new List<Proyecto>();
            DataTable dt = new DatProyecto().GetProyectosCombo();
            foreach (DataRow row in dt.Rows)
            {
                Proyecto proye = new Proyecto();
                proye.id_proyecto = Convert.ToInt32(row["ID"]);
                proye.nombre_proyecto = row["Nombre"].ToString();
                lst.Add(proye);
            }
            return lst;
        }
        public void CreateProyecto(Proyecto proye)
        {
            int filas = new DatProyecto().CreateProyecto(proye.nombre_proyecto, proye.desc_proyecto, proye.img_proyecto, proye.fecha_proyecto, proye.costo_proyecto);
            if (filas != 1)
            {
                throw new ApplicationException($"Error al insertar Proyecto");
            }

        }
        public void UpdateProyecto(Proyecto proye)
        {
            int filas = new DatProyecto().UpdateProyecto(proye.id_proyecto, proye.nombre_proyecto, proye.desc_proyecto, proye.img_proyecto, proye.fecha_proyecto, proye.costo_proyecto);
            if (filas != 1)
            {
                throw new ApplicationException($"Error al actualizar Proyecto");
            }
        }

        public void DeleteProyecto(Proyecto proye)
        {
            int filas = new DatProyecto().DeleteLibro(proye.id_proyecto);
            if (filas != 1)
            {
                throw new ApplicationException("Error al eliminar proyecto");
            }
        }
    }
}
