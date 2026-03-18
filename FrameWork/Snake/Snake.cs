using Framework.Engine;
using System;
using System.Collections.Generic;
using System.Text;

public class Snake : GameObject
{

    private const float k_MoveInterval = 0.15f; // 자동으로 움직이는 시간

    private readonly LinkedList<(int X, int Y)> _body = new LinkedList<(int X, int Y)>();

    private (int X, int Y) _direction;
    private (int X, int Y) _nextDirection; // 틱마다 움직이기 때문에 정보 갱신용 필드
    private float _moveTimer;
    private int _growCount;

    public bool Alive {  get; private set; } = true;
    public (int X, int Y) HeadPosition => _body.First.Value; // 충돌 체크
    public LinkedList<(int X, int Y)> Body => _body;


    public Snake(Scene scene, int startX, int startY) : base(scene)
    {
        Name = "Snake";

        _direction = (1, 0);
        _nextDirection = (1, 0);

        // 머리
        _body.AddLast((startX, startY));
        // 꼬리
        _body.AddLast((startX - 1, startY)); 
        _body.AddLast((startX - 2, startY));

    }
    public override void Update(float deltaTime)
    {
        if (!Alive)
        {
            return;
        }
        HandleInput();
        _moveTimer += deltaTime;

        // 자동 이동
        if (_moveTimer > k_MoveInterval)
        {
            Move();
            _moveTimer = 0f;
        }
    }

    private void HandleInput()
    {
        (int X, int Y) desired = _nextDirection; // 키입력 없을 시 자동이동 방향


        // 키입력 시 방향설정 
        if(Input.IsKeyDown(ConsoleKey.UpArrow))
        {
            desired = (0, -1);
        }

        else if(Input.IsKeyDown(ConsoleKey.DownArrow))
        {
            desired = (0, 1);

        }

        else if(Input.IsKeyDown(ConsoleKey.LeftArrow))
        {
            desired = (-1, 0);

        }

        else if(Input.IsKeyDown(ConsoleKey.RightArrow))
        {
            desired = (1, 0);

        }

        // 180도 회전은 불가함. 머리가 꼬리에 부딫히면 끝인 게임임. + 자동이동 안멈추게끔
        if (desired.X + _direction.X != 0 || desired.Y + _direction.Y != 0)
        {
            _nextDirection = desired;
        }
    }
    private void Move()
    {
        // 머리 이동
        _direction = _nextDirection;
        var newHead = (HeadPosition.X + _direction.X, HeadPosition.Y + _direction.Y);

        _body.AddFirst(newHead);

        // 먹었을 때 꼬리 증가. 안지우면 남아있는걸 이용
        if(_growCount > 0)
        {
            _growCount--;
        }
        else 
        {
            _body.RemoveLast();
        }


        var node = _body.First.Next; // 첫꼬리부터
        while (node != null)
        {

            // 꼬리 충돌 했는지 모든 꼬리 좌표 체크
            if(newHead == node.Value)
            {
                Alive = false;
                break;
            }

            node = node.Next;
        }
    }

    public override void Draw(ScreenBuffer buffer)
    {
        // 꼬리부터 그리기
        var node = _body.Last;

        while (node != _body.First)
        {
            buffer.SetCell(node.Value.X, node.Value.Y, 'o', ConsoleColor.DarkGreen);
            node = node.Previous;
        }

        buffer.SetCell(node.Value.X, node.Value.Y, '@', ConsoleColor.Green);



    }

    public void Grow()
    {
        _growCount++;
    }


}