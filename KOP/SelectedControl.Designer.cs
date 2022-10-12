using System.Drawing;
using System.Windows.Forms;

namespace KOP
{
    partial class SelectedControl
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
            this.myCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // myCheckedListBox
            // 
            this.myCheckedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myCheckedListBox.FormattingEnabled = true;
            this.myCheckedListBox.Location = new System.Drawing.Point(0, 0);
            this.myCheckedListBox.Name = "myCheckedListBox";
            this.myCheckedListBox.Size = new System.Drawing.Size(150, 150);
            this.myCheckedListBox.TabIndex = 0;
            this.myCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CheckedListBox_ItemCheck);
            // 
            // SelectedControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.myCheckedListBox);
            this.Name = "SelectedControl";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox myCheckedListBox;

    }
}
