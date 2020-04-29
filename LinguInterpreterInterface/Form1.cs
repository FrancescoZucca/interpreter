using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LinguLib;

namespace LinguInterpreterInterface
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fl = new OpenFileDialog { Filter = "Lingu source files (*.lgu)|*lgu" };
            fl.ShowDialog();
            textBox1.Text = fl.FileName;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            return;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OneLiner.LexterpretFile(textBox1.Text);
        }
    }
}
