using AdmissionCommittee.BL.Contracts.Models;
using AdmissionCommittee.Storage.Contracts;
using System.Data.Entity;

namespace AdmissionCommittee.Storage.Sql
{
    public class AdmissionCommitteeStorage : IStorage<Entrant>
    {
        private readonly string connectionString;

        /// <summary>
        /// ctor
        /// </summary>
        public AdmissionCommitteeStorage(string connectionString)
        {
            this.connectionString = connectionString;
        }

        async Task IStorage<Entrant>.Add(Entrant item, CancellationToken cancellationToken)
        {
            using (var context = new AdmissionCommitteeContext(connectionString))
            {
                context.Entrants.Add(item);
                await context.SaveChangesAsync(cancellationToken);
            }
        }

        async Task IStorage<Entrant>.Delete(Guid id, CancellationToken cancellationToken)
        {
            using (var context = new AdmissionCommitteeContext(connectionString))
            {
                var element = await context.Entrants.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
                context.Entrants.Remove(element);
                await context.SaveChangesAsync(cancellationToken);
            }
        }

        async Task IStorage<Entrant>.Edit(Guid id, Entrant item, CancellationToken cancellationToken)
        {
            using (var context = new AdmissionCommitteeContext(connectionString))
            {
                var element = await context.Entrants.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

                element.Name = item.Name;
                element.Gender = item.Gender;
                element.Birthday = item.Birthday;
                element.EducationForm = item.EducationForm;
                element.MathExamScore = item.MathExamScore;
                element.RusExamScore = item.RusExamScore;
                element.ITExamScore = item.ITExamScore;

                await context.SaveChangesAsync();
            }
        }

        async Task<Entrant?> IStorage<Entrant>.Get(Guid id, CancellationToken cancellationToken)
        {
            using (var context = new AdmissionCommitteeContext(connectionString))
            {
                var result = await context.Entrants.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
                return result;
            }
        }

        async Task<IReadOnlyCollection<Entrant>> IStorage<Entrant>.GetAll(CancellationToken cancellationToken)
        {
            using (var context = new AdmissionCommitteeContext(connectionString))
            {
                var result = await context.Entrants
                    .OrderBy(x => x.Name)
                    .ToListAsync(cancellationToken);
                return result;
            }
        }
    }
}