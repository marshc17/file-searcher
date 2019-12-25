using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSearcher.ExtensionMethods
{
    public static class DirectoryInfoExtensionMethods
    {
        public static bool IsSymLink(this DirectoryInfo directoryInfo)
        {
            /*
             Made several attempts to reliable identify SymLinks (both soft and hard links for files and folders),
             but the Windows API is severely lacking support for this. No support in C#, and invoking Win32 API
             via kernel32.dll to detect reparse points does not work 100% reliably. Could only detect hard folder
             links that way (i.e. directory junctions). As a consequence test code was failing to detect soft symlink
             directories and looping endlessly when loops existed in file tree being searched. The implemented approach
             below is a crude but working solution. 'fsutil reparsepoint query' will return data for a directory that
             is a symlink and will return an error if it's a normal directory. A directory is determined to be a
             symlink if no error occurs when calling the command. Unfortunately the fsutil command doesn't utilize
             the standard error output, so the best way to detect an error is to search for the text "Error:" in the
             standard output text. This might fail in languages other than English or for unpredicted edge cases where
             successful symlink files report "Error:" somewhere in their output (though probably not likely to occur).
             */

            var symLinkCmd = $"fsutil reparsepoint query \"{directoryInfo.FullName}\"";

            var processStartInfo = new ProcessStartInfo("cmd", "/c" + symLinkCmd);
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.UseShellExecute = false;
            processStartInfo.CreateNoWindow = true;

            var process = new Process();
            process.StartInfo = processStartInfo;
            process.Start();

            var standardOutput = process.StandardOutput.ReadToEnd();

            // this command produces error output when a directory is not a symlink.
            return !standardOutput.Contains("Error:");
        }

        public static long CountFiles(this DirectoryInfo directoryInfo)
        {
            long fileCount = 0;

            // Exceptions are swallowed below simply to move on when we get UnauthorizedAccessException
            // or any other exception that wouldn't prevent us from counting the majority of files under
            // this directory. This method is designed ot count as many files as possible without being
            // fragile or terminated early and losing files in the count.

            try
            {
                fileCount = directoryInfo.GetFiles().LongLength;
            }
            catch { }

            // Do this in a separate try-catch to isolate failure as much as possible.
            // If there's a permissions issue with a particular file in this directory
            // but we can still dig deeper into sub-directories we want to not fail to
            // do so due to receiving an exception from that file.
            try
            {
                foreach (var subDirectoryInfo in directoryInfo.GetDirectories())
                {
                    fileCount += CountFiles(subDirectoryInfo);
                }
            }
            catch { }

            return fileCount;
        }
    }
}
