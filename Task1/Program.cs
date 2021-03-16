using System;
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
            InitFileSystemInfo(path);

            GetLeatestFile(path, extension);

            GetFreshFiles(path, extension);
        }

        private static FileSystemInfo[] InitFileSystemInfo(string path)
        {
            FileSystemInfo[] fileSystemInfo = new DirectoryInfo(path).GetFileSystemInfos();
            return fileSystemInfo;
        }
        private static void GetLeatestFile(String path, String extension)
        {    
            foreach (FileSystemInfo fileSI in InitFileSystemInfo(path))
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

        private static void GetFreshFiles(String path, String extension)
        {
            foreach (FileSystemInfo fileSI in InitFileSystemInfo(path))
            {
                if (Path.GetFileName(fileSI.FullName).Contains(extension))
                {
                    DateTime dt2 = Convert.ToDateTime(fileSI.CreationTime);
                    int timeDifference = (int)(dt - dt2).TotalSeconds;
                    if (timeDifference <= 10 & timeDifference >= 0 & fileSI.Name != fileName)
                    {
                        {
                            Console.WriteLine("olso new file =>" + fileSI.Name);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No files with such extension");
                    break;
                }
            }
            Console.ReadLine();
        }
    }
}
