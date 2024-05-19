using System.Windows.Forms;
using System;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private double currentValue = 0; 
        private string currentOperation = ""; 
        private bool isNewNumber = true; 
        private bool hasOperation = false; 

        public Form1()
        {
            InitializeComponent();
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (isNewNumber)
            {
                okno.Text = btn.Text;
                isNewNumber = false;
            }
            else
            {
                okno.Text += btn.Text;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetOperation("+");
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            SetOperation("-");
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            SetOperation("*");
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            SetOperation("/");
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            PerformOperation();
            isNewNumber = true;
            currentOperation = "";
            hasOperation = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            okno.Text = "0";
            currentValue = 0;
            currentOperation = "";
            isNewNumber = true;
            hasOperation = false;
        }

        private void SetOperation(string operation)
        {
            if (hasOperation)
            {
                PerformOperation();
            }
            else
            {
                currentValue = double.Parse(okno.Text);
                hasOperation = true;
            }

            currentOperation = operation;
            isNewNumber = true;
        }

        private void PerformOperation()
        {
            double newValue = double.Parse(okno.Text);
            switch (currentOperation)
            {
                case "+":
                    currentValue += newValue;
                    break;
                case "-":
                    currentValue -= newValue;
                    break;
                case "*":
                    currentValue *= newValue;
                    break;
                case "/":
                    if (newValue != 0)
                        currentValue /= newValue;
                    else
                        MessageBox.Show("Nie można dzielić przez zero!");
                    break;
            }
            okno.Text = currentValue.ToString();
        }
    }
}
