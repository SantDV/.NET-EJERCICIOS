using Microsoft.EntityFrameworkCore;
using Login_asp.net_core_mvc.Models;
using Login_asp.net_core_mvc.Servicios.Contrato;

namespace Login_asp.net_core_mvc.Servicios.Implementacion
{
    public class UsuarioServices : IUsuarioService
    {

        private readonly DbpruebaContext _dbpruebaContext;

        public UsuarioServices(DbpruebaContext dbpruebaContext)
        {
            _dbpruebaContext = dbpruebaContext;
        }
        public async Task<Usuario> GetUsuarios(string correo, string clave)
        {
            Usuario usuario_encontrado = await _dbpruebaContext.Usuarios.Where(u => u.Correo == correo && u.Clave == clave)
                .FirstOrDefaultAsync();
            return usuario_encontrado;
        }

        public async Task<Usuario> SaveUsuarios(Usuario modelo)
        {
            _dbpruebaContext.Usuarios.Add(modelo);
            await _dbpruebaContext.SaveChangesAsync();

            return modelo;
        }
    }
}
