Console.Clear();
Console.WriteLine(@"✨🧙‍♂️ Welcome to Reductio & Absurdum! 🧙‍♂️✨

For nearly 1000 years, we've enchanted wizards with our magical supplies. 
Explore our digitized realm and discover the wonders we offer!");
Console.WriteLine("\nPress any key to unlock the magic and begin your journey!");
Console.ReadKey();
Console.Clear();

string logo = "🧙 Reductio & Absurdum 🪄";

string choice = null;

while (choice != "e") 
{
    Console.WriteLine(@$"{logo}
Choose an option:
    a. View all products
    b. Add a product to the inventory
    c. Delete a product from the inventory
    d. Update a product's details
    e. EXIT");

    choice = Console.ReadLine();

    switch (choice)
    {
        case "a":
            throw new NotImplementedException("View all products");
        case "b":
            throw new NotImplementedException("Add a product to the inventory");
        case "c":
            throw new NotImplementedException("Delete a product from the inventory");
        case "d":
            throw new NotImplementedException("Update a product's details");
        case "e":
            Console.Clear();
            Console.WriteLine("🧙‍♂️🌟 Goodbye! May your journey be enchanted. 🌟🧙‍♂️");
            break;
        default:
            Console.WriteLine("\n💥 Oops! That spell isn't known. Please choose a valid option. 💥 \n");
            break;
    }
}


