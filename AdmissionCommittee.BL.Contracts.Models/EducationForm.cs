using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "Очная")]
        Fulltime = 0,

        /// <summary>
        /// Очно-заочная
        /// </summary>
        [Display(Name = "Очно-заочная")]
        [Description("Очно-заочная")]
        Parttime = 1,

        /// <summary>
        /// Заочная
        /// </summary>
        [Display(Name = "Заочная")]
        [Description("Заочная")]
        Correspondence = 2,
    }
}
