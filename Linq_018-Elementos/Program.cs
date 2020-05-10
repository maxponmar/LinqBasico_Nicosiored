using System;
using System.Collections.Generic;
using System.Linq;
// Necesario
using System.Xml.Linq;
namespace Linq_018_Elementos
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new XElement("Escuela",
                                        new XElement("Ciencias",
                                            new XElement("Materia", "Matematicas"),
                                            new XElement("Materia", "Fisica")
                                            ),
                                        new XElement("Artes",
                                            new XElement("Materia", "Historia del arte"),
                                            new XElement("Practica", "Pintura")
                                            )
                                        );
            Console.WriteLine(escuela);
            Console.WriteLine("-----------------------");
            
            // Nodes regresa a los hijos
            foreach(XNode nodo in escuela.Nodes())
                Console.WriteLine(nodo.ToString());
            Console.WriteLine("-----------------------");

            // Elements regresa los hijos de los nodos en tipo XElement
            foreach(XElement elemento in escuela.Elements())
                Console.WriteLine(elemento);//.Name + "=" + elemento.Value);
            Console.WriteLine("-----------------------");

            // FirstNode nos regresa el primer nodo
            Console.WriteLine(escuela.FirstNode);

            // Encontramos el padre del primer nodo
            Console.WriteLine(escuela.FirstNode.Parent.Name);
            Console.WriteLine("-----------------------");

            // LastNode nos regresa el ultimo nodo
            Console.WriteLine(escuela.LastNode);
            Console.WriteLine("-----------------------");

            // Obtiene todos los elementos del curso donde se encuentre Fisica
            IEnumerable<string> materias = from curso in escuela.Elements()
                                           where curso.Elements().Any(materia => materia.Value == "Fisica")
                                           select curso.Value;
            foreach(string s in materias)
                Console.WriteLine(s);
            Console.WriteLine("-----------------------");

            // Obtiene el nombre del elemento padre de fisica
            IEnumerable<XName> tipoCurso = from curso in escuela.Elements()
                                           where curso.Elements().Any(m => m.Value == "Fisica")
                                           select curso.Name;
            foreach (XName s in tipoCurso)
                Console.WriteLine(s);
            Console.WriteLine("-----------------------");

            // Solamente selecciona a los nodos materia
            IEnumerable<string> materias2 = from curso in escuela.Elements()
                                            from asgnatura in curso.Elements()
                                            where asgnatura.Name == "Materia"
                                            select asgnatura.Value;
            foreach (string s in materias2)
                Console.WriteLine(s);
            Console.WriteLine("-----------------------");

            // Contamos los elementos de un tipo en particular
            int n = escuela.Elements("Ciencias").Count();
            Console.WriteLine("Hay {0} Ciencias", n);
            Console.WriteLine("-----------------------");

            // Element nos da la primera ocurrencia de un elemento con ese nombre
            string mat = escuela.Element("Ciencias").Element("Materia").Value;
            Console.WriteLine(mat);
            Console.WriteLine("-----------------------");

            // Obtenemos el siguiente nodo, estilo lista ligada
            XNode xnodo = escuela.FirstNode;
            Console.WriteLine(xnodo);
            Console.WriteLine("--- Tomamos el siguiente ---");
            xnodo = xnodo.NextNode;
            Console.WriteLine(xnodo);
            Console.WriteLine("-----------------------");

            // Otra forma de crear un elemento, el parent es escuela
            escuela.SetElementValue("Deportes", "No hay");
            Console.WriteLine(escuela);
            Console.WriteLine("-----------------------");
            // Si lo volvemos a usar se actualiza
            escuela.SetElementValue("Deportes", "Sin presupuesto");
            Console.WriteLine(escuela);

            // Para adicionar despues de un elemento, el primer nodo es el punto de referencia
            escuela.FirstNode.AddAfterSelf(new XElement("Asignaturas"));
            Console.WriteLine(escuela);
            Console.WriteLine("-----------------------");
            // Ahora adicionamos un elemento antes ed ese
            escuela.FirstNode.AddBeforeSelf(new XElement("EscuelaLibre"));
            Console.WriteLine(escuela);
            Console.WriteLine("-----------------------");

            // Obtenemos a matematicas
            var mate = escuela.Element("Ciencias").Element("Materia");
            // Le damos un valor
            mate.SetValue("Geometria no Euclidiana");
            Console.WriteLine(escuela);

            // Obtenemos el valor de ese elemento
            string valorMate = mate.Value;
            Console.WriteLine(valorMate);

            // Descendats regresa a los nodos hijos y todos sus descendientes
            // Cargamos un XML de archivo
            // No olvidar poner un .xml en el directorio para cargar
            XDocument alumnos = XDocument.Load("alumnos.xml");
            Console.WriteLine(alumnos);
            Console.WriteLine("-----------------------");

            // Eliminamos a los alumnos
            //alumnos.Descendants("Alumnos").Remove();
            //Console.WriteLine(alumnos);
            Console.WriteLine("-----------------------");

            // Eliminamos calificaciones
            //alumnos.Descendants("Promedio").Remove();
            //Console.WriteLine(alumnos);
            //Console.WriteLine("-----------------------");

            // Obtenemos las calificaciones
            var califs = from a in alumnos.Descendants("Promedio")
                         select a.Value;
            foreach(var calif in califs)
                Console.WriteLine(calif);
        }
    }
}
