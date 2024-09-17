using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using FastConsole.Engine.Elements;
using FastConsole.Engine.Core;

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
        List<Bullet> bullets = new List<Bullet>();

        List<Element> elements = new List<Element>();
        Canvas Rooms = new Canvas(new Size(1, 1));
        PlayerDrawer playerdrawer = new PlayerDrawer(player);

        Rooms.CellWidth = 1;
        DrawRoom1(Rooms);


        elements.Add(Rooms);
        elements.Add(playerdrawer);
        while (isRunning)
        {
            if (Time.TryUpdate())
            {

                Element.UpdateAndRender(elements);
                //Console.WriteLine("Game Scene");

                switch (CurrentRoom)
                {
                    case Room.Room1:


                        if (IsDoorOpen && player.PlayerX >= 9 && player.PlayerX <= 11 && player.PlayerY == 18)
                        {
                            CurrentRoom = Room.Room2;
                            player.PlayerX = 14;
                            player.PlayerY = 2;
                        }
                        break;

                    case Room.Room2:
                        //DrawRoom2();

                        if (IsDoorOpen && player.PlayerX == 14 && player.PlayerY == 1)
                        {
                            CurrentRoom = Room.Room1;
                            DrawRoom1(Rooms);
                            player.PlayerX = 10;
                            player.PlayerY = 17;
                        }
                        break;
                }

                player.HandleInput(CurrentRoom.ToString(), bullets);

                foreach (var bullet in bullets)
                {
                    bullet.Move();
                    //bullet.Draw();
                }

                bullets.RemoveAll(b => b.IsOutOfRange() || b.IsCollidingWithWall(CurrentRoom.ToString()) || b.IsCollidingWithDoor(CurrentRoom.ToString()));

                player.Draw();
            }

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

    public static void DrawRoom1(Canvas RoomF)
    {
        RoomF.CanvasSize = new Size(20, 20);
        RoomF.Fill(Color.DarkGray);
        RoomF.FillRect(1, 1, 18, 18, Color.Gray);
        RoomF.FillRect(8, 19, 4, 1, Color.Blue);


    }

    public static void DrawRoom2(Canvas RoomS)
    {
        Console.Clear();

        for (int y = 0; y < 15; y++)
        {
            Console.SetCursorPosition(0, y);
            Console.Write(DrawingHelper.ColorBackground(new string(' ', 32), Color.Gray));
        }

        for (int x = 0; x < 32; x++)
        {
            Console.SetCursorPosition(x, 0);
            Console.Write(DrawingHelper.ColorBackground(" ", Color.DarkGray));
            Console.SetCursorPosition(x, 14);
            Console.Write(DrawingHelper.ColorBackground(" ", Color.DarkGray));
        }
        for (int y = 0; y < 15; y++)
        {
            Console.SetCursorPosition(0, y);
            Console.Write(DrawingHelper.ColorBackground(" ", Color.DarkGray));
            Console.SetCursorPosition(31, y);
            Console.Write(DrawingHelper.ColorBackground(" ", Color.DarkGray));
        }

        for (int y = 1; y < 14; y++)
        {
            Console.SetCursorPosition(1, y);
            Console.Write(DrawingHelper.ColorBackground(new string(' ', 30), Color.Yellow));
        }

        Console.SetCursorPosition(13, 0);
        Console.Write(DrawingHelper.ColorBackground(new string(' ', 3), Color.Blue));
    }
}

class DrawingHelper
{
    public static string ColorText(string message, Color color)
    {
        string CSI = "\u001b[";
        return $"{CSI}38;2;{color.R};{color.G};{color.B}m{message}{CSI}0m";
    }

    public static string ColorBackground(string message, Color color)
    {
        string CSI = "\u001b[";
        return $"{CSI}48;2;{color.R};{color.G};{color.B}m{message}{CSI}0m";
    }

    public static string ColorBackgroundAndText(string message, Color foregroundColor, Color backgroundColor)
    {
        string CSI = "\u001b[";
        string foreground = $"38;2;{foregroundColor.R};{foregroundColor.G};{foregroundColor.B}";
        string background = $"48;2;{backgroundColor.R};{backgroundColor.G};{backgroundColor.B}";
        return $"{CSI}{foreground};{background}m{message}{CSI}0m";
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

    public void Draw()
    {
        Renderer.SetCursorPosition(PlayerX, PlayerY);
        Renderer.Write("  ", background: Color.Black);

    }

    public void HandleInput(string room, List<Bullet> bullets)
    {
        while (Console.KeyAvailable)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.W:
                    bullets.Add(new Bullet(PlayerX, PlayerY - 1, 0, -1, Range));
                    break;
                case ConsoleKey.S:
                    bullets.Add(new Bullet(PlayerX, PlayerY + 1, 0, 1, Range));
                    break;
                case ConsoleKey.A:
                    bullets.Add(new Bullet(PlayerX - 1, PlayerY, -1, 0, Range));
                    break;
                case ConsoleKey.D:
                    bullets.Add(new Bullet(PlayerX + 1, PlayerY, 1, 0, Range));
                    break;
                case ConsoleKey.O:
                    Program.IsDoorOpen = !Program.IsDoorOpen;
                    break;
                case ConsoleKey.UpArrow:
                    PlayerY = Math.Max(0, PlayerY - 1);
                    break;
                case ConsoleKey.DownArrow:
                    PlayerY = Math.Min(Console.WindowHeight - 1, PlayerY + 1);
                    break;
                case ConsoleKey.LeftArrow:
                    PlayerX = Math.Max(0, PlayerX - 1);
                    break;
                case ConsoleKey.RightArrow:
                    PlayerX = Math.Min(Console.WindowWidth - 1, PlayerX + 1);
                    break;
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

class Bullet
{
    public int X;
    public int Y;
    public int DirectionX;
    public int DirectionY;
    public int Range;
    private int distanceTraveled;

    public Bullet(int x, int y, int directionX, int directionY, int range)
    {
        X = x;
        Y = y;
        DirectionX = directionX;
        DirectionY = directionY;
        Range = range;
        distanceTraveled = 0;
    }

    public void Move()
    {
        X += DirectionX;
        Y += DirectionY;
        distanceTraveled++;
    }

    public void Draw()
    {
        if (distanceTraveled < Range)
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(DrawingHelper.ColorBackground("  ", Color.Red));
            Console.ResetColor();
        }
    }

    public bool IsOutOfRange()
    {
        return distanceTraveled >= Range;
    }

    public bool IsCollidingWithWall(string room)
    {
        if (room == "Room1")
        {
            return (X <= 0 || X >= 19 || Y <= 0 || Y >= 19);
        }
        else if (room == "Room2")
        {
            return (X <= 0 || X >= 31 || Y <= 0 || Y >= 14);
        }
        return false;
    }

    public bool IsCollidingWithDoor(string room)
    {
        if (room == "Room1" && Program.IsDoorOpen)
        {
            return (X >= 9 && X <= 11 && Y == 19);
        }
        else if (room == "Room2" && Program.IsDoorOpen)
        {
            return (X == 14 && Y == 0);
        }
        return false;
    }

}
class PlayerDrawer : Element
{
    public Player Player { get; set; }
    public PlayerDrawer(Player player)
    {
        Player = player;

    }
    public override void Update()
    {
        Position = new Point(Player.PlayerX, Player.PlayerY);
    }
    protected override void OnRender()
    {
        Renderer.Write("  ", background: Color.Black);


    }
}