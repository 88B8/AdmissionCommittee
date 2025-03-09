using AdmissionCommittee.BL.Contracts;
using AdmissionCommittee.BL.Contracts.Models;
using AdmissionCommittee.Storage.Contracts;

namespace AdmissionCommittee.BL
{
    /// <inheritdoc cref="IEntrantManager"/>

    public class EntrantManager : IEntrantManager
    {
        private readonly IStorage<Entrant> storage;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="EntrantManager"/>
        /// </summary>
        public EntrantManager(IStorage<Entrant> storage)
        {
            this.storage = storage;
        }

        async Task<IReadOnlyCollection<Entrant>> IEntrantManager.GetEntrants(CancellationToken cancellationToken)
            => await storage.GetAll(cancellationToken);

        async Task<Entrant> IEntrantManager.Add(EntrantRequest request, CancellationToken cancellationToken)
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

            await storage.Add(item, cancellationToken);

            return item;
        }

        async Task<Entrant> IEntrantManager.Edit(Guid id, EntrantRequest request, CancellationToken cancellationToken)
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

            await storage.Edit(id, item, cancellationToken);

            return item;
        }

        async Task IEntrantManager.Delete(Guid id, CancellationToken cancellationToken)
        {
            var item = await GetEntrantOrThrowIfNull(id, cancellationToken);
            await storage.Delete(item.Id, cancellationToken);
        }

        /// <summary>
        /// Возвращает статистику <see cref="EntrantStatistics"
        /// </summary>
        public async Task<EntrantStatistics> GetEntrantStatistics(CancellationToken cancellationToken)
        {
            var items = await storage.GetAll(cancellationToken);
            var count = items.Count();
            var passedCount = items.Count(x => x.MathExamScore + x.RusExamScore + x.ITExamScore > 150);

            return new EntrantStatistics(count, passedCount);
        }

        private async Task<Entrant> GetEntrantOrThrowIfNull(Guid id, CancellationToken cancellationToken)
        {
            var item = await storage.Get(id, cancellationToken);

            if (item == null)
            {
                throw new InvalidOperationException($"Не удалось найти абитуриента с идентификатором {id}");
            }

            return item;
        }

        private static void Validate(EntrantRequest request)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(request.Name);
            ArgumentOutOfRangeException.ThrowIfLessThan(request.Name.Length, 3);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(request.Name.Length, 250);
        }
    }
}