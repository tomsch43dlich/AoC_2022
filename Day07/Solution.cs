using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day07
{
    
    public static class Solution
    {
        private class Folder
        {
            public string Name { get; set; }
            public List<DataFile> dataFileList { get; set; } = new List<DataFile>();
            public List<Folder> folderList { get; set;} = new List<Folder>(); 
            public Folder ?Dir { set; get; }

            public int getSize()
            {
                int sum = 0;
                foreach (var dataFile in dataFileList)
                {
                    sum += dataFile.Size;
                }
                foreach (var folder in folderList)
                {
                    sum += folder.getSize();
                }
                return sum;
            }
        }

        private class DataFile
        {
            public string Name { get; set; }
            public int Size { get; set; }
            public Folder Dir { set; get; } 
        }

        private static Folder CurrentFolder { get; set; }
        private static Folder PrevFolder { get; set; }

        private static List<Folder> AllFolders { get; set; } = new List<Folder>();

        private static List<List<string>> formatFile()
        {
            List<List<string>> result = new List<List<string>>();
            string[] lines = File.ReadAllLines(@"D:\AoC\2022_C#\AdventOfCode2022\Day07\File.txt");
            foreach (var line in lines)
            {
                result.Add(line.Split(" ").ToList());
            }
            return result;
        }

        private static Folder getFileTree(List<List<string>> unformatFileTree)
        {
            CurrentFolder = null;   
            PrevFolder = null;
            Folder root = null;

            foreach (var file in unformatFileTree)
            {
                if (file[0] == "$") // Command
                {
                    if (file[1] == "cd") 
                    {
                        if (file[2] == "/")
                        {
                            root = new Folder()
                            {
                                Name = file[2],
                                Dir = null
                            };
                            AllFolders.Add(root);
                            CurrentFolder = root;
                        }
                        else if (file[2] == "..")
                        {
                            CurrentFolder = CurrentFolder.Dir;
                        }
                        else
                        {
                            Predicate<Folder> predicate = (folder) => folder.Name == file[2];
                            CurrentFolder = CurrentFolder.folderList.Find(predicate);
                        }
                    }
                }
                else
                {
                    if (file[0] == "dir")
                    {
                        var directory = new Folder()
                        {
                            Name = file[1],
                            Dir = CurrentFolder
                        };
                        AllFolders.Add(directory);
                        CurrentFolder.folderList.Add(directory);
                    }
                    else
                    {
                        var dataFile = new DataFile()
                        {
                            Name = file[1],
                            Size = Convert.ToInt32(file[0]),
                            Dir = CurrentFolder
                        };
                        CurrentFolder.dataFileList.Add(dataFile);
                    }
                }
            }
            return root;

        }

        public static int GetSumOfFileSize(int maxSize)
        {
            var list = formatFile();
            Folder root = getFileTree(list);
            var sum = AllFolders.Select(x => x.getSize()).ToList<int>().FindAll((x) => x < maxSize).Sum();
            return sum;
        }

        public static int FindDeletableDirectory()
        {
            var list = formatFile();
            Folder root = getFileTree(list);

            int maxStorage = 70000000; // 70.000.000
            int minUnusedStorage = 30000000; // 30.000.000
            int usedStorage = root.getSize();
            int unusedStorage = maxStorage - usedStorage;
            int quantityDeletedStorage = minUnusedStorage - unusedStorage;

            var deletedStorageSize = AllFolders.FindAll((folder) => folder.getSize() >= quantityDeletedStorage).Min(folder => folder.getSize());
            return deletedStorageSize;
        }

    }
}
