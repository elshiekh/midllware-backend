using System;
using System.Collections.Generic;

namespace Kyriba_Out.DTO
{
    public class FTPItem
    {
        //public string  Permissions { get; set; }
        //public int Size { get; set; }
        public DateTime LastModified { get; set; }
        public string Name { get; set; }
        public string FullPath { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class FTPDirectory : FTPItem
    {
        public FTPDirectory() { }
        public FTPDirectory(FTPItem item)
        {
            //Permissions = item.Permissions;
            //Size = item.Size;
            LastModified = item.LastModified;
            Name = item.Name;
            FullPath = item.FullPath;
        }

        public Lazy<List<FTPItem>> SubItems { get; set; }
    }

    public class FTPFile : FTPItem
    {
        public FTPFile() { }
        public FTPFile(FTPItem item)
        {
            //Permissions = item.Permissions;
            //Size = item.Size;
            LastModified = item.LastModified;
            Name = item.Name;
            FullPath = item.FullPath;
        }
    }
}
