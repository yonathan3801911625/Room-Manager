using RoomManager.Transversal.Comun.Conexion;
using RoomManager.Transversal.Comun.UnidadDeTrabajo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RoomManager.Infraestructura.Repositorio.UnidadDeTrabajo
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {
        //Atributos de clase
        private readonly IDbConnection _connection = null;
        private IDbTransaction _transaction = null;
        private readonly Guid _id = Guid.Empty;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionFactory"></param>
        public UnidadDeTrabajo(IConnectionFactory connectionFactory)
        {
            _id = Guid.NewGuid();
            _connection = connectionFactory.GetConnection;
        }//Fín método

        /// <summary>
        /// Retorna el identificador de la transacción.
        /// </summary>
        public Guid Id
        {
            get { return _id; }
        }

        /// <summary>
        /// Retorna la conexión a base de datos.
        /// </summary>
        public IDbConnection Connection
        {
            get { return _connection; }
        }

        /// <summary>
        /// Retorna la transacción actual.
        /// </summary>
        public IDbTransaction Transaction
        {
            get { return _transaction; }
        }

        /// <summary>
        /// Inicia una transacción sobre la entidad actual.
        /// </summary>
        public void Begin()
        {
            _transaction = _connection.BeginTransaction();
        }

        /// <summary>
        /// Confirma los cambios pendientes en la entidad actual.
        /// </summary>
        public void Commit()
        {
            _transaction.Commit();
            Dispose();
        }//Fín método

        /// <summary>
        /// Devuelve los cambios realizados en la entidad actual.
        /// </summary>
        public void Rollback()
        {
            _transaction.Rollback();
            Dispose();
        }//Fín método

        /// <summary>
        /// Libera los recursos actuales de la conexión.
        /// </summary>
        public void Dispose()
        {
            if (_transaction != null)
                _transaction.Dispose();

            _transaction = null;
        }//Fín método

    }//Fín class
}
