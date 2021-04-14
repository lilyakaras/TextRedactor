using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_5_WinForms
{
    public partial class Form2 : Form
    {
        public string FindWord { get; set; }
        //TextBox t;
        Form1 form1;

        public Form2()
        {
            InitializeComponent();
        }
        public Form2(Form1 f1)
        {
            InitializeComponent();
            form1 = f1;
        }
        public Form2(TextBox str)
        {
            InitializeComponent();
            //this.t = str;
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            // FindWord = textBox1.Text;
            //this.t.Text= textBox1.Text;
            this.DialogResult = DialogResult.OK;
            form1.Findd(textBox1.Text);
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //this.Owner.Enabled = false;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.Owner.Enabled = true;
            //this.t.Text = textBox1.Text;
        }
    }
}
