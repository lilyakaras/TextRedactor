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
    public partial class Form3 : Form
    {
        Form1 form3;
        public Form3()
        {
            InitializeComponent();
        }
        public Form3(Form1 f1)
        {
            InitializeComponent();
            form3 = f1;
        }

        private void buttonReplace_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            form3.FindReplace(textBox1.Text, textBox2.Text);
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
