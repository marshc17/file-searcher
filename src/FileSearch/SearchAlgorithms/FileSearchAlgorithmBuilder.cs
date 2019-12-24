using FileSearcher.FileSearch.FileNameMatchingAlgorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSearcher.FileSearch.SearchAlgorithms
{
    public class FileSearchAlgorithmBuilder
    {
        private List<SearchTerm> searchTerms = new List<SearchTerm>();
        private readonly SearchType searchType;

        public FileSearchAlgorithmBuilder(SearchType searchType)
        {
            this.searchType = searchType;
        }

        public FileSearchAlgorithmBuilder AddSearchTerm(SearchTerm searchTerm)
        {
            searchTerms.Add(searchTerm);

            return this;
        }

        public FileSearchAlgorithm Build()
        {
            if (searchTerms == null)
            {
                throw new ArgumentException("Must add at least one search term.");
            }

            var fileNameMatchingAlgorithms = searchTerms.Select(searchTerm => FileNameMatchingAlgorithmFactory.Create(searchTerm));

            return FileSearchAlgorithmFactory.Create(searchType, fileNameMatchingAlgorithms);
        }
    }
}
