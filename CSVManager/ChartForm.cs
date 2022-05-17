using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CSVManager
{
    public partial class ChartForm : Form
    {
        #region Загрузка и данные

        public Tuple<string, string> names = new Tuple<string, string>("", "");
        public Dictionary<string, int> histDic = null;
        public Dictionary<double, double> graphDic = null;
        public List<Dictionary<string, double>> diagDic = null;
        public List<string> legendNames = null;
        private int scale = 1;
        private bool isHistInt = false;

        public ChartForm()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Загрузка формы для 3 разных случаев - гистограмма, график и диаграмма.
        /// </summary>
        private void HistForm_Load(object sender, EventArgs e)
        {
            try
            {
                chart.ChartAreas[0].AxisX.TitleFont = this.Font;
                chart.ChartAreas[0].AxisY.TitleFont = this.Font;

                if (histDic != null)
                {
                    chart.Series[0].Points.Clear();
                    chart.ChartAreas[0].AxisX.CustomLabels.Clear();
                    chart.ChartAreas[0].AxisX.MajorGrid.LineColor = chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;

                    ConvertToDoubleHistKeys(histDic);
                    int i = 0;
                    foreach (var item in histDic)
                    {
                        chart.Series[0].Points.Add(item.Value);
                        chart.ChartAreas[0].AxisX.CustomLabels.Add(new CustomLabel(i, i + 2, item.Key, 0, LabelMarkStyle.LineSideMark));
                        i++;
                    }

                    if(histDic.Count < 120)
                    chart.ChartAreas[0].AxisX.LabelStyle.Angle = -70;
                    else chart.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
                    chart.ChartAreas[0].AxisX.Title = names.Item1;
                    chart.ChartAreas[0].AxisY.Title = names.Item2;
                    return;
                }
                if (graphDic != null)
                {
                    chart.Series[0].Points.Clear();
                    chart.Series[0].ChartType = SeriesChartType.Spline;


                    int i = 0;
                    double xmax = double.MinValue, ymax = double.MinValue, xmin = double.MaxValue, ymin = double.MaxValue;
                    foreach (var item in graphDic.OrderBy(x => x.Key))
                    {
                        chart.Series[0].Points.AddXY(item.Key, item.Value);

                        xmax = Math.Max(item.Key, xmax);
                        ymax = Math.Max(item.Value, ymax);
                        xmin = Math.Min(item.Key, xmin);
                        ymin = Math.Min(item.Value, ymin);
                        i++;
                    }

                    foreach (var item in chart.Series[0].Points)
                    {
                        item.MarkerStyle = MarkerStyle.Circle;
                        item.MarkerSize = 4;
                    }

                    chart.ChartAreas[0].AxisX.MajorGrid.Interval = (xmax - xmin) / graphDic.Count;
                    chart.ChartAreas[0].AxisY.MajorGrid.Interval = (ymax - ymin) / graphDic.Count;
                    chart.ChartAreas[0].AxisX.MajorGrid.LineColor = chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;

                    chart.ChartAreas[0].AxisX.Title = names.Item1;
                    chart.ChartAreas[0].AxisY.Title = names.Item2;
                    //chart.ChartAreas[0].AxisX.LabelStyle.Angle = -90;

                    return;
                }
                if (diagDic != null)
                {
                    chart.Series.Clear();
                    chart.ChartAreas[0].AxisX.CustomLabels.Clear();
                    chart.ChartAreas[0].AxisY.CustomLabels.Clear();
                    chart.ChartAreas[0].AxisX.MajorGrid.LineColor = chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
                    chart.ChartAreas[0].AxisX.Title = names.Item1;
                    chart.ChartAreas[0].AxisY.Title = names.Item2;
                    chart.ChartAreas[0].AxisX.LabelStyle.Angle = -70;

                    int uniqueIndex = 1;
                    for (int row = 0; row < diagDic.Count; row++)
                    {
                        chart.Series.Add(new Series());

                        string name = legendNames[row];
                        while (!chart.Series.IsUniqueName(name))
                            name = legendNames[row] + "_" + uniqueIndex++;
                        chart.Series[row].Name = name;

                        int i = 0;
                        foreach (var item in diagDic[row])
                        {
                            chart.Series[row].Points.Add(item.Value);
                            if (row == 0)
                                chart.ChartAreas[0].AxisX.CustomLabels.Add(new CustomLabel(i, i + 2, item.Key, 0, LabelMarkStyle.LineSideMark));
                            i++;
                        }

                    }
                    chart.Legends.Add(new Legend());

                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("При работе программы произошла ошибка: " + ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Меню

        /// <summary>
        /// Анализ данных - для 3 разных случаев используются разные параметры метода GetStats.
        /// </summary>
        private void tsmiAnalys_Click(object sender, EventArgs e)
        {
            try
            {
                if (histDic != null)
                {
                    Dictionary<object, object> d = new Dictionary<object, object>();
                    foreach (var item in histDic)
                        d.Add(item.Key, item.Value);
                    if (!isHistInt)
                        MessageBox.Show(GetStats(d, null, $"частоты встречаемости {chart.ChartAreas[0].AxisX.Title}"), "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else MessageBox.Show(GetStats(d, $"числовых значений {chart.ChartAreas[0].AxisX.Title}", $"частоты встречаемости {chart.ChartAreas[0].AxisX.Title}"), "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }
                if (graphDic != null)
                {
                    Dictionary<object, object> d = new Dictionary<object, object>();
                    foreach (var item in graphDic)
                        d.Add(item.Key, item.Value);

                    MessageBox.Show(GetStats(d, chart.ChartAreas[0].AxisX.Title, chart.ChartAreas[0].AxisY.Title), "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (diagDic != null)
                {
                    if (diagDic.Count == 0)
                        return;
                    Dictionary<string, double> allVals = diagDic[0];
                    foreach (var item in allVals.Keys)
                    {
                        string key = item;
                        int ind = 1;
                        Dictionary<object, object> d = new Dictionary<object, object>();
                        foreach (var dic in diagDic)
                            d.Add(key + "-" + ind++, dic[key]);

                        MessageBox.Show(GetStats(d, null, key), "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("При анализе данных произошла ошибка: " + ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Изменение охвата значений - основная работа в методе ChangeScale.
        /// </summary>
        private void tsmiScaleN_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
                tsmiScale1.BackColor = Color.White;
                tsmiScale2.BackColor = Color.White;
                tsmiScale3.BackColor = Color.White;
                tsmiScale4.BackColor = Color.White;
                tsmiScale5.BackColor = Color.White;
                tsmi.BackColor = Color.Lime;
                scale = Convert.ToInt32(tsmi.Text.Split()[0]);

                ChangeScale();
            }
            catch (Exception ex)
            {
                MessageBox.Show("При работе произошла ошибка: " + ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Сохранение изображения графика по указанному пути в формате jpeg.
        /// </summary>
        private void tsmiSaveImage_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog openFolderDialog = new FolderBrowserDialog();
                openFolderDialog.Description = "Путь к изображению";

                if (openFolderDialog.ShowDialog() == DialogResult.Cancel)
                    return;

                string fullpath = openFolderDialog.SelectedPath;
                chart.SaveImage(Path.Combine(fullpath, "chart_" + DateTime.Now.ToOADate().ToString() + ".jpeg"), ChartImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                MessageBox.Show("При сохранении изображения произошла ошибка: " + ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion

        #region Мышь (нет, блин, крыса)

        /// <summary>
        /// Изменении курсора при наведении на график.
        /// </summary>
        private void chart_MouseMove(object sender, MouseEventArgs e)
        {
            var result = chart.HitTest(e.X, e.Y);
            Cursor = result.ChartElementType == ChartElementType.DataPoint ? Cursors.Hand : Cursors.Default;
        }

        /// <summary>
        /// Щелчок по графику: лкм - вывод информации, пкм - изменение цвета.
        /// </summary>
        private void chart_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                try
                {
                    var result = chart.HitTest(e.X, e.Y);
                    if (result == null || result.ChartElementType != ChartElementType.DataPoint)
                        return;

                    Button btn = new Button() { BackColor = Color.Red, FlatStyle = FlatStyle.Popup, Size = new Size(4, 4), Location = new Point(e.X - 1, e.Y - 1) };
                    chart.Controls.Add(btn);

                    if (histDic != null)
                        MessageBox.Show($"{chart.ChartAreas[0].AxisX.Title}: {chart.ChartAreas[0].AxisX.CustomLabels[result.PointIndex].Text}\n" +
                                              $"Частота: {result.Series.Points[result.PointIndex].YValues[0]}", "Информация о точке", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (graphDic != null)
                        MessageBox.Show($"{chart.ChartAreas[0].AxisX.Title} = {result.Series.Points[result.PointIndex].XValue}\n" +
                            $"{chart.ChartAreas[0].AxisY.Title} = {result.Series.Points[result.PointIndex].YValues[0]}", "Информация о точке", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (diagDic != null)
                        MessageBox.Show($"{result.Series.Name}:\n" +
                            $"{chart.ChartAreas[0].AxisX.CustomLabels[result.PointIndex].Text} = {result.Series.Points[result.PointIndex].YValues[0]}", "Информация о точке", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    chart.Controls.Remove(btn);
                    return;
                }
                catch (Exception) { }
            if (e.Button == MouseButtons.Right)
                try
                {
                    ColorDialog colorDialog = new ColorDialog();
                    if (colorDialog.ShowDialog() == DialogResult.Cancel)
                        return;
                    var result = chart.HitTest(e.X, e.Y);
                    if (result == null || result.ChartElementType != ChartElementType.DataPoint)
                        return;
                    result.Series.Color = colorDialog.Color;
                }
                catch (Exception) { }
        }

        #endregion

        #region Анализ данных

        /// <summary>
        /// Данные анализа значений. t1 - ось Ox, t2 - ось Оy. Если одно из них null, то информация по этой оси не выводится.
        /// </summary>
        private string GetStats(Dictionary<object, object> dict, string t1, string t2)
        {
            try
            {
                string text = $"Значения {t2}:\n\nСреднее значение:\t\t";
                List<double> vals = new List<double>();

                foreach (var item in dict.Values)
                    vals.Add(double.Parse(item.ToString()));

                double a = 0;
                text += $"{(!TryToGetAverage(vals, out a) ? "Не удалось вычислить" : GetF3(a))}\nМедиана:\t\t\t";
                text += $"{(!TryToGetMidian(vals, out a) ? "Не удалось вычислить" : GetF3(a))}\nДисперсия (в кв. ед.):\t\t";
                text += $"{(!TryToGetDispersion(vals, out a) ? "Не удалось вычислить" : GetF3(a))}\nСреднеквадратичное отклонение:\t";
                text += $"{(!TryToGetDispersion(vals, out a) ? "Не удалось вычислить" : GetF3(Math.Sqrt(a)))}";

                // Если не надо выводить данные по Ох, возвращаемся
                if (t1 == null)
                    return text;

                text += $"\n\n\nЗначения {t1}:\n\nСреднее значение:\t\t";
                vals = new List<double>();

                foreach (var item in dict.Keys)
                    vals.Add(double.Parse(item.ToString()));

                text += $"{(!TryToGetAverage(vals, out a) ? "Не удалось вычислить" : GetF3(a))}\nМедиана:\t\t\t";
                text += $"{(!TryToGetMidian(vals, out a) ? "Не удалось вычислить" : GetF3(a))}\nДисперсия (в кв. ед.):\t\t";
                text += $"{(!TryToGetDispersion(vals, out a) ? "Не удалось вычислить" : GetF3(a))}\nСреднеквадратичное отклонение:\t";
                text += $"{(!TryToGetDispersion(vals, out a) ? "Не удалось вычислить" : GetF3(Math.Sqrt(a)))}";

                return text;
            }
            catch (Exception)
            {
                return "";
            }

        }


        /// <summary>
        /// Отдельный метод для форматирования, так как впихнуть форматирование в те строки, где метод используется, не получается.
        /// </summary>
        private string GetF3(double a)
        {
            return $"{a:f3}";
        }

        /// <summary>
        /// Получение среднего значения.
        /// </summary>
        private bool TryToGetAverage(List<double> a, out double aver)
        {
            try
            {
                aver = a.Average();
                return true;
            }
            catch (Exception)
            {
                aver = 0;
                return false;
            }
        }

        /// <summary>
        /// Получение медианы.
        /// </summary>
        private bool TryToGetMidian(List<double> a, out double med)
        {
            try
            {
                a.Sort();
                if (a.Count % 2 == 1)
                    med = a[a.Count / 2];
                else med = a[a.Count / 2] * 0.5 + a[a.Count / 2 - 1] * 0.5;
                return true;
            }
            catch (Exception)
            {
                med = 0;
                return false;
            }
        }

        /// <summary>
        /// Получение дисперсии.
        /// </summary>
        private bool TryToGetDispersion(List<double> a, out double disp)
        {
            try
            {
                disp = 0;
                if (a.Count == 0)
                    return false;

                double sum = 0;
                double average = a.Average();
                foreach (var item in a)
                    sum += Math.Pow(item - average, 2);

                disp = sum / a.Count;
                return true;
            }
            catch (Exception)
            {
                disp = 0;
                return false;
            }
        }

        #endregion

        #region Вспомогательные методы

        /// <summary>
        /// Метод изменения охвата значений.
        /// </summary>
        private void ChangeScale()
        {
            try
            {
                if (histDic == null)
                {
                    MessageBox.Show("Изменение спектра значений, охватываемых одним столбцом, возможно только для гистограммы частот.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                Dictionary<string, int> newHist = new Dictionary<string, int>();
                List<string> keys = new List<string>();
                List<int> values = new List<int>();

                foreach (var item in histDic)
                {
                    keys.Add(item.Key);
                    values.Add(item.Value);
                }
                int prev = 0, post = scale - 1;
                for (; post < keys.Count;)
                {
                    newHist.Add(prev != post ? keys[prev] + " - " + keys[post] : keys[prev], values.GetRange(prev, scale).Sum());
                    prev = post + 1;
                    post += scale;
                }
                if (prev != keys.Count)
                    newHist.Add(prev != keys.Count - 1 ? keys[prev] + " - " + keys[keys.Count - 1] : keys[prev].ToString(),
                        (int)values.GetRange(prev, keys.Count - prev).Sum());

                chart.Series[0] = new Series();
                chart.Series[0].Points.Clear();
                chart.ChartAreas[0].AxisX.CustomLabels.Clear();
                chart.ChartAreas[0].AxisY.CustomLabels.Clear();

                int i = 0;
                foreach (var item in newHist)
                {
                    chart.Series[0].Points.Add(item.Value);
                    chart.ChartAreas[0].AxisX.CustomLabels.Add(new CustomLabel(i, i + 2, item.Key, 0, LabelMarkStyle.LineSideMark));
                    i++;
                }

                chart.ChartAreas[0].AxisX.Title = names.Item1;
                chart.ChartAreas[0].AxisY.Title = names.Item2;
            }

            catch (Exception ex)
            {
                MessageBox.Show("При изменении охвата произошла ошибка: " + ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Проверка, является ли Ох у гистограммы числовым столбцом.
        /// </summary>
        private void ConvertToDoubleHistKeys(Dictionary<string, int> histDic)
        {
            try
            {
                isHistInt = false;
                List<Tuple<double, int>> tuples = new List<Tuple<double, int>>();
                foreach (var item in histDic)
                {
                    double key = 0;
                    if (!double.TryParse(item.Key, out key))
                        return;
                    tuples.Add(new Tuple<double, int>(key, item.Value));
                }
                tuples.Sort();
                histDic.Clear();
                foreach (var item in tuples)
                    histDic.Add(item.Item1.ToString(), item.Item2);
                isHistInt = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("При работе программы произошла ошибка: " + ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
