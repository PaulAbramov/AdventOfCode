namespace Day7_2;

public class Folder
{
    public string Name { get; }
    
    public long Size { get; set; }
    
    public Folder? ParentFolder { get; set; }
    
    public List<Folder> Folders { get; set; } = new List<Folder>();

    public List<File> Files { get; set; } = new List<File>();

    public Folder(string name, Folder? parentFolder = null)
    {
        Name = name;
        ParentFolder = parentFolder;
    }
}