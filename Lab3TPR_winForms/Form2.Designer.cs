namespace Lab3TPR_winForms
{
    partial class Form2
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
            label_table_I = new Label();
            dataGridView_PaymentMatrix = new DataGridView();
            numericUpDown_tableID = new NumericUpDown();
            button_SaveChanges = new Button();
            button_Graph = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView_PaymentMatrix).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_tableID).BeginInit();
            SuspendLayout();
            // 
            // label_table_I
            // 
            label_table_I.AutoSize = true;
            label_table_I.Location = new Point(60, 41);
            label_table_I.Name = "label_table_I";
            label_table_I.Size = new Size(118, 15);
            label_table_I.TabIndex = 0;
            label_table_I.Text = "Платежная матрица";
            // 
            // dataGridView_PaymentMatrix
            // 
            dataGridView_PaymentMatrix.AllowUserToDeleteRows = false;
            dataGridView_PaymentMatrix.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_PaymentMatrix.ColumnHeadersVisible = false;
            dataGridView_PaymentMatrix.Location = new Point(60, 58);
            dataGridView_PaymentMatrix.Margin = new Padding(3, 2, 3, 2);
            dataGridView_PaymentMatrix.Name = "dataGridView_PaymentMatrix";
            dataGridView_PaymentMatrix.RowHeadersWidth = 51;
            dataGridView_PaymentMatrix.RowTemplate.Height = 29;
            dataGridView_PaymentMatrix.Size = new Size(659, 473);
            dataGridView_PaymentMatrix.TabIndex = 1;
            dataGridView_PaymentMatrix.RowsAdded += dataGridView_table_I_RowsAdded;
            dataGridView_PaymentMatrix.SelectionChanged += dataGridView_table_I_SelectionChanged;
            // 
            // numericUpDown_tableID
            // 
            numericUpDown_tableID.Location = new Point(557, 31);
            numericUpDown_tableID.Margin = new Padding(3, 2, 3, 2);
            numericUpDown_tableID.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown_tableID.Name = "numericUpDown_tableID";
            numericUpDown_tableID.Size = new Size(162, 23);
            numericUpDown_tableID.TabIndex = 3;
            numericUpDown_tableID.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown_tableID.Visible = false;
            numericUpDown_tableID.ValueChanged += numericUpDown_tableID_ValueChanged;
            // 
            // button_SaveChanges
            // 
            button_SaveChanges.Location = new Point(612, 571);
            button_SaveChanges.Margin = new Padding(3, 2, 3, 2);
            button_SaveChanges.Name = "button_SaveChanges";
            button_SaveChanges.Size = new Size(176, 22);
            button_SaveChanges.TabIndex = 4;
            button_SaveChanges.Text = "Сохранить изменения";
            button_SaveChanges.UseVisualStyleBackColor = true;
            button_SaveChanges.Click += button_SaveChanges_Click;
            // 
            // button_Graph
            // 
            button_Graph.Location = new Point(60, 580);
            button_Graph.Margin = new Padding(3, 2, 3, 2);
            button_Graph.Name = "button_Graph";
            button_Graph.Size = new Size(176, 22);
            button_Graph.TabIndex = 6;
            button_Graph.Text = "Показать граф состояний";
            button_Graph.UseVisualStyleBackColor = true;
            button_Graph.Visible = false;
            button_Graph.Click += button_Graph_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(989, 938);
            Controls.Add(button_Graph);
            Controls.Add(button_SaveChanges);
            Controls.Add(numericUpDown_tableID);
            Controls.Add(dataGridView_PaymentMatrix);
            Controls.Add(label_table_I);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form2";
            Text = "Редактирование платежной матрицы";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView_PaymentMatrix).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_tableID).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_table_I;
        private DataGridView dataGridView_PaymentMatrix;
        private NumericUpDown numericUpDown_tableID;
        private Button button_SaveChanges;
        private Button button_Graph;
    }
}