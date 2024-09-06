using System;
using System.Diagnostics;
using System.Threading;

delegate Scene Scene();

enum Room
{
    Room1,
    Room2
}

class Program
{
    public static Room CurrentRoom = Room.Room1;
    public static bool IsDoorOpen = true;

    public static void Main()
    {
        Scene sceneToRender = MenuScene();
        while (sceneToRender != null)
        {
            sceneToRender = sceneToRender.Invoke();
        }
    }

    public static Scene GameScene()
    {
        const int FPS = 30;
        const int frameTime = 1000 / FPS;
        bool isRunning = true;
        Player player = new Player(1, 3, 5, 10, 10);

        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("Game Scene");

            switch (CurrentRoom)
            {
                case Room.Room1:
                    DrawRoom1();

                    if (IsDoorOpen && player.PlayerX >= 9 && player.PlayerX <= 11 && player.PlayerY == 18)
                    {
                        CurrentRoom = Room.Room2;
                        player.PlayerX = 14;
                        player.PlayerY = 2;
                    }
                    break;

                case Room.Room2:
                    DrawRoom2();

                    if (IsDoorOpen && player.PlayerX == 14 && player.PlayerY == 1)
                    {
                        CurrentRoom = Room.Room1;
                        player.PlayerX = 10;
                        player.PlayerY = 17;
                    }
                    break;
            }

            player.Move();
            player.HandleInput(CurrentRoom.ToString());

            Thread.Sleep(frameTime);
        }

        return null;
    }

    public static Scene Info()
    {
        const int FPS = 60;
        const int frameTime = 1000 / FPS;
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("Information Scene");
            Thread.Sleep(frameTime);
        }

        return null;
    }

    public static Scene MenuScene()
    {
        int boxSize = 32;
        string[] menuButtons = new string[]
        {
            "Start",
            "Info",
            "Settings",
            "Exit"
        };
        int selectedButtonIndex = 0;
        bool isRunning = true;
        double refreshRate = 1.0 / 15.0;
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        Console.CursorVisible = false;

        while (isRunning)
        {
            if (stopwatch.Elapsed.TotalSeconds > refreshRate)
            {
                stopwatch.Restart();
                selectedButtonIndex = Math.Clamp(selectedButtonIndex, 0, menuButtons.Length - 1);

                Console.Clear();
                PrintMessageNTimes("-", boxSize);
                Console.WriteLine();
                PrintSurrondedMessage("|", "Dungeons Of Demons", "|", boxSize);
                Console.WriteLine();
                PrintSurrondedMessage("|", "Created by: Shewchuks Team", "|", boxSize);
                Console.WriteLine();
                PrintMessageNTimes("-", boxSize);
                Console.WriteLine();

                for (int i = 0; i < menuButtons.Length; i++)
                {
                    if (i == selectedButtonIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        PrintSurrondedMessage("*", menuButtons[i], "*", boxSize);
                        Console.ResetColor();
                    }
                    else
                    {
                        PrintSurrondedMessage("", menuButtons[i], "", boxSize);
                    }
                    Console.WriteLine();
                }

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.W:
                        case ConsoleKey.UpArrow:
                            selectedButtonIndex = (selectedButtonIndex - 1 + menuButtons.Length) % menuButtons.Length;
                            break;
                        case ConsoleKey.S:
                        case ConsoleKey.DownArrow:
                            selectedButtonIndex = (selectedButtonIndex + 1) % menuButtons.Length;
                            break;
                        case ConsoleKey.Enter:
                            switch (selectedButtonIndex)
                            {
                                case 0:
                                    return GameScene;
                                case 1:
                                    return Info;
                                case 2:
                                    // Placeholder for Settings menu
                                    Console.Clear();
                                    Console.WriteLine("Settings Menu is not implemented yet.");
                                    Thread.Sleep(1000);
                                    break;
                                case 3:
                                    Ending(400);
                                    isRunning = false;
                                    break;
                            }
                            break;
                    }
                }
            }
        }

        Console.WriteLine("Goodbye");
        return null;
    }

    public static void PrintMessageNTimes(string message, int n)
    {
        Console.Write(new string(message[0], n));
    }

    public static void PrintSurrondedMessage(string before, string message, string after, int boxSize, double alignment = 0.5)
    {
        Console.Write(before);
        boxSize = boxSize - (before.Length + after.Length);
        int start = (int)((boxSize - message.Length) * alignment);
        Console.Write(new string(' ', start));
        Console.Write(message);
        Console.Write(new string(' ', boxSize - start - message.Length));
        Console.Write(after);
    }

    public static void Ending(int wait)
    {
        for (int i = 0; i < 3; i++)
        {
            Console.Clear();
            Console.WriteLine("Please wait" + new string('.', i));
            Thread.Sleep(wait);
        }
        Console.Clear();
    }

    public static void DrawRoom1()
    {
        Console.Clear();

        Console.BackgroundColor = ConsoleColor.Gray;
        for (int y = 0; y < 20; y++)
        {
            Console.SetCursorPosition(0, y);
            Console.Write(new string(' ', 20));
        }
        Console.ResetColor();

        Console.BackgroundColor = ConsoleColor.DarkGray;
        for (int x = 0; x < 20; x++)
        {
            Console.SetCursorPosition(x, 0);
            Console.Write(' ');
            Console.SetCursorPosition(x, 19);
            Console.Write(' ');
        }
        for (int y = 0; y < 20; y++)
        {
            Console.SetCursorPosition(0, y);
            Console.Write(' ');
            Console.SetCursorPosition(19, y);
            Console.Write(' ');
        }
        Console.ResetColor();

        Console.BackgroundColor = ConsoleColor.Blue;
        for (int x = 9; x <= 11; x++)
        {
            Console.SetCursorPosition(x, 19);
            Console.Write(' ');
        }
        Console.ResetColor();
    }

    public static void DrawRoom2()
    {
        Console.Clear();

        Console.BackgroundColor = ConsoleColor.Gray;
        for (int y = 0; y < 15; y++)
        {
            Console.SetCursorPosition(0, y);
            Console.Write(new string(' ', 32));
        }
        Console.ResetColor();

        Console.BackgroundColor = ConsoleColor.DarkGray;
        for (int x = 0; x < 32; x++)
        {
            Console.SetCursorPosition(x, 0);
            Console.Write(' ');
            Console.SetCursorPosition(x, 14);
            Console.Write(' ');
        }
        for (int y = 0; y < 15; y++)
        {
            Console.SetCursorPosition(0, y);
            Console.Write(' ');
            Console.SetCursorPosition(31, y);
            Console.Write(' ');
        }
        Console.ResetColor();

        Console.BackgroundColor = ConsoleColor.DarkYellow;
        for (int y = 1; y < 14; y++)
        {
            Console.SetCursorPosition(1, y);
            Console.Write(new string(' ', 30));
        }
        Console.ResetColor();

        Console.BackgroundColor = ConsoleColor.Blue;
        Console.SetCursorPosition(13, 0);
        Console.Write(new string(' ', 3));
        Console.ResetColor();
    }
}

class Player
{
    public int Health;
    public int Damage;
    public int Range;
    public int PlayerX;
    public int PlayerY;

    public Player(int health, int damage, int range, int playerx, int playery)
    {
        Health = health;
        Damage = damage;
        Range = range;
        PlayerX = playerx;
        PlayerY = playery;
    }

    public void Move()
    {
        Console.SetCursorPosition(PlayerX, PlayerY);
        Console.Write(' ');
    }

    public void HandleInput(string room)
    {
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            int newX = PlayerX;
            int newY = PlayerY;
            switch (key.Key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    newY = Math.Max(0, PlayerY - 1);
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    newY = Math.Min(Console.WindowHeight - 1, PlayerY + 1);
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    newX = Math.Max(0, PlayerX - 1);
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    newX = Math.Min(Console.WindowWidth - 1, PlayerX + 1);
                    break;
                case ConsoleKey.O:
                    Program.IsDoorOpen = !Program.IsDoorOpen;
                    break;
            }

            if (!IsCollidingWithWall(newX, newY, room))
            {
                PlayerX = newX;
                PlayerY = newY;
            }
        }
    }

    private bool IsCollidingWithWall(int x, int y, string room)
    {
        if (room == "Room1")
        {
            return (x <= 0 || x >= 19 || y <= 0 || y >= 19);
        }
        else if (room == "Room2")
        {
            return (x <= 0 || x >= 31 || y <= 0 || y >= 14);
        }
        return false;
    }
}