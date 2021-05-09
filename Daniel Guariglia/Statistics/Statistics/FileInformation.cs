using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace statisticsOOP.DanielGuariglia
{
    public class FileInformation
    {
        private static string FILENAME = "statFile.txt";
        private static string currentPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            //Path.GetPathRoot(Environment.SystemDirectory);
        public static readonly FileInformation STATFILE = new FileInformation(currentPath, '|', FILENAME);
        public static IEnumerable<FileInformation> Values
        {
            get
            {
                yield return STATFILE;
            }
        }

        public string FilePath { get; private set; }
        public char FileSeparator { get; private set; }
        public string FileName { get; private set; }


        FileInformation(string path, char sep, string fileName) =>
            (FilePath, FileSeparator, FileName) = (path, sep, fileName);
    }
}

