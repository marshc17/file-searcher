namespace FileSearcher
{
    partial class SearchTermDialog
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
            this.searchTermTextBox = new System.Windows.Forms.TextBox();
            this.searchTermTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.regularExpressionRadioButton = new System.Windows.Forms.RadioButton();
            this.textRadioButton = new System.Windows.Forms.RadioButton();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.searchTermTypeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchTermTextBox
            // 
            this.searchTermTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTermTextBox.Location = new System.Drawing.Point(13, 13);
            this.searchTermTextBox.Name = "searchTermTextBox";
            this.searchTermTextBox.Size = new System.Drawing.Size(359, 20);
            this.searchTermTextBox.TabIndex = 0;
            // 
            // searchTermTypeGroupBox
            // 
            this.searchTermTypeGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTermTypeGroupBox.Controls.Add(this.regularExpressionRadioButton);
            this.searchTermTypeGroupBox.Controls.Add(this.textRadioButton);
            this.searchTermTypeGroupBox.Location = new System.Drawing.Point(13, 40);
            this.searchTermTypeGroupBox.Name = "searchTermTypeGroupBox";
            this.searchTermTypeGroupBox.Size = new System.Drawing.Size(359, 65);
            this.searchTermTypeGroupBox.TabIndex = 1;
            this.searchTermTypeGroupBox.TabStop = false;
            this.searchTermTypeGroupBox.Text = "Search Term Type";
            // 
            // regularExpressionRadioButton
            // 
            this.regularExpressionRadioButton.AutoSize = true;
            this.regularExpressionRadioButton.Location = new System.Drawing.Point(6, 42);
            this.regularExpressionRadioButton.Name = "regularExpressionRadioButton";
            this.regularExpressionRadioButton.Size = new System.Drawing.Size(116, 17);
            this.regularExpressionRadioButton.TabIndex = 1;
            this.regularExpressionRadioButton.Text = "Regular Expression";
            this.regularExpressionRadioButton.UseVisualStyleBackColor = true;
            // 
            // textRadioButton
            // 
            this.textRadioButton.AutoSize = true;
            this.textRadioButton.Checked = true;
            this.textRadioButton.Location = new System.Drawing.Point(6, 19);
            this.textRadioButton.Name = "textRadioButton";
            this.textRadioButton.Size = new System.Drawing.Size(46, 17);
            this.textRadioButton.TabIndex = 0;
            this.textRadioButton.TabStop = true;
            this.textRadioButton.Text = "Text";
            this.textRadioButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(216, 111);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(297, 111);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // SearchTermDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 146);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.searchTermTypeGroupBox);
            this.Controls.Add(this.searchTermTextBox);
            this.MaximizeBox = false;
            this.Name = "SearchTermDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Search Term";
            this.searchTermTypeGroupBox.ResumeLayout(false);
            this.searchTermTypeGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchTermTextBox;
        private System.Windows.Forms.GroupBox searchTermTypeGroupBox;
        private System.Windows.Forms.RadioButton regularExpressionRadioButton;
        private System.Windows.Forms.RadioButton textRadioButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}