using System;
using System.Collections.Generic;
using System.Text;

class Minion : Unit
{
    public Minion(string name, int hp) : base(name, hp) { }

    public override void Attack()
    {
        Console.WriteLine($"{Name}이(가) 공격합니다.");
    }
}
