using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace Linq_012_ProgressiveQuery
{
    class Program
    {
        static void Main(string[] args)
        {
            // En el progressive query hacemos un query en varios pasos
            // Eso nos permite meter logica antes de objetner el resultado final

            string[] postres = { "pay de manzana","pay de manzana y pera", "pastel de chocolate", "manzana caramelizada", "fresas con crema" };
            bool mayusculas = true;
            IEnumerable<string> resultado;

            var manzanas = postres.Where(n => n.Contains("manzana"));
            var ordenadas = manzanas.OrderBy(n => n);

            if (mayusculas)
                resultado = ordenadas.Select(n => n.ToUpper());
            else
                resultado = ordenadas;

            foreach(string postre in resultado)
                Console.WriteLine(postre);
            Console.WriteLine("===============");

            // Into se puede interpretar de dos formas, aqui lo vemos en una continuacion de query
            // solo se puede usar despues de select o group
            // Digamos que reinicia el query permitiendo tener otros where, orderby y select

            // Ojo con into las variables de rango salen de ambito, p no sera conocido por el query de pays

            IEnumerable<string> encontrados = from p in postres
                                              where p.Contains("manzana")
                                              orderby p
                                              select p
                                              into pays
                                              where pays.Contains("pay")
                                              select pays;

            foreach(string postre in encontrados)
                Console.WriteLine(postre);
            Console.WriteLine("===============");

            // Envolver Queries -wrapping
            // Es otra opcion de como podemos trabajar con el query
            // No confundir esta tecnica con los subqueries que colocan el query en la expression lambda

            IEnumerable<string> mipay = from p in
                                        (
                                            from p1 in postres
                                            where p1.Contains("manzana")
                                            orderby p1
                                            select p1
                                        )
                                        where p.Contains("pay")
                                        select p;
            foreach(string postre in mipay)
                Console.WriteLine(postre);
            Console.WriteLine("===============");

            // let nos permite colocar una nueva variable junto con la variable de rango
            IEnumerable<string> mispays = from p in postres
                                          let manzanitas = (
                                            from p1 in postres
                                            where p1.Contains("manzana")
                                            orderby p1
                                            select p1
                                            )
                                          where manzanitas.Contains("pay")
                                          select p;
            foreach(string postre in mispays)
                Console.WriteLine(postre);
        }
    }
}
