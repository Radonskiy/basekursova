using System;
using System.Windows.Forms;

namespace ChildrenGardenInterface
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Database.InitializeDatabase();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}