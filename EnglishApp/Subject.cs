using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishApp;

public class Subject
{
    private List<Word> words;
    public Subject() { words = new List<Word>(); }

    public List<Word> Words { get; set; }
    public void GetWordsFromFile()
    {
        Menu();
        string choose = Console.ReadLine() ?? string.Empty;
        switch(choose)
        {
            case "1":
                break;
        }
    }

    private void Menu()
    {
        Console.WriteLine("1. X");
    }
}



