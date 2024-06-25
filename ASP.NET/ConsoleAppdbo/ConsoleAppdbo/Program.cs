using ConsoleAppdbo;

using (TestContext db = new TestContext()) 
{
    var fav = db.FruitsAndVegetables.ToList();
    fav.ForEach(i => Console.WriteLine(i));

    Console.WriteLine("\n---------------------------------\n");

    await db.FruitsAndVegetables.AddAsync(new FruitsAndVegetable {Name = "New Fruit", Calories = 201, Color="Violet", Type="Fruit"});
    await db.SaveChangesAsync();

    fav.ForEach(i => Console.WriteLine(i));

    var favfromid = db.FruitsAndVegetables.FirstOrDefault(i => i.Id == 1006);
}