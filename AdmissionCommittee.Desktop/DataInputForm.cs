using AdmissionCommittee.Desktop.Models;

namespace AdmissionCommittee.Desktop
{
    /// <summary>
    /// Модель формы параметров абитуриентов
    /// </summary>
    public partial class DataInputForm : Form
    {
        /// <summary>
        /// ctor
        /// </summary>
        public DataInputForm(Entrant? source = null)
        {
            InitializeComponent();
            Entrant = source == null
                ? new Entrant()
                {
                    Id = Guid.NewGuid(),
                    Birthday = DateOnly.FromDateTime(DateTime.Now.AddYears(-16)),
                }
                : new Entrant()
                {
                    Id = source.Id,
                    Name = source.Name,
                    Gender = source.Gender,
                    Birthday = source.Birthday,
                    EducationForm = source.EducationForm,
                    MathExamScore = source.MathExamScore,
                    RusExamScore = source.RusExamScore,
                    ITExamScore = source.ITExamScore,
                };
            textBoxName.Text = Entrant.Name;
            comboBoxGender.SelectedIndex = Entrant.Gender == Gender.Male ? 0 : 1;
            dateBirthday.Value = Entrant.Birthday.ToDateTime(TimeOnly.MinValue);
            comboBoxEducationForm.SelectedIndex = Entrant.EducationForm switch
            {
                EducationForm.Fulltime => 0,
                EducationForm.Parttime => 1,
                _ => 2,
            };
            numericMath.Value = Entrant.MathExamScore;
            numericRussian.Value = Entrant.RusExamScore;
            numericIT.Value = Entrant.ITExamScore;
        }

        public Entrant Entrant { get; }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            Entrant.Name = textBoxName.Text;
        }

        private void comboBoxGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            Entrant.Gender = comboBoxGender.SelectedIndex == 0 ? Gender.Male : Gender.Female;
        }

        private void dateBirthday_ValueChanged(object sender, EventArgs e)
        {
            Entrant.Birthday = DateOnly.FromDateTime(dateBirthday.Value);
        }

        private void comboBoxEducationForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            Entrant.EducationForm = comboBoxEducationForm.SelectedIndex switch
            {
                0 => EducationForm.Fulltime,
                1 => EducationForm.Parttime,
                _ => EducationForm.Correspondence,
            };
        }

        private void numericMath_ValueChanged(object sender, EventArgs e)
        {
            Entrant.MathExamScore = numericMath.Value;
        }

        private void numericRussian_ValueChanged(object sender, EventArgs e)
        {
            Entrant.RusExamScore = numericRussian.Value;
        }

        private void numericIT_ValueChanged(object sender, EventArgs e)
        {
            Entrant.ITExamScore = numericIT.Value;
        }
    }
}
