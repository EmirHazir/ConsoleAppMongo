using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppMongo
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsyc(args).GetAwaiter().GetResult();

        }

        static async Task MainAsyc(string[] args)
        {
            Product p = new Product();
            p.ProductName = "raket";
            p.Price = 15;
            p.Stock = 200;

            ProductRepository repository = new ProductRepository();

            await repository.Insert(p);

        }
    }
}
