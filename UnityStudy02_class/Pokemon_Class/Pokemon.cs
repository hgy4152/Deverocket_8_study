using System;
using System.Collections.Generic;
using System.Text;
class Pokemon
{
    private string name;
    private int attack;
    private int defense;
    private string type;
    public static int totalCount = 0;

    public readonly int health;

    public Pokemon(string name, int attack, int defense, string type, int health)
    {
        this.name = name;
        this.attack = attack;
        this.defense = defense;
        this.type = type;
        this.health = health;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"[{name}] 타입: {type}");
        Console.WriteLine($"HP: {health}");
        Console.WriteLine($"Atk: {attack}");
        Console.WriteLine($"Def: {defense}");
        Console.WriteLine();
    }
}