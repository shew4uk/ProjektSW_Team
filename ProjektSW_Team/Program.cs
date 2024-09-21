using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using FastConsole.Engine.Elements;
using FastConsole.Engine.Core;
using ProjektSW_Team;
using ProjektSW_Team.Rooms;

delegate Scene Scene();



class Program
{
    public static TheWorld World;
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
        World = new TheWorld();
        World.SwitchRoom(typeof(Room1));
        const int FPS = 30;
        const int frameTime = 1000 / FPS;
        bool isRunning = true;
        Player player = World.Player;
        List<Bullet> bullets = new List<Bullet>();

        List<Element> elements = new List<Element>();
        Canvas Rooms = new Canvas(new Size(1, 1));
        PlayerDrawer playerdrawer = new PlayerDrawer(player);
        elements.Add(World);

        Rooms.CellWidth = 1;
        
        


        elements.Add(Rooms);
        elements.Add(playerdrawer);
        while (isRunning)
        {
            if (Time.TryUpdate())
            {

                Element.UpdateAndRender(elements);
                //Console.WriteLine("Game Scene");



                player.HandleInput(World.CurrentRoom);

                foreach (var bullet in bullets)
                {
                    bullet.Move();
                    //bullet.Draw();
                }

                // bullets.RemoveAll(b => b.IsOutOfRange() || b.IsCollidingWithWall(CurrentRoom.ToString()) || b.IsCollidingWithDoor(CurrentRoom.ToString()));

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

    public void HandleInput(Room Room)
    {
        while (Console.KeyAvailable)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                
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



    public bool IsOutOfRange()
    {
        return distanceTraveled >= Range;
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