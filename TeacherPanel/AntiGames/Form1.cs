using System;
using System.Windows.Forms;
using System.Net;
using System.Text.Json;
using System.Collections.Generic;

namespace AntiGames
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            List<string> stringList = JsonSerializer.Deserialize<List<string>>(wc.DownloadString(textBox1.Text + "/all"));
            foreach (var item in stringList)
            {
                ListViewItem li = new ListViewItem(item);
                listView1.Items.Add(li);
            }

            if (wc.DownloadString(textBox1.Text) == "True")
            {
                label1.Text = "Состояние - Вкл";
            } else
            {
                label1.Text = "Состояние - Выкл";
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            wc.DownloadString(textBox1.Text + "/on");
            label1.Text = "Состояние - Вкл";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            wc.DownloadString(textBox1.Text + "/off");
            label1.Text = "Состояние - Выкл";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
                return;
            WebClient wc = new WebClient();
            wc.DownloadString(textBox1.Text + "/add?word=" + textBox2.Text);
            ListViewItem item = new ListViewItem(textBox2.Text);
            listView1.Items.Add(item);
            textBox2.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                WebClient wc = new WebClient();
                wc.DownloadString(textBox1.Text + "/del?word=" + listView1.SelectedItems[0].Text);
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
        }
    }
}
