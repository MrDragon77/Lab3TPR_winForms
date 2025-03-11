namespace ConjTable.Demo
{
    partial class MainForm
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
            splitContainer1 = new SplitContainer();
            conjTable1 = new AdjTable();
            conjPanel1 = new AdjPanel();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)conjTable1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(4, 5, 4, 5);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(conjTable1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(conjPanel1);
            splitContainer1.Size = new Size(1013, 678);
            splitContainer1.SplitterDistance = 335;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 3;
            // 
            // conjTable1
            // 
            conjTable1.AllowUserToAddRows = false;
            conjTable1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            conjTable1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            conjTable1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            conjTable1.ColumnHeadersVisible = false;
            conjTable1.Dock = DockStyle.Top;
            conjTable1.Location = new Point(0, 0);
            conjTable1.Margin = new Padding(4, 5, 4, 5);
            conjTable1.Name = "conjTable1";
            conjTable1.RowHeadersVisible = false;
            conjTable1.RowHeadersWidth = 51;
            conjTable1.Size = new Size(335, 255);
            conjTable1.TabIndex = 1;
            conjTable1.VirtualMode = true;
            conjTable1.CellContentClick += conjTable1_CellContentClick;
            conjTable1.CellValueChanged += conjTable1_CellValueChanged;
            // 
            // conjPanel1
            // 
            conjPanel1.BorderStyle = BorderStyle.FixedSingle;
            conjPanel1.Dock = DockStyle.Fill;
            conjPanel1.Location = new Point(0, 0);
            conjPanel1.Margin = new Padding(4, 5, 4, 5);
            conjPanel1.Name = "conjPanel1";
            conjPanel1.Size = new Size(673, 678);
            conjPanel1.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1013, 678);
            Controls.Add(splitContainer1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "MainForm";
            Text = "Граф состояний";
            Load += MainForm_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)conjTable1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private AdjPanel conjPanel1;
        private AdjTable conjTable1;
        private SplitContainer splitContainer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

