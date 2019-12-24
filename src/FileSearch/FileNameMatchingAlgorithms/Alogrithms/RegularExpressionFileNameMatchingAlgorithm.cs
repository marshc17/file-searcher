using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileSearcher.FileSearch.FileNameMatchingAlgorithms.Alogrithms
{
    public class RegularExpressionFileNameMatchingAlgorithm : FileNameMatchingAlgorithm
    {
        private readonly Regex regex;

        public RegularExpressionFileNameMatchingAlgorithm(string searchTerm)
            : base(searchTerm)
        {
            regex = new Regex(searchTerm, RegexOptions.Compiled);
        }

        public override bool IsMatch(string fileName)
        {
            return regex.IsMatch(fileName);
        }
    }
}
