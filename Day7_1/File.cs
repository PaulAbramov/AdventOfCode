﻿namespace Day7_1;

public class File
{
    public string Name { get; }
    
    public long Size { get; }

    public File(string name, long size)
    {
        Name = name;
        Size = size;
    }
}