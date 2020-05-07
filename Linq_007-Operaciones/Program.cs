using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace Linq_007_Operaciones
{
    class Program
    {
        static void Main(string[] args)
        {
            // Vemos varias operaciones que podemos realizar con LINQ

            // Creamos una lista
            List<CEstudiante> estudiantes = new List<CEstudiante>
            {
                new CEstudiante("Ana","A100", "Mercadotecnia", 10.0),
                new CEstudiante("Luis", "S250", "Oriantado a objetos", 9.0),
                new CEstudiante("Juan", "S875", "Programacion basica", 5.0),
                new CEstudiante("Susana","A432", "Mercadotecnia", 8.7),
                new CEstudiante("Pablo", "A156", "Mercadotecnia", 4.3),
                new CEstudiante("Alberto", "S456", "Orientado a objetos", 8.3)
            };

            // Conteo
            int cantidad = (from e in estudiantes
                            where e.Promedio > 5
                            select e).Count();
            Console.WriteLine("La cantidad de aprobados es {0}", cantidad);
            Console.WriteLine("================");

            // Reversa
            var aprobados = from e in estudiantes
                            where e.Promedio > 5
                            select e;
            foreach(CEstudiante est in aprobados)
                Console.WriteLine(est);
            Console.WriteLine("Orden inverso");
            foreach(CEstudiante est in aprobados.Reverse())
                Console.WriteLine(est);

            Console.WriteLine("================");
            
            // Ordenamiento
            Console.WriteLine("Descendente");
            var ordenados = from e in estudiantes
                            orderby e.Promedio descending
                            select e;
            foreach(CEstudiante est in ordenados)
                Console.WriteLine(est);

            Console.WriteLine("Ascedente");
            var ordenadosA = from e in estudiantes
                             orderby e.Promedio ascending
                             select e;
            foreach(CEstudiante est in ordenadosA)
                Console.WriteLine(est);
            
            Console.WriteLine("================");

            int[] numeros = { 2, 5, 3, 9, 1, 6, 4, 7, 8 };

            // Encontramos el maximo
            int maximo = (from n in numeros select n).Max();
            Console.WriteLine("El maximo es {0}", maximo);

            // Encontramos el minimo
            int minimo = (from n in numeros select n).Min();
            Console.WriteLine("El minimo es {0}", minimo);

            // Encontramos el promedio
            double prom = (from n in numeros select n).Average();
            Console.WriteLine("El promedio es {0}", prom);

            // Sumatoria
            int sumatoria = (from n in numeros select n).Sum();
            Console.WriteLine("La sumatoria es {0}", sumatoria);
            
        }
    }
}
