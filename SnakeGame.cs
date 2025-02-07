using System;
using System.Collections.Generic;
using SnakeGame;
using System.Drawing;

namespace SnakeGame
{
    class Program
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Random random = new Random();
            Coord gridDimensions = new Coord(50, 20);
            int frameDelayMilli = 100;
            int snakeSpeed = 1;
            int maxSpeed = 50;

            char[] appleSymbols = { '#', '@', '%', '*', '&' };

            while (true)
            {
                Console.CursorVisible = false;

                int score = 0;
                Coord snakePos = new Coord(10, 1);
                Direction movementDirection = Direction.Down;
                List<Coord> snakePosHistory = new List<Coord>();
                int tailLength = 1;
                char appleSymbol = appleSymbols[random.Next(appleSymbols.Length)];
                Coord applePos = new Coord(random.Next(1, gridDimensions.X - 1), random.Next(1, gridDimensions.Y - 1));
                bool gameOver = false;
                string gameOverMessage = "";

                while (!gameOver)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine($"Score: {score}   Snake Speed: {snakeSpeed}");

                    for (int y = 0; y < gridDimensions.Y; y++)
                    {
                        for (int x = 0; x < gridDimensions.X; x++)
                        {
                            Coord currentCoord = new Coord(x, y);

                            if (snakePos.Equals(currentCoord) || snakePosHistory.Contains(currentCoord))
                                Console.Write("■");
                            else if (applePos.Equals(currentCoord))
                                Console.Write(appleSymbol);
                            else if (x == 0 || y == 0 || x == gridDimensions.X - 1 || y == gridDimensions.Y - 1)
                                Console.Write("═");
                            else
                                Console.Write(" ");
                        }
                        Console.WriteLine();
                    }

                    
                    snakePos.ApplyMovementDirection(movementDirection);

                   
                    if (snakePos.Equals(applePos))
                    {
                        tailLength++;
                        score++;
                        snakeSpeed = Math.Min(maxSpeed, snakeSpeed + 1);
                        frameDelayMilli = Math.Max(10, 100 - snakeSpeed * 2);
                        appleSymbol = appleSymbols[random.Next(appleSymbols.Length)];
                        applePos = new Coord(random.Next(1, gridDimensions.X - 1), random.Next(1, gridDimensions.Y - 1));
                    }
                    
                    else if (snakePosHistory.Contains(snakePos))
                    {
                        gameOver = true;
                        gameOverMessage = "Game Over! The snake bit itself!";
                        break;
                    }
                    
                    else if (snakePos.X == 0 || snakePos.Y == 0 || snakePos.X == gridDimensions.X - 1 || snakePos.Y == gridDimensions.Y - 1)
                    {
                        gameOver = true;
                        gameOverMessage = "Game Over! You hit the wall!";
                        break;
                    }

                    
                    snakePosHistory.Add(new Coord(snakePos.X, snakePos.Y));

                   
                    if (snakePosHistory.Count > tailLength)
                        snakePosHistory.RemoveAt(0);

                   
                    DateTime time = DateTime.Now;
                    while ((DateTime.Now - time).Milliseconds < frameDelayMilli)
                    {
                        if (Console.KeyAvailable)
                        {
                            ConsoleKey key = Console.ReadKey(true).Key;

                            if ((key == ConsoleKey.LeftArrow && movementDirection != Direction.Right) ||
                                (key == ConsoleKey.RightArrow && movementDirection != Direction.Left) ||
                                (key == ConsoleKey.UpArrow && movementDirection != Direction.Down) ||
                                (key == ConsoleKey.DownArrow && movementDirection != Direction.Up))
                            {
                                movementDirection = key switch
                                {
                                    ConsoleKey.LeftArrow => Direction.Left,
                                    ConsoleKey.RightArrow => Direction.Right,
                                    ConsoleKey.UpArrow => Direction.Up,
                                    ConsoleKey.DownArrow => Direction.Down,
                                    _ => movementDirection
                                };
                            }
                        }
                    }
                }

                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine($"     {gameOverMessage}");
                Console.WriteLine("========================================");
                Console.WriteLine($"Your total number of points is: {score}");
                Console.WriteLine("Press R to Retry or ESC to Quit");
                Console.WriteLine("========================================");

                bool validInput = false;
                while (!validInput)
                {
                    ConsoleKey retryKey = Console.ReadKey(true).Key;
                    if (retryKey == ConsoleKey.R)
                    {
                        validInput = true;
                        Console.Clear();
                        break;
                    }
                    else if (retryKey == ConsoleKey.Escape)
                    {
                        return;
                    }
                }
            }
        }
    }
}
