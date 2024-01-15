// Inlämningsuppgift 1 L0002B - Kristoffer Flygare
// Först skriver vi ut att applikation startar och frågar efter input
Console.WriteLine("Startar växelräknare...");
Console.WriteLine("Ange pris:");
// Vi konverterar input till int
int cost = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Betalt:");
int payed = Convert.ToInt32(Console.ReadLine());
// Här deklarerar vi all olika sedlar/mynt vi vill dela upp betalningen i.
int[] sedlar = { 500, 200, 100, 50, 20, 10, 5, 1 };
Dictionary<int,Dictionary<string, string>> sedlarmynt = new Dictionary<int, Dictionary<string, string>>{
    {500, new Dictionary<string, string>{{"femhundralapp", "femhundralappar"}}},
    {200, new Dictionary<string, string>{{"tvåhundralapp", "tvåhundralappar"}}},
    {100, new Dictionary<string, string>{{"hundralapp", "hundralappar"}}},
    {50, new Dictionary<string, string>{{"femtiolapp", "femtiolappar"}}},
    {20, new Dictionary<string, string>{{"tjuga", "tjugor"}}},
    {10, new Dictionary<string, string>{{"tiokrona", "tiokronor"}}},
    {5, new Dictionary<string, string>{{"femkrona", "femkronor"}}},
    {1, new Dictionary<string, string>{{"enkrona", "enrkonor"}}}
};
// Vi kollar att vi fått in rimliga värden
if (payed > cost)
{
    Console.WriteLine("Växel tillbaka:");
    // Räknar ut växel
    int change = payed - cost;
    // För varje sedel/mynt i vår lista
    foreach (var outerDict in sedlarmynt)
    {
        // Först hämtar vi värdet i vår dictionary
        int outerKey = outerDict.Key;
        // Sedan hämtar vi texten som tillhör värdet
        var innerDict = outerDict.Value;
        // Vi sätter texten till singular
        string text = innerDict.First().Key;
        // Om det är plural av ett mynt/sedel
        if (change / outerKey > 1)
        {
            // Vi ändrar texten till plural och skriver ut antal och text
            text = innerDict.First().Value;
            Console.WriteLine(change / outerKey+" "+text);
        }
        // Om det är singular av ett mynt/sedel
        else if (change / outerKey == 1)
        {
            // Vi skriver ut antal och text
            Console.WriteLine(change / outerKey+" "+text);
        }
        // Här sätter vi växel till det kvarvarande värdet
        change = change % outerKey;
    }
}
else
{
    // Om input inte är rimligt (vi har betalat mindre än kostnaden) så skriver vi ut felmeddelande
    // Man skulle kunna tänka sig här att man skriver ut kvarvarande belopp istället.
    Console.WriteLine("Invalid input");
    return;
}