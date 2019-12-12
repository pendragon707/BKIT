namespace L4_2
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
            this.but_search = new System.Windows.Forms.Button();
            this.text_search = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.status = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FindType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Distance = new System.Windows.Forms.DomainUpDown();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.ListData = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // but_search
            // 
            this.but_search.Location = new System.Drawing.Point(531, 175);
            this.but_search.Name = "but_search";
            this.but_search.Size = new System.Drawing.Size(92, 31);
            this.but_search.TabIndex = 0;
            this.but_search.Text = "Поиск";
            this.but_search.UseVisualStyleBackColor = true;
            this.but_search.Click += new System.EventHandler(this.but_search_Click);
            // 
            // text_search
            // 
            this.text_search.Location = new System.Drawing.Point(34, 175);
            this.text_search.Name = "text_search";
            this.text_search.Size = new System.Drawing.Size(482, 26);
            this.text_search.TabIndex = 1;
            this.text_search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.search_keydown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1251, 33);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытиеToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.fileToolStripMenuItem.Text = "&Файл";
            // 
            // открытиеToolStripMenuItem
            // 
            this.открытиеToolStripMenuItem.Name = "открытиеToolStripMenuItem";
            this.открытиеToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.открытиеToolStripMenuItem.Size = new System.Drawing.Size(231, 30);
            this.открытиеToolStripMenuItem.Text = "&Открыть";
            this.открытиеToolStripMenuItem.Click += new System.EventHandler(this.on_open_click);
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(34, 401);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(58, 20);
            this.status.TabIndex = 4;
            this.status.Text = "Время";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Алгоритм работы :";
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
            this.FindType.Location = new System.Drawing.Point(192, 49);
            this.FindType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FindType.Name = "FindType";
            this.FindType.Size = new System.Drawing.Size(431, 28);
            this.FindType.TabIndex = 11;
            this.FindType.Text = "простой поиск";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Строка для поика :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(241, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Дистанция поиска не больше :";
            // 
            // Distance
            // 
            this.Distance.Location = new System.Drawing.Point(290, 95);
            this.Distance.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Distance.Name = "Distance";
            this.Distance.Size = new System.Drawing.Size(135, 26);
            this.Distance.TabIndex = 14;
            this.Distance.Tag = "2";
            this.Distance.Text = "2";
            this.Distance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Distance.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // LogTextBox
            // 
            this.LogTextBox.Location = new System.Drawing.Point(34, 221);
            this.LogTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.Size = new System.Drawing.Size(589, 236);
            this.LogTextBox.TabIndex = 15;
            // 
            // ListData
            // 
            this.ListData.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ListData.FormattingEnabled = true;
            this.ListData.ItemHeight = 16;
            this.ListData.Location = new System.Drawing.Point(650, 25);
            this.ListData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ListData.Name = "ListData";
            this.ListData.Size = new System.Drawing.Size(580, 432);
            this.ListData.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 502);
            this.Controls.Add(this.ListData);
            this.Controls.Add(this.LogTextBox);
            this.Controls.Add(this.Distance);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FindType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.status);
            this.Controls.Add(this.text_search);
            this.Controls.Add(this.but_search);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button but_search;
        private System.Windows.Forms.TextBox text_search;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытиеToolStripMenuItem;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox FindType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DomainUpDown Distance;
        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.ListBox ListData;
    }
}

