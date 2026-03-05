// See https://aka.ms/new-console-template for more information


Minion[] minions = new Minion[]
{
    new Minion{Name = "근접 미니언", Hp = 477, atk = 12},
};


Champion[] champions = new Champion[]
{
    new Champion{ Name = "애쉬", Hp = 600, atk = 60, Mana = 280 }
};

Turret[] turrets= new Turret[]
{
    new Turret{ Name = "외곽 포탑", Hp = 5000, atk = 150}
};


Console.WriteLine("=== 상속 없음 ===");

for (int i = 0; i < minions.Length; i++)
{
    Console.WriteLine(minions[i]);
}

for (int i = 0; i < champions.Length; i++)
{
    Console.WriteLine(champions[i]);

}

for (int i = 0; i < turrets.Length; i++)
{
    Console.WriteLine(turrets[i]);

}

for (int i = 0; i < minions.Length; i++)
{
    minions[i].Attack();
}

for (int i = 0; i < champions.Length; i++)
{
    champions[i].Attack();
}

for (int i = 0; i < turrets.Length; i++)
{
    turrets[i].Attack();
}


Console.WriteLine();
Console.WriteLine("==== 전투 ====");

// 새로운 종류의 유닛을 만들 때 마다
// 새로운 조합의 메소드를 만들어 줘야함
// 아니면 오브젝트로 받아야하는데... 박싱/언박싱이 일어나진 않긴해도
// 멤버를 쓰려면 타입을 전부 명시해줘야해서 불편함.
Battle1(minions[0], turrets[0]);
Battle2(minions[0], champions[0]);
Battle3(champions[0], turrets[0]);


void Battle1(Minion minion, Turret turret)
{
    Console.WriteLine($"{minion.Name}과 {turret.Name}이 싸웁니다.");
}
void Battle2(Minion minion, Champion champion)
{
    Console.WriteLine($"{minion.Name}과 {champion.Name}이 싸웁니다.");
}
void Battle3(Champion champion, Turret turret)
{
    Console.WriteLine($"{champion.Name}과 {turret.Name}이 싸웁니다.");
}