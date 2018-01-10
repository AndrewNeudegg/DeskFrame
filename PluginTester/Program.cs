using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeskFramePluginLoader;


namespace PluginTester
{
    class Program
    {
        static void Main(string[] args)
        {
            // This is a demonstration application.
            string _current_directory = Directory.GetCurrentDirectory();
            string _ext = "*.dll";
            var _plugins = Loader.LoadPlugins(_current_directory, _ext);
            // Load assesment.
            Console.WriteLine("Detected {0} plugins.", _plugins.Count);
            Console.WriteLine("Attempting to Load plugins sequentially.");

            // Loop over plugins.
            foreach (var plugin in _plugins)
            {
                Console.WriteLine("Name: {0}", plugin.uid);
                Console.WriteLine("Author: {0}", plugin.author);
                Console.WriteLine("Description: {0}", plugin.descriptor);
                Form _thisForm = plugin.view;
                _thisForm.Show();
                Console.WriteLine("Plugin Loaded Successfully.\n\n");                
                _thisForm.Close();
            }
            // Exit stuff.
            Console.WriteLine("Press the any key.");
            Console.ReadKey();
        }
    }
}
