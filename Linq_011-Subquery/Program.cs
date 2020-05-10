using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq_011_Subquery
{
    class Program
    {
        static void Main(string[] args)
        {
            // Un subquery es un query que esta contenido en la expresion lambda de otro query
            // El scope que existe dentro de la expresion que lo contiene

            string[] postres = { "pay de manzana", "pastel de chocolate", "manzana caramelizada", "fresas con crema" };

            // Ordenamos alfabeticamente de aceurdo a la ultima palabra de cada elemento
            // Split divide en una coleccion a la cadena
            // pSplit().Las() es el subquery
            IEnumerable<string> resultados = postres.OrderBy(p => p.Split().Last());

            foreach(string postre in resultados)
                Console.WriteLine(postre);

            Console.WriteLine("=============");
            int[] numeros = { 19, 14, 56, 32, 11, 8, 45, 7, 18, 2, 18, 23 };

            IEnumerable<int> nums = numeros
                .Where(n => n < numeros.First());
            foreach(int n in nums)
                Console.WriteLine(n);
            Console.WriteLine("=============");

            // Numeros que sean menores o iguales al primero entero que se encuentre
            IEnumerable<int> nums2 = numeros
                .Where(n => n <= (numeros.Where(n2 => n2 % 2 == 0)).First());
            foreach(int n in nums2)
                Console.WriteLine(n);
        }
    }
}
