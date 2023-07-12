using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceHunter.Contracts
{
    public interface IConvertFiles
    {
        public void CreateAndWriteXML(int index, string filePatch);

        public void CreateAndWriteStrings(int index, string filePath);

        public int LanguagesCount();

        public string LanguagesName(int i);
    }
}
