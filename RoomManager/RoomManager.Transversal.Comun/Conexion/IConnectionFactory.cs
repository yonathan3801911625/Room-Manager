using System.Data;

namespace RoomManager.Transversal.Comun.Conexion
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}
