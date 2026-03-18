using System;
using System.Collections.Generic;
using System.Text;
using Framework.Engine;
public class TitleScene : Scene
{
    public event GameAction StartRequested;

    public override void Load()
    {
    }

    public override void Unload()
    {
    }

    public override void Update(float deltaTime)
    {
        if (Input.IsKeyDown(ConsoleKey.Enter))
        {
            StartRequested?.Invoke(); // 다음 씬으로 넘어가기 구현
        }
    }

    public override void Draw(ScreenBuffer buffer)
    {
        // 위치는 하드 코딩
        buffer.WriteTextCentered(6, "S N A K E", ConsoleColor.Yellow);
        buffer.WriteTextCentered(10, "Arrow Keys: Move");
        buffer.WriteTextCentered(12, "ESC: Quit"); // 게임단위에서 종료
        buffer.WriteTextCentered(15, "Press ENTER to Start", ConsoleColor.Green); // 타이틀에서 실행
    }

}