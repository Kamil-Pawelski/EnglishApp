namespace EnglishApp;

class Program
{
    static void Main(string[] args)
    {
        Subject subject = new Subject();
        subject.ReadFile("Dom.txt");
        subject.ReadFiles();
    }
}
