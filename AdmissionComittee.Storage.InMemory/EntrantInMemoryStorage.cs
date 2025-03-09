using AdmissionCommittee.BL.Contracts.Models;
using AdmissionCommittee.Storage.Contracts;
using System.Collections.ObjectModel;

namespace AdmissionComittee.Storage.InMemory
{
    public class EntrantInMemoryStorage : IStorage<Entrant>
    {
        private readonly List<Entrant> items;

        public EntrantInMemoryStorage()
        {
            items = new List<Entrant>();
            items.Add(new Entrant()
            {
                Id = Guid.NewGuid(),
                Name = "Иванов И.И.",
                Gender = Gender.Male,
                Birthday = DateTime.Now.AddYears(-17),
                EducationForm = EducationForm.Fulltime,
                MathExamScore = 30,
                RusExamScore = 14,
                ITExamScore = 88,
            });
        }

        Task<IReadOnlyCollection<Entrant>> IStorage<Entrant>.GetAll(CancellationToken cancellationToken)
            => Task.FromResult((IReadOnlyCollection<Entrant>)new ReadOnlyCollection<Entrant>(items));

        Task<Entrant?> IStorage<Entrant>.Get(Guid id, CancellationToken cancellationToken)
            => Task.FromResult(items.FirstOrDefault(x => x.Id == id));

        Task IStorage<Entrant>.Add(Entrant item, CancellationToken cancellationToken)
        {
            items.Add(item);
            return Task.CompletedTask;
        }

        Task IStorage<Entrant>.Delete(Guid id, CancellationToken cancellationToken)
        {
            var element = items.First(x => x.Id == id);
            items.Remove(element);

            return Task.CompletedTask;
        }

        Task IStorage<Entrant>.Edit(Guid id, Entrant item, CancellationToken cancellationToken)
        {
            var element = items.First(x => x.Id == id);
            element.Name = item.Name;
            element.Gender = item.Gender;
            element.Birthday = item.Birthday;
            element.EducationForm = item.EducationForm;
            element.MathExamScore = item.MathExamScore;
            element.RusExamScore = item.RusExamScore;
            element.ITExamScore = item.ITExamScore;

            return Task.CompletedTask;
        }
    }
}
