namespace GUI
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.xsdRbn = new System.Windows.Forms.RadioButton();
            this.dtdRbn = new System.Windows.Forms.RadioButton();
            this.validatorTextTbx = new System.Windows.Forms.TextBox();
            this.validatorFileTbx = new System.Windows.Forms.TextBox();
            this.loadValidatorBtn = new System.Windows.Forms.Button();
            this.loadValidatorFile = new System.Windows.Forms.Button();
            this.loadValidatorText = new System.Windows.Forms.Button();
            this.xmlFileTbx = new System.Windows.Forms.TextBox();
            this.xmlTextTbx = new System.Windows.Forms.TextBox();
            this.validateFromFileBtn = new System.Windows.Forms.Button();
            this.validateFromTextBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.validatorFileBrowseBtn = new System.Windows.Forms.Button();
            this.xmlFileBrowseBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // xsdRbn
            // 
            this.xsdRbn.AutoSize = true;
            this.xsdRbn.Checked = true;
            this.xsdRbn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.xsdRbn.Location = new System.Drawing.Point(27, 56);
            this.xsdRbn.Name = "xsdRbn";
            this.xsdRbn.Size = new System.Drawing.Size(81, 17);
            this.xsdRbn.TabIndex = 1;
            this.xsdRbn.TabStop = true;
            this.xsdRbn.Text = "XSD-схема";
            this.xsdRbn.UseVisualStyleBackColor = true;
            // 
            // dtdRbn
            // 
            this.dtdRbn.AutoSize = true;
            this.dtdRbn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtdRbn.Location = new System.Drawing.Point(27, 79);
            this.dtdRbn.Name = "dtdRbn";
            this.dtdRbn.Size = new System.Drawing.Size(82, 17);
            this.dtdRbn.TabIndex = 2;
            this.dtdRbn.Text = "DTD-схема";
            this.dtdRbn.UseVisualStyleBackColor = true;
            // 
            // validatorTextTbx
            // 
            this.validatorTextTbx.Location = new System.Drawing.Point(10, 145);
            this.validatorTextTbx.Multiline = true;
            this.validatorTextTbx.Name = "validatorTextTbx";
            this.validatorTextTbx.Size = new System.Drawing.Size(352, 275);
            this.validatorTextTbx.TabIndex = 3;
            this.validatorTextTbx.TextChanged += new System.EventHandler(this.validatorTextTbx_TextChanged);
            // 
            // validatorFileTbx
            // 
            this.validatorFileTbx.Location = new System.Drawing.Point(10, 106);
            this.validatorFileTbx.Name = "validatorFileTbx";
            this.validatorFileTbx.Size = new System.Drawing.Size(263, 20);
            this.validatorFileTbx.TabIndex = 4;
            // 
            // loadValidatorBtn
            // 
            this.loadValidatorBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadValidatorBtn.Location = new System.Drawing.Point(137, 65);
            this.loadValidatorBtn.Name = "loadValidatorBtn";
            this.loadValidatorBtn.Size = new System.Drawing.Size(111, 23);
            this.loadValidatorBtn.TabIndex = 5;
            this.loadValidatorBtn.Text = "Подтвердить";
            this.loadValidatorBtn.UseVisualStyleBackColor = true;
            this.loadValidatorBtn.Click += new System.EventHandler(this.loadValidatorBtn_Click);
            // 
            // loadValidatorFile
            // 
            this.loadValidatorFile.Enabled = false;
            this.loadValidatorFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadValidatorFile.Location = new System.Drawing.Point(368, 104);
            this.loadValidatorFile.Name = "loadValidatorFile";
            this.loadValidatorFile.Size = new System.Drawing.Size(126, 23);
            this.loadValidatorFile.TabIndex = 6;
            this.loadValidatorFile.Text = "Загрузить схему";
            this.loadValidatorFile.UseVisualStyleBackColor = true;
            this.loadValidatorFile.Click += new System.EventHandler(this.loadValidatorFile_Click);
            // 
            // loadValidatorText
            // 
            this.loadValidatorText.Enabled = false;
            this.loadValidatorText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadValidatorText.Location = new System.Drawing.Point(368, 145);
            this.loadValidatorText.Name = "loadValidatorText";
            this.loadValidatorText.Size = new System.Drawing.Size(126, 24);
            this.loadValidatorText.TabIndex = 7;
            this.loadValidatorText.Text = "Валидация";
            this.loadValidatorText.UseVisualStyleBackColor = true;
            this.loadValidatorText.Click += new System.EventHandler(this.loadValidatorText_Click);
            // 
            // xmlFileTbx
            // 
            this.xmlFileTbx.Location = new System.Drawing.Point(6, 104);
            this.xmlFileTbx.Name = "xmlFileTbx";
            this.xmlFileTbx.Size = new System.Drawing.Size(258, 20);
            this.xmlFileTbx.TabIndex = 8;
            // 
            // xmlTextTbx
            // 
            this.xmlTextTbx.Location = new System.Drawing.Point(6, 145);
            this.xmlTextTbx.Multiline = true;
            this.xmlTextTbx.Name = "xmlTextTbx";
            this.xmlTextTbx.Size = new System.Drawing.Size(346, 275);
            this.xmlTextTbx.TabIndex = 9;
            this.xmlTextTbx.TextChanged += new System.EventHandler(this.xmlTextTbx_TextChanged);
            // 
            // validateFromFileBtn
            // 
            this.validateFromFileBtn.Enabled = false;
            this.validateFromFileBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.validateFromFileBtn.Location = new System.Drawing.Point(358, 101);
            this.validateFromFileBtn.Name = "validateFromFileBtn";
            this.validateFromFileBtn.Size = new System.Drawing.Size(136, 23);
            this.validateFromFileBtn.TabIndex = 10;
            this.validateFromFileBtn.Text = "Загрузить файл";
            this.validateFromFileBtn.UseVisualStyleBackColor = true;
            this.validateFromFileBtn.Click += new System.EventHandler(this.validateFromFileBtn_Click);
            // 
            // validateFromTextBtn
            // 
            this.validateFromTextBtn.Enabled = false;
            this.validateFromTextBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.validateFromTextBtn.Location = new System.Drawing.Point(358, 146);
            this.validateFromTextBtn.Name = "validateFromTextBtn";
            this.validateFromTextBtn.Size = new System.Drawing.Size(136, 23);
            this.validateFromTextBtn.TabIndex = 11;
            this.validateFromTextBtn.Text = "Валидация";
            this.validateFromTextBtn.UseVisualStyleBackColor = true;
            this.validateFromTextBtn.Click += new System.EventHandler(this.validateFromTextBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.validatorFileBrowseBtn);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.xsdRbn);
            this.groupBox1.Controls.Add(this.dtdRbn);
            this.groupBox1.Controls.Add(this.loadValidatorBtn);
            this.groupBox1.Controls.Add(this.validatorFileTbx);
            this.groupBox1.Controls.Add(this.validatorTextTbx);
            this.groupBox1.Controls.Add(this.loadValidatorText);
            this.groupBox1.Controls.Add(this.loadValidatorFile);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 426);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "XML-схема:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(24, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выберите схему для проверки:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.xmlFileBrowseBtn);
            this.groupBox2.Controls.Add(this.xmlFileTbx);
            this.groupBox2.Controls.Add(this.xmlTextTbx);
            this.groupBox2.Controls.Add(this.validateFromTextBtn);
            this.groupBox2.Controls.Add(this.validateFromFileBtn);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(534, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(500, 426);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "XML-файл:";
            // 
            // validatorFileBrowseBtn
            // 
            this.validatorFileBrowseBtn.Location = new System.Drawing.Point(279, 104);
            this.validatorFileBrowseBtn.Name = "validatorFileBrowseBtn";
            this.validatorFileBrowseBtn.Size = new System.Drawing.Size(82, 23);
            this.validatorFileBrowseBtn.TabIndex = 8;
            this.validatorFileBrowseBtn.Text = "Обзор";
            this.validatorFileBrowseBtn.UseVisualStyleBackColor = true;
            this.validatorFileBrowseBtn.Click += new System.EventHandler(this.validatorFileBrowseBtn_Click);
            // 
            // xmlFileBrowseBtn
            // 
            this.xmlFileBrowseBtn.Location = new System.Drawing.Point(270, 103);
            this.xmlFileBrowseBtn.Name = "xmlFileBrowseBtn";
            this.xmlFileBrowseBtn.Size = new System.Drawing.Size(82, 23);
            this.xmlFileBrowseBtn.TabIndex = 9;
            this.xmlFileBrowseBtn.Text = "Обзор";
            this.xmlFileBrowseBtn.UseVisualStyleBackColor = true;
            this.xmlFileBrowseBtn.Click += new System.EventHandler(this.xmlFileBrowseBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Валидатор";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RadioButton xsdRbn;
        private System.Windows.Forms.RadioButton dtdRbn;
        private System.Windows.Forms.TextBox validatorTextTbx;
        private System.Windows.Forms.TextBox validatorFileTbx;
        private System.Windows.Forms.Button loadValidatorBtn;
        private System.Windows.Forms.Button loadValidatorFile;
        private System.Windows.Forms.Button loadValidatorText;
        private System.Windows.Forms.TextBox xmlFileTbx;
        private System.Windows.Forms.TextBox xmlTextTbx;
        private System.Windows.Forms.Button validateFromFileBtn;
        private System.Windows.Forms.Button validateFromTextBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button validatorFileBrowseBtn;
        private System.Windows.Forms.Button xmlFileBrowseBtn;
    }
}

