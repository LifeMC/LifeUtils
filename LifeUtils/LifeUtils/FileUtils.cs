#region Header

// 
//        LifeUtils - LifeUtils - FileUtils.cs
//                  23.10.2018 08:11

#endregion

namespace LifeUtils
{
    #region Imports

    using System;
    using System.IO;
    using Microsoft.Win32;

    #endregion

    internal static class FileUtils
    {
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