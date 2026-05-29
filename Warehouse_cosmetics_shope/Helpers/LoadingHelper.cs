using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warehouse_cosmetics_shope.Helpers
{
    /// <summary>
    /// Показывает оверлей с крутилкой поверх формы на время выполнения задачи
    /// </summary>
    public static class LoadingHelper
    {
        public static async Task RunWithSpinner(Form parentForm, Panel spinnerPanel, Func<Task> action)
        {
            spinnerPanel.Visible = true;
            parentForm.UseWaitCursor = true;

            try
            {
                await action();
            }
            finally
            {
                spinnerPanel.Visible = false;
                parentForm.UseWaitCursor = false;
            }
        }
    }
}