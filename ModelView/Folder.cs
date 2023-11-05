namespace FileSolder.ModelView
{
    internal class Folder : Item
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public long Size { get; set; }
        public int AmountOfItems { get; set; }
        public object Type { get; set; }
    }
}