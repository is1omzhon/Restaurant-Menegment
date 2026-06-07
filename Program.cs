using Services.Helpers;

var storage = new FileStorage("test.json");

// Saqlash
var names = new List<string> { "Ali", "Vali", "Hasan" };
storage.Save(names);
Console.WriteLine("Saved!");

// Yuklash
var loadedNames = storage.Load<List<string>>();
foreach (var name in loadedNames)
{
    Console.WriteLine(name);
}