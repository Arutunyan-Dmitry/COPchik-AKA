namespace TestComponents
{
    partial class FormTestComponents
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
            this.kochkarevaListBox1 = new Kochkareva_var16.KochkarevaListBox.KochkarevaListBox();
            this.kochkarevaTextBox1 = new Kochkareva_var16.KochkarevaTextBox.KochkarevaTextBox();
            this.kochkarevaDataGridView1 = new Kochkareva_var16.KochkarevaDataGridView.KochkarevaDataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // kochkarevaListBox1
            // 
            this.kochkarevaListBox1.CurrentValue = "";
            this.kochkarevaListBox1.Location = new System.Drawing.Point(12, 12);
            this.kochkarevaListBox1.Name = "kochkarevaListBox1";
            this.kochkarevaListBox1.Size = new System.Drawing.Size(246, 168);
            this.kochkarevaListBox1.TabIndex = 0;
            this.kochkarevaListBox1.ValueChanged += new System.EventHandler(this.kochkarevaListBox1_ValueChanged);
            // 
            // kochkarevaTextBox1
            // 
            this.kochkarevaTextBox1.Location = new System.Drawing.Point(12, 207);
            this.kochkarevaTextBox1.Name = "kochkarevaTextBox1";
            this.kochkarevaTextBox1.Size = new System.Drawing.Size(265, 118);
            this.kochkarevaTextBox1.TabIndex = 1;
            this.kochkarevaTextBox1.ValueChanged += new System.EventHandler(this.kochkarevaTextBox1_ValueChanged);
            // 
            // kochkarevaDataGridView1
            // 
            this.kochkarevaDataGridView1.Location = new System.Drawing.Point(283, 2);
            this.kochkarevaDataGridView1.Name = "kochkarevaDataGridView1";
            this.kochkarevaDataGridView1.Size = new System.Drawing.Size(803, 521);
            this.kochkarevaDataGridView1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 331);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(145, 331);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 29);
            this.button2.TabIndex = 4;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormTestComponents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 563);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.kochkarevaDataGridView1);
            this.Controls.Add(this.kochkarevaTextBox1);
            this.Controls.Add(this.kochkarevaListBox1);
            this.Name = "FormTestComponents";
            this.Text = "FormTestComponents";
            this.ResumeLayout(false);

        }

        #endregion

        private Kochkareva_var16.KochkarevaListBox.KochkarevaListBox kochkarevaListBox1;
        private Kochkareva_var16.KochkarevaTextBox.KochkarevaTextBox kochkarevaTextBox1;
        private Kochkareva_var16.KochkarevaDataGridView.KochkarevaDataGridView kochkarevaDataGridView1;
        private Button button1;
        private Button button2;
    }
}