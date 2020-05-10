using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Linq_013_Operadores01
{
    class Program
    {
        static void Main(string[] args)
        {
            // Hay tres categorias para los operadores de query
            // Secuencia a secuencia (secuencia de entrada, secuencia de salida)
            // Secuencia de entrada, elemento sencillo o escalar
            // Nada de entrada, secuencia de salida

            // Secuencia a secuencia
            // Filtro: where, take, takewhile, skip, skipwhile, distinct
            // Proyeccion: select, selectmany
            // Union: join, groupjoin, zip
            // Ordenamiento: orderby, thenby, reverse
            // Agrupamiento: groupby
            // operadores de conjuntos: concat, union, intersect, except
            // Conversion improt: oftype, cast
            // Conversion export: toarray, todictionary, tolookup, asenumerable, asqueryable

            // Secuencia a elemento o escalar
            // Operadores de elemnto: first, firstordefault, last, lastordefault, single, singleordefault, elementat, elementatordefault, defaultempty
            // Agregacion: aggregate, averge, count, longcount, sum, max, min
            // Cuantificador: all, any, contains, sequenceequal

            // Nada de entrada, secuencia de salida
            // Generacion: empty, range, repeat

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            // Filtro

            // Where regresa un subconjunto de elementos que satisfacen una condicion 
            // Take regresa el primer elemento n e ignora el resto
            // Skip ignora los primeros n elementos y regresa el resto
            // TakeWhile emite los elementos de la secuencia de entrada hasta que el predicado es falso
            // SkipWhile ignora los elementos de la sequencia de entrada hasta que el predicado es falso, luego emite el resto
            // Distinct regresa una sequencia que excluye a los duplicados

            // Where
            // Aparte de lo que hemos visto, where permite un segundo argumento de tipo int que simboliza el indice del elemento
            // Esto se conoce como filtrado por indice

            string[] postres = { "pay de manzana", "pastel de chocolate", "manzana caramelizada", "fresas con crema", "pay de perza y manzana" };

            Console.WriteLine("\n===== FILTRO =====\n");

            Console.WriteLine("===== Where ======\n");
            IEnumerable<string> r1 = postres.Where((n, i) => i % 2 == 0);
            foreach(string postre in r1)
                Console.WriteLine(postre);
            Console.WriteLine("----------");
            IEnumerable<string> r2 = from p in postres
                                     where p.StartsWith("pay")
                                     select p;
            foreach (string postre in r2)
                Console.WriteLine(postre);
            Console.WriteLine("----------");
            IEnumerable<string> r3 = from p in postres
                                     where p.EndsWith("manzana")
                                     select p;
            foreach (string postre in r3)
                Console.WriteLine(postre);

            Console.WriteLine("\n===== TakeWhile ======\n");
            // TakeWhile enumera la secuencia de entrada y emite cada elemento hasta que el predicado es falso
            // ignora el resto

            int[] numeros = { 1, 5, 7, 3, 5, 9, 8, 11, 2, 4 };
            var r4 = numeros.TakeWhile(n => n < 8);
            foreach (int n in r4)
                Console.WriteLine(n);
            Console.WriteLine("----------");
            // SkipWhile enumera la secuencia, ignora los elementos hasta que el predicado es falso
            // y emite el resto
            var r5 = numeros.SkipWhile(n => n < 8);
            foreach (int n in r5)
                Console.WriteLine(n);

            // Proyeccion
            Console.WriteLine("\n===== PROYECCION =====\n");
            // Select transforma el elemento de entrada con la expresion lambda
            // SelectMany transforma el elemento, lo aplana y concatena con los subsecuencias resultantes

            // Proyeccion indexada
            Console.WriteLine("===== Proyeccion Indexada =====\n");
            IEnumerable<string> r6 = postres.Select((p, i) => "Indice " + 1 + " para el postre " + p);
            foreach(string n in r6)
                Console.WriteLine(n);
            Console.WriteLine("----------");
            // SelectMany
            // En Select cada elemento de entrada produce un elemento de saluda
            // SelectMany produce 0...n elementos
            Console.WriteLine("===== SelectMany =====\n");
            IEnumerable<string> r7 = postres.SelectMany(p => p.Split());
            foreach (string n in r7)
                Console.WriteLine(n);
            Console.WriteLine("----------");
            // Comparamos con Select
            Console.WriteLine("Comparamos con Select");
            IEnumerable<string[]> r8 = postres.Select(p => p.Split());
            foreach (string[] n in r8)
            {
                Console.WriteLine("-");
                foreach(string m in n)
                    Console.WriteLine(m);
            }
            Console.WriteLine("----------");
            // Select con multiples variables de rango
            Console.WriteLine("===== Select con multiples variables =====\n");
            IEnumerable<string> r9 = from p in postres
                                     from p1 in p.Split()
                                     select p1 + " ===> " + p;
            foreach(string n in r9)
                Console.WriteLine(n);
            Console.WriteLine("----------");
            IEnumerable<string> r10 = from p in postres
                                      from p1 in postres
                                      select "Yo quiero: " + p1 + " y tu quieres: " + p;
            foreach (string n in r10)
                Console.WriteLine(n);
            Console.WriteLine("----------");

            // Union-Joining
            // Join une los elementos de dos colecciones en un solo conjunto
            // GroupJoin es como Join pero da un resultado jerarquico
            // Zip enumera dos secuencias y aplica una funcion a cada par

            Console.WriteLine("\n===== Join =====\n");
            List<CEstudiante> estudiantes = new List<CEstudiante>
            {
                new CEstudiante("Ana", 100),
                new CEstudiante("Mario", 150),
                new CEstudiante("Ana", 180)
            };
            List<CCurso> cursos = new List<CCurso>
            {
                new CCurso("Programacion", 100),
                new CCurso("Orientado a objetos", 150),
                new CCurso("Programacion", 150),
                new CCurso("Programacion", 180),
                new CCurso("UML", 100),
                new CCurso("Orientado a objetos", 100),
                new CCurso("UML", 180)
            };
            var listado = from e in estudiantes
                          join c in cursos on e.Id equals c.Id
                          select e.Nombre + " esta en el curso " + c.Curso;
            foreach (string n in listado)
                Console.WriteLine(n);

            Console.WriteLine("\n===== GroupJoin =====\n");
            // Los resultados se obtienen de forma jerarquica
            // la sintaxis es la misma pero utilizamos into
            var listado2 = from e in estudiantes
                           join c in cursos on e.Id equals c.Id
                           into tempListado
                           select new { estudiante = e.Nombre, tempListado };

            foreach (var lst in listado2)
            {
                Console.WriteLine(lst.estudiante);
                foreach(var lst2 in lst.tempListado)
                    Console.WriteLine(lst2);
            }

            // ZIP
            // Regresa una secuencia que aplica una funcion a cada par
            Console.WriteLine("\n===== ZIP =====\n");
            string[] helados = { "chocolate", "vainilla", "fresa", "limon" };
            IEnumerable<string> r12 = postres.Zip(helados, (p, h) => p + " con helado de " + h);
            foreach(string n in r12)
                Console.WriteLine(n);


            // Ordenamiento
            // OrderBy, ThenBy, Ordena en orden ascendente
            // OrderByDescending, ThenByDescending ordena en orden descendente
            // Reverse regresa en el orden inverso
            Console.WriteLine("\n===== Ordenamiento =====\n");
            IEnumerable<int> numOrder = numeros.OrderBy(n => n);
            IEnumerable<int> numDes = numeros.OrderByDescending(n => n);
            foreach(int n in numOrder)
                Console.WriteLine(n);
            foreach (int n in numDes)
                Console.WriteLine(n);
            Console.WriteLine("----------");
            string[] palabras = { "hola", "piedra", "pato", "pastel", "carros", "auto" };
            IEnumerable<string> palabrasOrd = palabras.OrderBy(p => p.Length).ThenBy(p => p);
            foreach(string n in palabrasOrd)
                Console.WriteLine(n);


            // Agrupamiento
            // GroupBy agrupa una secuencia en subsecuencias
            Console.WriteLine("\n===== Agrupamiento =====\n");
            string[] archivos = System.IO.Directory.GetFiles("d:\\04_Files\\Misc");
            Console.WriteLine("Archivos obtenidos por GetFiles");
            foreach(string n in archivos)
                Console.WriteLine(n);

            // Agrupamos basados en la extension
            // Dentro de () colocamos el criterio de agrupamiento
            var archivoAg = archivos.GroupBy(a => System.IO.Path.GetExtension(a));
            Console.WriteLine("Resultados agrupados");
            foreach(IGrouping<string, string>g in archivoAg)
            {
                Console.WriteLine("Archivos de extension {0}", g.Key);
                foreach(string a in g)
                    Console.WriteLine("\t {0}", a);
            }

            // Conjuntos
            // Concat, Union, Intersect, Except

            // Conversion
            // OfType convierte IEnumerable a IEnumerable<T>, desecha los elementos erroneos
            // Cast convierte de IEnumerable a Ienumerable<T>, lanza excepcion con los elementos erroneos
            // ToArray convierte de IEnumerable<T> a T[]
            // ToList convierte de IEnumerable<T> a List<T>
            // ToDictionary convierte de IEnumerable<T> a Dictionary<TKey, TValue>
            // ToLookup convierte de IEnumerable<T> a ILookup<TKey, TElement>
            // AsEnumerable hace downcast a IEnumerable<T>
            // AsQueryable hace cast o convierte a IQueryable<T>


            // De elemento
            // First, FirstOrDefault    Regresa primer elemento de la secuencia
            // Last, LastOrDefault      Regresa el ultimo elemento de la secuencia           
            // Single, SingleOrDefault  Equivalente a First, FirstOrDefault pero lanza excepcion si hay mas de uno
            // ElementAt, ElementAtOrDefault    Regresa el elemento de determinada posicion
            // DefulatIfEmpty           Regresa al elemento de default si la secuencia no tiene elementos

            Console.WriteLine("\n===== De elemento =====\n");
            int primero = numeros.First();
            Console.WriteLine(primero);
            int primeroc = numeros.First(n => n % 2 == 0);
            Console.WriteLine(primeroc);
            int primerod = numeros.FirstOrDefault(n => n % 57 == 0);
            Console.WriteLine(primerod);

            // Agregacion
            // Count, LongCount regresa la cantidad de elementos en la secuencia int o int64
            // Min regresa el eleento menor de la secuencia
            // Max regresa el elemento mayor de la secuencia
            // Sum regresa la sumatoria de los elementos
            // Average regresa el promedio de los elementos
            // Aggregate hace una agregacion usando nuestro algoritmo

            Console.WriteLine("\n===== De agregacion =====\n");
            int sumatoria = numeros.Sum();
            Console.WriteLine(sumatoria);
            int[] numeros2 = { 1, 2, 3, 4, 5 };
            // En este caso la semilla es cero, si no se pone la semilla, toma el primer valor
            int agregado = numeros2.Aggregate(0, (t, n) => t + (n * 2));
            Console.WriteLine(agregado);


            // Cuantificadores
            // Contains regresa true si la secuencia contiene al elemento
            // Any regresa true si un elemento satisface el predicado
            // All regresa true si todos los elementos satisfacen el predicado
            // SequenceEqual regresa true si la segunda secuencia tiene elementos identicos a la de entrada

            Console.WriteLine("\n===== Cuantificadores =====\n");
            bool todos = numeros2.All(n => n < 10);
            Console.WriteLine(todos);
            bool iguales = numeros2.SequenceEqual(numeros);
            Console.WriteLine(iguales);

            // Generacion
            // Empty crea una secuencia vacia
            // Repeat crea una secuencia de elementos que se repiten
            // Range crea una secuencia de enteros

            Console.WriteLine("\n===== Generacion =====\n");
            var vacio = Enumerable.Empty<int>();
            foreach(int n in vacio)
                Console.WriteLine(n);
            Console.WriteLine("----------");
            var repetir = Enumerable.Repeat("hola ", 5);
            foreach (string n in repetir)
                Console.WriteLine(n);
            Console.WriteLine("----------");
            var rango = Enumerable.Range(5, 15);
            foreach (int n in rango)
                Console.WriteLine(n);
            Console.WriteLine("----------");

        }
    }
}
