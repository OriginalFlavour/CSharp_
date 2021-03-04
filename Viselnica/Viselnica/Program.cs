using System;

namespace Viselnica 
{
    class Words
    {
        private static char[] _RightWord;
        private static char[] _WritedWord;
        private static string[] _AllWords;
        private static int _AmountOfTries = 0;
        private static char[] _Characters;
        public static void CheckWord(char symbol)
        {
            bool IsSymbol = true;
            for (int i = 0; i < _RightWord.Length; i++)
            {
                if (symbol == _RightWord[i])
                {
                    _WritedWord[i] = symbol;
                    IsSymbol = false;
                }
            }
            if (IsSymbol && symbol >= 'a' && symbol <= 'z')
            {
                _AmountOfTries++;
                for (int i = 0; i < _Characters.Length; i++)
                {
                    if (symbol == _Characters[i])
                    {
                        _AmountOfTries--;
                        return;
                    }
                }
                char[] TempCharacters = new char[_Characters.Length + 1];
                for (int j = 0; j < _Characters.Length; j++)
                {
                    TempCharacters[j] = _Characters[j];
                }
                _Characters = new char[_Characters.Length + 1];
                for (int j = 0; j < _Characters.Length; j++)
                {
                    _Characters[j] = TempCharacters[j];
                }
                _Characters[_Characters.Length - 1] = symbol;
            }
        }
        public static void SeeWord()
        {
            Console.Clear();
            Console.WriteLine(_WritedWord);
            Console.WriteLine("Amount of tries = " + _AmountOfTries);
        }
        public static void SetWord()
        {
            Random rnd = new Random();
            int value = rnd.Next();
            _AllWords = new string[15];
            _AllWords[0] = "lake";
            _AllWords[1] = "earthquake";
            _AllWords[2] = "puppy";
            _AllWords[3] = "planet";
            _AllWords[4] = "mood";
            _AllWords[5] = "rule";
            _AllWords[6] = "mission";
            _AllWords[7] = "story";
            _AllWords[8] = "rabbish";
            _AllWords[9] = "operator";
            _AllWords[10] = "surger";
            _AllWords[11] = "moment";
            _AllWords[12] = "sugar";
            _AllWords[13] = "museum";
            _AllWords[14] = "garden";
            _RightWord = _AllWords[value % 15].ToCharArray();
        }
        public static void ResetWord()
        {
            _Characters = new char[1];
            _Characters[0] = ' ';


            _WritedWord = new char[_RightWord.Length];

            for (int i = 0; i < _RightWord.Length; i++)
            {
                _WritedWord[i] = '_';
            }
        }
        public static void CheckGame(ref bool EndGame)
        {
            if (_AmountOfTries == 9)
            {
                SeeWord();
                Console.WriteLine("You Lose!");
                PaintGallows();
                Console.ReadKey();
                EndGame = false;
                return;
            }
            int RightSymbols = _RightWord.Length;
            for (int i = 0; i < _RightWord.Length; i++)
            {
                if (_RightWord[i] == _WritedWord[i])
                {
                    RightSymbols--;
                    if (RightSymbols == 0)
                    {
                        SeeWord();
                        Console.WriteLine("You Win!");
                        PaintGallows();
                        Console.ReadKey();
                        EndGame = false;
                    }
                }
            }
        }
        public static void PaintGallows()
        {
            switch (_AmountOfTries)
            {
                case 1:
                    for (int i = 0; i < 6; i++)
                    {
                        Console.WriteLine('|');
                    }
                    break;
                case 2:
                    Console.WriteLine("|____");
                    for (int i = 0; i < 5; i++)
                    {
                        Console.WriteLine('|');
                    }
                    break;
                case 3:
                    Console.WriteLine("|____");
                    Console.WriteLine("|   |");
                    for (int i = 0; i < 4; i++)
                    {
                        Console.WriteLine('|');
                    }
                    break;
                case 4:
                    Console.WriteLine("|____");
                    Console.WriteLine("|   |");
                    Console.WriteLine("|   O");
                    for (int i = 0; i < 3; i++)
                    {
                        Console.WriteLine('|');
                    }
                    break;
                case 5:
                    Console.WriteLine("|____");
                    Console.WriteLine("|   |");
                    Console.WriteLine("|   O");
                    Console.WriteLine("|   |");
                    for (int i = 0; i < 2; i++)
                    {
                        Console.WriteLine('|');
                    }
                    break;
                case 6:
                    Console.WriteLine("|____");
                    Console.WriteLine("|   |");
                    Console.WriteLine("|   O");
                    Console.WriteLine("|   |\\");
                    for (int i = 0; i < 2; i++)
                    {
                        Console.WriteLine('|');
                    }
                    break;
                case 7:
                    Console.WriteLine("|____");
                    Console.WriteLine("|   |");
                    Console.WriteLine("|   O");
                    Console.WriteLine("|  /|\\");
                    for (int i = 0; i < 2; i++)
                    {
                        Console.WriteLine('|');
                    }
                    break;
                case 8:
                    Console.WriteLine("|____");
                    Console.WriteLine("|   |");
                    Console.WriteLine("|   O");
                    Console.WriteLine("|  /|\\");
                    Console.WriteLine("|  / ");
                    for (int i = 0; i < 2; i++)
                    {
                        Console.WriteLine('|');
                    }
                    break;
                case 9:
                    Console.WriteLine("|____");
                    Console.WriteLine("|   |");
                    Console.WriteLine("|   O");
                    Console.WriteLine("|  /|\\");
                    Console.WriteLine("|  / \\");
                    for (int i = 0; i < 2; i++)
                    {
                        Console.WriteLine('|');
                    }
                    break;
                default:
                    break;
            }
        }

    }
    class Program
    {
        static void Main()
        {
            Words.SetWord();
            Words.ResetWord();
            bool EndGame = true;
            while (EndGame)
            {
                Words.SeeWord();
                Words.PaintGallows();
                Words.CheckWord(Console.ReadKey().KeyChar);
                Words.CheckGame(ref EndGame);
            }
        }
    }
}
