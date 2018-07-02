using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// make sure that all of the code falls within the dotnet_forms namespace.s
namespace dotnet_forms
{
    public partial class Base_Form : Form
    {
        // these protected methods will handle the 
        // difference in size of the panel and the main window.
        // you *should* be able to simply fill the panel with a component/components
        // in order to properly scale the sizes.
        // I'm not sure how the designer will handle the base_form as a dependency - but I guess we'll find out.
        protected int dHeight { get; set; }
        protected int dWidth { get; set; }

        public Base_Form()
        {

            #region form defaults
            this.Text = "Default_Form";
                       
            #endregion

            InitializeComponent();



            #region resize handler
            // slaving to the panel was successfull.
            this.progressBar1.Enabled = false;
            this.progressBar1.Visible = false; // hidiing it since it only exists for tsting purposes.
            //this.progressBar1.Height = panel1.Height;
            //this.progressBar1.Width = panel1.Width;
            //this.progressBar1.Maximum = 200;
            //this.progressBar1.Value = 100;
            this.Resize += base_form_resize_handle;



            #endregion

            #region remove prior to use/release
            // disable this when implementing this code in a production environment.
            //foreach(ToolStripMenuItem a in this.menuStrip1.Items)
            //{
            //    a.Visible = false; // makes the components invisible by default.
            //}

            // disable this as well - masking the status strip items.
            //foreach(ToolStripStatusLabel a in this.statusStrip1.Items)
            //{
            //    a.Visible = false;
            //}

            #endregion

            
        }

        protected void base_form_resize_handle(object Sender, EventArgs e)
        {
            this.panel1.Width = this.Width - dWidth;
            this.panel1.Height = this.Height - dHeight;

            // test

            //this.progressBar1.Height = panel1.Height;
            //this.progressBar1.Width = panel1.Width;
        }
    }
}
