using FileSearcher.FileSearch.FileNameMatchingAlgorithms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSearcher.FileSearch.SearchAlgorithms.Events;
using FileSearcher.FileSearch.SearchAlgorithms.Algorithms;

namespace FileSearcher.FileSearch.SearchAlgorithms
{
    public abstract class FileSearchAlgorithm
    {
        public event CurrentSearchDirectoryChangedEventHandler CurrentSearchDirectoryChanged;
        public event FileMatchFoundEventHandler FileMatchFound;
        public event ProgressUpdatedEventHandler ProgressUpdated;
        public event Func<bool> CheckForCancellation;
        public int PercentageMaximum { get; set; } = 100;

        private readonly IEnumerable<FileNameMatchingAlgorithm> fileNameMatchingAlgorithms;
        private long totalFileCount;
        private long currentFileCount;
        private string currentDirectory;

        public FileSearchAlgorithm(IEnumerable<FileNameMatchingAlgorithm> fileNameMatchingAlgorithms)
        {
            this.fileNameMatchingAlgorithms = fileNameMatchingAlgorithms;
        }

        public void Run(IEnumerable<DirectoryInfo> rootFolders)
        {
            totalFileCount = GetTotalFileCount(rootFolders);
            currentFileCount = 0;

            // Implement the alogirthm separately for each root directory.
            foreach (var directoryInfo in rootFolders)
            {
                SearchDirectory(directoryInfo, out bool cancelSearch);

                if (cancelSearch)
                {
                    return;
                }
            }
        }

        protected abstract void SearchDirectory(DirectoryInfo directoryInfo, out bool cancelSearch);

        protected void ProcessFile(FileInfo fileInfo, out bool cancelSearch)
        {
            // Check if the process running this algorithm would like to cancel it early.
            if (CheckForCancellation())
            {
                cancelSearch = true;
                return;
            }

            IncrementProgress();
            HandleDirectoryChanges(fileInfo);

            // Run each each file name matching algorithm this search alogorithm has been configured to use
            // against the current file and alert the outer process if the file matched any of them.
            foreach (var nameMatchingAlgorithm in fileNameMatchingAlgorithms)
            {
                if (nameMatchingAlgorithm.IsMatch(fileInfo.Name))
                {
                    FileMatchFound?.Invoke(this, new FileMatchFoundEventArgs(fileInfo));
                    break;
                }
            }

            cancelSearch = false;
        }

        private void IncrementProgress()
        {
            ++currentFileCount;

            var percentage = (int)((currentFileCount * PercentageMaximum) / totalFileCount);

            ProgressUpdated?.Invoke(this, new ProgressUpdatedEventArgs(percentage));
        }

        private long GetTotalFileCount(IEnumerable<DirectoryInfo> rootFolders)
        {
            // Count the files across all the directories to search
            return rootFolders
                .AsParallel()
                .SelectMany(rootFolder => rootFolder.EnumerateFiles("*", SearchOption.AllDirectories))
                .Count();
        }

        private void HandleDirectoryChanges(FileInfo fileInfo)
        {
            if (fileInfo.DirectoryName != currentDirectory)
            {
                currentDirectory = fileInfo.DirectoryName;
                CurrentSearchDirectoryChanged?.Invoke(this, new CurrentSearchDirectoryChangedEventArgs(currentDirectory));
            }
        }
    }
}
