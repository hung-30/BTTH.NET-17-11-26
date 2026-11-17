using RETAILSALESSYSTEM.GUI;

namespace RETAILSALESSYSTEM
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Sửa dòng này thành FormMain
            Application.Run(new GUI.FormMain());
        }
    }
}