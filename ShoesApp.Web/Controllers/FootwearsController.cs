using Microsoft.AspNetCore.Mvc;
using INF148151_148140.ShoesApp.Core;
using System.Globalization;
using INF148151_148140.ShoesApp.BLC;
namespace INF148151_148140.ShoesApp.Web.Controllers
{
    public class FootwearsController : Controller
    {

        private readonly BLController _blc;

        public FootwearsController()
        {

            string libraryName = System.Configuration.ConfigurationManager.AppSettings["DAOLibraryName"];
            _blc = BLController.GetInstance(libraryName);
        }


        // GET: Footwears
        public IActionResult Index(string searchTerm, string producerName, string color, decimal? minPrice, decimal? maxPrice, FootwearType? footwearType)
        {
            var allFootwear = _blc.GetAllFootwear();
            var filteredFootwear = allFootwear
                .Where(footwear =>
                    (string.IsNullOrEmpty(searchTerm) ||
                    footwear.Sku.ToLower().Contains(searchTerm.ToLower()) ||
                    footwear.Producer.Name.ToLower().Contains(searchTerm.ToLower()) ||
                    footwear.Name.ToLower().Contains(searchTerm.ToLower()) ||
                    footwear.Color.ToLower().Contains(searchTerm.ToLower())) &&
                    (string.IsNullOrEmpty(producerName) || footwear.Producer.Name.ToLower().Contains(producerName.ToLower())) &&
                    (string.IsNullOrEmpty(color) || footwear.Color.ToLower().Contains(color.ToLower())) &&
                    (!minPrice.HasValue || footwear.Price >= minPrice.Value) &&
                    (!maxPrice.HasValue || footwear.Price <= maxPrice.Value) &&
                    (!footwearType.HasValue || footwear.Type == footwearType.Value))
                .ToList();

            return View(filteredFootwear);
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
                var footwear = _blc.GetFootwear(id);
                footwear.Name = collection["Name"];
                footwear.Price = decimal.Parse(collection["Price"], CultureInfo.InvariantCulture);
                footwear.Color = collection["Color"];
                footwear.Sku = collection["Sku"];
                footwear.Producer = _blc.GetProducer(int.Parse(collection["Producer"]));
                footwear.Type = (FootwearType)Enum.Parse(typeof(FootwearType), collection["Type"]);
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {

            _blc.DeleteFootwear(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
