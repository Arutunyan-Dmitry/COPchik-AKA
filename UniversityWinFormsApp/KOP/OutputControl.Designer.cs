namespace KOP
{
    partial class OutputControl
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
            this.myTreeView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // myTreeView
            // 
            this.myTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.myTreeView.Location = new System.Drawing.Point(0, 0);
            this.myTreeView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.myTreeView.Name = "myTreeView";
            this.myTreeView.Size = new System.Drawing.Size(322, 368);
            this.myTreeView.TabIndex = 0;
            this.myTreeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.myTreeView_KeyDown);
            // 
            // OutputControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.myTreeView);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "OutputControl";
            this.Size = new System.Drawing.Size(322, 368);
            this.ResumeLayout(false);

        }

        #endregion

        private TreeView myTreeView;
    }
}
