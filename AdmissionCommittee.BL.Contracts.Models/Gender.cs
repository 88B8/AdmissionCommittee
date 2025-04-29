using System.ComponentModel.DataAnnotations;

namespace AdmissionCommittee.BL.Contracts.Models
{
    /// <summary>
    /// Пол абитуриента
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// Мужской
        /// </summary>
        [Display(Name = "Мужской")]
        Male = 0,

        /// <summary>
        /// Женский
        /// </summary>
        [Display(Name = "Женский")]
        Female = 1,
    }
}
