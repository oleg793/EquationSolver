using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EquationSolver__ENG_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string equation = textBox1.Text;

            int n1 = 0, res = 0;
            char equationLetter = ' ';
            char op = ' ';

            string temp = "";

            bool isLetterWent = false;

            foreach(char q in equation)
            {
                if(q == '*' || q == '/' || q == '+' || q == '-')
                {
                    op = q;
                    isLetterWent = true;
                    break;
                } else if(Char.IsLetter(q))
                {
                    equationLetter = q;
                } 
                else
                {
                    temp += q;
                    n1 = Convert.ToInt32(temp);
                }
            }

            temp = "";
            bool isEq = false;

            foreach (char q in equation)
            {
                if ((q == '*' || q == '/' || q == '+' || q == '-') && !isLetterWent)
                {
                    op = q;
                    break;
                }
                else if (Char.IsLetter(q))
                {
                    equationLetter = q;
                }
                else
                {
                    if(q == '=')
                    {
                        break;
                    }

                    if (op != q)
                    {
                        temp += q;
                        n1 = Convert.ToInt32(temp);
                    }
                }
            }

            temp = "";
            isEq = false;

            foreach (char q in equation)
            {
                if(isEq == true)
                {
                    temp += q;
                }

                if(q == '=')
                {
                    isEq = true;
                }
            }
            res = Convert.ToInt32(temp);
            temp = "";
            isEq = false;

            int output = 0;

            if(radioButton1.Checked)
            {
                switch(op)
                {
                    case '+':
                        output = res - n1;
                        break;
                    case '-':
                        output = res + n1;
                        break;
                    case '*':
                        output = res / n1;
                        break;
                    case '/':
                        output = res * n1;
                        break;
                }
            } else if(radioButton2.Checked)
            {
                switch (op)
                {
                    case '+':
                        output = res - n1;
                        break;
                    case '-':
                        output = n1 - res;
                        break;
                    case '*':
                        output = res / n1;
                        break;
                    case '/':
                        output = n1 / res;
                        break;
                }
            }
            MessageBox.Show(String.Format("Result: {0}", output));
        }
    }
}
