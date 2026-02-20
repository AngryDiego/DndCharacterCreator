using Microsoft.AspNetCore.Mvc;

namespace DndCharacterCreator.Controllers
{
    public class TestContoller : Controller
    {
        // GET: TestContoller
        public ActionResult Index()
        {
            return View();
        }

        // GET: TestContoller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TestContoller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestContoller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TestContoller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TestContoller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TestContoller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TestContoller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
