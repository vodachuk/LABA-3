using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnalyzerClass;
using CalcClass;

namespace Calc
{
    public partial class Form1 : Form
    {
        public int number;

        public Form1()
        {
            InitializeComponent();
        }

        private void OpenBracket_Click(object sender, EventArgs e)
        {
            Expression.Text += "(";
        }

        private void CloseBracket_Click(object sender, EventArgs e)
        {
            Expression.Text += ")";
        }

        private void Backspace_Click(object sender, EventArgs e)
        {
            if (Expression.Text.Length > 0)
                Expression.Text = Expression.Text.Remove(Expression.Text.Length - 1, 1);
        }

        private void C_Click(object sender, EventArgs e)
        {
            Expression.Text = "";
        }

        private void numberButton_Click(object sender, EventArgs e)
        {
            var numButton = sender as Button;
            if (numButton != null)
                Expression.Text += numButton.Text;
        }

        private void operatorButton_Click(object sender, EventArgs e)
        {
            var operatorButton = sender as Button;
            if (operatorButton != null)
                Expression.Text += operatorButton.Tag;
        }

        private void MPlus_Click(object sender, EventArgs e)
        {
            number += Convert.ToInt32(Result.Text);
        }

        private void MC_Click(object sender, EventArgs e)
        {
            number = 0;
        }

        private void MR_Click(object sender, EventArgs e)
        {
            Expression.Text += number.ToString();
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            Analyzer.Expression = Expression.Text;
            Result.Text = Analyzer.Estimate();
        }

        private void Calculator_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Calculate.PerformClick();
        }
    }
}
