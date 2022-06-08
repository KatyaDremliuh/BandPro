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

        private int Division(int a, int b)
        {
            int result = 0;

            try
            {
                result = a / b;
                return result;
            }
            catch (MyException exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show(@"We are into finally.");
            }

            return result;
        }

        private void btnCatchError_Click(object sender, EventArgs e)
        {
            int a = 100;
            int b = 0;

            if (b == 0)
            {
                MessageBox.Show(@"Divider = 0. Choose another divider.");
            }
            else
            {
                Division(a, b);

            }
        }
    }
}