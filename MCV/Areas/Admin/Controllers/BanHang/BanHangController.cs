using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MCV.Areas.Admin.Controllers.BanHang
{
    [Area("admin")]
    public class BanHangController : Controller
    {
        // GET: BanHangController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BanHangController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BanHangController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BanHangController/Create
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

        // GET: BanHangController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BanHangController/Edit/5
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

        // GET: BanHangController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BanHangController/Delete/5
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
