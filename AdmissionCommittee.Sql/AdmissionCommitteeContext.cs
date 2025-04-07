using AdmissionCommittee.BL.Contracts.Models;
using System.Data.Entity;

namespace AdmissionCommittee.Storage.Sql
{
    public class AdmissionCommitteeContext : DbContext
    {
        /// <summary>
        /// ctor
        /// </summary>
        public AdmissionCommitteeContext(string connectionString)
            : base(connectionString)
        {
            
        }
        /// <summary>
        /// Список абитуриентов
        /// </summary>
        public DbSet<Entrant> Entrants { get; set; }
    } 
}