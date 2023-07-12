using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ResourceHunter;
using ResourceHunter.Contracts;

namespace ResourceHunter.Tests
{
    [TestClass()]
    public class FolderHelperTests
    {
        private string _testRootFolder = "Output";
        private string lang = "en";
        Mock<FolderHelper> folderhelper = new Mock<FolderHelper>();

        [TestInitialize()]
        public void Startup()
        {
            if (Directory.Exists(_testRootFolder))
            {
                Directory.Delete(_testRootFolder, true);
            }
        }

        [TestMethod()]
        public void CreateiOSTest()
        {
            folderhelper.Object.CreateiOS(lang);

            Assert.IsTrue(Directory.Exists(_testRootFolder));
            Assert.IsTrue(Directory.Exists(_testRootFolder + @"/iOS"));
            Assert.IsTrue(Directory.Exists(_testRootFolder + @"/iOS/" + lang + ".lproj"));
        }

        [TestMethod()]
        public void CreateAndroidTest()
        {
            folderhelper.Object.CreateAndroid(lang);

            Assert.IsTrue(Directory.Exists(_testRootFolder));
            Assert.IsTrue(Directory.Exists(_testRootFolder + @"/Android"));
            Assert.IsTrue(Directory.Exists(_testRootFolder + @"/Android/values-" + lang));
        }
    }
}





