using ResourceHunter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResourceHunter.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using Microsoft.VisualBasic;

namespace ResourceHunter.Tests
{
    [TestClass()]
    public class ExportFilesTests
    {
        private int columncount = 5;
        Mock<IConvertFiles> convertFilesMock = new Mock<IConvertFiles>();
        Mock<IFolderHelper> folderHelperMock = new Mock<IFolderHelper>();
        ExportFiles exportFiles;

        [TestInitialize()]
        public void Startup()
        {
            convertFilesMock.Setup(x => x.LanguagesCount()).Returns(columncount);
        }

        [TestMethod()]
        public void ExportAndroidTest()
        {
            exportFiles = new ExportFiles(convertFilesMock.Object, folderHelperMock.Object);
            exportFiles.ExportAndroid();
            convertFilesMock.Verify(x => x.CreateAndWriteXML(It.IsAny<int>(), It.IsAny<string>()), Times.Exactly(columncount - 1));
            folderHelperMock.Verify(x => x.CreateAndroid(It.IsAny<string>()), Times.Exactly(columncount - 1));
        }
       
        [TestMethod()]
        public void ExportiOSTest()
        {
            exportFiles = new ExportFiles(convertFilesMock.Object, folderHelperMock.Object);
            exportFiles.ExportiOS();
            convertFilesMock.Verify(x => x.CreateAndWriteStrings(It.IsAny<int>(), It.IsAny<string>()), Times.Exactly(columncount - 1));
            folderHelperMock.Verify(x => x.CreateiOS(It.IsAny<string>()), Times.Exactly(columncount - 1));
        }
    }
}