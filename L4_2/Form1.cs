using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L4_2
{
    public partial class Form1 : Form
    {
        private List<string> words;


        public Form1()
        {
            InitializeComponent();
        }

        private void but_search_Click(object sender, EventArgs e)
        {
            if (words == null) return;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            result_search.BeginUpdate();
            result_search.Items.Clear();

            string substring = text_search.Text.ToLower();
            foreach (string s in words)
                if (s.Contains(substring))
                    result_search.Items.Add(s);
            result_search.EndUpdate();

            sw.Stop();
            status.Text = "Прошло " + sw.ElapsedMilliseconds + "мс";
        }

        private void search_keydown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.None && (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return))
                but_search_Click(this, new EventArgs());
        }

        private void on_open_click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text files|*.txt";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                words = new List<string>();
                status.Text = "Reading file..";
                Stopwatch sw = new Stopwatch();
                sw.Start();
                foreach (string s in File.ReadAllText(dialog.FileName, Encoding.UTF8).Split(' ', '\t', '!', '?', ',', '-', '.', ':', '\r', '\n'))
                {
                    if (!String.IsNullOrEmpty(s))
                    {
                        string lowercase = s.ToLower();
                        if (!words.Contains(lowercase)) words.Add(lowercase);
                    }
                }
                sw.Stop();
                status.Text = "Took " + sw.ElapsedMilliseconds + "ms";
                but_search_Click(this, new EventArgs());
            }
        }


    }
}
