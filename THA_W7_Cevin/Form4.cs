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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        List<Button> seatlist = new List<Button>();
        List<Button> seatclicked = new List<Button>();
        List<Button> seatremoved = new List<Button>();

        List<Button> seatreserved = new List<Button>();
        List<string> seatunavail = new List<string>();

        List<int> randomchecker = new List<int>();

        public Button button { get; set; }

        public Form3 runningform3 { get; set; }

        public string hour { get; set; }

        string[] alphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J"};

        Button btn;

        int random;
        int randomseatalphabet;
        int randomseat;

        public void randomizer()
        {
            Random rnd = new Random();

            random = rnd.Next(1,70);

            for (int i = 0; i < random; i++)
            {
                randomseat = rnd.Next(1, 10);
                randomseatalphabet = rnd.Next(1, 10);
                if (randomchecker.Contains(Convert.ToInt32(randomseatalphabet.ToString() + randomseat.ToString())))
                {
                    i--;
                }
                else
                {
                    seatunavail.Add($"{alphabet[randomseatalphabet]}{randomseat.ToString()}");
                }
            }
        }

        public void seatloader()
        {
            randomizer();
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    btn = new Button();
                    btn.Name = alphabet[i-1] + j;
                    btn.Text = alphabet[i-1] + j;
                    btn.Font = new Font("Microsoft Sans Serif", 6.7F);
                    btn.Size = new Size(30, 30);
                    btn.Location = new Point(1 + 31 * (j - 1), 1 + 31 * (i - 1));
                    this.Controls.Add(btn);
                    seatlist.Add(btn);
                    btn.Click += Btn_Click;
                }
            }
            seatavail();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            btn = (Button)sender;

            if (!seatclicked.Contains(btn))
            {
                seatclicked.Add(btn);
                seatavail();
            }
            else
            {
                foreach (Button click in seatclicked)
                {
                    if (btn.Name == click.Name)
                    {
                        this.btn.BackColor = default(Color);
                        seatremoved.Add(btn);
                    }
                }
                foreach (Button remove in seatremoved)
                {
                    seatclicked.Remove(remove);
                }
            }
        }

        public void seatavail()
        {
            foreach (Button seat in seatlist)
            {
                foreach (string unavail in seatunavail)
                {
                    if (seat.Name.Equals(unavail))
                    {
                        seat.BackColor = Color.Tomato;
                        seat.Enabled = false;
                    }
                }
            }
            foreach (Button seat in seatlist)
            {
                foreach (Button click in seatclicked)
                {
                    if (seat.Name.Equals(click.Name))
                    {
                        seat.BackColor = Color.LightGreen;
                    }
                }
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            btnScreen.Left = (this.Width - btnScreen.Right) / 2;
            seatloader();
        }

        private void btnReserve_Click(object sender, EventArgs e)
        {
            foreach (Button seat in seatclicked)
            {
                seatreserved.Add(seat);
                seatunavail.Add(seat.Name);
            }
            foreach (Button reserved in seatreserved)
            {
                seatclicked.Remove(reserved);
            }
            seatavail();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            runningform3.runningform4 = this;
            this.Name = hour;
            runningform3.runningform.Add(this);
            this.Hide();
        }
    }
}
