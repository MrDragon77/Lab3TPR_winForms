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
            dataGridView_table_I.DataSource = datasetTemp.Tables[tablesNames.table_I + "1"];
            dataGridView_table_P.DataSource = datasetTemp.Tables[tablesNames.table_P + "1"];
            dataGridView_table_K.DataSource = datasetTemp.Tables[tablesNames.table_K + "1"];
        }

        private void numericUpDown_tableID_ValueChanged(object sender, EventArgs e)
        {
            dataGridView_table_I.DataSource = datasetTemp.Tables[tablesNames.table_I + numericUpDown_tableID.Value.ToString()];
            dataGridView_table_P.DataSource = datasetTemp.Tables[tablesNames.table_P + numericUpDown_tableID.Value.ToString()];
            dataGridView_table_K.DataSource = datasetTemp.Tables[tablesNames.table_K + numericUpDown_tableID.Value.ToString()];
            dataGridView_table_I.Update();
            dataGridView_table_P.Update();
            dataGridView_table_K.Update();
        }

        private void button_SaveChanges_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dataGridView_table_I_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView_table_I.Update();
        }

        private void dataGridView_table_P_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView_table_P.Update();
        }

        private void dataGridView_table_K_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView_table_K.Update();
        }


        private void button_Graph_Click(object sender, EventArgs e)
        {

            //Application.Run(new MainForm(datasetTemp.Tables["s" + numericUpDown_tableID.Value.ToString()]));
            MainForm GraphForm = new MainForm(datasetTemp.Tables["s" + numericUpDown_tableID.Value.ToString()]);
            GraphForm.ShowDialog();
        }

        private void dataGridView_table_I_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < dataGridView_table_I.Rows.Count; i++)
            {
                dataGridView_table_I.Rows[i].HeaderCell.Value = "И" + (i + 1).ToString();
            }
        }

        private void dataGridView_table_P_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < dataGridView_table_P.Rows.Count; i++)
            {
                dataGridView_table_P.Rows[i].HeaderCell.Value = "П" + (i + 1).ToString();
            }
        }

        private void dataGridView_table_K_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < dataGridView_table_K.Rows.Count; i++)
            {
                dataGridView_table_K.Rows[i].HeaderCell.Value = "К" + (i + 1).ToString();
            }
        }
    }
}
