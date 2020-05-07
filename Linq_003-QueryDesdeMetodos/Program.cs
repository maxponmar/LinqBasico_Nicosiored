using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq_003_QueryDesdeMetodos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Obtener resultados del query desde metodos

            // Invocamos el metodo
            IEnumerable<int> resultados = CClaseExplicita.ObtenerNumerosPares();

            // Mostramos los resultados
            foreach(int num in resultados)
                Console.WriteLine(num);

            Console.WriteLine("========");

            IEnumerable<string> postres = CClaseExplicita.ObtenerPostres();

            // Mostramos los resultados
            foreach (string p in postres)
                Console.WriteLine(p);

            Console.WriteLine("========");

            // Ejemplo de resultado de query inmediato
            int[] impares = CClaseExplicita.ObtenerNumerosImpares();

            // Mostramos los resultados
            foreach(int m in impares)
                Console.WriteLine(m);
        }
    }
}
