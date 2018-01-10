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
        Form view { get; }

        /// <summary>
        /// The unique identifier for this subclass.
        /// </summary>
        string uid { get; }

        /// <summary>
        /// A end user friendly description for this frame.
        /// </summary>
        string descriptor { get; }

        /// <summary>
        /// The author of this frame.
        /// </summary>
        string author { get; }
    }
}
