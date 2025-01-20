namespace AdmissionCommittee.Desktop.Models
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
        public string Name { get; set; }

        /// <inheritdoc cref="Models.Gender"/>
        public Gender Gender { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateOnly Birthday { get; set; }

        /// <inheritdoc cref="Models.EducationForm"/>
        public EducationForm EducationForm { get; set; }

        /// <summary>
        /// Баллы ЕГЭ по математике
        /// </summary>
        public decimal MathExamScore { get; set; }

        /// <summary>
        /// Баллы ЕГЭ по русскому
        /// </summary>
        public decimal RusExamScore { get; set; }

        /// <summary>
        /// Баллы ЕГЭ по информатике
        /// </summary>
        public decimal ITExamScore { get; set; }
    }
}
