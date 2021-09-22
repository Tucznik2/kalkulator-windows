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
            bool isEmpty = entryContent.Text == string.Empty;
            if (entryContent.Text == "0" || operationClicked )
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
            resultLabel.Text = value + " " + operation;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            resultLabel.Text = "";
            switch (operation)
            {
                case "+":
                    entryContent.Text = (value + double.Parse(entryContent.Text)).ToString();
                    break;
                case "-":
                    entryContent.Text = (value - double.Parse(entryContent.Text)).ToString();
                    break;
                case "×":
                    entryContent.Text = (value * double.Parse(entryContent.Text)).ToString();
                    break;
                case "÷":
                    if(entryContent.Text == "0")
                    {
                        entryContent.Text = "Nie możesz dzielić przez 0!";
                    }
                    else
                    {
                        entryContent.Text = (value / double.Parse(entryContent.Text)).ToString();
                    }
                    break;
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
                entryContent.Text = (double.Parse(entryContent.Text) * 0.01).ToString();
            }
        }
    }
}
