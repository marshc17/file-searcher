using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace FileSearcher.Configuration
{
    public class AppConfiguration
    {
        public static string AppTitle { get; } = ConfigurationManager.AppSettings["AppTitle"];
    }
}
