using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using RoomManager.Infraestructura.Interfaz.General;
using RoomManager.Transversal.Comun.Configuracion;
using System.Data;

namespace RoomManager.Infraestructura.Datos
{
    public class ConnectionRoomManagerFactory : IConnectionRoomManagerDB
    {
        //Atributos de clase
        private readonly IConfiguration _configuracion;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration">Configuración inyectada</param>
        public ConnectionRoomManagerFactory(IConfiguration configuration)
        {
            _configuracion = configuration;
        }

        /// <summary>
        /// Permite obtener la conexión a base de datos requerida.
        /// </summary>
        public IDbConnection GetConnection
        {
            get
            {
                var oracleConnection = new OracleConnection();
                if (oracleConnection == null) return null;

                oracleConnection.ConnectionString = _configuracion.GetConnectionString(Constantes.CONEXION_INTROROOM);
                oracleConnection.Open();
                return oracleConnection;
            }
        }
    }
}
