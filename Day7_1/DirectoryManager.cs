namespace Day7_1;

public class DirectoryManager
{
    private Folder rootFolder;
    private Folder? currentFolder;

    public DirectoryManager()
    {
        rootFolder = new Folder("/");
        currentFolder = rootFolder;
    }
    
    public void CheckInput(string line)
    {
        if (line.StartsWith("$"))
        {
            if (line.Contains("ls"))
            {
                return;
            }

            if (line.Contains("cd"))
            {
                var cdInfo = line.Split(" ");

                currentFolder = cdInfo[2] switch
                {
                    ".." => currentFolder?.ParentFolder,
                    _ => currentFolder?.Folders.FirstOrDefault(x => x.Name == cdInfo[2]) ?? currentFolder
                };

                return;
            }
        }

        if (line.StartsWith("dir"))
        {
            AddFolder(line);
            return;
        }

        AddFile(line);
    }

    private void AddFolder(string line)
    {
        currentFolder?.Folders.Add(new Folder(line.Split(" ")[1], currentFolder));
    }

    private void AddFile(string line)
    {
        var fileInfo = line.Split(" ");
        currentFolder?.Files.Add(new File(fileInfo[1],long.Parse(fileInfo[0])));

        AddSizeToFolderHierarchy(currentFolder, long.Parse(fileInfo[0]));
    }

    private static void AddSizeToFolderHierarchy(Folder folder, long size)
    {
        folder.Size += size;

        if (folder.ParentFolder != null)
        {
            AddSizeToFolderHierarchy(folder.ParentFolder, size);
        }
    }
    
    public long TotalSumOfSize()
    {
        return GetDirectorySizeWithThreshold(rootFolder);
    }

    private static long GetDirectorySizeWithThreshold(Folder folder, long threshold = 100_000)
    {
        long size = 0;
        if (folder.Size <= threshold)
        {
            size += folder.Size;
        }

        size += folder.Folders.Sum(subfolder => GetDirectorySizeWithThreshold(subfolder));

        return size;
    }
}