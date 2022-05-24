using System;
using System.Collections.Generic;
using System.Text;

namespace RoomManager.Aplicacion.DTO
{
    public class UsuarioDTO
    {
        public int pkIdUsuario { get; set; }

        public string nombreUsuario { get; set; }

        public string identificacionUsuario { get; set; }

        public string contraseñaUsuario { get; set; }

        public string fkIdRol { get; set; }
    }
}
