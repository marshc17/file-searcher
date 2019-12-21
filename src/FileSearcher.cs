using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSearcher
{
    public class FileSearcher
    {
        private IEnumerable<DirectoryInfo> rootFolders;
        private IEnumerable<SearchTerm> searchTerms;
        private SearchType searchType;
        private int totalFileCount;
        private BackgroundWorker backgroundWorker = new BackgroundWorker();

        public event ProgressChangedEventHandler ProgressChanged;
        public event RunWorkerCompletedEventHandler RunWorkerCompleted;

        public FileSearcher(IEnumerable<string> folderPaths, IEnumerable<SearchTerm> searchTerms, SearchType searchType)
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

        public void StartSearchAsync()
        {
            // Count the files across all the directories to search
            totalFileCount = rootFolders
                .AsParallel()
                .SelectMany(rootFolder => rootFolder.EnumerateFiles("*", SearchOption.AllDirectories))
                .Count();

            // Start search the directories
            switch (searchType)
            {
                case SearchType.DepthFirstSearch:
                    backgroundWorker.DoWork += new DoWorkEventHandler(DoDepthFirstSearch);
                    break;

                case SearchType.BreadthFirstSearch:
                    backgroundWorker.DoWork += new DoWorkEventHandler(DoBreadthFirstSearch);
                    break;

                default:
                    throw new ArgumentException($"{searchType.ToString()} is not a supported search type.");
            }

            backgroundWorker.RunWorkerAsync();
        }

        public void CancelSearch()
        {
            backgroundWorker.CancelAsync();
        }

        private void DoDepthFirstSearch(object sender, DoWorkEventArgs e)
        {
            int fileCountProcessed = 0;

            while (fileCountProcessed < totalFileCount)
            {
                if (backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

                var percent = (fileCountProcessed * 100) / totalFileCount;
                backgroundWorker.ReportProgress(percent, $"Current/File/Path/{fileCountProcessed}");
                ++fileCountProcessed;
                System.Threading.Thread.Sleep(1000);
            }

            backgroundWorker.ReportProgress((fileCountProcessed * 100) / totalFileCount, $"Current/File/Path/{fileCountProcessed}");
            System.Threading.Thread.Sleep(1000);
        }

        private void DoBreadthFirstSearch(object sender, DoWorkEventArgs e)
        {
            throw new NotImplementedException();
        }

        private bool FileNameMatchesSearchTerm(string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
