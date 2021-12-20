using System;
using System.Collections.Generic;
using System.Linq;

namespace SeleccionalrBuscarOrdenar
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Beer> beers = new List<Beer>()
            {
                new Beer()
                {
                    Name = "Corona",
                    Country = "México"
                },
                new Beer()
                {
                    Name = "Delirium",
                    Country = "Bélgica"
                },
                new Beer()
                {
                    Name = "Erdiger",
                    Country = "Alemania"
                }
            };

            foreach(var beer in beers)
                Console.WriteLine(beer);

            Console.WriteLine("---------------------------------------");

            //Select
            var beersName = from b in beers
                            select new
                            {
                                Name = b.Name,
                                Letters = b.Name.Length,
                                Fixed = 1
                            };
            foreach(var beer in beersName)
                Console.WriteLine($"{beer.Name}, {beer.Letters}, {beer.Fixed}");

            Console.WriteLine("---------------------------------------");

            var beerNameReal = from b in beersName
                               select new
                               {
                                   Name = b.Name
                               };
            foreach (var beer in beerNameReal)
                Console.WriteLine(beer.Name);

            Console.WriteLine("---------------------------------------");

            var beersMexico = from b in beers
                              where b.Country == "México"
                              || b.Country == "Alemania"
                              select b;
            foreach (var beer in beersMexico)
                Console.WriteLine(beer);

            Console.WriteLine("---------------------------------------");

            var orderBeer = from b in beers
                            orderby b.Country
                            select b;
            foreach(var beer in orderBeer)
                Console.WriteLine(beer);
        }
    }

    public class Beer
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public override string ToString()
        {
            return $"Nombre: {Name}, País: {Country}";
        }
    }
}
