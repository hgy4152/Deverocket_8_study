

// See https://aka.ms/new-console-template for more information
string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

// 'a' 포함 → 길이순 정렬 → 대문자 변환
var query = names
    .Where(n => n.Contains("a"))
    .OrderBy(n => n.Length)
    .Select(n => n.ToUpper());


foreach (var name in query)
{
    Console.WriteLine(name);
}