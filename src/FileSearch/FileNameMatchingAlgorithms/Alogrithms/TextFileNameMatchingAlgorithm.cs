using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSearcher.FileSearch.FileNameMatchingAlgorithms.Alogrithms
{
    public class TextFileNameMatchingAlgorithm : FileNameMatchingAlgorithm
    {
        public TextFileNameMatchingAlgorithm(string searchTerm)
            : base(searchTerm) { }

        public override bool IsMatch(string fileName)
        {
            return fileName.Contains(SearchTerm);
        }
    }
}
