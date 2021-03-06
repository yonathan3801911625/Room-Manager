using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomManager.Aplicacion.DTO;
using RoomManager.Aplicacion.Interfaz;

namespace RoomManger.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        // Atributos de clase.
        private readonly IUsuarioAplicacion _usuarioAplicacion;

        public UsuarioController(IUsuarioAplicacion usuarioAplicacion) {
            _usuarioAplicacion = usuarioAplicacion;
        }

        #region Métodos Asíncronos.

        [HttpPost]
        [Route("InsertarUsuarioAsync")]
        public async Task<IActionResult> InsertarUsuarioAsync([FromBody] UsuarioDTO usuarioDTO) {
            if(usuarioDTO == null) return BadRequest("Parámetro nulo.");

            // Se llama al método que permite hacer la inserción de la entidad.
            var respuesta = await _usuarioAplicacion.InsertarUsuarioAsync(usuarioDTO);

            // Se valida el resultado obtenido.
            if (respuesta.ResultadoExitoso)
            {
                // Se retorna el resultado requerido.
                return Ok(respuesta);
            }
            else
            {
                // Se retorna el resultado requerido.
                return BadRequest(respuesta.MensajeError);
            }// Fín if.
        }

        [HttpGet]
        [Route("ObtenerUsuariosAsync")]
        public async Task<IActionResult> ObtenerUsuariosAsync()
        {
            // Se llama al método que permite obtener las configuraciones de acceso.
            var respuesta = await _usuarioAplicacion.ObtenerUsuariosAsync();

            // Se valida el resultado obtenido.
            if (respuesta.ResultadoExitoso)
            {
                // Se retorna el resultado requerido.
                return Ok(respuesta);
            }
            else
            {
                // Se retorna el resultado requerido.
                return BadRequest(respuesta.MensajeError);
            }// Fín if.
        }

        [HttpPut]
        [Route("EliminarUsuarioPorIdAsync")]
        public async Task<IActionResult> Eliminar([FromBody] UsuarioDTO usuarioDTO) {
            // Se llama al método que permite obtener las configuraciones de acceso.
            var respuesta = await _usuarioAplicacion.EliminarUsuarioAsync(usuarioDTO.pkIdUsuario);

            // Se valida el resultado obtenido.
            if (respuesta.ResultadoExitoso)
            {
                // Se retorna el resultado requerido.
                return Ok(respuesta);
            }
            else
            {
                // Se retorna el resultado requerido.
                return BadRequest(respuesta.MensajeError);
            }// Fín if.
        }

        [HttpPost]
        [Route("ActualizarUsuarioAsync")]
        public async Task<IActionResult> ActualizarUsuarioAsync([FromBody] UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null) return BadRequest("Parámetro nulo.");

            // Se llama al método que permite hacer la inserción de la entidad.
            var respuesta = await _usuarioAplicacion.ActualizarrUsuarioAsync(usuarioDTO);

            // Se valida el resultado obtenido.
            if (respuesta.ResultadoExitoso)
            {
                // Se retorna el resultado requerido.
                return Ok(respuesta);
            }
            else
            {
                // Se retorna el resultado requerido.
                return BadRequest(respuesta.MensajeError);
            }// Fín if.
        }

        #endregion
    }
}