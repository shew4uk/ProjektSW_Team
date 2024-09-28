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

        TheWorld TWI  = new TheWorld();
        TWI.SwitchRoom(typeof(Room1));
        const int FPS = 30;
        const int frameTime = 1000 / FPS;
        bool isRunning = true;
        Player player = TWI.Player;


        List<Element> elements = new List<Element>();
        Canvas Rooms = new Canvas(new Size(1, 1));

        elements.Add(TWI);

        Rooms.CellWidth = 1;
        
        


        elements.Add(Rooms);

        while (isRunning)
        {
            if (Time.TryUpdate())
            {

                Element.UpdateAndRender(elements);
                



                

                
                

                
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



