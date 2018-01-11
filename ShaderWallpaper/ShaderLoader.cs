using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeskFrameLib;

namespace ShaderWallpaper
{
    public class ShaderLoader : IDeskFrameView
    {

        Form IDeskFrameView.view
        {
            get => new ShaderRenderer();
        }

        string IDeskFrameView.uid
        {
            get => "Shader Renderer";
        }

        string IDeskFrameView.descriptor
        {
            get => "Shader Renderer";
        }

        string IDeskFrameView.author
        {
            get => "hello world author";
        }
    }
}
