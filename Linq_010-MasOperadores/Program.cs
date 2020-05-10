using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq_010_MasOperadores
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creamos un arreglo
            int[] numeros = { 1, 5, 4, 7, 6, 3, 5, 9, 8, 11 };
            IEnumerable<int> desdeInicio = numeros.Take(5);

            // Mostramos resultados
            foreach(int num in desdeInicio)
                Console.WriteLine(num);
            Console.WriteLine("==========");

            IEnumerable<int> brinco = numeros.Skip(5);
            // Mostramos resultados
            foreach (int num in brinco)
                Console.WriteLine(num);
            Console.WriteLine("==========");

            IEnumerable<int> reversa = numeros.Reverse();
            // Mostramos resultados
            foreach (int num in reversa)
                Console.WriteLine(num);
            Console.WriteLine("==========");

            // Encontramos el primero
            Console.WriteLine("El primero es {0}", numeros.First());

            // Entramos el ultimo
            Console.WriteLine("El ultimo es {0}", numeros.Last());

            // Encontramos el elemento en el indice 3
            Console.WriteLine("En el indice 3 esta {0}", numeros.ElementAt(3));

            // Vemos si contiene a determinado elemento
            Console.WriteLine("Contiene al 15 - {0}", numeros.Contains(15));

            // Vemos si hay elementos
            Console.WriteLine("Tiene elementos - {0}", numeros.Any());

            // Vemos is hay multiplos de 5
            Console.WriteLine("Hay multiplos de 5 - {0}", numeros.Any(n => n % 5 == 0));
            Console.WriteLine("==============");


            // Cuidado con los cambios de valor entre la ejecucion de los query
            int valor = 2;
            IEnumerable<int> resultados = numeros.Where(n => n % valor == 0);
            valor = 3;
            foreach(int n in resultados)
                Console.WriteLine(n);
        }
    }
}
