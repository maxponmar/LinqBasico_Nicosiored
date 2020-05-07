using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqBasico
{
    class Program
    {
        static void Main(string[] args)
        {
            // Queries sencillos con arreglos y reflexion

            // Ejemplo con numeros
            // Creamos un arreglo sobre el cual trabajar
            int[] numeros = { 1, 5, 7, 3, 5, 9, 8 };

            // Hacemos el query
            IEnumerable<int> valores = from n in numeros
                                       where n > 3 && n < 8
                                       select n;

            // Mostramos los resultados
            foreach (int num in valores)            
                Console.WriteLine(num);

            Console.WriteLine("========================");

            // Ejemplo con cadenas
            // Creamos un arreglo sobre el cual trabajar
            string[] postres = { "pay de manzana", "pastel de chocolate", "manzana caramelizada", "fresas con crema" };

            // Hacemos un query
            IEnumerable<string> encontrados = from p in postres
                                              where p.Contains("manzana")
                                              orderby p
                                              select p;

            // Mostramos los resultados
            foreach(string postre in encontrados)
                Console.WriteLine(postre);

            Console.WriteLine("========================");

            // Hacemos reflexion
            InformacionResultados(valores);
            Console.WriteLine("-----");
            InformacionResultados(encontrados);
        }
        
        static void InformacionResultados(object pResultados)
        {
            Console.WriteLine("Tipo {0}", pResultados.GetType().Name);
            Console.WriteLine("Locacion {0}", pResultados.GetType().Assembly.GetName().Name);
        }

    }
}
