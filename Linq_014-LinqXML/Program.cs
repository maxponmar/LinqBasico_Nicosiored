using System;

// Necesario
using System.Xml.Linq;

namespace Linq_014_LinqXML
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creamos un documento sencillo de XML con LINQ
            XElement raiz = new XElement("raiz");
            XElement el1 = new XElement("Elemento1");
            el1.Add(new XAttribute("atributo", "valor"));
            el1.Add(new XElement("Anidado", "Contenido"));

            raiz.Add(el1);
            Console.WriteLine(raiz);
            Console.WriteLine("================");

            // Esta forma de crear el documento se conoce como construccion funcional
            XElement documento = new XElement("Alumnos",
                new XElement("Ana", new XAttribute("ID", "10100"),
                    new XElement("Curso", "Administracion"),
                    new XElement("Promedio", "10")
                    ), // fin de Ana
                new XElement("Luis", new XAttribute("ID", "25350"),
                    new XElement("Curso", "Programacion"),
                    new XElement("Promedio", "9.5")
                    ) // fin de Luis
                ); // fin del documento
            Console.WriteLine(documento);
            //documento.Save("Alumnos.xml");
        }
    }
}
