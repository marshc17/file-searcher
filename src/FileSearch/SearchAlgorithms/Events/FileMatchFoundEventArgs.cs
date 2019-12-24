using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSearcher.FileSearch.SearchAlgorithms.Events
{
    public class FileMatchFoundEventArgs : EventArgs
    {
        public FileInfo FileInfo { get; }

        public FileMatchFoundEventArgs(FileInfo fileInfo)
        {
            FileInfo = fileInfo;
        }
    }
}
