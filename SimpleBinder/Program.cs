using System;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;
namespace SimpleBinder
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SimpleBinder());
        }
    }
}