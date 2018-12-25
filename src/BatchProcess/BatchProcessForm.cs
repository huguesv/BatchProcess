// Copyright (c) Hugues Valois. All rights reserved.
// Licensed under the MIT license. See LICENSE in the project root for license information.

namespace Woohoo.BatchProcess
{
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;
    using Microsoft.WindowsAPICodePack.Taskbar;

    /// <summary>
    /// Main window.
    /// </summary>
    public partial class BatchProcessForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BatchProcessForm"/> class.
        /// </summary>
        public BatchProcessForm()
        {
            this.InitializeComponent();
            this.SetCaption();
            this.LoadPreferences();
        }

        private static string Quote(string val)
        {
            return "\"" + val + "\"";
        }

        private void SetCaption()
        {
            var version = (AssemblyFileVersionAttribute)Assembly.GetExecutingAssembly().GetCustomAttribute(typeof(AssemblyFileVersionAttribute));
            this.Text = string.Format(CultureInfo.CurrentCulture, Resources.ProductCaption, Resources.ProductTitle, version.Version);
        }

        private void LoadPreferences()
        {
            try
            {
                var prefs = BatchProcessPreferences.Load();

                this._executableFileTextBox.Text = prefs.Executable;
                this._parametersTextBox.Text = prefs.Parameters;
                this._showWindowCheckBox.Checked = prefs.ShowWindow;
                this._runInParallelCheckBox.Checked = prefs.Parallel;
            }
            catch (InvalidOperationException)
            {
            }
            catch (IOException)
            {
            }
        }

        private void SavePreferences()
        {
            try
            {
                var prefs = new BatchProcessPreferences()
                {
                    Executable = this._executableFileTextBox.Text,
                    Parameters = this._parametersTextBox.Text,
                    ShowWindow = this._showWindowCheckBox.Checked,
                    Parallel = this._runInParallelCheckBox.Checked,
                };

                prefs.Save();
            }
            catch (IOException)
            {
            }
        }

        private void OnAddFilesButtonClick(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog
            {
                Multiselect = true,
                Filter = Resources.FileFilterAll,
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this._filesListBox.Items.AddRange(dlg.FileNames);
            }
        }

        private void OnRemoveFilesButtonClick(object sender, EventArgs e)
        {
            foreach (var item in this._filesListBox.SelectedItems.Cast<string>().ToArray())
            {
                this._filesListBox.Items.Remove(item);
            }
        }

        private void OnClearFilesButtonClick(object sender, EventArgs e)
        {
            this._filesListBox.Items.Clear();
        }

        private void OnFilesListBoxDragDrop(object sender, DragEventArgs e)
        {
            Array array = (Array)e.Data.GetData(DataFormats.FileDrop);
            if (array != null)
            {
                foreach (var f in array)
                {
                    this._filesListBox.Items.Add(f);
                }
            }
        }

        private void OnFilesListBoxDragEnter(object sender, DragEventArgs e)
        {
            if (!this._addFilesButton.Enabled)
            {
                e.Effect = DragDropEffects.None;
            }
            else
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    e.Effect = DragDropEffects.Link;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
        }

        private void OnExecutableFileTextBoxDragDrop(object sender, DragEventArgs e)
        {
            Array array = (Array)e.Data.GetData(DataFormats.FileDrop);
            if (array != null)
            {
                string filePath = array.GetValue(0).ToString();

                this._executableFileTextBox.Text = filePath;
            }
        }

        private void OnExecutableFileTextBoxDragEnter(object sender, DragEventArgs e)
        {
            if (!this._addFilesButton.Enabled)
            {
                e.Effect = DragDropEffects.None;
            }
            else
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    e.Effect = DragDropEffects.Link;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
        }

        private void OnProcessButtonClick(object sender, EventArgs e)
        {
            var parallel = this._runInParallelCheckBox.Checked;
            var show = this._showWindowCheckBox.Checked;
            var executable = this._executableFileTextBox.Text.Trim();
            var parameters = this._parametersTextBox.Text.Trim();
            var files = this._filesListBox.Items.Cast<string>().ToArray();

            if (!File.Exists(executable))
            {
                MessageBox.Show(string.Format(CultureInfo.CurrentCulture, Resources.ExecutableDoesNotExist, executable), Resources.ProductTitle);
                return;
            }

            this.SavePreferences();

            this.EnableControls(working: true);

            this._backgroundWorker.RunWorkerAsync(new Tuple<bool, bool, string, string, string[]>(parallel, show, executable, parameters, files));
        }

        private void OnCancelButtonClick(object sender, EventArgs e)
        {
            this._cancelButton.Visible = true;
            this._cancelButton.Enabled = false;
            this._backgroundWorker.CancelAsync();
        }

        private void OnBackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            var arg = (Tuple<bool, bool, string, string, string[]>)e.Argument;
            this.ProcessFiles(arg.Item1, arg.Item2, arg.Item3, arg.Item4, arg.Item5);
        }

        private void ProcessFiles(bool parallel, bool show, string executable, string parameters, string[] files)
        {
            if (parameters.Length == 0)
            {
                parameters = Quote(ParameterTags.FilePath);
            }
            else if (!parameters.Contains(ParameterTags.FilePath) &&
                     !parameters.Contains(ParameterTags.FileName) &&
                     !parameters.Contains(ParameterTags.Name) &&
                     !parameters.Contains(ParameterTags.Ext) &&
                     !parameters.Contains(ParameterTags.Folder))
            {
                parameters = Quote(ParameterTags.FilePath) + " " + parameters;
            }

            var total = files.Length;
            for (var i = 0; i < total; i++)
            {
                this._backgroundWorker.ReportProgress((int)(i * 100.0 / total));

                if (this._backgroundWorker.CancellationPending)
                {
                    return;
                }

                var f = files[i];
                var args = parameters.Replace(ParameterTags.FilePath, f);
                args = args.Replace(ParameterTags.FileName, Path.GetFileName(f));
                args = args.Replace(ParameterTags.Name, Path.GetFileNameWithoutExtension(f));
                args = args.Replace(ParameterTags.Ext, Path.GetExtension(f));
                args = args.Replace(ParameterTags.Folder, Path.GetDirectoryName(f));

                var psi = new ProcessStartInfo(executable, args)
                {
                    UseShellExecute = false,
                    CreateNoWindow = !show,
                    WorkingDirectory = Path.GetDirectoryName(f),
                };

                var proc = Process.Start(psi);
                if (!parallel)
                {
                    proc.WaitForExit();
                }
            }

            this._backgroundWorker.ReportProgress(100);
        }

        private void OnBackgroundWorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this._progressBar.Value = e.ProgressPercentage;

            // Support taskbar progress bar for Windows 7 & later
            if (TaskbarManager.IsPlatformSupported)
            {
                TaskbarManager.Instance.SetProgressValue(e.ProgressPercentage, 100);
            }
        }

        private void OnBackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.EnableControls(working: false);
        }

        private void EnableControls(bool working)
        {
            this._addFilesButton.Enabled = !working;
            this._removeFilesButton.Enabled = !working;
            this._clearFilesButton.Enabled = !working;
            this._runInParallelCheckBox.Enabled = !working;
            this._showWindowCheckBox.Enabled = !working;
            this._executableFileTextBox.ReadOnly = working;
            this._parametersTextBox.ReadOnly = working;
            this._processButton.Visible = !working;
            this._progressBar.Visible = working;
            this._cancelButton.Visible = working;
            this._cancelButton.Enabled = working;
        }
    }
}
