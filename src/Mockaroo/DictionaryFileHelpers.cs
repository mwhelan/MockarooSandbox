using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Mockaroo
{
    public class DictionaryFileHelpers
    {
        public void MergeFiles(string folderPath)
        {
            var directory = new DirectoryInfo(folderPath);
            var words = new List<string>();
            var files = directory.GetFiles("*.txt");
            foreach (var file in files)
            {
                words.AddRange(File.ReadAllLines(file.FullName));
            }

            var distinct = words.Distinct().ToList();
            var fileName = Path.Combine(folderPath, Guid.NewGuid() + ".txt");
            File.WriteAllLines(fileName, distinct);

            Console.WriteLine("Count: {0}", distinct.Count);
            Console.ReadLine();
        }
    }
}