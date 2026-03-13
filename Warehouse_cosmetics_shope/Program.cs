using System;
using System.Windows.Forms;
using Warehouse;
using Warehouse_cosmetics_shop; 

namespace Warehouse_cosmetics_shop
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