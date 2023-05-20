using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace EnglishApp;

public class Subject
{
    private List<Word> words;
    private Dictionary<string, List<Word>> allSubjects;
    public List<Word> Words { get { return words; } private set { words = value; } }
    public Subject() { words = new List<Word>(); allSubjects = new Dictionary<string, List<Word>>(); }

    public void ChooseSubcject()
    {
        Menu();
        string choose = Console.ReadLine() ?? string.Empty;
        switch (choose)
        {
            case "1":
                words = allSubjects["Dom"];
                break;
        }
    }

    public void ReadFile(string file)
    {
        string folderPath = "\\txt\\" + file;
        string currentDirectory = Directory.GetCurrentDirectory();
        string name = file.Substring(0, file.IndexOf('.'));
        string filePath = Path.Combine(currentDirectory, folderPath);
        string parentDirectory;

        while (!File.Exists(filePath))
        {
            if ((Directory.GetParent(currentDirectory)) != null)
            {
                parentDirectory = Directory.GetParent(currentDirectory).FullName;
                currentDirectory = parentDirectory;
                filePath = parentDirectory + folderPath;
                
            }
            else
            {
                Console.WriteLine("Nie mogę odnaleźć pliku");
                return;
            }   
        }

        string[] text = File.ReadAllLines(filePath);

        text = Split(text);
        List<Word> currentWord = new List<Word>();
        for (int i = 0; i < text.Length; i += 2)
            currentWord.Add(new Word(text[i], text[i + 1]));
        allSubjects.Add(name, currentWord);
    }



    private void Menu()
    {
        Console.WriteLine("1. Dom");
    }

    private string[] Split(string[] lines)
    {
        List<string> partsList = new List<string>();

        foreach (string line in lines)
        {
            string[] parts = line.Split(';');
            partsList.AddRange(parts);
        }

        return partsList.ToArray();
    }
}



