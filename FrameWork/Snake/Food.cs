using Framework.Engine;
using System;
using System.Collections.Generic;
using System.Text;



public class Food : GameObject
{
    private Random rnd = new Random();
    public (int X, int Y) foodPosition;

    public Food(Scene scene) : base(scene)
    {
        Name = "Food";


    }

    public override void Draw(ScreenBuffer buffer)
    {

        buffer.SetCell(foodPosition.X, foodPosition.Y, '*', ConsoleColor.Red);

    }

    public override void Update(float deltaTime)
    {

    }

    public void Spawn(LinkedList<(int X, int Y)> snakePos, int Left, int Right, int Top, int Bottom)
    {

            bool isDuplicate = false;

            do
            {
                foodPosition.X = rnd.Next(Left, Right);
                foodPosition.Y = rnd.Next(Top, Bottom);
                isDuplicate = snakePos.Contains(foodPosition);
            } while (isDuplicate);

    }
}