using System.ComponentModel;

namespace AdmissionCommittee.BL.Contracts.Models
{
    /// <summary>
    /// Форма обучения абитуриента
    /// </summary>
    public enum EducationForm
    {
        /// <summary>
        /// Очная
        /// </summary>
        [Description("Очная")]
        Fulltime = 0,

        /// <summary>
        /// Очно-заочная
        /// </summary>
        [Description("Очно-заочная")]
        Parttime = 1,

        /// <summary>
        /// Заочная
        /// </summary>
        [Description("Заочная")]
        Correspondence = 2,
    }
}
