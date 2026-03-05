using System;
using System.Collections.Generic;
using System.Text;

class Champion
{
    public string Name;
    public int Hp;
    public int Mana;
    public int atk;
    public void Attack()
    {
        Console.WriteLine($"{Name}이(가) 공격합니다!");
    }

    public override string ToString()
    {
        return $"{Name}(HP: {Hp})";
    }
}