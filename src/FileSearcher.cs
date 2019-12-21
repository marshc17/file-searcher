using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSearcher
{
    public class FileSearcher
    {
        private IEnumerable<DirectoryInfo> rootFolders;
        private IEnumerable<SearchTerm> searchTerms;
        private SearchType searchType;

        public int TotalSteps { get; private set; }
        public int CurrentStep { get; private set; }

        public FileSearcher(IEnumerable<string> folderPaths, IEnumerable<SearchTerm> searchTerms, SearchType searchType)
        {
            // Call ToList() to execute these enumerables so that these values are fully
            // calculated in this form's context before doing any parallel work on them.
            rootFolders = folderPaths
                .ToList()
                .Select(path => new DirectoryInfo(path));

            this.searchTerms = searchTerms.ToList();
            this.searchType = searchType;
        }

        public void StartSearch()
        {
            // Count the files across all the directories to search
            TotalSteps = rootFolders
                .AsParallel()
                .SelectMany(rootFolder => rootFolder.EnumerateFiles("*", SearchOption.AllDirectories))
                .Count();

            // Start search the directories
            switch (searchType)
            {
                case SearchType.DepthFirstSearch:
                    DoDepthFirstSearch();
                    break;

                case SearchType.BreadthFirstSearch:
                    DoBreadthFirstSearch();
                    break;

                default:
                    throw new ArgumentException($"{searchType.ToString()} is not a supported search type.");
            }
        }

        private void DoDepthFirstSearch()
        {
            throw new NotImplementedException();
        }

        private void DoBreadthFirstSearch()
        {
            throw new NotImplementedException();
        }

        private bool FileNameMatchesSearchTerm(string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
