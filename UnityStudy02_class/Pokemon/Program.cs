// See https://aka.ms/new-console-template for more information



string poke1_name = "피카츄";
int poke1_hp = 35;
int poke1_attack = 55;
int poke1_defense = 40;
string poke1_type = "전기";

string poke2_name = "파이리";
int poke2_hp = 39;
int poke2_attack = 52;
int poke2_defense = 43;
string poke2_type = "불꽃";

string poke3_name = "꼬부기";
int poke3_hp = 44;
int poke3_attack = 48;
int poke3_defense = 65;
string poke3_type= "물";

string poke4_name = "이상해씨";
int poke4_hp = 45;
int poke4_attack = 49;
int poke4_defense = 49;
string poke4_type = "풀";

string poke5_name = "잠만보";
int poke5_hp = 160;
int poke5_attack = 110;
int poke5_defense = 65;
string poke5_type = "노말";


int totalCount = 5;

Console.WriteLine(
    $"[{poke1_name}] 타입: {poke1_type}\n"+
    $"HP: {poke1_hp}\n"+
    $"Atk: {poke1_attack}\n"+
    $"Def: {poke1_defense}\n"
);

Console.WriteLine(
    $"[{poke2_name}] 타입: {poke2_type}\n"+
    $"HP: {poke2_hp}\n"+
    $"Atk: {poke2_attack}\n"+
    $"Def: {poke2_defense}\n"
);

Console.WriteLine(
    $"[{poke3_name}] 타입: {poke3_type}\n"+
    $"HP: {poke3_hp}\n"+
    $"Atk: {poke3_attack}\n"+
    $"Def: {poke3_defense}\n"
);

Console.WriteLine(
    $"[{poke4_name}] 타입: {poke4_type}\n"+
    $"HP: {poke4_hp}\n"+
    $"Atk: {poke4_attack}\n"+
    $"Def: {poke4_defense}\n"
);

Console.WriteLine(
    $"[{poke5_name}] 타입: {poke5_type}\n"+
    $"HP: {poke5_hp}\n"+
    $"Atk: {poke5_attack}\n"+
    $"Def: {poke5_defense}\n"
);

Console.WriteLine($"총 포켓몬 수: {totalCount}");