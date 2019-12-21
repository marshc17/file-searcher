namespace FileSearcher
{
    partial class MainForm
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
            this.foldersGroupBox = new System.Windows.Forms.GroupBox();
            this.addFolderButton = new System.Windows.Forms.Button();
            this.removeFolderButton = new System.Windows.Forms.Button();
            this.foldersListView = new System.Windows.Forms.ListView();
            this.SearchTermsGroupBox = new System.Windows.Forms.GroupBox();
            this.removeSearchTermButton = new System.Windows.Forms.Button();
            this.addSearchTermButton = new System.Windows.Forms.Button();
            this.searchTermsListView = new System.Windows.Forms.ListView();
            this.searchTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.breadthFirstSearchRadioButton = new System.Windows.Forms.RadioButton();
            this.depthFirstSearchRadioButton = new System.Windows.Forms.RadioButton();
            this.searchButton = new System.Windows.Forms.Button();
            this.foldersGroupBox.SuspendLayout();
            this.SearchTermsGroupBox.SuspendLayout();
            this.searchTypeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // foldersGroupBox
            // 
            this.foldersGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.foldersGroupBox.Controls.Add(this.addFolderButton);
            this.foldersGroupBox.Controls.Add(this.removeFolderButton);
            this.foldersGroupBox.Controls.Add(this.foldersListView);
            this.foldersGroupBox.Location = new System.Drawing.Point(12, 12);
            this.foldersGroupBox.Name = "foldersGroupBox";
            this.foldersGroupBox.Size = new System.Drawing.Size(460, 155);
            this.foldersGroupBox.TabIndex = 0;
            this.foldersGroupBox.TabStop = false;
            this.foldersGroupBox.Text = "Root Folders to Search";
            // 
            // addFolderButton
            // 
            this.addFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addFolderButton.Location = new System.Drawing.Point(7, 126);
            this.addFolderButton.Name = "addFolderButton";
            this.addFolderButton.Size = new System.Drawing.Size(75, 23);
            this.addFolderButton.TabIndex = 1;
            this.addFolderButton.Text = "Add";
            this.addFolderButton.UseVisualStyleBackColor = true;
            this.addFolderButton.Click += new System.EventHandler(this.addFolderButton_Click);
            // 
            // removeFolderButton
            // 
            this.removeFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeFolderButton.Location = new System.Drawing.Point(88, 126);
            this.removeFolderButton.Name = "removeFolderButton";
            this.removeFolderButton.Size = new System.Drawing.Size(75, 23);
            this.removeFolderButton.TabIndex = 2;
            this.removeFolderButton.Text = "Remove";
            this.removeFolderButton.UseVisualStyleBackColor = true;
            this.removeFolderButton.Click += new System.EventHandler(this.removeFolderButton_Click);
            // 
            // foldersListView
            // 
            this.foldersListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.foldersListView.Location = new System.Drawing.Point(7, 20);
            this.foldersListView.Name = "foldersListView";
            this.foldersListView.Size = new System.Drawing.Size(447, 100);
            this.foldersListView.TabIndex = 0;
            this.foldersListView.UseCompatibleStateImageBehavior = false;
            this.foldersListView.View = System.Windows.Forms.View.Details;
            // 
            // SearchTermsGroupBox
            // 
            this.SearchTermsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchTermsGroupBox.Controls.Add(this.removeSearchTermButton);
            this.SearchTermsGroupBox.Controls.Add(this.addSearchTermButton);
            this.SearchTermsGroupBox.Controls.Add(this.searchTermsListView);
            this.SearchTermsGroupBox.Location = new System.Drawing.Point(12, 173);
            this.SearchTermsGroupBox.Name = "SearchTermsGroupBox";
            this.SearchTermsGroupBox.Size = new System.Drawing.Size(460, 155);
            this.SearchTermsGroupBox.TabIndex = 1;
            this.SearchTermsGroupBox.TabStop = false;
            this.SearchTermsGroupBox.Text = "Search Terms";
            // 
            // removeSearchTermButton
            // 
            this.removeSearchTermButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeSearchTermButton.Location = new System.Drawing.Point(88, 126);
            this.removeSearchTermButton.Name = "removeSearchTermButton";
            this.removeSearchTermButton.Size = new System.Drawing.Size(75, 23);
            this.removeSearchTermButton.TabIndex = 2;
            this.removeSearchTermButton.Text = "Remove";
            this.removeSearchTermButton.UseVisualStyleBackColor = true;
            this.removeSearchTermButton.Click += new System.EventHandler(this.removeSearchTermButton_Click);
            // 
            // addSearchTermButton
            // 
            this.addSearchTermButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addSearchTermButton.Location = new System.Drawing.Point(7, 126);
            this.addSearchTermButton.Name = "addSearchTermButton";
            this.addSearchTermButton.Size = new System.Drawing.Size(75, 23);
            this.addSearchTermButton.TabIndex = 1;
            this.addSearchTermButton.Text = "Add";
            this.addSearchTermButton.UseVisualStyleBackColor = true;
            this.addSearchTermButton.Click += new System.EventHandler(this.addSearchTermButton_Click);
            // 
            // searchTermsListView
            // 
            this.searchTermsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTermsListView.Location = new System.Drawing.Point(7, 20);
            this.searchTermsListView.Name = "searchTermsListView";
            this.searchTermsListView.Size = new System.Drawing.Size(447, 100);
            this.searchTermsListView.TabIndex = 0;
            this.searchTermsListView.UseCompatibleStateImageBehavior = false;
            this.searchTermsListView.View = System.Windows.Forms.View.Details;
            // 
            // searchTypeGroupBox
            // 
            this.searchTypeGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTypeGroupBox.Controls.Add(this.breadthFirstSearchRadioButton);
            this.searchTypeGroupBox.Controls.Add(this.depthFirstSearchRadioButton);
            this.searchTypeGroupBox.Location = new System.Drawing.Point(12, 334);
            this.searchTypeGroupBox.Name = "searchTypeGroupBox";
            this.searchTypeGroupBox.Size = new System.Drawing.Size(460, 65);
            this.searchTypeGroupBox.TabIndex = 2;
            this.searchTypeGroupBox.TabStop = false;
            this.searchTypeGroupBox.Text = "Search Type";
            // 
            // breadthFirstSearchRadioButton
            // 
            this.breadthFirstSearchRadioButton.AutoSize = true;
            this.breadthFirstSearchRadioButton.Location = new System.Drawing.Point(6, 42);
            this.breadthFirstSearchRadioButton.Name = "breadthFirstSearchRadioButton";
            this.breadthFirstSearchRadioButton.Size = new System.Drawing.Size(121, 17);
            this.breadthFirstSearchRadioButton.TabIndex = 1;
            this.breadthFirstSearchRadioButton.TabStop = true;
            this.breadthFirstSearchRadioButton.Text = "Breadth-First Search";
            this.breadthFirstSearchRadioButton.UseVisualStyleBackColor = true;
            // 
            // depthFirstSearchRadioButton
            // 
            this.depthFirstSearchRadioButton.AutoSize = true;
            this.depthFirstSearchRadioButton.Checked = true;
            this.depthFirstSearchRadioButton.Location = new System.Drawing.Point(6, 19);
            this.depthFirstSearchRadioButton.Name = "depthFirstSearchRadioButton";
            this.depthFirstSearchRadioButton.Size = new System.Drawing.Size(113, 17);
            this.depthFirstSearchRadioButton.TabIndex = 0;
            this.depthFirstSearchRadioButton.TabStop = true;
            this.depthFirstSearchRadioButton.Text = "Depth-First Search";
            this.depthFirstSearchRadioButton.UseVisualStyleBackColor = true;
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.Location = new System.Drawing.Point(397, 405);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 3;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 440);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.searchTypeGroupBox);
            this.Controls.Add(this.SearchTermsGroupBox);
            this.Controls.Add(this.foldersGroupBox);
            this.MinimumSize = new System.Drawing.Size(209, 479);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.foldersGroupBox.ResumeLayout(false);
            this.SearchTermsGroupBox.ResumeLayout(false);
            this.searchTypeGroupBox.ResumeLayout(false);
            this.searchTypeGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox foldersGroupBox;
        private System.Windows.Forms.Button addFolderButton;
        private System.Windows.Forms.Button removeFolderButton;
        private System.Windows.Forms.ListView foldersListView;
        private System.Windows.Forms.GroupBox SearchTermsGroupBox;
        private System.Windows.Forms.ListView searchTermsListView;
        private System.Windows.Forms.Button removeSearchTermButton;
        private System.Windows.Forms.Button addSearchTermButton;
        private System.Windows.Forms.GroupBox searchTypeGroupBox;
        private System.Windows.Forms.RadioButton breadthFirstSearchRadioButton;
        private System.Windows.Forms.RadioButton depthFirstSearchRadioButton;
        private System.Windows.Forms.Button searchButton;
    }
}

