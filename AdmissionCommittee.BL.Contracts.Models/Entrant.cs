using System.ComponentModel.DataAnnotations;

namespace AdmissionCommittee.BL.Contracts.Models
{
    /// <summary>
    /// Модель студента
    /// </summary>
    public class Entrant
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// ФИО
        /// </summary>
        [Display(Name = "ФИО")]
        [Required(ErrorMessage = "ФИО должно быть обязательно!")]
        [StringLength(250, MinimumLength = 3)]
        public string Name { get; set; }

        /// <inheritdoc cref="Models.Gender"/>
        [Display(Name = "Пол")]
        public Gender Gender { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        [Display(Name = "Дата рождения")]
        [Required(ErrorMessage = "Дата рождения должна быть обязательно!")]
        [AgeValidation(16, 100, ErrorMessage = "Возраст введен некорректно!")]
        public DateTime Birthday { get; set; }

        /// <inheritdoc cref="Models.EducationForm"/>
        [Display(Name = "Форма обучения")]
        public EducationForm EducationForm { get; set; }

        /// <summary>
        /// Баллы ЕГЭ по математике
        /// </summary>
        [Range(0, 100, ErrorMessage = "Баллы должны быть в диапазоне от 0 до 100")]
        [Display(Name = "Баллы по математике")]
        public decimal MathExamScore { get; set; }

        /// <summary>
        /// Баллы ЕГЭ по русскому
        /// </summary>
        [Range(0, 100, ErrorMessage = "Баллы должны быть в диапазоне от 0 до 100")]
        [Display(Name = "Баллы по русскому языку")]
        public decimal RusExamScore { get; set; }

        /// <summary>
        /// Баллы ЕГЭ по информатике
        /// </summary>
        [Range(0, 100, ErrorMessage = "Баллы должны быть в диапазоне от 0 до 100")]
        [Display(Name = "Баллы по информатике")]
        public decimal ITExamScore { get; set; }

        /// <summary>
        /// Shallow copy
        /// </summary>
        /// <returns></returns>
        public Entrant Clone()
        {
            return (Entrant)MemberwiseClone();
        }
    }
}