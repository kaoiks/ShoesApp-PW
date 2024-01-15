using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using INF148151_148140.ShoesApp.BLC;
using INF148151_148140.ShoesApp.Intefaces;

namespace INF148151_148140.ShoesApp.Web.Controllers
{
    public class ProducersController : Controller
    {
        private BLC.BLC blc { get; set; }

        public ProducersController()
        {
            string execPath = System.Reflection.Assembly.GetEntryAssembly().Location;
            string libraryName = System.Configuration.ConfigurationManager.AppSettings["DAOLibraryName"];
            blc = new BLC.BLC(libraryName);
        }

        // GET: Producers
        public async Task<IActionResult> Index()
        {
            return View(blc.GetAllProducers());
        }
        // GET: Producers/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var producer = blc.GetProducer(id);
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
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var producer = blc.CreateProducer();
                producer.Name = collection["Name"];
                producer.Country = collection["Country"];
                blc.AddProducer(producer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: Producers/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var producer = blc.GetProducer(id);
            if (producer == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }

        // POST: Producers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection collection)
        {

            try
            {
                var producer = blc.GetProducer(id);
                if (producer == null)
                {
                    return RedirectToAction(nameof(Index));
                }
                producer.Name = collection["Name"];
                producer.Country = collection["Country"];
                blc.UpdateProducer(producer);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Producers/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var producer = blc.GetProducer(id);
            if (producer == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }

        // POST: Producers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            blc.DeleteProducer(id);
            return RedirectToAction(nameof(Index));
        }

        //private bool ProducerExists(int id)
        //{
        //  return (_context.Producers?.Any(e => e.ID == id)).GetValueOrDefault();
        //}
    }
}
