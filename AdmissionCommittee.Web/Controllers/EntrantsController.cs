using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AdmissionCommittee.Web.Models;
using AdmissionCommittee.BL.Contracts.Models;
using AdmissionCommittee.Storage.Contracts;

namespace AdmissionCommittee.Web.Controllers
{
    /// <summary>
    /// Контроллер <see cref="Entrant"/>
    /// </summary>
    public class EntrantsController : Controller
    {
        private readonly IStorage<Entrant> storage;

        /// <summary>
        /// ctor
        /// </summary>
        public EntrantsController(IStorage<Entrant> storage)
        {
            this.storage = storage;
        }

        /// <summary>
        /// Отображает список абитуриентов
        /// </summary>
        public async Task<IActionResult> Index()
        {
            var entrants = await storage.GetAll(CancellationToken.None);
            return View(entrants);
        }

        /// <summary>
        /// Отображает форму добавления
        /// </summary>
        [HttpGet]
        public IActionResult Add()
        {
            return View(new Entrant());
        }

        /// <summary>
        /// Обрабатывает добавление
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Add(Entrant entrant)
        {
            if (ModelState.IsValid)
            {
                entrant.Id = Guid.NewGuid();
                await storage.Add(entrant, CancellationToken.None);
                return RedirectToAction(nameof(Index));
            }

            return View(entrant);
        }

        /// <summary>
        /// Отображает форму для редактирования
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var entrant = await storage.Get(id, CancellationToken.None);
            if (entrant == null)
            {
                return NotFound();
            }

            return View(entrant);
        }

        /// <summary>
        /// Обрабатывает форму для редактирования
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Edit(Entrant entrant)
        {
            if (ModelState.IsValid)
            {
                await storage.Edit(entrant.Id, entrant, CancellationToken.None);
                return RedirectToAction(nameof(Index));
            }

            return View(entrant);
        }

        /// <summary>
        /// Обработка удаления
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await storage.Delete(id, CancellationToken.None);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}