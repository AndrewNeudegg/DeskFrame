using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeskFrameLib;

namespace DeskFrame
{
    class Program
    {
        static Injector _injector = null;
        private static IDeskFrameView defualtView;

        /// <summary>
        /// Void Main: Entry point for the application.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Hello World Introduction!
            Injector injector = new Injector(defualtView);
            _injector = injector;
            injector.RunDeskFrame();            
        }

        
    }
}
