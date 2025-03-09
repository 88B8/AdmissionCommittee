using System.ComponentModel.DataAnnotations;

namespace AdmissionCommittee.BL.Contracts.Models
{
    /// <summary>
    /// Модель атрибута, проверяющего минимальный возраст
    /// </summary>
    public class AgeValidationAttribute(int age) : ValidationAttribute
    {
        /// <summary>
        /// Минимальный возраст
        /// </summary>
        public int MinAge { get; set; } = age;

        public override bool IsValid(object? value)
        {
            if (value is not DateTime birthDate)
                return false;

            int age = DateTime.Today.Year - birthDate.Year;

            if (birthDate.Date > DateTime.Today.AddYears(-age))
            {
                age--;
            }

            return age >= MinAge;
        }
    }
}