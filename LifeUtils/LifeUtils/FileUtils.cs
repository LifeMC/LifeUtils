#region Header

// 
//        LifeUtils - LifeUtils - FileUtils.cs
//                  24.10.2018 03:24

#endregion

namespace LifeUtils
{
    #region Imports

    using System;
    using System.IO;
    using Microsoft.Win32;

    #endregion

    /// <summary>
    /// File or folder utilities for C#.
    /// </summary>
    internal static class FileUtils
    {
        /// <summary>
        /// Checks if a file exists in the given path.
        /// If path is null or empty, false is returned.
        /// Returns false in any exception / error.
        /// </summary>
        /// <param name="path">The path to check.</param>
        /// <returns>True if a file exists in the given path.</returns>
        internal static bool FileExists(string path)
        {
            if (string.IsNullOrEmpty(path)) return false;
            try
            {
                return File.Exists(path);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Gets java installation directory of computer.
        /// Return value can be null. If it was null,
        /// we are unable to detect java installation path,
        /// so the computer doesn't have java or the path is unknown.
        /// </summary>
        /// <returns>The java installation path.</returns>
        internal static string GetJavaHome()
        {
            try
            {
                string environmentPath = Environment.GetEnvironmentVariable("JAVA_HOME");
                if (!string.IsNullOrEmpty(environmentPath) && !string.IsNullOrWhiteSpace(environmentPath))
                    return environmentPath;

                const string javaKey = "SOFTWARE\\JavaSoft\\Java Runtime Environment\\";
                using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(javaKey))
                {
                    string currentVersion = rk?.GetValue("CurrentVersion").ToString();
                    using (RegistryKey key = rk?.OpenSubKey(currentVersion))
                    {
                        return key?.GetValue("JavaHome").ToString();
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Deletes a directory in the given path.
        /// Includes all subdirectories and files, Ignores any exceptions / errors.
        /// </summary>
        /// <param name="path">The directories path to delete it.</param>
        internal static void DeleteDirectory(string path)
        {
            foreach (string directory in Directory.GetDirectories(path)) DeleteDirectory(directory);
            try
            {
                Directory.Delete(path, true);
            }
            catch (IOException)
            {
                try
                {
                    Directory.Delete(path, true);
                }
                catch
                {
                    /* ignored */
                }
            }
            catch (UnauthorizedAccessException)
            {
                try
                {
                    Directory.Delete(path, true);
                }
                catch
                {
                    /* ignored */
                }
            }
            catch
            {
                /* ignored */
            }
        }
    }
}