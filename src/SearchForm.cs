using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSearcher
{
    public partial class SearchForm : Form
    {
        private FileSearcher fileSearcher;

        public SearchForm(IEnumerable<string> folderPaths, IEnumerable<SearchTerm> searchTerms, SearchType searchType)
        {
            InitializeComponent();

            Text = AppConfiguration.AppTitle;

            InitializeFileSearcher(folderPaths, searchTerms, searchType);
            fileSearcher.StartSearchAsync();
        }

        public void InitializeFileSearcher(IEnumerable<string> folderPaths, IEnumerable<SearchTerm> searchTerms, SearchType searchType)
        {
            fileSearcher = new FileSearcher(folderPaths, searchTerms, searchType);

            fileSearcher.ProgressChanged += (object sender, ProgressChangedEventArgs e) =>
            {
                progressBar.Value = e.ProgressPercentage;
                currentFolderLabel.Text = (string)e.UserState;
            };

            fileSearcher.RunWorkerCompleted += (object sender, RunWorkerCompletedEventArgs e) =>
            {
                currentFolderLabel.Text = "All done!";
                pauseResumeButton.Enabled = false;
                progressBar.Value = progressBar.Maximum;
            };

            progressBar.Maximum = 100;
            progressBar.Step = 1;
            progressBar.Value = 0;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pauseResumeButton_Click(object sender, EventArgs e)
        {
            fileSearcher.CancelSearch();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            var result = MessageBox.Show(
                "Are you sure you'd like to cancel this search?",
                AppConfiguration.AppTitle,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }

            fileSearcher.CancelSearch();
        }
    }
}
