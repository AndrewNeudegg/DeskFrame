using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DeskFrameLib;

namespace DeskFramePluginLoader
{
    public class Loader
    {

        /// <summary>
        /// Entrypoint for loading plugins.
        /// </summary>
        /// <param name="_directory">Directory to search for files within.</param>
        /// <param name="_extension">The extension to filter by.</param>
        /// <returns>A collection of plugins.</returns>
        public static ICollection<IDeskFrameView> LoadPlugins(string _directory, string _extension)
        {
            var _files = FindFiles(_directory, _extension);
            var _assemblies = GetAssemblies(_files);
            var _types = ValidateTypes(_assemblies);
            return LoadPlugins(_types);
        }

        /// <summary>
        /// Entrypoint for loading plugins.
        /// </summary>
        /// <param name="_files">The file paths to load.</param>
        /// <returns>A collection of plugins.</returns>
        public static ICollection<IDeskFrameView> LoadPlugins(List<string> _files)
        {
            var _assemblies = GetAssemblies(_files);
            var _types = ValidateTypes(_assemblies);
            return LoadPlugins(_types);
        }



        /// <summary>
        /// Loads a list of files from a directory using a filter.
        /// </summary>
        /// <param name="path">A directory to load from. Defualts to the current directory.</param>
        /// <param name="ext">An extension to filter by, defualts to '*.dll'.</param>
        /// <returns></returns>
        public static List<string> FindFiles(string path = ".", string ext = "*.dll")
        {
            List<string> files = new List<string>();
            if (Directory.Exists(path))
            {
                files = Directory.GetFiles(path, ext).ToList<string>();
            }
            return files;
        }


        /// <summary>
        /// Loads assemblies from a file list.
        /// </summary>
        /// <param name="files">A list of files.</param>
        /// <returns>A list of activated assemblies.</returns>
        public static ICollection<Assembly> GetAssemblies(List<string> files)
        {
            // Return value.
            ICollection<Assembly> assemblies = new List<Assembly>(files.Count);
            // Check all files.
            foreach (var file in files)
            {
                // Load and add the assemblies.
                AssemblyName an = AssemblyName.GetAssemblyName(file);
                Assembly assembly = Assembly.Load(an);
                assemblies.Add(assembly);
            }
            return assemblies;
        }

        /// <summary>
        /// Validates the types of loaded files.
        /// </summary>
        /// <param name="assemblies">Requires a list of assemblies.</param>
        /// <returns>A list of types.</returns>
        public static ICollection<Type> ValidateTypes(ICollection<Assembly> assemblies)
        {
            // Proto type.
            Type _plugin = typeof(IDeskFrameView);
            // Prepare Return values.
            ICollection<Type> _pluginTypes = new List<Type>();
            // Loop over assemblies.
            foreach (Assembly assembly in assemblies)
            {
                if (assembly != null)
                {
                    Type[] types = assembly.GetTypes();
                    foreach (var type in types)
                    {
                        // Ignore proto plugins.
                        if (type.IsInterface || type.IsAbstract)
                        {
                            continue;
                        }
                        // Test whether we are happy to load this plugin.
                        else
                        {
                            // We are happy with these types.
                            if (type.GetInterface(_plugin.FullName) != null)
                            {
                                _pluginTypes.Add(type);
                            }
                        }
                    }
                }
            }
            return _pluginTypes;
        }


        /// <summary>
        /// Loads the plugins absoloutley.
        /// </summary>
        /// <param name="_pluginTypes">A list of the plugin types.</param>
        /// <returns>Returns a list of plugins.</returns>
        public static ICollection<DeskFrameLib.IDeskFrameView> LoadPlugins(ICollection<Type> _pluginTypes)
        {
            // Plugin Collection.
            ICollection<IDeskFrameView> plugins = new List<IDeskFrameView>(_pluginTypes.Count);
            foreach (Type type in _pluginTypes)
            {
                // Prepare loading.
                IDeskFrameView plugin = (IDeskFrameView)Activator.CreateInstance(type);
                plugins.Add(plugin);
            }
            return plugins;
        }

    }
}
