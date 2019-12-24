using FileSearcher.FileSearch.FileNameMatchingAlgorithms;
using FileSearcher.FileSearch.SearchAlgorithms;
using FileSearcher.FileSearch.SearchAlgorithms.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSearcher.FileSearch
{
    public class FileSearcherBackgroundWorker
    {
        private IEnumerable<DirectoryInfo> rootFolders;
        private IEnumerable<SearchTerm> searchTerms;
        private SearchType searchType;
        private BackgroundWorker backgroundWorker = new BackgroundWorker();

        public event ProgressChangedEventHandler ProgressChanged;
        public event RunWorkerCompletedEventHandler RunWorkerCompleted;

        public FileSearcherBackgroundWorker(IEnumerable<string> folderPaths, IEnumerable<SearchTerm> searchTerms, SearchType searchType)
        {
            // Call ToList() to execute these enumerables so that these values are fully
            // calculated in this form's context before doing any parallel work on them.
            rootFolders = folderPaths
                .ToList()
                .Select(path => new DirectoryInfo(path));

            this.searchTerms = searchTerms.ToList();
            this.searchType = searchType;

            InitializeBackgroundWorker();
        }

        public void StartSearchAsync()
        {
            var searchAlgorithmBuilder = new FileSearchAlgorithmBuilder(searchType);

            foreach (var searchTerm in searchTerms)
            {
                searchAlgorithmBuilder.AddSearchTerm(searchTerm);
            }

            var searchAlgorithm = searchAlgorithmBuilder.Build();

            searchAlgorithm.CurrentSearchDirectoryChanged += CurrentSearchDirectoryChanged;
            searchAlgorithm.FileMatchFound += FileMatchFound;
            searchAlgorithm.ProgressUpdated += ProgressUpdated;
            searchAlgorithm.CheckForCancellation += CheckForCancellation;

            backgroundWorker.DoWork += (object sender, DoWorkEventArgs e) =>
            {
                if (backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                try
                {
                    searchAlgorithm.Run(rootFolders);
                }
                catch (Exception exception)
                {
                    e.Result = exception;
                }
            };

            backgroundWorker.RunWorkerAsync();
        }

        public void CancelSearch()
        {
            backgroundWorker.CancelAsync();
        }

        private void InitializeBackgroundWorker()
        {
            backgroundWorker.ProgressChanged += (object sender, ProgressChangedEventArgs e) =>
            {
                ProgressChanged?.Invoke(sender, e);
            };

            backgroundWorker.RunWorkerCompleted += (object sender, RunWorkerCompletedEventArgs e) =>
            {
                RunWorkerCompleted?.Invoke(sender, e);
            };

            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
        }

        private void CurrentSearchDirectoryChanged(object sender, CurrentSearchDirectoryChangedEventArgs e)
        {
            backgroundWorker.ReportProgress(0, new FileSearcherProgressInfo()
            {
                Type = ProgressInfoType.CurrentSearchDirectoryChanged,
                ProgressData = e.DirectoryPath
            });
        }

        private void FileMatchFound(object sender, FileMatchFoundEventArgs e)
        {
            backgroundWorker.ReportProgress(0, new FileSearcherProgressInfo()
            {
                Type = ProgressInfoType.FileMatchFound,
                ProgressData = e.FileInfo
            });
        }

        private void ProgressUpdated(object sender, ProgressUpdatedEventArgs e)
        {
            backgroundWorker.ReportProgress(e.PercentComplete, new FileSearcherProgressInfo()
            {
                Type = ProgressInfoType.PercentProgressUpdated,
                ProgressData = null
            });
        }

        private bool CheckForCancellation()
        {
            return backgroundWorker.CancellationPending;
        }
    }
}
