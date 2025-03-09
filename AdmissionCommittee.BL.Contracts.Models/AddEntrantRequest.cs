namespace AdmissionCommittee.BL.Contracts.Models
{
    /// <summary>
    /// Запрос на добавление студента
    /// </summary>
    /// <param name="Name"></param>
    /// <param name="Gender"></param>
    /// <param name="Birthday"></param>
    /// <param name="EducationForm"></param>
    /// <param name="MathExamScore"></param>
    /// <param name="RusExamScore"></param>
    /// <param name="ITExamScore"></param>
    public record EntrantRequest(string Name, Gender Gender, DateTime Birthday, EducationForm EducationForm, decimal MathExamScore, decimal RusExamScore, decimal ITExamScore)
    {
    }
}