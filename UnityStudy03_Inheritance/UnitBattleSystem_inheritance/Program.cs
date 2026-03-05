// See https://aka.ms/new-console-template for more information
Unit[] units = new Unit[]
{
    new Minion("근접 미니언", 120),
    new Champion("애쉬", 600),
    new Turret("외곽 포탑", 5000)

};
Console.WriteLine("=== 상속 있음 ===");


for (int i = 0; i < units.Length; i++)
{
    Console.WriteLine(units[i]);
}
for(int i = 0; i < units.Length; i++)
{
    units[i].Attack();
}

Console.WriteLine();
Console.WriteLine("==== 전투 ====");


for (int i = 0; i < units.Length; i++)
{
    for(int j = i+1; j < units.Length; j++)
        Battle(units[i], units[j]);
}

// switch 문까지 써서 범용성 있지만 더 디테일하게 작성 가능함
void Battle(Unit unit1, Unit unit2)
{
    Console.WriteLine($"{unit1.Name}과 {unit2.Name}이 싸웁니다.");
}