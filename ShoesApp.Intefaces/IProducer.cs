using System.ComponentModel;

namespace INF148151_148140.ShoesApp.Intefaces
{
    public interface IProducer
    {
        int Id { get; set; }
        [DisplayName("Producer Name")]
        string Name { get; set; }
        string Country { get; set; }
    }
}
