using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishApp;

public struct Word
{
    public string wordPL;
    public string wordUK;

    public Word(string wordPL, string wordUK)
    {
        this.wordPL = wordPL;
        this.wordUK = wordUK;
    }
}

