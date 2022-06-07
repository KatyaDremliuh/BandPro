using System;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int Test(int a)
        {
            int x = a;
            int y = x + a;

            return y;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblCurrentTime.Text = DateTime.Now.ToString();

            int a = Test(50);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}