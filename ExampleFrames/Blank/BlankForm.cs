using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExampleFrames.BlankWindow
{
    public partial class BlankForm : Form
    {
        public BlankForm()
        {
            InitializeComponent();
        }

        private void BlankForm_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Red;
        }
    }
}
