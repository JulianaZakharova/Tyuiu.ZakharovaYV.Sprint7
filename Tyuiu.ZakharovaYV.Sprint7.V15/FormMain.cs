using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Tyuiu.ZakharovaYV.Sprint7.V15.Lib;

namespace Tyuiu.ZakharovaYV.Sprint7.V15
{
    public partial class FormMain_ZYV : Form
    {
        public FormMain_ZYV()
        {
            InitializeComponent();
            output();
            sortirovka();
        }
        public BindingList<Dogovors> dogovorList;
        private SortOrder currentSortOrder = SortOrder.Ascending;
        DataService ds = new DataService();
        static string[,] arrayValues;
        string openFilePath;
        static int rows;

        public void output()
        {
            openFileDialog_ZYV.Filter = "Значения, разделенные запятыми(*.csv)|*.csv|Все файлы(*.*)|*.*";
            dataGridViewOut_ZYV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dogovorList = new BindingList<Dogovors>();

            this.chartFunction_ZYV.ChartAreas[0].AxisX.Title = "Шифр договора";
            this.chartFunction_ZYV.ChartAreas[0].AxisY.Title = "Сумма работ по договору";

            for (int i = 0; i < dataGridViewOut_ZYV.ColumnCount; i++)
            {
                dataGridViewOut_ZYV.Columns[i].ReadOnly = true;
            }
        }
        public void sortirovka()
        {
            comboBoxSort_ZYV.Items.AddRange(new string[] { "По умолчанию", "Шифр договора", "Наименование организации", "Адрес", "Телефон", "Сумма договора", "Срок работы по договору" });
            comboBoxSort_ZYV.SelectedIndex = 0;
        }
        public void saveFile() //////
        {
            saveFileDialogExcel_ZYV.FileName = "FileTask7.csv";
            saveFileDialogExcel_ZYV.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileDialogExcel_ZYV.ShowDialog();

            openFilePath = saveFileDialogExcel_ZYV.FileName;

            FileInfo fileInfo = new FileInfo(openFilePath);
            bool fileExists = fileInfo.Exists;
            if (fileExists)
            {
                File.Delete(openFilePath);
            }

            int rows = dataGridViewOut_ZYV.RowCount;
            int columns = dataGridViewOut_ZYV.ColumnCount;

            string str = "";
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if ((j != columns - 1) && dataGridViewOut_ZYV.Rows[i].Cells[j].Value != null)
                    {
                        str = str + dataGridViewOut_ZYV.Rows[i].Cells[j].Value + ";";
                    }
                    else
                    {
                        str = str + dataGridViewOut_ZYV.Rows[i].Cells[j].Value;
                    }
                }
                File.AppendAllText(openFilePath, str + Environment.NewLine, Encoding.Default);
                str = "";
            }
            for (int i = 0; i <= dataGridViewOut_ZYV.ColumnCount - 1; i++)
            {
                dataGridViewOut_ZYV.Columns[i].ReadOnly = true;
            }
        }

        private void buttonInfo_ZYV_Click(object sender, EventArgs e)
        {
            FormAbout formAbout = new FormAbout();
            formAbout.ShowDialog();
        }

        private void buttonHelp_ZYV_Click(object sender, EventArgs e)
        {
            FormInfo formInfo = new FormInfo();
            formInfo.ShowDialog();
        }

        private void buttonAdd_ZYV_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxAddName_ZYV.Text != "" && textBoxAddAdress_ZYV.Text != "" && textBoxAddPhon_ZYV.Text != "" && textBoxAddSum_ZYV.Text != "" && textBoxAddSrok_ZYV.Text != "")
                {
                    dogovorList.Add(new Dogovors
                    {
                        Shifr_Dogovora = Convert.ToInt32(textBoxAddShifr_ZYV.Text),
                        Name_Organizacii = textBoxAddName_ZYV.Text,
                        Adress = textBoxAddAdress_ZYV.Text,
                        Phone = textBoxAddPhon_ZYV.Text,
                        Summa_Dogovora = Convert.ToInt32(textBoxAddSum_ZYV.Text),
                        Srok_rabot_po_dogovoru = textBoxAddSrok_ZYV.Text
                    });
                    DialogResult result = MessageBox.Show("Рекомендуем пересохранить данные в файле!\nСохранить?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        saveFile();
                        statistiks();
                    }
                    textBoxAddShifr_ZYV.Text = "";
                    textBoxAddName_ZYV.Text = "";
                    textBoxAddAdress_ZYV.Text = "";
                    textBoxAddPhon_ZYV.Text = "";
                    textBoxAddSum_ZYV.Text = "";
                    textBoxAddSrok_ZYV.Text = "";
                }
            }
            catch
            {
                MessageBox.Show("Введены неверные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void statistiks()
        {
            chartFunction_ZYV.Series[0].Points.Clear();
            int rows = dataGridViewOut_ZYV.RowCount;

            for (int i = 0; i < rows - 1; i++)
            {
                chartFunction_ZYV.Series[0].Points.AddXY(dataGridViewOut_ZYV.Rows[i].Cells[0].Value, dataGridViewOut_ZYV.Rows[i].Cells[4].Value);
            }
            textBoxCount_ZYV.Text = ds.Count(openFilePath).ToString();
            textBoxSumm_ZYV.Text = ds.Sum(openFilePath).ToString();
            textBoxSr_ZYV.Text = ds.Srednee(openFilePath).ToString();
            textBoxMinValue_ZYV.Text = ds.Min(openFilePath).ToString();
            textBoxMaxValue_ZYV.Text = ds.Max(openFilePath).ToString();

        }

        private void buttonChange_ZYV_Click(object sender, EventArgs e)
        {

            for (int i = 0; i <= dataGridViewOut_ZYV.ColumnCount - 1; i++)
            {
                dataGridViewOut_ZYV.Columns[i].ReadOnly = false;
            }
            MessageBox.Show("После редактирования необходимо пересохранить данные в файле", "Сообщение");
        }

        private void buttonSaveFile_ZYV_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Сохранить данные в файл?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    saveFile();
                    statistiks();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка сохранения файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxPoisk_ZYV_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPoisk_ZYV.Text.Trim() == "")
            {
                dataGridViewOut_ZYV.DataSource = dogovorList;
            }
            else
            {
                dataGridViewOut_ZYV.DataSource = new BindingList<Dogovors>(dogovorList.Where(staff =>
                    staff.Shifr_Dogovora.ToString().Contains(textBoxPoisk_ZYV.Text) ||
                    staff.Name_Organizacii.ToString().Contains(textBoxPoisk_ZYV.Text) ||
                    staff.Adress.ToString().Contains(textBoxPoisk_ZYV.Text) ||
                    staff.Phone.ToString().Contains(textBoxPoisk_ZYV.Text) ||
                    staff.Summa_Dogovora.ToString().Contains(textBoxPoisk_ZYV.Text) ||
                    staff.Srok_rabot_po_dogovoru.ToString().Contains(textBoxPoisk_ZYV.Text)
                ).ToList());
            }
        }

        private void comboBoxSort_ZYV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentSortOrder == SortOrder.Ascending)
            {
                switch (comboBoxSort_ZYV.SelectedIndex)
                {
                    case 0:
                        dogovorList = new BindingList<Dogovors>(dogovorList.OrderBy(x => x.Shifr_Dogovora).ToList());
                        currentSortOrder = SortOrder.Descending;
                        break;
                    case 1:
                        dogovorList = new BindingList<Dogovors>(dogovorList.OrderBy(x => x.Shifr_Dogovora).ToList());
                        currentSortOrder = SortOrder.Descending;
                        break;
                    case 2:
                        dogovorList = new BindingList<Dogovors>(dogovorList.OrderBy(x => x.Name_Organizacii).ToList());
                        currentSortOrder = SortOrder.Descending;
                        break;
                    case 3:
                        dogovorList = new BindingList<Dogovors>(dogovorList.OrderBy(x => x.Adress).ToList());
                        currentSortOrder = SortOrder.Descending;
                        break;
                    case 4:
                        dogovorList = new BindingList<Dogovors>(dogovorList.OrderBy(x => x.Phone).ToList());
                        currentSortOrder = SortOrder.Descending;
                        break;
                    case 5:
                        dogovorList = new BindingList<Dogovors>(dogovorList.OrderBy(x => x.Summa_Dogovora).ToList());
                        currentSortOrder = SortOrder.Descending;
                        break;
                    case 6:
                        dogovorList = new BindingList<Dogovors>(dogovorList.OrderBy(x => x.Srok_rabot_po_dogovoru).ToList());
                        currentSortOrder = SortOrder.Descending;
                        break;
                }
            }
            else
            {
                switch (comboBoxSort_ZYV.SelectedIndex)
                {
                    case 0:
                        dogovorList = new BindingList<Dogovors>(dogovorList.OrderByDescending(x => x.Shifr_Dogovora).ToList());
                        currentSortOrder = SortOrder.Ascending;
                        break;
                    case 1:
                        dogovorList = new BindingList<Dogovors>(dogovorList.OrderByDescending(x => x.Shifr_Dogovora).ToList());
                        currentSortOrder = SortOrder.Ascending;
                        break;
                    case 2:
                        dogovorList = new BindingList<Dogovors>(dogovorList.OrderByDescending(x => x.Name_Organizacii).ToList());
                        currentSortOrder = SortOrder.Ascending;
                        break;
                    case 3:
                        dogovorList = new BindingList<Dogovors>(dogovorList.OrderByDescending(x => x.Adress).ToList());
                        currentSortOrder = SortOrder.Ascending;
                        break;
                    case 4:
                        dogovorList = new BindingList<Dogovors>(dogovorList.OrderByDescending(x => x.Phone).ToList());
                        currentSortOrder = SortOrder.Ascending;
                        break;
                    case 5:
                        dogovorList = new BindingList<Dogovors>(dogovorList.OrderByDescending(x => x.Summa_Dogovora).ToList());
                        currentSortOrder = SortOrder.Ascending;
                        break;
                    case 6:
                        dogovorList = new BindingList<Dogovors>(dogovorList.OrderByDescending(x => x.Srok_rabot_po_dogovoru).ToList());
                        currentSortOrder = SortOrder.Ascending;
                        break;
                }
            }

            dataGridViewOut_ZYV.DataSource = dogovorList;
        }

        private void buttonOpenFile_ZYV_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog_ZYV.ShowDialog();
                openFilePath = openFileDialog_ZYV.FileName;
                arrayValues = ds.LoadFromFileData(openFilePath);

                dataGridViewOut_ZYV.Rows.Clear();


                rows = arrayValues.GetUpperBound(0) + 1;
                for (int i = 0; i < rows; i++)
                {
                    dogovorList.Add(new Dogovors
                    {
                        Shifr_Dogovora = Convert.ToInt32(arrayValues[i, 0]),
                        Name_Organizacii = arrayValues[i, 1],
                        Adress = arrayValues[i, 2],
                        Phone = arrayValues[i, 3],
                        Summa_Dogovora = Convert.ToInt32(arrayValues[i, 4]),
                        Srok_rabot_po_dogovoru = arrayValues[i, 5]
                    });
                }
                dataGridViewOut_ZYV.DataSource = dogovorList;
                statistiks();

                buttonSaveFile_ZYV.Enabled = true;
                buttonChange_ZYV.Enabled = true;
                buttonAdd_ZYV.Enabled = true;
                comboBoxSort_ZYV.Enabled = true;
                textBoxPoisk_ZYV.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Ошибка чтения файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
