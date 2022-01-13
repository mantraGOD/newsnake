using snake_game;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Snake_game
{
    class Program
    {
        private static int x0ffset;

        static void Main(string[] args)
        {
            int score = 0;
            //drawing a game field frame
            Walls walls = new Walls(80, 25);
            walls.Draw();

            Point snakeTail = new Point(15, 15, 's');
            Snake snake = new Snake(snakeTail, 5, Direction.RIGHT);
            snake.Draw();

            foodGenerator foodGenerator = new foodGenerator(80, 25, '$');
            Point food = foodGenerator.GenerateFood();
            food.Draw();
            
            while (true)
            {
                if(walls.IsHit(snake)  || snake.IsHitTail())
                {
                    break;
                }

                if(snake.Eat(food))
                {
                    food = foodGenerator.GenerateFood();
                    food.Draw();
                    score++;
                }else
                {
                    snake.Move();
                }

                if(Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKeys(key.Key);
                }

                Thread.Sleep(300);
            }

            string str_score = Convert.ToString(score);
            WriteGameOver(str_score);
            Console.ReadLine();
        }

        public static void WriteGameOver(string score)
        {
            int x0ffset = 25;
            int y0ffset = 8;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(x0ffset, x0ffset++);
            WriteText("                               =======================", x0ffset, y0ffset++);
            WriteText("                                       GAME OVER                                 ", x0ffset+1, y0ffset++);
            y0ffset++; 
            WriteText($"                              You scored {score} points", x0ffset + 2, y0ffset++);
            WriteText("", x0ffset+1, y0ffset++);
            WriteText("                               =======================", x0ffset, y0ffset++);
        }
        public static void WriteText(String next,int xOffset, int y0ffset)
        {
            Console.SetCursorPosition(x0ffset, y0ffset);
            Console.WriteLine(next);
        }
    }
}