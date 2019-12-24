using FileSearcher.FileSearch.FileNameMatchingAlgorithms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSearcher.FileSearch.SearchAlgorithms.Algorithms
{
    public class BreadthFirstFileSearchAlgorithm : FileSearchAlgorithm
    {
        public BreadthFirstFileSearchAlgorithm(IEnumerable<FileNameMatchingAlgorithm> fileNameMatchingAlgorithms)
            : base(fileNameMatchingAlgorithms) { }

        protected override void SearchDirectory(DirectoryInfo directoryInfo, out bool cancelSearch)
        {
            throw new NotImplementedException();
        }
    }
}
