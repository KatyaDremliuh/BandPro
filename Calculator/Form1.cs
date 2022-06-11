using System;
using System.Globalization;
using System.Windows.Forms;
using Calculator.Operations;

namespace Calculator
{
    public partial class Form1 : Form
    {
        protected Operation CurrentOperation; // тут объект объявили, но не создали

        private readonly CultureInfo _commaCulture = new CultureInfo("en")
        {
            NumberFormat =
            {
                NumberGroupSeparator = ",",
            },
        };
        private readonly CultureInfo _pointCulture = new CultureInfo("en")
        {
            NumberFormat =
            {
                NumberGroupSeparator = ".",
            },
        };

        public Form1()
        {
            InitializeComponent();

            // Подписываемся на события нажатия кнопок
            btn0.Click += BtnNumbers;
            btn1.Click += BtnNumbers;
            btn2.Click += BtnNumbers;
            btn3.Click += BtnNumbers;
            btn4.Click += BtnNumbers;
            btn5.Click += BtnNumbers;
            btn6.Click += BtnNumbers;
            btn7.Click += BtnNumbers;
            btn8.Click += BtnNumbers;
            btn9.Click += BtnNumbers;
            btnComma.Click += BtnNumbers;
        }

        private void BtnNumbers(object sender, EventArgs e)
        {
            tBOutput.Text += ((Button)sender).Tag.ToString();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (CurrentOperation == null) // проверить, создан ли объект Operation
            {
                CurrentOperation = new Addition();

                InitOperation(); // получить первое число
            }
            else
            {
                Calculate();
            }
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (CurrentOperation == null)
            {
                CurrentOperation = new Subtraction();
                InitOperation();
            }
            else
            {
                Calculate();
            }
        }

        private void btnObelus_Click(object sender, EventArgs e)
        {
            if (CurrentOperation == null)
            {
                CurrentOperation = new Division();
                InitOperation();
            }
            else
            {
                Calculate();
            }
        }

        private void btnTimes_Click(object sender, EventArgs e)
        {
            if (CurrentOperation == null)
            {
                CurrentOperation = new Multiplication();
            }
            else
            {
                Calculate();
            }
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            if (CurrentOperation != null)
            {
                Calculate();
            }
        }

        private void InitOperation()
        {
            CurrentOperation.FirstValue = ConvertToDouble(tBOutput.Text);
            tBOutput.Text = string.Empty;
        }

        private double ConvertToDouble(string input)
        {
            input = input.Trim();

            if (input.Contains(",") && input.Split(',').Length == 2)
            {
                return Convert.ToDouble(input, _commaCulture);
            }

            if (input.Contains(".") && input.Split('.').Length == 2)
            {
                return Convert.ToDouble(input, _pointCulture);
            }

            return Convert.ToDouble(input);
        }

        private void Calculate()
        {
            CurrentOperation.SecondValue = ConvertToDouble(tBOutput.Text);
            tBOutput.Text = Convert.ToString(CurrentOperation.DoOperation(), CultureInfo.InvariantCulture);
            CurrentOperation = null;
        }

        /// <summary>
        /// Запретить ввод с клавиатуры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tBOutput_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btbClear_Click(object sender, EventArgs e)
        {
            CurrentOperation = null;
            tBOutput.Text = string.Empty;
        }
    }
}