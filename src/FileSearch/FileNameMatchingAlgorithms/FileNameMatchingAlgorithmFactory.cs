using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSearcher.FileSearch.FileNameMatchingAlgorithms.Alogrithms;

namespace FileSearcher.FileSearch.FileNameMatchingAlgorithms
{
    public static class FileNameMatchingAlgorithmFactory
    {
        public static FileNameMatchingAlgorithm Create(SearchTerm searchTerm)
        {
            switch (searchTerm.SearchTermType)
            {
                case SearchTermType.Text:
                    return new TextFileNameMatchingAlgorithm(searchTerm.SearchTermText);

                case SearchTermType.RegularExpression:
                    return new RegularExpressionFileNameMatchingAlgorithm(searchTerm.SearchTermText);

                default:
                    throw new ArgumentException($"{searchTerm.SearchTermType.ToString()} is not a supported search term type.");
            }
        }
    }
}
