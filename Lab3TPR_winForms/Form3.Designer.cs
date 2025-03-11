namespace Lab3TPR_winForms
{
    partial class Form3
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
            dataGridView_results = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView_results).BeginInit();
            SuspendLayout();
            // 
            // dataGridView_results
            // 
            dataGridView_results.AllowUserToAddRows = false;
            dataGridView_results.AllowUserToDeleteRows = false;
            dataGridView_results.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_results.Location = new Point(29, 23);
            dataGridView_results.Name = "dataGridView_results";
            dataGridView_results.RowHeadersWidth = 51;
            dataGridView_results.RowTemplate.Height = 29;
            dataGridView_results.Size = new Size(753, 351);
            dataGridView_results.TabIndex = 2;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(981, 641);
            Controls.Add(dataGridView_results);
            Name = "Form3";
            Text = "Результаты моделирования";
            Load += Form3_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView_results).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView_results;
    }
}