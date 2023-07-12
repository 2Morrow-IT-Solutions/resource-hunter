using ResourceHunter.Contracts;
using System.IO;

namespace ResourceHunter
{
    public class ExportFiles : IExportFiles
    {
        private IConvertFiles _convertFiles;
        private IFolderHelper _folderHelper;
        
        public ExportFiles(IConvertFiles convertFiles, IFolderHelper folderHelper)
        {
            _convertFiles = convertFiles;
            _folderHelper = folderHelper;
        }

        public void ExportAndroid()
        {
            if (Directory.Exists("Output/Android")) { Directory.Delete("Output/Android", true); }
            for (int i = 2; i <= _convertFiles.LanguagesCount(); i++)
            {
                string filePathAndroid = @"Output/Android/values-" + _convertFiles.LanguagesName(i) + @"/string.xml";
                _folderHelper.CreateAndroid(_convertFiles.LanguagesName(i));
                _convertFiles.CreateAndWriteXML(i, filePathAndroid);
            }
        }

        public void ExportiOS()
        {
            if (Directory.Exists("Output/iOS")) { Directory.Delete("Output/iOS", true); }
            for (int i = 2; i <= _convertFiles.LanguagesCount(); i++)
            {
                string filePathiOS = "Output/iOS/" + _convertFiles.LanguagesName(i) + @".lproj/Localizable.strings";
                _folderHelper.CreateiOS(_convertFiles.LanguagesName(i));
                _convertFiles.CreateAndWriteStrings(i, filePathiOS);
            }
        }
    }
}
