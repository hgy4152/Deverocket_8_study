using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
class Pokemon
{
    private string name;
    private int attack;
    private int defense;
    private string type;
    public static int totalCount = 0;

    public readonly int health;
    
    private int currentHealth;
    private static bool battleEnd = false;

    public Pokemon(string name, int attack, int defense, string type, int health)
    {
        this.name = name;
        this.attack = attack;
        this.defense = defense;
        this.type = type;
        this.health = health;
        currentHealth = health;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"[{name}] 타입: {type}");
        Console.WriteLine($"HP: {health}");
        Console.WriteLine($"Atk: {attack}");
        Console.WriteLine($"Def: {defense}");
        Console.WriteLine();
    }

    public static void Battle(Pokemon pokemon1, Pokemon pokemon2)
    {
        Console.WriteLine("=== 포켓몬 배틀 시작 ===");
        Console.WriteLine($"    {pokemon1.name} vs {pokemon2.name}");
        Console.WriteLine("------------------------");

        while (battleEnd == false)
        {

            pokemon1.Attack(pokemon2);
            pokemon2.Attack(pokemon1);
        }
    }

    public void Attack(Pokemon pokemon)
    {
        int damage = TotalDamage(this.attack, pokemon.defense);
        pokemon.Damaged(damage, this);
    }

    public void Damaged(int damage, Pokemon pokemon)
    {


        if (damage > 0 && currentHealth > damage)
        {
            currentHealth -= damage;
            Console.WriteLine($"{pokemon.name} 공격! -> {name}");
            Console.WriteLine($"{name}이(가) {pokemon.name}에게 {damage}데미지를 받았습니다!\n{name} 체력:{currentHealth}");
            Console.WriteLine();
        }
        else if (damage > currentHealth && pokemon.currentHealth > 0)
        {
            currentHealth = 0;
            battleEnd = true;
            Console.WriteLine($"{pokemon.name} 공격! -> {name}");
            Console.WriteLine($"{name}이(가) {pokemon.name}에게 {damage} 데미지를 받았습니다!\n{name} 체력:{currentHealth}");
            Console.WriteLine($"{name}이(가) 쓰러졌습니다!");
        }
        else if (pokemon.currentHealth <= 0)
        {
            battleEnd = true;
        }
        
    }

    public int TotalDamage(int attack, int defense)
    {
        return (attack * (100 - defense) / 100)/2;
    }

}