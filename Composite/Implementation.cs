using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public abstract class FileSystemItem
    {
        public string Name { get; set; }
        public abstract long GetSize();
        public FileSystemItem(string name)
        {
            Name = name;
        }
    }


   public class File : FileSystemItem
    {
        private long _size;
        public File(string name , long size) : base(name) 
        {
        
            _size= size;
        }

        public override long GetSize()
        {
            return _size;
        }
    }

    public class Directory : FileSystemItem
    {
         private List<FileSystemItem> _fileSsystemItems { get; set; }  = new List<FileSystemItem>();
        private long _size;
        public Directory(string name, long size): base(name)
        {
               _size= size; 
        }

        public override long GetSize()
        {
            var treeSize = _size;
            foreach (var item in _fileSsystemItems)
            {
                treeSize += item.GetSize();
            }
            return treeSize;
        }

        public void Add(FileSystemItem item)
        {
            _fileSsystemItems.Add(item);
        }
        public void Remove(FileSystemItem item)
        {
            _fileSsystemItems.Remove(item);
        }
    }
}
