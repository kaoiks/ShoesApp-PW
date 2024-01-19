using Microsoft.AspNetCore.Mvc;

namespace INF148151_148140.ShoesApp.Web.Controllers
{
    public class ProducersController : Controller
    {
        private readonly BLC.BLC _blc;

        public ProducersController()
        {
            string libraryName = System.Configuration.ConfigurationManager.AppSettings["DAOLibraryName"];
            _blc = BLC.BLC.GetInstance(libraryName);
        }

        // GET: Producers
        public IActionResult Index()
        {
            return View(_blc.GetAllProducers());
        }
        // GET: Producers/Details/5
        public IActionResult Details(int id)
        {
            var producer = _blc.GetProducer(id);
            if (producer == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }

        // GET: Producers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Producers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
        {
            try
            {
                var producer = _blc.CreateProducer();
                producer.Name = collection["Name"];
                producer.Country = collection["Country"];
                _blc.AddProducer(producer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: Producers/Edit/5
        public IActionResult Edit(int id)
        {
            var producer = _blc.GetProducer(id);
            if (producer == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }

        // POST: Producers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
        {

            try
            {
                var producer = _blc.GetProducer(id);
                if (producer == null)
                {
                    return RedirectToAction(nameof(Index));
                }
                producer.Name = collection["Name"];
                producer.Country = collection["Country"];
                _blc.UpdateProducer(producer);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Producers/Delete/5
        public IActionResult Delete(int id)
        {
            var producer = _blc.GetProducer(id);
            if (producer == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }

        // POST: Producers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _blc.DeleteProducer(id);
            return RedirectToAction(nameof(Index));
        }

        //private bool ProducerExists(int id)
        //{
        //  return (_context.Producers?.Any(e => e.ID == id)).GetValueOrDefault();
        //}
    }
}
