namespace AdmissionCommittee.Desktop
{
    partial class DataInputForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            textBoxName = new TextBox();
            dateBirthday = new DateTimePicker();
            buttonOk = new Button();
            buttonCancel = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            label5 = new Label();
            label4 = new Label();
            label6 = new Label();
            label7 = new Label();
            comboBoxGender = new ComboBox();
            label8 = new Label();
            numericMath = new NumericUpDown();
            numericRussian = new NumericUpDown();
            numericIT = new NumericUpDown();
            comboBoxEducationForm = new ComboBox();
            label9 = new Label();
            errorProvider1 = new ErrorProvider(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericMath).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericRussian).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericIT).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(181, 115);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(302, 23);
            textBoxName.TabIndex = 0;
            // 
            // dateBirthday
            // 
            dateBirthday.Location = new Point(181, 186);
            dateBirthday.Name = "dateBirthday";
            dateBirthday.Size = new Size(301, 23);
            dateBirthday.TabIndex = 2;
            // 
            // buttonOk
            // 
            buttonOk.DialogResult = DialogResult.OK;
            buttonOk.Location = new Point(322, 368);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(75, 23);
            buttonOk.TabIndex = 9;
            buttonOk.Text = "Сохранить";
            buttonOk.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Location = new Point(406, 368);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 10;
            buttonCancel.Text = "Закрыть";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 259);
            label1.Name = "label1";
            label1.Size = new Size(128, 15);
            label1.TabIndex = 12;
            label1.Text = "Баллы по математике";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(41, 294);
            label2.Name = "label2";
            label2.Size = new Size(120, 15);
            label2.TabIndex = 12;
            label2.Text = "Баллы по рус. языку";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(41, 330);
            label3.Name = "label3";
            label3.Size = new Size(139, 15);
            label3.TabIndex = 12;
            label3.Text = "Баллы по информатике";
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.panel;
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(-4, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(543, 77);
            panel1.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Location = new Point(22, 46);
            label5.Name = "label5";
            label5.Size = new Size(192, 15);
            label5.TabIndex = 1;
            label5.Text = "Внимательно заполните все поля";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.Location = new Point(16, 5);
            label4.Name = "label4";
            label4.Size = new Size(307, 32);
            label4.TabIndex = 0;
            label4.Text = "Параметры абитуриента";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(41, 118);
            label6.Name = "label6";
            label6.Size = new Size(34, 15);
            label6.TabIndex = 15;
            label6.Text = "ФИО";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(41, 153);
            label7.Name = "label7";
            label7.Size = new Size(30, 15);
            label7.TabIndex = 16;
            label7.Text = "Пол";
            // 
            // comboBoxGender
            // 
            comboBoxGender.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxGender.FormattingEnabled = true;
            comboBoxGender.Items.AddRange(new object[] { "Мужской", "Женский" });
            comboBoxGender.Location = new Point(181, 150);
            comboBoxGender.Name = "comboBoxGender";
            comboBoxGender.Size = new Size(302, 23);
            comboBoxGender.TabIndex = 17;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(41, 192);
            label8.Name = "label8";
            label8.Size = new Size(90, 15);
            label8.TabIndex = 18;
            label8.Text = "Дата рождения";
            // 
            // numericMath
            // 
            numericMath.Location = new Point(181, 255);
            numericMath.Name = "numericMath";
            numericMath.Size = new Size(302, 23);
            numericMath.TabIndex = 19;
            // 
            // numericRussian
            // 
            numericRussian.Location = new Point(181, 292);
            numericRussian.Name = "numericRussian";
            numericRussian.Size = new Size(302, 23);
            numericRussian.TabIndex = 20;
            // 
            // numericIT
            // 
            numericIT.Location = new Point(181, 328);
            numericIT.Name = "numericIT";
            numericIT.Size = new Size(302, 23);
            numericIT.TabIndex = 21;
            // 
            // comboBoxEducationForm
            // 
            comboBoxEducationForm.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEducationForm.FormattingEnabled = true;
            comboBoxEducationForm.Location = new Point(181, 222);
            comboBoxEducationForm.Name = "comboBoxEducationForm";
            comboBoxEducationForm.Size = new Size(302, 23);
            comboBoxEducationForm.TabIndex = 22;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(41, 225);
            label9.Name = "label9";
            label9.Size = new Size(101, 15);
            label9.TabIndex = 23;
            label9.Text = "Форма обучения";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // DataInputForm
            // 
            AcceptButton = buttonOk;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(535, 415);
            Controls.Add(label9);
            Controls.Add(comboBoxEducationForm);
            Controls.Add(numericIT);
            Controls.Add(numericRussian);
            Controls.Add(numericMath);
            Controls.Add(label8);
            Controls.Add(comboBoxGender);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(panel1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOk);
            Controls.Add(dateBirthday);
            Controls.Add(textBoxName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DataInputForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Параметры абитуриента";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericMath).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericRussian).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericIT).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxName;
        private DateTimePicker dateBirthday;
        private Button buttonOk;
        private Button buttonCancel;
        private Label label1;
        private Label label2;
        private Label label3;
        private Panel panel1;
        private Label label5;
        private Label label4;
        private Label label6;
        private Label label7;
        private ComboBox comboBoxGender;
        private Label label8;
        private NumericUpDown numericMath;
        private NumericUpDown numericRussian;
        private NumericUpDown numericIT;
        private ComboBox comboBoxEducationForm;
        private Label label9;
        private ErrorProvider errorProvider1;
    }
}