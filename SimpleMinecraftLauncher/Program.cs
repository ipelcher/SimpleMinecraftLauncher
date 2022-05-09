using System;
using System.Windows.Forms;

namespace SimpleMinecraftLauncher
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Console.WriteLine(CmlLib._Test.tstr); // for test
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
