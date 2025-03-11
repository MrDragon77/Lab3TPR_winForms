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
    //НЕ ИСПОЛЬЗУЕТСЯ В 3 ЛАБЕ
    //Form4 - форма для ввода сложных параметров
    //конкретно в этой вводятся связи между состояниями в две таблицы
    public partial class Form4 : Form
    {
        public DataSet datasetTemp;
        public Form4()
        {
            InitializeComponent();
            datasetTemp = new DataSet();
        }
        public Form4(DataSet dataset, int strategyNum)
        {
            InitializeComponent();
            this.datasetTemp = dataset;
            numericUpDown_tableID.Maximum = strategyNum;
            numericUpDown_tableID.Minimum = 1;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            //dataGridView_table_S_IP.DataSource = datasetTemp.Tables[tablesNames.table_S_IP + "1"];
            //dataGridView_table_S_PK.DataSource = datasetTemp.Tables[tablesNames.table_S_PK + "1"];
        }

        private void numericUpDown_tableID_ValueChanged(object sender, EventArgs e)
        {
            //dataGridView_table_S_IP.DataSource = datasetTemp.Tables[tablesNames.table_S_IP + numericUpDown_tableID.Value.ToString()];
            //dataGridView_table_S_PK.DataSource = datasetTemp.Tables[tablesNames.table_S_PK + numericUpDown_tableID.Value.ToString()];
            dataGridView_table_S_IP.Update();
            dataGridView_table_S_PK.Update();
        }

        private void button_SaveChanges_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dataGridView_table_S_IP_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView_table_S_IP.Update();
        }

        private void dataGridView_table_S_PK_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView_table_S_PK.Update();
        }

        private void dataGridView_table_S_IP_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < dataGridView_table_S_IP.ColumnCount; i++)
            {
                dataGridView_table_S_IP.Columns[i].HeaderText = "П" + (i + 1).ToString();
            }
            for (int i = 0; i < dataGridView_table_S_IP.Rows.Count; i++)
            {
                dataGridView_table_S_IP.Rows[i].HeaderCell.Value = "И" + (i + 1).ToString();
            }
        }

        private void dataGridView_table_S_PK_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < dataGridView_table_S_PK.ColumnCount; i++)
            {
                dataGridView_table_S_PK.Columns[i].HeaderText = "К" + (i + 1).ToString();
            }
            for (int i = 0; i < dataGridView_table_S_PK.Rows.Count; i++)
            {
                dataGridView_table_S_PK.Rows[i].HeaderCell.Value = "П" + (i + 1).ToString();
            }
        }
    }
}
