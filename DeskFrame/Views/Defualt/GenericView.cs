using System;
using System.Drawing;
using System.Windows.Forms;

namespace DeskFrame
{
    public partial class GenericView : Form
    {
        public GenericView()
        {
            InitializeComponent();
        }

        private void GenericView_Load(object sender, EventArgs e)
        {
            // StartPosition was set to FormStartPosition.Manual in the properties window.
            Rectangle screen = Screen.PrimaryScreen.Bounds;
            int w = screen.Width;
            int h = screen.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Do Nothing. It is not possible for this event to be triggered.
        }
    }
}
