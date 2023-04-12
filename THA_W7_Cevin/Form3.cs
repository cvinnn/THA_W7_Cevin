using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THA_W7_Cevin
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public List<string> movielist { get; set; }
        public List<string> movietitle { get; set; }

        public List<Form> runningform = new List<Form>();

        public Form2 runningform2 { get; set; }
        public Form4 runningform4 { get; set; }

        public Button button { get; set; }

        public string title { get; set; }

        List<string> playinghourlist = new List<string>();

        Button btn;

        string[] splitter;

        int count = 0;

        public void titleload()
        {
            lblTitle.Text = button.Name.Replace("btn", "");
            lblTitle.Left = (this.Width - lblTitle.Width) / 2;
        }

        public void hourload()
        {
            for (int i = 0; i < movielist.Count; i++)
            {
                splitter = movielist[i].Split('+');

                movietitle.Add(splitter[0]);

                playinghourlist.Add(splitter[0] + splitter[2]);
                playinghourlist.Add(splitter[0] + splitter[3]);
                playinghourlist.Add(splitter[0] + splitter[4]);
            }

            for (int i = 0; i < playinghourlist.Count; i++)
            {
                btn = new Button();

                if (playinghourlist[i].Contains(button.Name.Replace("btn", "")))
                {
                    btn.Name = "btn" + playinghourlist[i];
                    btn.Text = playinghourlist[i].Replace(button.Name.Replace("btn", ""), "");
                    btn.Location = new Point(20 + (88 * count), 120);
                    btn.Size = new Size(80, 30);
                    this.Controls.Add(btn);
                    btn.Click += Btn_Click;

                    count++;
                }
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            button = (Button)sender;
            int count = 0;
            Form4 f4;
            foreach (Form frm in runningform)
            {
                if (frm.Name == button.Name)
                {
                    runningform4 = (Form4)frm;
                    runningform4.Show();
                    break;
                }
                else
                {
                    count++;
                }

                if (count == runningform.Count)
                {
                    break;
                }
            }
            if (count == runningform.Count)
            {
                f4 = new Form4();
                f4.hour = button.Name;
                f4.runningform3 = this;
                f4.button = button;
                f4.MdiParent = this.MdiParent;
                f4.Dock = DockStyle.Fill;
                f4.Show();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            runningform2.runningform3 = this;
            this.Name = title;
            runningform2.runningform.Add(this);
            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            btnBack.Left = (this.Width - btnBack.Width) / 2;
            titleload();
            hourload();
        }
    }
}
