using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyCalculator
{
    public partial class MainPage : ContentPage
    {
        int flag = 1;
        string myoperator;
        double firstNumber, secondNumber;


        public MainPage()
        {

            InitializeComponent();
        }

        void OnSelectNumber(object sender, EventArgs e)
        {
            Button button = (Button)sender;


            string pressed = button.Text;
           
            if (this.resultText.Text == "0" || flag < 0)
            {
                this.resultText.Text = "";

                if (flag < 0) 
                    flag *= -2;
            }

            this.resultText.Text += pressed;

            double number; 
            if (double.TryParse(this.resultText.Text, out number))
            {
             
                if (flag == 1)
                {
                    firstNumber = number;
                }
                else
                {
                    secondNumber = number;
                }
            }
        }

        void OnSelectOperator(object sender, EventArgs e)
        {
            flag = -1;
            Button button = (Button)sender;
            string pressed = button.Text;
            this.resultText.Text += pressed;
            myoperator = pressed;
        }

        void OnClear(object sender, EventArgs e)
        {
            firstNumber = 0;
            secondNumber = 0;
            flag = 1;
            this.resultText.Text = "0";
        }

        void OnPercentage(object sender, EventArgs e)
        {
            if  (flag == 1)
            {
                var result = firstNumber / 100;
                this.resultText.Text = result.ToString();
                firstNumber = result;
            }
        }
        void OnSquareRoot(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                double result = Math.Sqrt(firstNumber);
                this.resultText.Text = result.ToString();
                result = firstNumber;
            }
        }

        void OnDecimal(object sender, EventArgs e)
        {
            if (!resultText.Text.Contains("."))
             {
                 resultText.Text += ".";
             }
        }
        void OnDelete(object sender, EventArgs e)
        {
            if (resultText.Text != string.Empty)
            {
                int resultLength = this.resultText.Text.Length;
                if (resultLength != 1)
                {
                    resultText.Text = this.resultText.Text.Remove(resultLength - 1);
                }
                else
                {
                    resultText.Text = 0.ToString();
                }
            }
        }
        void OnCalculate(object sender, EventArgs e) 
        {

            if (flag == 2)
            {
                double result = Calculate(firstNumber, secondNumber, myoperator);
                this.resultText.Text = result.ToString();
                firstNumber = result;
            }
        }

        private static double Calculate(double value1, double value2, string myoperator)
        {
            double result = 0;
            switch (myoperator)
            {
                case "/":
                    result = value1 / value2;
                    break;
                case "*":
                    result = value1 * value2;
                    break;
                case "+":
                    result = value1 + value2;
                    break;
                case "-":
                    result = value1 - value2;
                    break;

            }
            return result;
        }
    }
}
