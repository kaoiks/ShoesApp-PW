using Microsoft.AspNetCore.Mvc;
using INF148151_148140.ShoesApp.Core;
using System.Globalization;

namespace INF148151_148140.ShoesApp.Web.Controllers
{
    public class FootwearsController : Controller
    {

        private readonly BLC.BLC _blc;

        public FootwearsController()
        {

            string libraryName = System.Configuration.ConfigurationManager.AppSettings["DAOLibraryName"];
            _blc = BLC.BLC.GetInstance(libraryName);
        }


        // GET: Footwears
        public IActionResult Index()
        {
            return View(_blc.GetAllFootwear());
        }

        // GET: Footwears/Details/5
        public IActionResult Details(int id)
        {
            return View(_blc.GetFootwear(id));
        }

        // GET: Footwears/Create
        public IActionResult Create()
        {

            ViewBag.Producers = _blc.GetAllProducers();
            return View();

        }

        // POST: Footwears/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
        {
            try
            {
                Console.WriteLine(collection["Price"]);
                var footwear = _blc.CreateFootwear();
                footwear.Name = collection["Name"];
                footwear.Price = decimal.Parse(collection["Price"], CultureInfo.InvariantCulture);
                footwear.Color = collection["Color"];
                footwear.Sku = collection["Sku"];
                footwear.Producer = _blc.GetProducer(int.Parse(collection["Producer"]));
                footwear.Type = (FootwearType)Enum.Parse(typeof(FootwearType), collection["Type"]);
                _blc.AddFootwear(footwear);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Footwears/Edit/5
        public IActionResult Edit(int id)
        {
            var footwear = _blc.GetFootwear(id);
            if (footwear == null)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Producers = _blc.GetAllProducers();
            return View(footwear);
        }

        // POST: Footwears/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Console.WriteLine(collection["Price"]);
                var footwear = _blc.GetFootwear(id);
                footwear.Name = collection["Name"];
                footwear.Price = decimal.Parse(collection["Price"]);
                footwear.Color = collection["Color"];
                footwear.Sku = collection["Sku"];
                footwear.Producer = _blc.GetProducer(int.Parse(collection["Producer"]));
                footwear.Type = (FootwearType)Enum.Parse(typeof(FootwearType), collection["Type"]);
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Footwears/Delete/5
        public IActionResult Delete(int id)
        {
            var footwear = _blc.GetFootwear(id);
            if (footwear == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(footwear);
        }

        // POST: Footwears/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {

            _blc.DeleteFootwear(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
