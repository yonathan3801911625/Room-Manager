using AutoMapper;
using RoomManager.Aplicacion.DTO;
using RoomManager.Aplicacion.Interfaz;
using RoomManager.Dominio.Entidad.General;
using RoomManager.Dominio.Interfaz.General;
using RoomManager.Transversal.Comun.Log;
using RoomManager.Transversal.Comun.Respuesta;
using RoomManager.Transversal.Comun.Utilidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RoomManager.Aplicacion.Principal
{

    public class UsuarioAplicacion : IUsuarioAplicacion
    {

        private readonly IUsuarioDominio _usuarioDominio;
        private readonly IMapper _mapper;
        private readonly IUtil _util;
        private readonly IAppLogger<UsuarioAplicacion> _logger;

        public UsuarioAplicacion(
            IUsuarioDominio usuarioDominio,
            IMapper mapper,
            IAppLogger<UsuarioAplicacion> logger,
            IUtil util
            )
        {
            _usuarioDominio = usuarioDominio;
            _mapper = mapper;
            _logger = logger;
            _util = util;
        }

        public async Task<RespuestaOperacion<bool>> InsertarUsuarioAsync(UsuarioDTO usuarioDTO) {
           
            //Declaración de variables
            var respuesta = new RespuestaOperacion<bool>();

            try {

                //Se mapean los objetos recibidos al tipo de objeto requerido.
                var usuario = _mapper.Map<Usuario>(usuarioDTO);

                //Sellama al método que permite actualizar el registro requerido y se asigna el resultado obtenido.
                respuesta.Datos = await _usuarioDominio.InsertarUsuarioAsync(usuario);

                //Se valida el resultado
                if (respuesta.Datos)
                {
                    respuesta.ResultadoExitoso = true;
                    respuesta.Mensajes = "Inserción Exitosa!";
                }//Fín if

            }
            catch (Exception ex)
            {
                respuesta.MensajeError = ex.Message;
                _logger.LogError(ex, "Error en el método InsertarServicioSubservicioAsync()");

            }//Fín try

            //Se retorna el resultado obtenido.
            return respuesta;
        }

        public async Task<RespuestaOperacion<IEnumerable<UsuarioDTO>>> ObtenerUsuariosAsync() {
            //Declaración de variables
            var respuesta = new RespuestaOperacion<IEnumerable<UsuarioDTO>>();

            try
            {
                // Se llama al método que permite consultar las configuraciones.
                var listaUsuarios = await _usuarioDominio.obtenerUsuariosAsync();

                // Se mapean los resultados obtenidos en sus respectivos objetos DTO.
                respuesta.Datos = _mapper.Map<IEnumerable<UsuarioDTO>>(listaUsuarios);

                // Se asigna el resultado.
                respuesta.ResultadoExitoso = true;
                respuesta.Mensajes = "Consulta Exitosa!";
            }
            catch (Exception ex)
            {
                respuesta.MensajeError = ex.Message;
                _logger.LogError(ex, "Error en el método obtenerUsuariosAsync()");

            }//Fín try

            //Se retorna el resultado obtenido.
            return respuesta;
        }
    }
}
