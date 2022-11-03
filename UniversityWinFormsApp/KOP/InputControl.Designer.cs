namespace KOP
{
    partial class InputControl
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelText = new System.Windows.Forms.Label();
            this.myDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelText);
            this.panel1.Controls.Add(this.myDateTimePicker);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(373, 59);
            this.panel1.TabIndex = 0;
            // 
            // labelText
            // 
            this.labelText.AutoSize = true;
            this.labelText.Location = new System.Drawing.Point(3, 26);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(38, 15);
            this.labelText.TabIndex = 3;
            this.labelText.Text = "label1";
            // 
            // myDateTimePicker
            // 
            this.myDateTimePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDateTimePicker.Location = new System.Drawing.Point(0, 0);
            this.myDateTimePicker.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.myDateTimePicker.Name = "myDateTimePicker";
            this.myDateTimePicker.Size = new System.Drawing.Size(373, 23);
            this.myDateTimePicker.TabIndex = 2;
            // 
            // InputControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "InputControl";
            this.Size = new System.Drawing.Size(376, 59);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label labelText;
        private DateTimePicker myDateTimePicker;
    }
}
