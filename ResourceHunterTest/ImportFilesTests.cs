using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ResourceHunter;
using ResourceHunter.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceHunter.Tests
{
    [TestClass()]
    public class ImportFilesTests
    {
        static string fileName = "Languages.xlsx";
        static string fileNameTest = "wrongName";
        ImportFiles importFilesTest = new ImportFiles(fileName);
        int keycount = 1;

        [TestMethod()]
        public void ReadExcellTest_CheckReturnIsNotNull_ReturnTrue()
        {
            var keywordColumn = importFilesTest.ReadExcell(keycount).Item1;
            var languageColumn = importFilesTest.ReadExcell(keycount).Item2;
            int columnCount = importFilesTest.ReadExcell(1).Item3;

            Assert.IsNotNull(keywordColumn);
            Assert.IsNotNull(languageColumn);
            Assert.IsNotNull(columnCount);
        }

        //[TestMethod()]
        //public void ReadExcellTest_CheckIFimportFileNOK_ReturnTrue()
        //{
        //    ImportFiles importFilesTest2 = new ImportFiles(fileNameTest);
        //    var keywordColumn = importFilesTest2.ReadExcell(keycount).Item1;
        //    var languageColumn = importFilesTest2.ReadExcell(keycount).Item2;
        //    int columnCount = importFilesTest2.ReadExcell(1).Item3;

        //    Assert.AreEqual(columnCount, 0);
        //    Assert.IsNull(keywordColumn);
        //    Assert.IsNull(languageColumn);
        //}
    }
}