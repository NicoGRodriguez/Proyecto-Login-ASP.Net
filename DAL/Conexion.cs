using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Conexion
    {
        SqlConnection conexion;
        SqlCommand comando;
        SqlDataReader lector;
        string conectionstring = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;


        //Properties
        public string Conectionstring { get => conectionstring; set => conectionstring = value; }
        public SqlDataReader Lector { get => lector; set => lector = value; }

        public SqlCommand Comando { get => comando; set => comando = value; }


        //Constructores

        public Conexion()
        {
            conexion = new SqlConnection();
            conexion.ConnectionString = conectionstring;
            comando = new SqlCommand();

        }
        public Conexion(string conectionstring)
        {
            conexion = new SqlConnection(conectionstring);
            comando = new SqlCommand();
        }

        //Metodos

        public void Conectar()
        {
            conexion.ConnectionString = conectionstring;
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;

        }

        public void Desconectar()
        {
            conexion.Close();
        }

    }
}
