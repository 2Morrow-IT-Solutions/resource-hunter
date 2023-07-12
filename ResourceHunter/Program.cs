using ResourceHunter.Contracts;
using System;
using System.IO;
using System.Linq;

namespace ResourceHunter
{
    class Program
    {
        private const int ANDROID = 0;
        private const int IOS = 1;
        private const int ANDROID_IOS = 2;
        private const int CLOSE = -1;
        private static int platform;
        private static readonly IImportFiles importFiles = new ImportFiles(@"Input/Languages.xlsx");

        static void Main(string[] args)
        {
            ConvertFiles convertFiles = new ConvertFiles();
            FolderHelper folderHelper = new FolderHelper();
            ExportFiles exportfiles = new ExportFiles(convertFiles, folderHelper);

            if (!Directory.Exists(@"Input"))
            {
                Directory.CreateDirectory("Input");
            }

            if (!File.Exists(@"Input/Languages.xlsx"))
            {
                Console.WriteLine(@"FILE NOT FOUND. PLEASE MAKE SURE THAT THE INSERTED FILE IS NAMED 'Languages.xlsx'.");
                Console.ReadKey();
            }
            else
            {
                Console.Write("Languages found:");
                string languages = null;
                for (int i = 2; i <= importFiles.ReadExcell(1).Item3; i++)
                {
                    languages = languages + "," + importFiles.ReadExcell(i).Item2[0].ToString();
                }
                Console.Write(languages.ToUpper().Remove(0, 1) + ".");

                platform = 123;
                while (true)
                {
                    if (importFiles.ReadExcell(1).Item3 == 0)
                    {
                        platform = CLOSE; break;
                    }

                    WriteMenu();

                    try { platform = int.Parse(Console.ReadLine()); } catch { }

                    switch (platform)
                    {
                        case ANDROID:
                            {
                                exportfiles.ExportAndroid();
                                break;
                            }
                        case IOS:
                            {
                                exportfiles.ExportiOS();
                                break;
                            }
                        case ANDROID_IOS:
                            {
                                exportfiles.ExportAndroid();
                                exportfiles.ExportiOS();
                                break;
                            }
                    }
                    if ((platform == ANDROID) | (platform == IOS) | (platform == ANDROID_IOS))
                    {
                        Console.WriteLine("Done, check Output folder. Press any button to close.");
                        Console.ReadKey();
                        break;
                    }
                    if (platform == CLOSE) { break; }
                }
            }
        }

        private static void WriteMenu()
        {
            Console.WriteLine("\n" + "\n" + "To proceed with the conversion please type:");
            Console.WriteLine("0 for Android");
            Console.WriteLine("1 for iOS");
            Console.WriteLine("2 for both");
            Console.WriteLine("-1 to terminate the program");
            Console.WriteLine("Then hit ENTER.");
        }
    }
}

