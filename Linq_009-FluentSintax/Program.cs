using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq_009_FluentSintax
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creamos un arreglo para trabajar
            int[] numeros = { 1, 5, 4, 7, 6, 3, 5, 9, 8, 11 };

            // Usamos expresion lambda como arguimento, n es el argumento de etrada (predicado)
            IEnumerable<int> pares = numeros.Where(n => n % 2 == 0);

            // Mostramos resultados
            foreach(int num in pares)
                Console.WriteLine(num);
            Console.WriteLine("================");

            // Creamos un arreglo
            string[] postres = { "pay de manzana", "pastel de chocolate", "manzana caramelizada", "fresas con crema" };

            IEnumerable<string> encontrados = postres.Where(p => p.Contains("manzana"));

            // Mostramos resultados
            foreach(string postre in encontrados)
                Console.WriteLine(postre);
            Console.WriteLine("================");

            // Encadenamos operadores
            // Se van adicionando operadores

            IEnumerable<string> manzanas = postres
                .Where(p => p.Contains("manzan"))
                .OrderBy(p => p.Length)
                .Select(p => p.ToUpper());

            // Mostramos los resultados
            foreach(string postre in manzanas)
                Console.WriteLine(postre);
            Console.WriteLine("================");


        }
    }
}
