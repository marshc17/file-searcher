using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileSearcher.FileSearch;
using FileSearcher.Configuration;
using FileSearcher.FileSearch.FileNameMatchingAlgorithms;
using FileSearcher.FileSearch.SearchAlgorithms;
using System.IO;

namespace FileSearcher.Forms
{
    public partial class SearchForm : Form
    {
        private FileSearcherBackgroundWorker fileSearcher;
        private bool isRunning = true;
        private bool resultsFound = false;

        public SearchForm(IEnumerable<string> folderPaths, IEnumerable<SearchTerm> searchTerms, SearchType searchType)
        {
            InitializeComponent();

            Text = AppConfiguration.AppTitle;

            InitializeResultsListView();

            InitializeFileSearcher(folderPaths, searchTerms, searchType);
            fileSearcher.StartSearchAsync();
        }

        private void InitializeResultsListView()
        {
            resultsListView.Columns.Add(new ColumnHeader()
            {
                Text = string.Empty
            });

            resultsListView.HeaderStyle = ColumnHeaderStyle.None;
            resultsListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void InitializeFileSearcher(IEnumerable<string> folderPaths, IEnumerable<SearchTerm> searchTerms, SearchType searchType)
        {
            fileSearcher = new FileSearcherBackgroundWorker(folderPaths, searchTerms, searchType);

            fileSearcher.ProgressChanged += OnProgressChanged;
            fileSearcher.RunWorkerCompleted += OnRunWorkerCompleted;

            progressBar.Maximum = 100;
            progressBar.Step = 1;
            progressBar.Value = 0;
        }

        private void OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var fileSearcherProgressInfo = (FileSearcherProgressInfo)e.UserState;

            switch (fileSearcherProgressInfo.Type)
            {
                case ProgressInfoType.PercentProgressUpdated:
                    HandlePercentProgressUpdate(e);
                    break;

                case ProgressInfoType.CurrentSearchDirectoryChanged:
                    HandleCurrentSearchDirectoryChanged(fileSearcherProgressInfo);
                    break;

                case ProgressInfoType.FileMatchFound:
                    HandleFileMatchFound(fileSearcherProgressInfo);
                    break;

                default:
                    throw new ArgumentException($"{fileSearcherProgressInfo.Type.ToString()} is not a supported progress info type.");
            }
        }

        private void HandlePercentProgressUpdate(ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void HandleCurrentSearchDirectoryChanged(FileSearcherProgressInfo fileSearcherProgressInfo)
        {
            currentFolderLabel.Text = (string)fileSearcherProgressInfo.ProgressData;
        }

        private void HandleFileMatchFound(FileSearcherProgressInfo fileSearcherProgressInfo)
        {
            var fileInfo = (FileInfo)fileSearcherProgressInfo.ProgressData;

            resultsListView.Items.Add(new ListViewItem(new string[]
            {
                fileInfo.Name,
                fileInfo.CreationTime.ToShortDateString(),
                fileInfo.LastWriteTime.ToShortDateString(),
                fileInfo.Extension,
                fileInfo.Length.ToString(),
                fileInfo.DirectoryName
            })
            {
                Tag = fileInfo
            });

            if (!resultsFound)
            {
                resultsFound = true;
                DisplayResultsViewHeaders();
            }
        }

        private void DisplayResultsViewHeaders()
        {
            resultsListView.Columns.Clear();

            resultsListView.Columns.Add("Name");
            resultsListView.Columns.Add("Date created");
            resultsListView.Columns.Add("Date modified");
            resultsListView.Columns.Add("File extension");
            resultsListView.Columns.Add("Size");
            resultsListView.Columns.Add("Folder path");

            resultsListView.HeaderStyle = ColumnHeaderStyle.Clickable;
            resultsListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
            {
                MessageBox.Show(e.Result.ToString(), AppConfiguration.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                currentFolderLabel.ForeColor = Color.Red;
                currentFolderLabel.Text = "Search aborted prematurely!";
            }
            else
            {
                currentFolderLabel.Text = "All done!";
            }
            
            progressBar.Value = progressBar.Maximum;
            isRunning = false;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            var message = isRunning
                ? "Are you sure you'd like to cancel this search?"
                : "Are you sure you'd like to discard these search results?";

            var result = MessageBox.Show(
                message,
                AppConfiguration.AppTitle,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

            fileSearcher.CancelSearch();
        }
    }
}
