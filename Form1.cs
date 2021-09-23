   using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kalkulator_windows
{
    public partial class Kalkulator : Form
    {
        string operation = "";
        string lastOperation = "";
        double value = 0;
        bool operationClicked = false;
        public Kalkulator()
        {
            InitializeComponent();
        }
        private void clearButton_Click(object sender, EventArgs e)
        {
            resultLabel.Text = "";
            entryContent.Text = "0";
            operationClicked = false;
            button21.Enabled = true;
        }
        private void entryClearButton_Click(object sender, EventArgs e)
        {
            entryContent.Text = "0";
            button21.Enabled = true;
        }
        private void numberButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(entryContent.Text == "0" || operationClicked)
            {
                entryContent.Clear();
            }
            operationClicked = false;
            entryContent.Text += double.Parse(button.Text);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Text;
            value = double.Parse(entryContent.Text);
            operationClicked = true;
            button21.Enabled = true;
            bool isEmpty = resultLabel.Text == "";
            if (isEmpty)
            {
                resultLabel.Text = value + " " + operation;
            }
            else
            {
                double resultLabelValue = double.Parse(resultLabel.Text.Remove(resultLabel.Text.Length - 2, 2));
                lastOperation = resultLabel.Text.Remove(0 ,resultLabel.Text.Length - 1);
                switch (lastOperation)
                {
                    case "+":
                        resultLabel.Text = (resultLabelValue + value).ToString() + " " + operation;
                        entryContent.Text = (resultLabelValue + value).ToString();
                        break;
                    case "-":
                        resultLabel.Text = (resultLabelValue - value).ToString() + " " + operation;
                        entryContent.Text = (resultLabelValue - value).ToString();
                        break;
                    case "×":
                        resultLabel.Text = (resultLabelValue * value).ToString() + " " + operation;
                        entryContent.Text = (resultLabelValue * value).ToString();
                        break;
                    case "÷":
                        if (entryContent.Text == "0")
                        {
                            entryContent.Text = "Nie możesz dzielić przez 0!";
                        }
                        else
                        {
                            resultLabel.Text = (resultLabelValue / value).ToString() + " " + operation;
                            entryContent.Text = (resultLabelValue / value).ToString();
                        }
                        break;
                }
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            string resultLabelValue = resultLabel.Text.Remove(resultLabel.Text.Length - 2, 2);
            if (resultLabelValue == entryContent.Text)
            {
                resultLabel.Text = (double.Parse(resultLabelValue) - double.Parse(resultLabelValue)).ToString();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            value = double.Parse(entryContent.Text);
            entryContent.Text = (1 / value).ToString();
            operationClicked = true;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            value = double.Parse(entryContent.Text);
            operationClicked = true;
            entryContent.Text = (Math.Sqrt(value)).ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            value = double.Parse(entryContent.Text);
            operationClicked = true;
            entryContent.Text = (Math.Pow(value, 2)).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            entryContent.Text = entryContent.Text.Remove(entryContent.Text.Length - 1, 1);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (entryContent.Text.Contains(","))
            {
                button21.Enabled = false;
            }
            else
            {
                entryContent.Text += button.Text;
                button21.Enabled = false;
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            entryContent.Text = (double.Parse(entryContent.Text) * -1).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(resultLabel.Text == "")
            {
                entryContent.Text = "0";
            }
            else
            {
                entryContent.Text = (double.Parse(entryContent.Text) /100).ToString();
            }
        }
    }
}
