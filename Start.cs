using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySnake
{
     class Start
    {
        static void Main(string[] args)
        {
            Snake snakeTest = new Snake();
            Console.CursorVisible = false;
            while (true)
            {
                snakeTest.ResetGame();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                for (int i = 0; i < Console.WindowWidth; i++)
                {
                    Console.SetCursorPosition(i, 3);
                    Console.Write("=");
                }
                for (int i = 0; i < Console.WindowWidth; i++)
                {
                    Console.SetCursorPosition(i, 20);
                    Console.Write("=");
                }
                for (int i = 4; i <= 19; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write("*");
                }
                for (int i = 4; i <= 19; i++)
                {
                    Console.SetCursorPosition(Console.WindowWidth - 1, i);
                    Console.Write("*");
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition((Console.WindowWidth / 2) - 6, 5);
                Console.Write("- SNAKE -");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(5, 8);
                Console.Write("Press: ");
                Console.SetCursorPosition(13, 10);
                Console.Write("1 - Standard Mode");
                Console.SetCursorPosition(13, 12);
                Console.Write("2 - Freestyle Mode");
                Console.SetCursorPosition(13, 14);
                Console.Write("3 - Exit");
                Console.ResetColor();

                ConsoleKeyInfo userInput = Console.ReadKey(true);
                if (userInput.Key == ConsoleKey.D1)
                {
                    snakeTest.StandartMode();
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    for (int i = 0; i < Console.WindowWidth; i++)
                    {
                        Console.SetCursorPosition(i, 3);
                        Console.Write("=");
                    }
                    for (int i = 0; i < Console.WindowWidth; i++)
                    {
                        Console.SetCursorPosition(i, 20);
                        Console.Write("=");
                    }
                    for (int i = 4; i <= 19; i++)
                    {
                        Console.SetCursorPosition(0, i);
                        Console.Write("*");
                    }
                    for (int i = 4; i <= 19; i++)
                    {
                        Console.SetCursorPosition(Console.WindowWidth - 1, i);
                        Console.Write("*");
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition((Console.WindowWidth / 2) - 6, 5);
                    Console.Write("- SNAKE -");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.SetCursorPosition(5, 8);
                    Console.Write("Press: ");
                    Console.SetCursorPosition(13, 10);
                    Console.Write("1 - Standard Mode");
                    Console.SetCursorPosition(13, 12);
                    Console.Write("2 - Freestyle Mode");
                    Console.SetCursorPosition(13, 14);
                    Console.Write("3 - Exit");
                    Console.ResetColor();
                    
                }
                else if (userInput.Key == ConsoleKey.D2)
                {
                    snakeTest.FreestyleMode();
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    for (int i = 0; i < Console.WindowWidth; i++)
                    {
                        Console.SetCursorPosition(i, 3);
                        Console.Write("=");
                    }
                    for (int i = 0; i < Console.WindowWidth; i++)
                    {
                        Console.SetCursorPosition(i, 20);
                        Console.Write("=");
                    }
                    for (int i = 4; i <= 19; i++)
                    {
                        Console.SetCursorPosition(0, i);
                        Console.Write("*");
                    }
                    for (int i = 4; i <= 19; i++)
                    {
                        Console.SetCursorPosition(Console.WindowWidth - 1, i);
                        Console.Write("*");
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition((Console.WindowWidth / 2) - 6, 5);
                    Console.Write("- SNAKE -");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.SetCursorPosition(5, 8);
                    Console.Write("Press: ");
                    Console.SetCursorPosition(13, 10);
                    Console.Write("1 - Standard Mode");
                    Console.SetCursorPosition(13, 12);
                    Console.Write("2 - Freestyle Mode");
                    Console.SetCursorPosition(13, 14);
                    Console.Write("3 - Exit");
                    Console.ResetColor();
                    
                }
                else if (userInput.Key == ConsoleKey.D3)
                {
                    break;
                }
            }

        }
    }
}
