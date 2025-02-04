namespace AdmissionCommittee.Desktop.Models;
using System.ComponentModel.DataAnnotations;

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
    [Required(ErrorMessage = "ФИО должно быть обязательно!")]
    [StringLength(250, MinimumLength = 3)]
    public string Name { get; set; }

    /// <inheritdoc cref="Models.Gender"/>
    public Gender Gender { get; set; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    [Required(ErrorMessage = "Дата рождения должна быть обязательно!")]
    [AgeValidation(16, ErrorMessage = "Возраст должен быть больше 16 лет!")]
    public DateTime Birthday { get; set; }

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

    /// <summary>
    /// Shallow copy
    /// </summary>
    /// <returns></returns>
    public Entrant Clone()
    {
        return (Entrant)MemberwiseClone();
    }
}
