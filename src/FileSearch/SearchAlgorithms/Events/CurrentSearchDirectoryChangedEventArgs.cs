using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSearcher.FileSearch.SearchAlgorithms.Events
{
    public class CurrentSearchDirectoryChangedEventArgs : EventArgs
    {
        public string DirectoryPath { get; }

        public CurrentSearchDirectoryChangedEventArgs(string directoryPath)
        {
            DirectoryPath = directoryPath;
        }
    }
}
