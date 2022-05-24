using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoomManager.Transversal.Comun.Respuesta
{
    public class RespuestaOperacion<T>
    {
        /// <summary>
        /// Obtiene y/o asigna los datos de respuesta.
        /// </summary>
        public T Datos { get; set; }

        /// <summary>
        /// Obtiene y/o asigna el resultado obtenido en una operación (OK | ERROR).
        /// </summary>
        public bool ResultadoExitoso { get; set; }

        /// <summary>
        /// Obtiene y/o establece los posibles errores.
        /// </summary>
        public string MensajeError { get; set; }

        /// <summary>
        /// Obtiene y/o establece los mensajes para el usuario.
        /// </summary>
        public string Mensajes { get; set; }

        /// <summary>
        /// Obtiene y/o asigna los errores encontrados en validaciones de datos.
        /// </summary>
        public IEnumerable<ValidationFailure> ErroresValidacion { get; set; }

    }//Fín class
}
