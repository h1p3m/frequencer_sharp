using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WordFrequnecer; //word frequencer 
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
 
        [TestMethod]
        public void TestMethod1()
        {
            WordFrequnecer.Program pr = new Program();

            string dir =@"F:\Users\Admin\Documents";
            var words = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);
            words = pr.CountDir(dir);
          //  pr.PrintDict(words);
            if (words == null)
            {
                Assert.Inconclusive();
            }
        }
        [TestMethod]
        public void TestMethod2()
        {
            WordFrequnecer.Program pr = new Program();
            string dir = Directory.GetCurrentDirectory();
            var words = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);
            words = pr.CountDir(dir);
         //  pr.PrintDict(words);
            Assert.IsNotNull(words);

        }
        [TestMethod]
        public void TestMethod3()
        {
            WordFrequnecer.Program pr = new Program();

            string dir = Directory.GetCurrentDirectory();
            var words = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);
            words = pr.CountDir(dir);

            string fileresult = Directory.GetCurrentDirectory();

            Assert.AreNotSame(dir, fileresult);

        }
        [TestMethod]
        public void TestMethod4()
        {

            WordFrequnecer.Program pr = new Program();

            string dir = @"F:\Users\Admin\Documents";
            var words = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);
            words = pr.CountDir(dir);

            string fileresult = Directory.GetCurrentDirectory();
            Assert.IsTrue(pr.SaveToFile(words, fileresult));

        }
        [TestMethod]
        public void TestMethod5()
        {
            WordFrequnecer.Program pr = new Program();
            string dir = Directory.GetCurrentDirectory();
            var words = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);
            words = pr.CountDir(dir);
          
            Assert.IsTrue(pr.SaveToFile(words, dir));

        }
        [TestMethod]
        public void TestMethod6()
        {
            WordFrequnecer.Program pr = new Program();
            string dir = Directory.GetCurrentDirectory();
            var words = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);
            words = pr.CountDir(dir);
            Assert.IsTrue(words.Count() > 0);

        }
        [TestMethod]
        public void TestMethod7()
        {
            WordFrequnecer.Program pr = new Program();
            string dir = Directory.GetCurrentDirectory();
            var words = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);
            words = pr.CountDir(dir);

            Assert.IsTrue(words.First().Value > words.Last().Value);
        }
        [TestMethod]
        public void TestMethod8()
        {
            WordFrequnecer.Program pr = new Program();
            string dir = Directory.GetCurrentDirectory();
            var words = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);
            words = pr.CountDir(dir);
            Assert.IsFalse(!(words.First().Value > words.Last().Value));
        }
        [TestMethod]
        public void TestMethod9()
        {
            WordFrequnecer.Program pr = new Program();
            //check directory
            string path = Directory.GetCurrentDirectory();
            //DirectoryInfo dinfo = new DirectoryInfo(path);
           
            Assert.IsFalse(pr.FindFiles(path) == null);
        }
        [TestMethod]
        public void TestMethod10()
        {
            WordFrequnecer.Program pr = new Program();
        //    string dir = Directory.GetCurrentDirectory();
            string dir = @"F:\Users\Admin\Documents";
            Assert.IsFalse(!Directory.Exists(dir));



        }


    }
}
