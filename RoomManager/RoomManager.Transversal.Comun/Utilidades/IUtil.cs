using System;
using System.Collections.Generic;
using System.Text;

namespace RoomManager.Transversal.Comun.Utilidades
{
    public interface IUtil
    {
        /// <summary>
        /// Mjcorrea:13/05/2022 
        /// Método que permite dividir una lista de enteros en arreglos de 1000 elementos.
        /// </summary>
        /// <param name="lista">Lista con los elementos a dividir.</param>
        /// <returns>Retorna una matriz con arreglos de 1000 elementos.</returns>
        string[][] DividirListaXMil(IEnumerable<string> lista);

    }
}
