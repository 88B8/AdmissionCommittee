namespace AdmissionCommittee.Storage.Contracts
{
    /// <summary>
    /// Хранение сущностей <see cref="T"/>
    /// </summary>
    public interface IStorage<T>
    {
        /// <summary>
        /// Получает список всех сущностей <see cref="T"/>
        /// </summary>
        Task<IReadOnlyCollection<T>> GetAll(CancellationToken cancellationToken);

        /// <summary>
        /// Получает сущность по идентификатору
        /// </summary>
        Task<T?> Get(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет сущность <see cref="T"/> в хранилище
        /// </summary>
        Task Add(T item, CancellationToken cancellationToken);

        /// <summary>
        /// Редактирует сущность по идентификатору
        /// </summary>
        Task Edit(Guid id, T item, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет сущность <see cref="T"/> из хранилища
        /// </summary>
        Task Delete(Guid id, CancellationToken cancellationToken);

    }
}