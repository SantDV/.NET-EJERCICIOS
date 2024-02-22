using Microsoft.EntityFrameworkCore;
using Login_asp.net_core_mvc.Models;

namespace Login_asp.net_core_mvc.Servicios.Contrato
{
    public interface IUsuarioService
    {
        Task<Usuario> GetUsuarios(string correo, string clave);

        Task<Usuario> SaveUsuarios(Usuario modelo);
    }
}
