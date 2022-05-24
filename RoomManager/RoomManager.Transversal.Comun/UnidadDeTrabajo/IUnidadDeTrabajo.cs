using System;
using System.Data;

namespace RoomManager.Transversal.Comun.UnidadDeTrabajo
{
    public interface IUnidadDeTrabajo : IDisposable
    {
        /// <summary>
        /// Retorna el identificador de la transacción.
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Retorna la conexión a base de datos.
        /// </summary>
        IDbConnection Connection { get; }

        /// <summary>
        /// Retorna la transacción actual.
        /// </summary>
        IDbTransaction Transaction { get; }

        /// <summary>
        /// Inicia una transacción sobre la entidad actual.
        /// </summary>
        void Begin();

        /// <summary>
        /// Confirma los cambios pendientes en la entidad actual.
        /// </summary>
        void Commit();

        /// <summary>
        /// Devuelve los cambios realizados en la entidad actual.
        /// </summary>
        void Rollback();

    }//Fín interface
}
