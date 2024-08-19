using System.Security.Cryptography;

List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Enchanted Wand",
        Price = 45.00M,
        Available = true,
        ProductTypeId = 4 
    },
    new Product()
    {
        Name = "Spellbook of Ancient Runes",
        Price = 75.50M,
        Available = true,
        ProductTypeId = 3
    },
    new Product()
    {
        Name = "Potion of Eternal Youth",
        Price = 120.00M,
        Available = false, 
        ProductTypeId = 2
    },
    new Product()
    {
        Name = "Crystal Ball",
        Price = 90.25M,
        Available = true,
        ProductTypeId = 3
    },
    new Product()
    {
        Name = "Mystic Amulet",
        Price = 55.00M,
        Available = true,
        ProductTypeId = 1
    },
    new Product()
    {
        Name = "Dragon Scale Armor",
        Price = 250.00M,
        Available = true,
        ProductTypeId = 1
    },
    new Product()
    {
        Name = "Healing Potion",
        Price = 35.00M,
        Available = true,
        ProductTypeId = 2
    },
    new Product()
    {
        Name = "Wizard's Hat",
        Price = 25.00M,
        Available = true,
        ProductTypeId = 1
    },
    new Product()
    {
        Name = "Magic Carpet",
        Price = 500.00M,
        Available = true,
        ProductTypeId = 3
    },
    new Product()
    {
        Name = "Teleportation Wand",
        Price = 60.00M,
        Available = true,
        ProductTypeId = 4
    }
};

List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType()
    {
        Name = "Apparel",
        Id = 1
    },
    new ProductType()
    {
        Name = "Potions",
        Id = 2
    },
    new ProductType()
    {
        Name = "Enchanted Objects",
        Id = 3
    },
    new ProductType()
    {
        Name = "Wands",
        Id = 4
    }
};

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
            ListProducts();
            break;
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

string ProductDetails(Product product, int index)
{
    string productString = @$"{index + 1}. {product.Name} - Price: {product.Price:C}  {(product.Available ? "✅ In Stock!" : "🚫 Out of Stock")}
------------------------------------------------------------------";

    return productString;
}

void ReturnToMenu()
{
    Console.WriteLine("\nPress any button to return to menu");
    Console.ReadKey();
    Console.Clear();
}

void ListProducts()
{
    Console.Clear();
    Console.WriteLine("ALL PRODUCTS\n");

    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine(ProductDetails(products[i], i));
    }

    ReturnToMenu();
}
