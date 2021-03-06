﻿using System;
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
        private OpenFileDialog validatorFileDialog;
        private OpenFileDialog xmlFileDialog;

        public Form1()
        {
            InitializeComponent();
            validatorFileDialog = new OpenFileDialog();
            validatorFileDialog.Filter = "DTD(*.dtd)|*.dtd|XSD(*.xsd)|*.xsd|All files(*.*)|*.*";

            xmlFileDialog = new OpenFileDialog();
            xmlFileDialog.Filter = "XML(*.xml)|*.xml|All files(*.*)|*.*";
        }

        private void loadValidatorBtn_Click(object sender, EventArgs e)
        {
            if (xsdRbn.Checked)
            {
                _validator = new XsdValidator();
                validatorFileDialog.Filter = "XSD(*.xsd)|*.xsd|All files(*.*)|*.*";
            }

            if (dtdRbn.Checked)
            {
                _validator = new DtdValidator();
                validatorFileDialog.Filter = "DTD(*.dtd)|*.dtd|All files(*.*)|*.*";
            }

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
            try
            {
                _validator.Load(validatorTextTbx.Text);
                validateFromTextBtn.Enabled = true;
                validateFromFileBtn.Enabled = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка загрузки", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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

        private void validatorTextTbx_TextChanged(object sender, EventArgs e)
        {
            validatorTextTbx.ScrollBars = ScrollBars.Vertical;
        }

        private void xmlTextTbx_TextChanged(object sender, EventArgs e)
        {
            xmlTextTbx.ScrollBars = ScrollBars.Vertical;
        }

        private void validatorFileBrowseBtn_Click(object sender, EventArgs e)
        {
            if (validatorFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            validatorFileTbx.Text = validatorFileDialog.FileName;
        }

        private void xmlFileBrowseBtn_Click(object sender, EventArgs e)
        {
            if (xmlFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            xmlFileTbx.Text = xmlFileDialog.FileName;
        }
    }
}