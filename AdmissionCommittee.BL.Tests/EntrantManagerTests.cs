using Moq;
using AdmissionCommittee.BL.Contracts;
using AdmissionCommittee.BL.Contracts.Models;
using AdmissionCommittee.Storage.Contracts;
using Xunit;
using FluentAssertions;
using Microsoft.Extensions.Logging;

namespace AdmissionCommittee.BL.Tests
{
    /// <summary>
    /// Тесты для <see cref="EntrantManager"/>
    /// </summary>
    public class EntrantManagerTests
    {
        private readonly IEntrantManager entrantManager;
        private readonly Mock<IStorage<Entrant>> storageMock;
        private readonly Mock<ILogger> loggerMock;
        
        /// <summary>
        /// ctor
        /// </summary>
        public EntrantManagerTests()
        {
            storageMock = new Mock<IStorage<Entrant>>();
            loggerMock = new Mock<ILogger>();

            entrantManager = new EntrantManager(storageMock.Object, loggerMock.Object);
        }

        /// <summary>
        /// Возвращает пустую коллекцию
        /// </summary>
        [Fact]
        public async Task GetEntrantsShouldReturnEmpty()
        {
            // Arrange
            storageMock.Setup(x => x.GetAll(It.IsAny<CancellationToken>()))
                .ReturnsAsync(Array.Empty<Entrant>());

            // Act
            var result = await entrantManager.GetEntrants(CancellationToken.None);

            // Assert
            result.Should().BeEmpty();
            storageMock.Verify(x => x.GetAll(It.IsAny<CancellationToken>()), Times.Once);
            storageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Возвращает значения
        /// </summary>
        [Fact]
        public async Task GetEntrantsReturnValues()
        {
            // Arrange
            var target1 = CreateEntrant();
            var target2 = CreateEntrant();
            storageMock.Setup(x => x.GetAll(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<Entrant>() { target1, target2 });

            // Act
            var result = await entrantManager.GetEntrants(CancellationToken.None);

            // Assert
            result.Should().NotBeEmpty()
                .And.HaveCount(2)
                .And.ContainSingle(x => x.Id == target1.Id)
                .And.ContainSingle(x => x.Id == target2.Id);
            storageMock.Verify(x => x.GetAll(It.IsAny<CancellationToken>()), Times.Once);
            storageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Добавляет абитуриента
        /// </summary>
        [Fact]
        public async Task AddShouldWork()
        {
            // Arrange
            var target = CreateEntrant();
            var request = new EntrantRequest(
                "Петров П.П.",
                Gender.Male,
                DateTime.Now.AddYears(-16),
                EducationForm.Fulltime,
                50,
                60,
                70);

            storageMock.Setup(x => x.GetAll(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<Entrant>() { target });

            storageMock.Setup(x => x.Add(It.IsAny<Entrant>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await entrantManager.Add(request, CancellationToken.None);

            // Assert
            storageMock.Verify(x => x.Add(It.IsAny<Entrant>(), It.IsAny<CancellationToken>()), Times.Once);
            storageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Обрабатывает ошибку
        /// </summary>
        [Fact]
        public async Task AddShouldThrow()
        {
            // Arrange
            EntrantRequest? request = null;

            // Act
            Func<Task> act = () => entrantManager.Add(request, CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<ArgumentNullException>();
        }

        /// <summary>
        /// Изменяет абитуриента
        /// </summary>
        [Fact]
        public async Task EditShouldWork()
        {
            // Arrange
            var id = Guid.NewGuid();
            var target = CreateEntrant();
            target.Id = id;

            var request = new EntrantRequest(
                "Петров П.П.",
                Gender.Male,
                DateTime.Now.AddYears(-16),
                EducationForm.Fulltime,
                50,
                60,
                70);

            storageMock.Setup(x => x.Get(id, It.IsAny<CancellationToken>()))
                .ReturnsAsync(target);

            storageMock.Setup(x => x.Edit(id, It.IsAny<Entrant>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await entrantManager.Edit(id, request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be(request.Name);
            result.Gender.Should().Be(request.Gender);
            result.Birthday.Should().Be(request.Birthday);
            result.EducationForm.Should().Be(request.EducationForm);
            result.MathExamScore.Should().Be(request.MathExamScore);
            result.RusExamScore.Should().Be(request.RusExamScore);
            result.ITExamScore.Should().Be(request.ITExamScore);

            storageMock.Verify(x => x.Get(id, It.IsAny<CancellationToken>()), Times.Once);
            storageMock.Verify(x => x.Edit(id, It.IsAny<Entrant>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        /// <summary>
        /// Обрабатывает ошибку
        /// </summary>
        [Fact]
        public async Task EditShouldThrow()
        {
            // Arrange
            var id = Guid.NewGuid();
            var request = new EntrantRequest(
                "Петров П.П.",
                Gender.Male,
                DateTime.Now.AddYears(-16),
                EducationForm.Fulltime,
                50,
                60,
                70);

            storageMock.Setup(x => x.Get(id, It.IsAny<CancellationToken>()))
                .ReturnsAsync((Entrant?)null);

            // Act
            Func<Task> act = () => entrantManager.Edit(id, request, CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage($"*{id}*");
        }

        /// <summary>
        /// Обрабатывает ошибку
        /// </summary>
        [Fact]
        public async Task DeleteShouldThrow()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            Func<Task> act = () => entrantManager.Delete(id, CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<InvalidOperationException>().WithMessage($"*{id}*");
        }

        /// <summary>
        /// Удаление абитуриента
        /// </summary>
        [Fact]
        public async Task DeleteShouldWork()
        {
            // Arrange
            var target1 = CreateEntrant();
            storageMock.Setup(x => x.Get(It.Is<Guid>(y => y == target1.Id), It.IsAny<CancellationToken>()))
                .ReturnsAsync(target1);

            // Act
            await entrantManager.Delete(target1.Id, CancellationToken.None);

            // Assert
            storageMock.Verify(x => x.Get(It.Is<Guid>(y => y == target1.Id), It.IsAny<CancellationToken>()), Times.Once);
            storageMock.Verify(x => x.Delete(It.Is<Guid>(y => y == target1.Id), It.IsAny<CancellationToken>()), Times.Once);
            storageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Возвращает правильную статистику
        /// </summary>
        [Fact]
        public async Task GetEntrantStatisticsShouldWork()
        {
            // Arrange
            var target1 = CreateEntrant();
            var target2 = CreateEntrant();
            var entrants = new List<Entrant>
            {
                target1, target2
            };

            storageMock.Setup(x => x.GetAll(It.IsAny<CancellationToken>()))
                .ReturnsAsync(entrants);

            // Act
            var result = await entrantManager.GetEntrantStatistics(CancellationToken.None);

            // Assert
            result.Should().BeEquivalentTo(new EntrantStatistics(2, 0));
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
