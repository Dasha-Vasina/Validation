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
            this.SuspendLayout();
            // 
            // xsdRbn
            // 
            this.xsdRbn.AutoSize = true;
            this.xsdRbn.Checked = true;
            this.xsdRbn.Location = new System.Drawing.Point(12, 392);
            this.xsdRbn.Name = "xsdRbn";
            this.xsdRbn.Size = new System.Drawing.Size(61, 17);
            this.xsdRbn.TabIndex = 1;
            this.xsdRbn.TabStop = true;
            this.xsdRbn.Text = "xsdRbn";
            this.xsdRbn.UseVisualStyleBackColor = true;
            // 
            // dtdRbn
            // 
            this.dtdRbn.AutoSize = true;
            this.dtdRbn.Location = new System.Drawing.Point(12, 421);
            this.dtdRbn.Name = "dtdRbn";
            this.dtdRbn.Size = new System.Drawing.Size(60, 17);
            this.dtdRbn.TabIndex = 2;
            this.dtdRbn.Text = "dtdRbn";
            this.dtdRbn.UseVisualStyleBackColor = true;
            // 
            // validatorTextTbx
            // 
            this.validatorTextTbx.Location = new System.Drawing.Point(12, 56);
            this.validatorTextTbx.Multiline = true;
            this.validatorTextTbx.Name = "validatorTextTbx";
            this.validatorTextTbx.Size = new System.Drawing.Size(290, 327);
            this.validatorTextTbx.TabIndex = 3;
            // 
            // validatorFileTbx
            // 
            this.validatorFileTbx.Location = new System.Drawing.Point(12, 21);
            this.validatorFileTbx.Name = "validatorFileTbx";
            this.validatorFileTbx.Size = new System.Drawing.Size(290, 20);
            this.validatorFileTbx.TabIndex = 4;
            // 
            // loadValidatorBtn
            // 
            this.loadValidatorBtn.Location = new System.Drawing.Point(79, 392);
            this.loadValidatorBtn.Name = "loadValidatorBtn";
            this.loadValidatorBtn.Size = new System.Drawing.Size(111, 23);
            this.loadValidatorBtn.TabIndex = 5;
            this.loadValidatorBtn.Text = "loadValidatorBtn";
            this.loadValidatorBtn.UseVisualStyleBackColor = true;
            this.loadValidatorBtn.Click += new System.EventHandler(this.loadValidatorBtn_Click);
            // 
            // loadValidatorFile
            // 
            this.loadValidatorFile.Enabled = false;
            this.loadValidatorFile.Location = new System.Drawing.Point(333, 17);
            this.loadValidatorFile.Name = "loadValidatorFile";
            this.loadValidatorFile.Size = new System.Drawing.Size(126, 23);
            this.loadValidatorFile.TabIndex = 6;
            this.loadValidatorFile.Text = "loadValidatorFile";
            this.loadValidatorFile.UseVisualStyleBackColor = true;
            this.loadValidatorFile.Click += new System.EventHandler(this.loadValidatorFile_Click);
            // 
            // loadValidatorText
            // 
            this.loadValidatorText.Enabled = false;
            this.loadValidatorText.Location = new System.Drawing.Point(333, 55);
            this.loadValidatorText.Name = "loadValidatorText";
            this.loadValidatorText.Size = new System.Drawing.Size(126, 24);
            this.loadValidatorText.TabIndex = 7;
            this.loadValidatorText.Text = "loadValidatorText";
            this.loadValidatorText.UseVisualStyleBackColor = true;
            this.loadValidatorText.Click += new System.EventHandler(this.loadValidatorText_Click);
            // 
            // xmlFileTbx
            // 
            this.xmlFileTbx.Location = new System.Drawing.Point(528, 21);
            this.xmlFileTbx.Name = "xmlFileTbx";
            this.xmlFileTbx.Size = new System.Drawing.Size(330, 20);
            this.xmlFileTbx.TabIndex = 8;
            // 
            // xmlTextTbx
            // 
            this.xmlTextTbx.Location = new System.Drawing.Point(528, 55);
            this.xmlTextTbx.Multiline = true;
            this.xmlTextTbx.Name = "xmlTextTbx";
            this.xmlTextTbx.Size = new System.Drawing.Size(330, 328);
            this.xmlTextTbx.TabIndex = 9;
            // 
            // validateFromFileBtn
            // 
            this.validateFromFileBtn.Enabled = false;
            this.validateFromFileBtn.Location = new System.Drawing.Point(864, 18);
            this.validateFromFileBtn.Name = "validateFromFileBtn";
            this.validateFromFileBtn.Size = new System.Drawing.Size(136, 23);
            this.validateFromFileBtn.TabIndex = 10;
            this.validateFromFileBtn.Text = "validateFromFileBtn";
            this.validateFromFileBtn.UseVisualStyleBackColor = true;
            this.validateFromFileBtn.Click += new System.EventHandler(this.validateFromFileBtn_Click);
            // 
            // validateFromTextBtn
            // 
            this.validateFromTextBtn.Enabled = false;
            this.validateFromTextBtn.Location = new System.Drawing.Point(864, 56);
            this.validateFromTextBtn.Name = "validateFromTextBtn";
            this.validateFromTextBtn.Size = new System.Drawing.Size(136, 23);
            this.validateFromTextBtn.TabIndex = 11;
            this.validateFromTextBtn.Text = "validateFromTextBtn";
            this.validateFromTextBtn.UseVisualStyleBackColor = true;
            this.validateFromTextBtn.Click += new System.EventHandler(this.validateFromTextBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 450);
            this.Controls.Add(this.validateFromTextBtn);
            this.Controls.Add(this.validateFromFileBtn);
            this.Controls.Add(this.xmlTextTbx);
            this.Controls.Add(this.xmlFileTbx);
            this.Controls.Add(this.loadValidatorText);
            this.Controls.Add(this.loadValidatorFile);
            this.Controls.Add(this.loadValidatorBtn);
            this.Controls.Add(this.validatorFileTbx);
            this.Controls.Add(this.validatorTextTbx);
            this.Controls.Add(this.dtdRbn);
            this.Controls.Add(this.xsdRbn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

