using RoomManager.Aplicacion.DTO;
using RoomManager.Transversal.Comun.Respuesta;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RoomManager.Aplicacion.Interfaz
{
    public interface IUsuarioAplicacion
    {
        Task<RespuestaOperacion<bool>> InsertarUsuarioAsync(UsuarioDTO usuarioDTO);

        Task<RespuestaOperacion<IEnumerable<UsuarioDTO>>> ObtenerUsuariosAsync();
    }
}
