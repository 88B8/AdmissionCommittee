using Microsoft.Extensions.Logging;
using AdmissionCommittee.BL.Contracts;
using AdmissionCommittee.BL.Contracts.Models;
using AdmissionCommittee.Storage.Contracts;
using System.Diagnostics;

namespace AdmissionCommittee.BL
{
    /// <inheritdoc cref="IEntrantManager"/>

    public class EntrantManager : IEntrantManager
    {
        private readonly IStorage<Entrant> storage;
        private readonly ILogger<EntrantManager> logger;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="EntrantManager"/>
        /// </summary>
        public EntrantManager(IStorage<Entrant> storage, ILogger<EntrantManager> logger)
        {
            this.storage = storage;
            this.logger = logger;
        }

        async Task<IReadOnlyCollection<Entrant>> IEntrantManager.GetEntrants(CancellationToken cancellationToken)
            => await storage.GetAll(cancellationToken);

        async Task<Entrant> IEntrantManager.Add(EntrantRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            Validate(request);

            var stopwatch = Stopwatch.StartNew();
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
            stopwatch.Stop();

            logger.LogInformation("Добавлен новый абитуриент с идентификатором {EntrantId}: {@Entrant}. Время выполнения: {ElapsedMilliseconds}мс", item.Id, item, stopwatch.ElapsedMilliseconds);
            return item;
        }

        async Task<Entrant> IEntrantManager.Edit(Guid id, EntrantRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            Validate(request);
            var stopwatch = Stopwatch.StartNew();
            var item = await GetEntrantOrThrowIfNull(id, cancellationToken);

            item.Name = request.Name;
            item.Gender = request.Gender;
            item.Birthday = request.Birthday;
            item.EducationForm = request.EducationForm;
            item.MathExamScore = request.MathExamScore;
            item.RusExamScore = request.RusExamScore;
            item.ITExamScore = request.ITExamScore;

            await storage.Edit(id, item, cancellationToken);
            stopwatch.Stop();

            logger.LogInformation("Изменен абитуриент с идентификатором {EntrantId}: {@Entrant}. Время выполнения: {ElapsedMilliseconds}мс", item.Id, item, stopwatch.ElapsedMilliseconds);
            return item;
        }

        async Task IEntrantManager.Delete(Guid id, CancellationToken cancellationToken)
        {
            var stopwatch = Stopwatch.StartNew();
            var item = await GetEntrantOrThrowIfNull(id, cancellationToken);
            await storage.Delete(item.Id, cancellationToken);
            stopwatch.Stop();

            logger.LogInformation("Удален абитуриент с идентификатором {EntrantId}: {@Entrant}. Время выполнения: {ElapsedMilliseconds}мс", item.Id, item, stopwatch.ElapsedMilliseconds);
        }

        public async Task<Entrant> GetEntrantOrThrowIfNull(Guid id, CancellationToken cancellationToken)
        {
            var item = await storage.Get(id, cancellationToken);

            if (item == null)
            {
                logger.LogWarning("Не удалось найти абитуриента с идентификатором {EntrantId}", id);
                throw new InvalidOperationException($"Не удалось найти абитуриента с идентификатором {id}");
            }

            return item;
        }

        /// <summary>
        /// Возвращает статистику <see cref="EntrantStatistics"
        /// </summary>
        public async Task<EntrantStatistics> GetEntrantStatistics(CancellationToken cancellationToken)
        {
            var stopwatch = Stopwatch.StartNew();
            var items = await storage.GetAll(cancellationToken);
            var count = items.Count();
            var passedCount = items.Count(x => x.MathExamScore + x.RusExamScore + x.ITExamScore > 150);
            stopwatch.Stop();

            logger.LogInformation("Создана статистика абитуриентов. Общее кол-во: {Total}, Прошедших порог: {Passed}, Время выполнения: {ElapsedMilliseconds}мс", count, passedCount, stopwatch.ElapsedMilliseconds);

            return new EntrantStatistics(count, passedCount);
        }

        private static void Validate(EntrantRequest request)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(request.Name);
            ArgumentOutOfRangeException.ThrowIfLessThan(request.Name.Length, 3);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(request.Name.Length, 250);
        }
    }
}