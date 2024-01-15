using INF148151_148140.ShoesApp.Intefaces;

namespace INF148151_148140.ShoesApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string execPath = System.Reflection.Assembly.GetEntryAssembly().Location;
            Console.WriteLine("Hello World!");
            string libraryName = System.Configuration.ConfigurationManager.AppSettings["DAOLibraryName"];
            BLC.BLC blc = new BLC.BLC(libraryName);

            //blc.AddFootwear(new IFootwear(1, "Adidas", blc.GetProducer(1), FootwearType.Sport));
            //blc.AddFootwear(new IFootwear(2, "Nike", blc.GetProducer(2), FootwearType.Sport));
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