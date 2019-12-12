namespace DZ
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.LogFileName = new System.Windows.Forms.TextBox();
            this.NumStream = new System.Windows.Forms.DomainUpDown();
            this.FindType = new System.Windows.Forms.ComboBox();
            this.Distance = new System.Windows.Forms.DomainUpDown();
            this.FindText = new System.Windows.Forms.TextBox();
            this.FindGo = new System.Windows.Forms.Button();
            this.FileLogbt = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TextFileName = new System.Windows.Forms.TextBox();
            this.OpenFilebt = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btPrescript = new System.Windows.Forms.Button();
            this.DistMatrix = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.NameFileStr = new System.Windows.Forms.ToolStripStatusLabel();
            this.TimeWorkStr = new System.Windows.Forms.ToolStripStatusLabel();
            this.ListData = new System.Windows.Forms.ListBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DistMatrix)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(575, 468);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.LogTextBox);
            this.tabPage1.Controls.Add(this.LogFileName);
            this.tabPage1.Controls.Add(this.NumStream);
            this.tabPage1.Controls.Add(this.FindType);
            this.tabPage1.Controls.Add(this.Distance);
            this.tabPage1.Controls.Add(this.FindText);
            this.tabPage1.Controls.Add(this.FindGo);
            this.tabPage1.Controls.Add(this.FileLogbt);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.TextFileName);
            this.tabPage1.Controls.Add(this.OpenFilebt);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(567, 439);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Параметры поиска :";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // LogTextBox
            // 
            this.LogTextBox.Location = new System.Drawing.Point(15, 219);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.Size = new System.Drawing.Size(539, 214);
            this.LogTextBox.TabIndex = 13;
            // 
            // LogFileName
            // 
            this.LogFileName.Location = new System.Drawing.Point(154, 191);
            this.LogFileName.Name = "LogFileName";
            this.LogFileName.Size = new System.Drawing.Size(400, 22);
            this.LogFileName.TabIndex = 12;
            this.LogFileName.Text = "logfile.txt";
            this.LogFileName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // NumStream
            // 
            this.NumStream.Location = new System.Drawing.Point(260, 154);
            this.NumStream.Name = "NumStream";
            this.NumStream.Size = new System.Drawing.Size(120, 22);
            this.NumStream.TabIndex = 11;
            this.NumStream.Tag = "10";
            this.NumStream.Text = "10";
            this.NumStream.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NumStream.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
 //           this.NumStream.TextChanged += new System.EventHandler(this.Distance_TextChanged);
            // 
            // FindType
            // 
            this.FindType.FormattingEnabled = true;
            this.FindType.Items.AddRange(new object[] {
            "простой поиск",
            "алгоритм Вагнера-Фишера",
            "алгоритм Дамерау-Левенштейна",
            "простой поиск (многопоточный)",
            "алгоритм Вагнера-Фишера (многопоточный)",
            "алгоритм Дамерау-Левенштейна (многопоточный)"});
            this.FindType.Location = new System.Drawing.Point(154, 50);
            this.FindType.Name = "FindType";
            this.FindType.Size = new System.Drawing.Size(400, 24);
            this.FindType.TabIndex = 10;
            this.FindType.Text = "простой поиск";
            // 
            // Distance
            // 
            this.Distance.Location = new System.Drawing.Point(260, 119);
            this.Distance.Name = "Distance";
            this.Distance.Size = new System.Drawing.Size(120, 22);
            this.Distance.TabIndex = 9;
            this.Distance.Tag = "2";
            this.Distance.Text = "2";
            this.Distance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Distance.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.Distance.TextChanged += new System.EventHandler(this.Distance_TextChanged);
            // 
            // FindText
            // 
            this.FindText.Location = new System.Drawing.Point(154, 84);
            this.FindText.Name = "FindText";
            this.FindText.Size = new System.Drawing.Size(400, 22);
            this.FindText.TabIndex = 8;
            this.FindText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FindText_KeyDown);
            // 
            // FindGo
            // 
            this.FindGo.Location = new System.Drawing.Point(392, 118);
            this.FindGo.Name = "FindGo";
            this.FindGo.Size = new System.Drawing.Size(162, 23);
            this.FindGo.TabIndex = 7;
            this.FindGo.Text = "Выполнить поиск :";
            this.FindGo.UseVisualStyleBackColor = true;
            this.FindGo.Click += new System.EventHandler(this.FindGo_Click);
            // 
            // FileLogbt
            // 
            this.FileLogbt.Location = new System.Drawing.Point(15, 190);
            this.FileLogbt.Name = "FileLogbt";
            this.FileLogbt.Size = new System.Drawing.Size(131, 23);
            this.FileLogbt.TabIndex = 6;
            this.FileLogbt.Text = "Имя файла логов :";
            this.FileLogbt.UseVisualStyleBackColor = true;
            this.FileLogbt.Click += new System.EventHandler(this.FileLogbt_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(242, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Потоков в многопоточном режиме :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(213, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Дистанция поиска не больше :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Строка для поика :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Алгоритм работы :";
            // 
            // TextFileName
            // 
            this.TextFileName.Location = new System.Drawing.Point(135, 18);
            this.TextFileName.Name = "TextFileName";
            this.TextFileName.Size = new System.Drawing.Size(419, 22);
            this.TextFileName.TabIndex = 1;
            // 
            // OpenFilebt
            // 
            this.OpenFilebt.Location = new System.Drawing.Point(15, 18);
            this.OpenFilebt.Name = "OpenFilebt";
            this.OpenFilebt.Size = new System.Drawing.Size(114, 23);
            this.OpenFilebt.TabIndex = 0;
            this.OpenFilebt.Text = "Открыть файл :";
            this.OpenFilebt.UseVisualStyleBackColor = true;
            this.OpenFilebt.Click += new System.EventHandler(this.OpenFilebt_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btPrescript);
            this.tabPage2.Controls.Add(this.DistMatrix);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(567, 439);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Матрица расстояний :";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btPrescript
            // 
            this.btPrescript.Location = new System.Drawing.Point(177, 389);
            this.btPrescript.Name = "btPrescript";
            this.btPrescript.Size = new System.Drawing.Size(144, 23);
            this.btPrescript.TabIndex = 1;
            this.btPrescript.Text = "Предписание";
            this.btPrescript.UseVisualStyleBackColor = true;
            this.btPrescript.Click += new System.EventHandler(this.btPrescript_Click);
            // 
            // DistMatrix
            // 
            this.DistMatrix.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.DistMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DistMatrix.Location = new System.Drawing.Point(6, 6);
            this.DistMatrix.Name = "DistMatrix";
            this.DistMatrix.RowTemplate.Height = 24;
            this.DistMatrix.Size = new System.Drawing.Size(558, 354);
            this.DistMatrix.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NameFileStr,
            this.TimeWorkStr});
            this.statusStrip1.Location = new System.Drawing.Point(0, 487);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1095, 25);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // NameFileStr
            // 
            this.NameFileStr.AutoSize = false;
            this.NameFileStr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.NameFileStr.Name = "NameFileStr";
            this.NameFileStr.Size = new System.Drawing.Size(550, 20);
            this.NameFileStr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TimeWorkStr
            // 
            this.TimeWorkStr.AutoSize = false;
            this.TimeWorkStr.BackColor = System.Drawing.SystemColors.ControlLight;
            this.TimeWorkStr.Name = "TimeWorkStr";
            this.TimeWorkStr.Size = new System.Drawing.Size(250, 20);
            this.TimeWorkStr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ListData
            // 
            this.ListData.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ListData.FormattingEnabled = true;
            this.ListData.ItemHeight = 16;
            this.ListData.Location = new System.Drawing.Point(579, 28);
            this.ListData.Name = "ListData";
            this.ListData.Size = new System.Drawing.Size(516, 436);
            this.ListData.TabIndex = 2;
            this.ListData.Click += new System.EventHandler(this.ListData_Click);
            this.ListData.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListData_DrawItem);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 472);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1089, 15);
            this.progressBar1.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 10;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 512);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.ListData);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Подопригорова H. ИУ5-34Б";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DistMatrix)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel NameFileStr;
        private System.Windows.Forms.ToolStripStatusLabel TimeWorkStr;
        private System.Windows.Forms.DomainUpDown Distance;
        private System.Windows.Forms.TextBox FindText;
        private System.Windows.Forms.Button FindGo;
        private System.Windows.Forms.Button FileLogbt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextFileName;
        private System.Windows.Forms.Button OpenFilebt;
        private System.Windows.Forms.Button btPrescript;
        private System.Windows.Forms.DataGridView DistMatrix;
        private System.Windows.Forms.ListBox ListData;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox LogFileName;
        private System.Windows.Forms.DomainUpDown NumStream;
        private System.Windows.Forms.ComboBox FindType;
        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}

