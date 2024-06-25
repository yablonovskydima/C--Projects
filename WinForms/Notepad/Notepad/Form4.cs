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
    public partial class Form4 : Form
    {
        public TextBox text { get; set; }
        public Form4(TextBox textBox)
        {
            InitializeComponent();

            text = textBox; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text)) 
            {
                try
                {
                    int j = 0;
                    string txt = "";
                    for (int i = 0; i < text.Lines.Count(); i++)
                    {
                        if (i == Convert.ToInt32(textBox1.Text))
                        {
                            j = text.Text.IndexOf(text.Lines[i]);
                            text.Select(j, text.Lines[i].Count());
                            txt = text.SelectedText;
                            break;
                        }
                    }


                    text.Select(j, txt.Count());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("You have inputed an integer or line does not exist!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
