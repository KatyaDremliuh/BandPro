using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            btn1.Click += btnNumbers;
            btn2.Click += btnNumbers;
            btn3.Click += btnNumbers;
            btn4.Click += btnNumbers;
            btn5.Click += btnNumbers;
            btn6.Click += btnNumbers;
            btn7.Click += btnNumbers;
            btn8.Click += btnNumbers;
            btn9.Click += btnNumbers;
        }

        private void btnNumbers(object sender, EventArgs e)
        {
            textBox1.Text += ((Button)sender).Tag.ToString();
        }
    }
}