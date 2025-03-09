using AdmissionCommittee.BL.Contracts.Models;

namespace AdmissionCommittee.BL.Contracts
{
    /// <summary>
    /// Менеджер по управлению <see cref="Entrant"/>
    /// </summary>
    public interface IEntrantManager
    {
        /// <summary>
        /// Возвращает список <see cref="Entrant"/>
        /// </summary>
        Task<IReadOnlyCollection<Entrant>> GetEntrants(CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет нового абитуриента
        /// </summary>
        Task<Entrant> Add(EntrantRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Редактирует абитуриента с указанным идентификатором
        /// </summary>
        Task<Entrant> Edit(Guid id, EntrantRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет абитуриента с указанным идентификатором
        /// </summary>
        Task Delete(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает статистику <see cref="EntrantStatistics"/>
        /// </summary>
        Task<EntrantStatistics> GetEntrantStatistics(CancellationToken cancellationToken);
    }
}
