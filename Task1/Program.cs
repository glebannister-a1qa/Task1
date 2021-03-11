using System;
using System.Collections.Generic;
using System.IO;

namespace Task1
{
    class Program
    {
        private static DateTime dt = new DateTime();
        private static string fileName;
        static void Main(string[] args)
        {
            Console.WriteLine("Enter path ");
            String path = Console.ReadLine();
            Console.WriteLine("Enter extension ");
            String extension = Console.ReadLine();
            GetLastFiles(path, extension);
        }

        public static void GetLastFiles(String path, String extension)
        {
            GetLeatestFile(path, extension);
            GetAlsoFreshFiles(path, extension);
        }
        private static void GetLeatestFile(String path, String extension)
        {
            FileSystemInfo[] fileSystemInfo = new DirectoryInfo(path).GetFileSystemInfos();
            foreach (FileSystemInfo fileSI in fileSystemInfo)
            {
                if (Path.GetFileName(fileSI.FullName).Contains(extension))
                {
                    if (dt <= Convert.ToDateTime(fileSI.CreationTime))
                    {
                        dt = Convert.ToDateTime(fileSI.CreationTime);
                        fileName = fileSI.Name;
                    }
                }
                else
                {
                    Console.WriteLine("No files with such extension");
                    break;
                }
            }
            Console.WriteLine("last file =>" + fileName + ", created " + dt);
        }

        private static void GetAlsoFreshFiles(String path, String extension)
        {
            List<String> olsoFreshFilesList = new List<String>();
            FileSystemInfo[] fileSystemInfo = new DirectoryInfo(path).GetFileSystemInfos();
            foreach (FileSystemInfo fileSI in fileSystemInfo)
            {
                if (Path.GetFileName(fileSI.FullName).Contains(extension))
                {
                    DateTime dt2 = new DateTime();
                    dt2 = Convert.ToDateTime(fileSI.CreationTime);
                    int timeDifference = (int)(dt - dt2).TotalSeconds;
                    if (timeDifference <= 10 & timeDifference >= 0 & fileSI.Name != fileName)
                    {
                        Console.WriteLine(dt.Second - Convert.ToDateTime(fileSI.CreationTime).Second);
                        {
                            olsoFreshFilesList.Add(fileSI.Name);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No files with such extension");
                    break;
                }
            }
            for (int j = 0; j < olsoFreshFilesList.Count; j++)
            {
                Console.WriteLine("olso new file =>" + olsoFreshFilesList[j]);
            }

            Console.ReadLine();
        }
    }
}
