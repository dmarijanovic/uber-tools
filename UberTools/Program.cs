using System;
using System.Collections.Generic;
using System.Windows.Forms;

using DamirM.CommonLibrary;

namespace NTHTools
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {

            try
            {
                Log.SaveLocal = true;
                WindowsFormsSynchronizationContext.AutoInstall = false;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Main());
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Fatal error please report to damir.marijanovic@gmail.com", "Fatal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.IO.StreamWriter sw = new System.IO.StreamWriter("error.txt", false);
                sw.WriteLine("Time:");
                sw.WriteLine(DateTime.Now);
                sw.WriteLine("Source:");
                sw.WriteLine(ex.Source);
                sw.WriteLine("Message:");
                sw.WriteLine(ex.Message);
                sw.WriteLine("InnerException:");
                sw.WriteLine(ex.InnerException);
                sw.WriteLine("StackTrace:");
                sw.WriteLine(ex.StackTrace);
                sw.Close();
                
                System.Diagnostics.Process process = System.Diagnostics.Process.Start("notepad", string.Format("{0}", "error.txt"));
                if (process != null)
                {
                    Application.Exit();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show(ex.StackTrace, "Fatal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
