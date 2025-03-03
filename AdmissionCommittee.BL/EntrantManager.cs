using System.Collections.ObjectModel;
using AdmissionCommittee.BL.Models;

namespace AdmissionCommittee.BL
{
    /// <summary>
    /// Менеджер по управлению <see cref="Entrant"/>
    /// </summary>

    public class EntrantManager
    {
        private readonly List<Entrant> entrants;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="EntrantManager"/>
        /// </summary>
        public EntrantManager()
        {
            entrants =
            [
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Петров Петр Петрович",
                    Gender = Gender.Male,
                    Birthday = DateTime.Now.AddYears(-16),
                    EducationForm = EducationForm.Fulltime,
                    MathExamScore = 78,
                    RusExamScore = 14,
                    ITExamScore = 88,
                }
            ];
        }

        /// <summary>
        /// Возвращает список <see cref="Entrant">
        /// </summary>
        public Task<IReadOnlyCollection<Entrant>> GetEntrants(CancellationToken cancellationToken) 
            => Task.FromResult((IReadOnlyCollection<Entrant>)new ReadOnlyCollection<Entrant>(entrants));

        /// <summary>
        /// Добавляет нового абитуриента
        /// </summary>
        public Task<Entrant> Add(EntrantRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            Validate(request);

            var item = new Entrant
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Gender = request.Gender,
                Birthday = request.Birthday,
                EducationForm = request.EducationForm,
                MathExamScore = request.MathExamScore,
                RusExamScore = request.RusExamScore,
                ITExamScore = request.ITExamScore,
            };

            entrants.Add(item);
            return Task.FromResult(item);
        }

        /// <summary>
        /// Редактирует абитуриента с указанным идентификатором
        /// </summary>
        public async Task<Entrant> Edit(Guid id, EntrantRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            Validate(request);
            var item = await GetEntrantOrThrowIfNull(id, cancellationToken);

            item.Name = request.Name;
            item.Gender = request.Gender;
            item.Birthday = request.Birthday;
            item.EducationForm = request.EducationForm;
            item.MathExamScore = request.MathExamScore;
            item.RusExamScore = request.RusExamScore;
            item.ITExamScore = request.ITExamScore;

            return item;
        }

        /// <summary>
        /// Удаляет абитуриента по идентификатору
        /// </summary>
        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            var item = await GetEntrantOrThrowIfNull(id, cancellationToken);
            entrants.Remove(item);
        }

        /// <summary>
        /// Возвращает статистику <see cref="EntrantStatistics"
        /// </summary>
        public Task<EntrantStatistics> GetEntrantStatistics(CancellationToken cancellationToken)
        {
            var count = entrants.Count();
            var passedCount = entrants.Count(x => x.MathExamScore + x.RusExamScore + x.ITExamScore > 150);

            return Task.FromResult(new EntrantStatistics(count, passedCount));
        }

        private Task<Entrant> GetEntrantOrThrowIfNull(Guid id, CancellationToken cancellationToken)
        {
            var item = entrants.FirstOrDefault(x => x.Id == id);

            if (item == null)
            {
                throw new InvalidOperationException($"Не удалось найти абитуриента с идентификатором {id}");
            }

            return Task.FromResult(item);
        }

        private static void Validate(EntrantRequest request)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(request.Name);
            ArgumentOutOfRangeException.ThrowIfLessThan(request.Name.Length, 3);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(request.Name.Length, 250);
        }
    }
}