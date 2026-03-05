using System;
using System.Collections.Generic;
using System.Text;

abstract class Unit
{
    public string Name { get; set; }
    public int Hp;

    public Unit(string name, int hp)
    {
        Name = name;
        Hp = hp;
    }

    public abstract void Attack();

    public override string ToString()
    {
        return $"{Name}(HP: {Hp})";
    }

}