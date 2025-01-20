namespace AdmissionCommittee.Desktop
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            toolStrip1 = new ToolStrip();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripAdd = new ToolStripButton();
            toolStripEdit = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripDelete = new ToolStripButton();
            statusStrip1 = new StatusStrip();
            entrantsCount = new ToolStripStatusLabel();
            entrantsPassed = new ToolStripStatusLabel();
            dataGridView1 = new DataGridView();
            NameColumn = new DataGridViewTextBoxColumn();
            GenderColumn = new DataGridViewTextBoxColumn();
            BirthdayColumn = new DataGridViewTextBoxColumn();
            EducationFormColumn = new DataGridViewTextBoxColumn();
            MathExamScoreColumn = new DataGridViewTextBoxColumn();
            RusExamScoreColumn = new DataGridViewTextBoxColumn();
            ITExamScoreColumn = new DataGridViewTextBoxColumn();
            TotalExamScoreColumn = new DataGridViewTextBoxColumn();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripSeparator1, toolStripAdd, toolStripEdit, toolStripSeparator2, toolStripDelete });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(866, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // toolStripAdd
            // 
            toolStripAdd.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripAdd.Image = (Image)resources.GetObject("toolStripAdd.Image");
            toolStripAdd.ImageTransparentColor = Color.Magenta;
            toolStripAdd.Name = "toolStripAdd";
            toolStripAdd.Size = new Size(23, 22);
            toolStripAdd.Text = "Добавить абитуриента";
            toolStripAdd.Click += toolStripAdd_Click;
            // 
            // toolStripEdit
            // 
            toolStripEdit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripEdit.Image = (Image)resources.GetObject("toolStripEdit.Image");
            toolStripEdit.ImageTransparentColor = Color.Magenta;
            toolStripEdit.Name = "toolStripEdit";
            toolStripEdit.Size = new Size(23, 22);
            toolStripEdit.Text = "Изменить данные";
            toolStripEdit.Click += toolStripEdit_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // toolStripDelete
            // 
            toolStripDelete.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripDelete.Image = (Image)resources.GetObject("toolStripDelete.Image");
            toolStripDelete.ImageTransparentColor = Color.Magenta;
            toolStripDelete.Name = "toolStripDelete";
            toolStripDelete.Size = new Size(23, 22);
            toolStripDelete.Text = "Удалить абитуриента";
            toolStripDelete.Click += toolStripDelete_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { entrantsCount, entrantsPassed });
            statusStrip1.Location = new Point(0, 458);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(866, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // entrantsCount
            // 
            entrantsCount.Name = "entrantsCount";
            entrantsCount.Size = new Size(118, 17);
            entrantsCount.Text = "toolStripStatusLabel1";
            // 
            // entrantsPassed
            // 
            entrantsPassed.Name = "entrantsPassed";
            entrantsPassed.Size = new Size(118, 17);
            entrantsPassed.Text = "toolStripStatusLabel2";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { NameColumn, GenderColumn, BirthdayColumn, EducationFormColumn, MathExamScoreColumn, RusExamScoreColumn, ITExamScoreColumn, TotalExamScoreColumn });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 25);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(866, 433);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            // 
            // NameColumn
            // 
            NameColumn.DataPropertyName = "Name";
            NameColumn.HeaderText = "ФИО";
            NameColumn.Name = "NameColumn";
            NameColumn.ReadOnly = true;
            // 
            // GenderColumn
            // 
            GenderColumn.DataPropertyName = "Gender";
            GenderColumn.HeaderText = "Пол";
            GenderColumn.Name = "GenderColumn";
            GenderColumn.ReadOnly = true;
            // 
            // BirthdayColumn
            // 
            BirthdayColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            BirthdayColumn.DataPropertyName = "Birthday";
            BirthdayColumn.HeaderText = "Дата рождения";
            BirthdayColumn.Name = "BirthdayColumn";
            BirthdayColumn.ReadOnly = true;
            // 
            // EducationFormColumn
            // 
            EducationFormColumn.DataPropertyName = "EducationForm";
            EducationFormColumn.HeaderText = "Форма обучения";
            EducationFormColumn.Name = "EducationFormColumn";
            EducationFormColumn.ReadOnly = true;
            // 
            // MathExamScoreColumn
            // 
            MathExamScoreColumn.DataPropertyName = "MathExamScore";
            MathExamScoreColumn.HeaderText = "Баллы ЕГЭ по математике";
            MathExamScoreColumn.Name = "MathExamScoreColumn";
            MathExamScoreColumn.ReadOnly = true;
            // 
            // RusExamScoreColumn
            // 
            RusExamScoreColumn.DataPropertyName = "RusExamScore";
            RusExamScoreColumn.HeaderText = "Баллы ЕГЭ по русскому";
            RusExamScoreColumn.Name = "RusExamScoreColumn";
            RusExamScoreColumn.ReadOnly = true;
            // 
            // ITExamScoreColumn
            // 
            ITExamScoreColumn.DataPropertyName = "ITExamScore";
            ITExamScoreColumn.HeaderText = "Баллы ЕГЭ по информатике";
            ITExamScoreColumn.Name = "ITExamScoreColumn";
            ITExamScoreColumn.ReadOnly = true;
            // 
            // TotalExamScoreColumn
            // 
            TotalExamScoreColumn.HeaderText = "Общая сумма баллов";
            TotalExamScoreColumn.Name = "TotalExamScoreColumn";
            TotalExamScoreColumn.ReadOnly = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(866, 480);
            Controls.Add(dataGridView1);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            Name = "Form1";
            Text = "Приёмная комиссия";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripAdd;
        private ToolStripButton toolStripEdit;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton toolStripDelete;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel entrantsCount;
        private ToolStripStatusLabel entrantsPassed;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn NameColumn;
        private DataGridViewTextBoxColumn GenderColumn;
        private DataGridViewTextBoxColumn BirthdayColumn;
        private DataGridViewTextBoxColumn EducationFormColumn;
        private DataGridViewTextBoxColumn MathExamScoreColumn;
        private DataGridViewTextBoxColumn RusExamScoreColumn;
        private DataGridViewTextBoxColumn ITExamScoreColumn;
        private DataGridViewTextBoxColumn TotalExamScoreColumn;
    }
}
