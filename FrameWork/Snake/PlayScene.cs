using Framework.Engine;
using System;
using System.Collections.Generic;
using System.Text;

public class PlayScene : Scene
{
    private Wall wall;
    private Snake snake;
    private Food food;

    private int score;
    private bool isGameOver; // 플래그

    public event GameAction PlayAgainRequested;

    public override void Load()
    {
        score = 0;
        isGameOver = false;

        wall = new Wall(this);
        AddGameObject(wall); // scene에 넣기

        snake = new Snake(this, 20, 10);
        AddGameObject(snake);

        food = new Food(this);
        food.Spawn(snake.Body, Wall.Left, Wall.Right, Wall.Top, Wall.Bottom);
        AddGameObject(food);
    }

    public override void Unload()
    {
        ClearGameObjects();
    }

    public override void Update(float deltaTime)
    {
        if(isGameOver) 
        {
            if(Input.IsKeyDown(ConsoleKey.Enter))
            {
                PlayAgainRequested?.Invoke();
            }
            return;
        }

        UpdateGameObjects(deltaTime);

        if (!wall.IsInBound(snake.HeadPosition))
        {
            // 게임오버
            isGameOver = true;
            return;
        }

        if(!snake.Alive)
        {
            isGameOver = true;
            return;
        }

        if(food.foodPosition == snake.HeadPosition)
        {
            snake.Grow();
            score += 10;
            food.Spawn(snake.Body, Wall.Left, Wall.Right, Wall.Top, Wall.Bottom);

        }

    }


    public override void Draw(ScreenBuffer buffer)
    {
        DrawGameObjects(buffer);

        buffer.WriteText(1, 0, $"Score: {score}", ConsoleColor.Cyan);
        buffer.WriteText(1, 19, "Arrow Keys: Move", ConsoleColor.DarkGray);



        if(isGameOver)
        {
            buffer.WriteTextCentered(8, "Game Over", ConsoleColor.Red);
            buffer.WriteTextCentered(10, $"Score: {score}", ConsoleColor.Yellow);
            buffer.WriteTextCentered(12, "Press ENTER to Retry", ConsoleColor.White);

        }
    }
}