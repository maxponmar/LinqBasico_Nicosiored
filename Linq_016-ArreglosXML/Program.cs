using System;
using System.ComponentModel;
using System.Linq;
// Necesario
using System.Xml.Linq;

namespace Linq_016_ArreglosXML
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creamos XML a partir de un arreglo
            // Funciona con otros contenedores tambien

            // Usamos tipos anonimos pero funciona con clases normales tambien
            var listado = new[]
            {
                new {Nombre="Jose", Calif=8, Curso="Programacion"},
                new {Nombre="Susana", Calif=9, Curso="UML"},
                new {Nombre="Maria", Calif=10, Curso="Orientado a objetos"},
                new {Nombre="Luis", Calif=10, Curso="UML"},
            };

            // Ahora creamos el elemento
            XElement alumnos = new XElement("Alumnos", // Este es la raiz
                from a in listado
                select new XElement("Alumno", new XAttribute("Nombre", a.Nombre),
                       new XElement("Curso", a.Curso),
                       new XElement("Calificacion", a.Calif)
                       )// fin de alumnp
                ); // fin de alumnos
            Console.WriteLine(alumnos);
            alumnos.Save("Alumnos.xml");
        }
    }
}
