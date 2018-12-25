namespace Woohoo.BatchProcess
{
    partial class BatchProcessForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BatchProcessForm));
            this._filesListBox = new System.Windows.Forms.ListBox();
            this._parametersTextBox = new System.Windows.Forms.TextBox();
            this._executableFileTextBox = new System.Windows.Forms.TextBox();
            this._processButton = new System.Windows.Forms.Button();
            this._addFilesButton = new System.Windows.Forms.Button();
            this._removeFilesButton = new System.Windows.Forms.Button();
            this._progressBar = new System.Windows.Forms.ProgressBar();
            this._runInParallelCheckBox = new System.Windows.Forms.CheckBox();
            this._executableFileLabel = new System.Windows.Forms.Label();
            this._parametersLabel = new System.Windows.Forms.Label();
            this._clearFilesButton = new System.Windows.Forms.Button();
            this._backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this._cancelButton = new System.Windows.Forms.Button();
            this._showWindowCheckBox = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // _filesListBox
            // 
            this._filesListBox.AllowDrop = true;
            resources.ApplyResources(this._filesListBox, "_filesListBox");
            this._filesListBox.FormattingEnabled = true;
            this._filesListBox.Name = "_filesListBox";
            this._filesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this._filesListBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnFilesListBoxDragDrop);
            this._filesListBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnFilesListBoxDragEnter);
            // 
            // _parametersTextBox
            // 
            resources.ApplyResources(this._parametersTextBox, "_parametersTextBox");
            this._parametersTextBox.Name = "_parametersTextBox";
            this.toolTip1.SetToolTip(this._parametersTextBox, resources.GetString("_parametersTextBox.ToolTip"));
            // 
            // _executableFileTextBox
            // 
            this._executableFileTextBox.AllowDrop = true;
            resources.ApplyResources(this._executableFileTextBox, "_executableFileTextBox");
            this._executableFileTextBox.Name = "_executableFileTextBox";
            this._executableFileTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnExecutableFileTextBoxDragDrop);
            this._executableFileTextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnExecutableFileTextBoxDragEnter);
            // 
            // _processButton
            // 
            resources.ApplyResources(this._processButton, "_processButton");
            this._processButton.Name = "_processButton";
            this._processButton.UseVisualStyleBackColor = true;
            this._processButton.Click += new System.EventHandler(this.OnProcessButtonClick);
            // 
            // _addFilesButton
            // 
            resources.ApplyResources(this._addFilesButton, "_addFilesButton");
            this._addFilesButton.Name = "_addFilesButton";
            this._addFilesButton.UseVisualStyleBackColor = true;
            this._addFilesButton.Click += new System.EventHandler(this.OnAddFilesButtonClick);
            // 
            // _removeFilesButton
            // 
            resources.ApplyResources(this._removeFilesButton, "_removeFilesButton");
            this._removeFilesButton.Name = "_removeFilesButton";
            this._removeFilesButton.UseVisualStyleBackColor = true;
            this._removeFilesButton.Click += new System.EventHandler(this.OnRemoveFilesButtonClick);
            // 
            // _progressBar
            // 
            resources.ApplyResources(this._progressBar, "_progressBar");
            this._progressBar.Name = "_progressBar";
            // 
            // _runInParallelCheckBox
            // 
            resources.ApplyResources(this._runInParallelCheckBox, "_runInParallelCheckBox");
            this._runInParallelCheckBox.Name = "_runInParallelCheckBox";
            this._runInParallelCheckBox.UseVisualStyleBackColor = true;
            // 
            // _executableFileLabel
            // 
            resources.ApplyResources(this._executableFileLabel, "_executableFileLabel");
            this._executableFileLabel.Name = "_executableFileLabel";
            // 
            // _parametersLabel
            // 
            resources.ApplyResources(this._parametersLabel, "_parametersLabel");
            this._parametersLabel.Name = "_parametersLabel";
            // 
            // _clearFilesButton
            // 
            resources.ApplyResources(this._clearFilesButton, "_clearFilesButton");
            this._clearFilesButton.Name = "_clearFilesButton";
            this._clearFilesButton.UseVisualStyleBackColor = true;
            this._clearFilesButton.Click += new System.EventHandler(this.OnClearFilesButtonClick);
            // 
            // _backgroundWorker
            // 
            this._backgroundWorker.WorkerReportsProgress = true;
            this._backgroundWorker.WorkerSupportsCancellation = true;
            this._backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.OnBackgroundWorkerDoWork);
            this._backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.OnBackgroundWorkerProgressChanged);
            this._backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.OnBackgroundWorkerRunWorkerCompleted);
            // 
            // _cancelButton
            // 
            resources.ApplyResources(this._cancelButton, "_cancelButton");
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this.OnCancelButtonClick);
            // 
            // _showWindowCheckBox
            // 
            resources.ApplyResources(this._showWindowCheckBox, "_showWindowCheckBox");
            this._showWindowCheckBox.Name = "_showWindowCheckBox";
            this._showWindowCheckBox.UseVisualStyleBackColor = true;
            // 
            // BatchProcessForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._showWindowCheckBox);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._clearFilesButton);
            this.Controls.Add(this._parametersLabel);
            this.Controls.Add(this._executableFileLabel);
            this.Controls.Add(this._runInParallelCheckBox);
            this.Controls.Add(this._progressBar);
            this.Controls.Add(this._removeFilesButton);
            this.Controls.Add(this._addFilesButton);
            this.Controls.Add(this._processButton);
            this.Controls.Add(this._executableFileTextBox);
            this.Controls.Add(this._parametersTextBox);
            this.Controls.Add(this._filesListBox);
            this.Name = "BatchProcessForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox _filesListBox;
        private System.Windows.Forms.TextBox _parametersTextBox;
        private System.Windows.Forms.TextBox _executableFileTextBox;
        private System.Windows.Forms.Button _processButton;
        private System.Windows.Forms.Button _addFilesButton;
        private System.Windows.Forms.Button _removeFilesButton;
        private System.Windows.Forms.ProgressBar _progressBar;
        private System.Windows.Forms.CheckBox _runInParallelCheckBox;
        private System.Windows.Forms.Label _executableFileLabel;
        private System.Windows.Forms.Label _parametersLabel;
        private System.Windows.Forms.Button _clearFilesButton;
        private System.ComponentModel.BackgroundWorker _backgroundWorker;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.CheckBox _showWindowCheckBox;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

