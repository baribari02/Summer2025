using System;
using static HangMan.Program;

namespace HangMan
{
    internal class Program
    {
        public class Player
        {
            public string name { get; set; }
            public string alias { get; set; }
            public int wins { get; private set; }
            public int loses { get; private set; }

            public Player(string name, string alias)
            {
                this.name = name;
                this.alias = alias;
                wins = 0;
                loses = 0;
            }

            public void AddWin()
            {
                wins++;
            }

            public void AddLoses()
            {
                loses++;
            }


            public void Afiseaza()
            {
                Console.WriteLine($"{alias} ({name} - wins: {wins}  loses: {loses})");
            }
        }
        public class Game
        {
            private string _word;
            private string _progress;
            private int _attemptsLeft;
            private HashSet<char> _guessedLetters;
            private Player _player;

            public Game(Player player)
            {
                _player = player;

            }

            public void Init()
            {
               
                Console.Write("Introdu cuvântul de ghicit: ");

                string input = "";
                ConsoleKey key;
                do
                {
                    var keyInfo = Console.ReadKey(intercept: true);
                    key = keyInfo.Key;

                    if (key == ConsoleKey.Backspace && input.Length > 0)
                    {
                        input = input.Substring(0, input.Length - 1);
                    }
                    else if (key == ConsoleKey.Enter)
                    {
                        break;
                    }
                    else if (char.IsLetter(keyInfo.KeyChar))
                    {
                        input += keyInfo.KeyChar;
                    }
                } while (true);

                _word = input.ToLower();
                _attemptsLeft = 6;
                _guessedLetters = new HashSet<char>();
                _progress = new string('_', _word.Length);

                Console.Clear();
            }

            public void Start()
            {
                Console.WriteLine($"\n{_player.alias}, jocul a început! Succes!");

                while (_attemptsLeft > 0 && _progress.Contains(""))
                {
                    Console.WriteLine($"\nCuvant: {_progress}");
                    Console.WriteLine($"Încercari ramase: {_attemptsLeft}");
                    Console.Write("Ghiceste o litera: ");
                    string input = Console.ReadLine().ToLower();

                    if (string.IsNullOrWhiteSpace(input) || input.Length != 1 || !char.IsLetter(input[0]))
                    {
                        Console.WriteLine("Te rog introdu o singură litera valida.");
                        continue;
                    }

                    char guess = input[0];

                    if (_guessedLetters.Contains(guess))
                    {
                        Console.WriteLine("Ai mai ghicit această litera.");
                        continue;
                    }

                    _guessedLetters.Add(guess);

                    if (_word.Contains(guess))
                    {
                        Console.WriteLine("Corect!");
                        UpdateProgress(guess);
                        if (_progress == _word)
                        {
                            Console.WriteLine($"\nFelicitari, {_player.alias}! Ai ghicit cuvantul: {_word}");
                            _player.AddWin();
                            break;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Gresit!");
                        _attemptsLeft--;
                        if (_attemptsLeft == 0)

                        {
                            Console.WriteLine($"\nAi pierdut. Cuvantul era: {_word}");
                            _player.AddLoses();
                        }

                    }
                }
                _player.Afiseaza();
            

        }

           

            private void UpdateProgress(char guess)
            {
                char[] newProgress = _progress.ToCharArray();
                for (int i = 0; i < _word.Length; i++)
                {
                    if (_word[i] == guess)
                    {
                        newProgress[i] = guess;
                    }
                }

                _progress = new string(newProgress);
            }
        }
        public class Manager
        {
            private List<Player> _players;
            private Player _currentPlayer;
            public Manager()
            {
                _players = new List<Player>();
            }

            public Player CreatePlayer()
            {
                Console.Write("Nume jucator: ");
                string name = Console.ReadLine();
                Console.Write("Alias: ");
                string alias = Console.ReadLine();
                Player newPlayer = new Player(name, alias);
                _currentPlayer = newPlayer;
                return newPlayer;
            }

            public void StartGame()
            {
                Player player = CreatePlayer();
                Game game = new Game(player);
                game.Init();
                game.Start();
            }

            public void ContinueGame()
            {
                if (_currentPlayer == null)
                {
                    Console.WriteLine("Nu exista niciun jucator activ. Te rog creeaza unul mai intai (optiunea 1).");
                    return;
                }

                Game game = new Game(_currentPlayer);
                game.Init();
                game.Start();
            }
        }
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            while (true)
            {
                Console.WriteLine("\n--- Meniu Hangman ---");
                Console.WriteLine("1. Porneste un joc nou");
                Console.WriteLine("2. Continua jocul");
                Console.WriteLine("3. Iesire");
                Console.Write("Alege optiunea: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        manager.StartGame();
                        break;
                    case "2":
                        manager.ContinueGame();
                        break;
                    case "3":
                        Console.WriteLine("La revedere! Multumim ca ai jucat!");
                        break;
                    default:
                        Console.WriteLine("Optiune invalida. Incearca din nou.");
                        break;



                }


            }
        }
    }
}







