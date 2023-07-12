using ResourceHunter.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ResourceHunter
{
    public class FolderHelper : IFolderHelper
    {
        private string _rootFolder = "Output";
        private void CreateFolder(String path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public void CreateiOS(string lang)
        {
            CreateFolder(_rootFolder);
            CreateFolder(_rootFolder + @"/iOS");
            CreateFolder(_rootFolder + @"/iOS/" + lang + ".lproj");
        }

        public void CreateAndroid(string lang)
        {
            CreateFolder(_rootFolder);
            CreateFolder(_rootFolder + @"/Android");
            CreateFolder(_rootFolder + @"/Android/values-" + lang);
        }
    }
}
