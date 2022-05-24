using System;
using System.Collections.Generic;
using System.Text;

namespace RoomManager.Dominio.Entidad.General
{
    public class Usuario
    {
        public int pkIdUsuario { get; set; }

        public string nombreUsuario { get; set; }

        public string identificacionUsuario { get; set; }

        public string contraseñaUsuario { get; set; }

        public string fkIdRol { get; set; }

    }
}
