using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;
using System.Diagnostics;

namespace CSVManager
{
    public partial class MainForm : Form
    {

        #region Загрузка и данные

        string fullpath = "";

        public MainForm()
        {
            InitializeComponent();
            tsmiOpen.Click += TsmiOpen_Click;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            ReadData(fullpath);
        }


        #endregion

        #region Кнопки графиков

        /// <summary>
        /// Создание гистограммы.
        /// </summary>
        private void btnOneHist_Click(object sender, EventArgs e)
        {
            try
            {
                if (cBoxSelectedColumn.SelectedIndex < 0 || cBoxSelectedColumn.SelectedIndex >= dataGridView.Columns.Count)
                { MessageBox.Show("Выбранный столбец не подходит для построения гистограммы", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

                int i = cBoxSelectedColumn.SelectedIndex;
                DataGridViewColumn col = dataGridView.Columns[cBoxSelectedColumn.SelectedIndex];
                Dictionary<string, int> dick = new Dictionary<string, int>();
                for (int j = 0; j < dataGridView.RowCount; j++)
                    if (dataGridView[i, j].Value != null && dataGridView[i, j].Value.ToString() != string.Empty)
                        if (dick.ContainsKey(dataGridView[i, j].Value.ToString()))
                            dick[dataGridView[i, j].Value.ToString()]++;
                        else dick.Add(dataGridView[i, j].Value.ToString(), 1);

                ChartForm histForm = new ChartForm();
                histForm.histDic = dick;
                histForm.names = new Tuple<string, string>(cBoxSelectedColumn.SelectedItem.ToString(), "Частота встречаемости");
                histForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("При построении гистограммы произошла ошибка: " + ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Создание графика зависимости.
        /// </summary>
        private void btnGraph_Click(object sender, EventArgs e)
        {
            try
            {
                if (cBoxSelectedColumn1.SelectedIndex < 0 || cBoxSelectedColumn1.SelectedIndex >= dataGridView.Columns.Count || cBoxSelectedColumn2.SelectedIndex < 0 || cBoxSelectedColumn2.SelectedIndex >= dataGridView.Columns.Count)
                { MessageBox.Show("Выбранные столбцы не подходят для построения графика зависимости", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

                int ind1 = cBoxSelectedColumn1.SelectedIndex;
                int ind2 = cBoxSelectedColumn2.SelectedIndex;
                DataGridViewColumn col1 = dataGridView.Columns[cBoxSelectedColumn1.SelectedIndex];
                DataGridViewColumn col2 = dataGridView.Columns[cBoxSelectedColumn2.SelectedIndex];

                Dictionary<double, double> dick = new Dictionary<double, double>();

                for (int j = 0; j < dataGridView.RowCount; j++)
                {
                    if (dataGridView[ind1, j].Value == null && dataGridView[ind2, j].Value == null)
                        continue;
                    if (dataGridView[ind1, j].Value != null && double.TryParse(dataGridView[ind1, j].Value.ToString(), out double val1) &&
                        dataGridView[ind2, j].Value != null && double.TryParse(dataGridView[ind2, j].Value.ToString(), out double val2))
                        if (dick.ContainsKey(val1))
                            dick[val1] = val2;
                        else dick.Add(val1, val2);
                    else
                    {
                        MessageBox.Show("Данные в выбранных столбцах не являются числовыми и не подходят для построения данного графика." +
                          $" Проверьте ячейку [{(dataGridView[ind1, j].Value != null && !double.TryParse(dataGridView[ind1, j].Value.ToString(), out val1) ? ind1 + 1 : ind2 + 1)}, " +
                          $"{j + 1}]", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
                    }
                }


                ChartForm graphForm = new ChartForm();
                graphForm.graphDic = dick;
                graphForm.names = new Tuple<string, string>(cBoxSelectedColumn1.SelectedItem.ToString(), cBoxSelectedColumn2.SelectedItem.ToString());
                graphForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("При построении графика произошла ошибка: " + ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        /// <summary>
        /// Создание диаграммы диапозона.
        /// </summary>
        private void btnRange_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView.SelectedCells == null || dataGridView.SelectedCells.Count == 0)
                { MessageBox.Show("Необходимо сначала выделить ячейки мышкой, а затем нажать на эту кнопку.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }


                List<Dictionary<string, double>> dick = new List<Dictionary<string, double>>();

                Dictionary<string, double> curRowDic = new Dictionary<string, double>();

                List<DataGridViewCell> selectedCells = new List<DataGridViewCell>();
                foreach (DataGridViewCell item in dataGridView.SelectedCells)
                    selectedCells.Add(item);

                selectedCells.Sort((x, y) => x.RowIndex.CompareTo(y.RowIndex));

                for (int i = 0; i < selectedCells.Count; i++)
                    for (int j = i; j < selectedCells.Count; j++)
                        if (selectedCells[i].RowIndex == selectedCells[j].RowIndex && selectedCells[i].ColumnIndex > selectedCells[j].ColumnIndex)
                        {
                            var tr = selectedCells[i];
                            selectedCells[i] = selectedCells[j];
                            selectedCells[j] = tr;
                        }



                //selectedCells.Sort((x, y) => { if (x.RowIndex == y.RowIndex) return x.ColumnIndex.CompareTo(y.ColumnIndex); else return 0; });

                if (!SquareCheck(selectedCells))
                { MessageBox.Show("Необходимо выбрать ячейки так, чтобы они соответствовали некоему прямоугольнику, если их совместить. Необходимо выбрать также минимум два столбца, так как самый левый столбец является столбцом подписей.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }



                List<string> legendNames = new List<string>();

                int previ = selectedCells[0].ColumnIndex, left = previ;
                for (int cell = 0; cell < selectedCells.Count; cell++)
                {
                    int i = selectedCells[cell].ColumnIndex;
                    int j = selectedCells[cell].RowIndex;

                    if (i == left)
                    {
                        if (dataGridView[i, j].Value != null && dataGridView[i, j].Value.ToString().Trim() != string.Empty)
                            legendNames.Add(dataGridView[i, j].Value.ToString());
                        else
                        {
                            MessageBox.Show("Данные для подписей в выбранных столбцах не подходят для построения данной диаграммы." +
                          $"\nПроверьте ячейку [{i + 1}, {j + 1}]", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
                        }
                        continue;
                    }

                    if (previ >= i && cell > 0)
                    {
                        dick.Add(curRowDic);
                        curRowDic = new Dictionary<string, double>();
                    }
                    if (dataGridView[i, j].Value == null || !double.TryParse(dataGridView[i, j].Value.ToString(), out double val))
                    {
                        MessageBox.Show("Данные в выбранных столбцах не являются числовыми/не содержат корректных числовых значений и не подходят для построения данной диаграммы." +
                      $"\nПроверьте ячейку [{i + 1}, {j + 1}]", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
                    }
                    if (curRowDic.ContainsKey(dataGridView.Columns[i].Name))
                        curRowDic[dataGridView.Columns[i].Name] = val;
                    else curRowDic.Add(dataGridView.Columns[i].Name, val);

                    previ = i;
                }
                dick.Add(curRowDic);


                ChartForm rangeForm = new ChartForm();
                rangeForm.diagDic = dick;
                rangeForm.legendNames = legendNames;
                rangeForm.names = new Tuple<string, string>("Столбцы", "Значения");
                rangeForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("При построении графика произошла ошибка: " + ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Чтение CSV файлов


        /// <summary>
        /// Выбор файла для чтения.
        /// </summary>
        private void TsmiOpen_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "CSV files(*.csv)|*.csv";
                if (openFileDialog.ShowDialog() == DialogResult.Cancel || !openFileDialog.FileName.Contains(".csv"))
                    return;

                fullpath = openFileDialog.FileName;
                lblHeader.Text = Path.GetFileName(fullpath);

                ReadData(fullpath);
            }
            catch (IOException ex)
            {
                MessageBox.Show("Возникла ошибка при работе с файлом: " + ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Неизвестная ошибка: " + ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Конвертация csv файла в datagridview.
        /// </summary>
        public void ReadData(string fileName, bool firstRowContainsFieldNames = true)
        {
            try
            {
                if (fileName == "")
                    return;
                dataGridView.Rows.Clear();
                dataGridView.Columns.Clear();
                cBoxSelectedColumn.Items.Clear();
                cBoxSelectedColumn1.Items.Clear();
                cBoxSelectedColumn2.Items.Clear();

                using (TextFieldParser tfp = new TextFieldParser(fileName))
                {
                    tfp.SetDelimiters(",");

                    if (!tfp.EndOfData)
                    {
                        string[] fields = tfp.ReadFields();

                        for (int i = 0; i < fields.Count(); i++)
                        {
                            if (firstRowContainsFieldNames)
                                dataGridView.Columns.Add(fields[i], fields[i]);
                            else
                                dataGridView.Columns.Add("", "");
                        }

                        if (!firstRowContainsFieldNames)
                            dataGridView.Rows.Add(fields);
                    }

                    while (!tfp.EndOfData)
                        dataGridView.Rows.Add(tfp.ReadFields());

                }

                foreach (DataGridViewColumn item in dataGridView.Columns)
                {
                    cBoxSelectedColumn.Items.Add(item.Name);
                    cBoxSelectedColumn1.Items.Add(item.Name);
                    cBoxSelectedColumn2.Items.Add(item.Name);
                }

                if (dataGridView.Columns.Count > 0)
                {
                    cBoxSelectedColumn.SelectedIndex = 0;
                    cBoxSelectedColumn1.SelectedIndex = 0;
                    cBoxSelectedColumn2.SelectedIndex = 0;
                }
                if (dataGridView.Columns.Count > 1)
                    cBoxSelectedColumn2.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("При чтении файла произошла ошибка: " + ex.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Вспомогательные методы

        /// <summary>
        /// Проверка корректности выделенного диапозона для диаграммы.
        /// </summary>
        private bool SquareCheck(List<DataGridViewCell> b)
        {
            try
            {
                List<DataGridViewCell> a = new List<DataGridViewCell>(b);
                int minR = int.MaxValue;
                int maxR = int.MinValue;
                int minC = int.MaxValue;
                int maxC = int.MinValue;
                foreach (var item in a)
                {
                    maxR = Math.Max(maxR, item.RowIndex);
                    maxC = Math.Max(maxC, item.ColumnIndex);
                    minR = Math.Min(minR, item.RowIndex);
                    minC = Math.Min(minC, item.ColumnIndex);
                }
                bool[,] check = new bool[maxR - minR + 1, maxC - minC + 1];
                foreach (var item in a)
                    check[item.RowIndex - minR, item.ColumnIndex - minC] = true;

                if (minC >= maxC)
                    return false;

                for (int i = 0; i < check.GetLength(0); i++)
                    for (int j = 0; j < check.GetLength(1); j++)
                        if (check[i, j])
                            for (int k = 0; k < check.GetLength(0); k++)
                                if (!check[k, j])
                                    for (int l = 0; l < check.GetLength(1); l++)
                                        if (check[k, l])
                                            return false;

                return true;
            }
            catch (Exception) { return false; }


        }

        /// <summary>
        /// Сообщение справки.
        /// </summary>
        private void tsmiHelp_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(File.ReadAllText("Help.txt"), "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("При выводе справки возникла ошибка. Скорее всего, что-то не так с файлом Help.txt в папке" +
                    " с исполняемым модулем. " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        
        
        //private void DebugWriteArr(bool[,] a)
        //{
        //    for (int i = 0; i < a.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < a.GetLength(1); j++)
        //            Debug.Write(a[i, j] ? "1 " : "0 ");
        //        Debug.WriteLine("");
        //    }
        //    Debug.WriteLine("");
        //}        

        //public DataGridViewColumn FindColumn(string name)
        //{
        //    foreach (DataGridViewColumn item in dataGridView.Columns)
        //        if (item.Name == name)
        //            return item;
        //    return null;
        //} 

        #endregion

    }
}
