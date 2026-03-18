using System;
using System.Collections.Generic;
using System.Text;
using Framework.Engine;


public class SnakeGame : GameApp
{

    private readonly SceneManager<Scene> _scenes = new SceneManager<Scene>();

    public SnakeGame() : base(40, 20)
    {

    }
    public SnakeGame(int width, int height) : base(width, height)
    {

    }


    protected override void Initialize()
    {
        ChangeToTitle();
    }

    protected override void Update(float deltaTime)
    {
        // 키다운시 종료
        if(Input.IsKeyDown(ConsoleKey.Escape))
        {
            Quit();
            return;
        }

        // 현재 화면 업뎃
        _scenes.CurrentScene?.Update(deltaTime);
    }

    protected override void Draw()
    {
        // 현재 화면 그리기
        _scenes.CurrentScene?.Draw(Buffer);

    }

    private void ChangeToTitle()
    {
        var title = new TitleScene();
        title.StartRequested += ChangeToPlay; // 플레이 씬 실행 이벤트 추가
        _scenes.ChangeScene(title);
    }

    private void ChangeToPlay()
    {
        var play = new PlayScene();
        play.PlayAgainRequested += ChangeToTitle;
        _scenes.ChangeScene(play);
    }

}