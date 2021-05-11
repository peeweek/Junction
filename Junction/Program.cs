using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Junction
{
    static class Program
    {
        /// <summary>
        /// Main entrypoint of application
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            Application.EnableVisualStyles();

            if (args.Length == 0)
            {
                MessageBox.Show("Usage : Junction.exe [/F] <SourceDirectory/File>", "Junction Usage", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (args[0] == "/F")
            {
                string sourceFile = string.Join(" ", args, 1, args.Length - 1);
                if (File.Exists(sourceFile))
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.FileName = Path.GetFileName(sourceFile);
                    saveFileDialog.Title = "Save a reference to " + sourceFile;
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {

                        if (File.Exists(saveFileDialog.FileName))
                        {
                            MessageBox.Show("Target file already exists : " + saveFileDialog.FileName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {

                            string command = "mklink \"" + saveFileDialog.FileName + "\" \"" + sourceFile + "\"";
                            ProcessStartInfo process = new ProcessStartInfo("cmd.exe", "/c " + command);
                            process.CreateNoWindow = true;
                            process.UseShellExecute = true;
                            process.Verb = "runas";
                            Process.Start(process);
                            Process.Start("explorer.exe", $"/root,\"{Path.GetDirectoryName(saveFileDialog.FileName)}\"");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid File : " + sourceFile, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                string sourceDirectory = string.Join(" ", args, 0, args.Length);

                if (Directory.Exists(sourceDirectory))
                {

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.FileName = Path.GetFileName(sourceDirectory);
                    saveFileDialog.Title = "Save a reference to " + sourceDirectory ;
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {

                        if (Directory.Exists(saveFileDialog.FileName))
                        {
                            MessageBox.Show("Target directory already exists : " + saveFileDialog.FileName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            string command = "mklink /j \"" + saveFileDialog.FileName + "\" \"" + sourceDirectory + "\"";
                            ProcessStartInfo process = new ProcessStartInfo("cmd.exe", "/c " + command);
                            process.CreateNoWindow = true;
                            Process.Start(process);
                            Process.Start("explorer.exe", $"/root,\"{saveFileDialog.FileName}\"");
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
