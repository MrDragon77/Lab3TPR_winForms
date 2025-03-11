namespace Lab3TPR_winForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label_ = new Label();
            button_StartModelling = new Button();
            label2 = new Label();
            label3 = new Label();
            button_EditForm2 = new Button();
            button_LoadFromFile = new Button();
            button_SaveToFile = new Button();
            textBox_saveName = new TextBox();
            nud_StepNum = new NumericUpDown();
            nud_conditionNum = new NumericUpDown();
            nud_resourceNum = new NumericUpDown();
            button_EditForm4 = new Button();
            label1 = new Label();
            textBox_accuracy = new TextBox();
            ((System.ComponentModel.ISupportInitialize)nud_StepNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_conditionNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_resourceNum).BeginInit();
            SuspendLayout();
            // 
            // label_
            // 
            label_.AutoSize = true;
            label_.Location = new Point(19, 36);
            label_.Name = "label_";
            label_.Size = new Size(179, 15);
            label_.TabIndex = 0;
            label_.Text = "Количество стратегий 1 игрока";
            // 
            // button_StartModelling
            // 
            button_StartModelling.Location = new Point(462, 220);
            button_StartModelling.Margin = new Padding(3, 2, 3, 2);
            button_StartModelling.Name = "button_StartModelling";
            button_StartModelling.Size = new Size(189, 33);
            button_StartModelling.TabIndex = 1;
            button_StartModelling.Text = "Начать моделирование";
            button_StartModelling.UseVisualStyleBackColor = true;
            button_StartModelling.Click += button_StartModelling_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 71);
            label2.Name = "label2";
            label2.Size = new Size(179, 15);
            label2.TabIndex = 3;
            label2.Text = "Количество стратегий 2 игрока";
            label2.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 232);
            label3.Name = "label3";
            label3.Size = new Size(127, 15);
            label3.TabIndex = 5;
            label3.Text = "Количество итераций";
            // 
            // button_EditForm2
            // 
            button_EditForm2.Location = new Point(29, 118);
            button_EditForm2.Margin = new Padding(3, 2, 3, 2);
            button_EditForm2.Name = "button_EditForm2";
            button_EditForm2.Size = new Size(257, 35);
            button_EditForm2.TabIndex = 7;
            button_EditForm2.Text = "Редактировать платежную матрицу";
            button_EditForm2.UseVisualStyleBackColor = true;
            button_EditForm2.Click += buttonEditForm2_Click;
            // 
            // button_LoadFromFile
            // 
            button_LoadFromFile.Location = new Point(448, 58);
            button_LoadFromFile.Margin = new Padding(3, 2, 3, 2);
            button_LoadFromFile.Name = "button_LoadFromFile";
            button_LoadFromFile.Size = new Size(131, 40);
            button_LoadFromFile.TabIndex = 8;
            button_LoadFromFile.Text = "Загрузка данных из файла";
            button_LoadFromFile.UseVisualStyleBackColor = true;
            button_LoadFromFile.Click += buttonLoad_Click;
            // 
            // button_SaveToFile
            // 
            button_SaveToFile.Location = new Point(584, 58);
            button_SaveToFile.Margin = new Padding(3, 2, 3, 2);
            button_SaveToFile.Name = "button_SaveToFile";
            button_SaveToFile.Size = new Size(121, 40);
            button_SaveToFile.TabIndex = 9;
            button_SaveToFile.Text = "Сохранить данные в файл";
            button_SaveToFile.UseVisualStyleBackColor = true;
            button_SaveToFile.Click += buttonSave_Click;
            // 
            // textBox_saveName
            // 
            textBox_saveName.Location = new Point(448, 34);
            textBox_saveName.Margin = new Padding(3, 2, 3, 2);
            textBox_saveName.Name = "textBox_saveName";
            textBox_saveName.Size = new Size(258, 23);
            textBox_saveName.TabIndex = 10;
            // 
            // nud_StepNum
            // 
            nud_StepNum.Location = new Point(180, 230);
            nud_StepNum.Margin = new Padding(3, 2, 3, 2);
            nud_StepNum.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nud_StepNum.Name = "nud_StepNum";
            nud_StepNum.Size = new Size(85, 23);
            nud_StepNum.TabIndex = 11;
            nud_StepNum.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // nud_conditionNum
            // 
            nud_conditionNum.Location = new Point(204, 69);
            nud_conditionNum.Margin = new Padding(3, 2, 3, 2);
            nud_conditionNum.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nud_conditionNum.Name = "nud_conditionNum";
            nud_conditionNum.Size = new Size(85, 23);
            nud_conditionNum.TabIndex = 12;
            nud_conditionNum.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nud_conditionNum.Visible = false;
            // 
            // nud_resourceNum
            // 
            nud_resourceNum.Location = new Point(204, 34);
            nud_resourceNum.Margin = new Padding(3, 2, 3, 2);
            nud_resourceNum.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nud_resourceNum.Name = "nud_resourceNum";
            nud_resourceNum.Size = new Size(85, 23);
            nud_resourceNum.TabIndex = 13;
            nud_resourceNum.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // button_EditForm4
            // 
            button_EditForm4.Location = new Point(133, 372);
            button_EditForm4.Margin = new Padding(3, 2, 3, 2);
            button_EditForm4.Name = "button_EditForm4";
            button_EditForm4.Size = new Size(257, 35);
            button_EditForm4.TabIndex = 14;
            button_EditForm4.Text = "Редактировать связи событий";
            button_EditForm4.UseVisualStyleBackColor = true;
            button_EditForm4.Visible = false;
            button_EditForm4.Click += button_EditForm4_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 191);
            label1.Name = "label1";
            label1.Size = new Size(111, 15);
            label1.TabIndex = 15;
            label1.Text = "Заданная точность";
            // 
            // textBox_accuracy
            // 
            textBox_accuracy.Location = new Point(180, 192);
            textBox_accuracy.Name = "textBox_accuracy";
            textBox_accuracy.Size = new Size(100, 23);
            textBox_accuracy.TabIndex = 16;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(764, 428);
            Controls.Add(textBox_accuracy);
            Controls.Add(label1);
            Controls.Add(button_EditForm4);
            Controls.Add(nud_resourceNum);
            Controls.Add(nud_conditionNum);
            Controls.Add(nud_StepNum);
            Controls.Add(textBox_saveName);
            Controls.Add(button_SaveToFile);
            Controls.Add(button_LoadFromFile);
            Controls.Add(button_EditForm2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button_StartModelling);
            Controls.Add(label_);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Ввод параметров модуляции";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)nud_StepNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_conditionNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_resourceNum).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_;
        private Button button_StartModelling;
        private Label label2;
        private Label label3;
        private Button button_EditForm2;
        private Button button_LoadFromFile;
        private Button button_SaveToFile;
        private TextBox textBox_saveName;
        private NumericUpDown nud_StepNum;
        private NumericUpDown nud_conditionNum;
        private NumericUpDown nud_resourceNum;
        private Button button_EditForm4;
        private Label label1;
        private TextBox textBox_accuracy;
    }
}