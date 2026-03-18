using Framework.Engine;
using System;
using System.Collections.Generic;
using System.Text;




public class Wall : GameObject
{
    public const int Left = 1;
    public const int Right = 38;
    public const int Top = 2;
    public const int Bottom = 17;



    public Wall(Scene scene) : base(scene)
    {
        Name = "Wall"; // id 용
    }

    public override void Draw(ScreenBuffer buffer)
    {
        buffer.DrawBox(Left - 1, Top - 1, Right - Left + 3, Bottom - Top + 3, ConsoleColor.White);
    }

    public override void Update(float deltaTime)
    {

    }


    // 벽 충돌 감지
    public bool IsInBound(int x, int y)
    {
        return x >= Left && x <= Right && y >= Top && y <= Bottom;
    }
    public bool IsInBound((int x, int y) position)
    {
        return IsInBound(position.x, position.y);
    }
}