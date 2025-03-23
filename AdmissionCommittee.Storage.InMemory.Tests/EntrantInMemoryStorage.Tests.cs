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
                    Id = target.Id,
                    Age = 14,
                });
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
            Func<Task> act = () => storage.Delete(Guid.NewGuid(), CancellationToken.None);

            // Assert
            await act.Should().NotThrowAsync();
            var result = await storage.Get(target.Id, CancellationToken.None);
            result.Should().BeNull();
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public async Task GetAllShouldReturnValues()
        {
            var target = CreateEntrant();
            await storage.Add(target, CancellationToken.None);

        }

        private static Entrant CreateEntrant()
            => new()
            {
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