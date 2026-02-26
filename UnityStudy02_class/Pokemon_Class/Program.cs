// See https://aka.ms/new-console-template for more information


Pokemon poke1 = new Pokemon("피카츄", 55, 40, "전기", 35);
Pokemon.totalCount++;
poke1.ShowInfo();

Pokemon poke2 = new Pokemon("파이리", 52, 43, "불꽃", 39);
Pokemon.totalCount++;
poke2.ShowInfo();

Pokemon poke3 = new Pokemon("꼬부기", 48, 65, "물", 44);
Pokemon.totalCount++;
poke3.ShowInfo();

Pokemon poke4 = new Pokemon("이상해씨", 49, 49, "풀", 45);
Pokemon.totalCount++;
poke4.ShowInfo();

Pokemon poke5 = new Pokemon("잠만보", 110, 65, "노말", 160);
Pokemon.totalCount++;
poke5.ShowInfo();


Console.WriteLine($"총 포켓몬 수: {Pokemon.totalCount}");