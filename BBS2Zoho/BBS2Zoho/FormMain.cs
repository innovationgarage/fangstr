using BBS2Zoho.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBS2Zoho
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void linkLabelOpenPayment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo(((LinkLabel)sender).Text) { UseShellExecute = true, Verb = "open" });
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialogInput.ShowDialog() == DialogResult.OK)
                {
                    if (saveFileDialogOutput.ShowDialog() == DialogResult.OK)
                    {
                        backgroundWorkerProcess.RunWorkerAsync(new Tuple<string, string>(openFileDialogInput.FileName, saveFileDialogOutput.FileName));
                        UpdateGui(true);
                    }
                }
            }catch
            {
                
            }
        }

        private void UpdateGui(bool isBusy)
        {
            buttonConvert.Enabled = !isBusy;

            progressBarMain.Value = 0;
            progressBarMain.Style = isBusy ? ProgressBarStyle.Marquee : ProgressBarStyle.Blocks;
        }

        int Map(int x, int in_min, int in_max, int out_min, int out_max)
        {
            return (int)((x - in_min) * (out_max - out_min) / (double)(in_max - in_min) + out_min);
        }
        private void backgroundWorkerProcess_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = "";

            try
            {
                var t = (Tuple<string, string>)e.Argument;
                var input = t.Item1;
                var output = t.Item2;
                var outputLines = new List<String>();

                // https://stackoverflow.com/questions/1389155/easiest-way-to-read-text-file-which-is-locked-by-another-application
                using (var fileStream = new FileStream(input, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var textReader = new StreamReader(fileStream))
                {
                    var content = textReader.ReadToEnd();
                    var matches = Regex.Matches(content, Settings.Default.InputRegex);

                    outputLines.Add(Settings.Default.OutputHeader);

                    var i = 0;
                    foreach (Match m in matches)
                    {
                        // Each transaction outputs one line
                        backgroundWorkerProcess.ReportProgress(Map(i++, 0, matches.Count, 10, 90));
                        var l = Regex.Replace(Settings.Default.OutputLine, @"\{(\w+)\}", match => MatchEvaluatorCustom(match, m));
                        outputLines.Add(l.Replace("#i#",""+(i+1)));

                    }

                    File.WriteAllLines(output, outputLines);
                    e.Result = Environment.NewLine + "Imported " + (outputLines.Count-1) + " item(s). ";
                }
            }
            catch (Exception ex)
            {
                backgroundWorkerProcess.ReportProgress(-1, ex.Message);
            }
            
        }

        private string MatchEvaluatorCustom(Match match, Match replacements)
        {
            return replacements.Groups[match.Groups[1].Value].Value;
        }

        private void backgroundWorkerProcess_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarMain.Style = ProgressBarStyle.Continuous;

            if (e.ProgressPercentage == -1)
                MessageBox.Show(e.UserState as string, "Error processing the input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                progressBarMain.Value = e.ProgressPercentage;
        }

        private void backgroundWorkerProcess_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UpdateGui(false);
            progressBarMain.Value = 100;

            if (MessageBox.Show("File created: " + saveFileDialogOutput.FileName + Environment.NewLine + e.Result as string + "Copy output path to clipboard?", "Done", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                Clipboard.SetText(saveFileDialogOutput.FileName);
        }
    }
}
