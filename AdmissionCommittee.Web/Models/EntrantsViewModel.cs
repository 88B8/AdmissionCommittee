using AdmissionCommittee.BL.Contracts.Models;

namespace AdmissionCommittee.Web.Models
{
    public class EntrantsViewModel
    {
        public IReadOnlyCollection<Entrant> Entrants { get; set; } = [];

        public EntrantStatistics? Stats { get; set; } = null;
    }
}