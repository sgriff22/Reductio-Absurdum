List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Enchanted Wand",
        Price = 45.00M,
        Available = true,
        ProductTypeId = 4,
        DateStocked = new DateTime(2024, 1, 15)
    },
    new Product()
    {
        Name = "Spellbook of Ancient Runes",
        Price = 75.50M,
        Available = true,
        ProductTypeId = 3,
        DateStocked = new DateTime(2024, 3, 22)
    },
    new Product()
    {
        Name = "Potion of Eternal Youth",
        Price = 120.00M,
        Available = false, 
        ProductTypeId = 2,
        DateStocked = new DateTime(2024, 5, 10)
    },
    new Product()
    {
        Name = "Crystal Ball",
        Price = 90.25M,
        Available = true,
        ProductTypeId = 3,
        DateStocked = new DateTime(2024, 7, 8)
    },
    new Product()
    {
        Name = "Mystic Amulet",
        Price = 55.00M,
        Available = true,
        ProductTypeId = 1,
        DateStocked = new DateTime(2024, 7, 30)
    },
    new Product()
    {
        Name = "Dragon Scale Armor",
        Price = 250.00M,
        Available = true,
        ProductTypeId = 1,
        DateStocked = new DateTime(2024, 2, 14)
    },
    new Product()
    {
        Name = "Healing Potion",
        Price = 35.00M,
        Available = true,
        ProductTypeId = 2,
        DateStocked = new DateTime(2024, 4, 1)
    },
    new Product()
    {
        Name = "Wizard's Hat",
        Price = 25.00M,
        Available = true,
        ProductTypeId = 1,
        DateStocked = new DateTime(2024, 6, 17)
    },
    new Product()
    {
        Name = "Magic Carpet",
        Price = 500.00M,
        Available = true,
        ProductTypeId = 3,
        DateStocked = new DateTime(2024, 8, 8)
    },
    new Product()
    {
        Name = "Teleportation Wand",
        Price = 60.00M,
        Available = true,
        ProductTypeId = 4,
        DateStocked = new DateTime(2024, 7, 5)
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

while (choice != "f") 
{
    Console.WriteLine(@$"{logo}
Choose an option:
    a. View all products
    b. Add a product to the inventory
    c. Delete a product from the inventory
    d. Update a product's details
    e. Search inventory by product type
    f. EXIT");

    choice = Console.ReadLine();

    switch (choice)
    {
        case "a":
            AllProducts();
            break;
        case "b":
            AddProduct();
            break;
        case "c":
            DeleteProduct();
            break;
        case "d":
            UpdateProduct();
            break;
        case "e":
            SearchProducts();
            break;
        case "f":
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
    string productString = @$"{index + 1}. {product.Name} | {product.Price:C} | {(product.Available ? "✅" : "🚫")} | {ProductTypeName(product.ProductTypeId)} | {product.DaysOnShelf}
------------------------------------------------------------------------";

    return productString;
}

void ReturnToMenu()
{
    Console.WriteLine("\nPress any button to return to menu");
    Console.ReadKey();
    Console.Clear();
}

string ProductTypeName(int productTypeId)
{
    string nameString = "";
    for (int i = 0; i < productTypes.Count; i++)
    {
        if (productTypes[i].Id == productTypeId)
        {
            nameString = productTypes[i].Name;
        }
    }
    return nameString;
}

void ListProducts()
{
    Console.WriteLine(@"   NAME   |  PRICE  |  IN STOCK  |  PRODUCT TYPE  |  DAYS ON SHELF
------------------------------------------------------------------------");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine(ProductDetails(products[i], i));
    }
}

void AllProducts()
{
    Console.Clear();
    Console.WriteLine("ALL PRODUCTS");
    ListProducts();
    ReturnToMenu();
}

void AddProduct()
{
    Console.Clear();
    Console.WriteLine("ADD PRODUCT");

    //Name
    bool validNameInput = false;
    string name = "";
    while(!validNameInput)
    {
        Console.WriteLine("Enter the product name:");
        try
        {
            name = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("🛑 Name cannot be empty.");
            }
            validNameInput = true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"✨ Oops! {ex.Message} ✨\n");
        }
    }

    //Price
    bool validPriceInput = false;
    decimal price = 0.0M;
    while (!validPriceInput) 
    {
        Console.WriteLine("Enter a price:");
        try
        {
            price = int.Parse(Console.ReadLine().Trim());
            validPriceInput = true;
        }
        catch (FormatException)
        {
            Console.WriteLine("✨🛑 Invalid price. Use digits only.✨\n");
        }
    }

    //ProductTypeId
    bool validIdInput =false;
    int chosenId = 0;
    while (!validIdInput) 
    {
        Console.WriteLine("Choose a type:");

        for (int i = 0; i < productTypes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {productTypes[i].Name}");
        }

        try
        {
            chosenId = int.Parse(Console.ReadLine().Trim());
            if (chosenId >= 1 && chosenId <= productTypes.Count)
            {
                validIdInput = true;
            }
            else
            {
                Console.WriteLine("\n✨🛑 Please enter a valid number corresponding to the product type.✨\n");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("✨🛑 Invalid choice. Use a number.✨\n");
        }
    }

    Product newProduct = new Product
    {
        Name = name,
        Price = price,
        Available = true,
        ProductTypeId = chosenId,
        DateStocked = DateTime.Now
    };

    products.Add(newProduct);

    Console.WriteLine("\n✨🌟 The spell is cast! Your product has been added to the inventory. 🌟✨");
    ReturnToMenu();
}

void DeleteProduct()
{
    Console.Clear();
    Console.WriteLine("DELETE PRODUCT");
    ListProducts();
    Console.WriteLine("Select a product to delete or enter 0 to cancel");

    bool validInput = false;
    while(!validInput)
    {
        try
        {
            int selection = int.Parse(Console.ReadLine().Trim());
            if(selection == 0)
            {
                Console.Clear();
                validInput = true;
            }
            else if(selection >= 1 && selection <= products.Count)
            {
                Product removeProduct = products[selection - 1];
                products.RemoveAt(selection - 1);
                validInput = true;
                Console.WriteLine($"\n✨🌟 Product Successfully Removed! 🌟✨");
                ReturnToMenu();
            }
            else
            {
                Console.WriteLine("\n✨🛑 Please enter a valid number corresponding to the product.✨\n");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("✨🛑 Invalid choice. Use a number.✨\n");
        }
    }
}

void UpdateProduct()
{
    Console.Clear();
    Console.WriteLine("UPDATE PRODUCT");
    ListProducts();
    Console.WriteLine("Select a product to update or enter 0 to cancel");

    bool validInput = false;
    int selection = 0;
    while (!validInput)
    {   
        try 
        {
            selection = int.Parse(Console.ReadLine().Trim());
            if (selection == 0)
            {
                Console.Clear();
                return;
            }
            else if (selection >= 1 && selection <= products.Count)
            {
                validInput = true;
            }
            else
            {
                Console.WriteLine("\n✨🛑 Please enter a valid number corresponding to a product.✨\n");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("✨🛑 Please select a valid product number.✨");
        }
    }

    Product productToUpdate = products[selection - 1];

    Console.Clear();
    Console.WriteLine($"Editing {productToUpdate.Name}");
    Console.WriteLine(@$"Current Details:
- Name: {productToUpdate.Name}
- Price: {productToUpdate.Price:C}
- In Stock: {productToUpdate.Available}
- Type: {ProductTypeName(productToUpdate.ProductTypeId)}

What would you like to update?
1. Name
2. Price
3. Availability
4. Product Type
0. Cancel");

    bool validEditInput = false;
    int choice = 0;
   
    while(!validEditInput)
    {
        choice = int.Parse(Console.ReadLine().Trim());
        switch (choice)
        {
            case 1:
                validEditInput = true;
                Console.WriteLine("Enter Name (or enter nothing to cancel): ");
                string nameEdit = Console.ReadLine().Trim();
                if (nameEdit == "")
                {
                    Console.Clear();
                }
                else 
                {
                    productToUpdate.Name = nameEdit;
                    Console.WriteLine($"✨🌟 Name updated to {nameEdit} 🌟✨");
                    ReturnToMenu();
                }
                break;
            case 2:
                validEditInput = true;
                bool validPrice = false;
                while(!validPrice)
                {
                    try
                    {
                        Console.WriteLine("Enter Price (or enter nothing to cancel): ");
                        string input = Console.ReadLine().Trim();
                       
                        if (string.IsNullOrEmpty(input))
                        {
                            Console.Clear();
                            validPrice = true;
                        }
                        else 
                        {
                            decimal newPrice = decimal.Parse(input);
                            productToUpdate.Price = newPrice;
                            Console.WriteLine($"✨🌟 Price updated to {newPrice:C} 🌟✨");
                            ReturnToMenu();
                            validPrice = true;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("✨🛑 Invalid price format. Please enter a valid decimal number. ✨");
                    }
                }
                break;
            case 3:
                validEditInput = true;
                bool validAvailability = false;  
                while (!validAvailability)
                {
                    Console.WriteLine(@"Enter Availability:
- enter 'true' for ✅ In Stock, 
- enter'false' for 🚫 Not In Stock, 
- or press Enter to cancel");
                    string availabilityInput = Console.ReadLine().Trim().ToLower();

                    if (string.IsNullOrEmpty(availabilityInput))
                    {
                        Console.Clear();
                        validAvailability = true;
                    }
                    else if (availabilityInput == "true")
                    {
                        productToUpdate.Available = true;
                        Console.WriteLine("✨🌟 Availability updated to ✅ In Stock 🌟✨");
                        validAvailability = true;
                        ReturnToMenu();
                    }
                    else if (availabilityInput == "false")
                    {
                        productToUpdate.Available = false;
                        Console.WriteLine("✨🌟 Availability updated to 🚫 Not In Stock 🌟✨");
                        validAvailability = true;
                        ReturnToMenu();
                    }
                    else
                    {
                        Console.WriteLine("✨🛑 Invalid input. Please enter 'true' or 'false'. ✨");
                    }
                }
                break;
            case 4:
                validEditInput = true;

                Console.WriteLine("Product Types:");
                for (int i = 0; i < productTypes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {productTypes[i].Name}");
                }
                Console.WriteLine("0. Cancel");

                bool validType = false;

                while (!validType)
                {
                    Console.WriteLine("Enter the type number (enter 0 to cancel):");

                    try
                    {
                        int chosenId = int.Parse(Console.ReadLine().Trim());
                        if (chosenId == 0)
                        {
                            Console.Clear();
                            validType = true;
                        }
                        else if (chosenId >= 1 && chosenId <= productTypes.Count)
                        {
                            productToUpdate.ProductTypeId = chosenId;
                            string typeName = productTypes[chosenId - 1].Name;
                            Console.WriteLine($"✨🌟 Product Type updated to {typeName} 🌟✨");
                            ReturnToMenu();
                            validType = true;
                        }
                        else
                        {
                            Console.WriteLine("\n✨🛑 Please enter a valid number corresponding to the product type.✨\n");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("✨🛑 Invalid choice. Use a number.✨\n");
                    }
                }
                break;
            case 0:
                validEditInput = true;
                Console.Clear();
                break;
            default:
                Console.WriteLine("\n💥 Oops! That spell isn't known. Please choose a valid option. 💥 \n");
                break;
        }
    }
}

void SearchProducts()
{
    Console.Clear();
    Console.WriteLine("SEARCH PRODUCTS");
    Console.WriteLine("Product Types:");
    
    // Display the list of product types
    for (int i = 0; i < productTypes.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {productTypes[i].Name}");
    }
    Console.WriteLine("0. Cancel");

    bool validType = false;

    while (!validType)
    {
        Console.WriteLine("Enter the type number (enter 0 to cancel):");

        try
        {
            int chosenId = int.Parse(Console.ReadLine().Trim());

            if (chosenId == 0)
            {
                Console.Clear();
                validType = true;
            }
            else if (chosenId >= 1 && chosenId <= productTypes.Count)
            {
                List<Product> productsFound = new List<Product>();

                // Find products matching the selected type
                foreach (Product product in products)
                {
                    if (product.ProductTypeId == chosenId)
                    {
                        productsFound.Add(product);
                    }
                }

                if (productsFound.Count == 0)
                {
                    Console.WriteLine("😞 No products match your selection.");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"{productTypes[chosenId - 1].Name} Products:\n");
                    Console.WriteLine(@"   NAME   |  PRICE  |  IN STOCK  |  PRODUCT TYPE
------------------------------------------------------------------------");
                    for (int i = 0; i < productsFound.Count; i++)
                    {
                        string productString = @$"{i + 1}. {productsFound[i].Name} | {productsFound[i].Price:C} | {(productsFound[i].Available ? "✅" : "🚫")} | {ProductTypeName(productsFound[i].ProductTypeId)}
------------------------------------------------------------------------";
                        Console.WriteLine(productString); 
                    }
                    ReturnToMenu(); 
                }
                validType = true;
            }
            else
            {
                Console.WriteLine("\n✨🛑 Please enter a valid number corresponding to the product type. ✨\n");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("✨🛑 Invalid choice. Use a number. ✨\n");
        }
    }
}
