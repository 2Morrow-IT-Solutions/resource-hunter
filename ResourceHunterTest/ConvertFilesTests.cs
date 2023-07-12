using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResourceHunter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ResourceHunter.Tests
{
    [TestClass()]
    public class ConvertFilesTests
    {
        ConvertFiles convertFiles = new ConvertFiles();
        string filePathAndroid = "OutputFiles/filetestAndroid";
        string filePathIOS = "OutputFiles/filetestiOS";
        int selectList = 1;

        //for Android

        [TestInitialize()]
        public void Startup()
        {
            //if (File.Exists(filePathAndroid))
            //{
            //    File.Delete(filePathAndroid);
            //}

            //if (File.Exists(filePathIOS))
            //{
            //    File.Delete(filePathIOS);
            //}
        }

        [TestMethod()]
        public void CreateAndWriteXMLTest_CheckIfFileIsCreated()
        {
            convertFiles.CreateAndWriteXML(selectList, filePathAndroid);
            bool check = File.Exists(filePathAndroid);

            Assert.IsTrue(check);
        }

        [TestMethod()]
        public void CreateAndWriteXMLTest_CheckIfFileHasContent()
        {
            if (!(File.Exists(filePathAndroid)))
            { File.Create(filePathAndroid); }

            bool check = false;

            if (new FileInfo(filePathAndroid).Length > 10)
            {
                check = true;
            }

            Assert.IsTrue(check);
        }

        /// for IOS
        [TestMethod()]
        public void CreateAndWriteStringsTest_CheckIfFileIsCreated()
        {
            convertFiles.CreateAndWriteStrings(selectList, filePathIOS);
            bool check = File.Exists(filePathIOS);

            Assert.IsTrue(check);
        }

        [TestMethod()]
        public void CreateAndWriteStringsTest_CheckIfFileHasContent()
        {
            if (!(File.Exists(filePathIOS)))
            { File.Create(filePathIOS); }
            

            bool check = false;

            if (new FileInfo(filePathIOS).Length > 10)
            {
                check = true;
            }

            Assert.IsTrue(check);
        }
    }
}