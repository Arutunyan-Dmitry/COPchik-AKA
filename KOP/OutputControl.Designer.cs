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
            this.myTreeViewLabelShow = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // myTreeView
            // 
            this.myTreeView.Location = new System.Drawing.Point(0, 0);
            this.myTreeView.Name = "myTreeView";
            this.myTreeView.Size = new System.Drawing.Size(282, 241);
            this.myTreeView.TabIndex = 0;
            this.myTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // myTreeViewLabelShow
            // 
            this.myTreeViewLabelShow.AutoSize = true;
            this.myTreeViewLabelShow.Location = new System.Drawing.Point(3, 244);
            this.myTreeViewLabelShow.Name = "myTreeViewLabelShow";
            this.myTreeViewLabelShow.Size = new System.Drawing.Size(140, 15);
            this.myTreeViewLabelShow.TabIndex = 1;
            this.myTreeViewLabelShow.Text = "Вы не выбрали элемент";
            // 
            // OutputControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.myTreeViewLabelShow);
            this.Controls.Add(this.myTreeView);
            this.Name = "OutputControl";
            this.Size = new System.Drawing.Size(282, 276);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TreeView myTreeView;
        private Label myTreeViewLabelShow;
    }
}
