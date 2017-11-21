using System;
using System.Windows.Forms;
using DeskFrameLib;
namespace DeskFrame
{
    /// <summary>
    /// Defualt frame view and reference implementation.
    /// </summary>
    public class DefualtFrameView : IDeskFrameView
    {
        public Form view { get; set; }
        public string uid { get; set; }
        public string descriptor { get; set; }
        public string author { get; set; }

        public DefualtFrameView()
        {
            // Todo: Init.
            view = new GenericView();
            uid = "0";
            descriptor = "The generic view.";
            author = "The author";
        }

        ~DefualtFrameView()
        {
            // Todo: Deconstruct.
        }
        
        public bool CloseUp(Form activeForm)
        {
            // Do Nothing.
            return true;
        }

        public bool Init(Form activeForm)
        {
            // Do nothing.
            return true;
        }
    }
}
