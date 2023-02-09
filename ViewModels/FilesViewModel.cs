using System.Collections.Generic;
using System;

namespace DataRoom.ViewModels
{
    public class FileDetails
    {
        public string Name { get; set; }
        public string Path { get; set; }
    }
    public class DirectoryDetails
    {
        public string Name { get; set; }
        public string Path { get; set; }
    }

    public class FilesViewModel
    {
        public List<FileDetails> Files { get; set; } 
            = new List<FileDetails>();
        public List<DirectoryDetails> Directories { get; set; }
            = new List<DirectoryDetails>();
    }
}
