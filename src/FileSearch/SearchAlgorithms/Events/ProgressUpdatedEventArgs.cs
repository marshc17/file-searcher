using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSearcher.FileSearch.SearchAlgorithms.Events
{
    public class ProgressUpdatedEventArgs : EventArgs
    {
        public PercentProgressType Type { get; }
        public int? PercentComplete { get; }

        public ProgressUpdatedEventArgs(PercentProgressType type, int? percentComplete)
        {
            Type = type;
            PercentComplete = percentComplete;
        }

        public ProgressUpdatedEventArgs(PercentProgressType type)
            : this(type, null) { }
    }
}
