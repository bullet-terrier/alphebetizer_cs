using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// I'll continue on this later - add in the other functionality that was inherently in the "Alphebetizer" application.
namespace Alphebetizer.Views.Elements
{
    public partial class Alphebetizer : dotnet_forms.Base_Form
    {
        protected ToolStripMenuItem alphebetizeToolStripMenuItem { get; set; } // this will have to be established during the constructor.
        public Alphebetizer()
        {
            InitializeComponent();
            this.editToolStripMenuItem.DropDownItems.Add("Alphebetize");
            this.textBox1.Multiline = true;
            this.textBox1.ScrollBars = ScrollBars.Both;
            this.textBox1.Width = this.panel1.Width;
            this.textBox1.Height = this.panel1.Height;

            foreach (ToolStripItem m in MainMenuStrip.Items)
            {
                Console.WriteLine(m.Text);
            }
            // we'll see how this renders.

            #region event handler mapping

            this.panel1.Resize += this.resize_textbox_1;
            this.editToolStripMenuItem.DropDownItems[0].Click += alphebetize_event_handler;

            #endregion
        }

        #region event handlers (private)
        private void alphebetize_event_handler(object Sender, EventArgs e)
        {
            string accumulator = ""; // we'll reconstitute the textbox text here. By doing this in the handler we could also leverage a progressbar display.
            var reseq = new Alphebetizer_Core.Alphebetizer();
            this.textBox1.Text += "\n";
            foreach (string a in reseq.alphebetize(this.textBox1.Text.Split('\n').ToList<string>()))
            {
                Console.WriteLine(a);
                accumulator += $"{a}\n"; // since we removed *ONLY* the \n character, let's replace it.
            }
            // the easy version 

            // 
            return;
        }

        private void resize_textbox_1(object Sender, EventArgs e)
        {
            this.textBox1.Width = this.panel1.Width;
            this.textBox1.Height = this.panel1.Height;
        }
        #endregion
    }
}
