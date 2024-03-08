using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Productos
    {
        private CD_Productos objectoCD = new CD_Productos();
       
        public DataTable MostrarProd()
        {
            DataTable tabla = new DataTable();
            tabla = objectoCD.Mostrar();
            return tabla;
        }
        public void InsertarPROD(string nombre,string desc,string marca,string precio,string stock)
        {
            objectoCD.Insertar(nombre,desc,marca,Convert.ToDouble(precio),Convert.ToInt32(stock));
        }
        public void EditarProd(string nombre,string desc,string marca,string precio,string stock,string id)
        {
            objectoCD.Editar(nombre,desc,marca,Convert.ToDouble(precio),Convert.ToInt32(stock),Convert.ToInt32(id));
        }

        public void EliminarPROD(string id)
        {
            objectoCD.Eliminar(Convert.ToInt32(id));
        }
    }
}
