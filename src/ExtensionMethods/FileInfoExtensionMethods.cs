using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSearcher.ExtensionMethods
{
    public static class FileInfoExtensionMethods
    {
        public static void OpenInFileExplorerAndSelect(this FileInfo fileInfo)
        {
            var command = $"/select, \"{fileInfo.FullName}\"";
            Process.Start("explorer.exe", command);
        }
    }
}
