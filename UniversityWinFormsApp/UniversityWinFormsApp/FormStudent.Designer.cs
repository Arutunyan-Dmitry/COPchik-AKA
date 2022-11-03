namespace UniversityWinFormsApp
{
    partial class FormStudent
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
            this.labelFlm = new System.Windows.Forms.Label();
            this.textBoxFlm = new System.Windows.Forms.TextBox();
            this.labelShrtChrct = new System.Windows.Forms.Label();
            this.textBoxShortCharacteristic = new System.Windows.Forms.TextBox();
            this.arutunyanComboBox = new ArutunyanControlLibrary.ArutunyanComboBox();
            this.labelGrade = new System.Windows.Forms.Label();
            this.kochkarevaTextBox = new Kochkareva_var16.KochkarevaTextBox.KochkarevaTextBox();
            this.labelSchl = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelFlm
            // 
            this.labelFlm.AutoSize = true;
            this.labelFlm.Location = new System.Drawing.Point(8, 9);
            this.labelFlm.Name = "labelFlm";
            this.labelFlm.Size = new System.Drawing.Size(42, 20);
            this.labelFlm.TabIndex = 0;
            this.labelFlm.Text = "ФИО";
            // 
            // textBoxFlm
            // 
            this.textBoxFlm.Location = new System.Drawing.Point(12, 32);
            this.textBoxFlm.Name = "textBoxFlm";
            this.textBoxFlm.Size = new System.Drawing.Size(374, 27);
            this.textBoxFlm.TabIndex = 1;
            // 
            // labelShrtChrct
            // 
            this.labelShrtChrct.AutoSize = true;
            this.labelShrtChrct.Location = new System.Drawing.Point(12, 75);
            this.labelShrtChrct.Name = "labelShrtChrct";
            this.labelShrtChrct.Size = new System.Drawing.Size(176, 20);
            this.labelShrtChrct.TabIndex = 2;
            this.labelShrtChrct.Text = "Краткая характеристика";
            // 
            // textBoxShortCharacteristic
            // 
            this.textBoxShortCharacteristic.Location = new System.Drawing.Point(12, 98);
            this.textBoxShortCharacteristic.Multiline = true;
            this.textBoxShortCharacteristic.Name = "textBoxShortCharacteristic";
            this.textBoxShortCharacteristic.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxShortCharacteristic.Size = new System.Drawing.Size(374, 140);
            this.textBoxShortCharacteristic.TabIndex = 3;
            // 
            // arutunyanComboBox
            // 
            this.arutunyanComboBox.CurrentValue = "";
            this.arutunyanComboBox.Location = new System.Drawing.Point(12, 281);
            this.arutunyanComboBox.Name = "arutunyanComboBox";
            this.arutunyanComboBox.Size = new System.Drawing.Size(374, 34);
            this.arutunyanComboBox.TabIndex = 4;
            // 
            // labelGrade
            // 
            this.labelGrade.AutoSize = true;
            this.labelGrade.Location = new System.Drawing.Point(12, 258);
            this.labelGrade.Name = "labelGrade";
            this.labelGrade.Size = new System.Drawing.Size(41, 20);
            this.labelGrade.TabIndex = 5;
            this.labelGrade.Text = "Курс";
            // 
            // kochkarevaTextBox
            // 
            this.kochkarevaTextBox.Location = new System.Drawing.Point(12, 359);
            this.kochkarevaTextBox.Name = "kochkarevaTextBox";
            this.kochkarevaTextBox.Size = new System.Drawing.Size(374, 31);
            this.kochkarevaTextBox.TabIndex = 6;
            // 
            // labelSchl
            // 
            this.labelSchl.AutoSize = true;
            this.labelSchl.Location = new System.Drawing.Point(12, 336);
            this.labelSchl.Name = "labelSchl";
            this.labelSchl.Size = new System.Drawing.Size(84, 20);
            this.labelSchl.TabIndex = 7;
            this.labelSchl.Text = "Стипендия";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(292, 416);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(94, 29);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(180, 416);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(106, 29);
            this.buttonSave.TabIndex = 9;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // FormStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(400, 455);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelSchl);
            this.Controls.Add(this.kochkarevaTextBox);
            this.Controls.Add(this.labelGrade);
            this.Controls.Add(this.arutunyanComboBox);
            this.Controls.Add(this.textBoxShortCharacteristic);
            this.Controls.Add(this.labelShrtChrct);
            this.Controls.Add(this.textBoxFlm);
            this.Controls.Add(this.labelFlm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new System.Drawing.Size(418, 502);
            this.Name = "FormStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Студент";
            this.Load += new System.EventHandler(this.FormStudent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelFlm;
        private TextBox textBoxFlm;
        private Label labelShrtChrct;
        private TextBox textBoxShortCharacteristic;
        private ArutunyanControlLibrary.ArutunyanComboBox arutunyanComboBox;
        private Label labelGrade;
        private Kochkareva_var16.KochkarevaTextBox.KochkarevaTextBox kochkarevaTextBox;
        private Label labelSchl;
        private Button buttonCancel;
        private Button buttonSave;
    }
}