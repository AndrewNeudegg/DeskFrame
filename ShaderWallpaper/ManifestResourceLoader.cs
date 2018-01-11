using System.IO;
using System.Reflection;

namespace ShaderWallpaper
{
    /// <summary>
    /// A small helper class to load manifest resource files.
    /// </summary>
    public static class ManifestResourceLoader
    {
        /// <summary>
        /// Loads the named manifest resource as a text string.
        /// </summary>
        /// <param name="textFileName">Name of the text file.</param>
        /// <returns>The contents of the manifest resource.</returns>
        public static string LoadTextFile(string textFileName)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            var pathToDots = textFileName.Replace("\\", ".");
            var location = string.Format("{0}.{1}", executingAssembly.GetName().Name, pathToDots);


            using (var reader = new StreamReader(location))
            {
                return reader.ReadToEnd();
            }
        }
    }
}

