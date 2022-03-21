using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAL;


namespace DAL
{
    public class usuarioDAL
    {
        public static Usuario Ingresar(string Usuario, string Contraseña)
        {
            Contraseña = Encrypt.EncriptarPassword(Contraseña, "Pass");
            Usuario usu = new Usuario();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ValidarUsuario", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Usuario", Usuario);
                    cmd.Parameters.AddWithValue("@Contrasenia", Contraseña);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            usu = CargarUsuario(dr);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return usu;
        }
        private static Usuario CargarUsuario(SqlDataReader dr)
        {

            Usuario obj = new Usuario();
            obj.Id = int.Parse(dr["id"].ToString());
            obj.Usuarios = dr["Usuario"].ToString();
            obj.Contraseña = dr["Contrasenia"].ToString();
            obj.TipoAdm = bool.Parse(dr["TipoAdm"].ToString());

            return obj;
        }
        public static Usuario RegistrarUsuario(Usuario s)
        {
            Usuario usu = new Usuario();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_AgregarUsuario", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Usuario", s.Usuarios);
                    cmd.Parameters.AddWithValue("@Contrasenia", Encrypt.EncriptarPassword(s.Contraseña, "Pass"));
                    cmd.Parameters.AddWithValue("@TipoAdm", s.TipoAdm);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
            return usu;
        }


        public static bool EliminarUsuario(int s)
        {
            bool Eliminado = false;
            //Usuario usu = new Usuario();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_EliminarUsuario", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", s);
                    cmd.ExecuteNonQuery();
                    Eliminado = true;
                }
                catch (Exception )
                {
                    Eliminado = false;

                }
                finally
                {
                    
                    con.Close();
                }
            }
            return Eliminado;
        }
        public static bool EditarUsuario(Usuario s)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_EditarUsuario", con);
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", s.Id);
                    cmd.Parameters.AddWithValue("@Usuario", s.Usuarios);
                    cmd.Parameters.AddWithValue("@Contrasenia", s.Contraseña);
                    cmd.Parameters.AddWithValue("@TipoAdm", s.TipoAdm);

                    cmd.Connection = con;
                    exito = cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return exito;
        }
        public static List<Usuario> ListaUsuarios()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_MostrarUsuarios", con))
                {
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        List<Usuario> usu = new List<Usuario>();
                        while (dr.Read())
                        {
                            usu.Add(CargarUsuario(dr));
                        }
                        con.Close();
                        return usu;
                    }
                }
            }
        }
        public static Usuario TraerUsuario(int s)
        {
            Usuario usu = new Usuario();
            
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_TraerUsuario",con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", s);
                    

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            usu = CargarUsuario(dr);
                            
                        }
                    }
                }
                
                catch (Exception ex)
                {
                    throw ex;
                }
                return usu;
            }
        }

    }
}
