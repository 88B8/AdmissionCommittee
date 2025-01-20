using AdmissionCommittee.Desktop.Models;

namespace AdmissionCommittee.Desktop
{
    /// <summary>
    /// Модель главной формы
    /// </summary>
    public partial class Form1 : Form
    {
        private readonly List<Entrant> entrants = new List<Entrant>();
        private readonly BindingSource entrantBindingSource;

        /// <summary>
        /// ctor
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            entrants.Add(new Entrant
            {
                Id = Guid.NewGuid(),
                Name = "Петров Петр Петрович",
                Gender = Gender.Male,
                Birthday = DateOnly.FromDateTime(DateTime.Now.AddYears(-16)),
                EducationForm = EducationForm.Fulltime,
                MathExamScore = 78,
                RusExamScore = 14,
                ITExamScore = 88,
            });

            entrantBindingSource = new BindingSource();
            entrantBindingSource.DataSource = entrants;

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = entrantBindingSource;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var entrant = dataGridView1.Rows[e.RowIndex].DataBoundItem as Entrant;
            if (entrant == null)
            {
                return;
            }

            if (dataGridView1.Columns[e.ColumnIndex].Name == GenderColumn.Name)
            {
                e.Value = entrant.Gender == Gender.Male
                    ? "Мужской"
                    : "Женский";
            }

            if (dataGridView1.Columns[e.ColumnIndex].Name == EducationFormColumn.Name)
            {
                e.Value = entrant.EducationForm switch
                {
                    EducationForm.Fulltime => "Очная",
                    EducationForm.Parttime => "Очно-заочная",
                    _ => "Заочная",
                };
            }

            if (dataGridView1.Columns[e.ColumnIndex].Name == TotalExamScoreColumn.Name)
            {
                e.Value = entrant.MathExamScore + entrant.RusExamScore + entrant.ITExamScore;
            }

            CalculateStatsAndUpdate();
        }

        private void toolStripAdd_Click(object sender, EventArgs e)
        {
            var inputForm = new DataInputForm();
            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                entrants.Add(inputForm.Entrant);
                entrantBindingSource.ResetBindings(false);
            }
        }

        private void toolStripEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 &&
                dataGridView1.SelectedRows[0].DataBoundItem is Entrant entrant)
            {
                var inputForm = new DataInputForm(entrant);
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    entrant.Name = inputForm.Entrant.Name;
                    entrant.Gender = inputForm.Entrant.Gender;
                    entrant.Birthday = inputForm.Entrant.Birthday;
                    entrant.EducationForm = inputForm.Entrant.EducationForm;
                    entrant.MathExamScore = inputForm.Entrant.MathExamScore;
                    entrant.RusExamScore = inputForm.Entrant.RusExamScore;
                    entrant.ITExamScore = inputForm.Entrant.ITExamScore;
                    entrantBindingSource.ResetBindings(false);
                }
            }
        }

        private void toolStripDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 &&
                dataGridView1.SelectedRows[0].DataBoundItem is Entrant entrant)
            {

                if (MessageBox.Show($"Вы действительно хотите удалить абитуриента '{entrant.Name}'?",
                    "Удаление студента",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var target = entrants.FirstOrDefault(x => x.Id == entrant.Id);
                    if (target != null)
                    {
                        entrants.Remove(target);
                        entrantBindingSource.ResetBindings(false);
                    }
                }
            }
        }

        private void CalculateStatsAndUpdate()
        {
            entrantsCount.Text = $"Количество студентов: {entrants.Count}";
            entrantsPassed.Text = $"Набрали больше 150 баллов: {entrants.Count(e => e.MathExamScore + e.RusExamScore + e.ITExamScore > 150)}";
        }
    }
}