﻿using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Write("Введите имя файла: ");
        string fileName = Console.ReadLine();

        DriveInfo[] drives = DriveInfo.GetDrives();

        foreach (DriveInfo drive in drives)
        {
            Console.WriteLine($"{drive.Name}...");

            SearchForFile(fileName, drive.RootDirectory);
        }

    }

    static void SearchForFile(string fileName, DirectoryInfo directory)
    {
        try
        {
            FileInfo[] files = directory.GetFiles();

            if (files.Length > 0)
            {
                foreach (FileInfo file in files)
                {
                    if (file.Name.Equals(fileName))
                    {
                        Console.WriteLine(file.FullName);
                    }
                }
            }
        }
        catch (Exception ex)
        {
        }

        try
        {
            DirectoryInfo[] subdirectories = directory.GetDirectories();

            foreach (DirectoryInfo subdirectory in subdirectories)
            {
                SearchForFile(fileName, subdirectory);
            }
        }
        catch (Exception ex)
        {
        }
    }
}