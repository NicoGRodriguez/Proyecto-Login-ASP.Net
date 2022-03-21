using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace DLL
{
    public class usuarioBLL
    {
        public static Usuario Ingresar(string Usuario, string Contraseña)
        {
            return DAL.usuarioDAL.Ingresar(Usuario, Contraseña);
        }
        public static Usuario RegistrarUsuario(Usuario s)
        {
            return DAL.usuarioDAL.RegistrarUsuario(s);
        }
        public static List<Usuario> ListaUsuario()
        {
            return DAL.usuarioDAL.ListaUsuarios();
        }
        public static bool EliminarUsuario(int s)
        {
            return DAL.usuarioDAL.EliminarUsuario(s);
        }
        public static bool EditarUsuario(Usuario s)
        {
            return DAL.usuarioDAL.EditarUsuario(s);
        }
        public static Usuario TraerUsuario(int s)
        {
            return DAL.usuarioDAL.TraerUsuario(s);
        }
    }
}
