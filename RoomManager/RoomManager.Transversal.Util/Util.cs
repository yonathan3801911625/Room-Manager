using RoomManager.Transversal.Comun.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoomManager.Transversal.Util
{
    public class Util : IUtil
    {
        /// <summary>
        /// Método que permite dividir una lista de string en arreglos de 1000 elementos.
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
        public string[][] DividirListaXMil(IEnumerable<string> lista)
        {
            var i = 0;
            var query = from s in lista
                        let num = i++
                        group s by num / 1000 into g
                        select g.ToArray();
            var results = query.ToArray();
            return results;
        }//Fín Metodo.
    }
}
