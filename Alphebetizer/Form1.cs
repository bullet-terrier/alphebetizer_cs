using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Alphebetizer_Core;

namespace Alphebetizer
{
    public partial class Form1 : Form
    {
        int fontsize { get; set; }
        int lines_per_box { get; set; }
        int chars_per_width { get; set; }

        private string openfilename { get; set; }
        private string savefilename { get; set; }

        private int textbox1leftmargin { get; set; }
        private int textbox1topmargin { get; set; }
        private int textbox1rightmargin { get; set; }
        private int textbox1bottommargin { get; set; }

        /*
        private int button1leftmargin { get; set; }
        private int button1topmargin { get; set; }
        private int button1rightmargin { get; set; }
        private int button1bottommargin { get; set; }

        private int button2leftmargin { get; set; }
        private int button2topmargin { get; set; }
        private int button2rightmargin { get; set; }
        private int button2bottommargin { get; set; }
        */
        private int progressbar1leftmargin { get; set; }
        private int progressbar1topmargin { get; set; }
        private int progressbar1rightmargin { get; set; }
        private int progressbar1bottommargin { get; set; }

        private bool progressbar_last_status = false;

        // need to do some math to maintain the aspect ratio.
        public Form1()
        {
            savefilename = null;
            InitializeComponent();
            this.fontsize = this.textBox1.Font.Height;
            this.lines_per_box = this.textBox1.Height / this.fontsize;
            //this.button1.Text = "Alphebetize";
            //this.button2.Text = "Browse";
            this.progressBar1.Visible = false;
            this.textbox1leftmargin = -1*(this.Left - this.textBox1.Left);
            this.textbox1rightmargin = this.Width - this.textBox1.Width; // 
            this.textbox1topmargin = -1*(this.Top - this.textBox1.Top);
            this.textbox1bottommargin = this.Height - this.textBox1.Height;

            textBox1.Width = this.Width - textbox1rightmargin;
            textBox1.Height = this.Height - textbox1bottommargin;

            this.progressBar1.Visible = false;
            this.progressbar1leftmargin = -1 * (this.Left - this.progressBar1.Left);
            this.progressbar1rightmargin = this.Width - this.progressBar1.Width; // 
            this.progressbar1topmargin = -1 * (this.Top - this.progressBar1.Top);
            this.progressbar1bottommargin = this.Height - this.progressBar1.Height;


            //this.textBox1.Text= $"Bottom: {textbox1bottommargin}\r\nLeft: {textbox1leftmargin}\r\nRight: {textbox1rightmargin}\r\nTop: {textbox1topmargin}\r\nprogressbar:\r\nLeft:{progressbar1leftmargin}\r\nTop:{progressbar1topmargin}\r\nRight:{progressbar1rightmargin}\r\nBottom:{progressbar1bottommargin}";

            //this.alphebetizeToolStripMenuItem.Visible = false; // for now.

            #region handler definitions


            this.ResizeEnd += on_form_resize;
            this.Resize += on_resize;
            #endregion

        }

        private void on_resize(object caller, EventArgs e)
        {
            this.textBox1.Visible = false;
            this.progressbar_last_status = progressBar1.Visible;
            this.progressBar1.Visible = false;
        }

        private void on_form_resize(object caller, EventArgs e)
        {
            //textBox1.Left = this.Left - textbox1leftmargin;
            textBox1.Width = this.Width - textbox1rightmargin;
            textBox1.Height = this.Height - textbox1bottommargin;
            progressBar1.Width = this.Width - progressbar1rightmargin;
            progressBar1.Height = this.Height - progressbar1bottommargin;
            //textBox1.Top = this.Top - textbox1topmargin;

            this.textBox1.Visible = true;
            this.progressBar1.Visible = progressbar_last_status;


        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("File Clicked");
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var x = this.openFileDialog1.ShowDialog();
            openfilename = openFileDialog1.FileName;
            textBox1.Text = File.ReadAllText(openfilename);
            
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(savefilename is null)
            {
                if(openfilename is null)
                {
                    savefilename = $"C:/Users/{Environment.UserName}/My Documents/Alphebetizer_Save_{DateTime.Now.ToString("%Y-%m-%d_%H%M")}.txt";
                }
                else
                {
                    savefilename = openfilename;
                }
            }
            File.WriteAllText(savefilename, this.textBox1.Text);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.saveFileDialog1.ShowDialog();
            savefilename = saveFileDialog1.FileName;
        }

        private void alphebetizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Not ready yet!");
            Alphebetizer_Core.Alphebetizer al = new Alphebetizer_Core.Alphebetizer();
            List<string> toalphabetize = textBox1.Text.Split('\n').ToList();
            toalphabetize = al.alphebetize(toalphabetize);
            textBox1.Text = "";
            foreach(string a in toalphabetize)
            {
                this.textBox1.Text += $"{a}\n";

            }
        }
    }
}
