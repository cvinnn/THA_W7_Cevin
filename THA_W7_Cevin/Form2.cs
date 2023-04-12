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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace THA_W7_Cevin
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public List<Form> runningform = new List<Form>();

        public Form3 runningform3 { get; set; }

        List<string> movielist = new List<string>();
        List<string> movietitle = new List<string>();

        string[] moviearray;
        string[] splitter;

        string movieposterloc;

        Bitmap poster;
        Bitmap resize;

        Panel panel;

        Button button;

        Label lbl;

        public void posterload()
        {
            for (int i = 0; i < movielist.Count; i++)
            {
                button = new Button();

                splitter = movielist[i].Split('+');
                movieposterloc = $@"{splitter[1]}";
                movietitle.Add(splitter[0]);

                poster = new Bitmap(movieposterloc, false);
                resize = new Bitmap(poster, new Size(180, 280));

                button.Name = $"{splitter[0]}";
                button.Image = resize;
                button.Location = new Point(60, 20 + (i * 340));
                button.Size = new Size(180, 280);

                this.Controls.Add(button);

                button.Click += Button_Click;
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            button = (Button)sender;
            Form3 f3;
            int count = 0;
            foreach (Form frm in runningform)
            {
                if (frm.Name == button.Name)
                {
                    runningform3 = (Form3)frm;
                    runningform3.Show();
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
                f3 = new Form3();
                f3.title = button.Name;
                f3.runningform2 = this;
                f3.button = button;
                f3.MdiParent = this.MdiParent;
                f3.movielist = this.movielist;
                f3.movietitle = this.movietitle;
                f3.Dock = DockStyle.Fill;
                f3.Show();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string txtlocation = File.ReadAllText(@"C:\Users\Cevin-Predator\Documents\Coding stuff\File Data\Movie List.txt");
            moviearray = txtlocation.Split('=');
            foreach (string movie in moviearray)
            {
                movielist.Add(movie);
            }
            posterload();
        }
    }
}
