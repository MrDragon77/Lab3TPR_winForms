using System;
using System.Data;
using System.Windows.Forms;

namespace ConjTable.Demo
{
    public partial class MainForm : Form
    {
        DataTable strategy;
        double[,] _matrix;
        public MainForm(DataTable strategy)
        {
            InitializeComponent();
            this.strategy = strategy;
            int N = strategy.Rows.Count;
            _matrix = new double[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    _matrix[i, j] = Convert.ToDouble(strategy.Rows[i][j]);
                }
            }
        }



        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            conjTable1.Build(_matrix);
            conjPanel1.Build(_matrix);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            conjPanel1.Build(conjTable1.Matrix);
        }

        private void conjTable1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            conjPanel1.Build(conjTable1.Matrix);
        }

        private void conjTable1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
