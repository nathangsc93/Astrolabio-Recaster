using System.Runtime.InteropServices;

namespace Astrolabio_Recaster
{
    internal static class Program
    {
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern bool SetDllDirectory(string lpPathName);

        [STAThread]
        static void Main()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string nativeDir = Path.Combine(baseDir, "x64");

            if (Directory.Exists(nativeDir))
            {
                SetDllDirectory(nativeDir);
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}