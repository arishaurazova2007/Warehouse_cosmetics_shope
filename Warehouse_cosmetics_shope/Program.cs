using System;
using System.Windows.Forms;
using Warehouse_cosmetics_shope;

namespace  Warehouse_cosmetics_shope
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}