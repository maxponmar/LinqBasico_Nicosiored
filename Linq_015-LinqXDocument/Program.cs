using System;
// Necesario
using System.Xml.Linq;

namespace Linq_015_LinqXDocument
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creamos un documento XML mas completo

            XDocument documento = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"), // Colocamos la declaracion del documento
                new XComment("Listado de alumnos"), // Con eso colocamos un comentario
                new XProcessingInstruction("xml-stylesheet", "href='MyStyles.css' title='Compact' type='text/css'"),
                new XElement("Alumnos", // Lleva namespace {http://nicosio.com}
                    new XElement("Ana", new XAttribute("ID", "10100"),
                        new XElement("Curso", "Administracion"),
                        new XElement("Promedio", "10")
                        ), // fin de Ana
                    new XElement("Luis", new XAttribute("ID", "25350"),
                        new XElement("Curso", "Programacion"),
                        new XElement("Promedio", "9.5")
                        ) // fin de Luis
                    ) // fin de alumnos
                ); // fin de documento
            Console.WriteLine(documento);
            documento.Save("alumnos.xml");
        }
    }
}
