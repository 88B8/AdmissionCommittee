using AdmissionComittee.Storage.InMemory;
using AdmissionCommittee.BL.Contracts.Models;
using AdmissionCommittee.Storage.Contracts;
using FluentAssertions;
using Xunit;

namespace AdmissionCommittee.Storage.InMemory.Tests
{
    /// <summary>
    /// Тесты для <see cref="EntrantInMemoryStorage"/>
    /// </summary>
    public class EntrantInMemoryStorageTests
    {
        private readonly IStorage<Entrant> storage;

        /// <summary>
        /// ctor
        /// </summary>
        public EntrantInMemoryStorageTests()
        {
            storage = new EntrantInMemoryStorage();
        }

        /// <summary>
        /// Не находит <see cref="Entrant"/>
        /// </summary>
        [Fact]
        public async Task GetShouldReturnNull()
        {
            // Act
            var result = await storage.Get(Guid.NewGuid(), CancellationToken.None);

            // Assert
            result.Should().BeNull();
        }

        /// <summary>
        /// Проверяет добавление объекта в хранилище
        /// </summary>
        [Fact]
        public async Task AddShouldReturnValue()
        {
            // Arrange
            var target = CreateEntrant();

            // Act
            await storage.Add(target, CancellationToken.None);
            var result = await storage.Get(target.Id, CancellationToken.None);

            // Assert
            result.Should().NotBeNull()
                .And
                .BeEquivalentTo(new
                {
                    target.Id,
                });
        }

        /// <summary>
        /// Проверяет правильность редактирования абитуриента
        /// </summary>
        [Fact]
        public async Task EditShouldWork()
        {
            // Arrange
            var target1 = CreateEntrant();
            var target2 = CreateEntrant();
            target2.Name = "Петров П.П.";
            await storage.Add(target1, CancellationToken.None);

            // Act
            await storage.Edit(target1.Id, target2, CancellationToken.None);
            var result = await storage.Get(target1.Id, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(target2, options => options.Excluding(x => x.Id));
        }

        /// <summary>
        /// Удаление падает с ошибкой: элемент не найден
        /// </summary>
        [Fact]
        public async Task DeleteShouldThrow()
        {
            // Act
            Func<Task> act = () => storage.Delete(Guid.NewGuid(), CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<InvalidOperationException>();
        }

        /// <summary>
        /// Удаляет существующий элемент
        /// </summary>
        [Fact]
        public async Task DeleteShouldWork()
        {
            // Arrange
            var target = CreateEntrant();
            await storage.Add(target, CancellationToken.None);

            // Act
            Func<Task> act = () => storage.Delete(target.Id, CancellationToken.None);

            // Assert
            await act.Should().NotThrowAsync();
            var result = await storage.Get(target.Id, CancellationToken.None);
            result.Should().BeNull();
        }

        /// <summary>
        /// Проверяет получение всех абитуриентов
        /// </summary>
        [Fact]
        public async Task GetAllShouldReturnValues()
        {
            // Arrange
            var target = CreateEntrant();
            await storage.Add(target, CancellationToken.None);

            // Act
            var result = await storage.GetAll(CancellationToken.None);

            // Assert
            result.Should().HaveCount(2)
                .And.ContainSingle(x => x.Id == target.Id);
        }

        private static Entrant CreateEntrant()
            => new()
            {
                Id = Guid.NewGuid(),
                Name = "Иванов И.И.",
                Gender = Gender.Male,
                Birthday = DateTime.Now.AddYears(-18),
                EducationForm = EducationForm.Fulltime,
                MathExamScore = 14,
                RusExamScore = 22,
                ITExamScore = 11,
            };
    }
}