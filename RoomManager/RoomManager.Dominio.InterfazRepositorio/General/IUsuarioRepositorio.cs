using RoomManager.Dominio.Entidad.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RoomManager.Dominio.InterfazRepositorio.General
{
    public interface IUsuarioRepositorio
    {
        Task<bool> InsertarUsuarioAsync(Usuario usuario);

        Task<IEnumerable<Usuario>> obtenerUsuariosAsync();
    }
}
