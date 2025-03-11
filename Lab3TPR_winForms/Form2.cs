using ConjTable.Demo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3TPR_winForms
{
    //Form2 - форма для ввода сложных параметров
    //конкретно здесь вводятся данные об исходных, промежуточных и конечных состояниях в соответствующие таблицы
    public partial class Form2 : Form
    {
        public DataSet datasetTemp;
        public Form2()
        {
            InitializeComponent();
            datasetTemp = new DataSet();
        }
        public Form2(DataSet dataset, int strategyNum)
        {
            InitializeComponent();
            this.datasetTemp = dataset;
            numericUpDown_tableID.Maximum = strategyNum;
            numericUpDown_tableID.Minimum = 1;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView_PaymentMatrix.DataSource = datasetTemp.Tables[tablesNames.paymentMatrix];
            foreach (DataGridViewColumn column in dataGridView_PaymentMatrix.Columns)
            {
                column.Width = 40; // Установка ширины для каждого столбца
            }
        }

        private void numericUpDown_tableID_ValueChanged(object sender, EventArgs e)
        {
            dataGridView_PaymentMatrix.DataSource = datasetTemp.Tables[tablesNames.paymentMatrix];
            dataGridView_PaymentMatrix.Update();
        }

        private void button_SaveChanges_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dataGridView_table_I_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView_PaymentMatrix.Update();
        }

        private void button_Graph_Click(object sender, EventArgs e)
        {

            //Application.Run(new MainForm(datasetTemp.Tables["s" + numericUpDown_tableID.Value.ToString()]));
            MainForm GraphForm = new MainForm(datasetTemp.Tables["s" + numericUpDown_tableID.Value.ToString()]);
            GraphForm.ShowDialog();
        }
    }
}
