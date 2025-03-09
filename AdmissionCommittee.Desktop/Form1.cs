using AdmissionCommittee.BL.Contracts;
using AdmissionCommittee.BL.Contracts.Models;

namespace AdmissionCommittee.Desktop
{
    /// <summary>
    /// Модель главной формы
    /// </summary>
    public partial class Form1 : Form
    {
        private readonly IEntrantManager entrantManager;
        private readonly BindingSource entrantBindingSource;

        /// <summary>
        /// ctor
        /// </summary>
        public Form1(IEntrantManager entrantManager)
        {
            InitializeComponent();
            this.entrantManager = entrantManager;
            entrantBindingSource = new BindingSource();
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
        }

        private async void toolStripAdd_Click(object sender, EventArgs e)
        {
            var inputForm = new DataInputForm();
            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                await entrantManager.Add(new EntrantRequest(inputForm.Entrant.Name,
                    inputForm.Entrant.Gender,
                    inputForm.Entrant.Birthday,
                    inputForm.Entrant.EducationForm,
                    inputForm.Entrant.MathExamScore,
                    inputForm.Entrant.RusExamScore,
                    inputForm.Entrant.ITExamScore), CancellationToken.None);
                await UpdateDataAndStats(CancellationToken.None);
            }
        }

        private async void toolStripDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 &&
                dataGridView1.SelectedRows[0].DataBoundItem is Entrant entrant)
            {

                if (MessageBox.Show($"Вы действительно хотите удалить абитуриента '{entrant.Name}'?",
                    "Удаление абитуриента",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    await entrantManager.Delete(entrant.Id, CancellationToken.None);
                    await UpdateDataAndStats(CancellationToken.None);
                }
            }
        }

        private async void toolStripEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 &&
                dataGridView1.SelectedRows[0].DataBoundItem is Entrant entrant)
            {
                var inputForm = new DataInputForm(entrant);
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    await entrantManager.Edit(inputForm.Entrant.Id, new EntrantRequest(inputForm.Entrant.Name,
                        inputForm.Entrant.Gender,
                        inputForm.Entrant.Birthday,
                        inputForm.Entrant.EducationForm,
                        inputForm.Entrant.MathExamScore,
                        inputForm.Entrant.RusExamScore,
                        inputForm.Entrant.ITExamScore), CancellationToken.None);
                    await UpdateDataAndStats(CancellationToken.None);
                }
            }
        }

        private async Task UpdateDataAndStats(CancellationToken cancellationToken)
        {
            var result = await entrantManager.GetEntrantStatistics(cancellationToken);
            entrantsCount.Text = $"Количество абитуриентов: {result.EntrantsCount}";
            entrantsPassed.Text = $"Набрали больше 150 баллов: {result.EntrantsPassedCount}";
            entrantBindingSource.DataSource = await entrantManager.GetEntrants(CancellationToken.None);
            entrantBindingSource.ResetBindings(false);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await UpdateDataAndStats(CancellationToken.None);
        }
    }
}