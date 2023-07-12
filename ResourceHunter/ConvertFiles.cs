﻿using ResourceHunter.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Unicode;

namespace ResourceHunter
{
    public class ConvertFiles : IConvertFiles
    {
        private static DirectoryInfo mainDirectory = new DirectoryInfo(@"Input");
        private static string fileName = mainDirectory.GetFiles().First().FullName;
        private static readonly IImportFiles importFiles = new ImportFiles(fileName);

        private static void CreateFile(String path)
        {
            if (!File.Exists(path))
            {
                File.Create(path);
            }
        }

        public void CreateAndWriteXML(int index, string filePath)
        {
            var datas = importFiles.ReadExcell(index);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            FileStream fs = new FileStream(filePath, FileMode.Create);
            StreamWriter w = new StreamWriter(fs, Encoding.UTF8);


            w.WriteLine(@"<?xml version=""1.0"" encoding=""utf-8"" ?>");
            w.WriteLine("<resources> \n");

            for (int i = 1; i < datas.Item1.Count; i++)
            {
                string writeItem = datas.Item2[i];
                if (datas.Item2[i].EndsWith(" ")) { writeItem = datas.Item2[i].Replace(datas.Item2[i], datas.Item2[i].TrimEnd() + @"\u0020"); }
                w.WriteLine($"    <string name=\"{datas.Item1[i]}\">{writeItem}</string>");
            }

            w.WriteLine("</resources>");
            w.Flush();
            w.Close();
            fs.Close();
        }

        public void CreateAndWriteStrings(int index, string filePath)
        {
            var datas = importFiles.ReadExcell(index);
            FileStream fs = new FileStream(filePath, FileMode.Create);
            StreamWriter w = new StreamWriter(fs, Encoding.UTF8);

            for (int i = 1; i < datas.Item1.Count; i++)
            {
                w.WriteLine($" \"{datas.Item1[i]}\" = \"{datas.Item2[i]}\"; ");
            }
            w.Flush();
            w.Close();
            fs.Close();
        }

        public int LanguagesCount()
        {
            return importFiles.ReadExcell(1).Item3;
        }

        public string LanguagesName(int i)
        {
            return importFiles.ReadExcell(i).Item2[0];
        }
    }
}