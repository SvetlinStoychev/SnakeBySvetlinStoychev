using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MySnake
{
    class Snake
    {
        private Queue<SnakeElement> snake;
        private Food currentFood = null;
        private SnakeElement snakeHead;
        private bool right = true;
        private bool left = false;
        private bool up = false;
        private bool down = false;
        private int snakeSpeed = 3;
        private int foodTime = 30000;
        private int score = 0;
        private int speed = 1;
        private bool isFreestyleMode = false;

        public void ResetGame()
        {
            this.right = true;
            this.left = false;
            this.up = false;
            this.down = false;
            this.score = 0;
            this.speed = 1;
            this.snakeSpeed = 300;
        }

        private void MoveSnake()
        {
            SnakeElement currentElement = null;
            if (this.right && this.snakeHead.Col < 60 - 1)
            {
                currentElement = this.snake.Dequeue();
                Console.SetCursorPosition(currentElement.Col, currentElement.Row);
                Console.Write(" ");
                this.snakeHead.Col++;
                Console.SetCursorPosition(this.snakeHead.Col, this.snakeHead.Row);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("@");
                Console.ResetColor();
                this.snake.Enqueue(new SnakeElement(this.snakeHead.Row, this.snakeHead.Col));
            }
            else if (this.left && this.snakeHead.Col > 0)
            {
                currentElement = this.snake.Dequeue();
                Console.SetCursorPosition(currentElement.Col, currentElement.Row);
                Console.Write(" ");
                this.snakeHead.Col--;
                Console.SetCursorPosition(this.snakeHead.Col, this.snakeHead.Row);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("@");
                Console.ResetColor();
                this.snake.Enqueue(new SnakeElement(this.snakeHead.Row, this.snakeHead.Col));
            }
            else if (this.up && this.snakeHead.Row > 0)
            {
                currentElement = this.snake.Dequeue();
                Console.SetCursorPosition(currentElement.Col, currentElement.Row);
                Console.Write(" ");
                this.snakeHead.Row--;
                Console.SetCursorPosition(this.snakeHead.Col, this.snakeHead.Row);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("@");
                Console.ResetColor();
                this.snake.Enqueue(new SnakeElement(this.snakeHead.Row, this.snakeHead.Col));
            }
            else if (this.down && this.snakeHead.Row < Console.WindowHeight - 1)
            {
                currentElement = this.snake.Dequeue();
                Console.SetCursorPosition(currentElement.Col, currentElement.Row);
                Console.Write(" ");
                this.snakeHead.Row++;
                Console.SetCursorPosition(this.snakeHead.Col, this.snakeHead.Row);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("@");
                Console.ResetColor();
                this.snake.Enqueue(new SnakeElement(this.snakeHead.Row, this.snakeHead.Col));
            }
        }

        private bool CheckForCrash()
        {
            int numOfEqualElement = 0;
            foreach (var item in this.snake)
            {
                if ((this.snakeHead.Row == item.Row) && this.snakeHead.Col == item.Col)
                {
                    numOfEqualElement++;
                }
            }
            if (this.snakeHead.Row == 0)
            {
                return true;
            }
            else if (this.snakeHead.Row == Console.WindowHeight - 1)
            {
                return true;
            }
            else if (this.snakeHead.Col == 0)
            {
                return true;
            }
            else if (this.snakeHead.Col == 59)
            {
                return true;
            }
            else if (numOfEqualElement > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void CreateFood()
        {
            Random rndGenerator = new Random();
            int foodRow = rndGenerator.Next(2, Console.WindowHeight - 3);
            int foodCol = rndGenerator.Next(2, 58);
            this.currentFood = new Food(foodRow, foodCol);
        }

        private void ClearFood()
        {
            Console.SetCursorPosition(this.currentFood.Col, this.currentFood.Row);
            Console.Write(" ");
        }

        private void PrintFood()
        {
            Console.SetCursorPosition(this.currentFood.Col, this.currentFood.Row);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("*");
            Console.ResetColor();
        }

        private void PrintScore()
        {
            Console.SetCursorPosition(72, 5);
            Console.Write(this.score);
        }

        private void PrintSpeed()
        {
            Console.SetCursorPosition(72, 8);
            Console.Write(this.speed);
        }

        private void CheckSpeed()
        {
            if (this.score == 10)
            {
                this.speed++;
                this.PrintSpeed();
                this.snakeSpeed = this.snakeSpeed - 40;
            }
            else if(this.score == 20)
            {
                this.speed++;
                this.PrintSpeed();
                this.snakeSpeed = this.snakeSpeed - 40;
            }
            else if (this.score == 30)
            {
                this.speed++;
                this.PrintSpeed();
                this.snakeSpeed = this.snakeSpeed - 30;
            }
            else if (this.score == 40)
            {
                this.speed++;
                this.PrintSpeed();
                this.snakeSpeed = this.snakeSpeed - 30;
            }
            else if (this.score == 50)
            {
                this.speed++;
                this.PrintSpeed();
                this.snakeSpeed = this.snakeSpeed - 30;
            }
            else if (this.score == 60)
            {
                this.speed++;
                this.PrintSpeed();
                this.snakeSpeed = this.snakeSpeed - 20;
            }
            else if (this.score == 70)
            {
                this.speed++;
                this.PrintSpeed();
                this.snakeSpeed = this.snakeSpeed - 20;
            }
            else if (this.score == 80)
            {
                this.speed++;
                this.PrintSpeed();
                this.snakeSpeed = this.snakeSpeed - 20;
            }
            else if (this.score == 90)
            {
                this.speed++;
                this.PrintSpeed();
                this.snakeSpeed = this.snakeSpeed - 20;
            }
        }

        public void FreestyleMode()
        {
            Console.Clear();
            Console.Write("Please, enter speed: ");
            string line = Console.ReadLine();
            int speed;
            while (true)
            {
                if (int.TryParse(line, out speed))
                {
                    if (speed >= 1 && speed <= 10)
                    {
                        if (speed == 2)
                        {
                            this.snakeSpeed = this.snakeSpeed - 40;
                            this.speed = 2;
                        }
                        else if (speed == 3)
                        {
                            this.snakeSpeed = this.snakeSpeed - 80;
                            this.speed = 3;
                        }
                        else if (speed == 4)
                        {
                            this.snakeSpeed = this.snakeSpeed - 110;
                            this.speed = 4;
                        }
                        else if (speed == 5)
                        {
                            this.snakeSpeed = this.snakeSpeed - 140;
                            this.speed = 5;
                        }
                        else if (speed == 6)
                        {
                            this.snakeSpeed = this.snakeSpeed - 170;
                            this.speed = 6;
                        }
                        else if (speed == 7)
                        {
                            this.snakeSpeed = this.snakeSpeed - 190;
                            this.speed = 7;
                        }
                        else if (speed == 8)
                        {
                            this.snakeSpeed = this.snakeSpeed - 210;
                            this.speed = 8;
                        }
                        else if (speed == 9)
                        {
                            this.snakeSpeed = this.snakeSpeed - 230;
                            this.speed = 9;
                        }
                        else
                        {
                            this.snakeSpeed = this.snakeSpeed - 250;
                            this.speed = 10;
                        }
                        Console.Clear();
                        this.isFreestyleMode = true;
                        this.CreateScreen();
                        this.CreateSnake();
                        this.PrintSnake();
                        this.CreateFood();
                        this.PrintFood();
                        this.RunGame();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalide speed: {0}", line);
                        Console.WriteLine();
                        Console.WriteLine("speed must be from 1 to 10");
                        Console.WriteLine();
                        Console.Write("try again: ");
                        line = Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalide speed: {0}", line);
                    Console.WriteLine();
                    Console.WriteLine("speed must be from 1 to 10");
                    Console.WriteLine();
                    Console.Write("try again: ");
                    line = Console.ReadLine();
                }
            }
        }

        public void StandartMode()
        {
            Console.Clear();
            this.CreateScreen();
            this.CreateSnake();
            this.PrintSnake();
            this.CreateFood();
            this.PrintFood();
            this.RunGame();
        }

        private bool CheckForFood()
        {
            if ((this.snakeHead.Row == this.currentFood.Row) && (this.snakeHead.Col == this.currentFood.Col))
            {
                this.snake.Enqueue(new SnakeElement(this.currentFood.Row, this.currentFood.Col));
                this.score++;
                this.PrintScore();
                if (!this.isFreestyleMode)
                {
                    this.CheckSpeed();
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private void RunGame()
        {
            this.PrintSpeed();
            int startSnake = Environment.TickCount;
            int endSnake = startSnake + this.snakeSpeed;
            int startFood = Environment.TickCount;
            int endFood = startFood + this.foodTime;
            ConsoleKeyInfo userInput;
            bool isCrash = false;
            while (!isCrash)
            {
                if (Console.KeyAvailable)
                {
                    userInput = Console.ReadKey(true);
                    if (this.right)
                    {
                        if (userInput.Key == ConsoleKey.UpArrow)
                        {
                            this.right = false;
                            this.up = true;
                        }
                        else if (userInput.Key == ConsoleKey.DownArrow)
                        {
                            this.right = false;
                            this.down = true;
                        }
                    }
                    else if (this.left)
                    {
                        if (userInput.Key == ConsoleKey.UpArrow)
                        {
                            this.left = false;
                            this.up = true;
                        }
                        else if (userInput.Key == ConsoleKey.DownArrow)
                        {
                            this.left = false;
                            this.down = true;
                        }
                    }
                    else if (this.up)
                    {
                        if (userInput.Key == ConsoleKey.LeftArrow)
                        {
                            this.up = false;
                            this.left = true;
                        }
                        else if (userInput.Key == ConsoleKey.RightArrow)
                        {
                            this.up = false;
                            this.right = true;
                        }
                    }
                    else if (this.down)
                    {
                        if (userInput.Key == ConsoleKey.LeftArrow)
                        {
                            this.down = false;
                            this.left = true;
                        }
                        else if (userInput.Key == ConsoleKey.RightArrow)
                        {
                            this.down = false;
                            this.right = true;
                        }
                    }

                    if (userInput.Key == ConsoleKey.D1)
                    {
                        Console.SetCursorPosition(66, 20);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("- PAUSE -");
                        Console.ResetColor();
                        ConsoleKeyInfo pause = Console.ReadKey(true);
                        if (pause.Key != ConsoleKey.D1)
                        {
                            pause = Console.ReadKey(true);
                        }
                        else
                        {
                            Console.SetCursorPosition(66, 20);
                            Console.Write("          ");
                        }
                    }
                    else if (userInput.Key == ConsoleKey.D2)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(61, 20);
                        Console.Write("do you want to exit: ");
                        Console.SetCursorPosition(66, 22);
                        Console.Write("- Y / N -");
                        Console.ResetColor();
                        ConsoleKeyInfo exit = Console.ReadKey(true);
                        if (exit.Key == ConsoleKey.Y)
                        {
                            break;
                        }
                        else
                        {
                            Console.SetCursorPosition(61, 20);
                            Console.Write("                      ");
                            Console.SetCursorPosition(66, 22);
                            Console.Write("          ");
                        }
                    }
                }
                startFood = Environment.TickCount;
                if (startFood >= endFood)
                {
                    this.ClearFood();
                    this.CreateFood();
                    this.PrintFood();
                    startFood = Environment.TickCount;
                    endFood = startFood + this.foodTime;
                }
                startSnake = Environment.TickCount;
                if (startSnake >= endSnake)
                {
                    this.MoveSnake();
                    this.PrintFood();
                    isCrash = this.CheckForCrash();
                    if (this.CheckForFood())
                    {
                        this.CreateFood();
                        this.PrintFood();
                        startFood = Environment.TickCount;
                        endFood = startFood + this.foodTime;
                    }
                    startSnake = Environment.TickCount;
                    endSnake = startSnake + this.snakeSpeed;
                }
            }
            Console.SetCursorPosition(25, Console.WindowHeight / 2);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("- GAME OVER -");
            Console.ResetColor();
            Thread.Sleep(1500);
        }

        private void PrintSnake()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var item in this.snake)
            {
                Console.SetCursorPosition(item.Col, item.Row);
                Console.Write("@");
            }
            Console.ResetColor();
        }

        private void CreateSnake()
        {
            this.snake = new Queue<SnakeElement>();

            this.snake.Enqueue(new SnakeElement(Console.WindowHeight / 2, 28));
            this.snake.Enqueue(new SnakeElement(Console.WindowHeight / 2, 29));
            this.snake.Enqueue(new SnakeElement(Console.WindowHeight / 2, 30));
            this.snake.Enqueue(new SnakeElement(Console.WindowHeight / 2, 31));

            this.snakeHead = new SnakeElement(Console.WindowHeight / 2, 31);
        }

        private void CreateScreen()
        {
            Console.CursorVisible = false;
            Console.BufferWidth = Console.WindowWidth;
            Console.BufferHeight = Console.WindowHeight;
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Console.SetCursorPosition(60, i);
                Console.Write("|");
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            for (int i = 0; i < 60; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("@");
            }
            for (int i = 0; i < 60; i++)
            {
                Console.SetCursorPosition(i, Console.WindowHeight - 1);
                Console.Write("@");
            }
            for (int i = 0; i < Console.WindowHeight - 1; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("@");
            }
            for (int i = 0; i < Console.WindowHeight - 1; i++)
            {
                Console.SetCursorPosition(59, i);
                Console.Write("@");
            }
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(66, 3);
            Console.Write("- SNAKE -");
            Console.SetCursorPosition(62, 11);
            Console.Write("Options: ");
            Console.ResetColor();
            Console.SetCursorPosition(65, 5);
            Console.Write("score: ");
            Console.SetCursorPosition(65, 8);
            Console.Write("speed: ");
            Console.SetCursorPosition(62, 13);
            Console.Write("press: ");
            Console.SetCursorPosition(66, 15);
            Console.Write("1 - pause:");
            Console.SetCursorPosition(66, 17);
            Console.Write("2 - exit:");

        }
    }
}
