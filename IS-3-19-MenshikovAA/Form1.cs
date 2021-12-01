using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS_3_19_MenshikovAA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        abstract class Components
        {
            public int cena { get; set; }
            public string godV { get; set; }
        }
        public void Display()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
