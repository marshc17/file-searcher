using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSearcher.FileSearch
{
    public class FileSearcherProgressInfo
    {
        public ProgressInfoType Type { get; set; }

        /// <summary>
        /// When Type = CurrentSearchDirectoryChanged:
        /// A string value representing the current directory path being searched.
        /// 
        /// When Type = FileMatchFound:
        /// A FileInfo object for the file that was matched.
        /// </summary>
        public object ProgressData { get; set; }
    }
}
