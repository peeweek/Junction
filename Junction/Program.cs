using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;

namespace Junction
{
    static class Program
    {

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            Application.EnableVisualStyles();
            if (args.Length == 0)
            {
                MessageBox.Show("Usage : Junction.exe <SourceDirectory>", "Junction Usage", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string sourceDirectory = string.Join(" ", args, 0, args.Length);

                if (System.IO.Directory.Exists(sourceDirectory))
                {

                    System.Windows.Forms.SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Title = "Save a reference to " + sourceDirectory ;
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {

                        if (System.IO.Directory.Exists(saveFileDialog.FileName))
                        {

                            MessageBox.Show("Target directory already exists : " + saveFileDialog.FileName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            string command = "mklink /j \"" + saveFileDialog.FileName + "\" \"" + sourceDirectory + "\"";
                            ProcessStartInfo process = new ProcessStartInfo("cmd.exe", "/c " + command);
                            process.CreateNoWindow = true;
                            Process.Start(process);
                            Process.Start("explorer.exe", saveFileDialog.FileName);

                        }

                    }

                }
                else
                {

                    MessageBox.Show("Invalid Directory : " + sourceDirectory, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            
        }
    }
}
