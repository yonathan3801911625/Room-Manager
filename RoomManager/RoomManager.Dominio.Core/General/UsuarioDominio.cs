using RoomManager.Dominio.Entidad.General;
using RoomManager.Dominio.Interfaz.General;
using RoomManager.Dominio.InterfazRepositorio.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RoomManager.Dominio.Core.General
{
    public class UsuarioDominio : IUsuarioDominio
    {
        //Atributos de clase
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioDominio(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<bool> InsertarUsuarioAsync(Usuario usuario)
        {
            return await _usuarioRepositorio.InsertarUsuarioAsync(usuario);

        }

        public async Task<IEnumerable<Usuario>> obtenerUsuariosAsync()
        {
            return await _usuarioRepositorio.obtenerUsuariosAsync();
        }

        public async Task<bool> EliminarUsuarioAsync(int IdUsuario)
        {
            return await _usuarioRepositorio.EliminarUsuarioAsync(IdUsuario);
        }

        public async Task<bool> ActualizarrUsuarioAsync(Usuario usuario) {
            return await _usuarioRepositorio.ActualizarrUsuarioAsync(usuario);
        }
    }
}
