using System;
// Necesario
using System.Xml.Linq;
namespace Linq_017_CadenaXML
{
    class Program
    {
        static void Main(string[] args)
        {
            // Obtenemos informacion XML a partir de una cadena
            string alumnos = @"<Alumnos>
<Alumno Nombre='Jose'>
<Curso>Programacion</Curso>
<Calificacion>8</Calificacion>
</Alumno>
<Alumno Nombre='Susana'>
<Curso>UML</Curso>
<Calificacion>9</Calificacion>
</Alumno>
<Alumno Nombre='Maria'>
<Curso>Orientado a objetos</Curso>
<Calificacion>10</Calificacion>
</Alumno>
<Alumno Nombre='Luis'>
<Curso>UML</Curso>
<Calificacion>10</Calificacion>
</Alumno>
</Alumnos>";

            XElement alumnosx = XElement.Parse(alumnos);
            Console.WriteLine(alumnosx);
        }
    }
}
