using Dapper;
using RoomManager.Dominio.Entidad.General;
using RoomManager.Dominio.InterfazRepositorio.General;
using RoomManager.Infraestructura.Interfaz.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace RoomManager.Infraestructura.Repositorio.General
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        // Atributos de clase.
        private readonly IConnectionRoomManagerDB _connectionRoomManagerDB;

        public UsuarioRepositorio(IConnectionRoomManagerDB connectionRoomManagerDB) {
            _connectionRoomManagerDB = connectionRoomManagerDB;
        }

        public async Task<bool> InsertarUsuarioAsync(Usuario usuario)
        {
            using (var conexion = _connectionRoomManagerDB.GetConnection)
            {
                // Se construye la instrucción requerida.
                var sql = @"
                            INSERT INTO usuarios
                            ( 
                                PK_ID_USUARIO,
                                NOMBRE_USUARIO,
                                IDENTIFICACION_USUARIO,
                                CONTRASEÑA_USUARIO,
                                FK_ID_ROL
                            ) 
                            VALUES 
                            (
                                (select max(PK_ID_USUARIO)+1 from usuarios),
                                :nombreUsuario,
                                :identificacionUsuario,
                                :contraseñaUsuario,
                                :idRol
                            )";

                // Definición de parámetros.
                var parametros = new DynamicParameters();
                parametros.Add(name: "nombreUsuario", value: usuario.nombreUsuario.ToUpper());
                parametros.Add(name: "identificacionUsuario", value: usuario.identificacionUsuario.ToUpper());
                parametros.Add(name: "contraseñaUsuario", value: usuario.contraseñaUsuario.ToUpper());
                parametros.Add(name: "idRol", value: usuario.fkIdRol.ToUpper());

                // Se ejecuta la instrucción requerida.
                var result = await conexion.ExecuteAsync(sql, parametros, commandType: CommandType.Text);

                // Se retorna el resultado obtenido.
                return result > 0;
            }


        }

        public async Task<IEnumerable<Usuario>> obtenerUsuariosAsync (){
            using (var conexion = _connectionRoomManagerDB.GetConnection)
            {
                var sql = @"SELECT PK_ID_USUARIO pkIdUsuario,
                                   NOMBRE_USUARIO nombreUsuario,
                                   IDENTIFICACION_USUARIO identificacionUsuario,
                                   CONTRASEÑA_USUARIO contraseñaUsuario,
                                   FK_ID_ROL fkIdRol
                            FROM USUARIOS
                            ";

                // Definición de parámetros.
                var parametros = new DynamicParameters();
                var respuesta = await conexion.QueryAsync<Usuario>(sql, parametros, commandType: CommandType.Text);

                // Se retorna el resultado requerido.
                return respuesta;
            }
        }

        public async Task<bool> EliminarUsuarioAsync(int IdUsuario) {
            using (var conexion = _connectionRoomManagerDB.GetConnection)
            {
                var sql = @" DELETE
                            FROM USUARIOS
                            WHERE PK_ID_USUARIO = :idUsuario";

                // Definición de parámetros.
                var parametros = new DynamicParameters();
                parametros.Add(name: "idUsuario", value: IdUsuario);

                var respuesta = await conexion.ExecuteAsync(sql, parametros, commandType: CommandType.Text);

                // Se retorna el resultado requerido.
                return respuesta > 0;
            }
        }

        public async Task<bool> ActualizarrUsuarioAsync(Usuario usuario) {
            using (var conexion = _connectionRoomManagerDB.GetConnection)
            {
                var sql = @" UPDATE USUARIOS SET
                            NOMBRE_USUARIO = :nombreUsuario,
                            IDENTIFICACION_USUARIO = :identificacionUsuario,
                            FK_ID_ROL = :idRol
                            WHERE PK_ID_USUARIO = :idUsuario";

                // Definición de parámetros.
                var parametros = new DynamicParameters();
                parametros.Add(name: "idUsuario", value: usuario.pkIdUsuario);
                parametros.Add(name: "nombreUsuario", value: usuario.nombreUsuario);
                parametros.Add(name: "identificacionUsuario", value: usuario.identificacionUsuario);
                parametros.Add(name: "idRol", value: usuario.fkIdRol);

                var respuesta = await conexion.ExecuteAsync(sql, parametros, commandType: CommandType.Text);

                // Se retorna el resultado requerido.
                return respuesta > 0;
            }
        }
    }
}
