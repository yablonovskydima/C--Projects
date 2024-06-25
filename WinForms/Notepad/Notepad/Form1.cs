using System.Drawing.Printing;
using System.Diagnostics;
using System.ComponentModel;

namespace Notepad
{
    public partial class Form1 : Form
    {
        public string FileName = string.Empty;
        public PrinterSettings settings = null;
        public string FindToolString = null;
        public List<int> findnext_list = new List<int>();
        public int findnext_count = 0;
        public float currentsize { get; set; }
        public Form1()
        {
            InitializeComponent();
            currentsize = textBox1.Font.Size;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            Text = "Untitled";
        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Form1();
            form.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;

            if(openFileDialog.ShowDialog() == DialogResult.OK) 
            {
                using(StreamReader reader = File.OpenText(openFileDialog.FileName))
                {
                    textBox1.Text = reader.ReadToEnd();
                }
                Text = openFileDialog.FileName;
                this.FileName = openFileDialog.FileName;
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFile.FileName + ".txt"))
                {
                    writer.Write(textBox1.Text);
                }
                Text = saveFile.FileName + ".txt";
                this.FileName = saveFile.FileName + ".txt";
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(FileName)) 
            {
                using (StreamWriter writer = new StreamWriter(FileName))
                {
                    writer.Write(textBox1.Text);
                }
                Text = FileName;
            }
            else 
            {
                saveAsToolStripMenuItem.PerformClick();
            }
        }

        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {

            PageSetupDialog setupDialog = new PageSetupDialog();
            setupDialog.PageSettings = new PageSettings();
            setupDialog.PrinterSettings = new PrinterSettings();
            setupDialog.ShowNetwork = false;

            if (setupDialog.ShowDialog()== DialogResult.OK) 
            {
                settings = setupDialog.PrinterSettings;
            }
            

        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDialog print = new PrintDialog();
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = "Print";
            print.Document = printDoc;
            print.AllowSelection = true;
            print.AllowSomePages = true;

            if (print.ShowDialog() == DialogResult.OK) 
            {
                if(settings == null) 
                {
                    printDoc.Print();
                }
                else 
                {
                    printDoc.DefaultPageSettings.PrinterSettings = settings;
                    printDoc.Print();
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to save the file?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(result == DialogResult.Yes) 
            {
                saveAsToolStripMenuItem.PerformClick();
                this.Close();
            }
            else 
            {
                this.Close();
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Undo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            string txt = textBox1.SelectedText;
            Clipboard.SetText(txt);
            textBox1.SelectedText = string.Empty;
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string txt = textBox1.SelectedText;
            Clipboard.SetText(txt);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + Clipboard.GetText();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectedText = string.Empty;
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.FileName = $"https://google.com/search?q={textBox1.SelectedText}";
            process.Start();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(textBox1);
            form.ShowDialog();
            FindToolString = textBox1.SelectedText;
            int j = textBox1.Text.IndexOf(FindToolString);

            char key = FindToolString[0];
            string text = textBox1.Text;

            int index = 0;
            foreach (var i in text)
            {
                if (i == key)
                {
                    textBox1.Select(index, FindToolString.Count());
                    string val = textBox1.SelectedText;
                    textBox1.Select(0, 0);
                    if (val == FindToolString)
                    {
                        findnext_list.Add(index);
                    }
                }
                index++;
            }
            textBox1.Select(j, FindToolString.Count());
        }

        private void findNextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try 
            {
                textBox1.Select(findnext_list[findnext_count], FindToolString.Count());
                if (findnext_count + 1 <= findnext_list.Count)
                {
                    findnext_count++;
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("There is no such string!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void findPreviuosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try 
            {
                findnext_count = findnext_list.Count-1;
                textBox1.Select(findnext_list[findnext_count], FindToolString.Count());
                if (findnext_count - 1 >= 0)
                {
                    findnext_count--;
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("There is no such string!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3(textBox1);
            form.ShowDialog();
        }

        private void goToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4(textBox1);
            form.ShowDialog();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void timeAndDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + DateTime.Now.ToString();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK) 
            {
                textBox1.Font = fontDialog.Font;
            }
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var currentsize = textBox1.Font.Size;
            currentsize += 3.0f;
            textBox1.Font = new Font(textBox1.Font.FontFamily, currentsize);
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var currentsize = textBox1.Font.Size;
            currentsize -= 3.0f;
            textBox1.Font = new Font(textBox1.Font.FontFamily, currentsize);
        }

        private void restoreDefaultZoomSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Font = new Font(textBox1.Font.FontFamily, this.currentsize);
        }

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (statusStrip1.Visible) 
            {
                statusStrip1.Visible = false;
            }
            else 
            {
                statusStrip1.Visible=true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel4.Text = textBox1.Text.Count().ToString();
            toolStripStatusLabel2.Text = textBox1.Lines.Count().ToString();
        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.FileName = "https://google.com/search?q=отримання+довідки+з+програми+блокнот+у+windows";
            process.Start();
        }

        private void colorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog()==DialogResult.OK) 
            {
                textBox1.ForeColor = dialog.Color;
            }
        }

        private void backGroundColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.BackColor = dialog.Color;
            }
        }
    }
}