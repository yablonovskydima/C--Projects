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
    public partial class Form3 : Form
    {
        public TextBox textbox { get; set; }
        public List<int> indexes = new List<int>();
        public Form3(TextBox text_box)
        {
            InitializeComponent();

            this.textbox = text_box;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text)) 
            {
                textbox.Select(textbox.Text.IndexOf(textBox1.Text), textBox1.Text.Count());
                textbox.SelectedText = textBox2.Text;
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
            {
                int indx = 0;
                char key = textBox1.Text[0];
                foreach (var i in textbox.Text) 
                {
                    if(i == key) 
                    {
                        textbox.Select(indx, textBox1.Text.Count());
                        string val = textbox.SelectedText;
                        if(val == textBox1.Text) 
                        {
                            indexes.Add(indx);
                        }
                    }
                    indx++;
                }

                foreach(var i in indexes) 
                {
                    textbox.Select(i, textBox1.Text.Count());
                    textbox.SelectedText = textBox2.Text;
                }
                this.Close();
            }
        }
    }
}
