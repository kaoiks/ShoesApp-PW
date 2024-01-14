using ShoesApp.Intefaces;
using System.Reflection;

namespace ShoesApp.BLC
{
    public class BLC
    {
        private IDAO dao;

        public BLC(string libraryName)
        {
            Type? typeToCreate = null;

            Assembly assembly = Assembly.UnsafeLoadFrom(libraryName);

            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsAssignableTo(typeof(IDAO)))
                {
                    typeToCreate = type;
                    break;
                }
            }

            dao = (IDAO)Activator.CreateInstance(typeToCreate, null);
        }

        public IEnumerable<IFootwear> GetAllFootwear()
        {
            return dao.GetAllFootwear();
        }

        public IEnumerable<IProducer> GetAllProducers()
        {
            return dao.GetAllProducers();
        }

    }
}
