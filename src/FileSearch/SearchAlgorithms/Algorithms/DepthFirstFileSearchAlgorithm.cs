using FileSearcher.ExtensionMethods;
using FileSearcher.FileSearch.FileNameMatchingAlgorithms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSearcher.FileSearch.SearchAlgorithms.Algorithms
{
    public class DepthFirstFileSearchAlgorithm : FileSearchAlgorithm
    {
        public DepthFirstFileSearchAlgorithm(IEnumerable<FileNameMatchingAlgorithm> fileNameMatchingAlgorithms)
            : base(fileNameMatchingAlgorithms) { }

        protected override void SearchDirectory(DirectoryInfo directoryInfo, out bool cancelSearch)
        {
            // Do "depth-first" by diving into all the sub-directories before checking this directory.
            var subDirectories = directoryInfo.GetDirectories();

            foreach (var subDirectory in subDirectories)
            {
                // Skip over symlinks to avoid potential circular loops.
                if (subDirectory.IsSymLink())
                {
                    continue;
                }

                SearchDirectory(subDirectory, out cancelSearch);

                if (cancelSearch)
                {
                    return;
                }
            }

            // Once the subdirectories are searched, search the files in this directory.
            var files = directoryInfo.GetFiles();

            foreach (var fileInfo in files)
            {
                ProcessFile(fileInfo, out cancelSearch);
                
                if (cancelSearch)
                {
                    return;
                }

                System.Threading.Thread.Sleep(1000);
            }

            cancelSearch = false;
        }
    }
}
