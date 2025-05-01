using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AdmissionCommittee.Web.Models;
using AdmissionCommittee.BL.Contracts.Models;
using AdmissionCommittee.BL.Contracts;

namespace AdmissionCommittee.Web.Controllers
{
    /// <summary>
    /// Контроллер для работы с абитуриентами
    /// </summary>
    public class EntrantsController : Controller
    {
        private readonly IEntrantManager entrantManager;

        /// <summary>
        /// ctor
        /// </summary>
        public EntrantsController(IEntrantManager entrantManager)
        {
            this.entrantManager = entrantManager;
        }

        /// <summary>
        /// Отображает список абитуриентов
        /// </summary>
        public async Task<IActionResult> Index()
        {
            var entrants = await entrantManager.GetEntrants(CancellationToken.None);
            var stats = await entrantManager.GetEntrantStatistics(CancellationToken.None);

            var viewModel = new EntrantsViewModel
            {
                Entrants = entrants,
                Stats = stats,
            };

            return View(viewModel);
        }

        /// <summary>
        /// Отображает форму для добавления и редактирования
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return View(new Entrant());
            }

            var entrant = await entrantManager.GetEntrantOrThrowIfNull(id.Value, CancellationToken.None);
            if (entrant == null)
            {
                return NotFound();
            }

            return View(entrant);
        }

        /// <summary>
        /// Обрабатывает форму для добавления и редактирования
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Edit(Entrant entrant)
        {
            if (ModelState.IsValid)
            {
                if (entrant.Id == Guid.Empty)
                {
                    await entrantManager.Add(new EntrantRequest(
                        entrant.Name,
                        entrant.Gender,
                        entrant.Birthday,
                        entrant.EducationForm,
                        entrant.MathExamScore,
                        entrant.ITExamScore,
                        entrant.RusExamScore),
                        CancellationToken.None);
                }
                else
                {
                    await entrantManager.Edit(entrant.Id,
                        new EntrantRequest(
                        entrant.Name,
                        entrant.Gender,
                        entrant.Birthday,
                        entrant.EducationForm,
                        entrant.MathExamScore,
                        entrant.ITExamScore,
                        entrant.RusExamScore),
                        CancellationToken.None);
                }

                return RedirectToAction("Index");
            }

            return View(entrant);
        }

        /// <summary>
        /// Обработка удаления
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await entrantManager.Delete(id, CancellationToken.None);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
