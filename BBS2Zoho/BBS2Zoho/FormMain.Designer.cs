namespace BBS2Zoho
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.buttonConvert = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabelOpenPayment = new System.Windows.Forms.LinkLabel();
            this.progressBarMain = new System.Windows.Forms.ProgressBar();
            this.openFileDialogInput = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogOutput = new System.Windows.Forms.SaveFileDialog();
            this.backgroundWorkerProcess = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // buttonConvert
            // 
            this.buttonConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConvert.Location = new System.Drawing.Point(432, 84);
            this.buttonConvert.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(138, 42);
            this.buttonConvert.TabIndex = 0;
            this.buttonConvert.Text = "&Convert...";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Import all the payments in ";
            // 
            // linkLabelOpenPayment
            // 
            this.linkLabelOpenPayment.AutoSize = true;
            this.linkLabelOpenPayment.Location = new System.Drawing.Point(40, 193);
            this.linkLabelOpenPayment.Name = "linkLabelOpenPayment";
            this.linkLabelOpenPayment.Size = new System.Drawing.Size(480, 28);
            this.linkLabelOpenPayment.TabIndex = 2;
            this.linkLabelOpenPayment.TabStop = true;
            this.linkLabelOpenPayment.Text = "https://subscriptions.zoho.eu/app#/payments/import";
            this.linkLabelOpenPayment.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelOpenPayment_LinkClicked);
            // 
            // progressBarMain
            // 
            this.progressBarMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarMain.Location = new System.Drawing.Point(43, 46);
            this.progressBarMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.progressBarMain.Name = "progressBarMain";
            this.progressBarMain.Size = new System.Drawing.Size(527, 30);
            this.progressBarMain.TabIndex = 3;
            // 
            // openFileDialogInput
            // 
            this.openFileDialogInput.Filter = "OCR files|*.ocr|CSV files|*.csv|All files|*.*";
            this.openFileDialogInput.Title = "Input file";
            // 
            // saveFileDialogOutput
            // 
            this.saveFileDialogOutput.Filter = "CSV files|*.csv|All files|*.*";
            this.saveFileDialogOutput.Title = "Save output as";
            // 
            // backgroundWorkerProcess
            // 
            this.backgroundWorkerProcess.WorkerReportsProgress = true;
            this.backgroundWorkerProcess.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerProcess_DoWork);
            this.backgroundWorkerProcess.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerProcess_ProgressChanged);
            this.backgroundWorkerProcess.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerProcess_RunWorkerCompleted);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 265);
            this.Controls.Add(this.progressBarMain);
            this.Controls.Add(this.linkLabelOpenPayment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonConvert);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "BBS to Zoho payments converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConvert;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabelOpenPayment;
        private System.Windows.Forms.ProgressBar progressBarMain;
        private System.Windows.Forms.OpenFileDialog openFileDialogInput;
        private System.Windows.Forms.SaveFileDialog saveFileDialogOutput;
        private System.ComponentModel.BackgroundWorker backgroundWorkerProcess;
    }
}

