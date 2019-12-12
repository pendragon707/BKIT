using L5;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace DZ
{
    public partial class Form1 : Form
    {
        public int LenCol { get; set; }
        public int CountItemsUp { get; set; }
        private Stopwatch stopwatchwork;
        private string ResultTimeStrim;
        public static List<MyEventThreadFind> ItemListAdd { get; set; }
        private MyThreadFind[] ListThreadFind = new MyThreadFind[0];
        private List<string> words;
        public delegate ShearchItemClass ShearhFunction(string firstText, string secondText); //какой алгоритм использовать
        public ShearhFunction ShearhFunc = null;

        public Form1()
        {
            InitializeComponent();
            FindType.SelectedIndex = 0;
            LenCol = 30;
        }

        private void FindGo_Click(object sender, EventArgs e)
        {
            if (words == null) return;
            timer1.Stop();
            stopwatchwork = new Stopwatch();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = words.Count + 1;
            progressBar1.Value = 0;
            progressBar1.Visible = true;

            int len = 0;
            LenCol = 50;
            CountItemsUp = 0;

            stopwatchwork.Start();

            ListData.BeginUpdate();
            ListData.Items.Clear();
            ItemListAdd.Clear();
            ResultTimeStrim = "";
            //ItemListStop.Clear();

            string substring = FindText.Text.ToLower();

            if (FindType.SelectedIndex > 2)
            {
                int k = Convert.ToInt32(NumStream.Text);
                int Lenght = words.Count / k;

                int CountThread = 0;

                Array.Resize(ref ListThreadFind, k);
                Array.Clear(ListThreadFind, 0, k);

                for (int i = 0; i < words.Count; i = i + Lenght)
                {
                    if (((words.Count - i) % (k - CountThread)) == 0) Lenght = ((words.Count - i) / (k - CountThread));
                    ListThreadFind[CountThread] = new MyThreadFind();

                    ListThreadFind[CountThread].OneShearchAddNow += OneShearchAddOk;
                    ListThreadFind[CountThread].ShearchCompletedNow += ShearchCompletedNow;
                    ListThreadFind[CountThread].NameThread = " Stream - " + CountThread;
                    if (CountThread == k - 1) Lenght = words.Count - i;
                    LogTextBox.AppendText(ListThreadFind[CountThread].NameThread + " c " + i + " по " + (i + Lenght - 1) + " в потоке " + Lenght + " элементов \r\n");
                    ListThreadFind[CountThread].MyThreadIni(words, i, Lenght, substring, FindType.SelectedIndex - 3, Convert.ToInt32(Distance.Text));

                    CountThread++;
                }

                CountThread--;
                timer2.Tag = 0; // счетчик переноса в ListBox
                timer2.Start();
            }
            else
            {
                switch (FindType.SelectedIndex)
                {
                    case 0:
                        ShearhFunc = new ShearhFunction(L5.LevenshteinDistance.StrContains);
                        break;
                    case 1:
                        ShearhFunc = new ShearhFunction(L5.LevenshteinDistance.WagnweFisher);
                        break;
                    case 2:
                        ShearhFunc = new ShearhFunction(L5.LevenshteinDistance.DamerauLevenshteinDistance);
                        break;
                    default:
                        break;
                }
                foreach (string s in words)
                {
                    ShearchItemClass ShearchItem = ShearhFunc(s, substring);
                    if (ShearchItem.Distance <= Convert.ToInt32(Distance.Text))
                    {
                        ShearchItem.IndexItem = progressBar1.Value;
                        len = TextRenderer.MeasureText((ListData.Items[ListData.Items.Add(ShearchItem)] as ShearchItemClass).ShearchString, ListData.Font).Width;
                        if (LenCol < len) LenCol = len + 10;
                    }
                    progressBar1.Value++;
                }
                progressBar1.Value = progressBar1.Maximum;
                stopwatchwork.Stop();

                TimeWorkStr.Text = "Время поиска " + stopwatchwork.ElapsedMilliseconds + " ms";
                timer1.Start();
            }
            if ((FindType.SelectedIndex == 2) || (FindType.SelectedIndex == 5))
                ListData.Items.Insert(0, "Строка , Редакционное предписание ,  Номер");
            else
                ListData.Items.Insert(0, "Строка ,    ,  Номер");
            ListData.EndUpdate();

        }

        public void OneShearchAddOk(MyEventThreadFind c)
        {
            if (c is MyEventThreadFind)
            {
                ItemListAdd.Add(c);
                CountItemsUp = CountItemsUp + c.CountUp;
            }
        }

        public void ShearchCompletedNow(List<ShearchItemClass> ShearchItemList, MyEventThreadFind c)
        {
            CountItemsUp = CountItemsUp + c.CountUp;
            if (c.EndWork)
            {
                ResultTimeStrim = ResultTimeStrim + c.NameThread + " время работы потока - " + c.TimeWork + " мс \r\n";
            }
        }

        private void OpenFilebt_Click(object sender, EventArgs e)
        {
            FindText.Text = "";

            OpenFileDialog dialog = new OpenFileDialog
            {
                InitialDirectory = Application.CommonAppDataPath,
                Filter = "Text files|*.txt|All files|*.*"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                words = new List<string>();
                words.Clear();
                ItemListAdd = new List<MyEventThreadFind>();
                ItemListAdd.Clear();


                NameFileStr.Text = "Открываем файл.. " + dialog.FileName;
                TextFileName.Text = dialog.FileName;
                Stopwatch sw = new Stopwatch();
                sw.Start();
                progressBar1.Minimum = 0;
                FileInfo fileInf = new FileInfo(dialog.FileName);
                progressBar1.Maximum = Convert.ToInt32(fileInf.Length) * 2;
                progressBar1.Value = 0;
                progressBar1.Visible = true;

                foreach (string s in File.ReadAllText(dialog.FileName, Encoding.ASCII).Split(' ', '\t', '!', '?', ',', '-', '.', ':', '\r', '\n'))
                {
                    if (!String.IsNullOrEmpty(s))
                    {
                        string lowercase = s.ToLower();
                        if (!words.Contains(lowercase)) words.Add(lowercase);
                        progressBar1.Value = progressBar1.Value + Encoding.ASCII.GetBytes(lowercase).Length;

                    }
                }

                FindGo_Click(this, new EventArgs());
                progressBar1.Value = progressBar1.Maximum;
                sw.Stop();
                NameFileStr.Text = "Открыт файл.. " + dialog.FileName;
                TimeWorkStr.Text = "Время открытия файла " + sw.ElapsedMilliseconds + " ms";

                timer1.Start();

            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            timer1.Stop();
        }

        private void FindText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.None && (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return))
                FindGo_Click(this, new EventArgs());
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if ((int)timer2.Tag == ItemListAdd.Count)
            {
                int k = 0;
                for (int i = 0; i < ListThreadFind.Length; i++)
                    if (((ListThreadFind[i] is MyThreadFind) && (ListThreadFind[i].EndWork)) || (ListThreadFind[i] == null)) k++;
                LogTextBox.AppendText(" работают-" + (ListThreadFind.Length - k) + " потоков\r\n");
                if (k == ListThreadFind.Length)
                {
                    stopwatchwork.Stop();
                    timer1.Start(); // запускаем таймер для сокрытия прогрессбара
                    timer2.Stop(); // останавливаем таймер переноса данных в лист бокс
                    TimeWorkStr.Text = "Время поиска " + stopwatchwork.ElapsedMilliseconds + " ms";
                    for (int i = 0; i < ItemListAdd.Count; i++)
                    {
                        if (ItemListAdd[i] is MyEventThreadFind)
                            LogTextBox.AppendText("№" + i + "   " + ItemListAdd[i].ShearchItem + "  Stream - " + ItemListAdd[i].NameThread + "\r\n");
                    }
                    LogTextBox.AppendText(ResultTimeStrim);
                    File.WriteAllText(LogFileName.Text, LogTextBox.Text);
                    ItemListAdd.Clear();
                }
            }
            if (!((ItemListAdd.Count == 0) || (ItemListAdd.Count == (int)timer2.Tag)))
            {
                MyEventThreadFind c = ItemListAdd[(int)timer2.Tag];
                if (c is MyEventThreadFind)
                {
                    int len = TextRenderer.MeasureText(c.ShearchItem.ShearchString, ListData.Font).Width;
                    if (LenCol < len) LenCol = len + 10;

                    if ((int)timer2.Tag == 0)
                    {
                        ListData.Items.Add(c.ShearchItem);
                    }
                    else
                    {
                        bool insertOk = false;
                        for (int i = 0; i < ListData.Items.Count; i++)
                        {
                            if ((ListData.Items[i] is ShearchItemClass) && (ListData.Items[i] as ShearchItemClass).IndexItem > c.IndexNow)
                            {
                                ListData.Items.Insert(i, c.ShearchItem);
                                // if (c.NameThread == " Stream - 10") 
                                LogTextBox.AppendText(c.NameThread + " insert -  " + c.ShearchItem + "\r\n");
                                insertOk = true;
                                break;
                            }
                        }
                        if (!insertOk)
                        {
                            ListData.Items.Add(c.ShearchItem);
                            //if (c.NameThread == " Stream - 10")
                            LogTextBox.AppendText(c.NameThread + " Add -  " + c.ShearchItem + "\r\n");
                        }
                    }
                }

                timer2.Tag = (int)timer2.Tag + 1;
                if (CountItemsUp == 0) progressBar1.Value = progressBar1.Maximum;
                else progressBar1.Value = progressBar1.Value + CountItemsUp;
                CountItemsUp = 0;

            }

        }

        private void ListData_Click(object sender, EventArgs e)
        {
            int m = FindText.Text.Length;
            if ((ListData.Items.Count > 0) && (ListData.SelectedItem is ShearchItemClass) && (m > 0))
            {
                ListData.Width = 350;

                m++;
                int n = (ListData.SelectedItem as ShearchItemClass).ShearchString.Length + 2;


                DistMatrix.ColumnCount = n;
                DistMatrix.RowCount = m;
                int k = 0;

                for (var i = 1; i < n; i++)
                {
                    DistMatrix[i, 0].Value = i - 1;
                    if (i < (n - 1)) { DistMatrix.Columns[i + 1].Name = " " + (ListData.SelectedItem as ShearchItemClass).ShearchString[i - 1]; }
                    //else ArrayView1.Columns[i].Name = " ";

                }

                for (var j = 0; j < m; j++)
                {
                    DistMatrix[1, j].Value = j;
                    if (j < (m - 1)) DistMatrix[0, j + 1].Value = " " + FindText.Text[j];
                }


                for (var i = 2; i < n; i++)
                {
                    for (var j = 1; j < m; j++)
                    {
                        if (btPrescript.Text == "Предписание")
                            DistMatrix[i, j].Value = (ListData.SelectedItem as ShearchItemClass).ArrayPrescript[k];
                        else
                            DistMatrix[i, j].Value = (ListData.SelectedItem as ShearchItemClass).ArrayGrid[k];
                        k++;
                    }
                }
            }
        }

        private void btPrescript_Click(object sender, EventArgs e)
        {
            if (btPrescript.Text == "Предписание") btPrescript.Text = "Алгоритм";
            else btPrescript.Text = "Предписание";

            ListData_Click(ListData, new EventArgs());
        }

        private void ListData_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            string currName = ListData.Items[e.Index].ToString();

            string[] s = currName.Split(',');

            if (s.Length > 0)
            {
                System.Drawing.Pen skyPen =
                                       new System.Drawing.Pen(e.ForeColor);//System.Drawing.Brushes.Black);

                System.Drawing.SolidBrush shadowBrush =
                                       new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(255, System.Drawing.Color.Black)); //e.ForeColor));//
                e.Graphics.DrawString(s[0], e.Font, shadowBrush, new System.Drawing.PointF(e.Bounds.X, e.Bounds.Y - 2));
                if (s.Length > 1)
                {
                    e.Graphics.DrawLine(skyPen, LenCol, e.Bounds.Top, LenCol, e.Bounds.Bottom);
                    e.Graphics.DrawString(s[1], e.Font, shadowBrush, new System.Drawing.PointF(e.Bounds.X + LenCol + 10, e.Bounds.Y - 2));
                }
                if (s.Length > 2)
                {
                    e.Graphics.DrawLine(skyPen, e.Bounds.Width - LenCol * 2, e.Bounds.Top, e.Bounds.Width - LenCol * 2, e.Bounds.Bottom);
                    e.Graphics.DrawString(s[2], e.Font, shadowBrush, new System.Drawing.PointF(e.Bounds.Width - LenCol, e.Bounds.Y - 2));
                }
            }



        }


        private void Distance_TextChanged(object sender, EventArgs e)
        {
            if (sender is DomainUpDown)
            {
                DomainUpDown t = (sender as DomainUpDown);
                try
                {
                    t.Tag = Convert.ToInt32(t.Text);
                    t.ForeColor = Color.Black;
                    t.Tag = t.Text;
                    t.Refresh();
                }
                catch
                {
                    //t.ForeColor = Color.Red;
                    t.Text = (string)t.Tag;
                    t.Refresh();
                }
            }

        }

        private void FileLogbt_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                InitialDirectory = Application.CommonAppDataPath,
                Filter = "Text files|*.txt|All files|*.*"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LogFileName.Text = dialog.FileName;

            }
        }
    }
    public class MyEventThreadFind
    {
        public string NameThread { get; set; } //имя потока
        public Thread MyThread { get; set; } // ссылка на класс многопоточности
        public int Lenght { get; set; } // элементов в очереди
        public int First { get; set; } // первый элемент в очереди
        public int IndexNow { get; set; }
        public int CountUp { get; set; } // обработано до первого найденого
        public long TimeWork { get; set; } // время работы
        public bool EndWork { get; set; } // признак поток стоп
        public ShearchItemClass ShearchItem { get; set; }
    }

    public class MyThreadFind
    {
        public string NameThread { get; set; }  //имя потока
        public string ShearchString { get; set; }  // строка для поиска
        public decimal Distance { get; set; }  // условие поиска
        public int Lenght { get; set; }  // обработать элнмнгтов в этом потоке
        public int First { get; set; } // первый обрабатываемый эдемент
        public bool EndWork { get; set; } // признак поток стоп
        public List<string> ArrayShearch { get; set; } // массив элементов для обработки
        public List<ShearchItemClass> ResultList = new List<ShearchItemClass>();  // список удовлетворяющих поиску элиментов

        public delegate ShearchItemClass ShearhFunction(string firstText, string secondText); //какой алгоритм использовать
        public ShearhFunction ShearhFunc = null;

        public delegate void OneShearchAdd(MyEventThreadFind c);  // выполняется при нахождении каждого удовлетворяющего элемента
        public OneShearchAdd OneShearchAddNow = null;

        public delegate void ShearchCompleted(List<ShearchItemClass> ShearchItemList, MyEventThreadFind c); // выполняется после обработки всех элиментов
        public ShearchCompleted ShearchCompletedNow = null;
        //  private MyEventThreadFind c;

        private Thread MyThread { get; set; }  // класс многопоточности
        public string MyThreadIni(List<string> ArrayShearch, int First, int Lenght, string ShearchString, int ShearchType, decimal Distance)
        {
            this.ArrayShearch = ArrayShearch;
            this.First = First;
            this.Lenght = Lenght;
            this.ShearchString = ShearchString;
            this.Distance = Distance;

            switch (ShearchType)
            {
                case 0:
                    ShearhFunc = new ShearhFunction(L5.LevenshteinDistance.StrContains);
                    break;
                case 1:
                    ShearhFunc = new ShearhFunction(L5.LevenshteinDistance.WagnweFisher);
                    break;
                case 2:
                    ShearhFunc = new ShearhFunction(L5.LevenshteinDistance.DamerauLevenshteinDistance);
                    break;
                default:
                    break;
            }
            MyThread = new Thread(ShearchStart);
            MyThread.Name = NameThread;
            MyThread.Start();
            return MyThread.Name;

        }
        private void ShearchStart()
        {
            int EndItem = First + Lenght;
            //int CountUp = 0;
            MyEventThreadFind e = new MyEventThreadFind();
            e.NameThread = NameThread;
            e.Lenght = Lenght;
            e.First = First;
            e.EndWork = false;
            EndWork = false;
            e.CountUp = 0;
            e.TimeWork = 0;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            if (EndItem > ArrayShearch.Count) EndItem = ArrayShearch.Count;
            for (int i = First; i < EndItem; i++)
            {
                int k = i;
                string s = ArrayShearch[k];

                ShearchItemClass ShearchItem = ShearhFunc(s, ShearchString);
                e.CountUp++;
                if (ShearchItem.Distance <= Distance)
                {
                    ShearchItem.IndexItem = k;
                    ResultList.Add(ShearchItem);
                    e.TimeWork = sw.ElapsedMilliseconds;
                    e.ShearchItem = ShearchItem;
                    e.IndexNow = k;
                    MyEventThreadFind cc = new MyEventThreadFind();


                    cc.EndWork = e.EndWork;
                    cc.First = e.First;
                    cc.IndexNow = e.IndexNow;
                    cc.Lenght = e.Lenght;
                    cc.MyThread = e.MyThread;
                    cc.NameThread = e.NameThread;
                    cc.ShearchItem = e.ShearchItem;
                    cc.TimeWork = e.TimeWork;
                    cc.CountUp = e.CountUp;

                    OneShearchAddNow?.Invoke(cc);
                    e.CountUp = 0;
                    Thread.Sleep(20);
                }
            }
            sw.Stop();
            e.TimeWork = sw.ElapsedMilliseconds;
            e.EndWork = true;
            EndWork = true;
            ShearchCompletedNow?.Invoke(ResultList, e);
            Thread.Sleep(100);
        }

    }
}
