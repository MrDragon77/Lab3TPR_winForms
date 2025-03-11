using System.Data;

namespace Lab3TPR_winForms
{
    //Form1 - ������� �����, ������������ ��� ����� ������� ���������� � ������� �� ������ �������� ���� ��� ����� ������� ����������
    //� ����� ��� ���������� ������ � ���� � �������� �� �� �����
    public partial class Form1 : Form
    {
        DataSet dataset; //will have 5 tables
        Calculator calculator;
        bool isDatasetCreated = false;
        bool isBindTablesCreated = false; //tables 
        int savedResourceNum = 0;
        //int savedStrategyNum = 0; //not used
        //int savedConditionNum = 0; //not used
        public Form1()
        {
            InitializeComponent();
            dataset = new DataSet();
            calculator = new Calculator(dataset, 1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonEditForm2_Click(object sender, EventArgs e)
        {
            //|| savedStrategyNums != Int32.Parse(textBox_strategyNum.Text)
            bool isNeedToCreateDataset = false;
            if (!isDatasetCreated)
            {
                isNeedToCreateDataset = true;
            }
            else
            {
                if (savedResourceNum != Decimal.ToInt32(nud_resourceNum.Value))
                {
                    DialogResult result = MessageBox.Show("� ���� ��� ���� ����������� ������. \n�� - ��������� �� �� ����.\n��� - ������� ����� ������", "������", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        nud_resourceNum.Value = Convert.ToDecimal(savedResourceNum);
                        isNeedToCreateDataset = false;
                    }
                    else if (result == DialogResult.No)
                    {
                        isNeedToCreateDataset = true;
                    }
                }
            }

            if (isNeedToCreateDataset)
            {
                int resourceNum = Decimal.ToInt32(nud_resourceNum.Value);
                //int conditionNum = Decimal.ToInt32(nud_conditionNum.Value);
                savedResourceNum = resourceNum;
                dataset = new DataSet();
                for (int i = 1; i <= resourceNum; i++)
                {
                    DataTable I = new DataTable(tablesNames.table_I + i.ToString()); //������� ������������ �������
                    I.Columns.Add("��������"); //������� 1 ��� �������� ������������� �������
                    I.Columns.Add("�����������"); //������� 2 ��� ����������� ������������� ������������� �������
                    I.Rows.Add("", "");

                    DataTable P = new DataTable(tablesNames.table_P + i.ToString()); //������� ������������� �������
                    P.Columns.Add("��������"); //������� 1 ��� �������� ������������� �������
                    P.Rows.Add("");

                    DataTable K = new DataTable(tablesNames.table_K + i.ToString()); //������� �������� �������
                    K.Columns.Add("��������"); //������� 1 ��� �������� ������������� �������
                    K.Columns.Add("������"); //������� 2 ��� ����������� ������������� ������������� �������
                    K.Rows.Add("", "");

                    dataset.Tables.Add(I);
                    dataset.Tables.Add(P);
                    dataset.Tables.Add(K);
                }
                isDatasetCreated = true;
                isBindTablesCreated = false;
            }

            using (Form2 form2 = new Form2(dataset, savedResourceNum)) //��������� Form2 ����� ������������� ������ �������
            {
                if (form2.ShowDialog() == DialogResult.OK)
                {
                    dataset = form2.datasetTemp;
                    isBindTablesCreated = false;
                }

            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string saveName = textBox_saveName.Text + ".xml";
            if (textBox_saveName.Text == "")
            {
                MessageBox.Show("�������� ��� �����");
                return;
            }
            if (File.Exists(saveName))
            {
                MessageBox.Show("���� � ����� ������ ��� ����������");
                return;
            }
            if (!isDatasetCreated)
            {
                MessageBox.Show("������ ���������. ������� �������� ������ � ��������� �� �������.");
                return;
            }
            if (!isBindTablesCreated)
            {
                MessageBox.Show("�������� ������. ������� �������� ����� ����� �����������.");
                return;
            }
            if (dataset.Tables.Contains(tablesNames.table_state))
            {
                dataset.Tables.Remove(tablesNames.table_state);
            }
            DataTable stateTable = new DataTable(tablesNames.table_state); //�������� ����������� ������� state
            stateTable.Columns.Add("resourceNum", typeof(int));
            dataset.Tables.Add(stateTable);
            dataset.WriteXml(saveName);
            MessageBox.Show("���� ��������");
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            string openName = textBox_saveName.Text + ".xml";
            if (!File.Exists(openName))
            {
                MessageBox.Show("����� � ����� ������ ���");
                return;
            }
            dataset = new DataSet();
            dataset.ReadXml(openName);
            DataTable stateTable = dataset.Tables[tablesNames.table_state];
            nud_resourceNum.Value = Convert.ToDecimal(stateTable.Rows[0]["resourceNum"]);
            savedResourceNum = Int32.Parse(stateTable.Rows[0]["resourceNum"].ToString());
            MessageBox.Show("���� ��������");
            isDatasetCreated = true;

        }

        private void button_StartModelling_Click(object sender, EventArgs e)
        {
            calculator.ChangeDS(dataset);
            calculator.ChangeIterations(Decimal.ToInt32(nud_StepNum.Value));
            DataTable result = calculator.Calculate();
            using (Form3 form3 = new Form3(result))
            {
                form3.ShowDialog();
            }
        }

        private void button_EditForm4_Click(object sender, EventArgs e)
        {
            if (!isDatasetCreated)
            {
                MessageBox.Show("������ - ������ ������� �� �������.\n���������� ������� ������� ������ ������������, ������������� � �������� �������.");
                return;
            }
            bool isNeedToCreateBindTables = false;
            if (!isBindTablesCreated)
            {
                isNeedToCreateBindTables = true;
            }
            else
            {
                if (savedResourceNum != Decimal.ToInt32(nud_resourceNum.Value))
                {
                    DialogResult result = MessageBox.Show("� ���� ��� ���� ����������� ������. \n�� - ��������� �� �� ����.\n��� - ������� ����� ������", "������", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        nud_resourceNum.Value = Convert.ToDecimal(savedResourceNum);
                        isNeedToCreateBindTables = false;
                    }
                    else if (result == DialogResult.No)
                    {
                        isNeedToCreateBindTables = false;
                        MessageBox.Show("��� ���� ����� ������� ����� ������ ������� �� ������ ������������� ������");
                    }
                }
            }


            if (isNeedToCreateBindTables)
            {
                int resourceNum = Decimal.ToInt32(nud_resourceNum.Value);
                for (int i = 1; i <= resourceNum; i++)
                {
                    if (dataset.Tables.Contains(tablesNames.table_S_IP + i.ToString()))
                    {
                        dataset.Tables.Remove(tablesNames.table_S_IP + i.ToString());
                    }
                    if (dataset.Tables.Contains(tablesNames.table_S_PK + i.ToString()))
                    {
                        dataset.Tables.Remove(tablesNames.table_S_PK + i.ToString());
                    }
                }


                savedResourceNum = resourceNum;
                for (int i = 1; i <= resourceNum; i++)
                {
                    int I_num = dataset.Tables[tablesNames.table_I + i.ToString()].Rows.Count;
                    int P_num = dataset.Tables[tablesNames.table_P + i.ToString()].Rows.Count;
                    int K_num = dataset.Tables[tablesNames.table_K + i.ToString()].Rows.Count;
                    DataTable S_IP = new DataTable(tablesNames.table_S_IP + i.ToString()); //������� ������ �� ������������ � �������������
                    for (int j = 1; j <= P_num; j++)
                    {
                        S_IP.Columns.Add(tablesNames.table_P + j.ToString());
                    }
                    for (int j = 1; j <= I_num; j++)
                    {
                        S_IP.Rows.Add("");
                    }

                    DataTable S_PK = new DataTable(tablesNames.table_S_PK + i.ToString()); //������� ������ �� ������������ � �������������
                    for (int j = 1; j <= K_num; j++)
                    {
                        S_PK.Columns.Add(tablesNames.table_K + j.ToString());
                    }
                    for (int j = 1; j <= P_num; j++)
                    {
                        S_PK.Rows.Add("");
                    }

                    dataset.Tables.Add(S_IP);
                    dataset.Tables.Add(S_PK);
                }
                isBindTablesCreated = true;
            }


            using (Form4 form4 = new Form4(dataset, savedResourceNum)) //��������� Form4 ����� ������������� ����� �������
            {
                if (form4.ShowDialog() == DialogResult.OK)
                {
                    dataset = form4.datasetTemp;
                }

            }
        }
    }

    static public class tablesNames
    {
        //I - table for �������� ���������
        //P - table for ������������� ���������
        //K - table for �������� ���������
        //S_IP - table for ����� ��������� P �� I
        //S_PK - table for ����� ��������� K �� P
        //state - ����������� ������� (������������ ��� ���������� ������ �� Form1)
        public const String table_I = "I";
        public const String table_P = "P";
        public const String table_K = "K";
        public const String table_S_IP = "S_IP";
        public const String table_S_PK = "S_PK";
        public const String table_state = "state";
    }
}