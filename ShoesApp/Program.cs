using ShoesApp.Intefaces;

namespace ShoesApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string libraryName = System.Configuration.ConfigurationManager.AppSettings["DAOLibraryName"];
            BLC.BLC blc = new BLC.BLC(libraryName);

            foreach (IProducer p in blc.GetAllProducers())
            {
                Console.WriteLine($"{p.ID}: {p.Name} ");
            }
            Console.WriteLine("----------------------");

            foreach (IFootwear f in blc.GetAllFootwear())
            {
                Console.WriteLine($"{f.ID}: {f.Name} {f.Producer.Name} {f.Type}");
            }

        }
    }
}