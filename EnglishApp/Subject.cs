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
    /// <summary>
    /// Words list.
    /// </summary>
    private List<Word> words;
    /// <summary>
    /// All words for the subject.
    /// </summary>
    private Dictionary<string, List<Word>> allSubjects;
    /// <summary>
    /// Path to txt folder.
    /// </summary>
    private readonly string txtPath;
    /// <summary>
    /// Return words list or set words list.
    /// </summary>
    public List<Word> Words { get { return words; } private set { words = value; } }
    /// <summary>
    /// Initializes the field.
    /// </summary>
    public Subject() 
    { 
        words = new List<Word>(); 
        allSubjects = new Dictionary<string, List<Word>>();

        string folderPath = "\\txt";
        string currentDirectory = Directory.GetCurrentDirectory();
        string filePath = Path.Combine(currentDirectory, folderPath);
        string parentDirectory;

        while (!Directory.Exists(filePath))
        {
            if ((Directory.GetParent(currentDirectory)) != null)
            {
                parentDirectory = Directory.GetParent(currentDirectory)!.FullName;
                currentDirectory = parentDirectory;
                filePath = parentDirectory + folderPath;

            }
            else
            {
                throw new Exception("ERROR! Nie mogę odnaleźć scieżki.");
            }
        }
        txtPath = filePath;
    }

    /// <summary>
    /// Chooses the subject.
    /// </summary>
    public void ChooseSubcject()
    {
        Menu();
        string choose = Console.ReadLine() ?? string.Empty;

        if(allSubjects.ContainsKey(choose))
        {
            words = allSubjects[choose];
            Guess();
        }
        else
        {
            Console.WriteLine("Opcja nie istnieje");
        }
    }

    private void Guess()
    {
        List<Word> good = new List<Word>();
        List<Word> wrong = new List<Word>();
        Random random = new Random();
        string engWord;
        while(words.Count > 0)
        {
            Console.WriteLine("Słowo do zgadnięcia: ");
            engWord = words[random.Next(words.Count)].wordUK;
            Console.WriteLine(engWord);

        }
    }

    /// <summary>
    /// Read from file words and adds to the dictionary.
    /// </summary>
    /// <param name="file">file name</param>
    private  void ReadFile(string file)
    {
        string[] text = File.ReadAllLines(txtPath + "\\" + file);
        string name = file.Substring(0, file.IndexOf('.'));
        text = Split(text);
        List<Word> currentWord = new List<Word>();
        for (int i = 0; i < text.Length; i += 2)
            currentWord.Add(new Word(text[i], text[i + 1]));
        allSubjects.Add(name, currentWord);
    }

    public void ReadFiles()
    {
        string[] txtFiles = Directory.GetFiles(txtPath, "*.txt");

        foreach (string filePath in txtFiles)
        {
            string fileName = Path.GetFileName(filePath);
            ReadFile(filePath);
        }
    }

    /// <summary>
    /// Print menu for ChooseSubcject().
    /// </summary>
    private void Menu()
    {
        Console.WriteLine("Wybierz tematyke:");
        foreach (var item in allSubjects)
        {
            Console.WriteLine(item.Key);
        }
    }

    /// <summary>
    /// Split our words to Polish and English
    /// </summary>
    /// <param name="lines">Line from file</param>
    /// <returns></returns>
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



