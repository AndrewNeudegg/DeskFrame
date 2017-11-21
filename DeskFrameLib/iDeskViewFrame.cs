using System.Windows.Forms;


namespace DeskFrameLib
{
    /// <summary>
    /// An interface for deriving custom desk frames. 
    /// </summary>
    public interface IDeskFrameView
    { 
        /// <summary>
        /// Property represents the view to be injected.
        /// </summary>
        Form view { get; set; }

        /// <summary>
        /// The unique identifier for this subclass.
        /// </summary>
        string uid { get; set; }

        /// <summary>
        /// A end user friendly description for this frame.
        /// </summary>
        string descriptor { get; set; }

        /// <summary>
        /// The author of this frame.
        /// </summary>
        string author { get; set; }

        /// <summary>
        /// Is called before init.
        /// </summary>
        /// <returns></returns>
        bool Init(Form activeForm);

        /// <summary>
        /// Is called before closing the form.
        /// </summary>
        /// <returns></returns>
        bool CloseUp(Form activeForm);
    }
}
