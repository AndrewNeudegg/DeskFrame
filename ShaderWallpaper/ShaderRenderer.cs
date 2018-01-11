using SharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShaderWallpaper
{
    public partial class ShaderRenderer : Form
    {
        public ShaderRenderer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the OpenGLInitialized event of the openGLControl1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void openGLControl1_OpenGLInitialized(object sender, EventArgs e)
        {
            scene.Initialise(openGLControl1.OpenGL, Width, Height);
        }

        /// <summary>
        /// Handles the OpenGLDraw event of the openGLControl1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="RenderEventArgs"/> instance containing the event data.</param>
        private void openGLControl1_OpenGLDraw(object sender, RenderEventArgs args)
        {
            //  Draw the scene.
            scene.Draw(openGLControl1.OpenGL);
        }



        /// <summary>
        /// The scene that we are rendering.
        /// </summary>
        private readonly Scene scene = new Scene();

        private void openGLControl1_Load(object sender, EventArgs e)
        {
        }

        private void ShaderRenderer_Load(object sender, EventArgs e)
        {

        }
    }
}
