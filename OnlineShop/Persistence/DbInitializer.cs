using OnlineShop.Domain.Models;

namespace OnlineShop.Persistence;

public static class DbInitializer
{
    public static void InitializeDishes(DefaultContext context)
    {
        if (context.Dishes.Any())
        {
            return;
        }

        var dishes = new Dish[]
        {
            new()
            {
                Name = "Kebab",
                Description = "Grilled meat, often served with rice, vegetables, and yogurt sauce.",
                Price = 6.99,
                Categories = new List<Category>
                {
                    context.Categories.First(c => c.Name == "Main Course"),
                    context.Categories.First(c => c.Name == "Grilled")
                },
                Currency = "EUR",
                Reviews = new List<Review>
                {
                    new()
                    {
                        Name = "John Doe",
                        Value = "Delicious!",
                        Stars = 5
                    }
                }
            },
            new()
            {
                Name = "Baklava",
                Description =
                    "A sweet pastry made of layers of filo filled with chopped nuts and sweetened with syrup or honey.",
                Price = 4.50,
                Categories = new List<Category>
                {
                    context.Categories.First(c => c.Name == "Dessert"),
                    context.Categories.First(c => c.Name == "Pastry"),
                },
                Currency = "EUR",
                Reviews = new List<Review>
                {
                    new()
                    {
                        Name = "Jane Smith",
                        Value = "Amazing dessert!",
                        Stars = 5
                    }
                }
            },
            new()
            {
                Name = "Iskender",
                Description = "Sliced doner kebab served on a bed of pita bread, topped with tomato sauce and yogurt.",
                Price = 9.99,
                Categories = new List<Category>
                {
                    context.Categories.First(c => c.Name == "Main Course"),
                    context.Categories.First(c => c.Name == "Grilled"),
                },
                Currency = "EUR",
                Reviews = new List<Review>
                {
                    new()
                    {
                        Name = "Michael Johnson",
                        Value = "Absolutely delicious!",
                        Stars = 5
                    }
                }
            },
            new()
            {
                Name = "Meze Platter",
                Description =
                    "An assortment of small, flavorful dishes such as hummus, tzatziki, and stuffed grape leaves.",
                Price = 12.50,
                Categories = new List<Category>
                {
                    context.Categories.First(c => c.Name == "Appetizer"),
                    context.Categories.First(c => c.Name == "Vegetarian"),
                },
                Currency = "EUR",
                Reviews = new List<Review>
                {
                    new()
                    {
                        Name = "Anna Davis",
                        Value = "Great variety of flavors!",
                        Stars = 4
                    }
                }
            },
            new()
            {
                Name = "Manti",
                Description = "Tiny dumplings filled with spiced meat, served with yogurt and garlic sauce.",
                Price = 10.99,
                Categories = new List<Category>
                {
                    context.Categories.First(c => c.Name == "Main Course"),
                    context.Categories.First(c => c.Name == "Dumplings"),
                },
                Currency = "EUR",
                Reviews = new List<Review>
                {
                    new()
                    {
                        Name = "David Brown",
                        Value = "Authentic and flavorful!",
                        Stars = 5
                    }
                }
            },
            new()
            {
                Name = "Turkish Delight",
                Description = "A sweet confection made of starch and sugar, often flavored with rosewater or citrus.",
                Price = 6.50,
                Categories = new List<Category>
                {
                    context.Categories.First(c => c.Name == "Dessert"),
                    context.Categories.First(c => c.Name == "Candy"),
                },
                Currency = "EUR",
                Reviews = new List<Review>
                {
                    new()
                    {
                        Name = "Emily White",
                        Value = "Delightful treat!",
                        Stars = 4
                    }
                }
            }
        };

        context.Dishes.AddRange(dishes);
        context.SaveChanges();
    }

    public static void InitializeCategories(DefaultContext context)
    {
        if (context.Categories.Any())
        {
            return;
        }

        var categories = new Category[]
        {
            new() { Name = "Main Course" },
            new() { Name = "Grilled" },
            new() { Name = "Dessert" },
            new() { Name = "Candy" },
            new() { Name = "Pastry" },
            new() { Name = "Appetizer" },
            new() { Name = "Vegetarian" },
            new() { Name = "Dumplings" },
        };
        
        context.Categories.AddRange(categories);
        context.SaveChanges();
    }
    
    public static void InitializeRestaurants(DefaultContext context)
    {
        if (context.Restaurants.Any())
        {
            return;
        }

        var restaurants = new List<Restaurant>
        {
            new() 
            { 
                Id = Guid.NewGuid(), 
                Name = "Sivach Grill", 
                Latitude = 50.4320068359375,
                Longitude = 30.548824310302734
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Sivach Kebap",
                Latitude = 50.433223724365234,
                Longitude = 30.550851821899414
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Sivach Shisha House",
                Latitude = 50.43281173706055,
                Longitude = 30.54745101928711
            }
        };
        
        context.Restaurants.AddRange(restaurants);
        context.SaveChanges();
    }
}