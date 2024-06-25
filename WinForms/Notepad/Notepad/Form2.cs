using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    public partial class Form2 : Form
    {
        public TextBox TextBox1 { get; set; }
        public Form2(TextBox textBox)
        {
            InitializeComponent();
            TextBox1 = textBox;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text)) 
            {
                int pos = TextBox1.Text.IndexOf(textBox1.Text);
                int length = textBox1.Text.Count();
                TextBox1.Select(pos, length);
                
                this.Close();
            }
        }
    }
}
