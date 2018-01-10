using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeskFrameLib;

namespace ExampleFrames
{
    public class Blank : IDeskFrameView
    {

        Form IDeskFrameView.view {
            get => new BlankWindow.BlankForm();
        }

        string IDeskFrameView.uid {
            get => "hello world";
        }

        string IDeskFrameView.descriptor {
            get => "hello world";
        }

        string IDeskFrameView.author {
            get => "hello world author";
        }
    }
}
