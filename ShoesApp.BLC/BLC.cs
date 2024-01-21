using INF148151_148140.ShoesApp.Intefaces;
using System.Diagnostics;
using System.Reflection;

namespace INF148151_148140.ShoesApp.BLC
{
	public class BLController
	{
		private static BLController instance;
		private static readonly object lockObject = new object();

		private IDAO dao;

		public BLController()
		{
            string libraryName = System.Configuration.ConfigurationManager.AppSettings["DAOLibraryName"];
            GetInstance(libraryName);
        }

		private BLController(string libraryName)
		{

				Type? typeToCreate = null;
				string path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
				string libraryPath = string.Join("\\", path, libraryName);
				Assembly assembly = Assembly.UnsafeLoadFrom(libraryPath);
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

		public static BLController GetInstance(string libraryName)
		{
			if (instance == null)
			{
				lock (lockObject)
				{
					if (instance == null)
					{
						instance = new BLController(libraryName);
					}
				}
			}
            
            return instance;
		}

		public IEnumerable<IFootwear> GetAllFootwear()
		{
			return dao.GetAllFootwear();
		}

		public IEnumerable<IProducer> GetAllProducers()
		{
			return dao.GetAllProducers();
		}

		public IFootwear GetFootwear(int id)
		{
			return dao.GetFootwear(id);
		}
		public IProducer GetProducer(int id)
		{
			return dao.GetProducer(id);
		}

		public void AddFootwear(IFootwear footwear)
		{
			dao.AddFootwear(footwear);
		}

		public IProducer CreateProducer()
		{
			return dao.CreateProducer();
		}
		public IFootwear CreateFootwear()
		{
			return dao.CreateFootwear();
		}

		public void AddProducer(IProducer producer)
		{
			dao.AddProducer(producer);
		}

		public void UpdateFootwear(IFootwear footwear)
		{
			dao.UpdateFootwear(footwear);
		}

		public void UpdateProducer(IProducer producer)
		{
			dao.UpdateProducer(producer);
		}

		public void DeleteProducer(int id)
		{
			dao.RemoveProducer(id);
		}
		public void DeleteFootwear(int id)
		{
			dao.RemoveFootwear(id);
		}

	}
}
