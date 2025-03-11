using System.Data;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Xml;

class Calculator
{
    public DataSet DS;
    int iterations;

    public Calculator(DataSet newDS, int iter)
    {
        DS = newDS;
        iterations = iter;
    }

    public void ChangeDS(DataSet new_DS)
    {
        DS = new_DS;
    }

    public void ChangeIterations(int new_iters)
    {
        iterations = new_iters;
    }

    public DataTable Calculate()
    {
        int conditions = DS.Tables["s" + 1.ToString()].Rows.Count;
        DataTable results = new DataTable();
        results.Clear();
        for (int i = 0 ; i < iterations; i++)
        {
            results.Columns.Add((i+1).ToString());
        }
        for (int i = 0; i < conditions * 2; i++)
        {
            DataRow row = results.NewRow();
            for(int j = 0; j < iterations; j++)
            {
                row[j] = 0;
            }
            results.Rows.Add(row);
        }
        for (int n = 0; n < iterations; n++)
        {
            double sum = 0;
            int cur_strat = 1;
            while (DS.Tables["s" + cur_strat.ToString()] != null)
            {
                DataTable s = DS.Tables["s" + cur_strat.ToString()];
                DataTable d = DS.Tables["d" + cur_strat.ToString()];

                for (int j = 0; j < conditions; j++)
                {
                    sum = 0;
                    for (int i = 0; i < conditions; i++)
                    {
                        sum += Convert.ToDouble(s.Rows[j][i]) * Convert.ToDouble(d.Rows[j][i]); //тут мы из состояния j смотрим сумму вероятностей, умноженных на прибыль каждого схода
                        Console.WriteLine(s.Rows[j][i]);
                        Console.WriteLine(d.Rows[j][i]);
                    }
                    if (n > 0)
                    {
                        for (int i = 0; i < conditions; i++)
                        {
                            sum += Convert.ToDouble(results.Rows[i][n - 1]) * Convert.ToDouble(s.Rows[j][i]); //добавляем к ожидаемой прибыли максимальные прибыли с прошлых итераций и умножаем их на вероятности текущей стратегии (я час сидел и так и не понял, почему именно так, спасите, XDXDXD, ну сдали и Бог с ним
                        }
                    }
                    if (sum > Convert.ToDouble(results.Rows[j][n]))
                    {
                        results.Rows[j][n] = sum;   // если это максимально прибыльный вариант, то вписываем его и номер стратегии
                        results.Rows[j + conditions][n] = cur_strat;
                    }
                }
                cur_strat++;
            }
        }
        return results;
    }
}