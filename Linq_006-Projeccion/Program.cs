using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq_006_Projeccion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Hacemos proyeccion a un nuevo tipo por medio de tipos anonimos

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

            var nombrePromedio = from e in estudiantes
                                 select new { e.Nombre, e.Promedio };

            foreach(var np in nombrePromedio)
                Console.WriteLine(np.ToString());
        }
    }
}
