using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSearcher.FileSearch.FileNameMatchingAlgorithms;
using FileSearcher.FileSearch.SearchAlgorithms.Algorithms;

namespace FileSearcher.FileSearch.SearchAlgorithms
{
    public static class FileSearchAlgorithmFactory
    {
        public static FileSearchAlgorithm Create(SearchType searchType, IEnumerable<FileNameMatchingAlgorithm> fileNameMatchingAlgorithms)
        {
            switch (searchType)
            {
                case SearchType.DepthFirstSearch:
                    return new DepthFirstFileSearchAlgorithm(fileNameMatchingAlgorithms);

                case SearchType.BreadthFirstSearch:
                    return new BreadthFirstFileSearchAlgorithm(fileNameMatchingAlgorithms);

                default:
                    throw new ArgumentException($"{searchType.ToString()} is not a supported search type.");
            }
        }
    }
}
