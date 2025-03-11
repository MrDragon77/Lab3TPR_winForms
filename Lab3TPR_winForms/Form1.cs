using System.Data;

namespace Lab3TPR_winForms
{
    //Form1 - главная форма, используется для ввода простых параметров и нажатия на кнопки открытия форм для ввода сложных параметров
    //а также для сохранения данных в файл и загрузки их из файла
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
                    DialogResult result = MessageBox.Show("В кеше уже есть сохраненные списки. \nДа - загрузить их из кеша.\nНет - Создать новые списки", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                    DataTable I = new DataTable(tablesNames.table_I + i.ToString()); //таблица инициирующих событий
                    I.Columns.Add("Название"); //колонка 1 для названия инициирующего события
                    I.Columns.Add("Вероятность"); //колонка 2 для вероятности возникновения инициирующего события
                    I.Rows.Add("", "");

                    DataTable P = new DataTable(tablesNames.table_P + i.ToString()); //таблица промежуточных событий
                    P.Columns.Add("Название"); //колонка 1 для названия инициирующего события
                    P.Rows.Add("");

                    DataTable K = new DataTable(tablesNames.table_K + i.ToString()); //таблица конечных событий
                    K.Columns.Add("Название"); //колонка 1 для названия инициирующего события
                    K.Columns.Add("Потери"); //колонка 2 для вероятности возникновения инициирующего события
                    K.Rows.Add("", "");

                    dataset.Tables.Add(I);
                    dataset.Tables.Add(P);
                    dataset.Tables.Add(K);
                }
                isDatasetCreated = true;
                isBindTablesCreated = false;
            }

            using (Form2 form2 = new Form2(dataset, savedResourceNum)) //открываем Form2 чтобы редактировать списки событий
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
                MessageBox.Show("Напишите имя файла");
                return;
            }
            if (File.Exists(saveName))
            {
                MessageBox.Show("Файл с таким именем уже существует");
                return;
            }
            if (!isDatasetCreated)
            {
                MessageBox.Show("Нечего сохранять. Сначала создайте списки и заполните их данными.");
                return;
            }
            if (!isBindTablesCreated)
            {
                MessageBox.Show("Неполные данные. Сначала создайте связи между состояниями.");
                return;
            }
            if (dataset.Tables.Contains(tablesNames.table_state))
            {
                dataset.Tables.Remove(tablesNames.table_state);
            }
            DataTable stateTable = new DataTable(tablesNames.table_state); //название технической таблицы state
            stateTable.Columns.Add("resourceNum", typeof(int));
            dataset.Tables.Add(stateTable);
            dataset.WriteXml(saveName);
            MessageBox.Show("Файл сохранен");
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            string openName = textBox_saveName.Text + ".xml";
            if (!File.Exists(openName))
            {
                MessageBox.Show("Файла с таким именем нет");
                return;
            }
            dataset = new DataSet();
            dataset.ReadXml(openName);
            DataTable stateTable = dataset.Tables[tablesNames.table_state];
            nud_resourceNum.Value = Convert.ToDecimal(stateTable.Rows[0]["resourceNum"]);
            savedResourceNum = Int32.Parse(stateTable.Rows[0]["resourceNum"].ToString());
            MessageBox.Show("Файл загружен");
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
                MessageBox.Show("Ошибка - Списки событий не созданы.\nНеобходимо сначала создать списки Инициирующих, Промежуточных и Конечных событий.");
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
                    DialogResult result = MessageBox.Show("В кеше уже есть сохраненные списки. \nДа - загрузить их из кеша.\nНет - Создать новые списки", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        nud_resourceNum.Value = Convert.ToDecimal(savedResourceNum);
                        isNeedToCreateBindTables = false;
                    }
                    else if (result == DialogResult.No)
                    {
                        isNeedToCreateBindTables = false;
                        MessageBox.Show("Для того чтобы создать новые списки нажмите на кнопку Редактировать списки");
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
                    DataTable S_IP = new DataTable(tablesNames.table_S_IP + i.ToString()); //таблица связей от инициирующих к промежуточным
                    for (int j = 1; j <= P_num; j++)
                    {
                        S_IP.Columns.Add(tablesNames.table_P + j.ToString());
                    }
                    for (int j = 1; j <= I_num; j++)
                    {
                        S_IP.Rows.Add("");
                    }

                    DataTable S_PK = new DataTable(tablesNames.table_S_PK + i.ToString()); //таблица связей от инициирующих к промежуточным
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


            using (Form4 form4 = new Form4(dataset, savedResourceNum)) //открываем Form4 чтобы редактировать связи событий
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
        //I - table for исходные состояния
        //P - table for промежуточные состояния
        //K - table for конечные состояния
        //S_IP - table for связи состояний P от I
        //S_PK - table for связи состояний K от P
        //state - техническая таблица (используется для сохранения данных на Form1)
        public const String table_I = "I";
        public const String table_P = "P";
        public const String table_K = "K";
        public const String table_S_IP = "S_IP";
        public const String table_S_PK = "S_PK";
        public const String table_state = "state";
    }
}