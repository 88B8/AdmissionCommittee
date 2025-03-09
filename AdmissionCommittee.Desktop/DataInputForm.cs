using AdmissionCommittee.BL.Contracts.Models;

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
                    Birthday = DateTime.Now.AddYears(-16),
                }
                : source.Clone();

            comboBoxGender.DataSource = Enum.GetValues(typeof(Gender));
            comboBoxEducationForm.DataSource = Enum.GetValues(typeof(EducationForm));

            textBoxName.AddBindings(x => x.Text, Entrant, x => x.Name, errorProvider1);
            comboBoxGender.AddBindings(x => x.SelectedItem, Entrant, x => x.Gender, errorProvider1);
            dateBirthday.AddBindings(x => x.Value, Entrant, x => x.Birthday, errorProvider1);
            comboBoxEducationForm.AddBindings(x => x.SelectedItem, Entrant, x => x.EducationForm, errorProvider1);
            numericMath.AddBindings(x => x.Value, Entrant, x => x.MathExamScore, errorProvider1);
            numericRussian.AddBindings(x => x.Value, Entrant, x => x.RusExamScore, errorProvider1);
            numericIT.AddBindings(x => x.Value, Entrant, x => x.ITExamScore, errorProvider1);
        }

        public Entrant Entrant { get; }
    }
}
