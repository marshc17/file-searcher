namespace FileSearcher
{
    partial class SearchForm
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.currentFolderLabel = new System.Windows.Forms.Label();
            this.resultsListView = new System.Windows.Forms.ListView();
            this.pauseResumeButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(13, 13);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(559, 23);
            this.progressBar.TabIndex = 0;
            // 
            // currentFolderLabel
            // 
            this.currentFolderLabel.AutoSize = true;
            this.currentFolderLabel.Location = new System.Drawing.Point(13, 43);
            this.currentFolderLabel.Name = "currentFolderLabel";
            this.currentFolderLabel.Size = new System.Drawing.Size(16, 13);
            this.currentFolderLabel.TabIndex = 1;
            this.currentFolderLabel.Text = "...";
            // 
            // resultsListView
            // 
            this.resultsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsListView.Location = new System.Drawing.Point(13, 60);
            this.resultsListView.Name = "resultsListView";
            this.resultsListView.Size = new System.Drawing.Size(559, 260);
            this.resultsListView.TabIndex = 2;
            this.resultsListView.UseCompatibleStateImageBehavior = false;
            // 
            // pauseResumeButton
            // 
            this.pauseResumeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pauseResumeButton.Location = new System.Drawing.Point(416, 326);
            this.pauseResumeButton.Name = "pauseResumeButton";
            this.pauseResumeButton.Size = new System.Drawing.Size(75, 23);
            this.pauseResumeButton.TabIndex = 3;
            this.pauseResumeButton.Text = "Pause";
            this.pauseResumeButton.UseVisualStyleBackColor = true;
            this.pauseResumeButton.Click += new System.EventHandler(this.pauseResumeButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(497, 326);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.pauseResumeButton);
            this.Controls.Add(this.resultsListView);
            this.Controls.Add(this.currentFolderLabel);
            this.Controls.Add(this.progressBar);
            this.MinimumSize = new System.Drawing.Size(200, 200);
            this.Name = "SearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label currentFolderLabel;
        private System.Windows.Forms.ListView resultsListView;
        private System.Windows.Forms.Button pauseResumeButton;
        private System.Windows.Forms.Button cancelButton;
    }
}