using System;
using System.Linq;
using System.Collections.Generic;

namespace Linq_004_Clases
{
    class Program
    {
        static void Main(string[] args)
        {
            // Uso de LINQ con clases

            // Creamos una listas
            List<CEstudiante> estudiantes = new List<CEstudiante>
            {
                new CEstudiante("Ana","A100", "Mercadotecnia", 10.0),
                new CEstudiante("Luis", "S250", "Oriantado a objetos", 9.0),
                new CEstudiante("Juan", "S875", "Programacion basica", 5.0),
                new CEstudiante("Susana","A432", "Mercadotecnia", 8.7),
                new CEstudiante("Pablo", "A156", "Mercadotecnia", 4.3),
                new CEstudiante("Alberto", "S456", "Orientado a objetos", 8.3)
            };

            // Encontramos a los reprobrados
            var reprobados = from e in estudiantes
                             where e.Promedio <= 5.0
                             select e;

            // Mostramos
            Console.WriteLine("Reprobados");
            foreach(CEstudiante r in reprobados)
                Console.WriteLine(r);

            // Mostramos solo un atributo de los encontrados por medio de la propiedad
            Console.WriteLine("Solo con nombre");
            foreach (CEstudiante r in reprobados)
                Console.WriteLine(r.Nombre);

            // Encontramos solo los nombres de los de mercadotecnia
            var mercadotecnia = from e in estudiantes
                                where e.Curso == "Mercadotecnia"
                                select e.Nombre;

            Console.WriteLine("Nombres de mercadotecnia");
            foreach(string n in mercadotecnia)
                Console.WriteLine(n);
        }
    }
}
