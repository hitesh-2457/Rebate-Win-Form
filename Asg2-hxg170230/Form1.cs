using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asg2_hxg170230
{
    public partial class Form1 : Form
    {
        int bsCount = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void FeildKeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<String> Gender = new List<string> {"Male","Female" };
        }
    }
}
