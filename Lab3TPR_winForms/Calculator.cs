using System.Data;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Xml;

class Calculator
{
    public DataSet DS;
    public DataTable DT;
    int iterations;

    public Calculator(DataSet newDS, int iter)
    {
        DS = newDS;
        iterations = iter;
    }

    public void ChangeDS(DataSet new_Ds)
    {
        DS = new_Ds;
        DT = DS.Tables["PM"];
    }

    public void ChangeIterations(int new_iters)
    {
        iterations = new_iters;
    }

    public DataTable Calculate()
    {
        int first_st = DT.Rows.Count;
        int second_st = DT.Columns.Count;
        DataTable results = new DataTable();
        results.Clear();

        int M = 2 + first_st;
        int V = 4 + first_st + second_st;
        int jk = 1;
        int ik = 3 + first_st;
        for (int i = 0 ; i < first_st + second_st + 5; i++)
        {
            if (i == 0)
            {
                results.Columns.Add("k");
            }
            if (i == 1)
            {
                results.Columns.Add("jk");
            }
            if ((i > 1 && i < 2 + first_st))
            {
                results.Columns.Add("g" + (i - 1).ToString());
            }

            if (i == 2 + first_st)
            {
                results.Columns.Add("M");
            }
            if (i == 3 + first_st)
            {
                results.Columns.Add("ik");
            }
            if (i > 3 + first_st && i < 4 + first_st + second_st)
            {
                results.Columns.Add("h" + (i - 3 - first_st).ToString());
            }
            if (i == 4 + first_st + second_st)
            {
                results.Columns.Add("V");
            }
        }
        for (int i = 0; i < iterations; i++)
        {
            DataRow row = results.NewRow();
            for(int j = 0; j < first_st + second_st + 5; j++)
            {
                row[j] = 0;
            }
            results.Rows.Add(row);
        }

        double min = 10000000;
        double max = 0;

        for (int i = 0; i < first_st; i++)
        {
            results.Rows[0][2 + i] = Convert.ToDouble(DT.Rows[i][0]);
            if (min > Convert.ToDouble(DT.Rows[i][0]))
            {
                min = Convert.ToDouble(DT.Rows[i][0]);
                results.Rows[0][ik] = i + 1;
            }
        }
        for (int j = 0; j < second_st; j++)
        {
            results.Rows[0][4 + j + first_st] = Convert.ToDouble(DT.Rows[0][j]);
            if (max < Convert.ToDouble(DT.Rows[0][j]))
            {
                max = Convert.ToDouble(DT.Rows[0][j]);
                results.Rows[0][jk] = j + 1;
            }
        }
        results.Rows[0][0] = 1;
        results.Rows[0][M] = min;
        results.Rows[0][V] = max;


        for (int k = 1; k < iterations; k++)
        {
            min = 10000000;
            max = 0;
            results.Rows[k][0] = k + 1;

            for (int i = 0; i < first_st; i++)
            {
                results.Rows[k][2 + i] = Convert.ToDouble(results.Rows[k - 1][2 + i]) + Convert.ToDouble(DT.Rows[i][Convert.ToInt32(results.Rows[k - 1][jk]) - 1]);
                if (min > Convert.ToDouble(results.Rows[k][2 + i]))
                {
                    min = Convert.ToDouble(results.Rows[k][2 + i]);
                    results.Rows[k][ik] = i + 1;
                }
            }
            for (int j = 0; j < second_st; j++)
            {
                results.Rows[k][4 + first_st + j] = Convert.ToDouble(results.Rows[k - 1][4 + first_st + j]) + Convert.ToDouble(DT.Rows[Convert.ToInt32(results.Rows[k - 1][ik]) - 1][j]);
                if (max < Convert.ToDouble(results.Rows[k][4 + first_st + j]))
                {
                    max = Convert.ToDouble(results.Rows[k][4 + first_st + j]);
                    results.Rows[k][jk] = j + 1;
                }
            }
            results.Rows[k][M] = min / (k + 1);
            results.Rows[k][V] = max / (k + 1);
        }
        return results;
    }
}