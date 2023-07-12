using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceHunter.Contracts
{
    public interface IImportFiles
    {
        public (List<string>, List<string>, int) ReadExcell(int selectLang);
    }
}
