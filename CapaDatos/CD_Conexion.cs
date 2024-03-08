using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Conexion
    {
        private SqlConnection conexion = new SqlConnection("server=(local);DATABASE= Practica;Integrated Security=true");
        
        public SqlConnection AbrirConexion()
        {
            if (conexion.State == ConnectionState.Closed)
            
                conexion.Open();
           return conexion;
            
        }

        public SqlConnection CerrarConexion()
        {
            if(conexion.State == ConnectionState.Open)
                conexion.Close();
            return conexion;
        }
    
    }

}
