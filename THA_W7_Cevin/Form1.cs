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

namespace THA_W7_Cevin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void f2show()
        {
            Form2 f2 = new Form2();
            f2.MdiParent = this;
            f2.Dock = DockStyle.Fill;
            f2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            f2show();
        }
    }
}
