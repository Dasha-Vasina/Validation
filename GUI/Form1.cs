using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleApplication2;
using Validators;

namespace GUI
{
    public partial class Form1 : Form
    {
        private IValidator _validator;

        public Form1()
        {
            InitializeComponent();
        }

        private void loadValidatorBtn_Click(object sender, EventArgs e)
        {
            if (xsdRbn.Checked) _validator = new XsdValidator();
            if (dtdRbn.Checked) _validator = new DtdValidator();

            _validator.OnValidationError -= ValidatorOnOnValidationError;
            _validator.OnValidationError += ValidatorOnOnValidationError;

            loadValidatorText.Enabled = true;
            loadValidatorFile.Enabled = true;
        }

        private void ValidatorOnOnValidationError(string error)
        {
            MessageBox.Show(error);
        }

        private void loadValidatorFile_Click(object sender, EventArgs e)
        {
            using (var fileStream = new StreamReader(validatorFileTbx.Text))
            {
                _validator.Load(fileStream.BaseStream);
            }

            validateFromTextBtn.Enabled = true;
            validateFromFileBtn.Enabled = true;
        }

        private void loadValidatorText_Click(object sender, EventArgs e)
        {
            _validator.Load(validatorTextTbx.Text);
            validateFromTextBtn.Enabled = true;
            validateFromFileBtn.Enabled = true;
        }

        private void validateFromFileBtn_Click(object sender, EventArgs e)
        {
            bool result;
            using (var fileStream = new StreamReader(xmlFileTbx.Text))
            {
                result = _validator.Validate(fileStream.BaseStream);
            }

            if (result)
            {
                MessageBox.Show("Валидация прошла успешно");
            }
            else
            {
                MessageBox.Show("Валидация завершилась с ошибками");
            }
        }

        private void validateFromTextBtn_Click(object sender, EventArgs e)
        {
            var result = _validator.Validate(xmlTextTbx.Text);

            if (result)
            {
                MessageBox.Show("Валидация прошла успешно");
            }
            else
            {
                MessageBox.Show("Валидация завершилась с ошибками");
            }
        }
    }
}