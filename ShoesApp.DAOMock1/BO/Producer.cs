using ShoesApp.Intefaces;

namespace ShoesApp.DAOMock1.BO
{
    public class Producer : IProducer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
