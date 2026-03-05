using System;
using System.Collections.Generic;
using System.Text;

class Minion
{
    public string Name;
    public int Hp;
    public int atk;


    public void Attack()
    {
        Console.WriteLine($"{Name}이 공격합니다!");
    }

    public override string ToString()
    {
        return $"{Name}(HP: {Hp})";
    }
}
