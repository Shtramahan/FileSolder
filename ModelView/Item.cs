using System;

namespace FileSolder.ModelView
{
    public class Item
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public long Size { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public ItemType? Type { get; set; }
    }
}