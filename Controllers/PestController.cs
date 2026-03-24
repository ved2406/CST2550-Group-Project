using Microsoft.AspNetCore.Mvc;
using PestControlWebApp.Models;

namespace PestControlWebApp.Controllers
{
    public class PestController : Controller
    {
        private static BST _tree = new BST();

        public IActionResult Index()
        {
            return RedirectToAction("Display");
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(PestRecord record)
        {
            record.DateReported = DateTime.Now;
            _tree.Insert(record);
            return RedirectToAction("Display");
        }

        public IActionResult Search(int id)
        {
            PestRecord? result = _tree.Search(id);
            return View(result);
        }

        public IActionResult Delete(int id)
        {
            _tree.Delete(id);
            return RedirectToAction("Display");
        }

        public IActionResult Display()
        {
            List<PestRecord> records = _tree.GetAll();
            return View(records);
        }
    }
}
