using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSearcher.FileSearch.FileNameMatchingAlgorithms
{
    public abstract class FileNameMatchingAlgorithm
    {
        public string SearchTerm { get; }

        public FileNameMatchingAlgorithm(string searchTerm)
        {
            SearchTerm = searchTerm;
        }

        public abstract bool IsMatch(string fileName);
    }
}
