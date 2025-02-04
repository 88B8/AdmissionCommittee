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
                    Birthday = DateTime.Now.AddYears(-16),
                }
                : source.Clone();

            comboBoxGender.DataSource = Enum.GetValues(typeof(Gender));

            textBoxName.AddBindings(x => x.Text, Entrant, x => x.Name, errorProvider1);
            comboBoxGender.AddBindings(x => x.SelectedItem, Entrant, x => x.Gender);
            dateBirthday.AddBindings(x => x.Value, Entrant, x => x.Birthday, errorProvider1);
            comboBoxEducationForm.AddBindings(x => x.SelectedItem, Entrant, x => x.EducationForm);
            numericMath.AddBindings(x => x.Value, Entrant, x => x.MathExamScore);
            numericRussian.AddBindings(x => x.Value, Entrant, x => x.RusExamScore);
            numericIT.AddBindings(x => x.Value, Entrant, x => x.ITExamScore);
        }

        public Entrant Entrant { get; }
    }
}
