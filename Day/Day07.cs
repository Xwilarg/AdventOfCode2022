using System.ComponentModel.Design.Serialization;

namespace AdventOfCode2022.Day
{
    public class Day07 : IDay
    {
        private class FileInfo
        {
            protected FileInfo(string name, DirectoryInfo? parent)
            {
                Name = name;
                _size = 0;
                Parent = parent;
            }

            public FileInfo(string name, DirectoryInfo? parent, int size) : this(name, parent)
            {
                Size = size;
            }

            public string Name { private init; get; }
            private int _size;
            public int Size
            {
                set
                {
                    if (Parent != null)
                    {
                        Parent.Size -= _size; // Remove the pre-update size to the parent
                    }
                    _size = value;
                    if (Parent != null)
                    {
                        Parent.Size += _size; // And then add the new one
                    }
                }
                get => _size;
            }
            public DirectoryInfo? Parent { init; get; }
        }

        private class DirectoryInfo : FileInfo // A directory is basically a file that can contains others
        {
            public DirectoryInfo(string name, DirectoryInfo? parent) : base(name, parent)
            {
                SubDirs = new();
            }

            public List<FileInfo> SubDirs { private init; get; }
        }

        public string Part1(string input)
        {
            // Split to get all commands and remove the empty space at the start
            // We also skip the first command that is always cd /
            var cmds = input.Split('$', StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).Skip(1);


            DirectoryInfo currDirectory = new("root", null);
            var root = currDirectory; // Keep a reference to root to access it

            foreach (var cmd in cmds)
            {
                var shellData = cmd.Split('\n'); // All line in the command
                var cmdData = shellData[0].Split(' '); // Input done to the shell

                if (cmdData[0] == "ls")
                {
                    foreach (var o in shellData.Skip(1)) // List of all files
                    {
                        var oData = o.Split(' ');
                        if (oData[0] == "dir") // We listed a directory
                        {
                            currDirectory!.SubDirs.Add(new DirectoryInfo(oData[1], currDirectory));
                        }
                        else
                        {
                            currDirectory!.SubDirs.Add(new(oData[1], currDirectory, int.Parse(oData[0])));
                        }
                    }
                }
                else // If we are not doing a ls, we are doing a cd
                {
                    if (cmdData[1] == "..") // Going back to the parent
                    {
                        currDirectory = currDirectory!.Parent;
                    }
                    else
                    {
                        currDirectory = (DirectoryInfo)currDirectory!.SubDirs.First(x => x.Name == cmdData[1]);
                    }
                }
            }

            return root.SubDirs.Where(x => x is DirectoryInfo && x.Size >= 10000).Select(x => x.Size).Sum().ToString();
        }

        public string Part2(string input)
        {
            return string.Empty;
        }
    }
}
