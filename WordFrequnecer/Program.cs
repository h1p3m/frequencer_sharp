using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
namespace WordFrequnecer
{
    public class Program
    {
        public void countWordsInFile(string file, Dictionary<string, int> words)
        {
            var content = File.ReadAllText(file);

            var wordPattern = new Regex(@"\w+");

            foreach (Match match in wordPattern.Matches(content))
            {
                int currentCount = 0;
                words.TryGetValue(match.Value, out currentCount);

                currentCount++;
                words[match.Value] = currentCount;
            }
        }
        public List<string> FindFiles(string dir)
        {
            //(@"C:\TestDirectory"
            DirectoryInfo dinfo = new DirectoryInfo(dir);
            FileInfo[] Files = dinfo.GetFiles("*.txt");
            List<string> files=new List<string>();
            foreach (FileInfo file in Files)
            {
               files.Add(file.FullName);
            }
            return files;
        }

        public Dictionary<string, int> CountDir (string dir)
        {
            List<string> dirs = FindFiles(dir);
            var words = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);

            foreach (string str in dirs)
            {
                countWordsInFile(str, words);

            }

            return words;
        }
        public void PrintDict(Dictionary<string, int> words) {
            foreach (KeyValuePair<string, int> kvp in words)
            {
          
                Console.WriteLine("{0} - {1}", kvp.Key, kvp.Value);
            }
        }
        public bool SaveToFile(Dictionary<string, int> words, string path)
        {
         
            using (StreamWriter sw = File.AppendText(path+@"\counter.txt"))
            {
                foreach (KeyValuePair<string, int> kvp in words)
                {

                    sw.WriteLine("{0} - {1}", kvp.Key, kvp.Value);
                }
            }

            return true;
        }
        static void Main(string[] args)
        {
            Program pr = new Program();
            Console.WriteLine("Write directory and press Enter:");
            string dir = Console.ReadLine();
            var words = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);
            words=pr.CountDir(dir);
            pr.PrintDict(words);

            pr.SaveToFile(words,dir);
        }
    }
}
